namespace Profixer.Models.Master
{
    public class City
    {
        public int CityID { get; set; }
        public int CUID { get; set; }
        public string CityName { get; set; }
        public bool IsActive { get; set; }
        public int CountryID { get; set; }
        public string CountryName { get; set; }
    }
}