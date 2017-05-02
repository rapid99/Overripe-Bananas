using System.ComponentModel.DataAnnotations;

namespace OverripeBananas.Models
{
    public class Episodes
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Show Name")]
        public string ShowName { get; set; }

        [Required]
        public int Season { get; set; }

        [Display(Name = "Episode Number")]
        [Required]
        public int EpisodeNumber { get; set; }

        [Display(Name = "Episode Name")]
        [Required]
        public string EpisodeName { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "Best Character")]
        [Required]
        public string BestCharacter { get; set; }

        [Required]
        [Display(Name = "Humor Rating")]
        public int HumorRating { get; set; }

        [Required]
        [Display(Name = "Story Rating")]
        public int StoryRating { get; set; }

        [Display(Name = "Overall Grade")]
        [Required]
        public int OverallGrade { get; set; }
    }
}
