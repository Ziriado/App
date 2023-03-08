﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Projekt1Eget.ViewModel
{
    class CovidView
    {
        public static string AmountOfCovidWorldWide()
        {
            string finaloutput;
            try
            {
                string url = "https://www.worldometers.info/coronavirus/";
                string htmlContent = new System.Net.WebClient().DownloadString(url);
                Regex startOfChains = new Regex("        <span style=\"color:#aaa\">.*        <\\/span>");
                
                MatchCollection matches = startOfChains.Matches(htmlContent);
                Regex firstReplace = new Regex("<.*?>");
                string removeBadOutput1 = firstReplace.Replace(matches[0].ToString(), "");
                 finaloutput = removeBadOutput1.Trim();
            }
            catch(Exception e) 
            {
                finaloutput = "null";
            }
            return finaloutput;
        }
    }
}