using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Eolienne
{
    class Client_Scoket_Asynchrone
    {
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        Client_Scoket_Asynchrone oclient = new Client_Scoket_Asynchrone();
        NetworkStream networkStream;

        public void Connect(string ipAddress, int port)
        {
            clientSocket.Connect("127.0.0.1", 23);

        }

        public void Send(string data)
        {

        }

        public void Close()
        {
            clientSocket.Close();
        }

     public void Receive()
        {
            // écrire la commmande
        }
    }
}
