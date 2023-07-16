using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;


namespace EF_HW_1.Models
{
    class MyDbContext : DbContext
    {
        public MyDbContext() : base("LibraryDb") { }

        public DbSet<Book> Books { get; set; }


        public void AddBook(string name, string category, string pressName,
                            int pagesCount, string author)
        {
            Books.Add(new Book(name, category, pressName, pagesCount, author));
            SaveChanges();
        }

        public List<Book> SearchByAuthor(string authorName)
        {
            var res = from b in Books
                      where b.Author.ToLower() == authorName.ToLower()
                      select b;
            return res.ToList();
        }

        public List<Book> SearchByBookName(string bookName)
        {
            var res = from b in Books
                      where b.Name.ToLower() == bookName.ToLower()
                      select b;
            return res.ToList();
        }

        public List<Book> SearchByCategory(string category)
        {
            var res = from b in Books
                      where b.Category.ToLower() == category.ToLower()
                      select b;
            return res.ToList();
        }

        public List<Book> SearchByPressName(string pressName)
        {
            var res = from b in Books
                      where b.PressName.ToLower() == pressName.ToLower()
                      select b;
            return res.ToList();
        }
    }
}
