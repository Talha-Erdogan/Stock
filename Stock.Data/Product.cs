using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Data
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int BrandId { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50)]
        public string Name { get; set; }
        public int Piece { get; set; }
        public double BuyingPrice { get; set; }
        public double Kdv { get; set; }
        public double SalesPrice { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
