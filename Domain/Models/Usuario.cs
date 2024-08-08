using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Usuario
    {
        public long Id { get; set; }
        public string NumberIdentification { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone {  get; set; }
        public string Adress {  get; set; }
        public long RoleId { get; set; }
        public bool Status { get; set; }
    }
}
