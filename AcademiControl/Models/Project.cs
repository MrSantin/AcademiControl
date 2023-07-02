using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AcademiControl.Models
{
    public class Project : IEntity
    {
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Atividades")]
        public List<Activity> Activities { get; set; }

        [Display(Name = "Responsável")]
        
        public Staff ProjectOwner { get; set; }
    }
}
