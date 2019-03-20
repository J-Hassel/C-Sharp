using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.Iterator
{
    public interface IIterator
    {
        void First();
        string Next();
        bool IsDone();
        string CurrentItem();
    }
}
