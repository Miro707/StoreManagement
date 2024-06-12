using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storeBl.DAL
{
    public class dataAccessHelper
    {
        public static iDataAccess creatObject()
        { return new fileDataLayer(); }
    }
}
