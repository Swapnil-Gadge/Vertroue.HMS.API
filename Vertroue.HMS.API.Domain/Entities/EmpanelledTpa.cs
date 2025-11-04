namespace Vertroue.HMS.API.Domain.Entities;

public partial class EmpanelledTpa
{
    public int EmpanelledTpaId { get; set; }

    public int? Tpaid { get; set; }

    public string Portal { get; set; } = null!;

    public DateTime? EmpanelledDate { get; set; }

    public string? UserName { get; set; }

    public string? PassWord { get; set; }

    public int? HospitalId { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual Hospital? Hospital { get; set; }

    public virtual Tpa? Tpa { get; set; }

    public virtual ICollection<Mou> Mous { get; } = new List<Mou>();

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();
}
