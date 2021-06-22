using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineLearningFramework1
{
    class Afisare
    {
        List<double> acuratete = new List<double>();
        List<string> numeAlgo = new List<string>();

        public void draw(List<double> acuratete, List<string> numeAlgo)
        {
            this.acuratete = acuratete;
            this.numeAlgo = numeAlgo;
            OnlineLearningFramework1.Form2 form = new OnlineLearningFramework1.Form2();

            form.chart1.Series.Clear();

            for (int i = 0; i < acuratete.Count; i++)
            {
               
                form.chart1.Series.Add(numeAlgo[i]);
                form.chart1.Series[i].Points.Add(Math.Round(acuratete[i],2));
                form.chart1.Series[numeAlgo[i]].IsValueShownAsLabel = true;
                
            }
            
            form.ShowDialog();
        }
    }
}
