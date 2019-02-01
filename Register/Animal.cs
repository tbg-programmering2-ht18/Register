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

        public Animal(string animalType, string name, string sound, bool canFly) {
            Name = name;
            Sound = Sound;
            CanFly = canFly;
            AnimalType = animalType;
        }
        public string show()
        {
            if (CanFly == true)
            {
                return string.Format("Name:{0}\nSound:{1}\nType:{2} and can fly!!", Name, Sound, AnimalType);
            }
            else
            {
                return string.Format("Name:{0}\nSound:{1}\nType:{2}", Name, Sound, AnimalType);
            }
        }
    }
}
