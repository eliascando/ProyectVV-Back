using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class LoginResultDTO
    {
        public long Id { get; set; }
        public string NumberIdentification { get; set; }
        public string CompleteName { get; set; }
        public string Email {  get; set; }
        public long RoleId { get; set; }
        public string RoleName { get; set; }
        public string Token {  get; set; }
    }
}
