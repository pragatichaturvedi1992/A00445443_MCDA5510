﻿using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Assignment1
{
    public class CustomerData
    {
#nullable enable
      
        public string? FirstName { get; set; }
        
        public string? LastName { get; set; }
     
        public string? StreetNumber { get; set; }
     
        public string? Street { get; set; }
       
        public string? City { get; set; }
       
        public string? Province { get; set; }
        
        public string? PostalCode { get; set; }
        
        public string? Country { get; set; }
        public string? PhoneNumber { get; set; }
        public string? emailAddress { get; set; }
    }

    //Class Map| mapping by Names
    public sealed class CustomerDataMap : ClassMap<CustomerData>
    {
        public CustomerDataMap()
        {
            Map(m => m.FirstName).Name("First Name");
            Map(m => m.LastName).Name("Last Name");
            Map(m => m.StreetNumber).Name("Street Number");
            Map(m => m.Street).Name("Street");
            Map(m => m.City).Name("City");
            Map(m => m.Province).Name("Province");
            Map(m => m.PostalCode).Name("Postal Code");
            Map(m => m.Country).Name("Country");
            Map(m => m.PhoneNumber).Name("Phone Number");
            Map(m => m.emailAddress).Name("email Address");
        }
    }
}
