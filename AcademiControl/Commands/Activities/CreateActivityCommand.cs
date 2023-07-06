using AcademiControl.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AcademiControl.Commands.Activities
{
    public class CreateActivityCommand
    {
        public string ActivityName { get; set; }
        public string ActivityDescription { get; set; }
        public DateTime ActivityBeginDate { get; set; }
        public DateTime ActivityEndDate { get; set; }
        public DateTime ActivityDeliveryDate { get; set; }

        public ActivityStatus ActivityStatus { get; set; }

        //[JsonIgnore]
        //public Staff ActivityOwner { get; set; }
        //[JsonIgnore]
        //public List<Staff>? ActivityStaff { get; set; }
        //[JsonIgnore]
        //public List<Message>? ActivityMessage { get; set; }

    }
}
