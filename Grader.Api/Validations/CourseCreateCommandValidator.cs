﻿using FluentValidation;
using Grader.Api.Business.Commands.CourseCreate;

namespace Grader.Api.Validations
{
    public class CourseCreateCommandValidator : AbstractValidator<CourseCreateCommand>
    {
        public CourseCreateCommandValidator()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Title).MaximumLength(200).WithMessage("Title cannot be longer than 200");
            RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.Description).MaximumLength(200).WithMessage("Description cannot be longer than 200");
            
        }
    }
}
