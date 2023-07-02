using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AcademiControl.Models
{
    public class Message : IEntity
    {
        public Guid Id { get; set; }

        [Display(Name = "Título")]
        public string Title { get; set; }

        [Display(Name = "Descrição")]
        public string Body { get; set; }

        [Display(Name = "Responsável")]
        public Staff Owner { get; set; }
    }
}
