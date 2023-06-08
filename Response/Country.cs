namespace Profixer.Response.Country
{
    public class Country
    {
        public List<RtnData> RtnData { get; set; }
    }
    public class RtnData
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public bool IsActive { get; set; }
    }
}