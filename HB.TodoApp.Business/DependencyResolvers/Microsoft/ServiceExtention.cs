using AutoMapper;
using FluentValidation;
using HB.TodoApp.Business.Interfaces;
using HB.TodoApp.Business.Mapping.AutoMapper;
using HB.TodoApp.Business.Services;
using HB.TodoApp.Business.ValidationRules;
using HB.TodoApp.DataAccess.Contexts;
using HB.TodoApp.DataAccess.UnitOfWork;
using HB.TodoApp.Dtos.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HB.TodoApp.Business.DependencyResolvers.Microsoft
{
    public static class ServiceExtention
    {
        public static void AddDependencies(this IServiceCollection services, Action<ConnectionModel> action)
        {
            var cs = new ConnectionModel();
            action(cs);

            services.AddDbContext<TodoContext>(opt =>
            {
               opt.UseSqlServer(cs.ConnectionString);
                opt.LogTo(Console.WriteLine, LogLevel.Information);
            });

            services.AddScoped<IUow, Uow>();
            services.AddScoped<IWorkServices, WorkService>();

            var config = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new WorkProfile()); 
            });

            var mapper = config.CreateMapper();
            services.AddSingleton<IMapper>(mapper); //Imapper
            services.AddTransient<IValidator<WorkCreateDto>,WorkCreateDtoValidator>();
            services.AddTransient<IValidator<WorkUpdateDto>,WorkUpdateDtoValidator>();
        }
    }
    public class ConnectionModel
    {
        public string ConnectionString { get; set; } = "";
    }
}
