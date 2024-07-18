using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teledoc.DAL.Models;

public class Client
{
    [Key] public int Id { get; set; }

    public int ClientTypeId { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime? AddAt { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime? UpdateAt { get; set; }

    [ForeignKey("ClientTypeId")] public ClientType? Type { get; set; }

    public virtual IEnumerable<Founder>? Founders { get; set; } = null!;
}