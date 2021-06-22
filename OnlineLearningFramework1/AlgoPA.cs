using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningFramework1
{
    class AlgoPA : IAlgoritmPredictie
    {
        int lungimeFereastra;
        double c;
        public AlgoPA(double C, int lungimeFereastra)
        {
            this.c = C;
            this.lungimeFereastra = lungimeFereastra;
        }
        public double Predict(string path)
        {
            int predictiiGresite = 0;
            int predictiiCorecte = 0;
            int startIndex = 0;
            List<double> W = new List<double>(lungimeFereastra);
            List<double> fereastra;
            List<double> H = new List<double>();
            FileUtil.readFile(path, H);
            initiateWeights(W);

            int index = lungimeFereastra+1;
            while (startIndex + lungimeFereastra != H.Count && index != H.Count)
            {
                double target = H[index];
                fereastra = H.GetRange(startIndex, lungimeFereastra);
                double ltFinal;
                ltFinal = CalculLoss( W, fereastra,target);


                if (ltFinal > 0)
                {
                    UpdatePonderi( W, fereastra,target,ltFinal);


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
        public void initiateWeights(List<double> weights)
        {
            for(int i=0;i< weights.Capacity; i++)
            {
                weights.Add(0);
            }
        }
        public void UpdatePonderi( List<double> W, List<double> fereastra, double target,double l_t)
        {
            double norm_x = 0;
            for (int i = 0; i < fereastra.Count; i++)
            {
                norm_x += fereastra[i] * fereastra[i];
            }
            double gamma;
            if(norm_x>0)
            {
                gamma = l_t / norm_x;
            }
            else
            {
                gamma = 1;
            }

            for (int i = 0; i < lungimeFereastra; i++)
            {
                fereastra[i] = fereastra[i] * (target*gamma);
                W[i] = W[i] + fereastra[i];
            }
        }
        public double CalculLoss( List<double> W, List<double> fereastra,double target)
        {
            double ltFinal;

            double lt;
            double suma = 0;
            for (int i = 0; i < lungimeFereastra; i++)
            {
                suma += fereastra[i] * W[i];

            }
            lt = 1 -target * suma;
            ltFinal = Math.Max(0, lt);

            return ltFinal;
        }
    }
}
