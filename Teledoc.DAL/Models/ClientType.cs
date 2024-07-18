using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Teledoc.DAL.Models;

[Index(nameof(Name), IsUnique = true)]
public class ClientType
{
    [Key] public int Id { get; set; }
    public string Name { get; set; } = null!;
}