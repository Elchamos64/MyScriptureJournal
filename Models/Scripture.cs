using System.ComponentModel.DataAnnotations;

namespace MyScriptureJournal.Models
{
    public class Scripture
    {
        public int ID { get; set; }
        public string Book { get; set; }
        public int Chapter { get; set; }
        public string Verse { get; set; }


        [DataType(DataType.MultilineText)]
        public string Note { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; } = DateTime.Now;  // Default to the current date and time
    }
}
