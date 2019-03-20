using Iterator.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.Aggregate
{
    public class NYPaper : INewspaper
    {
        private List<string> _reporters;

        public NYPaper()
        {
            _reporters = new List<string> { "John Mest - NY", "Susanna Lee - NY", "Paul Randy - NY", "Kim Fields - NY", "Sky Taylor - NY" };
        }

        public IIterator CreateIterator()
        {
            return new NYPaperIterator(_reporters);
        }
    }
}
