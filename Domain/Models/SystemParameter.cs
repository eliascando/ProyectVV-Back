namespace Domain.Models
{
    public class SystemParameter
    {
        public long Id {  get; set; }
        public string Description {  get; set; }
        public DateTime CreationTime {  get; set; }
        public List<SystemParameterDetails> Details { get; set; }
    }
}
