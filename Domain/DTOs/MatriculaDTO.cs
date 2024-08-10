namespace Domain.DTOs
{
    public class MatriculaDTO
    {
        public long Id { get; set; }
        public string CourseDescription { get; set; }
        public string Cycle {  get; set; }
        public string UserName { get; set; }
        public string TypeName { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
