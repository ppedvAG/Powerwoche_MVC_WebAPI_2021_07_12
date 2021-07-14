using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCOREMVC.CodeSnipptesSamples
{
    public class DictionarySample
    {
        public void SampleCode_Dictionary()
        {
            IDictionary<int, string> dict = new Dictionary<int, string>();

            dict.Add(1, "hallo");
            dict.Add(1, "hallo nochmal"); //Hier wird eine Exception entsehen, weil Key doppelt vorkommt


            if (!dict.ContainsKey(1)) //Es geht auch mit Key Prüfung
                dict.Add(1, "hallo nochmal");
        }

        public void SampleCode_BadHashTable()
        {
            Hashtable hashtable = new Hashtable();

            hashtable.Add(new DateTime(), "hallo String");
            hashtable.Add(123, 34566);
            hashtable.Add(new FileInfo("abc"), "hallo String");

        }
    }
}
