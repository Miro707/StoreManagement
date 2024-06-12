using storeBl.DAL;
using storeBl.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storeBl.Bl
{
    public class clsStore : iBussnisLayer<storeModel>
    {
        #region Add
        public bool Add(storeModel table)
        {
            // Create a new store string in the format "storeId#storeName"
            string storeString = string.Format($"{table.storeID}#{table.storeName}-");

            // Get the data access object and insert the store string into the "store.txt" file
            iDataAccess mydataAccess = dataAccessHelper.creatObject();
            mydataAccess.insert("store.txt", storeString);

            // Return true to indicate that the store was successfully added
            return true;
        } 
        #endregion

        #region delete
        public bool Delet(int id)
        {
            List<storeModel> listStore = GetAll();
            storeModel model = listStore.Where(find => find.storeID == id).FirstOrDefault();
            if (model == null)
                return false;
            else
            {
                listStore.Remove(model);
                string sFileData = string.Empty;
                int nCount = 0;
                foreach (var store in listStore)
                {
                    if (nCount == 0)
                    {
                        sFileData += string.Format("{0}#{1}", store.storeID, store.storeName);
                    }
                    else
                    {
                        sFileData += string.Format("-{0}#{1}", store.storeID, store.storeName);
                    }
                    nCount++;
                }
                iDataAccess mydatAccess = dataAccessHelper.creatObject();
                mydatAccess.delet("store.txt", sFileData);
                return true;
            }

        }


        // make mithod for delet

        public bool Delet(storeModel id)
        {
            List<storeModel> listStore = GetAll();
            storeModel model = listStore.Where(find => find.storeID == id.storeID).FirstOrDefault();
            if (model == null)
                return false;
            else
            {
                listStore.Remove(model);
                string sFileData = string.Empty;
                int nCount = 0;
                foreach (var store in listStore)
                {
                    if (nCount == 0)
                    {
                        sFileData += string.Format("{0}#{1}", store.storeID, store.storeName);
                    }
                    else
                    {
                        sFileData += string.Format("-{0}#{1}", store.storeID, store.storeName);
                    }
                    nCount++;
                }
                iDataAccess mydatAccess = dataAccessHelper.creatObject();
                mydatAccess.delet("store.txt", sFileData);
                return true;
            }

        } 
        #endregion

        #region getAll
        public List<storeModel> GetAll()
        {
            


            iDataAccess myDataAccess = dataAccessHelper.creatObject();
            string storeData = myDataAccess.GetAll("store.txt");
            string[] storeFileds = storeData.Split('-');
            storeModel oStoreModel;
            List<storeModel> listStore = new List<storeModel>();
            foreach (var store in storeFileds)
            {
                if (string.IsNullOrEmpty(store)) continue;
                oStoreModel = new storeModel();
                string[] split_hash = store.Split('#');
                oStoreModel.storeID = Convert.ToInt32(split_hash[0]);
                oStoreModel.storeName = split_hash[1];
                listStore.Add(oStoreModel);

            }
            return listStore;
        } 
        #endregion

    }
}
