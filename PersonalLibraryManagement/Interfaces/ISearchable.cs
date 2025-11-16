using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibraryManagement.Interfaces
{
    public interface ISearchable
    {
        // void Filter(string searchText);

        void Filter(string keyword = "", string category = "", string author = "");
    }
}
