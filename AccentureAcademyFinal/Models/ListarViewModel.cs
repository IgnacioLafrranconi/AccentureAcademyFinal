using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccentureAcademyFinal.Models
{
    public class ListarViewModel
    {
            public string FilterTitle { get; set; }
            public int? FilterGenre { get; set; }
            public string FilterAuhtor { get; set; }
            public string FilterPublisher { get; set; }
    }
}