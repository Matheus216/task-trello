using System;
using AutoMapper;
using trello.api.Models;
using trello.api.Repositories.Entities.Models;
using trello.api.Repositories.Task;

namespace trello.api.Service.Task
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository; 
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper; 
        }

        public TaskModel Insert(TaskModel task)
        {
            IsValid(task);

            var entity = _mapper.Map<TaskEntityModel>(task); 
            var insered =  _mapper.Map<TaskModel>(_repository.Insert(entity)); 

            return insered; 
        }

        public bool IsValid(TaskModel task)
        {
            if (String.IsNullOrEmpty(task.Title))
                throw new Exception("É necessário incluir um titulo");

            return true; 
        }
    }
}