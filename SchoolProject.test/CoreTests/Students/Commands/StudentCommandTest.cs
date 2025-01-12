using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Localization;
using Moq;
using SchoolProject.Core.Features.Students.Commands.Handlers;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Mapping.Students;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.test.CoreTests.Students.Commands
{
    public class StudentCommandTest
    {
        private readonly Mock<IStudentService> _studentServiceMock;
        private readonly IMapper _mapper;
        private readonly Mock<IStringLocalizer<SharedResources>> _localizerMock;

        public StudentCommandTest()
        {
            _studentServiceMock = new();
            _localizerMock = new();
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new StudentMapping());
            });
            _mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async Task Student_Create_Success_Return_200_ok_Verify_AddUser_UsedOnlyOnce()
        {
            //Arrange
            _studentServiceMock.Setup(s => s.AddStudent(It.IsAny<Student>())).Verifiable();
            var handler = new StudentCommandHandler(_studentServiceMock.Object, _mapper, _localizerMock.Object);

            //Act
            var result = await handler.Handle(new AddStudentCommand()
            {
                NameAr = "محمد",
                NameEn = "Mohamed",
                Address = "Syria",
                Phone = "3450499674",
                DepartmentID = 1,
            }, default);

            //Assert
            result.Succeeded.Should().BeTrue();
            _studentServiceMock.Verify(s => s.AddStudent(It.IsAny<Student>()),
                Times.Once, "More than one usage for this method");
        }
    }
}