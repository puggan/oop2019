using System;
using System.Collections.Generic;
using System.Linq;
using w2e01;

namespace w2e03
{
    internal class BoxManager<T> where T : Box
    {
        private List<T> boxes;

        public BoxManager(List<T> boxes)
        {
            this.boxes = boxes;
        }
        public BoxManager() : this(new List<T>()) {}

        public void Add(T box)
        {
            boxes.Add(box);
        }

        public void DrawInCenter()
        {
            int vh = Console.WindowHeight;
            int vw  = Console.WindowWidth;
            foreach(var box in boxes.OrderBy(a => -a.width).ThenBy(b => -b.height))
            {
                int left = (vw - box.width) / 2;
                if (left < 0) left = 0;
                int top = (vh - box.height) / 2;
                if (top < 0) top = 0;
                box.Draw(left, top);
            }
        }
    }
}
