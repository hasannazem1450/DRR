using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands;
using DRR.Application.Contracts.Repository;
using DRR.Domain.Project;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.CommandHandlers
{
    public class CreateProjectCommandHandler : CommandHandler<CreateProjectCommand, CreateProjectCommandResponse>
    {
        private readonly IProjectRepository _projectRepository;

        public CreateProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }


        public override async Task<CreateProjectCommandResponse> Executor(CreateProjectCommand command)
        {
            var project = new Project(command.ProjectName, command.Price);
            var result = await _projectRepository.Create(project);

            return new CreateProjectCommandResponse()
            {
                IsCreated = result
            };
        }
    }
}
