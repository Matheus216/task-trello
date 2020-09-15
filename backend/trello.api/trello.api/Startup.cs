using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using trello.api.Models;
using trello.api.Repositories.Entities.Context;
using trello.api.Repositories.Entities.Models;
using trello.api.Repositories.Paiting;
using trello.api.Repositories.Task;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            ImplementDI(services); 
            ImplementMapper(services);

            services.AddDbContext<ContextDB>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("stringConnection"))
            ); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
            services.AddTransient<IPaintingRepository, PaintingRepository>();
            services.AddTransient<IPaintingService, PaintingService>();
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<ITaskRepository, TaskRepository>();
        }

        public void ImplementMapper(IServiceCollection services)
        {
            var config = new AutoMapper.MapperConfiguration(config => {
                config.CreateMap<PaintingModel, PaintingEntityModel>();
                config.CreateMap<PanelModel, PanelEntityModel>();
                config.CreateMap<TaskModel, TaskEntityModel>();
                config.CreateMap<PaintingEntityModel, PaintingModel>();
                config.CreateMap<PanelEntityModel, PanelModel>();
                config.CreateMap<TaskEntityModel, TaskModel>();
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
