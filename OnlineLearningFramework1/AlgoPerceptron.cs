using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningFramework1
{
    class AlgoPerceptron:IAlgoritmPredictie
    {
        int lungimeFereastra;
       public AlgoPerceptron(int lungimeFereastra)
        {
            this.lungimeFereastra = lungimeFereastra;
        }

        public double Predict(string path)
        {
            int predictiiGresite = 0;
            int predictiiCorecte = 0;
            int startIndex = 0;
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
                    UpdatePonderi(target, W, fereastra);
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

        public void UpdatePonderi(double target, List<double> W, List<double> fereastra)
        {
            for (int i = 0; i < W.Count; i++)

            {
                W[i] = W[i] + target * fereastra[i];
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
