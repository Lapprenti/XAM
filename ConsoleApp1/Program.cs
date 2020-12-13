using Business.services;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ErgastAPI ergastAPI = new ErgastAPI();
            await ergastAPI.FindSeasonsAsync();
            await ergastAPI.FindDriversForSeasonAsync(2020);
            Console.ReadKey();
        }
    }
}
