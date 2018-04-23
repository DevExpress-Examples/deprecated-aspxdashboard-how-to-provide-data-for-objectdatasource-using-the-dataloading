using System;
using System.Collections.Generic;
using System.Threading;

namespace WebDesigner_DataLoading {
    public class SalesPersonData {
        public string SalesPerson { get; set; }
        public int Quantity { get; set; }

        public static List<SalesPersonData> CreateData() {
            List<SalesPersonData> data = new List<SalesPersonData>();
            string[] salesPersons = { "Andrew Fuller", "Michael Suyama", 
                                    "Robert King", "Nancy Davolio",
                                    "Margaret Peacock", "Laura Callahan", 
                                    "Steven Buchanan", "Janet Leverling" };

            for (int i = 0; i < 100; i++) {
                SalesPersonData record = new SalesPersonData();
                int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;
                record.SalesPerson = salesPersons[new Random(seed).Next(0, salesPersons.Length)];
                record.Quantity = new Random(seed).Next(0, 100);
                data.Add(record);
                Thread.Sleep(3);
            }
            return data;
        }
    }
}