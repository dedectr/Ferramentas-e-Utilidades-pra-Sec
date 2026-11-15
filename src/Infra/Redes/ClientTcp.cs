using System.Formats.Asn1;
using System.Net;
using System.Net.Sockets;
using System.Text;
using src.Interfaces;

namespace src.Infra.Redes
{
    public class ClientTCP : IRedes
    {
        public Task<bool> Excute()
        {
            throw new NotImplementedException();
        }

        public async Task Logic(string? msgSend)
        {
            try
            {
                IPHostEntry ipDNS = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipADRR = ipDNS.AddressList[0];
                IPEndPoint ipEndPoint = new IPEndPoint(ipADRR, 9088);

                Socket sender = new Socket(ipADRR.AddressFamily,SocketType.Stream,ProtocolType.Tcp);
                try
                {
                    await sender.ConnectAsync(ipEndPoint);
                    Console.WriteLine("Scoket está Conectador no  -> {0}", sender.RemoteEndPoint.ToString());
                    byte[] msgSent = Encoding.ASCII.GetBytes(msgSend);
                    int byteSent = await sender.SendAsync(msgSent);
                    byte[] msgRevindicar = new byte[2048];
                    
                }
                catch (System.Exception)
                {
                    
                    throw;
                }
            }
            catch (Exception e)
            {
                
                throw;
            }
        }
    }
}