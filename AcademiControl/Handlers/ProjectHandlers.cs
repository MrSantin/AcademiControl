using AcademiControl.Commands.Projects;
using AcademiControl.Models;
using AcademiControl.Repository;
using NuGet.Protocol.Core.Types;

namespace AcademiControl.Handlers
{
    public class ProjectHandlers:CreateProjectCommand
    {
        private readonly IRepository<Project> _repository;
        private readonly IRepository<Staff> _staffrepo;
        public ProjectHandlers(IRepository<Project> repository, IRepository<Staff> staffrepo)
        {
            _repository = repository;
            _staffrepo = staffrepo;
        }

        public string Handle(CreateProjectCommand command)
        {
            var project = new Project() {
                Id = new Guid(),
                Description = command.ProjectDesciption,
                Name = command.ProjectName,
                ProjectOwner = Owner(command.ProjectOwner)
            };



            try
            {
                _repository.AddAsync(project);
                return "Projeto criado com sucesso";
            }
            catch (Exception error)
            {
                
                return error.Message;
            }

        }

        private Staff Owner(Guid id)
        {
            return _staffrepo.GetByIdAsync(id).Result;
        }
    }
}
