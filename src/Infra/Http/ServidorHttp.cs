using System.Net;
using System.Runtime.Serialization;
using System.Text;
using src.Interfaces;

namespace src.Infra.Http
{
    public class ServidorHttp : IHttp
    {
        public async Task Excute()
        {
            String urlServer = "http://127.0.0.1:8909/";
            using var serverHttp = new HttpListener();
            serverHttp.Prefixes.Add(urlServer);
            serverHttp.Start();
            Console.WriteLine($"Servidor rodando em {urlServer}");

            while (true)
            {
                var contexto = await serverHttp.GetContextAsync();
                var request = contexto.Request;
                var response = contexto.Response;

                Console.WriteLine($"Recebido: {request.HttpMethod} {request.Url}");

                String responseStringHtml = "<html><body><h1> Olá Mundo </h1></body></html>";
                byte[] buffer = Encoding.UTF8.GetBytes(responseStringHtml);

                using var output = response.OutputStream;
                await output.WriteAsync(buffer, 0, buffer.Length);
            }
        }
    }
}