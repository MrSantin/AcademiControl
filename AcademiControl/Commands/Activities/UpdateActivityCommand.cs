using AcademiControl.Models;
namespace AcademiControl.Commands.Activities
{
    public class UpdateActivityCommand
    {

        public Guid Id { get; set; }

        //public string ActivityName { get; set; }
        //public string ActivityDescription { get; set; }
        //public DateTime ActivityBeginDate { get; set; }
        public DateTime ActivityEndDate { get; set; }
        public DateTime ActivityDeliveryDate { get; set; }

        public TaskStatus ActivityStatus { get; set; }
        public Staff ActivityOwner { get; set; }

        public List<Staff>? ActivityStaff { get; set; }

       // public List<Message>? ActivityMessage { get; set; }

        public enum TaskStatus
        {
            Completed,
            Pending,
            Delayed,
            Cancelled
        }

        public enum Priority
        {
            Normal,
            Low,
            High
        }


    }
}
