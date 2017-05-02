using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;


namespace OverripeBananas.Models
{
    public class ShowGenreViewModel
    {
        public List<Show> shows;

        public SelectList genres;

        public string showGenre { get; set; }

    }
}
