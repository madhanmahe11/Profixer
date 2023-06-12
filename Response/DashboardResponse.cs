namespace Profixer.Response.Dashboard
{
    public class DashboardResponse
    {
        public List<RtnData> RtnData { get; set; }
    }
    public class RtnData
    {
        public int SubMenuID { get; set; }
        public string SubMenu { get; set; }
        public string Controller { get; set; }
        public string ActionName { get; set; }
        public int MainMenuID { get; set; }
        public string MainMenu { get; set; }
        public int MenuOrder { get; set; }
        public int SubMenuOrder { get; set; }
        public bool IsActive { get; set; }
        public string FaIcons { get; set; }
        public string Icon { get; set; }
    }
}