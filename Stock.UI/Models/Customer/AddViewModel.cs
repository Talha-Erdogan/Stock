using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock.UI.Models.Customer
{
    public class AddViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public double Debt { get; set; }
        public DateTime RecordDate { get; set; }
    }
}