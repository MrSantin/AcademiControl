using AcademiControl.Commands.Activities;
using AcademiControl.Models;
using AcademiControl.Repository;
using System;

namespace AcademiControl.Handlers
{
    public class ActivitiesHandlers : IHandler<CreateActivityCommand>, IHandler<UpdateActivityCommand>, IHandler<DeleteActivityCommand>
    {
        private readonly IRepository<Staff> _staffrepo;
        private readonly IRepository<Activity> _activityrepo;

        public ActivitiesHandlers(IRepository<Activity> activityrepo, IRepository<Staff> staffRepo)
        {
            _activityrepo = activityrepo;
            _staffrepo = staffRepo;
        }

        public string Handle(CreateActivityCommand command)
        {
            var activity = new Activity()
            {
                Id = Guid.NewGuid(),
                Name = command.ActivityName,
                Description = command.ActivityDescription,
                BeginDate = command.ActivityBeginDate,
                EndDate = command.ActivityEndDate,
                DeliveryDate = command.ActivityDeliveryDate,
                Status = (ActivityStatus)command.ActivityStatus,
                Owner= Owner(command.ActivityOwner)
            };

            try
            {
                _activityrepo.AddAsync(activity);
                return "Atividade criada com sucesso";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public string Handle(UpdateActivityCommand command)
        {
            var activity = _activityrepo.GetByIdAsync(command.Id).Result;

            if (activity == null)
                return "Atividade não encontrada";

            activity.EndDate = command.ActivityEndDate;
            activity.DeliveryDate = command.ActivityDeliveryDate;
            activity.Status = (ActivityStatus)command.ActivityStatus;

            try
            {
                _activityrepo.UpdateAsync(activity);
                return "Atividade atualizada com sucesso";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public string Handle(DeleteActivityCommand command)
        {
            try
            {
                _activityrepo.DeleteAsync(command.Id);
                return "Atividade excluída com sucesso";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        private Staff Owner(Guid id)
        {
            return _staffrepo.GetByIdAsync(id).Result;
        }
    }
}
