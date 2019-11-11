﻿using Microsoft.EntityFrameworkCore;
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
            var result = searchService.DeleteSearchHistory("i@mail.com");
            Console.WriteLine(result);
                 
        }
    }
}
