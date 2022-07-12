using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derveninov01_practica
{
    internal class Human
    {
        public int Age;
        public bool Vector;
        public bool Ill;
        public bool Recovered;
        public bool Dead;
        public float Risk;
        public int DaysWithIllness;
        public bool GotIllnessToday;
        public float ChanceToDie;
        public bool HasMask;

        public Human(int age, bool vector, bool ill, bool recovered, bool dead, float risk, bool gotIllnessToday, float chanceToDie, bool hasMask)
        {
            Age = age;
            Vector = vector;
            Ill = ill;
            Recovered = recovered;
            Dead = dead;
            Risk = risk;
            DaysWithIllness = 0;
            GotIllnessToday = gotIllnessToday;
            ChanceToDie = chanceToDie;
            HasMask = hasMask;
        }
    }
}
