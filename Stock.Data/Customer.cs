using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Data
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required.")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is required.")]
        [StringLength(50)]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Phone is required.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
        public double Debt { get; set; }
        public DateTime RecordDate { get; set; }

    }
}
