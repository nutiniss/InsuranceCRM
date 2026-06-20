namespace Firma.Intranet.Models;

public class AdminReportViewModel
{
    public IReadOnlyList<AgentPolicySalesRow> PolicySalesByAgent { get; set; } = [];
    public int TotalPoliciesSold { get; set; }
}

public class AgentPolicySalesRow
{
    public required string AgentName { get; set; }
    public required string Role { get; set; }
    public int PoliciesSold { get; set; }
    public decimal PremiumTotal { get; set; }
}
