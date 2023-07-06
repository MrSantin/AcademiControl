using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AcademiControl.Models
{
    public class Activity : IEntity
    {
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Data Inicial")]
        public DateTime BeginDate { get; set; }

        [Display(Name = "Data Final")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Data de Entrega")]
        public DateTime DeliveryDate { get; set; }

        public ActivityStatus Status { get; set; }

        [Display(Name = "Responsável")]
        public Staff Owner { get; set; }

        [Display(Name = "Lista de Responsaveis")]
        public List<Staff>? Staff { get; set; }

        [Display(Name = "Mensagem")]
        public List<Message>? Message { get; set; }
        //public List<byte[]>? Document { get; set; }
    }

    public enum ActivityStatus
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
