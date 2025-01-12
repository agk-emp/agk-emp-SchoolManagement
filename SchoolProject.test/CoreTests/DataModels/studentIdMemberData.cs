using System.Collections;

namespace SchoolProject.test.CoreTests.DataModels
{
    public class studentIdMemberData : IEnumerable<object[]>
    {
        public static List<object[]> GetStudentIds()
        {
            return new List<object[]>
            {
                new object[]{1},
            new object[]{2},
            };
        }
        public IEnumerator<object[]> GetEnumerator()
        {
            return GetStudentIds().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
