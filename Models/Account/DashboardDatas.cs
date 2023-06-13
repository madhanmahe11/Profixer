using Profixer.Response;
using Profixer.Response.Dashboard;
using Profixer.Response.TicketCount;

namespace Profixer.Models
{
    public class DashboardDatas
    {
        public DashboardResponse DashboardResponse { get; set; }
        public LoginResponse LoginResponse { get; set; }
        public TicketCountResponse TicketCountResponse { get; set; }
    }
}