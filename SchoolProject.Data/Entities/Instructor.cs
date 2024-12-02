using SchoolProject.Data.Common;

namespace SchoolProject.Data.Entities
{
    public class Instructor : GenericLocalizableEntity
    {
        public int InsId { get; set; }
        public string? ENameAr { get; set; }
        public string? ENameEn { get; set; }
        public string? Address { get; set; }
        public string? Position { get; set; }
        public int? SupervisorId { get; set; }
        public decimal? Salary { get; set; }
        public string? Image { get; set; }
        public int DID { get; set; }
        public Department? department { get; set; }
        public Department? departmentManager { get; set; }
        public Instructor? Supervisor { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
        public virtual ICollection<Ins_Subject> Ins_Subjects { get; set; }
    }
}
