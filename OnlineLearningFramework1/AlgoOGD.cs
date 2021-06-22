using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningFramework1
{
    class AlgoOGD : IAlgoritmPredictie
    {
        int lungimeFereastra;
        int lossType;
        int C;
       public AlgoOGD(int lossType, int C,int lungimeFereastra)
        {
            this.lossType = lossType;
            this.C = C;
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



            int index = lungimeFereastra+1;
            while (startIndex + lungimeFereastra != H.Count && index != H.Count)
            {
                fereastra = H.GetRange(startIndex, lungimeFereastra);

                double ltFinal;
                ltFinal = CalculLoss(H, W, fereastra, index, lossType);


                if (ltFinal > 0)
                {
                    UpdatePonderi(W, H, fereastra, C, index, lossType,startIndex);


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

        public void UpdatePonderi(List<double> W, List<double> H, List<double> fereastra, double C, int index, int lossType,int startIndex)
        {
            if (lossType == 0 || lossType == 1)
            {

                double learningRate = C / Math.Sqrt(startIndex);
                for (int i = 0; i < lungimeFereastra; i++)
                {
                    
                    W[i] = W[i] + (learningRate * H[index] * fereastra[i]);

                }
            }

            if (lossType == 2)
            {
                double suma = 0;
                double learningRate = C / Math.Sqrt(startIndex);
                for (int i = 0; i < lungimeFereastra; i++)
                {
                    suma += W[i] * fereastra[i];
                }
                for (int i = 0; i < lungimeFereastra ; i++)
                {
                    double alfa = (1.0 / (1 + Math.Exp(H[index] * suma)));
                    W[i] = W[i] + (learningRate * H[index] * fereastra[i] * alfa);
                }
            }


            if (lossType == 3)
            {
                double suma = 0;
                double learningRate = C / Math.Sqrt(startIndex);
                for (int i = 0; i < lungimeFereastra; i++)
                {
                    suma += W[i] * fereastra[i];
                }
                for (int i = 0; i < lungimeFereastra - 1; i++)
                {
                   
                    W[i + 1] = W[i] + learningRate * (H[index] - suma) * fereastra[i];
                }
            }
        }

        public double CalculLoss(List<double> H, List<double> W, List<double> fereastra, int index, int lossType)
        {
            double ltFinal = 0;
            //0-1 loss
            if (lossType == 0)
            {
                double suma = 0;
                for (int i = 0; i < lungimeFereastra; i++)
                {
                    suma += fereastra[i] * W[i];
                }
                ltFinal = CalculSemn(suma);
            }
            //hinge loss
            if (lossType == 1)
            {
                double lt = 0;
                double suma = 0;
                for (int i = 0; i < lungimeFereastra; i++)
                {
                    suma+= fereastra[i] * W[i];
  
                }
                lt = 1 - H[index] * suma;
                ltFinal = Math.Max(0, lt);

            }
            //logistic loss
            if (lossType == 2)
            {
                double suma = 0;
                double lt = 0;
                for (int i = 0; i < lungimeFereastra; i++)
                {
                    suma += fereastra[i] * W[i];
                   
                }
                lt = Math.Log(1 + Math.Exp(-H[index] * suma));
                ltFinal = lt;
            }
            //square loss
            if (lossType == 3)
            {
                double suma = 0;
                double lt;
                for (int i = 0; i < lungimeFereastra; i++)
                {
                    suma += fereastra[i] * W[i];
                   
                }
                lt = Math.Pow((suma - H[index]), 2);
                ltFinal = 0.5 * lt;
            }
            return ltFinal;
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
