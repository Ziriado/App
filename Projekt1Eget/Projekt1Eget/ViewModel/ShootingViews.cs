
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
        public static async Task<string> AmountOfShootings(string htmlContent)
        {
            string result2;
            try
            {
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
        public static async Task<string> DateOfLastShooting(string htmlContent)
        {
            string result;
            try
            {
                Regex infoStartofDateLastShooting = new Regex("<span class=\"badge rounded-0 mb.0 me-1 text-bg-primary text-break\">.*\\n.*\\n<\\/span>");
                MatchCollection matchesInfo1 = infoStartofDateLastShooting.Matches(htmlContent);
                Regex firstReplace = new Regex("<.*?>");
                string result1 = firstReplace.Replace(matchesInfo1[0].ToString(), "");
                Regex secondReplace = new Regex("\\n");
                result = secondReplace.Replace(result1, "");
            }
            catch (Exception e)
            {
                result = ViewModel.CallMethods.CatchReturn(); ;
            }
            return result;
        }

        public static async Task<string> LastShootingInfo(string htmlContent)
        {
            string result;

            try
            {
                Regex infoStartOfInfoLastShooting = new Regex("<p class=\"mt.1 mb-2 h6\">\\n.*\\n<\\/p>");
                MatchCollection matchesInfo1 = infoStartOfInfoLastShooting.Matches(htmlContent);
                Regex firstReplace = new Regex("<.*?>");
                string result1 = firstReplace.Replace(matchesInfo1[0].ToString(), "");
                Regex secondReplace = new Regex("\\n");
                result = secondReplace.Replace(result1, "");
            }
            catch (Exception e)
            {
                result = ViewModel.CallMethods.CatchReturn();
            }
            return result;
        }
    }
}
