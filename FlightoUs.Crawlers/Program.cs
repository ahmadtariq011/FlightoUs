using FlightoUs.Bll;
using FlightoUs.Model.Data;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace FlightoUs.Crawlers
{
    class Program
    {
        public static void Main(string[] args)
        {

            List<AirpotCodes> airportCodes = new List<AirpotCodes>();
            string url = "http://www.flugzeuginfo.net/table_airportcodes_country-location_en.php";
            string html = "";
            BllAirportCodes bllAirportCodes = new BllAirportCodes();

            using (WebClient webClient = new WebClient())
            {
                webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36");
                webClient.Headers.Add(HttpRequestHeader.Accept, "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3");
                webClient.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-GB,en-US;q=0.9,en;q=0.8");
                byte[] dataBuffer = webClient.DownloadData(url);
                html = Encoding.UTF8.GetString(dataBuffer);
            }

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var tablebody = htmlDocument.QuerySelectorAll("table");
            foreach (var body in tablebody)
            {
                var AllTr = body.QuerySelectorAll("tr");
                foreach (var tr in AllTr.Skip(1))
                {
                    AirpotCodes airportCode = new AirpotCodes();
                    airportCode.IATA = tr.QuerySelector("td:nth-child(1)").InnerText;
                    airportCode.ICAO = tr.QuerySelector("td:nth-child(2)").InnerText;
                    airportCode.Location = tr.QuerySelector("td:nth-child(3)").InnerText;
                    airportCode.Airport = tr.QuerySelector("td:nth-child(4)").InnerText;
                    airportCode.Country = tr.QuerySelector("td:nth-child(5)").InnerText;
                    bllAirportCodes.Insert(airportCode);
                    airportCodes.Add(airportCode);
                }
            }


            var i = 0;
        }
    }
}
