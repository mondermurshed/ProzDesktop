using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proz_DesktopApplication.API
{
    public interface DMAPIEndpointsDefinitions
    {
        [Get("/Employee/Feedbacks/GetFeedbackTypes")]
        Task<ApiResponse<List<GetFeedbackTypesDTO>>> GetFeedbackTypes();

        [Get("/DM/Departments/Get")]
        Task<ApiResponse<List<ReturnAllDepartments>>> GetMyDepartments();

        [Get("/DM/Feedbacks/Get")]
        Task<ApiResponse<List<ReturnFeedbacksResponse>>> GetEmployeesFeedbacks([Body] ReturnFeedbacksRequest model);

        [Post("/DM/FeedbacksAnswer/Add")]
        Task<ApiResponse<AddAnAnswerForAFeedbackResponse>> AddFeedbackAnswer([Body] AddAnAnswerForAFeedbackRequest model);

        [Get("/DM/FinishedFeedbacks/Get")]
        Task<ApiResponse<List<ReturnFinishedFeedbacksResponse>>> GetEmployeesFinishedFeedbacks([Body] ReturnFinishedFeedbacksRequest model);

        [Get("/DM/LeaveRequests/Get")]
        Task<ApiResponse<List<ReturnMyEmployeesLeaveRequests>>> GetEmployeesLeaveRequests([Body] ReturnMyEmployeesLeaveRequests_Request_ model);

        [Post("/DM/LeaveRequest/SendAnswer")]
        Task<ApiResponse<AddAnAnswerForALeaveRequestResponse>> AddLeaveRequestAnswer([Body] LeaveRequestAcceptRejectRequest model);


           [Get("/DM/CompletedLeaveRequests/Get")]
        Task<ApiResponse<List<ReturnFinishedLeaveRequestsResponse>>> GetCompletedEmployeesLeaveRequests([Body] ReturnFinishedLeaveRequestsRequest model);

        [Get("/DM/Employees/Get")]
        Task<ApiResponse<List<ReturnPerformanceRecordsResponse>>> GetMyEmployees([Body] ReturnPerformanceRecordsRequest model);

        [Post("/DM/Performance/SendPerformance")]
        Task<ApiResponse<SubmitPerformanceAnswerResponse>> PerformanceSubmitting([Body] SubmitPerformanceAnswerRequest model);
    }

    public class SubmitPerformanceAnswerResponse
    {
        public bool Success { get; set; } = false;
        public string Messagee { get; set; } = string.Empty;
        public string Error { get; set; } = string.Empty;
    }

    public class SubmitPerformanceAnswerRequest
    {
        public Guid EmployeeID { get; set; }
        public int Ratting { get; set; }
        public string Comment { get; set; }
    }

    public class ReturnPerformanceRecordsRequest
    {
        public Guid DepartmentID { get; set; }
    }
    public class ReturnPerformanceRecordsResponse
    {
        public Guid EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        //public int PerformanceRating { get; set; }

    }

    public class ReturnFinishedLeaveRequestsRequest
    {
        public Guid Department { get; set; }
    }

    public class ReturnFinishedLeaveRequestsResponse
    {
        public Guid LeaveRequestID { get; set; }
        public string employeeName { get; set; }
        public string SenderName { get; set; }
        public DateOnly From { get; set; }
        public DateOnly To { get; set; }
        public string Reason { get; set; }
        public string MyAnswer { get; set; }
        public DateTime LeaveRequestOLD { get; set; }
        public DateTime? AnswerOld { get; set; }

        public bool Accepted { get; set; }

        public string LeaveRequestOLDAtLocal =>
       LeaveRequestOLD.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");

        public string AnswerOldInLocal =>
AnswerOld.HasValue
? AnswerOld.Value.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")
: "**No Defined DateTime**";

        public string Result =>
              Accepted==true ? "Accepted" : "Rejected";
    }

    public class LeaveRequestAcceptRejectRequest
    {
        public Guid LeaveRequestID { get; set; }
        public bool Accept { get; set; }
        public string Comment { get; set; } = string.Empty;
    }

    public class AddAnAnswerForALeaveRequestResponse
    {
        public bool Success { get; set; } = false;
        public string Messagee { get; set; } = string.Empty;
        public string Error { get; set; } = string.Empty;
    }

    public class ReturnMyEmployeesLeaveRequests_Request_
    {
        public Guid Department { get; set; }
    }

    public class ReturnMyEmployeesLeaveRequests
    {
        public Guid LeaveRequestID { get; set; }
        public string employeeName { get; set; }
        public DateOnly From { get; set; }
        public DateOnly To { get; set; }
        public string Reason { get; set; }
    }

    public class ReturnFinishedFeedbacksRequest
    {
        public Guid Department { get; set; }
    }

    public class ReturnFinishedFeedbacksResponse
    {
        public Guid FeedbackID { get; set; }
        public string FeedbackTitle { get; set; }
        public string FeedbackDescription { get; set; }
        public string MyAnswer { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? AnsweredAt { get; set; } = DateTime.UtcNow;
        public string FeedbackTypeName { get; set; }
        public string RequesterEmployeeName { get; set; }

        public string CreatedAtLocal =>
        CreatedAt.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");


        public string AnsweredInLocal =>
AnsweredAt.HasValue
  ? AnsweredAt.Value.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")
  : "**No Answer yet**";
   
    }

    public class AddAnAnswerForAFeedbackRequest
    {
        public Guid TargetedFeedback { get; set; }
        public string Answer { get; set; } = string.Empty;
    }
    public class AddAnAnswerForAFeedbackResponse
    {
        public bool Success { get; set; } = false;
        public string Messagee { get; set; } = string.Empty;
        public string Error { get; set; } = string.Empty;
    }
    public class ReturnFeedbacksRequest
    {
        public Guid Department { get; set; }

    }

    public class ReturnFeedbacksResponse
    {
        public Guid FeedbackID { get; set; }
        public string FeedbackTitle { get; set; }
        public string FeedbackDescription { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string FeedbackTypeName { get; set; }
        public string RequesterEmployeeName { get; set; }

        public string CreatedAtLocal =>
    CreatedAt.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");


    }

    public class ReturnAllDepartments
    {
        public Guid DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }
}
