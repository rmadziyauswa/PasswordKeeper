using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using PasswordKeeper.Webapp.Models.MetaData;

namespace PasswordKeeper.Webapp.Models.EntityModel
{
    [MetadataType(typeof(HostTypeMetadata))]
    public partial class HostType
    {
    }

    [MetadataType(typeof(HostMetadata))]
    public partial class Host
    {
    }
    [MetadataType(typeof(CredentialTypeMetadata))]
    public partial class CredentialType
    {

    }

    [MetadataType(typeof(CredentialMetadata))]
    public partial class Credential
    {
    }
}