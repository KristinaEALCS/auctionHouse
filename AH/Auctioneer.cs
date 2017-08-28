using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Collections;

namespace AH
{
    class Auctioneer
    {
        int currentPrice;
        int startPrice = 0;
        string itemName;
        int buyOutPrice;
        Dictionary<string, int> Users;
        List<int> whatyoulike;
        public Item _item;


        public Auctioneer(Item item)
        {
            Users = new Dictionary<string, int>();
            whatyoulike = new List<int>();
            _item = item;
        }

        public string Bidding(int price)
        {
            startPrice = price;
            if (Users.Count <= 0 )
            {
                return startPrice.ToString();
            }
            else
            {
                List<KeyValuePair<string, int>> convertedPrices = Users.ToList();
                foreach (var prices in convertedPrices)
                {
                    whatyoulike.Add(prices.Value);
                }

                int maxprice = whatyoulike.Max();
                return maxprice.ToString();

            }
           
        }   

        public void Requeue(string ip, int price)
        {
            Users.Add(ip, price);
        }
    }
}
