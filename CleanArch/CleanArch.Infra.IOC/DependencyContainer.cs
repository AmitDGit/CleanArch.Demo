using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Domain.CommandHandler;
using CleanArch.Domain.Commands;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Query;
using CleanArch.Infra.Bus;
using CleanArch.Infra.Data.Context;
using CleanArch.Infra.Data.Dapper;
using CleanArch.Infra.Data.Repository;
using CLeanArch.Domain.Core.Bus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Infra.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection serviceCollection)
        {

            //Aplication Layer
            serviceCollection.AddScoped<ICourseService, CourseService>();

            //Infra Layer
            //serviceCollection.AddScoped<ICourseRepository, CourseRepository>();
            serviceCollection.AddScoped<ICourseRepository, CourseRespositoryDapper>();

            //Domain In Memory Bus MediatR
            serviceCollection.AddScoped<IMediatorHandler, InMemoryBus>();

            //Infra Data Layer
            serviceCollection.AddScoped<IRequestHandler<CreateCourseCommand, bool>, CourseCommandHandler>();

            serviceCollection.AddScoped<UniversityDBContext>();
            serviceCollection.AddScoped<DBConnectionFactory>();
            

            serviceCollection.AddScoped<IRequestHandler<GelAllCoursesQuery, CourseViewModel>, GetAllCoursesHandler>();
            serviceCollection.AddScoped<IUniversityDbContext, UniversityDbContextDapper>();

        }
    }
}
