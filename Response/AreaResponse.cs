namespace Profixer.Response.Area
{
    public class Area
    {
        public List<RtnData> RtnData { get; set; }
    }
    public class RtnData
    {
        public int AreaID { get; set; }
        public string AreaName { get; set; }
        public string pincode { get; set; }
        public int CityID { get; set; }
        public string CityName { get; set; }
        public bool IsActive { get; set; }
    }
}