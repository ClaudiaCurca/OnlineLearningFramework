using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningFramework1
{
    class AlgoSOP : IAlgoritmPredictie
    {
        int lungimeFereastra;
        int a;
        public AlgoSOP(int a,int lungimeFereastra)
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

            List<List<double>> sigma = new List<List<double>>();

            InitiateSigma(sigma);

            FileUtil.readFile(path, H);
            

            List<double> W = new List<double>(lungimeFereastra);
            initiateWeights(W);
            List<double> fereastra;
           

            int predictie;
            

            int index = lungimeFereastra+1;
            double t = 0;

            while (startIndex + lungimeFereastra != H.Count && index != H.Count)
            {
                fereastra = H.GetRange(startIndex, lungimeFereastra);

                double target = H[index];

                List<double> v_s_x_t = new List<double>(fereastra.Count);
                foreach(List<double> line in sigma)
                {
                    double line_sum = 0;
                    for(int i = 0;i< line.Count; i++)
                    {
                        line_sum += line[i] * fereastra[i];
                    }
                    v_s_x_t.Add(line_sum);
                }
                double v_t = 0;
                for (int i = 0; i < fereastra.Count; i++)
                {
                    v_t += v_s_x_t[i] * fereastra[i];

                }


                for (int i = 0; i < fereastra.Count; i++)
                {

                    t += fereastra[i] * v_s_x_t[i];
                }

                predictie = CalculSemn(t);

                if (predictie != target)
                {
                    UpdatePonderi(target, fereastra, sigma,W, v_t, v_s_x_t);
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

        public void InitiateSigma(List<List<double>> matrix )
        {
            for (int i = 0; i < lungimeFereastra; i++)
            {
                matrix.Add(new List<double>());
                for (int j = 0; j < lungimeFereastra; j++)
                {
                    if (i == j)
                    {
                        matrix[i].Add(a);
                    }
                    else { matrix[i].Add(0); }

                }
            }
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

        public void UpdatePonderi(double target, List<double> fereastra, List<List<double>> sigma, List<double> W, double v_t, List<double> v_s_x_t)
        {
            //update  ponderi
            for (int i = 0; i < fereastra.Count; i++) {

                W[i] += target * fereastra[i];
            }
            // update sigma
            double beta = 1.0 * (v_t + 1);
            for (int i = 0; i < sigma.Count; i++)
            {
                for (int j = 0; j < sigma[i].Count; j++)
                {

                    sigma[i][j] -= beta * v_s_x_t[i] * v_s_x_t[j];


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
