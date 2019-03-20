using Iterator.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.Aggregate
{
    public class LAPaper : INewspaper
    {
        private string[] _reporters;

        public LAPaper()
        {
            _reporters = new[] { "Ronald Smith - LA", "Danny Glover - LA", "Yolanda Adams - LA", "Jerry Straight - LA", "Rhonda Lime - LA"};
        } 

        public IIterator CreateIterator()
        {
            return new LAPaperIterator(_reporters);
        }
    }
}
