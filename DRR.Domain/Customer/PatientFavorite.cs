using DRR.Domain.Customer;
using DRR.Domain.Profile;
using DRR.Domain.Articles;
using System.Collections.Generic;
using DRR.Framework.Contracts.Abstracts;


namespace DRR.Domain.Customer
{
    public class PatientFavorite : Entity<int>
    {
        public PatientFavorite(int patientId, int? doctorId, int? articleId)
        {

            PatientId = patientId;
            DoctorId = doctorId;
            ArticleId = articleId;
        }


        public int PatientId { get; set; }
        public int? DoctorId { get; set; }
        public int? ArticleId { get; set; }

        public Article Article { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }




    }

}
