using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TarkovStats.Models;

public class Raid
{
    [Key] 
    public int Id { get; set; }
    public string UserId { get; set; }

    public DateTime EnteredAt { get; set; }
    public int MinLength { get; set; }
    public Map Map { get; set; }
    public RaidResult RaidResult { get; set; }
    public uint ScavKills { get; set; }
    public uint PmcKills { get; set; }
    public uint TotalEXP { get; set; }
    
    [ForeignKey(nameof(UserId))]
    public IdentityUser IdentityUser { get; set; }
}