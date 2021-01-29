using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace TestAPI.Models
{
    class GetStats
    {
        public static List<Hotspot> getStatForProvince(string province)

        {
            string curProvince = "";
            bool isProvince = true;
            List<Hotspot> hsList = new List<Hotspot>();
            //Convert Province Code To Work With Scraper
            if (province == "KZN")
            {
                curProvince = "collapseKZN";


            }
            else if (province == "WC")
            {

                curProvince = "collapseWesternCape";

            }
            else if (province == "GP")
            {

                curProvince = "collapseLatest18";

            }
            else if (province == "NC")
            {

                curProvince = "collapseLatest19";

            }
            else if (province == "LP")
            {

                curProvince = "collapseLatest22";

            }
            else if (province == "MP")
            {

                curProvince = "collapseMpumalanga";

            }

            else if (province == "NW")
            {

                curProvince = "collapseLatest20";

            }
            else if (province == "FS")
            {

                curProvince = "collapseLatest21";

            }
            else
            {
                isProvince = false;
            }
            //Checks if Province Exists
            if (isProvince)
            {   
                //Loads Discovery Website
                var url = "https://www.discovery.co.za/corporate/covid19-stay-informed-stay-healthy";
                var webGet = new HtmlWeb();

                
                if (webGet.Load(url) is HtmlDocument document)
                {
                    //Loops through table and scraps relevent data
                    
                    for (int i = 2; document.DocumentNode.SelectSingleNode("//*[@id='" + curProvince + "']/div/table/tbody/tr[" + i + "]/td[1]/p") != null; i++)
                    {
                        Hotspot hs = new Hotspot();

                        var district = document.DocumentNode.SelectSingleNode("//*[@id='" + curProvince + "']/div/table/tbody/tr[" + i + "]/td[1]/p").InnerText;
                        var cases = document.DocumentNode.SelectSingleNode("//*[@id='" + curProvince + "']/div/table/tbody/tr[" + i + "]/td[2]/p").InnerText;
                        var growth = document.DocumentNode.SelectSingleNode("//*[@id='" + curProvince + "']/div/table/tbody/tr[" + i + "]/td[3]/p").InnerText;
                        var avg = document.DocumentNode.SelectSingleNode("//*[@id='" + curProvince + "']/div/table/tbody/tr[" + i + "]/td[4]/p").InnerText;

                        hs.Province = province;
                        hs.District = district;
                        hs.casesPer100k = Convert.ToInt32(cases);
                        hs.id = i-1;

                        hs.avgNewCases = Convert.ToDouble(avg, new CultureInfo("en-US")); ;
                        hs.growthRate = Convert.ToDouble(growth.Substring(0, growth.Length - 1), new CultureInfo("en-US"));
                        hsList.Add(hs);
                    }


                }

              
            }

            return (hsList);
        }


        public static List<Hotspot> getAllStats()

        {
           
            string curProvince = "";
            bool isProvince = true;

            string[] Provinces = new string[8];
            List<Hotspot> hsList = new List<Hotspot>();


            Provinces[0] = "collapseKZN";




            Provinces[1] = "collapseWesternCape";




            Provinces[2] = "collapseLatest18";



            Provinces[3] = "collapseLatest22";



            Provinces[4] = "collapseMpumalanga";



            Provinces[5] = "collapseLatest20";


            Provinces[6] = "collapseLatest21";

            Provinces[7] = "collapseLatest19";






            if (isProvince)
            {
                var url = "https://www.discovery.co.za/corporate/covid19-stay-informed-stay-healthy";
                var webGet = new HtmlWeb();


                if (webGet.Load(url) is HtmlDocument document)
                {

                    for (int g = 0; g < Provinces.Length; g++)
                    {

                        curProvince = Provinces[g];
                        string provinceNow = "";

                        if (curProvince == "collapseKZN")
                        {
                            provinceNow = "KZN";


                        }
                        else if (curProvince == "collapseWesternCape")
                        {

                            provinceNow = "WC";

                        }
                        else if (curProvince == "collapseLatest18")
                        {

                            provinceNow = "GP";

                        }
                        else if (curProvince == "collapseLatest19")
                        {

                            provinceNow = "NC";

                        }
                        else if (curProvince == "collapseLatest22")
                        {

                            provinceNow = "LP";

                        }
                        else if (curProvince == "collapseMpumalanga")
                        {

                            provinceNow = "MP";

                        }

                        else if (curProvince == "collapseLatest20")
                        {

                            provinceNow = "NW";

                        }
                        else if (curProvince == "collapseLatest21")
                        {

                            provinceNow = "FS";

                        }

                        //Loops through table and scraps relevent data

                        for (int i = 2; document.DocumentNode.SelectSingleNode("//*[@id='" + curProvince + "']/div/table/tbody/tr[" + i + "]/td[1]/p") != null; i++)
                        {
                            Hotspot hs = new Hotspot();

                            var district = document.DocumentNode.SelectSingleNode("//*[@id='" + curProvince + "']/div/table/tbody/tr[" + i + "]/td[1]/p").InnerText;
                            var cases = document.DocumentNode.SelectSingleNode("//*[@id='" + curProvince + "']/div/table/tbody/tr[" + i + "]/td[2]/p").InnerText;
                            var growth = document.DocumentNode.SelectSingleNode("//*[@id='" + curProvince + "']/div/table/tbody/tr[" + i + "]/td[3]/p").InnerText;
                            var avg = document.DocumentNode.SelectSingleNode("//*[@id='" + curProvince + "']/div/table/tbody/tr[" + i + "]/td[4]/p").InnerText;

                            hs.Province = provinceNow;
                            hs.District = district;
                            hs.casesPer100k = Convert.ToInt32(cases);
                            hs.id = hsList.Count + 1;

                            hs.avgNewCases = Convert.ToDouble(avg, new CultureInfo("en-US"));
                            hs.growthRate = Convert.ToDouble(growth.Substring(0, growth.Length - 1), new CultureInfo("en-US"));
                            hsList.Add(hs);
                        }






                    }

                }
            }

            return hsList;
        }
    }
}