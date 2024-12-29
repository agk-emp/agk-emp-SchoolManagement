using SchoolProject.Data.Common;

namespace SchoolProject.Data.Entities.TabledFunctions
{
    public class GetInstructorsDetailsFunction : GenericLocalizableEntity
    {
        public int InsId { get; set; }
        public string ENameAr { get; set; }
        public string ENameEn { get; set; }
    }
}