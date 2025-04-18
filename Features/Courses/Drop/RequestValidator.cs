﻿using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Courses.Drop.Models;

namespace iSchool_Solution.Features.Courses.Drop;

public class RequestValidator : Validator<DropCourseRequest>
{
    public RequestValidator()
    {
        RuleFor(request => request.CourseCode)
            .NotNull().WithMessage("Course code cannot be null")
            .NotEmpty().WithMessage("Course code must be provided")
            .MaximumLength(20).WithMessage("Course code cannot exceed 20 characters")
            .Matches(@"^[A-Z0-9]{2,10}$").WithMessage("Course code must be in a valid format (e.g., CS101)");
    }
}