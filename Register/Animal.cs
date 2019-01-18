using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register
{
    //Animal
    class Animal
    {
        public string Name { get; set; }
        public string Sound { get; set; }
        public bool CanFly { get; set; }
        public string AnimalType { get; set; }

        public Animal(string animalType, string name, string Sound, bool CanFly) {
            Name = name;
            Sound = Sound;
            CanFly = CanFly;
            animalType = animalType;
        }
    }
}
