using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbexample2
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a band name to filter by:");
            string bandFilter = Console.ReadLine();
            // var bands = new BandService().GetBands("ed");
            // var bands = new BandService().GetBands("ed");
            var bands = new BandService().GetBandsWithDataTable("ed");
        }
    }
}
