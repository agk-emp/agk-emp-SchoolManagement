using SchoolProject.Data.Common;

namespace SchoolProject.Data.Entities.Procedures
{
    public class GETStudentsCountForDepartmentProcedure : GenericLocalizableEntity
    {
        public int DID { get; set; }
        public string DNameEn { get; set; }
        public string DNameAr { get; set; }
        public int StudentsCount { get; set; }
    }
}
