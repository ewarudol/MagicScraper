using System;

namespace MagicScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            Scraper scraper = new Scraper();
            var list = scraper.GetCards("eld");
            foreach(Card card in list)
            {
                Console.WriteLine($"{card.Name} | {card.Src}");

            }
        }
    }
}
