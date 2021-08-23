using System;

namespace ConsoleApp4
{
    /// <summary>
    /// Change of stock price should cascade notification to each investor.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IBM client = new IBM(99);
            client.AddInvestor(new Investor(client, "JP Morgans"));
            client.AddInvestor(new Investor(client, "Well's Fargo"));

            client.Price = 98;
            client.Price = 97;
            client.Price = 1000;
            client.Price = 99;

            Console.ReadKey();
        }
    }
}
