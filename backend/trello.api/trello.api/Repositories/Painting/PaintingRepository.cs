using System;
using System.Collections.Generic;
using trello.api.Models;
using trello.api.Repositories.Entities;

namespace trello.api.Repositories.Paiting
{
    public class PaintingRepository : IPaintingRepository
    {
        public PaintingEntityModel Get()
        {
            var task = new List<TaskModel>();
            task.Add(new TaskModel
            {
                DateBegin = DateTime.Now,
                DateFinished = null,
                Description = "Primeira Task",
                Estimated = "4",
                Status = EnumStatus.Aberto,
                TaskId = 1
            });

            var panel = new List<PanelModel>();

            panel.Add(new PanelModel(task)
            {
                Description = "Primeiro panel",
                Title = "Testando",
                PanelId = 1,
            });

            var painting = new PaintingEntityModel
            {
                Description = "Teste",
                PaintingId = 1,
                Panel = panel,
                PanelId = 1
            };

            return painting;
        }
    }
}