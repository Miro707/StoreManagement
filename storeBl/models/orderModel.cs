using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using storeBl.models;

namespace storeBl.models
{
    public class orderModel
    {
        public orderModel()
        {
              
            orderItem = new itemModel();
            orderStore = new storeModel();
        }
        public int orderId { get; set; }
        public DateTime orderDate{get;set;}
        public itemModel orderItem { get; set; }  // Change from int to itemModel
        public storeModel orderStore { get; set; } // Change from int to storeModel

       
    }

}
