using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    internal class Client
    {
        public string SendRequest(string request)
        {
            using (TcpClient client = new TcpClient())
            {
                try
                {
                    client.Connect("localhost", 7777);

                    NetworkStream stream = client.GetStream();
                    byte[] data = Encoding.UTF8.GetBytes(request);
                    stream.Write(data, 0, data.Length);

                    byte[] buffer = new byte[client.ReceiveBufferSize];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    return Encoding.UTF8.GetString(buffer, 0, bytesRead);
                }
                catch (SocketException ex)
                {
                    return $"Ошибка подключения: {ex.Message}";
                }
                catch (Exception ex)
                {
                    return $"Произошла ошибка: {ex.Message}";
                }
            }
        }
    }
}
