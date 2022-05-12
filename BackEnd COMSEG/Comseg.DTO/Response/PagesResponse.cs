
namespace Comseg.DTO.Response
{
    public class PagesResponse
    {
       public List<MenuResponse>? MenuResponse { get; set; }
       public List<SubMenuResponse>? SubMenuResponse { get; set; }
    }

    public class MenuResponse
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
    }

    public class SubMenuResponse
    {
        public int MenuId { get; set; }
        public string SubMenuName { get; set; }
        public string SubMenuPage { get; set; }
        public bool SubMenuStatus { get; set; }
    }
}
