using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Domain.Query;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetCourseController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<CourseViewModel>> GetAll() 
        {
            var vm = await Mediator.Send(new GelAllCoursesQuery());
            return Ok(vm);
        }
    }
}