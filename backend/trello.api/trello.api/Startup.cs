using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using trello.api.Models;
using trello.api.Repositories.Check;
using trello.api.Repositories.Entities.Context;
using trello.api.Repositories.Entities.Models;
using trello.api.Repositories.Painting;
using trello.api.Repositories.Panel;
using trello.api.Repositories.Task;
using trello.api.Repositories.User;
using trello.api.Service.Check;
using trello.api.Service.Painting;
using trello.api.Service.Task;

namespace trello.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            ImplementDI(services); 
            ImplementMapper(services);

            services.AddDbContext<ContextDB>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("stringConnection"))
            ); 
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ImplementDI(IServiceCollection services)
        {
            services.AddTransient<ICheckRepository, CheckRepository>();
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<IPanelRepository, PanelRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPaintingRepository, PaintingRepository>();
            
            services.AddTransient<ICheckService, CheckService>();
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<IPaintingService, PaintingService>();
        }

        public void ImplementMapper(IServiceCollection services)
        {
            var config = new AutoMapper.MapperConfiguration(config => {
                
                config.CreateMap<PaintingModel, PaintingEntityModel>();
                config.CreateMap<PanelModel, PanelEntityModel>();
                config.CreateMap<TaskModel, TaskEntityModel>();
                config.CreateMap<CheckModel, CheckEntityModel>();

                config.CreateMap<PaintingEntityModel, PaintingModel>();
                config.CreateMap<PanelEntityModel, PanelModel>();
                config.CreateMap<TaskEntityModel, TaskModel>();
                config.CreateMap<CheckEntityModel, CheckModel>();
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
