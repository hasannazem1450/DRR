using DRR.Domain.Articles;
using DRR.Domain.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Customer
{
    public class PatientFavoriteDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int? DoctorId { get; set; }
        public int? ArticleId { get; set; }

        public Article Article { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}
