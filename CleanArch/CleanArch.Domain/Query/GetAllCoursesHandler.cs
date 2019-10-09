using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Domain.Query
{
    public class GetAllCoursesHandler : IRequestHandler<GelAllCoursesQuery, CourseViewModel>
    {
        private readonly IUniversityDbContext _universityDBContext;

        public GetAllCoursesHandler(IUniversityDbContext universityDbContext)
        {
            _universityDBContext = universityDbContext;
        }

       
        public async Task<CourseViewModel> Handle(GelAllCoursesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Course> lstCourses = await _universityDBContext.GetAllCourses(cancellationToken);

            return new CourseViewModel { Courses = lstCourses };
        }
    }
}
