using DRR.Domain.Comments;
using DRR.Domain.Articles;
using DRR.Domain.Profile;
using DRR.Domain.Reservations;
using DRR.Domain.FileManagement;
using DRR.Domain.Specialists;
using DRR.Domain.TreatmentCenters;
using System;
using System.Collections.Generic;
using DRR.Framework.Contracts.Abstracts;
using DRR.Domain.BaseInfo;
using System.Xml.Linq;
using DRR.Domain.Insurances;



namespace DRR.Domain.Customer
{
    public class Doctor : Entity<int>
    {
        public Doctor(string doctorName, string doctorFamily, string nationalId, int codeNezam, int specialistId, string docExperiance, string docInstaLink, string mobile, string desc)
        {
            DoctorName = doctorName;
            DoctorFamily = doctorFamily;
            NationalId = nationalId;
            SpecialistId = specialistId;
            CodeNezam = codeNezam;
            DocExperiance = docExperiance;
            DocInstaLink = docInstaLink;
            Mobile = mobile;
            Desc = desc;
           

        }

        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string DoctorFamily { get; set; }
        public string NationalId { get; set; }
        public int SpecialistId { get; set; }
        public int CodeNezam {  get; set; }
        public string DocExperiance { get; set; }
        public string DocInstaLink { get; set; }
        public string Mobile { get; set; }
        public string Desc { get; set; }
       

        public Specialist Specialist { get; set; }
   

        public Guid? PersonalPhotoFileId { get; protected set; }
        public DRRFile? PersonalPhotoFile { get; protected set; }
        public Guid? LicancePhotoFileId { get; protected set; }
        public DRRFile? LicancePhotoFile { get; protected set; }
        public Guid? CertificatePhotoFileId { get; protected set; }
        public DRRFile? CertificatePhotoFile { get; protected set; }




        public int SmeProfileId { get; set; }
        public SmeProfile SmeProfile { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<CommentReply> CommentReplys { get; set; }
        public ICollection<Article> Articles { get; set; }
        public ICollection<DoctorInsurance> DoctorInsurances { get; set; }



        public void Update(string doctorName, string doctorFamily, string nationalId, int codeNezam, int specialistId, string docExperiance, string docInstaLink, string mobile, string desc)
        {
            DoctorName = doctorName;
            DoctorFamily = doctorFamily;
            NationalId = nationalId;
            SpecialistId = specialistId;
            CodeNezam = codeNezam;
            DocExperiance = docExperiance;
            DocInstaLink = docInstaLink;
            Mobile = mobile;
            Desc = desc;
        }
        public void SetIsDeleted(bool isDeleted)
        {
            IsDeleted = isDeleted;
        }

    }

}
