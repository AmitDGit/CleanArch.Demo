using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Services
{
    public class CourseService : ICourseService
    {

        ICourseRepository _courseReposoitory;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseReposoitory = courseRepository;
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
