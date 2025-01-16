using EntityModels.Models.Base;

namespace EntityModels.Models;

public class Role : AuditableBaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<User> Users { get; set; }
}
