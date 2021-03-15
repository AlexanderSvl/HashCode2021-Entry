using System;
using System.Collections.Generic;
using System.Text;

namespace HashCodeTraffic
{
    class Car
    {
        public Queue<string> route = new Queue<string>();
        private int traveling { get; set; }

        public Car(string[] route)
        {
            foreach(string street in route)
            {
                this.route.Enqueue(street);
            }
        }

        public bool IsTraveling()
        {
            return this.traveling != 0;
        }

        public void Travel()
        {
            this.traveling--;
        }
        public void AddTime(int time)
        {
            this.traveling += time;
        }

        public string NextStreet()
        {
            string next = this.route.Dequeue();

            return next;
        }

        public bool isDone()
        {
            return this.route.Count == 0;
        }
    }
}
