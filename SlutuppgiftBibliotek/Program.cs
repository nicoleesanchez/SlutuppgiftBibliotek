using SlutuppgiftBibliotek.Data;
using Helpers;
using SlutuppgiftBibliotek.Models;

namespace SlutuppgiftBibliotek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataAccess dataAccess = new DataAccess();
            dataAccess.Seed();
        }
    }
}