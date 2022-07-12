using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derveninov01_practica
{
    internal class Field
    {
        public List<List<Human>> HumanList { get; private set; }
        public int Columns;
        public int Rows;
        public bool EpidemicEnded { get; private set; }

        public Field()
        {
            HumanList = new List<List<Human>>();
            EpidemicEnded = false;
        }

        public void CheckNeighbours(int x, int y)
        {
            Random r = new Random();
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (Rows == x && Columns == y) continue;
                    int col = (x + i + Rows) % Rows;
                    int row = (y + j + Columns) % Columns;

                    if ((HumanList[x][y].Vector || HumanList[x][y].Ill) && !(HumanList[row][col].Vector || HumanList[row][col].Ill 
                        || HumanList[x][y].GotIllnessToday || HumanList[row][col].Recovered || HumanList[row][col].Dead))
                    {
                        float chance = r.Next(0,100);
                        if (HumanList[x][y].HasMask && HumanList[row][col].HasMask && chance > 1.5)
                            chance = (float)1.5;
                        else if (HumanList[x][y].HasMask && !HumanList[row][col].HasMask && chance > 5)
                            chance = (float)5;
                        else if (!HumanList[x][y].HasMask && HumanList[row][col].HasMask && chance > 70)
                            chance = (float)70;
                        if (HumanList[row][col].Risk > chance)
                        {
                            HumanList[row][col].Vector = true;
                            HumanList[row][col].GotIllnessToday = true;
                        }
                    }
                }
            }
        }

        public void ClearGotIllnes()
        {
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    HumanList[i][j].GotIllnessToday = false;
                }
            }
        }

        public void CreateHumanList(int columns, int rows, Virus virus, float chanceToHaveMask)
        {
            EpidemicEnded = false;
            Columns = columns;
            Rows = rows;
            Random rnd = new Random();
            for (int i = 0; i < columns; i++)
            {
                HumanList.Add(new List<Human>());
                for (int j = 0; j < rows; j++)
                {
                    int age = rnd.Next(0, 100);
                    float risk;
                    float chanceToDie;
                    bool mask = false;
                    if (age <= 18) 
                    {
                        risk = virus.RiskYoung;
                        chanceToDie = virus.MortalityYoung;
                    } 
                    else if (age <= 65)
                    {
                        risk = virus.RiskAdult;
                        chanceToDie = virus.MortalityAdult;
                    }
                    else
                    {
                        risk = virus.RiskAged;
                        chanceToDie = virus.MortalityAged;
                    }
                    float notAtRisk = rnd.Next(0, 100);
                    if (notAtRisk < 4) risk = 0;
                    float chance = rnd.Next(0, 100);
                    if (chanceToHaveMask < chance)
                        mask = true;
                    HumanList[i].Add(new Human(age, false, false, false, false, risk, false, chanceToDie, mask));
                }
            }
            HumanList[rows / 2][columns / 2].Vector = true;
        }

        public void NextGeneration()
        {
            EpidemicEnded = true;
            Random rnd = new Random();
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    CheckNeighbours(i, j);
                    if (HumanList[i][j].DaysWithIllness > 6)
                    {
                        HumanList[i][j].Vector = false;
                        HumanList[i][j].Ill = true;
                    }
                    if (HumanList[i][j].DaysWithIllness > 14)
                    {
                        HumanList[i][j].Ill = false;
                        
                        float chanceToDie = rnd.Next(0, 100);
                        if (chanceToDie < HumanList[i][j].ChanceToDie)
                            HumanList[i][j].Dead = true;
                        else
                            HumanList[i][j].Recovered = true;
                        HumanList[i][j].DaysWithIllness = 0;
                    }
                    if (HumanList[i][j].Vector)
                    {
                        EpidemicEnded = false;
                        HumanList[i][j].DaysWithIllness++;
                    }
                    else if (HumanList[i][j].Ill)
                    {
                        EpidemicEnded = false;
                        HumanList[i][j].DaysWithIllness++;
                    }
                }
            }
        }

        public List<int> EpidemicResult()
        {
            List<int> result;
            result = new List<int>();
            for (int i = 0; i < 7; i++)
                result.Add(0);
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    if (HumanList[i][j].Age < 19)
                    {
                        result[0]++;
                        if (HumanList[i][j].Dead)
                            result[1]++;
                        if (HumanList[i][j].Risk == 0)
                        {
                            result[0]--;
                            result[6]++;
                        }
                    }
                    else if (HumanList[i][j].Age < 66)
                    {
                        result[2]++;
                        if (HumanList[i][j].Dead)
                            result[3]++;
                        if (HumanList[i][j].Risk == 0)
                        {
                            result[2]--;
                            result[6]++;
                        }
                    }
                    else
                    {
                        result[4]++;
                        if (HumanList[i][j].Dead)
                            result[5]++;
                        if (HumanList[i][j].Risk == 0)
                        {
                            result[4]--;
                            result[6]++;
                        }
                    }
                }
            }
            return result;
        }

        public void DeleteHumanList()
        {
            HumanList.Clear();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
