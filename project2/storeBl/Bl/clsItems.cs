using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.SqlServer.Server;
using storeBl.DAL;
using storeBl.models;

namespace storeBl.Bl
{
    public class clsItems : iBussnisLayer<itemModel>
    {
        #region Add
        public bool Add(itemModel table)
        {
            // make list equal get all 
            List<itemModel> listItems = GetAll();
            string storedData = string.Format("{0}#{1}#{2}-", table.itemId, table.itemName, table.itemPrice);    
            iDataAccess MyIdataAccess = dataAccessHelper.creatObject();
            MyIdataAccess.insert("items.txt", storedData);
            return true;
        } 
        #endregion

        #region delete
        public bool Delet(itemModel id)
        {
            List<itemModel> listItems = GetAll();
            itemModel findData = listItems.Where(find => find.itemId == id.itemId).FirstOrDefault();
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
                        sStoreData += string.Format($"{id.itemId}#{id.itemName}#{id.itemPrice}");
                    }
                    else
                        sStoreData += string.Format($"-{id.itemId}#{id.itemName}#{id.itemPrice}");
                    nCount++;
                }
                iDataAccess mydatAccess = dataAccessHelper.creatObject();
                mydatAccess.delet("items.txt", sStoreData);
                return true;
            }
        }

        public bool Delet(int id)
        {
            List<itemModel> listItems = GetAll();
            itemModel findData = listItems.Where(find => find.itemId == find.itemId).FirstOrDefault();
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
                        sStoreData += string.Format($"{findData.itemId}#{findData.itemName}#{findData.itemPrice}");
                    }
                    else
                        sStoreData += string.Format($"{findData.itemId}#{findData.itemName}#{findData.itemPrice}-");
                    nCount++;
                }
                iDataAccess mydatAccess = dataAccessHelper.creatObject();
                mydatAccess.delet("items.txt", sStoreData);
                return true;
            }
        }

        #endregion

        #region getAll
        public List<itemModel> GetAll()
        {
            iDataAccess myDataAccess = dataAccessHelper.creatObject();
            string storeData = myDataAccess.GetAll("items.txt");
            string[] splitStoreData = storeData.Split('-');
            List<itemModel> listItems = new List<itemModel>();
            foreach (var items in splitStoreData)
            {
                if (string.IsNullOrEmpty(items)) continue;
                string[] splitItems = items.Split('#');
                itemModel oitemModel = new itemModel();
                oitemModel.itemId = Convert.ToInt32(splitItems[0]);
                oitemModel.itemName = splitItems[1];
                oitemModel.itemPrice = Convert.ToDecimal(splitItems[2]);
                listItems.Add(oitemModel);

            }
            return listItems;
        } 
        #endregion
    }
}
