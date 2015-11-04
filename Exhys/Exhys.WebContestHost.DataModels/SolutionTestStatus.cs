
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
    
public partial class SolutionTestStatus
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public SolutionTestStatus()
    {

        this.InputFeedbackEnabled = true;

        this.OutputFeedbackEnabled = true;

        this.SolutionFeedbackEnabled = true;

        this.ScoreFeedbackEnabled = true;

        this.StatusFeedbackEnabled = true;

    }


    public int Id { get; set; }

    public string Input { get; set; }

    public string Output { get; set; }

    public string Solution { get; set; }

    public double Score { get; set; }

    public byte StatusCode { get; set; }

    public bool InputFeedbackEnabled { get; set; }

    public bool OutputFeedbackEnabled { get; set; }

    public bool SolutionFeedbackEnabled { get; set; }

    public bool ScoreFeedbackEnabled { get; set; }

    public bool StatusFeedbackEnabled { get; set; }

}

}