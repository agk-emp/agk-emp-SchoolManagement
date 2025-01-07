using EntityFrameworkCore.Testing.Common;
using FluentAssertions;
using Moq;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.test.ServicesTest.Wrappers;

namespace SchoolProject.test.ServicesTest.Extensions
{
    public class ExtensionMethodTest
    {
        private readonly Mock<IQueryableWrapper<Student>> _queryWrapperMock;

        public ExtensionMethodTest()
        {
            _queryWrapperMock = new();
        }

        [Theory]
        [InlineData(1, 10)]
        public async Task ToPaginatedResult_Should_return_PaginatedResponse(int pageNumber, int pageSize)
        {
            //Arrange
            var department = new Department() { DID = 1, DNameAr = "هندسة البرمجيات", DNameEn = "SE" };

            var studentList = new AsyncEnumerable<Student>(new List<Student>
            {
                new Student(){ StudID=1, Address="Alex", DID=1, NameAr="محمد",NameEn="mohamed",Department=department},
            });

            var shouldReturn = new PaginatedResponse<Student>(true, studentList.ToList());
            _queryWrapperMock.Setup(q => q.GetPaginated(studentList, pageNumber, pageSize))
                .ReturnsAsync(shouldReturn);

            //Act
            var result = await _queryWrapperMock.Object.GetPaginated(studentList,
                pageNumber, pageSize);

            //Assert
            result.Should().NotBeNull();
        }
    }
}