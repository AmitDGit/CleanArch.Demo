using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Commands;
using CleanArch.Domain.Interfaces;
using CLeanArch.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArch.Application.Services
{
    public class CourseService : ICourseService
    {

        private readonly ICourseRepository _courseReposoitory;
        private readonly IMediatorHandler _bus;
        private readonly IMapper _autoMapper;

        public CourseService(ICourseRepository courseRepository,IMediatorHandler bus,IMapper autoMapper)
        {
            _courseReposoitory = courseRepository;
            _bus = bus;
            _autoMapper = autoMapper;
        }

        public void Create(CoursesViewModel coursesViewModel)
        {
            //var createCourseCommand = new CreateCourseCommand(
            //    coursesViewModel.Name,coursesViewModel.Descirption,coursesViewModel.ImageUrl
            //    );

            _bus.SendCommand(_autoMapper.Map<CreateCourseCommand>(coursesViewModel));

            
            
        }

        public IEnumerable<CoursesViewModel> GetCourses()
        {
            return _courseReposoitory.GetCourses().ProjectTo<CoursesViewModel>(_autoMapper.ConfigurationProvider);
        }
    }
}
