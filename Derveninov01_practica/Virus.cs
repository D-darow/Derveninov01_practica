using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derveninov01_practica
{
    // Класс "Вирус"
    internal class Virus
    {
        public float RiskYoung { get; private set; } // Риск заражения молодыми
        public float RiskAdult { get; private set; } // Риск заражения взрослыми
        public float RiskAged { get; private set; } // Риск заражения пожилыми
        public float MortalityYoung { get; private set; } // Смертность среди молодых
        public float MortalityAdult { get; private set; } // Смертность среди взрослых
        public float MortalityAged { get; private set; } // Смертность среди пожилых
        // Конструктор без параметров
        public Virus()
        {
            RiskYoung = 0;
            RiskAdult = 0;
            RiskAged = 0;
            MortalityYoung = 0;
            MortalityAdult = 0;
            MortalityAged = 0;
        }
        // Конструктор с параметрами
        public Virus(float riskYoung, float riskAdult, float riskAged, float mortalityYoung, float mortalityAdult, float mortalityAged)
        {
            RiskYoung = riskYoung;
            RiskAdult = riskAdult;
            RiskAged = riskAged;
            MortalityYoung = mortalityYoung;
            MortalityAdult = mortalityAdult;
            MortalityAged = mortalityAged;
        }
        // Установка новых параметров для вируса
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
