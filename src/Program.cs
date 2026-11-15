using src.Infra.Http;

class Program
{
    public async static Task Main()
    {
        Console.WriteLine("Rodando");
        var serverHttpRun = new ServidorHttp();
        await serverHttpRun.Excute();
    }
}