using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace Proz_DesktopApplication.API
{
   public interface GeneralAPICalling
    {

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
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }

    public class ChangeUsernameResponse
    {
        public List<string>? Message { get; set; } = null;
        public List<string>? Errors { get; set; } = null;
    }

    public class ChangeUsernameRequest
    {
        public string CurrentPassword { get; set; }
        public string NewUsername { get; set; }
    }
}
