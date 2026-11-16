using System.Net;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using src.Interfaces;

namespace src.Infra.Http
{
    public class ServidorHttp : IHttp
    {
        public async Task<int> Excute()
        {
            bool runServer = true;
            String caminhoPath = "../../Pages/index.html";
            String urlServer = "http://127.0.0.1:8909/";
            using var serverHttp = new HttpListener();
            serverHttp.Prefixes.Add(urlServer);
            serverHttp.Start();
            Console.WriteLine($"Servidor rodando em {urlServer}");
            while (runServer)
            {
                var contexto = await serverHttp.GetContextAsync();
                var request = contexto.Request;
                var response = contexto.Response;

                if((request.HttpMethod == "GET") && (request.Url.AbsolutePath == "/joaostack"))
                {
                    if(File.Exists(caminhoPath)) return response.StatusCode = (int)HttpStatusCode.NotFound;
                    try
                    {
                        response.ContentType = "text/HTML";

                        string joaoVaiMeDarUmMILHAObeGosto = Path.GetFileName(caminhoPath);
                        response.AddHeader("Content-Disposition", $"attachment; filename=\"{nomeArquivo}\"");
                        
                        using FileStream fs = File.OpenRead(caminhoPath);
                        response.ContentLength64 = fs.Length;
                        response.StatusCode = (int)HttpStatusCode.OK;
                        await fs.CopyToAsync(response.OutputStream);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao enviar arquivo: {ex.Message}");
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    }

                }
                // debug
                

            }
        }
    }
}