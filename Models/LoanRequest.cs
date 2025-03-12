namespace VendorWebApiIntegration.Models;

public class LoanRequest
{
    public Loan Loan { get; set; }
}

public class Loan
{
    public string sLNm { get; set; }
    public int sTerm { get; set; }
    public string sNoteIR { get; set; }
    public string sSchedDueD1 { get; set; }
    public string sSchedDueD1Lckd { get; set; }
    public string sAggregateAdjRsrvLckd { get; set; }
    public string sAppSubmittedDLckd { get; set; }
    public int sFinMethT { get; set; }
    public int sLT { get; set; }
    public int sBuydownContributorT { get; set; }
    public int sGseRefPurposeT { get; set; }
    public List<Consumer> Consumers { get; set; }
}