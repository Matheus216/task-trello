using trello.api.Repositories.Entities.Models;
using trello.api.Repositories.TaskUser;
using trello.api.Repositories.Task;
using trello.api.Models;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace trello.api.Service.Task
{
    public class TaskService : ITaskService
    {
        private readonly ITaskUserRepository _repositoryTaskUser;
        private readonly ITaskRepository _repository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository repository, ITaskUserRepository repositoryTaksUser, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryTaskUser = repositoryTaksUser;
        }

        public TaskModel Save(TaskModel task)
        {
            var taskInsered = new TaskModel();
            IsValid(task);

            if (task.TaskId == 0)
            {
                var entity = _mapper.Map<TaskEntityModel>(task);
                taskInsered = _mapper.Map<TaskModel>(_repository.Insert(entity));

                task.TaskId = taskInsered.TaskId;

                SaveTaskUser(task);
            }
            else
            {
                var entity = _mapper.Map<TaskEntityModel>(task);
                taskInsered = _mapper.Map<TaskModel>(_repository.Update(entity));

                task.TaskId = taskInsered.TaskId;

                SaveTaskUser(task);
            }

            return taskInsered;
        }
        private void SaveTaskUser(TaskModel task)
        {

            foreach (var x in task.User)
            {
                var userTask = _repositoryTaskUser.GetById(task.TaskId, x.UserId);
                if (userTask == null)
                {
                    var taskUser = new TaskUserEntityModel
                    {
                        TaskId = task.TaskId,
                        UserId = x.UserId
                    };

                    _repositoryTaskUser.Insert(taskUser);
                }
            }
        }
        public bool IsValid(TaskModel task)
        {
            if (task.User == null)
                throw new Exception("É necessário incluir um membro");

            if (String.IsNullOrEmpty(task.Title))
                throw new Exception("É necessário incluir um titulo");

            return true;
        }

        public void Remove(int id)
        {
            _repository.Delete(id); 
        }

        public IList<TaskModel> Get()
        {
            throw new NotImplementedException();
        }

        public TaskModel Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}