using System;
using System.ComponentModel.DataAnnotations;

namespace LinkShortener.Models;

public class ShortLinks
{
    public int Id { get; set; }
    
    [Required]
    public string OriginalUrl { get; set; }
    /*public string ShortUrl { get; set; }
    public DateTime CreatedAt { get; set; }*/
}