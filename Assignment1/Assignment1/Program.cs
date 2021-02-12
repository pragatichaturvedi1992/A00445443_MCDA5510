using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Assignment1
{
    public class DirWalker
    {

        public static List<CustomerData> validData = new List<CustomerData>();
        public static int goodRows = 0;
        public static int badRows = 0;
        public static int totalRow = 0;

        public void walk(String path)
        {

            string[] list = Directory.GetDirectories(path);


            if (list == null) return;

            foreach (string dirpath in list)
            // foreach (String f : list)
            {
                if (Directory.Exists(dirpath))
                {
                    walk(dirpath);
                    // Console.WriteLine("Dir:" + dirpath);
                }
            }
            string[] fileList = Directory.GetFiles(path);
            foreach (string filepath in fileList)
            {
                int BadData=0;
                int Total = 0;
                //Console.WriteLine("File:" + filepath);
                SimpleCSVParser par = new SimpleCSVParser();
                validData.AddRange(par.Read(filepath,out BadData, out Total));
                badRows = badRows + BadData;
                totalRow = totalRow + Total;

            }
        }

        public static void Main(String[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            DirWalker fw = new DirWalker();
            fw.walk(@"C:\Users\DELL\Desktop\MCDA5510_PROJECT\A00445443_MCDA5510\Assignment1\Assignment1\zip sample\Sample Data");

            //logging output
            StreamWriter streamwriter = new StreamWriter(@"C:\Users\DELL\Desktop\MCDA5510_PROJECT\A00445443_MCDA5510\Assignment1\Assignment1\output.csv");
            streamwriter.WriteLine("FirstName , LastName , StreetNumber , Street , City ,  Province , PostalCode , Country , PhoneNumber ,emailAddress");

            foreach (var cust in validData)
            {

                streamwriter.WriteLine(cust.FirstName + ", " + cust.LastName + ", " + cust.StreetNumber + ", " + cust.Street + ", " +
                            cust.City + ", " + cust.Province + ", " + cust.PostalCode + ", " + cust.Country + ", " + cust.PhoneNumber +
                            ", " + cust.emailAddress);

                goodRows += 1;
            }
            streamwriter.Close();

            // logging log information
            StreamWriter log = new StreamWriter(@"C:\Users\DELL\Desktop\MCDA5510_PROJECT\A00445443_MCDA5510\Assignment1\Assignment1\log.txt");
            log.WriteLine("TotalRows:  " + totalRow);
            log.WriteLine("badRows:  " + badRows);
            log.WriteLine("goodRows:  " + goodRows);
            watch.Stop();
            log.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            log.Close();
        }

    }
}
