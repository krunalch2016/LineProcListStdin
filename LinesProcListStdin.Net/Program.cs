using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/* Don't change anything here.
 * Do not add any other imports. You need to write
 * this program using only these libraries 
 */

namespace LineProcListStdin
{
    /* You may add helper classes here if necessary */
    public class helper
    {
        public string productName { get; set; }
        public string libraryName { get; set; }
        public int libraryVersion { get; set; }

    }

    public class Program
    {
        public static List<String> processData(
                                        IEnumerable<string> lines)
        {
            /* 
             * Do not make any changes outside this method.
             *
             * Modify this method to process `array` as indicated
             * in the question. At the end, return a List containing
             * the appropriate values
             *
             * Do not print anything in this method
             *
             * Submit this entire program (not just this function)
             * as your answer
             */
            var listHelper = new List<helper>();
            int i;
            foreach (string str in lines)
            {
                var strPara = str.Split(',');
                if (strPara.Length == 3) // it will only process those record which is having complete set of values
                {
                    var hp = new helper();
                    hp.productName = strPara[0].Trim();
                    hp.libraryName = strPara[1].Trim();
                    hp.libraryVersion = int.TryParse(strPara[2].Trim().Substring(1), out i) ? i : 0; //assume that all version numbers are of the form v<digits> where <digits> represents one or more decimal digits
                    listHelper.Add(hp);
                }
            }
            //List out the latest version for each library
            var latestVersionLibrary = listHelper.GroupBy(q => q.libraryName, q => q.libraryVersion, (x, y) => new { x, y = y.Max() }).Select(r => new { r.x, r.y });

            List<String> retVal = new List<String>();
            foreach (var a in latestVersionLibrary)
            {
                var result = listHelper.Where(x => x.libraryName == a.x && x.libraryVersion == a.y).Select(x => x.productName).Distinct();
                retVal.AddRange(result.Except(retVal));
            }

            return retVal;
        }

        static void Main(string[] args)
        {
            try
            {
                //String line;
                //var inputLines = new List<String>();
                //while ((line = Console.ReadLine()) != null)
                //{
                //    line = line.Trim();
                //    if (line != "")
                //        inputLines.Add(line);
                //}
                //var retVal = processData(inputLines);
                //foreach (var res in retVal)
                //    Console.WriteLine(res);

                String s1 = "42", s2 = "43";
                f1(ref s1, s2);
                Console.WriteLine(s1 + s2);

            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void f1(ref String s1, String s2)
        {
            s1 += "0";
            s2 += "0";
        }

        class S
        {
            public int I;
        }
    }
}