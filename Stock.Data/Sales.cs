using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Data
{
    [Table("Sales")]
    public class Sales
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product is required.")]
        public int ProductId { get; set; }
        public int Piece { get; set; }
        public DateTime SalesDate { get; set; }

        [Required(ErrorMessage = "Customer is required.")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Personal is required.")]
        public int PersonalId { get; set; }
        public double Discount { get; set; }

    }
}
