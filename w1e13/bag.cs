using System;
using System.Collections.Generic;
using System.Linq;

namespace w1e13
{
    internal class Bag<T>
    {
        private ICollection<T> template;
        private List<T> list;
        private Random random;
            
        public Bag(ICollection<T> list)
        {
            template = list;
            random = new Random();
            reset();
        }

        private void reset()
        {
            list = template.OrderBy( x => random.Next() ).ToList( );
        }

        public T Next()
        {
            if (list.Count < 1)
            {
                reset();
            }

            // list.Pop()?
            T top = list[0];
            list.RemoveAt(0);
            return top;
        }
    }
}
