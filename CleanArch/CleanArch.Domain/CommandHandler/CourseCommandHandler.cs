using CleanArch.Domain.Commands;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Domain.CommandHandler
{
    public class CourseCommandHandler : IRequestHandler<CreateCourseCommand, bool>
    {
        ICourseRepository _courseRespository;

        public CourseCommandHandler(ICourseRepository courseRepository)
        {
            _courseRespository = courseRepository;
        }


        public Task<bool> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = new Course()
            {
                Name = request.Name,
                Description=request.Description,
                ImageURL = request.ImageURL
            };

            _courseRespository.Add(course);

            return Task.FromResult(true);
        }

    }
}
