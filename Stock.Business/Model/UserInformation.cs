using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Business.Model
{
    public class UserInformation
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int AuthorityId { get; set; }
        public int PersonalId { get; set; }
        public string AuthorityName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
        public string Image { get; set; }
        public DateTime EntryDate { get; set; }

    }
}
