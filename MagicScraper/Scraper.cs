using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace MagicScraper
{
    public class Scraper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codeName"></param>
        /// <returns></returns>
        public List<Card> GetCards(string codeName)
        {
            List<Card> res = new List<Card>();
            string url = SetNamePrepareUrl(codeName);
            string href = "";
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = new HtmlDocument(); //
            doc = web.Load(url);
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//div[@class='card-grid-item']"))
            {
                Card newCard = new Card();
                var imageNode = node.Descendants().Where(x => x.Name == "img").ToList()[0];
                var attributes = imageNode.Attributes;
                string name = attributes.Where(x => x.Name == "title").FirstOrDefault()?.Value;
                string src = attributes.Where(x => x.Name == "src").FirstOrDefault()?.Value.Replace("normal","large");
                newCard.Name = name;
                newCard.Src = src;
                res.Add(newCard);
            }
            return res;
        }

        /// <summary>Returns web service specific url on the base of set name.</summary>
        /// <param name="setCode">Raw code of the set.</param>
        /// <returns></returns>
        public string SetNamePrepareUrl(string setCode)
        {
            string url = "https://scryfall.com/sets/";
            return url + setCode;
        }

    }
}
