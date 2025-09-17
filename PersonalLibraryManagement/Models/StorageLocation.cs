using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibraryManagement.Models
{
    public class StorageLocation
    {
        public int Id {  get; set; }
        public string Room {  get; set; }
        public string Shelf { get; set; }
        public string Row {  get; set; }

        public override string ToString()
        {
            return string.Format($"{Room} - {Shelf} - {Row}");
        }
    }
}
