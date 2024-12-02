namespace SchoolProject.Data.Entities
{
    public class Ins_Subject
    {
        public Ins_Subject()
        {

        }
        public int InsId { get; set; }
        public int SubId { get; set; }
        public Instructor? instructor { get; set; }
        public Subjects? Subject { get; set; }
    }
}
