using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningFramework1
{
    class AlgoALMA : IAlgoritmPredictie
    {
        int lungimeFereastra;
        int p;
        double alfa;
        double C;
        double B;
       public AlgoALMA(int p, double alfa, double C, double B,int lungimeFereastra)
        {
            this.p = p;
            this.alfa = alfa;
            this.C = C;
            this.B = B;
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
            double k = 1;
           
            
            while ((startIndex + lungimeFereastra != H.Count) && (index != H.Count))
            {
                double target = H[index];
                fereastra = H.GetRange(startIndex, lungimeFereastra);

                for (int i = 0; i < lungimeFereastra; i++)
                {
                    suma += fereastra[i] * W[i];
                }
                predictie = CalculSemn(suma);


                double ltFinal;
                ltFinal = CalculLoss(alfa, B, p, k,predictie,target);


                if (ltFinal > 0)
                {

                    UpdatePonderi(W, fereastra, C, p, k,target);
                    k += 1;

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

        public void UpdatePonderi(List<double> W, List<double> fereastra, double C, int p, double k, double target)
        {
            List<double> tempo = new List<double>();
            
            double eta_k = C / (Math.Sqrt(p - 1) * Math.Sqrt(k));
            for (int i = 0; i < fereastra.Count; i++)
            {
                tempo.Add(fereastra[i]*(eta_k*target));
            }
            for (int i = 0; i < W.Count; i++)
            {
                W[i]= W[i] + tempo[i];
            }
            double norm_w = 0;
            for (int i = 0; i < W.Count; i++)
            {
                norm_w += W[i] * W[i];
            }
            norm_w = Math.Sqrt(norm_w);

            for (int i = 0; i < W.Count; i++)
            {
                W[i] = W[i] * (1/Math.Max(1,norm_w));
            }

            }
        public double CalculLoss( double alfa, double B, int p,  double k, int predictie,double target)
        {
            return Math.Max(0, (1 - alfa) * B * (Math.Sqrt(p - 1) / Math.Sqrt(k)) - (target * predictie));
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
