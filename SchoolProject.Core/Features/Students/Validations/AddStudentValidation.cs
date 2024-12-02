using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Infrastructure.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Validations
{
    public class AddStudentValidation : AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IDepartmentService _departmentService;

        public AddStudentValidation(IStudentService studentService,
            IStringLocalizer<SharedResources> localizer,
            IDepartmentService departmentService)
        {
            _studentService = studentService;
            _localizer = localizer;
            AddStudentCommandRules();
            AddCustomValidation();
            _departmentService = departmentService;
        }


        private void AddStudentCommandRules()
        {
            RuleFor(stud => stud.NameEn).
                NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.NameEn]]).
            NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.NameEn]]).
            MaximumLength(SharedResourcesKeys.NameMaxLength).WithMessage(_localizer[SharedResourcesKeys.MaxLength, SharedResourcesKeys.NameMaxLength]);


            RuleFor(stud => stud.NameAr).
                NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.NameAr]]).
            NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.NameAr]]).
            MaximumLength(SharedResourcesKeys.NameMaxLength).WithMessage(_localizer[SharedResourcesKeys.MaxLength, SharedResourcesKeys.NameMaxLength]);

            RuleFor(stud => stud.Address)
                .NotEmpty()
                .NotNull();

            RuleFor(stud => stud.DepartmentID)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.UnAvailableDepartment])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.UnAvailableDepartment]);
        }

        private void AddCustomValidation()
        {
            RuleFor(stud => stud.NameAr)
                .MustAsync(async (Key, CancellationToken) =>
                !await _studentService.DoesExistWithNameAr(Key))
                .WithMessage(_localizer[SharedResourcesKeys.AlreadyExists, _localizer[SharedResourcesKeys.PropertyValue]]);

            RuleFor(stud => stud.NameEn)
                .MustAsync(async (Key, CancellationToken) =>
                !await _studentService.DoesExistWithNameEn(Key))
            .WithMessage(_localizer[SharedResourcesKeys.AlreadyExists, _localizer[SharedResourcesKeys.PropertyValue]]);

            RuleFor(stud => stud.DepartmentID)
                .MustAsync(async (key, CancellationToken) =>
                await _departmentService.DoesExistWithId((int)key))
            .WithMessage(_localizer[SharedResourcesKeys.UnAvailableDepartment]);
        }
    }
}
