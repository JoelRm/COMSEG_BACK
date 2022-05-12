using System.ComponentModel.DataAnnotations;


namespace Comseg.DTO.Request
{
    public class DtoUnit
    {
        public string UnitCode { get; set; }
        public string UnitName { get; set; }
        public string Abbreviation { get; set; }
        public int Factor { get; set; }
        public bool UnitStatus { get; set; }
    }
}
