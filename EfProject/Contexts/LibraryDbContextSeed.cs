using EfProject.Helper;
using EfProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EfProject.Contexts
{
    internal class LibraryDbContextSeed
    {
        public static bool DataSeed(LibraryManagementSystemContext dbContext)
        {
            using var transaction = dbContext.Database.BeginTransaction();
            try
            {
                if (!dbContext.Authors.Any())
                {
                    var authors = Dataseed.Seed<Author>("Files\\Authors.json");
                    if (authors is null || authors.Count == 0) return false;
                    dbContext.Authors.AddRange(authors);
                }

                if (!dbContext.Categories.Any())
                {
                    var categories = Dataseed.Seed<Category>("Files\\Categories.json");
                    if (categories is null || categories.Count == 0) return false;
                    dbContext.Categories.AddRange(categories);
                }

                dbContext.SaveChanges();

                if (!dbContext.Books.Any())
                {
                    var books = Dataseed.Seed<Book>("Files\\Books.json");
                    if (books is null || books.Count == 0) return false;
                    dbContext.Books.AddRange(books);
                }

                if (!dbContext.Members.Any())
                {
                    var members = Dataseed.Seed<Member>("Files\\Members.json");
                    if (members is null || members.Count == 0) return false;
                    dbContext.Members.AddRange(members);
                }


                dbContext.SaveChanges();
                transaction.Commit();
                return true;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                transaction.Rollback();
                return false;


            }
        }
    }
}
