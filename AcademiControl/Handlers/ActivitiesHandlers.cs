using AcademiControl.Commands.Activities;
using AcademiControl.Models;
using AcademiControl.Repository;

namespace AcademiControl.Handlers
{
    public class ActivitiesHandlers
    {

        private readonly IRepository<Staff> _staffrepo;
        private readonly IRepository<Activity> _activityrepo;
        public ActivitiesHandlers(IRepository<Activity> activityrepo)
        {
            _activityrepo = activityrepo;
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
                Status = command.ActivityStatus
            };



            try
            {
                _activityrepo.AddAsync(activity);
                return "Projeto criado com sucesso";
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
                return "Atividade não encontrado";

            activity.EndDate = command.ActivityEndDate;
            activity.DeliveryDate = command.ActivityDeliveryDate;
            activity.Status = (Models.ActivityStatus)command.ActivityStatus;


            try
            {
                _activityrepo.UpdateAsync(activity);
                return "Atividade atualizado com sucesso";
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

                return "Atividade excluido com sucesso";
            }
            catch (Exception error)
            {

                return error.Message;
            }

        }

    }



}

