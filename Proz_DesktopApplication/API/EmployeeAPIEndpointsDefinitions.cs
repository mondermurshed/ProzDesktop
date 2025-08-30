using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proz_DesktopApplication.API
{
    public interface EmployeeAPIEndpointsDefinitions
    {
        [Get("/Employee/Feedbacks/GetFeedbackTypes")]
        Task<ApiResponse<List<GetFeedbackTypesDTO>>> GetFeedbackTypes();

        [Post("/Employee/Feedbacks/RequestANewFeedback")]
        Task<ApiResponse<CreateANewFeedbackRequest_Response>> RequestANewFeedbackRequest([Body] CreateANewFeedbackRequest_Request model);

        [Get("/Employee/Feedbacks/ReturnMyFeedbacksInformation")]
        Task<ApiResponse<List<RetrunFeedbacksInformation>>> GetMyFeedbackRequests();

        [Delete("/Employee/Feedbacks/Remove")]
        Task<ApiResponse<RemoveMyFeedbackResponse>> RemoveMyFeedbackRequest([Body] RemoveMyFeedbackRequest model);

        [Post("/Employee/LeaveRequest/Add")]
        Task<ApiResponse<CreateANewLeaveRequest_Response_>> RequestANewLeaveRequestRequest([Body] CreateANewLeaveRequest_Request model);

        [Get("/Employee/LeaveRequest/Get")]
        Task<ApiResponse<List<ReturnLeaveRequestsInformation>>> GetMyLeaveRequestsRequests();

        [Delete("/Employee/LeaveRequest/Remove")]
        Task<ApiResponse<RemoveMyLeaveResponse>> RemoveMyLeaveRequest([Body] RemoveMyLeaveRequest model);

        [Post("/Employee/LeaveRequest/AddFinalAnswer")]
        Task<ApiResponse<AgreeOnLeaveRequestDecisionResponse>> AgreeonLeaveRequestRequest([Body] AgreeOnLeaveRequestDecisionRequest model);

        [Get("/Employee/PerformanceRecords/Get")]
        Task<ApiResponse<List<ReturnPerformanceRecordsEmployeeResponse>>> GetMyPerformanceRecords([Body] ReturnPerformanceRecordsListRequest model);
    }

    public class ReturnPerformanceRecordsListRequest
    {
        public int Month { get; set; }
    }
    public class ReturnPerformanceRecordsEmployeeResponse
    {
        public int PerformanceRating { get; set; }
        public string? ReviewerComment { get; set; }
        public DateOnly CreatedAt { get; set; }
        public string Reviewer { get; set; }

        public string PerformanceRatingLabel
        {
        get
            {
            if(PerformanceRating ==1)
                    return "Excellent";
                else if (PerformanceRating == -1)
                    return "Bad";
                else
                    return "Default";
            }
        }
    }
       
    public class AgreeOnLeaveRequestDecisionRequest
    {
        public Guid LeaveRequestID { get; set; }
        public bool Agreed { get; set; }
    }

    public class AgreeOnLeaveRequestDecisionResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }
    }



    public class RemoveMyLeaveRequest
    {
        public Guid LeaveRequestID { get; set; }
    }

    public class RemoveMyLeaveResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }
    }
    public class ReturnLeaveRequestsInformation
    {
        public Guid LeaveRequestId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public string Reason { get; set; }
        public string DepartmentManagerComment { get; set; }
        public string FinalStatusComment { get; set; }

        public string RequesterStatus { get; set; } = "Waiting";
        public string DMStatus { get; set; } = "Waiting";
        public string FinalStatus { get; set; } = "Waiting";


        public DateTime SentAt { get; set; }
        public DateTime? DMAnsweredAt { get; set; }
        public DateTime? HRMAnsweredAt { get; set; }
        public DateTime? CompletedAt { get; set; }

        public string SentAtLocal => SentAt.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
        public string DMAnsweredAtLocal => DMAnsweredAt.HasValue ? DMAnsweredAt.Value.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss") : "**No Answer yet**";
        public string HRMAnsweredAtLocal => HRMAnsweredAt.HasValue ? HRMAnsweredAt.Value.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss") : "**No Answer yet**";
        public string CompletedAtLocal => CompletedAt.HasValue ? CompletedAt.Value.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss") : "**No Answer yet**";

        public bool? HasSanctions { get; set; }
        public bool? AgreedOn { get; set; }
        public bool? Completed { get; set; } = false;
        public string CompletedDashboard => Completed==true ? "Yes" : "No";

        public string DMName { get; set; }
        public string HRMName { get; set; }
    }

    public class CreateANewLeaveRequest_Request
    {
        public string FromDATE { get; set; }
        public string ToDATE { get; set; }
        public string Reason { get; set; }
    }

    public class CreateANewLeaveRequest_Response_
    {
        public string? Message { get; set; } = null;
        public string? Errors { get; set; } = null;
    }

    public class RemoveMyFeedbackRequest
    {
        public Guid? FeedbackID { get; set; }
    }
    public class RemoveMyFeedbackResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }
    }
    public class RetrunFeedbacksInformation
    {
        public Guid FeedbackId { get; set; }
        public string FeedbackType { get; set; }
        public string FeedbackTitle { get; set; }
        public string FeedbackDescription { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string FeedbackAnswer { get; set; }
        public DateTime? AnsweredIn { get; set; }
        public string AnsweredBy { get; set; }

        public string CreatedAtLocal => CreatedAt.HasValue ? CreatedAt.Value.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss") : "**No Answer yet**";




        public string AnsweredInLocal =>
   AnsweredIn.HasValue
       ? AnsweredIn.Value.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")
       : "**No Answer yet**";
    }

    public class CreateANewFeedbackRequest_Request
    {
        public string FeedbackTitle { get; set; }

        public string FeedbackDescription { get; set; }

        public Guid FeedbackType { get; set; }
    }

    public class CreateANewFeedbackRequest_Response
    {
        public string? Message { get; set; } = null;
        public string? Errors { get; set; } = null;
    }
}
