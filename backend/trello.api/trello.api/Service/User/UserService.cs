using System.Collections.Generic;
using AutoMapper;
using trello.api.Models;
using trello.api.Repositories.Entities.Models;
using trello.api.Repositories.User;

namespace trello.api.Service.User
{
    public class UserService : IUserService
    {
        public IMapper _mapper { get; set; }
        public IUserRepository _repository { get; set; }

        public UserService(IMapper mapper, IUserRepository repository)
        {
            _mapper = mapper;
            _repository = repository; 
        }

        public UserModel Get(int id)
        {
            var search =  _mapper.Map<UserModel>(_repository.GetById(id));

            return search; 
        }

        public IList<UserModel> Get()
        {
            var search = _mapper.Map<List<UserModel>>(_repository.GetAll()); 

            return search; 
        }

        public void Remove(int id)
        {
            _repository.Delete(id); 
        }

        public UserModel Save(UserModel user)
        {
            var userOut = new UserModel(); 

            if (user.UserId == 0) 
            {
                var insered = _repository.Insert(_mapper.Map<UserEntityModel>(user));

                userOut = _mapper.Map<UserModel>(insered); 
            }
            else 
            {
                var insered = _repository.Update(_mapper.Map<UserEntityModel>(user));
                
                userOut = _mapper.Map<UserModel>(insered);
            }

            return userOut; 
        }
    }
}