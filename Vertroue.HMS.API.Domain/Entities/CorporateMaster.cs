using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vertroue.HMS.API.Domain.Entities
{
    [Table("Corporate_Master")]
    public class CorporateMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Corporate_Id { get; set; }

        public int? Parent_Corporate_Id { get; set; }

        [StringLength(200)]
        public string Corporate_Name { get; set; }

        [StringLength(500)]
        public string Corporate_Type { get; set; }

        [StringLength(500)]
        public string Corporate_Address { get; set; }

        public int? City_id { get; set; }    // FK to City_Master
        public int? State_Id { get; set; }   // FK to State_Master

        [StringLength(10)]
        public string Corporate_Pincode { get; set; }

        [StringLength(200)]
        public string Corporate_CotactNo { get; set; }

        [StringLength(15)]
        public string Corporate_Zone { get; set; }

        [StringLength(200)]
        public string Corporate_WebSite { get; set; }

        [StringLength(200)]
        public string Corporate_Email { get; set; }

        public bool? Active_Flag { get; set; }
        public DateTime? Created_date { get; set; }
        public int? Created_By { get; set; }
        public DateTime? Modifed_date { get; set; }
        public int? Modifed_By { get; set; }

        // Navigation property for Users
        public ICollection<UserMaster> Users { get; set; }
    }
}