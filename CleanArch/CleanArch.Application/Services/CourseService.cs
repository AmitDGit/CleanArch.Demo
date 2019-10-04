using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Commands;
using CleanArch.Domain.Interfaces;
using CLeanArch.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Services
{
    public class CourseService : ICourseService
    {

        private readonly ICourseRepository _courseReposoitory;
        private readonly IMediatorHandler _bus;

        public CourseService(ICourseRepository courseRepository,IMediatorHandler bus)
        {
            _courseReposoitory = courseRepository;
            _bus = bus;
        }

        public void Create(CoursesViewModel coursesViewModel)
        {
            var createCourseCommand = new CreateCourseCommand(
                coursesViewModel.Name,coursesViewModel.Descirption,coursesViewModel.ImageUrl
                );

            _bus.SendCommand(createCourseCommand);
            
        }

        public CoursesViewModel GetCourses()
        {
            return new CoursesViewModel()
            {
                Courses = _courseReposoitory.GetCourses()
            };
        }
    }
}
