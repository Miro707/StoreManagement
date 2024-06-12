using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storeBl.DAL
{
    public class fileDataLayer : iDataAccess
    {
        public void creat(string tableName)
        {
            try
            {
                File.CreateText(tableName);
            }
            catch { Console.WriteLine("invaled"); }
        }

        public void delet(string tableName, string data)
        {
            try
            {
                File.WriteAllText(tableName, data);
            }
            catch { Console.WriteLine("Invaled"); }
        }

        public string GetAll(string tableName)
        {
            try
            {
                return File.ReadAllText(tableName);
            }
            catch(Exception ex)
            {
               return "invaled";
            }
        }

        public void insert(string tableName, string data)
        {
            try
            {
                File.AppendAllText(tableName, data);
            }
            catch { Console.WriteLine("invaled"); }
        }
    }
}
