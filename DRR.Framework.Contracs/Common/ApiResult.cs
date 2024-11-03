using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Framework.Contracts.Abstracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DRR.Framework.Contracts.Common
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ApiResult
    {
        public bool HasError { get; set; } = false;
        public dynamic Message { get; set; }
        public int? Code { get; set; }
        public dynamic Result { get; set; }

        public ApiResult()
        {
        }

        public ApiResult(CommandResponse commandResponse, dynamic result = null, bool hasError = false)
        {
            HasError = hasError;
            Code = commandResponse.Code;
            Message = commandResponse.Message;
            Result = result;
        }

        public override string ToString()
        {
            var contractResolver = new CamelCasePropertyNamesContractResolver();
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
            });
        }
    }
}
