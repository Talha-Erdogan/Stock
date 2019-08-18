using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Data
{
    [Table("Brand")]
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
