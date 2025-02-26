﻿using System.Collections;

namespace SchoolProject.test.CoreTests.DataModels
{
    public class StudentIdClassData : IEnumerable<object[]>
    {

        private readonly List<object[]> data = new List<object[]>()
        {
            new object[]{ 1},
            new object[]{ 2}
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
