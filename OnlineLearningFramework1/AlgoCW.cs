using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningFramework1
{
    class AlgoCW : IAlgoritmPredictie
    {
        int lungimeFereastra;
        int a;
        
        public AlgoCW(int a,int lungimeFereastra)
        {
            this.a = a;
            this.lungimeFereastra = lungimeFereastra;
        }
        public double Predict(string path)
        {
            int startIndex = 0;
            int predictiiGresite = 0;
            int predictiiCorecte = 0;
            List<double> H = new List<double>();
           
            // initiate sigma matrix as a* Identity matrix
            List<List<double>> sigma = new List<List<double>>();
            InitiateSigma(sigma);

            FileUtil.readFile(path, H);

            // W which is also used as miu
            List<double> W = new List<double>(lungimeFereastra);//miu
            initiateWeights(W);


            List<double> fereastra;

            int predictie;

            double t = 0;
            int index = lungimeFereastra+1;
            while (startIndex + lungimeFereastra != H.Count && index != H.Count)
            {
                fereastra = H.GetRange(startIndex, lungimeFereastra);

                double target = H[index];

                //imultire W transpusa cu fereastra
                for (int i = 0; i < fereastra.Count; i++) {

                    t += fereastra[i] * W[0];
                }


                

                predictie = CalculSemn(t);




                if (predictie != target)
                {
                    UpdatePonderi(target, fereastra, sigma,W);
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
            if (suma > 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public void UpdatePonderi(double target, List<double> fereastra, List<List<double>> sigma,  List<double> W)
        {
            double phi = 112.544;
            double psi = 1 + Math.Pow(phi, 2) / 2;
            double ksi = 1 + Math.Pow(phi, 2);
            double m = 0;

            List<double> sigma_x_t = new List<double>();
            foreach (List<double> subList in sigma)
            {
                double sum = 0;
                for (int i = 0; i < subList.Count; i++)
                {
                    sum += subList[i] * fereastra[i];
                }
                sigma_x_t.Add(sum);



            }


            //callcul v
            double v = 0;
            for (int i = 0; i < fereastra.Count; i++)
            {
                v += sigma_x_t[i] * fereastra[i];

            }

            //calcul m
            for (int i = 0; i < fereastra.Count; i++) 
            {
                 m += target * (W[i] * fereastra[i]); 
            }

            double alfa = Math.Max(0,(-m*psi+Math.Sqrt((Math.Pow(m,2)*Math.Pow(phi,4))/4+v*Math.Pow(phi,2)*ksi))/(v*ksi));
            double u = 0.25 * Math.Pow((-alfa * v * phi + Math.Sqrt(Math.Pow(alfa, 2) * Math.Pow(v, 2) * Math.Pow(phi, 2) + 4 * v)),2);
            double beta = (alfa * phi) /( Math.Sqrt(u) + v * alfa * phi);
            
           

            //update  ponderi

            for (int i = 0; i < W.Count(); i++) {
                W[i] = W[i] + alfa * target * sigma_x_t[i]; }
            // update sigma
            for (int i = 0; i < sigma.Count; i++) {
                for (int j = 0; j < sigma[i].Count; j++) {

                    sigma[i][j] -= beta * sigma_x_t[i] * sigma_x_t[j];


                }
            
            
            }
            

        }

        public void InitiateSigma(List<List<double>> matrix)
        {
            for(int i = 0; i < lungimeFereastra; i++)
            {
                matrix.Add(new List<double>());
                for(int j = 0; j < lungimeFereastra; j++)
                {
                    if (i == j)
                    {
                        matrix[i].Add(a);
                    }
                    else { matrix[i].Add(0); }
                    
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
