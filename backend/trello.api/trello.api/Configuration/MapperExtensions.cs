using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using trello.api.Models;
using trello.api.Repositories.Entities.Models;

namespace trello.api.Configuration
{
    public static class MapperExtensions
    {
        public static void ImplementMapper(this IServiceCollection services)
        {
            var config = new AutoMapper.MapperConfiguration(config => {
                
                config.CreateMap<PaintingModel, PaintingEntityModel>();
                config.CreateMap<PanelModel, PanelEntityModel>();
                config.CreateMap<TaskModel, TaskEntityModel>();
                config.CreateMap<CheckModel, CheckEntityModel>();
                config.CreateMap<UserModel, UserEntityModel>();

                config.CreateMap<PaintingEntityModel, PaintingModel>();
                config.CreateMap<PanelEntityModel, PanelModel>();
                config.CreateMap<TaskEntityModel, TaskModel>();
                config.CreateMap<CheckEntityModel, CheckModel>();
                config.CreateMap<UserEntityModel, UserModel>();
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}