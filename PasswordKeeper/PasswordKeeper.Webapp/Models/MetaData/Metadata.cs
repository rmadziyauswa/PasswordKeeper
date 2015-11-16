using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PasswordKeeper.Webapp.Models.MetaData
{
    public class HostTypeMetadata
    {
        [Required]
        [Display(Name="Host Type")]
        [MaxLength(15, ErrorMessage = "Cannot Be More than 15 characters long")]
        public string Name;
    }

    public class HostMetadata
    {
        [Required]
        [Display(Name ="Host")]
        [MaxLength(15,ErrorMessage ="Cannot Be More than 15 characters long")]
        public string Name;
        [Display(Name ="Host Type")]
        public int HostTypeID;
    }

    public class CredentialTypeMetadata
    {
        [Required]
        [Display(Name ="Credential Type")]
        [MaxLength(20,ErrorMessage ="Cannot Be more than 20 characters")]
        public string Name;
    }


    public class CredentialMetadata
    {
        [Display(Name ="Credential Type")]
        public int CredentialTypeID { get; set; }
        [Display(Name ="Host")]
        public int HostID { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(20, ErrorMessage = "Cannot Be more than 20 characters")]
        public string Password { get; set; }
        [Required]
        [Display(Name ="Credential Name")]
        [MaxLength(20, ErrorMessage = "Cannot Be more than 20 characters")]
        public string Name { get; set; }
    }
}