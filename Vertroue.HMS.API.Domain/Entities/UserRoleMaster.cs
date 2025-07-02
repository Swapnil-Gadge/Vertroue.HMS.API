﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vertroue.HMS.API.Domain.Entities
{
    [Table("User_Role_Master")]
    public class UserRoleMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int User_Role_id { get; set; }

        [StringLength(50)]
        public string User_role_Name { get; set; }

        public bool? Active_Flag { get; set; }
        public DateTime? Created_date { get; set; }
        public int? Created_By { get; set; }
        public DateTime? Modifed_date { get; set; }
        public int? Modifed_By { get; set; }

        // Navigation property
        public ICollection<UserMaster> Users { get; set; }
    }
}
