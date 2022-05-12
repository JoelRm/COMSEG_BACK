namespace Comseg.Entities;

public class EntityBase
{
    public string CreationUser { get; set; }
    public DateTime CreationDate { get; set; }
    public string? ModificationUser { get; set; }
    public DateTime? ModificationDate { get; set; }
}

