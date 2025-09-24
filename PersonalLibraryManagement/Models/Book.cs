using PersonalLibraryManagement.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibraryManagement.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? AuthorId { get; set; }
        public int? CategoryId { get; set; }
        public int? PublisherId { get; set; }
        public int? PublishYear { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; } = PathManager.GetImagePath("place-holder.png");
        public int StorageLocationId { get; set; }

        public Book()
        {

        }

        public Book(string title, string author, string category)
        {

        }

        public Book(string title, string author, string category, int pageCount, string description, bool isBorrow)
        {
            //Title = title;
            //Author = author;
            //Category = category;
            //PageCount = pageCount;
            //Description = description;
            //AddedDate = DateTime.Now;
            //Status = ReadingStatus.NotRead;
            //IsBorrowed = isBorrow;
        }

        //public void Lend(string borrowerName, DateTime expectedReturnDate)
        //{
        //    IsLent = true;
        //    BorrowerName = borrowerName;
        //    LentDate = DateTime.Now;
        //    ExpectedReturnDate = expectedReturnDate;
        //}

        //public void ReturnFromBorrower()
        //{
        //    IsLent = false;
        //}

        //public void Borrow(string lenderName, DateTime mustReturnDate)
        //{
        //    IsBorrowed = true;
        //    LenderName = lenderName;
        //    BorrowDate = DateTime.Now;
        //    MustReturnDate = mustReturnDate;
        //}

        //public void ReturnToOwner()
        //{
        //    IsBorrowed = false;
        //    LenderName = null;
        //    BorrowDate = null;
        //    MustReturnDate = null;
        //}

        public override bool Equals(object obj)
        {
            if (obj is Book ortherBook)
            {
                return this.Id == ortherBook.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
