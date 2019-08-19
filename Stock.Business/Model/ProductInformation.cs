using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Business.Model
{
    public class ProductInformation
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string Name { get; set; }
        public int Piece { get; set; }
        public double BuyingPrice { get; set; }
        public double Kdv { get; set; }
        public double SalesPrice { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
