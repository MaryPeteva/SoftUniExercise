namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualBasic;
    using System.Text;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //Console.WriteLine(GetBooksNotReleasedIn(db,year));
            DbInitializer.ResetDatabase(db);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command) 
        {
            StringBuilder result = new StringBuilder();
            bool age =  Enum.TryParse<AgeRestriction>(command.ToLower(), true, out AgeRestriction selectedAge);
            var books = context.Books
                    .Where(b => b.AgeRestriction == selectedAge)
                    .OrderBy(b => b.Title)
                    .Select(b => b.Title);


            foreach (var book in books) 
            {
                result.AppendLine(book);
            }


            return result.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context) 
        {
            StringBuilder result = new StringBuilder();
            var books = context.Books.Where(b => b.EditionType == EditionType.Gold)
                .Where(b => b.Copies < 5000)
                .OrderBy(b => b.BookId);

            foreach (var book in books) 
            {
                result.AppendLine(book.Title);
            }
            return result.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context) 
        {
            StringBuilder result = new StringBuilder();

            var books = context.Books
                                                  .Where(b=>b.Price > 40)
                                                  .OrderByDescending(b => b.Price);

            foreach (var book in books) 
            {
                result.AppendLine($"{book.Title} - ${book.Price:f2}");
            }
            return result.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year) 
        {
            StringBuilder result = new StringBuilder();

            var books = context.Books.Where(b => b.ReleaseDate.Value.Year != year)
                                       .OrderBy(b=>b.BookId);

            foreach (var book in books) 
            {
                result.AppendLine(book.Title);
            }
            return result.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input) 
        {
            StringBuilder result = new StringBuilder();
            var selectedCategories = input.ToLower()
                                                  .Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            var books = context.Books
                .Where(book => book.BookCategories.Any(category => selectedCategories.Contains(category.Category.Name.ToLower())))
                .OrderBy(book => book.Title)
                .Select(book => book.Title);

            foreach (var book in books) 
            {
                result.AppendLine(book);
            }
            return result.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date) 
        {
            StringBuilder result = new StringBuilder();
            string dateFormat = "dd-MM-yyyy";
            DateTime dateP = DateTime.ParseExact(date, dateFormat, null);
            var books = context.Books.Where(b => b.ReleaseDate < dateP)
                                                        .OrderByDescending(b=>b.ReleaseDate)
                                                        .Select(b => new
                                                        {
                                                            Title = b.Title,
                                                            Price = b.Price,
                                                            Edition = b.EditionType
                                                        });
            foreach (var book in books) 
            {
                result.AppendLine($"{book.Title} - {book.Edition} - ${book.Price:f2}");
            }
            return result.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input) 
        {
            StringBuilder result = new StringBuilder();

            var autors = context.Authors.Where(a => a.FirstName.EndsWith(input))
                .Select(a => new { FullName = $"{a.FirstName} {a.LastName}" })
                .OrderBy(a=>a.FullName);

            foreach (var autor in autors) 
            {
                result.AppendLine(autor.FullName);
            }
            return result.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input) 
        {
            StringBuilder result = new StringBuilder();
            var books = context.Books
                                            .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                                            .Select(b=>b.Title)
                                            .OrderBy(b=>b);
            foreach (var book in books) 
            {
                result.AppendLine(book);
            }
            return result.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input) 
        {
            StringBuilder result = new StringBuilder();
            var books = context.Books.Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(b => new { Id = b.BookId, Title = b.Title, Autor = $"{b.Author.FirstName} {b.Author.LastName}" })
                .OrderBy(b => b.Id);
            foreach (var book in books) 
            {
                result.AppendLine($"{book.Title} ({book.Autor})");
            }
            return result.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck) 
        {
            var books = context.Books.Where(b => b.Title.Length > lengthCheck).Count();
            return books;
        }

        public static string CountCopiesByAuthor(BookShopContext context) 
        {
            StringBuilder result = new StringBuilder();
            var autors = context.Authors.Select(author => new
                                        {
                                            AuthorName = $"{author.FirstName} {author.LastName}",
                                            TotalCopies = author.Books.Sum(book => book.Copies)
                                        })
                                .OrderByDescending(author => author.TotalCopies);
            foreach (var autor in autors) 
            {
                result.AppendLine($"{autor.AuthorName} - {autor.TotalCopies}");
            }
            return result.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context) 
        {
            StringBuilder result = new StringBuilder();
            var categories = context.Categories
                               .Select(c => new
                               {
                                   CategoryId = c.CategoryId,
                                   Name = c.Name,
                                   Profit = c.CategoryBooks
                                   .Select(bc => bc.Book)
                                   .Sum(b => b.Copies * b.Price)
                               })
                               .OrderByDescending(r => r.Profit)
                               .ThenBy(result => result.Name);
            foreach (var category in categories) 
            {
                result.AppendLine($"{category.Name} ${category.Profit:f2}");
            }
            return result.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context) 
        {
            StringBuilder result = new StringBuilder();
            var categories = context.Categories
                               .Select(c => new
                               {
                                   Name = c.Name,
                                   Books = c.CategoryBooks
                                   .Select(bc => bc.Book)
                                   .OrderByDescending(b => b.ReleaseDate)
                                   .Take(3)
                               })
                               .OrderBy(c=>c.Name);

            foreach (var category in categories) 
            {
                result.AppendLine($"--{category.Name}");
                foreach (var book in category.Books) 
                {
                    result.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }
            return result.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context) 
        {
            var books = context.Books.Where(b => b.ReleaseDate.Value.Year < 2010);
            foreach (var book in books) 
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context) 
        {
            context.ChangeTracker.Clear();

            var books = context.Books
                .Where(b => b.Copies < 4200);

            context.RemoveRange(books);

            return context.SaveChanges();
        }
    }
}


