namespace AcademiControl.Models
{
    public class Message : IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public Staff Owner { get; set; }
    }
}
