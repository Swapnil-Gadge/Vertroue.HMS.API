using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vertroue.HMS.API.Domain.Entities
{
    [Table("User_Master")]
    public class UserMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int User_Login_id { get; set; }

        public int? Corporate_Id { get; set; }
        public int? User_Type_id { get; set; }
        public int? User_Role_id { get; set; }

        [StringLength(200)]
        public string UserName { get; set; }

        [StringLength(1000)]
        public string UserPassword { get; set; }

        [StringLength(1)]
        public string PasswordExpire_flag { get; set; }

        public DateTime? Last_change_Pass_Date { get; set; }

        [StringLength(200)]
        public string User_SessionId { get; set; }

        public DateTime? Created_date { get; set; }
        public int? Created_By { get; set; }
        public DateTime? Modifed_date { get; set; }
        public int? Modifed_By { get; set; }

        // Navigation properties
        [ForeignKey("Corporate_Id")]
        public CorporateMaster Corporate { get; set; }

        [ForeignKey("User_Role_id")]
        public UserRoleMaster UserRole { get; set; }

        [ForeignKey("User_Type_id")]
        public UserTypeMaster UserType { get; set; }
    }
}
