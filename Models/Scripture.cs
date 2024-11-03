using System.ComponentModel.DataAnnotations;

namespace MyScriptureJournal.Models
{
    public class Scripture
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Book { get; set; }

        [Required]
        public int Chapter { get; set; }

        [Required]
        public string Verse { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]

        public string Note { get; set; }

        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; } = DateTime.Now;  // Default to the current date and time
    }
}
