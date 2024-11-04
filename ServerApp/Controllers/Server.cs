using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ServerApp
{
    internal static class Server
    {
        public static void StartServer()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 7777);

            try
            {
                listener.Start();
                Console.WriteLine("Сервер запущен. Порт 7777");

                while (true)
                {
                    try
                    {
                        TcpClient client = listener.AcceptTcpClient();
                        HandleClient(client);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка при принятии клиента: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при запуске сервера: {ex.Message}");
            }
            finally
            {
                listener.Stop();
            }
        }

        private static void HandleClient(TcpClient client)
        {
            using (client)
            using (NetworkStream stream = client.GetStream())
            {
                try
                {
                    byte[] buffer = new byte[client.ReceiveBufferSize];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    string request = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    string response = CommandHandler.HandleRequest(request) ?? "Ошибка обработки запроса";
                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);


                    stream.Write(responseBytes, 0, responseBytes.Length);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка обработки клиента: {ex.Message}");
                }
            }
        }
    }
}
