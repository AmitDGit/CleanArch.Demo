using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces
{
    public interface IUniversityDbContext
    {
        Task<IEnumerable<Course>> GetAllCourses(CancellationToken cancellectionToken);
    }
}
