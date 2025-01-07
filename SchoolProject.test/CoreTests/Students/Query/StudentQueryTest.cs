using AutoMapper;
using EntityFrameworkCore.Testing.Common;
using FluentAssertions;
using Microsoft.Extensions.Localization;
using Moq;
using SchoolProject.Core.Features.Students.Queries.Handlers;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Core.Mapping.Students;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Helper;
using SchoolProject.Infrastructure.Resources;
using SchoolProject.Service.Abstracts;
using System.Net;

namespace SchoolProject.test.CoreTests.Students.Query
{
    public class StudentQueryTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IStudentService> _studentServiceMock;
        private readonly Mock<IStringLocalizer<SharedResources>> _localizerMock;

        public StudentQueryTest()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new StudentMapping());
            });
            _mapper = new Mapper(mapperConfiguration);

            _studentServiceMock = new();
            _localizerMock = new();
        }

        [Fact]
        public async void GetStudentList_Returns_AList_Of_All_Students()
        {
            var students = new List<Student>()
            {
                new Student()
                {
                    StudID=1,
                    Address="Alex",
                    DID=1,
                    NameAr="محمد",
                    NameEn="mohamed"
                }
            };
            _studentServiceMock.Setup(s => s.GetAllStudentsAsync()).ReturnsAsync(students);
            //Arrange
            var handler = new StudentQueryHandler(_studentServiceMock.Object, _mapper,
                _localizerMock.Object);

            //Act
            var result = await handler.Handle(new GetAllStudentsQuery(), default);
            //Assert

            result.Data.Should().HaveCount(1);
            result.Data.Should().BeOfType<List<GetStudentList>>();
        }

        [Theory]
        [InlineData(3)]
        public async Task GetStudentById_NotExist_Returns_NotFound(int id)
        {
            //Arrange
            var students = new List<Student>()
            {
                new Student()
                {
                    StudID=1,
                    Address="Alex",
                    DID=1,
                    NameAr="محمد",
                    NameEn="mohamed"
                },
                new Student()
                {
                    StudID=2,
                    Address="Alex",
                    DID=1,
                    NameAr="maمحمد",
                    NameEn="Malik"
                }
            };

            _studentServiceMock.Setup(s => s.GetStudentById(id)).ReturnsAsync(
                students.FirstOrDefault(s => s.StudID == id));

            //Act
            var handler = new StudentQueryHandler(_studentServiceMock.Object, _mapper, _localizerMock.Object);
            var result = await handler.Handle(new GetStudentByIdQuery(id), default);

            //Assert
            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task GetStudentById_Exists_Returns_Ok(int id)
        {
            //Arrange
            var students = new List<Student>()
            {
                new Student()
                {
                    StudID=1,
                    Address="Alex",
                    DID=1,
                    NameAr="محمد",
                    NameEn="mohamed"
                },
                new Student()
                {
                    StudID=2,
                    Address="Alex",
                    DID=1,
                    NameAr="محمد",
                    NameEn="mohamed"
                }
            };

            _studentServiceMock.Setup(s => s.GetStudentById(id)).ReturnsAsync(
                students.FirstOrDefault(s => s.StudID == id));

            //Act
            var handler = new StudentQueryHandler(_studentServiceMock.Object, _mapper, _localizerMock.Object);
            var result = await handler.Handle(new GetStudentByIdQuery(id), default);

            //Assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.StudID.Should().Be(id);
            result.Data.Should().BeOfType<GetStudentById>();
        }

        [Fact]
        public async Task GetStudentsPaginated_Returns_Ok_Students_list_count_3_PageSize_3_PageCount_2()
        {
            //Arrange
            var department = new Department() { DID = 1, DNameAr = "هندسة البرمجيات", DNameEn = "SE" };
            var asyncStudentsList = new AsyncEnumerable<Student>(new List<Student>()
            {
               new Student(){
                      StudID=1,
                      Address="Alex",
                      DID=1,
                      NameAr="محمد",
                      NameEn="mohamed",
                      Department=department},

               new Student(){
                      StudID=2,
                      Address="Alex",
                      DID=1,
                      NameAr="محمد",
                      NameEn="mohamed",
                      Department=department},

               new Student(){
                      StudID=3,
                      Address="Alex",
                      DID=1,
                      NameAr="محمد",
                      NameEn="mohamed",
                      Department=department},

            });

            var query = new GetStudentsPaginatedQuery()
            {
                PageNumber = 1,
                PageSize = 2,
                OrderBy = StudentOrderingEnum.StudID,
                Search = "mohamed"
            };


            _studentServiceMock.Setup(s => s.FilterStudents(query.Search, query.OrderBy))
                .Returns(asyncStudentsList);

            //Act
            var handler = new StudentQueryHandler(_studentServiceMock.Object,
                _mapper, _localizerMock.Object);

            var result = await handler.Handle(query, default);
            result.TotalCount.Should().Be(3);
            result.TotalPages.Should().Be(2);
            result.Data.Should().BeOfType<List<GetStudentsPaginated>>();
            result.Should().BeOfType<PaginatedResponse<GetStudentsPaginated>>();
            //Assert
        }
    }
}