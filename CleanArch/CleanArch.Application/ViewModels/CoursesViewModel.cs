using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.ViewModels
{
    public class CoursesViewModel
    {
        public string Name { get; set; }
        public string Descirption { get; set; }
        public string ImageUrl { get; set; }

        public IEnumerable<Course> Courses { get; set; }
    }
}
