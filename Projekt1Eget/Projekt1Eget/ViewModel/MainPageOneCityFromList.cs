using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1Eget.ViewModel
{
    class MainPageOneCityFromList
    {
        private List<string>citys = new List<string>();

        private static readonly MainPageOneCityFromList _instance= new MainPageOneCityFromList();

        private int nextCity = 0;

        private MainPageOneCityFromList() {
            citys.Add("Nyköping");
            citys.Add("Eskilstuna");
            citys.Add("Trosa");
            citys.Add("Luleå");
            citys.Add("Oslo");
        }

        public static MainPageOneCityFromList GetCity()
        {
            return _instance;
        }

        public string GetNextCity()
        {
            string output = citys[nextCity];
            nextCity++;
            if (nextCity >= citys.Count)
            {
                nextCity = 0;
            }
            return output;
        }
    }
}
