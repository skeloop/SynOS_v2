using System;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Serveradresse und Portnummer
        string serverAddress = "45.93.251.65";
        int port = 65432;

        try
        {
            // Erstelle einen TcpClient
            TcpClient client = new TcpClient(serverAddress, port);
            Console.WriteLine("Verbunden mit dem Server");

            // Netzwerkstream für das Senden und Empfangen von Daten
            NetworkStream stream = client.GetStream();

            // Nachricht an den Server senden
            string message = Console.ReadLine();
            byte[] data = Encoding.ASCII.GetBytes(message);
            stream.Write(data, 0, data.Length);
            Console.WriteLine("Gesendet: {0}", message);

            // Antwort vom Server lesen
            data = new byte[256];
            int bytes = stream.Read(data, 0, data.Length);
            string responseData = Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine("Empfangen: {0}", responseData);
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
}


