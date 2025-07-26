namespace Vertroue.HMS.API.Application.Features.QMS.QMSControl.Model
{
    public class QMSInsurerDto
    {
        public int InsurerId { get; set; }
        public string InsurerName { get; set; }
    }

    public class QMSTPADto
    {
        public int TPAId { get; set; }
        public string TPAName { get; set; }
    }

    public class QMSRelationDto
    {
        public int RelationId { get; set; }
        public string RelationName { get; set; }
    }

    public class QMSGenderDto
    {
        public int GenderId { get; set; }
        public string GenderName { get; set; }
    }

    public class QMSIdentificationTypeDto
    {
        public int IdentificationTypeId { get; set; }
        public string IdentificationTypeName { get; set; }
    }

    public class QMSAdmissionTypeDto
    {
        public int AdmissionTypeId { get; set; }
        public string AdmissionTypeName { get; set; }
    }

    public class QMSStatusControlDto
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }
    }

    public class QMSCaseTypeControlDto
    {
        public string CaseTypeCode { get; set; }
        public string CaseTypeName { get; set; }
    }

    public class QMSPatientDto
    {
        public int CaseId { get; set; }
        public string PatientName { get; set; }
        public string PatientMobileNo { get; set; }
        public string PatientEmailId { get; set; }
        public string PatientGender { get; set; }
        public string RelationName { get; set; }
        public string StatusName { get; set; }
        public int StatusId { get; set; }
        public int CaseDetailsId { get; set; }
    }

    public class QMSDynamicDataDto
    {
        public int TblId { get; set; }
        public int CaseId { get; set; }
        public string ColumnName { get; set; }
        public string ColumnDetails { get; set; }
        public string ColumnName1 { get; set; }
        public string ColumnDetails1 { get; set; }
    }

}
