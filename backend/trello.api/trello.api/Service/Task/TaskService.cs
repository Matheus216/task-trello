using System;
using System.Collections.Generic;
using AutoMapper;
using trello.api.Models;
using trello.api.Repositories.Entities.Models;
using trello.api.Repositories.Task;
using trello.api.Repositories.TaskUser;

namespace trello.api.Service.Task
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;
        private readonly ITaskUserRepository _repositoryTaskUser;
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

            if (task.TaskId == 0)
            {
                IsValid(task);

                var entity = _mapper.Map<TaskEntityModel>(task);
                taskInsered = _mapper.Map<TaskModel>(_repository.Insert(entity));

                task.TaskId = taskInsered.TaskId;

                SaveTaskUser(task);
            }
            else
            {

            }

            return insered;
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

        public TaskModel Remove(int id)
        {
            throw new NotImplementedException();
        }

        public TaskModel Get()
        {
            throw new NotImplementedException();
        }

        public TaskModel Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}