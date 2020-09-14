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
            if (task.DateBegin == DateTime.MinValue)
                throw new Exception("Data de início inválida..");
                
            if (String.IsNullOrEmpty(task.Estimated))
                throw new Exception("Informar a estimativa");

            return true; 
        }
    }
}