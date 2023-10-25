using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AnimeApp.Data;
using Microsoft.AspNetCore.Identity;

namespace AnimeApp.Models;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; internal set; }
    public string LastName { get; internal set; }
    public string Nickname { get; internal set; }
    public List<Anime> WatchedAnime { get;  } = new();
}

