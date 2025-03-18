using DRR.Application.Contracts.Services.Specialists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Services.Specialists
{
    public class SpecialistCategorysService : ISpecialistCategorysService
    {
        public async Task<int> GetFileSizeKb(string base64)
        {
            var result = 0;

            try
            {
                var token = ";base64,";

                var stringLength = base64.Split(token).LastOrDefault().Length;

                var sizeInBytes = 4 * Math.Ceiling((double)(stringLength / 3)) * 0.5624896334383812;
                var sizeInKb = sizeInBytes / 1000;

                result = (int)sizeInKb;
            }
            catch (Exception)
            {
            }

            return result;
        }
    }
}
