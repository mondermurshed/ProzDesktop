using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proz_DesktopApplication.API
{
   public interface HRMAPIEndpointsDefinitions
    {
        [Get("/HRM/LeaveRequests/Get")]
        Task<ApiResponse<List<ReturnLeaveRequestsResponse>>> GetLeaveRequestsToManage();

        [Post("/HRM/LeaveRequest/SendAnswer")]
        Task<ApiResponse<AddAnAnswerForALeaveRequestHRMResponse>> AnswerLeaveRequest([Body] LeaveRequestAcceptRejectHRMRequest model);


        [Get("/HRM/CompletedLeaveRequests/Get")]
        Task<ApiResponse<List<ReturnFinishedLeaveRequestsHRResponse>>> GetCompletedEmployeesLeaveRequestsHR();
    }


    public class ReturnFinishedLeaveRequestsHRResponse
    {
        public Guid LeaveRequestID { get; set; }
        public string employeeName { get; set; }

        public DateOnly From { get; set; }
        public DateOnly To { get; set; }
        public string Reason { get; set; }
        public string MyAnswer { get; set; }
        public DateTime LeaveRequestOLD { get; set; }
        public DateTime? AnswerOld { get; set; }
        public DateTime? DecisionOld { get; set; }
        public string DepartmentName { get; set; }
        public string ManagerName { get; set; }
        public bool Accepted { get; set; }
        public bool? NeedToAgreeOn { get; set; }
        public bool? AgreedOn { get; set; }

        public string LeaveRequestOLDAtLocal =>
       LeaveRequestOLD.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");

        public string AnswerOldInLocal =>
AnswerOld.HasValue
? AnswerOld.Value.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")
: "**No Defined DateTime**";

        public string DecisionOldInLocal =>
DecisionOld.HasValue
? DecisionOld.Value.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")
: "**No Defined DateTime**";

        public string Result =>
              Accepted == true ? "Accepted" : "Rejected";

        public string AgreementNeeded =>
            NeedToAgreeOn == true ? "Yes" : "No";

        public string Agreed =>
            AgreedOn == true ? "Yes" : "No";
    }

    public class LeaveRequestAcceptRejectHRMRequest
    {
        public Guid LeaveRequestID { get; set; }
        public bool Accept { get; set; }
        public string Comment { get; set; } = string.Empty;
        public bool MustAgreeOn { get; set; }
    }

    public class AddAnAnswerForALeaveRequestHRMResponse
    {
        public bool Success { get; set; } = false;
        public string Messagee { get; set; } = string.Empty;
        public string Error { get; set; } = string.Empty;


    }

    public class ReturnLeaveRequestsResponse
    {
        public Guid LeaveRequestID { get; set; }
        public string employeeName { get; set; }
        public DateOnly From { get; set; }
        public DateOnly To { get; set; }
        public string Reason { get; set; }
        public string DMName { get; set; }
        public string Department { get; set; }
        public DateTime CreatedAt { get; set; }

        public string CreatedAtAtLocal =>
     CreatedAt.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
    }
}
