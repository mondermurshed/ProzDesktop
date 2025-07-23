using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace Proz_DesktopApplication.API
{
    public interface AdminAPIEndpointsDefinitions
    {
        [Put("/Admin/Users/AssignRoles")]
        Task<ApiResponse<AdminChangeRoleResponse>> UpdateUsersRole([Body] AdminChangeRoleRequest model);

        [Delete("/Admin/Users/DeleteAccount")]
        Task<ApiResponse<AdminDeleteAccountResponse>> DeleteAccount([Body] AdminDeleteAccountRequest model);

        [Get("/Admin/Users/GetAllUsers")]
        Task<ApiResponse<List<GetAllUsersResponse>>> GetAllUsers();
    }


    public class GetAllUsersResponse
    {
        public Guid id { get; set; }
        public string FullName { get; set; }
        public string RoleName { get; set; }
        public bool IsUser { get; set; } = false;
        public bool IsEmployee { get; set; } = false;
        public bool IsDepartmentManager { get; set; } = false;
        public bool IsHRManager { get; set; } = false;
        public bool IsAdmin { get; set; } = false;
    }

    public class AdminDeleteAccountRequest
    {
        public Guid UserID { get; set; }

   
    }

    public class AdminDeleteAccountResponse
    {
        public List<string> Message { get; set; }
        public List<string> Errors { get; set; }
    }

    public class AdminChangeRoleRequest
    {

        public Guid UserId { get; set; }
        public string NewRoles { get; set; }
    }

    public class AdminChangeRoleResponse
    {
        public List<string> Message { get; set; } 
        public List<string> Errors { get; set; }
    }
}
