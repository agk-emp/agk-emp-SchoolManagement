namespace SchoolProject.Data.Common
{
    public class StudentLocalizableEntity
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }

        public string GetLocalizedName()
        {
            var culture = Thread.CurrentThread.CurrentCulture;

            if (culture.TwoLetterISOLanguageName.ToLower() == "ar")
            {
                return NameAr;
            }
            return NameEn;
        }
    }
}
