using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibraryManagement.Models
{
    public class ShelfRow
    {
        public int Id { get; set; }
        public int ShelfId {  get; set; }
        public int Ordinal { get; set; }
    }
}
