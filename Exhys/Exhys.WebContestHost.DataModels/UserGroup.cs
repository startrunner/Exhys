
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Exhys.WebContestHost.DataModels
{

using System;
    using System.Collections.Generic;
    
public partial class UserGroup
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public UserGroup()
    {

        this.GroupMembers = new HashSet<UserAccount>();

        this.AvaiableCompetitions = new HashSet<Competition>();

    }


    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public bool IsOpen { get; set; }

    public bool IsAdministrator { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<UserAccount> GroupMembers { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Competition> AvaiableCompetitions { get; set; }

}

}