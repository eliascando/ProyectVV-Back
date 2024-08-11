namespace Domain.DTOs
{
    public class CalificacionDTO
    {
        public long Id { get; set; }
        public long MatriculaId { get; set; }
        public decimal Grade { get; set; }
        public long GradeType { get; set; }
        public string GradeTypeName { get; set; }
        public long GradePeriodId { get; set; }
        public string GradePeriodName {  get; set; }
    }
}
