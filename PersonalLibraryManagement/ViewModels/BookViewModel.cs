using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalLibraryManagement.Models;

namespace PersonalLibraryManagement.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author {  get; set; }
        public string Category {  get; set; }
        public string Publisher {  get; set; }
        public int? PublishYear {  get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string Status {  get; set; }
        public string StorageLocation {  get; set; }
        
        public BookViewModel(int id, string title, string author, string category, string publisher, int? publishYear, string imagePath, string description, string status, string storageLocation)
        {
            Id = id;
            Title = title;
            Author = author;
            Category = category;
            Publisher = publisher;
            PublishYear = publishYear;
            Description = description;
            ImagePath = imagePath;
            Status = status;
            StorageLocation = storageLocation;
        }
    }
}
