using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment
{
    public class EmployeeCSV

    {
 

        public int id { get; set; }  // Make sure to align with the correct data if you have an Id
        public string ssn { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string gender { get; set; }
        public string street_name { get; set; }
        public string street_number { get; set; }
        public string zipcode { get; set; }
        public string city { get; set; }
        public string email { get; set; }
       
    }
}
