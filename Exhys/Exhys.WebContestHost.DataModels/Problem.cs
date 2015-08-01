
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
    
public partial class Problem
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Problem()
    {

        this.IgnoreTestBlankSpaces = true;

        this.RequiresChecker = false;

        this.ProblemSolutions = new HashSet<ProblemSolution>();

        this.ProblemStatements = new HashSet<ProblemStatement>();

        this.ProblemTests = new HashSet<ProblemTest>();

    }


    public int Id { get; set; }

    public string Name { get; set; }

    public bool IgnoreTestBlankSpaces { get; set; }

    public int DummyTestCount { get; set; }

    public double PointsPerTest { get; set; }

    public bool RequiresChecker { get; set; }



    public virtual Competition CompetitionGivenAt { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<ProblemSolution> ProblemSolutions { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<ProblemStatement> ProblemStatements { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<ProblemTest> ProblemTests { get; set; }

}

}