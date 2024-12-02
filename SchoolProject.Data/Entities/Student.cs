using SchoolProject.Data.Common;

namespace SchoolProject.Data.Entities
{
    public class Student : GenericLocalizableEntity
    {
        public int StudID { get; set; }
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public int? DID { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<StudentSubject> StudentSubject { get; set; }
    }
}
