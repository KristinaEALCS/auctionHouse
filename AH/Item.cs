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
    class Item
    {
        public string _itemName { get; set; }
        public int _price { get; set; }

        public Item(string itemName, int price)
        {
            _itemName = itemName;
            _price = price;
        }
    }
}
