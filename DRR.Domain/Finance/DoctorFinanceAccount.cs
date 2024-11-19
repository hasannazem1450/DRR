using DRR.Domain.Customer;
using DRR.Domain.Profile;
using DRR.Framework.Contracts.Abstracts;
using System.Collections.Generic;

namespace DRR.Domain.Finance
{
    public class DoctorFinanceAccount : Entity<int>
    {
        public DoctorFinanceAccount(int doctorId, string shebanumber, string accountnumber, int terminalId, string ip, string pass, string uRL, string gateName, int gateId, decimal doctorPortion, decimal centerPortion, bool directToAccout, bool prePayment )
        {

            DoctorId = doctorId;
            Shebanumber = shebanumber;
            Accountnumber = accountnumber;
            TerminalId = terminalId;
            Ip = ip;
            Pass = pass;
            URL = uRL;
            GateName =gateName;
            GateId = gateId;
            DoctorPortion = doctorPortion;
            CenterPortion = centerPortion;
            DirectToAccout = directToAccout;
            PrePayment = prePayment;

        }


        public int DoctorId { get; set; }
        public string Shebanumber { get; set; }
        public string Accountnumber { get; set; }
        public int TerminalId { get; set; }
        public string Ip { get; set; }
        public string Pass { get; set; }
        public string URL { get; set; }
        public string GateName { get; set; }
        public int GateId { get; set; }
        public decimal DoctorPortion { get; set; }
        public decimal CenterPortion { get; set; }
        public bool DirectToAccout { get; set; }
        public bool PrePayment { get; set; }

        public Doctor Doctor { get; set; }
        




    }

}
