namespace HealthcareRecordsAPI.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int CabinetId { get; set; }
        public int SpecializationId { get; set; }
        public int SectionId { get; set; }
        public Cabinet Cabinet { get; set; }
        public Specialization Specialization { get; set; }
        public Section Section { get; set; }
    }
}
