using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningFramework1
{
    class AlgoMOGD : IAlgoritmPredictie
    {

        int lungimeFereastra;
        public AlgoMOGD(int lungimeFereastra)
        {
            this.lungimeFereastra = lungimeFereastra;
        }
        public double Predict(string path)
        {
            int predictiiGresite = 0;
            int predictiiCorecte = 0;
            int nrPerceptroni = 3; // parametru primit 
            int startIndex = 0;
            List<double> H = new List<double>();
            List<List<double>> W = new List<List<double>>();
            List<double> fereastra;
            FileUtil.readFile(path, H);
            initiateWeights(W, nrPerceptroni);

            List<double> suma = new List<double>();
            for (int j = 0; j < nrPerceptroni; j++)
            {
                suma.Add(0);
            }
            int index = lungimeFereastra + 1;

            while (startIndex + lungimeFereastra != H.Count && index != H.Count)
            {
                fereastra = H.GetRange(startIndex, lungimeFereastra);

                double target = H[index];
                int targetClass;
                if (target == -1) targetClass = 0;
                else targetClass = 1;

                for (int i = 0; i < nrPerceptroni; i++)
                {
                    double temp = 0;
                    for (int j = 0; j < lungimeFereastra; j++)
                    {
                        temp += fereastra[j] * W[i][j];


                    }
                    suma[i] = temp;
                }
                double max = Int32.MinValue;
                for (int i = 0; i < suma.Count; i++)
                {
                    max = Math.Max(max, suma[i]);


                }

                int indexMaxim = suma.IndexOf(max);
                double targetPerceptronValue = suma[targetClass];
                suma[targetClass] = Int16.MinValue;
                double maxFaraTarget = suma.Max();
                int indexMaxFaraTarget = suma.IndexOf(maxFaraTarget);

                
                double loss = Math.Max(0, 1 - (targetPerceptronValue - maxFaraTarget));


              
                if (loss > 0)
                {
                    for (int i = 0; i < fereastra.Count; i++)
                        fereastra[i] /= Math.Sqrt(startIndex);
                    UpdatePonderi( W, fereastra, indexMaxim, -1);
                    UpdatePonderi( W, fereastra, targetClass, 1);
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
       

        public void UpdatePonderi( List<List<double>> W, List<double> fereastra, int index, double delta)
        {


            for (int i = 0; i < lungimeFereastra; i++)
            {

                W[index][i] = W[index][i] + delta * fereastra[i];
            }


        }
        public void initiateWeights(List<List<double>> W, int nrClase)
        {

            for (int i = 0; i < nrClase; i++)
            {
                W.Add(new List<double>());
                for (int j = 0; j < lungimeFereastra; j++)
                {
                    W[i].Add(0);
                }
            }
        }
        public double CalculLoss(List<double> suma, int indexMaxim, int targetClass)
        {

            return Math.Max(0,1-(suma[indexMaxim]-suma[targetClass]));
        }
    }
}
