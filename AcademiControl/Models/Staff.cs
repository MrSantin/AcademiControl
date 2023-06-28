using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AcademiControl.Models
{
    public class Staff : IEntity
    {
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Celular")]
        public string Phone { get; set; }
    }
}
