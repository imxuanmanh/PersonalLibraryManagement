using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibraryManagement.Models
{
    public class LoanHistory
    {
        public int Id { get; set; }
        public int BookId {  get; set; }
        public string BorrowerName {  get; set; }
        public string LenderName { get; set; }
        public DateTime? LoanDate { get; set; }
        public DateTime? MustReturnDate {  get; set; }
        public DateTime? ActualReturnDate {  get; set; }

        public LoanHistory() { }



        public LoanHistory(int bookId, string borrowerName, string lenderName, DateTime? loanDate, DateTime? mustReturnDate, DateTime? actualReturnDate)
        {
            BookId = bookId;
            BorrowerName = borrowerName;
            LenderName = lenderName;
            LoanDate = loanDate;
            MustReturnDate = mustReturnDate;
            ActualReturnDate = actualReturnDate;
        }
    }
}
