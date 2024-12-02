using SchoolProject.Data.Common;

namespace SchoolProject.Data.Entities
{
    public class Department : GenericLocalizableEntity
    {
        public Department()
        {
            Students = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmetSubject>();
            Instructors = new HashSet<Instructor>();
        }
        public int DID { get; set; }
        public string? DNameEn { get; set; }
        public string? DNameAr { get; set; }
        public int? InsManager { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<DepartmetSubject> DepartmentSubjects { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
        public virtual Instructor? Instructor { get; set; }

    }
}
