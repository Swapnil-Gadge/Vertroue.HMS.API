using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.Dashboards.Models;
using Vertroue.HMS.API.Application.Shared;
using Vertroue.HMS.API.Domain.Entities;

namespace Vertroue.HMS.API.Persistence.Repositories
{
    public class DashBoardRepository : IDashBoardRepository
    {
        private readonly ApiDbContext _context;

        public DashBoardRepository(ApiDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<(List<CaseCounts>, List<TatReportCase>, List<Denial>, List<Defficiency>, List<string?>, List<string?>)> GetProviderAdminDashboardData(int hospitalId)
        {
            var caseCounts = new List<CaseCounts>();
            var tatReportCases = new List<TatReportCase>();
            var denials = new List<Denial>(); // TPA Query Codes
            var defficiencies = new List<Defficiency>(); // Can be ICD 11 codes
            var tatReport = new List<string?>();
            var totalCaseBiFurications = new List<string?>();

            Expression<Func<Patient, bool>> hospitalExpression = h => true;
            if (hospitalId > 0)
            {
                hospitalExpression = h => h.HospitalId == hospitalId;
            }

            var claims = await _context.Patients
                        .Where(hospitalExpression)
                        .Include(p => p.ClaimFlows) // Only latest
                        .AsNoTracking()
                        .ToListAsync();

            var casecount = new CaseCounts
            {
                ApprovedCaseAmount = 0,
                ApprovedCaseCount = 0,
                ApprovedCasePercent = 0,
                ClosedCaseAmount = 0,
                ClosedCaseCount = 0,
                ClosedCasePercent = 0,
                DeniedCaseAmount = 0,
                DeniedCaseCount = 0,
                DeniedCasePercent = 0,
                LiveCaseAmount = 0,
                LiveCaseCount = 0,
                LiveCasePercent = 0,
                PayPendingCaseAmount = 0,
                PayPendingCaseCount = 0,
                PayPendingCasePercent = 0,
                PaidCaseAmount = 0,
                PaidCaseCount = 0,
                PaidCasePercent = 0,
                FileSentCaseAmount = 0,
                FileSentCaseCount = 0,
                FileSentCasePercent = 0,
                QuerryCaseAmount = 0,
                QuerryCaseCount = 0,
                QuerryCasePercent = 0,
                TotalCaseAmount = 0,
                TotalCaseCount = 0,
                TotalCasePercent = 0
            };
            foreach (var claim in claims)
            {
                var latestClaimFlow = claim.ClaimFlows.OrderByDescending(c => c.ClaimFlowId).FirstOrDefault();
                var allClaimsFlows = claim.ClaimFlows;
                decimal totalClaimAmount = 0;

                if (latestClaimFlow != null)
                    totalClaimAmount += allClaimsFlows.Sum(c => c.EstimatedAmount ?? 0) + allClaimsFlows.Sum(c => c.TreatmentPatientPayableAmount ?? 0);
                else
                    totalClaimAmount += claim.TotalExpectedCost ?? 0;

                if (claim.ClaimStatus == Constant.ClaimStatuses.DRAFT 
                    || claim.ClaimStatus == Constant.ClaimStatuses.CLAIM_SUBMITTED
                    || claim.ClaimStatus == Constant.ClaimStatuses.ENHANCED_CLAIM_SUBMITTED)
                {
                    casecount.LiveCaseCount++;
                    casecount.LiveCaseAmount += totalClaimAmount;
                }                    

                if (claim.ClaimStatus == Constant.ClaimStatuses.QUERIED 
                    || claim.ClaimStatus == Constant.ClaimStatuses.QUERY_ANSWERED 
                    || claim.ClaimStatus == Constant.ClaimStatuses.AWAITING_FINAL_APPROVAL)
                {
                    casecount.QuerryCaseCount++;

                    // TODO: needs to check how to calculate queried amount
                    var claimflow = allClaimsFlows
                        .Where(c => (c.Stage == Constant.ClaimFlowTypes.TPA_RESPONSE && c.ApprovedAmount.HasValue && c.ApprovedAmount.Value > 0)
                        || c.Stage == Constant.ClaimFlowTypes.TREATMENT || c.Stage == Constant.ClaimFlowTypes.ENHANCEMENT)
                        .OrderByDescending(c => c.ClaimFlowId)
                        .FirstOrDefault();

                    if (claimflow == null)
                        casecount.QuerryCaseAmount += claim.TotalExpectedCost ?? 0;
                    else
                        casecount.QuerryCaseAmount += (claimflow.ApprovedAmount ?? 0) + (claimflow.ClaimPatientPayableAmount ?? 0)
                            + (claimflow.EstimatedAmount ?? 0) + (claimflow.TreatmentPatientPayableAmount ?? 0);
                }                    

                if (claim.ClaimStatus == Constant.ClaimStatuses.DENIED)
                {
                    casecount.DeniedCaseCount++;
                    var claimflow = allClaimsFlows
                       .Where(c => (c.Stage == Constant.ClaimFlowTypes.TPA_RESPONSE && c.ApprovedAmount.HasValue && c.ApprovedAmount.Value > 0)
                       || c.Stage == Constant.ClaimFlowTypes.TREATMENT || c.Stage == Constant.ClaimFlowTypes.ENHANCEMENT)
                       .OrderByDescending(c => c.ClaimFlowId)
                       .FirstOrDefault();

                    if (claimflow == null)
                        casecount.DeniedCaseAmount += claim.TotalExpectedCost ?? 0;
                    else
                        casecount.DeniedCaseAmount += (claimflow.ApprovedAmount ?? 0) + (claimflow.ClaimPatientPayableAmount ?? 0)
                            + (claimflow.EstimatedAmount ?? 0) + (claimflow.TreatmentPatientPayableAmount ?? 0);
                }                    

                if (claim.ClaimStatus == Constant.ClaimStatuses.CLOSED)
                {
                    casecount.ClosedCaseCount++;
                    var closedClaimrec = allClaimsFlows
                        .Where(c => c.Stage == Constant.ClaimFlowTypes.CLOSED_CLAIM)
                        .OrderByDescending(c => c.ClaimFlowId)
                        .FirstOrDefault();

                    if (closedClaimrec != null)
                        casecount.ClosedCaseAmount += closedClaimrec.ClaimPatientPayableAmount ?? 0;
                    else
                        casecount.ClosedCaseAmount += claim.TotalExpectedCost ?? 0;
                }             

                if (claim.ClaimStatus == Constant.ClaimStatuses.APPROVED ||
                    claim.ClaimStatus == Constant.ClaimStatuses.PRE_AUTH_APPROVED ||
                    claim.ClaimStatus == Constant.ClaimStatuses.PARTIALLY_APPROVED)
                {
                    casecount.ApprovedCaseCount++;
                    if (latestClaimFlow != null)
                        casecount.ApprovedCaseAmount += allClaimsFlows.Sum(c => c.ApprovedAmount ?? 0) + allClaimsFlows.Sum(c => c.ClaimPatientPayableAmount ?? 0);
                    else
                        casecount.ApprovedCaseAmount += claim.TotalExpectedCost ?? 0;
                }
                    
                if (claim.ClaimStatus == Constant.ClaimStatuses.SETTLED)
                {
                    casecount.PaidCaseCount++;
                    if (latestClaimFlow != null)
                        casecount.PaidCaseAmount += allClaimsFlows.Sum(c => c.FinalSettlementAmount ?? 0) + allClaimsFlows.Sum(c => c.ClaimPatientPayableAmount ?? 0);
                    else
                        casecount.PaidCaseAmount += claim.TotalExpectedCost ?? 0;
                }                    

                if (claim.ClaimStatus == Constant.ClaimStatuses.ACKNOWLEDGEMENT_RECEIVED)
                {
                    casecount.PayPendingCaseCount++;
                    if (latestClaimFlow != null)
                        casecount.PayPendingCaseAmount += allClaimsFlows.Sum(c => c.ApprovedAmount ?? 0) + allClaimsFlows.Sum(c => c.ClaimPatientPayableAmount ?? 0);
                    else
                        casecount.PayPendingCaseAmount += claim.TotalExpectedCost ?? 0;
                }                    

                if (claim.ClaimStatus == Constant.ClaimStatuses.FILE_SENT)
                {
                    casecount.FileSentCaseCount++;
                    if (latestClaimFlow != null)
                        casecount.FileSentCaseAmount += allClaimsFlows.Sum(c => c.ApprovedAmount ?? 0) + allClaimsFlows.Sum(c => c.ClaimPatientPayableAmount ?? 0);
                    else
                        casecount.FileSentCaseAmount += claim.TotalExpectedCost ?? 0;
                }                    
            }
            casecount.TotalCaseCount = claims.Count;
            casecount.TotalCaseAmount = casecount.PaidCaseAmount + casecount.ApprovedCaseAmount + casecount.ClosedCaseAmount
                + casecount.DeniedCaseAmount + casecount.FileSentCaseAmount + casecount.LiveCaseAmount
                + casecount.PayPendingCaseAmount + casecount.QuerryCaseAmount;

            casecount.LiveCasePercent = CalculatePercent(casecount.LiveCaseCount, casecount.TotalCaseCount);
            casecount.ApprovedCasePercent = CalculatePercent(casecount.ApprovedCaseCount, casecount.TotalCaseCount);
            casecount.QuerryCasePercent = CalculatePercent(casecount.QuerryCaseCount, casecount.TotalCaseCount);
            casecount.DeniedCasePercent = CalculatePercent(casecount.DeniedCaseCount, casecount.TotalCaseCount);
            casecount.PaidCasePercent = CalculatePercent(casecount.PaidCaseCount, casecount.TotalCaseCount);
            casecount.PayPendingCasePercent = CalculatePercent(casecount.PayPendingCaseCount, casecount.TotalCaseCount);
            casecount.FileSentCasePercent = CalculatePercent(casecount.FileSentCaseCount, casecount.TotalCaseCount);
            casecount.ClosedCasePercent = CalculatePercent(casecount.ClosedCaseCount, casecount.TotalCaseCount);

            caseCounts.Add(casecount);

            totalCaseBiFurications.Add("\"Live case Count\",\"Approved case Count\",\"Queried case Count\",\"Denied case Count\",\"Closed case Count\",\"Paid case Count\",\"PayPending case Count\",\"File-Sent case Count\"");
            totalCaseBiFurications.Add($"{casecount.LiveCaseCount}, {casecount.ApprovedCaseCount}, {casecount.QuerryCaseCount}, {casecount.DeniedCaseCount}, {casecount.ClosedCaseCount}, {casecount.PaidCaseCount}, {casecount.PayPendingCaseCount}, {casecount.FileSentCaseCount}");

            var querycodes = claims
                .SelectMany(c => c.ClaimFlows)
                .Where(cf => cf.Stage == Constant.ClaimFlowTypes.TPA_RESPONSE && !string.IsNullOrEmpty(cf.QueryCode))
                .GroupBy(cf => new { cf.QueryCode })
                .Select(g => new Denial
                {
                    Name = g.Key.QueryCode,
                    Count = g.Count(),
                    TPACode = g.Key.QueryCode
                })
                .OrderByDescending(d => d.Count)
                .Take(10)
                .ToList();
            denials.AddRange(querycodes);

            var defficiencycodes = claims
                .GroupBy(c => new { c.Icd11Code })
                .Select(g => new Defficiency
                {
                    Name = g.Key.Icd11Code,
                    Count = g.Count(),
                    TPACode = g.Key.Icd11Code
                })
                .OrderByDescending(d => d.Count)
                .Take(10)
                .ToList();
            defficiencies.AddRange(defficiencycodes);

            var submittedClaims = claims
                .Where(c => c.ClaimStatus == Constant.ClaimStatuses.CLAIM_SUBMITTED 
                || c.ClaimStatus == Constant.ClaimStatuses.ENHANCED_CLAIM_SUBMITTED
                || c.ClaimStatus == Constant.ClaimStatuses.QUERY_ANSWERED
                || c.ClaimStatus == Constant.ClaimStatuses.AWAITING_FINAL_APPROVAL)
                .OrderBy(c => c.SubmitedDate)
                .ToList();

            var labels = new[] { "0-1 hrs", "1-2 hrs", "2-3 hrs", "3-4 hrs", "4-5 hrs", "5-6 hrs", ">6 hrs" };
            var tatValues = GetTATValues(submittedClaims);
            tatReport.Add(string.Join(",", labels));
            tatReport.Add(tatValues);

            tatReport.Reverse();
            totalCaseBiFurications.Reverse();
            return (caseCounts, tatReportCases, denials, defficiencies, tatReport, totalCaseBiFurications);
        }

        private static decimal CalculatePercent(int? count, int? total)
        {
            return total > 0 ? (decimal)count * 100 / (total.HasValue ? total.Value : 0) : 0;
        }

        private string GetTATValues(List<Patient> claims)
        {
            var now = DateTime.Now;
            var ranges = new (double Min, double Max)[]
            {
                (0.0, 1.0),
                (1.0, 2.0),
                (2.0, 3.0),
                (3.0, 4.0),
                (4.0, 5.0),
                (5.0, 6.0),
                (6.0, double.MaxValue)
             };

            var values = ranges
                .Select(r =>
                    claims.Count(c =>
                    {
                        var ageHours = (now - c.SubmitedDate.Value).TotalHours;
                        return ageHours >= r.Min && ageHours < r.Max;
                    })
                )
                .ToArray();
            return string.Join(",", values);
        }
    }
}
