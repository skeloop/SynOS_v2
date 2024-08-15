using System.Net.Sockets;
using System.Text;

namespace DevKit
{
    public class Client
    {
        private static NetworkStream networkStream;
        public void Connect()
        {
            // Serveradresse und Portnummer
            string serverAddress = "45.93.251.65"; // 
            int port = 65432;

            try
            {
                // Erstelle einen TcpClient
                TcpClient client = new TcpClient(serverAddress, port);
                Console.WriteLine("Verbunden mit dem Server");

                // Netzwerkstream für das Senden und Empfangen von Daten
                NetworkStream stream = client.GetStream();
                networkStream = stream;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }

            Console.WriteLine("Drücken Sie eine beliebige Taste, um fortzufahren...");
            Console.ReadKey();
        }
        public static void Send(object message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message), "Message cannot be null.");
            }

            string messageString = message.ToString();
            byte[] data = Encoding.ASCII.GetBytes(messageString);

            try
            {
                networkStream.Write(data, 0, data.Length);
                Console.WriteLine("Gesendet: {0}", messageString);
            }
            catch (IOException ioEx)
            {
                Console.WriteLine("I/O error occurred: {0}", ioEx.Message);
            }
            catch (SocketException sockEx)
            {
                Console.WriteLine("Socket error occurred: {0}", sockEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: {0}", ex.Message);
            }
        }
        public static object Response()
        {
            // Antwort vom Server lesen
            byte[] data = new byte[256];
            int bytes = networkStream.Read(data, 0, data.Length);
            return Encoding.ASCII.GetString(data, 0, bytes);
        }
    }
}
