namespace Vertroue.HMS.API.Application.Features.MasterData.DocumentType.Model
{
    public class DocumentTypeDto
    {
        public int DocumentTypeId { get; set; }
        public string DocumentTypeName { get; set; }
        public string DocumentDesc { get; set; }
        public string DocumentOwner { get; set; }
        public string ActiveFlag { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
