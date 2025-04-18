using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Information;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Queries.Information
{
    public class MainSearchQuery : Query
    {
        public string Term { get; set; }
    }

    public class MainSearchQueryResponse : QueryResponse
    {
        public string Suggest { get; set; }
        public List<DoctorSearchDto> Doctors { get; set; }
        public List<ArticleSearchDto> Articles { get; set; }
        public List<SpecialistSearchDto> Specialists { get; set; }
        public List<TreatmentCenterSearchDto> TreatMentcenters { get; set; }
        public List<EventSearchDto> Events { get; set; }

    }

}
