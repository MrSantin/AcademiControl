namespace AcademiControl.Commands.Projects
{
    public class CreateProjectCommand
    {
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public Guid ProjectOwner { get; set; }
    }
}
