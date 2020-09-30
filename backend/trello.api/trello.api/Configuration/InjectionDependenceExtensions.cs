using Microsoft.Extensions.DependencyInjection;
using trello.api.Repositories.Check;
using trello.api.Repositories.Painting;
using trello.api.Repositories.Panel;
using trello.api.Repositories.Task;
using trello.api.Repositories.TaskUser;
using trello.api.Repositories.User;
using trello.api.Service.Check;
using trello.api.Service.Task;
using trello.api.Service.Painting;
using trello.api.Service.User;
using trello.api.Service.Panel;

namespace trello.api.Configuration
{
    public static class InjectionDependenceExtensions
    {
        public static void ImplementDI(this IServiceCollection services)
        {
            services.AddTransient<ICheckRepository, CheckRepository>();
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<IPanelRepository, PanelRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPaintingRepository, PaintingRepository>();
            services.AddTransient<ITaskUserRepository, TaskUserRepository>();
            
            services.AddTransient<ICheckService, CheckService>();
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<IPaintingService, PaintingService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPanelService, PanelService>();
        }
    }
}