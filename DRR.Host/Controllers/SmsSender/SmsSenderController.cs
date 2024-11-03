using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DRR.Host.Controllers.SmsSender
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsSenderController : ControllerBase
    {
        //public async Task<IActionResult> SendSms()
        //{
        //    string username = "username";
        //    string password = "password";
        //    string domain = "magfa";

        //    var client = new RestClient("https://sms.magfa.com/api/http/sms/v2/send");

        //    client.Authenticator = new HttpBasicAuthenticator(username + "/" + domain, password);

        //    var request = new RestRequest(Method.POST);
        //    request.AddHeader("cache-control", "no-cache");
        //    request.AddHeader("accept", "application/json");

        //    request.RequestFormat = DataFormat.Json;
        //    request.AddBody(new { senders: ['3000xx', '3000xxxxxxxx'], messages:['test msg', 'msg 2'], recipients:['0912xxxxxxx', '0903xxxxxxx']});

        //IRestResponse response = client.Execute(request);

        //}
    }
}
