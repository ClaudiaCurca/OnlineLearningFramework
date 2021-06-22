using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningFramework1
{
    class AlgoROMMA : IAlgoritmPredictie
    {
        int lungimeFereastra;
        public AlgoROMMA(int lungimeFereastra)
        {
            this.lungimeFereastra = lungimeFereastra;
        }
        public double Predict(string path)
        {
            int startIndex = 0;
            int predictiiGresite = 0;
            int predictiiCorecte = 0;
            List<double> H = new List<double>();
            List<double> W = new List<double>(lungimeFereastra);
            List<double> fereastra;
            FileUtil.readFile(path, H);
            initiateWeights(W);

            int predictie;
            double suma = 0;

           
            int index = lungimeFereastra+1;

            while (startIndex + lungimeFereastra != H.Count && index != H.Count)
            {
                fereastra = H.GetRange(startIndex, lungimeFereastra);

                double target = H[index];

                for (int i = 0; i < lungimeFereastra; i++)
                {
                    suma += fereastra[i] * W[i];

                }
                predictie = CalculSemn(suma);


                if (predictie != target)
                {
                    UpdatePonderi(target, W, fereastra,predictie);
                    predictiiGresite++;
                }
                else
                {
                    predictiiCorecte++;
                }

                index++;
                startIndex++;



            }
            return ((double)predictiiCorecte / (predictiiCorecte + predictiiGresite)) * 100;

        }
        public int CalculSemn(double suma)
        {
            if (suma >= 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public void UpdatePonderi(double target, List<double> W, List<double> fereastra,double predictie)
        {
            double norm_W = 0;
            for (int i = 0; i < W.Count ; i++)
            {
                norm_W += W[i] * W[i];
               
            }
            if (norm_W == 0) 
            {
                for (int i = 0; i < fereastra.Count; i++)
                {
                    fereastra[i] = fereastra[i] * target;
                }
                for (int i = 0; i < fereastra.Count; i++)
                {
                    W[i] = W[i] + fereastra[i];
                }

            }
            else 
            {
                double norm_x = 0;
                for (int i = 0; i < fereastra.Count; i++)
                {
                    norm_x += fereastra[i] * fereastra[i];
                }
                double numitor = (norm_x * norm_W) - Math.Pow(predictie, 2);
                if (numitor != 0)
                {
                    double coef_1 = ((norm_x * norm_W) - target * predictie) / numitor;
                    double coef_2 = (norm_W*(target - predictie)) / numitor;
                    for (int i = 0; i < W.Count; i++)
                    {
                        W[i] = W[i] * coef_1;
                    }
                    for (int i = 0; i < fereastra.Count; i++)
                    {
                        fereastra[i] = fereastra[i] * coef_2;
                    }
                    for (int i = 0; i < W.Count; i++)
                    {
                        W[i] = W[i] + fereastra[i];
                    }
                }

            }

        }
        public void initiateWeights(List<double> weights)
        {
            for (int i = 0; i < weights.Capacity; i++)
            {
                weights.Add(0);
            }
        }
    }
}
