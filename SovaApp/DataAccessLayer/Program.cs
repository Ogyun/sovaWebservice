using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;

namespace DataAccessLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new SovaDbContext();

            var searchService = new SearchService();
            var result = searchService.SearchByKeyword("c#", "constructors");
            foreach (var item in result)
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine("");
            }
                 
        }
    }
}
