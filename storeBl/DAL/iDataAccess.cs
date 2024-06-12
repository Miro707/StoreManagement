using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storeBl.DAL
{
    public interface iDataAccess
    {
        void creat(string tableName);
        void insert(string tableName /* file name  */ , string data /* insert data */);
        void delet(string tableName /* name  */ , string data /* insert data */);
        string GetAll(string tableName);
    }
}
