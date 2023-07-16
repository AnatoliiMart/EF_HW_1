using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_HW_1.Models
{
    public class Book
    {
        public Book(string name, string category, string pressName, 
                    int pagesCount, string author)
        {
            Name = name;
            Category = category;
            PressName = pressName;
            PagesCount = pagesCount;
            Author = author;
        }
        public Book() { }

        public override string ToString()
        {
            return $"Book name: {Name}\tCategory: {Category}\tPress name: {PressName}\tPages count: {PagesCount}\tAuthor: {Author}";
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string PressName { get; set; }
        public int PagesCount { get; set; }
        public string Author { get; set; }
    }
}
