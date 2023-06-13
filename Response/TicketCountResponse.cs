namespace Profixer.Response.TicketCount
{
    public class TicketCountResponse
    {
        public List<RtnData> RtnData { get; set; }
    }
    public class RtnData
    {
        public int TicketStatusID { get; set; }
        public string StatusName { get; set; }
        public string StatusImage { get; set; }
        public string ColorCode { get; set; }
        public int TicketCount { get; set; }
        public string ColorCode2 { get; set; }
        public int StatusOrder { get; set; }
    }
}