using System;
using System.Collections.Generic;
using DRR.Application.Contracts.Commands.Specialist;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Specialist
{
    public class ReadSpecialistQuery : Query
    {
        public int SpecialistId { get; set; }
    }
    public class ReadSpecialistQueryResponse : QueryResponse
    {
        public ReadSpecialistQueryResponse()
        {
            List = new List<SpecialistDto>();
        }
        public List<SpecialistDto> List { get; set; }
    }
}
