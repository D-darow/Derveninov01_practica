using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derveninov01_practica
{
    internal class Virus
    {
        public float RiskYoung { get; private set; }
        public float RiskAdult { get; private set; }
        public float RiskAged { get; private set; }
        public float MortalityYoung { get; private set; }
        public float MortalityAdult { get; private set; }
        public float MortalityAged { get; private set; }

        public Virus()
        {
            RiskYoung = 0;
            RiskAdult = 0;
            RiskAged = 0;
            MortalityYoung = 0;
            MortalityAdult = 0;
            MortalityAged = 0;
        }

        public Virus(float riskYoung, float riskAdult, float riskAged, float mortalityYoung, float mortalityAdult, float mortalityAged)
        {
            RiskYoung = riskYoung;
            RiskAdult = riskAdult;
            RiskAged = riskAged;
            MortalityYoung = mortalityYoung;
            MortalityAdult = mortalityAdult;
            MortalityAged = mortalityAged;
        }

        public void ResetVirus(float riskYoung, float riskAdult, float riskAged, float mortalityYoung, float mortalityAdult, float mortalityAged)
        {
            RiskYoung = riskYoung;
            RiskAdult = riskAdult;
            RiskAged = riskAged;
            MortalityYoung = mortalityYoung;
            MortalityAdult = mortalityAdult;
            MortalityAged = mortalityAged;
        }
    }
}
