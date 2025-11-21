namespace Vertroue.HMS.API.Application.Shared
{
    public static class Constant
    {
        public const string RenewalDocsContainer = "renewaldocs";
        public const string MouDocsContainer = "mous";
        public const string PatientDocsContainer = "patientdocs";
        public const string VertroueEmailID = "SupportTeamEmails"; //"info@vertroue.com";
        public const string ClaimManagementEmail = "EmailSender";
        public const string AppLink = "AppLink";
        public const string EmailAPIKey = "EmailAPIKey";

        public static class UserRoles
        {
            public static string Admin = "Admin";
            public static string Executive = "Executive";
            public static string ProviderAdmin = "Provider Admin";
            public static string ProviderExecutive = "Provider Executive";
        }

        public static class ClaimFlowTypes 
        {
            public const string CLAIM = "Claim";
            public const string TREATMENT = "Treatment";
            public const string ENHANCEMENT = "Enhancement";
            public const string HOSPITAL_RESPONSE = "HospitalResponse";
            public const string TPA_RESPONSE = "TPAResponse";
            public const string REQUESTED_FINAL_APPROVAL = "RequestedFinalApproval";
            public const string FILE_FLOW = "FileSent";
            public const string ACKNOWLEDGEMENT_RECEIVED = "AcknowledgementReceived";
            public const string FINAL_SETTLEMENT = "FinalSettlement";
            public const string CLOSED_CLAIM = "ClosedClaim"; 
        }

        public static class ClaimStatuses
        {
            public const string DRAFT = "Draft";
            public const string CLAIM_SUBMITTED = "Claim Submitted";
            public const string QUERIED = "Queried";
            public const string QUERY_ANSWERED = "Query Answered";
            public const string PRE_AUTH_APPROVED = "Pre-Auth Approved";
            public const string AWAITING_FINAL_APPROVAL = "Awaiting Final Approval";
            public const string ENHANCED_CLAIM_SUBMITTED = "Enhanced Claim Submitted";
            public const string PARTIALLY_APPROVED = "Partially Approved";
            public const string APPROVED = "Approved";
            public const string FILE_SENT = "File Sent";
            public const string ACKNOWLEDGEMENT_RECEIVED = "Acknowledgement Received";
            public const string DENIED = "Denied";
            public const string WITH_EXPERTS = "With Experts";
            public const string SETTLED = "Settled";
            public const string CLOSED = "Closed";
        }   
    }
}
