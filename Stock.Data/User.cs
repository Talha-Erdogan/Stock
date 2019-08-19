using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Data
{
    [Table("User")]
   public class User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage ="User Name is required.")]
        public string UserName { get; set; }
        public string Password { get; set; }
        public int AuthorityId { get; set; }
        public int PersonalId { get; set; }
    }
}
