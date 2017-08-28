using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
namespace AH
{
    class Program
    {
        

        static void Main(string[] args)
        {
           
            ClientHandler ch = new ClientHandler();
            ch.listener.Start();
            while (true)
            {
                
                Thread t = new Thread(ch.Run);
                t.Start();
                Console.ReadKey();

            }

           


        }

       
    }

   public class ClientHandler
    {
       public TcpListener listener;
        Socket client;
        NetworkStream stream;
        StreamReader reader;
        StreamWriter writer;
        Auctioneer auctioneer;
        
        

        public ClientHandler()
        {
            listener = new TcpListener(IPAddress.Any, 11000);
            auctioneer = new Auctioneer(new Item("auction" , 150));
            

        }
        public void Run()
        {

            DoDialog();
            Start();
            Send("Epic sax Guy");
            Console.ReadKey();

        }

        public void Start()
        {
            try
            {
               
                client = listener.AcceptSocket();
                stream = new NetworkStream(client);
                writer = new StreamWriter(stream, Encoding.ASCII);
                writer.AutoFlush = true;
                reader = new StreamReader(stream, Encoding.ASCII);
                Console.WriteLine("Ready");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Send(string message)
        {
            writer.WriteLine(message);

        }

        public string Receive()
        {
            string input = reader.ReadLine();
            return input;
        }

        public void DoDialog()
        {
            Console.WriteLine("Bidding is starting");
            Console.WriteLine("Current bid is " + auctioneer.Bidding(auctioneer._item._price));

        }


    }

}
