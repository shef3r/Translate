using System.Collections.Generic;

namespace Translate.Models
{
    public class EntryList
    {
        public List<HistoryEntry> entries { get; set; } = new List<HistoryEntry>();
    }

    public class HistoryEntry
    {
        public string inputText { get; set; }
        public string outputText { get; set; }
        public string input { get; set; }
        public string output { get; set; }
    }
}
