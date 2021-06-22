using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningFramework1
{
    class Predictor
    {
        public static List<String> algoritmi = new List<string>
        { 
            "Perceptron", "Approximate Large Margin Algorithm",
            "Relaxed Online Maximum Margin Algorithm", "Online Gradient Descent", "Passive-Aggressive learning algorithm",
            "Second-Order Perceptron", "Confidence Weighted algorithm", "Multiclass Perceptron", "Multiclass Online Gradient Descent"
        };
        public Predictor()
        {
      

        }
        public  double predict(IAlgoritmPredictie algoritm, string filePath)
        {
            return algoritm.Predict(filePath);
        }

      
    }
}
