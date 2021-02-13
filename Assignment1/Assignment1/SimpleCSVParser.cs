using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.VisualBasic.FileIO;

namespace Assignment1
{
    public class SimpleCSVParser
    {

        public List<CustomerData> Read(String fileName, out int BadData , out int TotRows)
        {
            List<CustomerData> Data = new List<CustomerData>();
            BadData = 0;
            TotRows = 0;
            if (!fileName.Contains(".csv"))
            {
                return Data;
            }
           
            
            
            try
            {


                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                    MissingFieldFound = null,
                    BadDataFound = null,
                   // Delimiter = ",",

                };
                using (StreamReader streamReader = new StreamReader(fileName))
                using (CsvReader csvReader = new CsvReader(streamReader, config))
                {
                    csvReader.Context.RegisterClassMap<CustomerDataMap>();
                    var customers = csvReader.GetRecords<CustomerData>();
                    
                    foreach (var cust in customers)
                    {
                        TotRows += 1;
                        // checking invalid data
                        if (string.IsNullOrEmpty(cust.FirstName) || string.IsNullOrEmpty(cust.LastName) || string.IsNullOrEmpty(cust.PhoneNumber)
                            || string.IsNullOrEmpty(cust.PostalCode) || string.IsNullOrEmpty(cust.Province) || string.IsNullOrEmpty(cust.Street)
                            || string.IsNullOrEmpty(cust.StreetNumber) || string.IsNullOrEmpty(cust.City) || string.IsNullOrEmpty(cust.Country)
                            || string.IsNullOrEmpty(cust.emailAddress) || (!cust.emailAddress.ToString().Contains("@")))
                        {
                            BadData += 1;
                        }
                        else
                        {
                            cust.Street= cust.Street.Replace(",", "|");
                            // checking valid data and adding in list
                            Data.Add(cust);

                        }

                    }

                }

            }

            catch (IOException ioe)
            {
                Console.WriteLine(ioe.StackTrace);
            }
            return Data;

        }


    }
}
