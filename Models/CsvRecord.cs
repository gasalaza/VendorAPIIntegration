using CsvHelper.Configuration.Attributes;

namespace VendorWebApiIntegration.Models;

public class CsvRecord
{
    [Name("sLNm")]
    public string LoanName { get; set; }

    [Name("sTerm")]
    public string Term { get; set; }

    [Name("sNoteIR")]
    public string NoteIR { get; set; }

    [Name("sSchedDueD1")]
    public string sSchedDueD1 { get; set; }

    [Name("sAggregateAdjRsrv")]
    public string sAggregateAdjRsrv { get; set; }

    [Name("sAppSubmittedD")]
    public string sAppSubmittedD { get; set; }

    [Name("sFinMethT")]
    public string sFinMethT { get; set; }

    [Name("sLT")]
    public string sLT { get; set; }

    [Name("sGseRefPurposeT")]
    public string sGseRefPurposeT { get; set; }

    [Ignore]
    public string[] HeaderRecord { get; set; }
    
    [Ignore]
    public string[] Row { get; set; }
}