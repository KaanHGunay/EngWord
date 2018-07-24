using System.Collections.Generic;

namespace DataBase
{
    public class EngWord
    {
        public EngWord()
        {
            TurWords = new HashSet<TurWord>();
        }
        public int ID { get; set; }
        public string Word { get; set; }
        public ICollection<TurWord> TurWords { get; set; }
    }
}
