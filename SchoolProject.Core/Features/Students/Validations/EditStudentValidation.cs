using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Infrastructure.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Validations
{
    public class EditStudentValidation : AbstractValidator<EditStudentCommand>
    {
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResources> _localizer;
        public EditStudentValidation(IStudentService studentService, IStringLocalizer<SharedResources> localizer)
        {
            _studentService = studentService;
            _localizer = localizer;
            EditStudentCommandRules();
            AddCustomValidation();
        }

        private void EditStudentCommandRules()
        {
            RuleFor(stud => stud.EditStudentCommandBody.NameEn).
               NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.NameEn]]).
               NotNull().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.NameEn]]).
               MaximumLength(SharedResourcesKeys.NameMaxLength).WithMessage(_localizer[SharedResourcesKeys.MaxLength, SharedResourcesKeys.NameMaxLength]);

            RuleFor(stud => stud.EditStudentCommandBody.NameAr).
               NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty, _localizer[SharedResourcesKeys.NameAr]]).
               MaximumLength(SharedResourcesKeys.NameMaxLength).WithMessage(_localizer[SharedResourcesKeys.MaxLength, SharedResourcesKeys.NameMaxLength]);

            RuleFor(stud => stud.EditStudentCommandBody.Address)
                .NotEmpty()
                .NotNull();
        }

        public void AddCustomValidation()
        {
            RuleFor(stud => stud.EditStudentCommandBody.NameAr)
                .MustAsync(async (model, key, CancellationToken) =>
                {
                    return !await _studentService
                    .DoesExistWithNameArExcludeSelf(key, model.id);
                }).WithMessage(_localizer[SharedResourcesKeys.AlreadyExists, _localizer[SharedResourcesKeys.PropertyValue]]);

            RuleFor(stud => stud.EditStudentCommandBody.NameEn)
                .MustAsync(async (model, key, CancellationToken) =>
                {
                    return !await _studentService
                    .DoesExistWithNameEnExcludeSelf(key, model.id);
                }).WithMessage(_localizer[SharedResourcesKeys.AlreadyExists, _localizer[SharedResourcesKeys.PropertyValue]]);
        }
    }
}
