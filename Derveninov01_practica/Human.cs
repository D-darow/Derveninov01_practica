using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Класс "человек"
namespace Derveninov01_practica
{
    internal class Human
    {
        public int Age; // Возраст
        public bool Vector; // Переносчик
        public bool Ill; // Заболевший
        public bool Recovered; // Выздоровел
        public bool Dead; // Погиб
        public float Risk; // Риск заражения вирус
        public int DaysWithIllness; // Прошло дней с заражения
        public bool GotIllnessToday; // Заболел сегодня
        public float ChanceToDie; // Шанс смерти
        public bool HasMask; // Наличие маски
        // Конструктор
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
