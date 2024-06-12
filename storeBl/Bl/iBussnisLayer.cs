using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storeBl.Bl
{
    public interface iBussnisLayer<t>
    {
        // make mithod Add
        bool Add(t table);
        // make mithod for delet
        bool Delet(t id);
        // get all data frome store model and store it in list 
        List<t> GetAll();
    }
}
