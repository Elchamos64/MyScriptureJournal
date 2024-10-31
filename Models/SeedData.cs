using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyScriptureJournal.Data;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MyScriptureJournal.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyScriptureJournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyScriptureJournalContext>>()))
            {
                // Look for any movies.
                if (context.Scripture.Any())
                {
                    return;   // DB has been seeded
                }

                context.Scripture.AddRange(
                    new Scripture
                    {
                        Book = "Helaman",
                        Chapter = 14,
                        Verse = "12-13",
                        Note = "12 And also that ye might know of the coming of Jesus Christ" +
                        ", the Son of God, the Father of heaven and of earth, the Creator of " +
                        "all things from the beginning; and that ye might know of the signs of " +
                        "his coming, to the intent that ye might believe on his name.\r\n\r\n13 And if" +
                        " ye believe on his name ye will repent of all your sins, that thereby ye may " +
                        "have a remission of them through his merits."
                    },

                    new Scripture
                    {
                        Book= "Mosiah",
                        Chapter = 16,
                        Verse = "15",
                        Note = "15 Teach them that redemption cometh through Christ the Lord, who is the very Eternal Father. Amen."
                    },

                    new Scripture
                    {
                        Book = "Omni",
                        Chapter = 1,
                        Verse = "26",
                        Note = "26 And now, my beloved brethren, I would that ye should come unto Christ," +
                        " who is the Holy One of Israel, and partake of his salvation, and the power of" +
                        " his redemption. Yea, come unto him, and offer your whole souls as an offering unto him," +
                        " and continue in fasting and praying, and endure to the end; and as the Lord liveth ye will be saved."
                    },

                    new Scripture
                    {
                        Book = "Ether",
                        Chapter = 12,
                        Verse = "27",
                        Note = "27 And if men come unto me I will show unto them their weakness. I give" +
                        " unto men weakness that they may be humble; and my grace is sufficient for all " +
                        "men that humble themselves before me; for if they humble themselves before me, " +
                        "and have faith in me, then will I make weak things become strong unto them."
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
