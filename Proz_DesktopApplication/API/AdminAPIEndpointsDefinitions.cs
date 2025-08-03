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

        [Post("/Admin/Feedbacks/CreateFeedbackType")]
        Task<ApiResponse<AddANewFeedbackTypeResponse>> AddANewFeedbackType([Body] AddANewFeedbackTypeRequest model);

        [Get("/Admin/Feedbacks/GetFeedbackTypes")]
        Task<ApiResponse<List<GetFeedbackTypesDTO>>> GetFeedbackTypes();

        [Delete("/Admin/Feedbacks/DeleteAFeedbackType")] 
        Task<ApiResponse<RemoveFeedbackTypeResponse>> DeleteAFeedbackType([Body] RemoveFeedbackTypeRequest model);

        [Get("/Admin/Users/GetAllDepartmentManagers")]
        Task<ApiResponse<List<ReturnAllDepartmentManagers>>> GetAllDepartmentManagers();

        [Post("/Admin/Department/Create")]
        Task<ApiResponse<CreateANewDepartmentResponse>> CreateANewDepartment([Body] CreateANewDepartmentRequest model);

        [Get("/Admin/Users/GetAllDepartmentsWithItsManagers")]
        Task<ApiResponse<List<ReturnDepartmentsWithManagers>>> GetAllDepartmentsWithItsManagers();

        [Patch("/Admin/Department/UnassigningManager")]
        Task<ApiResponse<UnassignAManagerFromADepartmentResponse>> UnassignAManagerFromADepartment([Body] UnassignAManagerFromADepartmentRequest model);

        [Delete("/Admin/Department/Delete")]
        Task<ApiResponse<RemoveADepartmentResponse>> DeleteADepartment([Body] RemoveADepartmentRequest model);

        [Get("/Admin/Department/Get")]
        Task<ApiResponse<List<ReturnDepartmentsNames>>> GetDeparementsNames();

        [Get("/Admin/Department/GetAll")]
        Task<ApiResponse<List<ReturnDepartments>>> GetAllDepartments();
        

        [Patch("/Admin/Department/AssigningManager")]
        Task<ApiResponse<AssignManagerToADepartmentResponse>> AssignAManagerToADepartment([Body] AssignManagerToADepartmentRequest model);

        [Get("/Admin/Users/GetLoginHistory/My")]
        Task<ApiResponse<List<ReturnLoginHistoryForMyselfResponse>>> GetLoginHistoryOfMine([Body] ReturnLoginHistoryForMyselfRequest model);

        [Get("/Admin/Users/GetLoginHistory/Manager")]
        Task<ApiResponse<List<ReturnLoginHistoryForManagerResponse>>> GetLoginHistoryOfManager([Body] ReturnLoginHistoryForManagerRequest model);

        [Get("/Admin/Users/AllManagers/Get")]
        Task<ApiResponse<List<ReturnAllManagers>>> GetAllManagers();

        [Get("/Admin/Users/AllManagersAndAdmins/Get")]
        Task<ApiResponse<List<ReturnAllManagersAndAdmins>>> GetAllManagersAndAdmins();

        [Get("/Admin/Users/Logs/Get")]
        Task<ApiResponse<List<GetLogsForAPersonResponse>>> GetLogs([Body] GetLogsForAPersonRequest model);

        [Get("/Admin/Users/Employees/Get")]
        Task<ApiResponse<List<ReturnEmployees>>> GetEmployees();
    }


    public class ReturnEmployees
    {
        public string FullName { get; set; }
        public Guid ID { get; set; }
    }

    public class ReturnDepartments
    {
        public Guid Id { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentManager { get; set; }
    }
    public class GetLogsForAPersonResponse
    {
        public string ActionType { get; set; }
        public DateTime Performed_At { get; set; }

        public string Notes { get; set; }
        public string Targeted { get; set; }
    }
    public class GetLogsForAPersonRequest
    {
        public Guid TargetID { get; set; }
    }

    public class ReturnAllManagersAndAdmins
    {
        public string FullName { get; set; }
        public string RoleName { get; set; }
        public Guid ID { get; set; }
    }

    public class ReturnLoginHistoryForManagerResponse
    {

        public DateTime LoggedOn { get; set; }
        public string DeviceTokenHashed { get; set; }
        public string DeviceName { get; set; }
    }
    public class ReturnLoginHistoryForManagerRequest
    {
        public Guid ID { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public bool ReturnItAs { get; set; }
    }

    public class ReturnAllManagers
    {
        public string FullName { get; set; }
        public Guid ID { get; set; }
    }


    public class ReturnLoginHistoryForMyselfRequest
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public bool ReturnItAs { get; set; }

    }

    public class ReturnLoginHistoryForMyselfResponse
    {
        public DateTime LoggedOn { get; set; }
        public string DeviceTokenHashed { get; set; }
        public string DeviceName { get; set; }

        public string LoggedOnLocal => LoggedOn.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
    }

    public class AssignManagerToADepartmentRequest
    {
        public Guid DepartmentID { get; set; }
        public Guid ManagerID { get; set; }
    }

    public class AssignManagerToADepartmentResponse
    {
        public List<string>? Message { get; set; } = null;
        public List<string>? Errors { get; set; } = null;
    }

    public class ReturnDepartmentsNames
    {
        public string DepartmentName { get; set; }
        public Guid Id { get; set; }
    }

    public class RemoveADepartmentRequest
    {
        public Guid DepartmentID { get; set; }

        public bool WithUnassignEmployeesFromItAgreement { get; set; } = false;
    }
    public class RemoveADepartmentResponse
    {
        public List<string>? Message { get; set; } = null;
        public List<string>? Errors { get; set; } = null;
        public bool NeedesAdminApproval { get; set; } = false;
    }
    public class UnassignAManagerFromADepartmentResponse
    {
        public List<string>? Message { get; set; } = null;
        public List<string>? Errors { get; set; } = null;
    }


    public class UnassignAManagerFromADepartmentRequest
    {
        public Guid DepartmentID { get; set; }

    }
    public class ReturnDepartmentsWithManagers
    {

        public string DepartmentName { get; set; }
        public string ManagerName { get; set; }
        public Guid DepartmentID { get; set; }
        public Guid ManagerID { get; set; }



    }
   
    public class CreateANewDepartmentResponse
    {
        public List<string>? Message { get; set; } = null;
        public List<string>? Errors { get; set; } = null;
    }
    public class CreateANewDepartmentRequest
    {
        public Guid ManagerID { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
    }

    public class ReturnAllDepartmentManagers
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
    }

    public class RemoveFeedbackTypeResponse
    {
        public List<string>? Message { get; set; } = null;
        public List<string>? Errors { get; set; } = null;
    }

    public class RemoveFeedbackTypeRequest
    {
        public Guid FeedbackID { get; set; }
        public string ReplaceWith { get; set; }
    }

    public class GetFeedbackTypesDTO
    {
        public Guid Id { get; set; }
        public string FeedbackTypeName { get; set; }
    }
    public class AddANewFeedbackTypeRequest
    {
        public string feedbackTypeName { get; set; }
    }
    public class AddANewFeedbackTypeResponse
    {
        public List<string>? Message { get; set; } 
        public List<string>? Errors { get; set; } 
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
