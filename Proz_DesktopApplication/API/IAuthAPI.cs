using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace Proz_DesktopApplication.API
{
    public interface IAuthAPI
    {
        [Post("/Auth/ForgotMyPassword")]
        Task<ApiResponse<ForgotPasswordResponse>> ForgotPassword([Body] ForgotPasswordRequest model);

        [Post("/Auth/RegisterStageOne")]
        Task<ApiResponse<UserRegisterationResponse>> RegisterStageOne([Body] UserRegisterationRequest model);

        [Post("/Auth/ResendCode")]
        Task<ApiResponse<ReSendRegistrationCodeResponse>> ResendRegistrationCodeAgain([Body] ReSendRegistrationCode model);

        [Post("/Auth/RegisterStageTwo")]
        Task<ApiResponse<UserRegisterationStageTwoResponse>> RegisterStageTwo([Body] UserRegisterationStageTwoRequest model);

        [Post("/Auth/Login")]
        Task<ApiResponse<LoginResponse>> Login([Body] LoginRequest model);

        [Post("/Auth/RefreshMyToken")]
        Task<ApiResponse<RefreshResponse>> RefreshMyAccessToken([Body] RefreshRequest model);

        [Post("/Auth/Logout")]
        Task<ApiResponse<object>> Logout([Body] LogoutRequest model);

        [Post("/Admin/CheckGettingStatus")]
        Task<ApiResponse<object>> CheckSystemGettingStartedStatus();

        [Post("/Admin/GettingStatedFirstStage")]
        Task<ApiResponse<UserRegisterationResponse>> RegisterStartingUpStageOne([Body] GettingStartingStageOneRequest model);

        [Post("/Admin/GettingStatedSecondStage")]
        Task<ApiResponse<UserRegisterationStageTwoResponse>> RegisterStartingUpStageTwo([Body] GettingStartingStageTwoRequest model);

        [Post("/Admin/ResendCodeAdmin")]
        Task<ApiResponse<ReSendRegistrationCodeResponse>> ResendRegistrationCodeAgainAdmin([Body] ReSendRegistrationCode model);
        
    }

    public class LogoutRequest
    {
        public string RefreshToken { get; set; }
        public string DeviceToken { get; set; }
    }


    public class GettingStartingStageTwoRequest
    {
        public string AdminEmail { get; set; }
        public string Code { get; set; }





    }
    public class GettingStartingStageOneRequest
    {
        public string AdminUsername { get; set; }
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }

        public string CompanyName { get; set; }
        public string Currency { get; set; }
        public string PaymentFrequency { get; set; } = "Every Month";
        public string FullName { get; set; }
        public int Age { get; set; }
        public DateOnly Date_Of_Birth { get; set; }
        public string Gender { get; set; }
        public string? Nationality { get; set; }
        public bool Living_On_Primary_Place { get; set; } = true;

    }

    public class RefreshRequest
    {
        public string RefreshToken { get; set; } = string.Empty;
        public string DeviceToken { get; set; } = string.Empty;
    }


    public class RefreshResponse
    {
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new List<string>();
    }





    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new List<string>();
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string DeviceToken { get; set; }
        public string DeviceName { get; set; }
    }
  
    public class UserRegisterationStageTwoRequest
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }

    public class UserRegisterationStageTwoResponse
    {
        public List<string> Message { get; set; }
        public List<string> Error { get; set; }
    }

    public class UserRegisterationRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public string FullName { get; set; }

        public string Age { get; set; }
        public DateOnly Date_Of_Birth { get; set; }
        public string Gender { get; set; }
        public string? Nationality { get; set; }
        public bool Living_On_Primary_Place { get; set; } = true;

    }

    public class UserRegisterationResponse
    {
        public List<string> Message { get; set; }
        public List<string> Error { get; set; }
        public int Score { get; set; }
        public string Strength { get; set; }
        public string CrackTime { get; set; }
        public List<string> Suggestions { get; set; }
        public bool PasswordCause { get; set; } = false;
    }
    public class ReSendRegistrationCodeResponse
    {
        public List<string> Message { get; set; }
        public List<string> Error { get; set; }
    }

    public class ReSendRegistrationCode
    {
        public string Email { get; set; }
    }
    public class ForgotPasswordRequest
    {
        public string Email { get; set; }
    }

    public class ForgotPasswordResponse
    {
        public List<string> Message { get; set; }
        public List<string> Error { get; set; }
    }

    public class ValidationErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Dictionary<string, string[]> Errors { get; set; }
    }
}
