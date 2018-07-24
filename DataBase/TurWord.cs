using System.Collections.Generic;

namespace DataBase
{
    public class TurWord
    {
        public TurWord()
        {
            EngWords = new HashSet<EngWord>();
        }
        public int ID { get; set; }
        public string Word { get; set; }
        public ICollection<EngWord> EngWords { get; set; }
    }
}
