using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Information;
using DRR.Application.Contracts.Queries.Information;
using DRR.Application.Contracts.Repository.Articles;
using DRR.Application.Contracts.Repository.Customer;
using DRR.Application.Contracts.Repository.Event;
using DRR.Application.Contracts.Repository.Information;
using DRR.Application.Contracts.Repository.Insurance;
using DRR.Application.Contracts.Repository.Specialists;
using DRR.Application.Contracts.Repository.TreatmentCenters;
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
        private readonly ISearchHistoryRepository _searchHistoryRepository;

        public MainSearchQueryHandler(IEventInfoRepository eventInfoRepository,
        IDoctorRepository doctorRepository, IArticleRepository articleRepository,
        IInsuranceRepository insuranceRepository, ISpecialistRepository specialistRepository, 
        IDoctorTreatmentCenterRepository doctorTreatmentCenterRepository, ISearchHistoryRepository searchHistoryRepository)
        {
            _eventInfoRepository = eventInfoRepository;
            _doctorRepository = doctorRepository;
            _articleRepository = articleRepository;
            _insuranceRepository = insuranceRepository;
            _specialistRepository = specialistRepository;
            _doctorTreatmentCenterRepository = doctorTreatmentCenterRepository;
            _searchHistoryRepository = searchHistoryRepository;
        }

        public async Task<MainSearchQueryResponse> Execute(MainSearchQuery query,
        CancellationToken cancellationToken)
        {

            if (query.Term.IsNullOrEmptyExtension() || query.Term.Length <= 2)
            {
                List<String> list = new List<string>();
                return
                    new MainSearchQueryResponse { Suggest = await _searchHistoryRepository.ReadSuggestionByTerm(list) };
            }
            var searchTerms = query.Term.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string suggest = await _searchHistoryRepository.ReadSuggestionByTerm(searchTerms);
           

            

            var result = new MainSearchQueryResponse
            {
                Suggest = suggest,
                Events = await SearchEvents(searchTerms),
                Articles = await SearchArticles(searchTerms),
                Doctors = await SearchDoctors(searchTerms),
                Specialists = await SearchSpecialists(searchTerms),
                TreatMentcenters = await SearchTreatmentCenters(searchTerms)
            };
            if (result.Events.Count() > 0 || result.Articles.Count()> 0 || result.Doctors.Count()>0 || result.Specialists.Count() > 0
                || result.TreatMentcenters.Count() > 0 )
            {
                await _searchHistoryRepository.CreateUpdate(query.Term);
            }

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
                Link = s.Name + s.Province.Name
            }).ToList();
            
            return result;
        }

        private async Task<List<ArticleSearchDto>> SearchArticles(List<string> searchTerms)
        {

            var articles = await _articleRepository.Search(searchTerms);

            var result = articles.Select(s => new ArticleSearchDto
            {
                Id = s.Id,
                Result = s.Title,
                ShortDesc = s.ShortDesc,
                Link = s.Title
            }).ToList();

            return result;
        }

        private async Task<List<DoctorSearchDto>> SearchDoctors(List<string> searchTerms)
        {

            var doctors = await _doctorRepository.MainSearch(searchTerms);

            var result = doctors.Select(s => new DoctorSearchDto
            {
                Id = s.Id,
                Result = s.DoctorName + " " + s.DoctorFamily + " " + s.Specialist.Name,
                ShortDesc = s.Desc,
                Link = s.UniqueSSR
            }).ToList();

            return result;
        }

        private async Task<List<SpecialistSearchDto>> SearchSpecialists(List<string> searchTerms)
        {

            var specialists = await _specialistRepository.Search(searchTerms);

            var result = specialists.Select(s => new SpecialistSearchDto
            {
                Id = s.Id,
                Result = s.Name,
                ShortDesc = s.MaxaName + " " + s.Maxa,
                Link = s.Name
            }).ToList();

            return result;
        }

       
        
        
        private async Task<List<TreatmentCenterSearchDto>> SearchTreatmentCenters(List<string> searchTerms)
        {
            var dtc = await _doctorTreatmentCenterRepository.MainSearch(searchTerms);

            var result = dtc.Select(s => new TreatmentCenterSearchDto
            {
                Id = s.Id,
                Result = s.Office?.Name ?? "" + s.Clinic?.Name ?? "",
                ShortDesc = s.Office?.Phone ?? "" + s.Clinic?.Phone ?? "",
                Link = s.Office?.Name ?? "" + s.Clinic?.Name ?? ""
            }).ToList();

            return result;
        }

    }
}
