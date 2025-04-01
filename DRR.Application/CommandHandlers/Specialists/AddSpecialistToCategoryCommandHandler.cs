using DRR.Application.CommandHandlers.Specialists.Exceptions;
using DRR.Application.Contracts.Commands.Specialists;
using DRR.Application.Contracts.Repository.Specialists;
using DRR.Application.Contracts.Services.Specialists;
using DRR.Domain.Specialists;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Specialists
{
    public class AddSpecialistToCategoryCommandHandler : CommandHandler<AddSpecialistToCategoryCommand, AddSpecialistToCategoryCommandResponse>
    {
        private readonly ISpecialistCategorysRepository _specialistcategorysRepository;


        public AddSpecialistToCategoryCommandHandler(ISpecialistCategorysRepository specialistcategorysRepository)
        {
            _specialistcategorysRepository = specialistcategorysRepository;
        }
        public override async Task<AddSpecialistToCategoryCommandResponse> Executor(AddSpecialistToCategoryCommand command)
        {

            var scl = await _specialistcategorysRepository.ReadSpecialistsByCategoryId(command.CategoryId);
            if (scl.Where(x => x.Id == command.SpecialistId).Count()>0 )
                throw new Exception("تخصص قبلا به این دسته بندی تخصیص داده شده است وتکراری است");
           
                var sc = new SpecialistCategory(command.SpecialistId, command.CategoryId);

                await _specialistcategorysRepository.Create(sc);
          

            return new AddSpecialistToCategoryCommandResponse();
        }
    }
}
