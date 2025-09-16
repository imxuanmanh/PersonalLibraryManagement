using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyThuVienCaNhan.Models;

namespace QuanLyThuVienCaNhan.Repositories
{
    public interface IBookStorage
    {
        Dictionary<int, Book> LoadData();
        void Insert(Book book);
        void Update(Book book);
        void Delete(int bookId);
    }
}
