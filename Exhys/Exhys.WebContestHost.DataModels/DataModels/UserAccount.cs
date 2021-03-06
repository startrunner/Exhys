﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exhys.WebContestHost.DataModels
{
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(DatabaseLimits.Username_MaxLength)]
        [MinLength(DatabaseLimits.Username_MinLength)]
        [Required]
        public string Username { get; set; }

        [MaxLength(DatabaseLimits.HumanName_MaxLength)]
        //[MinLength(DatabaseLimits.HumanName_MinLength)]
        public string FullName { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<UserSession> UserSessions { get; set; }

        public virtual ICollection<Participation> Participations { get; set; }

        [Required]
        public virtual UserGroup UserGroup { get; set; }
    }
}

