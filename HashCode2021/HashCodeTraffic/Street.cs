using System;
using System.Collections.Generic;
using System.Text;

namespace HashCodeTraffic
{
    class Street
    {
        Queue<Car> stoppedCars = new Queue<Car>();

        private int L { get; set; }
        private bool IsGreen { get; set; }
        public int exitID { get; set; }
        private int entranceID { get; set; }
        public string Name { get; set; }

        public Street(string name, int L, int In, int Out)
        {
            this.Name = name;
            this.L = L;
            this.exitID = Out;
            this.entranceID = In;
            IsGreen = false;
        }

        public void GoGreen()
        {
            IsGreen = true;
        }
        public void GoRed()
        {
            IsGreen = false;
        }
        public void AddCar(Car car)
        {
            this.stoppedCars.Enqueue(car);
        }
    }
}
