using System;

namespace EFCore21.GroupByTranslation.EF20
{
    internal class ReportItem
    {
        public ReportItem()
        {
        }

        public string BlogName { get; set; }
        public int PostCount { get; set; }
        public DateTime? LatestPostDate { get; set; }
        public int MaxComments { get; set; }
    }
}