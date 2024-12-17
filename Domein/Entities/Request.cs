using Domein.Enums;

namespace Domein.Entities;

public class Request
{
    public int RequestId { get; set; }
    public int FromUserId { get; set; }
    public int ToUserId { get; set; }
    public int RequestSkillId { get; set; }
    public int OfferedSkillId { get; set; }
    public Status Status { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}