using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;


namespace Server
{
    class Program
    {
        private static Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static List<Socket> sockets = new List<Socket>();
        private static Dictionary<IPAddress,string> bids = new Dictionary<IPAddress,string>();
            
        static void Main(string[] args)
        {             
            IPEndPoint remote = new IPEndPoint(IPAddress.Any , 11000);
            listener.Bind(remote);
            listener.Listen(10);
            Console.WriteLine("Server is ready");
            listener.BeginAccept(new AsyncCallback(AcceptCallBack), null );
            Console.WriteLine("Press any key to close");
            Console.ReadKey();

        }

        private static void AcceptCallBack(IAsyncResult ar)
        {
            Socket s = listener.EndAccept(ar);
            sockets.Add(s);
            string str = "Highest bid:" + HighestBid();

            byte[] bytes = Encoding.ASCII.GetBytes(str);
            s.BeginSend(bytes,0,bytes.Length,SocketFlags.None,new AsyncCallback(EndSend),s);
            listener.BeginAccept(new AsyncCallback(AcceptCallBack), null);
        }

        private static void EndSend(IAsyncResult ar)
        {
            Socket s = (Socket) ar.AsyncState;
            s.EndSend(ar);
            
        }

        private static string HighestBid()
        {
            return "0";
                
        }
    }
}
