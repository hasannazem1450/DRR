using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using static System.Net.Mime.MediaTypeNames;


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
        static string EnglishToPersian(string text)
        {
            // Define a mapping from English letters to Persian letters
            var map = new System.Collections.Generic.Dictionary<char, char>
        {
            { 'p', 'ح' },  
            { 'o', 'خ' },  
            { 'i', 'ه' },  
            { 'u', 'ع' },  
            { 'y', 'غ' },  
            { 't', 'ف' },  
            { 'r', 'ق' },  
            { 'e', 'ث' },  
            { 'w', 'ص' },  
            { 'q', 'ض' },  
            { 'a', 'ش' },  
            { 's', 'س' },  
            { 'd', 'ی' },  
            { 'f', 'ب' },  
            { 'g', 'ل' },  
            { 'h', 'ا' },  
            { 'j', 'ت' },  
            { 'k', 'ن' },  
            { 'l', 'م' },  
            { 'z', 'ظ' },  
            { 'x', 'ط' },  
            { 'c', 'ز' },  
            { 'v', 'ر' },  
            { 'b', 'ذ' },  
            { 'n', 'د' },  
            { 'm', 'ئ' },  
            { ',', 'و' },
            
          
            //{ 'p', 'ح' },  
            //{ 'O', 'خ' },  
            //{ 'I', 'ه' },  
            //{ 'U', 'ع' },  
            //{ 'Y', 'غ' },  
            //{ 'T', 'ف' },  
            //{ 'R', 'ق' },  
            //{ 'E', 'ث' },  
            //{ 'W', 'ص' },  
            //{ 'Q', 'ض' },  
            //{ 'A', 'ش' },  
            //{ 'S', 'س' },  
            //{ 'D', 'ی' },  
            //{ 'F', 'ب' },  
            //{ 'G', 'ل' },  
            //{ 'H', 'ا' },  
            //{ 'J', 'ت' },  
            //{ 'K', 'ن' },  
            //{ 'L', 'م' },  
            //{ 'Z', 'ظ' },  
            //{ 'X', 'ط' },  
            //{ 'C', 'ز' },  
            //{ 'V', 'ر' },  
            //{ 'B', 'ذ' },  
            //{ 'N', 'د' },  
            //{ 'M', 'ئ' },  

            // add more mappings if you want
        };

            var result = new StringBuilder();

            foreach (char c in text)
            {
                // If lowercase version exists in map, replace it
                if (map.TryGetValue(char.ToLower(c), out char persianChar))
                {
                    result.Append(persianChar);
                }
                else
                {
                    // Otherwise, keep the original character
                    result.Append(c);
                }
            }

            return result.ToString();
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
            //this code adde by nazem to check and help if the user dont have persian key board installed

            string returenedchoise = "";
            bool hasEnglish = false;
            bool hasPersian = false;

            foreach (char c in query.Term)
            {
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                {
                    hasEnglish = true;
                }
                else if ((c >= '\u0600' && c <= '\u06FF') || (c >= '\u0750' && c <= '\u077F'))
                {
                    hasPersian = true;
                }
            }

            if (hasPersian && !hasEnglish)
                returenedchoise = "Persian";
            else if (hasEnglish && !hasPersian)
                returenedchoise = "English";
            else if (hasEnglish && hasPersian)
                returenedchoise = "Mixed";
            else
                returenedchoise = "Unknown";

            if (returenedchoise == "English")
            {
                query.Term = EnglishToPersian(query.Term);
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

            //var result = dtc.Select(s => new TreatmentCenterSearchDto
            //{
            //    Id = s.Id,
            //    Result = s.Office?.Name ?? "" + s.Clinic?.Name ?? "",
            //    ShortDesc = s.Office?.Phone ?? "" + s.Clinic?.Phone ?? "",
            //    Link = s.Office?.Name ?? "" + s.Clinic?.Name ?? ""
            //}).ToList();

            var result = dtc.Select(s => new TreatmentCenterSearchDto
            {
                Id = s.Id,
                Result = s.Result,
                ShortDesc = s.ShortDesc,
                Link = s.Link
            }).ToList();


            return result;
        }

    }
}
