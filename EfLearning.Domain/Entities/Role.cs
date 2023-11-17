using EfLearning.Domain.Commons;

namespace EfLearning.Domain.Entities;

public class Role : Auditable
{
    public string RoleName { get; set; }
    public string RoleDescription { get; set; }
}
