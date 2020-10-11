using trello.api.Repositories.Entities.Models;
using trello.api.Repositories.TaskUser;
using trello.api.Repositories.Task;
using trello.api.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using trello.api.Repositories.User;

namespace trello.api.Service.Task
{
    public class TaskService : ITaskService
    {
        private readonly ITaskUserRepository _repositoryTaskUser;
        private readonly ITaskRepository _repository;
        private readonly IMapper _mapper;

        public IUserRepository _userRepository { get; set; }

        public TaskService(ITaskRepository repository, ITaskUserRepository repositoryTaksUser, IMapper mapper, IUserRepository userRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryTaskUser = repositoryTaksUser;
            _userRepository = userRepository;
        }

        public TaskModel Save(TaskModel task)
        {
            IsValid(task); 

            var entity = _mapper.Map<TaskEntityModel>(task);

            if (task.TaskId == 0)
                task.TaskId = _mapper.Map<TaskModel>(_repository.Insert(entity)).TaskId;

            else
                task.TaskId = _mapper.Map<TaskModel>(_repository.Update(entity)).TaskId;

            SaveTaskUser(task);

            return task;
        }

        private void IsValid(TaskModel task)
        {
            if (task.DateBegin == null) 
                task.DateBegin = DateTime.Now; 

            if (task.User == null)
                task.User = new List<UserModel>(); 
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
            var search = _mapper.Map<TaskModel>(_repository.GetById(id)); 

            if (search == null) 
            {
                search = new TaskModel(); 
            }

            return search; 
        }

        public List<TaskModel> GetByPanelId(int id)
        {
            var search = _mapper.Map<List<TaskModel>>(_repository.GetByPanelId(id));

            foreach (var x in search)
            {
                var taskUser = _repositoryTaskUser.GetByTaskId(x.TaskId); 

                foreach (var z in taskUser)
                {
                    var aux = _mapper.Map<UserModel>(_userRepository.GetById(z.UserId)); 
                    x.User.Add(aux);
                }                
            }

            return search;  
        }
    }
}