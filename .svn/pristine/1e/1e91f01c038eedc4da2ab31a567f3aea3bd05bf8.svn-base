using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Objects;
using System.Data.SqlClient;
using CST.Selector;

namespace SelectorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List();
        }

        public static void List()
        {
            using (SelectorEntities SelectorContext = new SelectorEntities())
            {
                var list = SelectorContext.PubCatalogs("4040");

                //ObjectQuery oq1 = (ObjectQuery)makes;
                //string str = oq1.ToTraceString();
                //Console.WriteLine(str);

                foreach (var x in list)
                {
                    Console.WriteLine(x.CatalogDescription);
                }

                Console.ReadLine();
            }
        }
    }
}
