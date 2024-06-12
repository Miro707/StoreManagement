using storeBl.Bl;
using storeBl.models;
using System;
using System.Collections.Generic;
using System.Linq;
using storeBl.models;



namespace project2
{
    public class uiHelper
    {
        #region mainOptions
        public static void MainOption()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t|----------------------------------------|");
            Console.WriteLine("\t\t\t \t|\t   welcome to our store\t \t |");
            Console.WriteLine("\t\t\t\t|----------------------------------------|");
            Console.WriteLine("\t\t\t \t|\t   to manege stores press 1\t |");
            Console.WriteLine("\t\t\t\t|----------------------------------------|");
            Console.WriteLine("\t\t\t \t|\t   to manage items prees 2\t |");
            Console.WriteLine("\t\t\t\t|----------------------------------------|");
            Console.WriteLine("\t\t\t \t|\t   to manage orders prees 3\t |");
            Console.WriteLine("\t\t\t\t|----------------------------------------|");
            Console.WriteLine("\t\t\t \t|   to close the application prees 0\t |");
            Console.WriteLine("\t\t\t\t|----------------------------------------|");



        }
        #endregion

        #region itemOptions
        public static void itemOptions()
        {
            string itemOption = string.Empty;
            while (itemOption != "e")
            {

                itemModel oitemModel = new itemModel();
                clsItems oclsItems = new clsItems();
                Console.WriteLine("\t\t\t\t|----------------------------------------|");
                Console.WriteLine("\t\t\t\t|\t   welcome to manege item \t |");
                Console.WriteLine("\t\t\t\t|----------------------------------------|");
                Console.WriteLine("\t\t\t\t|\t   to Add items press 1\t\t |");
                Console.WriteLine("\t\t\t\t|----------------------------------------|");
                Console.WriteLine("\t\t\t\t|\t   to delet items prees 2\t |");
                Console.WriteLine("\t\t\t\t|----------------------------------------|");
                Console.WriteLine("\t\t\t\t|\t   to get All items prees 3   \t |");
                Console.WriteLine("\t\t\t\t|----------------------------------------|");
                Console.WriteLine("\t\t\t\t|\t   to go Backe prees 0     \t |");
                Console.WriteLine("\t\t\t\t|----------------------------------------|");
                itemOption = Console.ReadLine();
                switch (itemOption)
                {
                    #region Add
                    case "1":


                        try
                        {
                            Console.Clear();

                            // ask user to enter item ID 
                            Console.WriteLine("please enter item ID");
                            oitemModel.itemId = Convert.ToInt32(Console.ReadLine());
                            // ask user to enter item name 
                            Console.WriteLine("please enter items name ");
                            oitemModel.itemName = Console.ReadLine();
                            // ask user to enter item price
                            Console.WriteLine("please enter item price ");
                            oitemModel.itemPrice = Convert.ToDecimal(Console.ReadLine());

                            // store object of item model in clsitems
                            oclsItems.Add(oitemModel);

                        }
                        catch
                        {
                            Console.WriteLine("invaled ID");
                        }
                        break;
                    #endregion

                    #region delet
                    case "2":
                        Console.WriteLine("please enter store ID");
                        int nStoredId;
                        bool beCanConverted = int.TryParse(Console.ReadLine(), out nStoredId);
                        if (beCanConverted)
                        {
                            bool isDeleted = oclsItems.Delet(nStoredId);
                            if (!isDeleted)
                            {
                                Console.WriteLine("not founded");
                            }
                        }
                        break;
                    #endregion


                    #region getAll
                    case "3":
                        Console.Clear();
                        List<itemModel> listItemModel = oclsItems.GetAll();
                        showAllItems(listItemModel);
                        break;
                  

                    default:
                        Console.WriteLine("invaled option");
                        break;
                        #endregion

                }
            }

        }
        #region showAllItems
        public static void showAllItems(List<itemModel> listItems)
        {

            foreach (var items in listItems)
            {
                Console.WriteLine(string.Format("store id {0} store name {1} store price{2}", items.itemId, items.itemName, items.itemPrice));


            }
        }
       
        #endregion 
        #endregion

        #region storeOptions
        public static void storeOPtions()

        {
            string sStoreOption = string.Empty;
            while (sStoreOption != "0")
            {

                Console.WriteLine("\t\t\t\t|----------------------------------------|");
                Console.WriteLine("\t\t\t\t|\t   welcome to maneg store data\t |");
                Console.WriteLine("\t\t\t\t|----------------------------------------|");
                Console.WriteLine("\t\t\t\t|\t   to Add stores press 1\t |");
                Console.WriteLine("\t\t\t\t|----------------------------------------|");
                Console.WriteLine("\t\t\t\t|\t   to delet store prees 2\t |");
                Console.WriteLine("\t\t\t\t|----------------------------------------|");
                Console.WriteLine("\t\t\t\t|\t   to get All store prees 3   \t |");
                Console.WriteLine("\t\t\t\t|----------------------------------------|");
                Console.WriteLine("\t\t\t\t|\t   to go Backe prees 0     \t |");
                Console.WriteLine("\t\t\t\t|----------------------------------------|");
                storeModel ostoreModel = new storeModel();
                clsStore oclsStore = new clsStore(); // make object frome cls store to store data in file 
                sStoreOption = Console.ReadLine();
                switch (sStoreOption)
                {
                    #region Add
                    case "1":
                        try
                        {
                            Console.WriteLine("please enter store ID");

                            ostoreModel.storeID = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("please enetr store name ");
                            ostoreModel.storeName = Console.ReadLine();
                            oclsStore.Add(ostoreModel);
                        }
                        catch
                        {
                            Console.WriteLine("invaled ID");
                            break;
                        }
                        break;
                    #endregion

                    #region delet
                    case "2":
                        Console.WriteLine("please enter store ID");
                        int nStoredId;
                        bool beCanConverted = int.TryParse(Console.ReadLine(), out nStoredId);
                        if (beCanConverted)
                        {
                            bool isDeleted = oclsStore.Delet(nStoredId);
                            if (!isDeleted)
                            {
                                Console.WriteLine("not founded");
                            }
                        }
                        break;
                    #endregion

                    #region getAll
                    case "3":
                        List<storeBl.models.storeModel> listStoreModel = oclsStore.GetAll(); // make list frome store model and take object from it
                        showAllStores(listStoreModel); // show data frome file to user 
                        break;
                    default:
                        Console.WriteLine("invaled option");
                        break;
                        #endregion

                }



            }



        }

        #region shwAllStore
        public static void showAllStores(List<storeModel> listStores)
        {
            foreach (var store in listStores)
            {
                Console.WriteLine(string.Format($"stored id {store.storeID}  store name {store.storeName}"));
            }
        }
        #endregion

        #endregion

        // order options 
        #region orderOptions
        public static void orderOPtions()

        {
            string sOrderOption = string.Empty;
            while (sOrderOption != "0")
            {

                Console.WriteLine("\t\t\t\t|----------------------------------------|");
                Console.WriteLine("\t\t\t\t|\t   welcome to maneg store data\t |");
                Console.WriteLine("\t\t\t\t|----------------------------------------|");
                Console.WriteLine("\t\t\t\t|\t   to Add order press 1\t \t |");
                Console.WriteLine("\t\t\t\t|----------------------------------------|");
                Console.WriteLine("\t\t\t\t|\t   to delet order prees 2\t |");
                Console.WriteLine("\t\t\t\t|----------------------------------------|");
                Console.WriteLine("\t\t\t\t|\t   to get All order prees 3   \t |");
                Console.WriteLine("\t\t\t\t|----------------------------------------|");
                Console.WriteLine("\t\t\t\t|\t   to go Backe prees 0     \t |");
                Console.WriteLine("\t\t\t\t|----------------------------------------|");
                clsOrder oclsOrder = new clsOrder(); // make object frome cls store to store data in file 
                orderModel oOrderModel = new orderModel();
                sOrderOption = Console.ReadLine();
                switch (sOrderOption)
                {
                    #region ADD
                    case "1":
                        try
                        {


                            Console.WriteLine("please enter item iD");
                            oOrderModel.orderId = int.Parse(Console.ReadLine());
                            oOrderModel.orderDate = DateTime.Now;
                            Console.WriteLine("please enter item id");
                            oOrderModel.orderItem.itemId = int.Parse(Console.ReadLine());
                            Console.WriteLine("please enter store id");
                            oOrderModel.orderStore.storeID = int.Parse(Console.ReadLine());

                            oclsOrder.Add(oOrderModel);

                        }
                        catch
                        {
                            Console.WriteLine("invaled ID");
                            break;
                        }
                        break;
                    #endregion

                    #region delet
                    case "2":
                        Console.WriteLine("please order order ID");
                        int nOrderId;
                        bool beCanConverted = int.TryParse(Console.ReadLine(), out nOrderId);
                        if (beCanConverted)
                        {
                            bool isDeleted = oclsOrder.Delet(nOrderId);
                            if (!isDeleted)
                            {
                                Console.WriteLine("not founded");
                            }
                        }
                        break;
                    #endregion

                    #region getAll
                    case "3":
                        List<storeBl.models.orderModel> listOrderModel = oclsOrder.GetAll(); // make list frome order model and take object from it
                        showAllOrders(listOrderModel); // show data frome file to user 
                        break;
                    default:
                        Console.WriteLine("invaled option");
                        break;
                        #endregion

                }



            }



        }
        #region showAllOptions
        public static void showAllOrders(List<orderModel> listOrder)
        {
            foreach (var order in listOrder)
            {
                Console.WriteLine(string.Format($"order id {order.orderId} data {order.orderDate}   item id {order.orderItem.itemId} store id {order.orderStore.storeID}  "));
            }
        }
        #endregion

        #endregion
    }


}
