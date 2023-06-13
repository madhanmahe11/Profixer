namespace Profixer.Response
{
    public class LoginResponse
    {
        public bool RtnStatus { get; set; }
        public RtnData RtnData { get; set; }
    }
    public class RtnData
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string MobileNo { get; set; }
        public string RoleName { get; set; }
        public string ImagePath { get; set; }
    }
}