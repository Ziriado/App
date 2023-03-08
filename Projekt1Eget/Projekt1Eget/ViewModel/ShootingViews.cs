using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Projekt1Eget.ViewModel
{
    internal class ShootingViews
    {
        public static string AmountOfShootings(string url)
        {
            string result2;
            try
            {
                string htmlContent = ViewModel.CallMethods.GetWebClient(url);

                Regex startOfChains = new Regex("<h2 class=\"text-start mx-0 px-0\"><i class=\"\"></i> Karta över Stockholm:.+</h2>");

                MatchCollection matches = startOfChains.Matches(htmlContent);

                Regex secondChain = new Regex("<.*?>");
                string removeSomeText = secondChain.Replace(matches[0].ToString(), "");

                Regex thirdChain = new Regex("Karta över");
                string result = thirdChain.Replace(removeSomeText, "");

                Regex finalChain = new Regex("^\\s\\s");
                result2 = finalChain.Replace(result, "");
            }
            catch (Exception e)
            {
                result2 = ViewModel.CallMethods.CatchReturn();
            }
            return result2;
        }
        public static string DateOfLastShooting(string url)
        {
            string result;
            try
            {
                string htmlContent = ViewModel.CallMethods.GetWebClient(url);
                Regex infoStartofDateLastShooting = new Regex("<span class=\"badge rounded-0 mb.0 me-1 text-bg-primary text-break\">.*\\n.*\\n<\\/span>");
                MatchCollection matchesInfo1 = infoStartofDateLastShooting.Matches(htmlContent);
                Regex firstReplace = new Regex("<.*?>");
               string  result1 = firstReplace.Replace(matchesInfo1[0].ToString(), "");
                Regex secondReplace = new Regex("\\n");
                result = secondReplace.Replace(result1, "");
            }
            catch (Exception e)
            {
                result = ViewModel.CallMethods.CatchReturn(); ;
            }
            return result;
        }

        public static string LastShootingInfo(string url)
        {
            string result;

            try
            {
                string htmlContent = ViewModel.CallMethods.GetWebClient(url);
                Regex infoStartOfInfoLastShooting = new Regex("<p class=\"mt.1 mb-2 h6\">\\n.*\\n<\\/p>");
                MatchCollection matchesInfo1 = infoStartOfInfoLastShooting.Matches(htmlContent);
                Regex firstReplace = new Regex("<.*?>");
                string result1 = firstReplace.Replace(matchesInfo1[0].ToString(), "");
                Regex secondReplace = new Regex("\\n");
                result = secondReplace.Replace(result1, "");
            }
            catch(Exception e)
            {
                result = ViewModel.CallMethods.CatchReturn();
            }
            return result;
        }
    }
}
