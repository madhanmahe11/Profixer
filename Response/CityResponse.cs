namespace Profixer.Response
{
    public class ReturnResponse
    {
        public List<RtnData> RtnData { get; set; }
    }

    public class RtnData
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public bool IsActive { get; set; }
        public int CountryID { get; set; }
        public string CountryName { get; set; }
    }
}