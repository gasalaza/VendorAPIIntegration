using VendorWebApiIntegration.Interfaces;
using VendorWebApiIntegration.Models;
using System.Collections.Generic;
using System.Linq;

namespace VendorWebApiIntegration.Mappers;

public class LoanRequestMapper : IMapper<CsvRecord, LoanRequest>
{
    public LoanRequest Map(CsvRecord record)
    {
        var consumers = new List<Consumer>();

        var headers = record.HeaderRecord;
        var row = record.Row;

        int consumerIndex = 1;
        while (Array.IndexOf(headers, $"FirstName_{consumerIndex}") >= 0)
        {
            var firstName = GetValue(headers, row, $"FirstName_{consumerIndex}");
            if (string.IsNullOrWhiteSpace(firstName))
                break;

            consumers.Add(new Consumer
            {
                FirstName = firstName,
                LastName = GetValue(headers, row, $"LastName_{consumerIndex}"),
                MiddleName = GetValue(headers, row, $"MiddleName_{consumerIndex}"),
                Ssn = GetValue(headers, row, $"Ssn_{consumerIndex}"),
                HomePhone = GetValue(headers, row, $"HomePhone_{consumerIndex}"),
                CellPhone = GetValue(headers, row, $"CellPhone_{consumerIndex}"),
                Email = GetValue(headers, row, $"Email_{consumerIndex}"),
                DateOfBirth = GetValue(headers, row, $"DateofBirth_{consumerIndex}"),
                DecisionCreditScore = GetValue(headers, row, $"DecisionCreditScore_{consumerIndex}")
            });

            if (string.IsNullOrEmpty(firstName))
                break;

            consumerIndex++;
        }

        return new LoanRequest
        {
            Loan = new Loan
            {
                sLNm = record.LoanName,
                sTerm = int.TryParse(record.Term, out var term) ? term : 0,
                sNoteIR = record.NoteIR,
                sSchedDueD1 = record.sSchedDueD1,
                sSchedDueD1Lckd = !string.IsNullOrEmpty(record.sSchedDueD1) ? "True" : "False",
                sAggregateAdjRsrvLckd = !string.IsNullOrEmpty(record.sAggregateAdjRsrv) ? "True" : "False",
                sAppSubmittedDLckd = !string.IsNullOrEmpty(record.sAppSubmittedD) ? "True" : "False",
                sFinMethT = record.sFinMethT switch
                {
                    "Fixed" or "HELOC" => 0,
                    "Adjustable Rate" or "Step" => 1,
                    _ => 2
                },
                sLT = record.sLT switch
                {
                    "Conventional" => 0,
                    "FHA" => 1,
                    "VA" => 2,
                    "Usda Rural Housing" => 3,
                    _ => 4
                },
                sBuydownContributorT = 0,
                sGseRefPurposeT = 0,
                Consumers = consumers
            }
        };
    }

    private string GetValue(string[] headers, string[] row, string columnName)
    {
        var index = Array.IndexOf(headers, columnName);
        return index >= 0 ? row[index] : null;
    }
}