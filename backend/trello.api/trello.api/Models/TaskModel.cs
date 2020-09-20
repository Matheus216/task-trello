using System;
using System.Collections.Generic;
using trello.api.Models.Abstract;

namespace trello.api.Models
{
    public class TaskModel : TaskAbstractModel
    {
        public TaskModel()
        {
            CheckList = new List<CheckModel>(); 
            User = new List<UserModel>(); 
        }
        
        public List<CheckModel> CheckList { get; set; }
        public List<UserModel> User { get; set; }
    }
}