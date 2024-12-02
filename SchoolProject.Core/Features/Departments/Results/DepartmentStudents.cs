namespace SchoolProject.Core.Features.Departments.Results
{
    public class DepartmentStudents
    {
        public DepartmentStudents(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
