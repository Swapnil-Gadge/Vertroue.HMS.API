namespace Vertroue.HMS.API.Application.Models.Patient
{
    public class PatientDocDto
    {
        public int PatientDocId { get; set; }

        public int? PatientId { get; set; }

        public int Id { get; set; }

        public string? DocumentType { get; set; }

        public string? FileName { get; set; }

        public string? FileUrl { get; set; }

        public int UploadProgress { get; set; } = 100;

        public string UploadStatus { get; set; } = "uploaded";
    }
}
