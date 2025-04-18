using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Information;
using DRR.Application.Contracts.Queries.Information;
using DRR.Application.Contracts.Repository;
using DRR.Application.Contracts.Repository.Articles;
using DRR.Application.Contracts.Repository.Customer;
using DRR.Application.Contracts.Repository.Event;
using DRR.Application.Contracts.Repository.Insurance;
using DRR.Application.Contracts.Repository.Profile;
using DRR.Application.Contracts.Repository.Specialists;
using DRR.Application.Contracts.Repository.TreatmentCenters;
using DRR.CommandDb.Repository.TreatmentCentres;
using DRR.Framework.Contracts.Markers;
using DRR.Utilities.Extensions;

namespace DRR.Application.QueryHandlers.Information
{
    public class MainSearchQueryHandler : IQueryHandler<MainSearchQuery,MainSearchQueryResponse>
    {
        private readonly IEventInfoRepository _eventInfoRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IArticleRepository _articleRepository;
        private readonly IInsuranceRepository _insuranceRepository;
        private readonly ISpecialistRepository _specialistRepository;
        private readonly IDoctorTreatmentCenterRepository _doctorTreatmentCenterRepository;

        public MainSearchQueryHandler(IEventInfoRepository eventInfoRepository,
        IDoctorRepository doctorRepository, IArticleRepository articleRepository,
        IInsuranceRepository insuranceRepository, ISpecialistRepository specialistRepository, 
        IDoctorTreatmentCenterRepository doctorTreatmentCenterRepository)
        {
            _eventInfoRepository = eventInfoRepository;
            _doctorRepository = doctorRepository;
            _articleRepository = articleRepository;
            _insuranceRepository = insuranceRepository;
            _specialistRepository = specialistRepository;
            _doctorTreatmentCenterRepository = doctorTreatmentCenterRepository;
        }

        public async Task<MainSearchQueryResponse> Execute(MainSearchQuery query,
        CancellationToken cancellationToken)
        {
            if (query.Term.IsNullOrEmptyExtension() || query.Term.Length <= 2) return new MainSearchQueryResponse();

            var searchTerms = query.Term.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            var result = new MainSearchQueryResponse
            {
                Events = await SearchEvents(searchTerms),
                Articles = await SearchArticles(searchTerms),
                Doctors = await SearchDoctors(searchTerms),
                Specialists = await SearchSpecialists(searchTerms),
                TreatMentcenters = await SearchTreatmentCenters(searchTerms)
            };

            return result;
        }

        private async Task<List<EventSearchDto>> SearchEvents(List<string> searchTerms)
        {

            var eventInfos = await _eventInfoRepository.Search(searchTerms);

            var result = eventInfos.Select(s => new EventSearchDto
            {
                Id = s.Id,
                Result = s.Name,
                ShortDesc = s.Province.Name + s.EndDate,
                Link = "siteurl" + s.Id
            }).ToList();

            return result;
        }

        private async Task<List<ArticleSearchDto>> SearchArticles(List<string> searchTerms)
        {

            var eventInfos = await _articleRepository.Search(searchTerms);

            var result = eventInfos.Select(s => new ArticleSearchDto
            {
                Id = s.Id,
                Result = s.Title,
                ShortDesc = s.ShortDesc,
                Link = "siteurl" + s.Id
            }).ToList();

            return result;
        }

        private async Task<List<DoctorSearchDto>> SearchDoctors(List<string> searchTerms)
        {

            var eventInfos = await _doctorRepository.MainSearch(searchTerms);

            var result = eventInfos.Select(s => new DoctorSearchDto
            {
                Id = s.Id,
                Result = s.DoctorName + " " + s.DoctorFamily + " " + s.Specialist.Name,
                ShortDesc = s.Desc,
                Link = "siteurl" + s.Id
            }).ToList();

            return result;
        }

        private async Task<List<SpecialistSearchDto>> SearchSpecialists(List<string> searchTerms)
        {

            var eventInfos = await _specialistRepository.Search(searchTerms);

            var result = eventInfos.Select(s => new SpecialistSearchDto
            {
                Id = s.Id,
                Result = s.Name,
                ShortDesc = s.MaxaName + " " + s.Maxa,
                Link = "siteurl" + s.Id
            }).ToList();

            return result;
        }

       
        
        
        private async Task<List<TreatmentCenterSearchDto>> SearchTreatmentCenters(List<string> searchTerms)
        {
            var dtc = await _doctorTreatmentCenterRepository.MainSearch(searchTerms);

            var result = dtc.Select(s => new TreatmentCenterSearchDto
            {
                Id = s.Id,
                Result = s.Office.Name ?? "" + s.Clinic.Name ?? "",
                ShortDesc = s.Office.Phone ?? "" + s.Clinic.Phone ?? "",
                Link = "siteurl" + s.Id
            }).ToList();

            return result;
        }

    }
}
