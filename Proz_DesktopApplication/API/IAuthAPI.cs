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

        [Post("/Auth/ChangeUsername")]
        Task<ApiResponse<ChangeUsernameResponse>> ChangeMyUsername([Body] ChangeUsernameRequest model);

        [Post("/Auth/ChangePassword")]
        Task<ApiResponse<ChangePasswordResponse>> ChangeMyPassword([Body] ChangePasswordRequest model);
    }


    public class ChangePasswordResponse
    {
        public List<string>? Message { get; set; } = null;
        public List<string>? Errors { get; set; } = null;
    }

    public class ChangePasswordRequest
    {
        public string CurrentPassowrd { get; set; }
        public string NewPassword { get; set; }
    }

    public class ChangeUsernameResponse
    {
        public List<string>? Message { get; set; } = null;
        public List<string>? Errors { get; set; } = null;
    }

    public class ChangeUsernameRequest
    {
        public string CurrentPassowrd { get; set; } 
        public string NewUsername { get; set; }
    }

    public class RefreshRequest
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
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
