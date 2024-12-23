using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands;
using DRR.Application.Contracts.Commands.Authentication;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DRR.Host.Controllers.Authentication
{
    [AllowAnonymous]
    public class AuthenticationController : MainController
    {
        public AuthenticationController(IDistributor distributor) : base(distributor)
        {
        }
        [SwaggerOperation(Summary = "ثبت کاربری در سایت")]
        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp(SignUpCommand query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<SignUpCommand, SignUpCommandResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "ورود به سایت")]
        [HttpPut("sign-in")]
        public async Task<IActionResult> SignIn(SignInCommand query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<SignInCommand, SignInCommandResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "خروج از سایت")]
        [HttpGet("sign-out")]
        public async Task<IActionResult> SignOut(CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<SignOutCommand, SignOutCommandResponse>(new SignOutCommand(), cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "ایجاد کد تایید")]
        [HttpPost("generate-registration-code")]
        public async Task<IActionResult> GenerateRegistrationCode(GenerateRegistrationCodeCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<GenerateRegistrationCodeCommand, GenerateRegistrationCodeCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "فعال کردن کاربر با کد تایید")]
        [HttpPost("activating-registration")]
        public async Task<IActionResult> ActivatingRegistration(ActivatingRegistrationCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<ActivatingRegistrationCommand, ActivatingRegistrationCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "فراموشی کلمه عبور")]
        [HttpPost("forget-password")]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<ForgetPasswordCommand, ForgetPasswordCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "ارسال کد به موبایل برای ریست کردن پسورد")]
        [HttpPost("reseting-password")]
        public async Task<IActionResult> ResetingPassword(ResetingPasswordCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<ResetingPasswordCommand, ResetingPasswordCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "ریست کردن پسورد در صورت صحت کد ارسالی ")]
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<ResetPasswordCommand, ResetPasswordCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
    }
}
