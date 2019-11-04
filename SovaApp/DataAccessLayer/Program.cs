using System;

namespace DataAccessLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SovaDbContext();

            var connectionTest = context.Database.CanConnect();
            Console.WriteLine("Connected: " + connectionTest);
        }
    }
}
