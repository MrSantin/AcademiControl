using AcademiControl.Commands.Projects;
using AcademiControl.Models;
using AcademiControl.Repository;
using NuGet.Protocol.Core.Types;

namespace AcademiControl.Handlers
{
    public class ProjectHandlers
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
                Id =  Guid.NewGuid(),
                Description = command.ProjectDescription,
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

        public string Handle(UpdateProjectCommand command)
        {
            var project = _repository.GetByIdAsync(command.Id).Result;
           
            if (project == null)
                return "Projeto não encontrado";


            project.Description = command.ProjectDescription;
            project.Name = command.ProjectName;
            project.ProjectOwner = Owner(command.ProjectOwner);
            

            try
            {
                _repository.UpdateAsync(project);
                return "Projeto atualizado com sucesso";
            }
            catch (Exception error)
            {

                return error.Message;
            }

        }

        public string Handle(DeleteProjectCommand command)
        {

            try
            {
                _repository.DeleteAsync(command.id);

                return "Projeto excluido com sucesso";
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
