﻿using EntityModels.Models.Base;

namespace EntityModels.Models;

public class User : AuditableBaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string SaltKey { get; set; }
    public bool IsActive { get; set; }
    public Guid RoleId { get; set; }


    public virtual Role Role { get; set; }
}
