using System;
using System.Collections.Generic;
using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Commands.Specialists;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Queries.Specialists
{
    public class ReadSpecialistQuery : Query
    {
        public int SpecialistId { get; set; }
    }
    public class ReadSpecialistQueryResponse : QueryResponse
    {
        public SpecialistDto Data { get; set; }
    }
}
