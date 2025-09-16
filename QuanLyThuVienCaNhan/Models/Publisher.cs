using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVienCaNhan.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public Publisher() { }
        public Publisher(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

}
