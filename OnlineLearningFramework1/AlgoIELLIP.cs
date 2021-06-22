using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningFramework1
{
    class AlgoIELLIP : IAlgoritmPredictie
    {
        int lungimeFereastra;
        int a;
        int c;
        int b;

        public AlgoIELLIP(int a, int b, int c,int lungimeFereastra)
        {
            this.a = a;
            this.b = b;
            this.c = c;
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
            int index = 5;
            while (startIndex + lungimeFereastra != H.Count && index != H.Count)
            {
                fereastra = H.GetRange(startIndex, lungimeFereastra);

                double target = H[index];

                //imultire W transpusa cu fereastra
                for (int i = 0; i < fereastra.Count; i++)
                {

                    t += fereastra[i] * W[0];
                }


                List<double> v_s_x_t = new List<double>(fereastra.Count);
                foreach (List<double> line in sigma)
                {
                    double line_sum = 0;
                    for (int i = 0; i < line.Count; i++)
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
                double suma = 0;
                for (int i = 0; i < W.Count; i++) 
                {
                    suma += W[i] * fereastra[i];
                }

                //double m_t = target * suma;
               
                predictie = CalculSemn(suma);




                if (predictie != target)
                {
                    UpdatePonderi(target, fereastra, sigma, W);
                    predictiiGresite++;
                }
                else
                {
                    predictiiCorecte++;
                }




                index++;
                startIndex++;



            }
            return ((double)predictiiCorecte / (predictiiCorecte + predictiiGresite));
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

        public void UpdatePonderi(double target, List<double> fereastra, List<List<double>> sigma, List<double> W)
        {
            double phi = 112.544;
            double psi = 1 + Math.Pow(phi, 2) / 2;
            double ksi = 1 + Math.Pow(phi, 2);
            double m = 0;

            double suma = 0;
            for (int i = 0; i < W.Count; i++)
            {
                suma += W[i] * fereastra[i];
            }

            double m_t = target * suma;


            //callcul v
            double v = 0;
            for (int i = 0; i < fereastra.Count; i++)
            {
               // v += sigma_x_t[i] * fereastra[i];

            }

            //calcul m
            for (int i = 0; i < fereastra.Count; i++)
            {
                m += target * (W[i] * fereastra[i]);
            }

            double alfa = Math.Max(0, (-m * psi + Math.Sqrt((Math.Pow(m, 2) * Math.Pow(phi, 4)) / 4 + v * Math.Pow(phi, 2) * ksi)) / (v * ksi));
            double u = 0.25 * Math.Pow((-alfa * v * phi + Math.Sqrt(Math.Pow(alfa, 2) * Math.Pow(v, 2) * Math.Pow(phi, 2) + 4 * v)), 2);
            double beta = (alfa * phi) / (Math.Sqrt(u) + v * alfa * phi);



            //update  ponderi

            for (int i = 0; i < W.Count(); i++)
            {
               // W[i] = W[i] + alfa * target * sigma_x_t[i];
            }
            // update sigma
            for (int i = 0; i < sigma.Count; i++)
            {
                for (int j = 0; j < sigma[i].Count; j++)
                {

                    //sigma[i][j] -= beta * sigma_x_t[i] * sigma_x_t[j];


                }


            }


        }

        public void InitiateSigma(List<List<double>> matrix)
        {
            matrix.Add(new List<double> { a, 0, 0, 0 });
            matrix.Add(new List<double> { 0, a, 0, 0 });
            matrix.Add(new List<double> { 0, 0, a, 0 });
            matrix.Add(new List<double> { 0, 0, 0, a });

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
