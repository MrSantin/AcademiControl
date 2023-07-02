namespace AcademiControl.Commands.Projects
{
    public class UpdateProjectCommand
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDesciption { get; set; }
        public Guid ProjectOwner { get; set; }
    }
}
