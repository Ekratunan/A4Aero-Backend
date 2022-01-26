namespace A4Aero.Models
{
    public class BusinessEntities
    {
        public int BusinessId { get; set; }
        public string? Code { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
        public string? Country { get; set; }
        public string? Mobile { get; set; }
        public string? Phone { get; set; }
        public string? ContactPerson { get; set; }
        public string? ReferredBy { get; set; }
        public string? Logo { get; set; }
        public int Status { get; set; }
        public double Balance { get; set; }
        public string? SMTPServer { get; set; }
        public int SMTPPort { get; set; }
        public string? SMTPUsername { get; set; }
        public string? SMTPPassword { get; set; }
        public bool Deleted { get; set; }
        public DateTime CtreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
    }
}
