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
        public int ActivityStatus { get; set; }
        public Guid ActivityOwner { get; set; }
        [JsonIgnore]
        public List<Guid>? ActivityStaff { get; set; }
        [JsonIgnore]
        public List<Guid>? ActivityMessage { get; set; }

    }
}
