using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibraryManagement.Models
{
    public class Circulation
    {
        public int Id { get; set; }
        public int BookId {  get; set; }
        public string BookTitleSnapshot {  get; set; }
        public string BorrowerName {  get; set; }
        public string LenderName { get; set; }
        public DateTime CirculationDate { get; set; } = DateTime.Now;
        public DateTime? ReturnDate {  get; set; }

        public Circulation() { }
    }
}
