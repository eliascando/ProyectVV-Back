﻿namespace Domain.DTOs
{
    public class NewUserDTO
    {
        public long Id { get; set; }
        public string NumberIdentification { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public long RoleId { get; set; }
        public string RoleName {  get; set; }
        public string ? StatusMatricula { get; set; }
        public long? MatriculaId { get; set; }
    }
}
