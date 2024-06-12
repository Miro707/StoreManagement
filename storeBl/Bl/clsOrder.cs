using storeBl.DAL;
using storeBl.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;


namespace storeBl.Bl
{
    public class clsOrder : iBussnisLayer<orderModel>
    {
        #region Add
        public bool Add(orderModel table)
        {

            iDataAccess myDataAccess = dataAccessHelper.creatObject();
            string storeData = string.Format($"{table.orderId}#{table.orderDate}#{table.orderItem.itemId}#{table.orderStore.storeID}-");
            myDataAccess.insert("order.txt", storeData);
            return true;
        } 
        #endregion

        #region delete
        public bool Delet(orderModel id)
        {
            List<orderModel> listItems = GetAll();
            orderModel findData = listItems.Where(find => find.orderId == id.orderId).FirstOrDefault();
            if (findData == null)
                return false;
            else
            {
                listItems.Remove(findData);
                string sStoreData = string.Empty;
                int nCount = 0;
                foreach (var items in listItems)
                {
                    if (nCount == 0)
                    {
                        sStoreData += string.Format($"{id.orderId}#{id.orderDate}#{id.orderItem.itemId}#{id.orderStore.storeID}");
                    }
                    else
                        sStoreData += string.Format($"-{id.orderId}#{id.orderDate}#{id.orderItem.itemId}#{id.orderStore.storeID}");
                    nCount++;
                }
                iDataAccess mydatAccess = dataAccessHelper.creatObject();
                mydatAccess.delet("items.txt", sStoreData);
                return true;
            }
        }

        public bool Delet(int id)
        {
            List<orderModel> listOrders = GetAll();
            orderModel findData = listOrders.Where(find => find.orderId == find.orderId).FirstOrDefault();
            if (findData == null)
                return false;
            else
            {
                listOrders.Remove(findData);
                string sStoreData = string.Empty;
                int nCount = 0;
                foreach (var items in listOrders)
                {
                    if (nCount == 0)
                    {
                        sStoreData += string.Format($"{findData.orderId}#{findData.orderDate}#{findData.orderItem.itemId}#{findData.orderStore.storeID}");
                    }
                    else
                        sStoreData += string.Format($"-{findData.orderId}#{findData.orderDate}#{findData.orderItem.itemId}#{findData.orderStore.storeID}");
                    nCount++;
                }
                iDataAccess mydatAccess = dataAccessHelper.creatObject();
                mydatAccess.delet("order.txt", sStoreData);
                return true;
            }
        }

        #endregion

        #region getAll
        public List<orderModel> GetAll()
        {
            iDataAccess myDataAccess = dataAccessHelper.creatObject();
            string storeData = myDataAccess.GetAll("order.txt");
            string[] splitStoreData = storeData.Split('-');
            List<orderModel> listItems = new List<orderModel>();
            foreach (var items in splitStoreData)
            {
                if (string.IsNullOrEmpty(items)) continue;
                string[] splitItems = items.Split('#');
                orderModel oOrderModel = new orderModel();
                oOrderModel.orderId = Convert.ToInt32(splitItems[0]);
                oOrderModel.orderDate = Convert.ToDateTime(splitItems[1]);
                oOrderModel.orderItem.itemId = Convert.ToInt32(splitItems[2]);
                oOrderModel.orderStore.storeID = Convert.ToInt32(splitItems[3]);
                listItems.Add(oOrderModel);

            }
            return listItems;

        } 
        #endregion
    }
}
