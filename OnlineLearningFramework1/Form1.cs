using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineLearningFramework1
{
    public partial class Form1 : Form
    {
        List<IAlgoritmPredictie> algoritmi = new List<IAlgoritmPredictie> ();
        List<string> denumireAlgoritmi = new List<string>();
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            initateCheckBoxList();
        }
        private void initateCheckBoxList() {
            foreach (String algoName in Predictor.algoritmi) {
                checkedListBox.Items.Add(algoName);
            
            
            }
        
        
        }

        private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            panel1.Controls.Clear();
            panel2.Controls.Clear();
            String selectedAlgorithm = (String)checkedListBox.SelectedItem;
            if(selectedAlgorithm == "Passive-Aggressive learning algorithm")
            {
                
                
                Label label2 = new Label();
                label2.Text = "Lungime istorie";
                
                numeAlgo.Text = selectedAlgorithm;
                Label detalii = new Label();
                detalii.Text = " \n " +
                    "lungime istorie - lungimea vectorului de intrare";
                detalii.AutoSize = true;
                detalii.AutoEllipsis = true;
               
                NumericUpDown numericUpDown2 = new NumericUpDown();
                numericUpDown2.Name = "numericUpDownFereastra";
                numericUpDown2.Value = 4;
                numericUpDown2.Maximum = 100;
                numericUpDown2.Minimum = 1;
                numericUpDown2.Increment = 1;
                numericUpDown2.Location = new Point(100, 0);

                numericUpDown2.Font = new Font("Bodoni MT", 8);
               
                panel1.Controls.Add(label2);
                panel1.Controls.Add(label1);
                
                panel1.Controls.Add(numericUpDown2);
                panel2.Controls.Add(detalii);
                panel2.Show();
                panel1.Show();
            }
            if (selectedAlgorithm == "Perceptron" || selectedAlgorithm == "Relaxed Online Maximum Margin Algorithm")
            {
                numeAlgo.Text = selectedAlgorithm;
                Label label1 = new Label();
                label1.Text = "Lungime istorie";
                label1.Location = new Point(0, 0);
                Label detalii = new Label();
                detalii.Text = "\n lungime istorie - lungimea vectorului de intrare";
                detalii.AutoSize = true;
                detalii.AutoEllipsis = true;
                NumericUpDown numericUpDown2 = new NumericUpDown();
                numericUpDown2.Name = "numericUpDownFereastra";
                numericUpDown2.Value = 4;
                numericUpDown2.Maximum = 100;
                numericUpDown2.Minimum = 1;
                numericUpDown2.Increment = 1;
                numericUpDown2.Location = new Point(100, 0);
                panel2.Controls.Add(detalii);
                panel1.Controls.Add(label1);
                panel1.Controls.Add(numericUpDown2);
                panel1.Show();
            }
            if(selectedAlgorithm == "Approximate Large Margin Algorithm")
            {
                numeAlgo.Text = selectedAlgorithm;
                Label label1 = new Label();
                label1.Text = "p";
                Label label2 = new Label();
                label2.Text = "alfa";
                label2.Location = new Point(0,30);
                Label label3 = new Label();
                label3.Text = "C";
                label3.Location = new Point(0, 60);
                Label label4 = new Label();
                label4.Text = "Lungime istorie";
                label4.Location = new Point(0, 90);

                Label detalii = new Label();
                detalii.Text = "\n" +
                    " p - parametrul normei"+"\n" +
                    " alfa - determinarea marginii finale intre [0,1]"+"\n" +
                    " C - valoarea implicita este 2 sub radical\n" +
                  
                    "lungime istorie - lungimea vectorului de intrare";
                detalii.AutoSize = true;
                detalii.AutoEllipsis = true;

                NumericUpDown numericUpDownp = new NumericUpDown();
                numericUpDownp.Name = "numericUpDownp"; 
                numericUpDownp.Value = 2;
                numericUpDownp.Maximum = 10;
                numericUpDownp.Minimum = 2;
                numericUpDownp.Increment = 1;
                numericUpDownp.Location = new Point(100, 0);
                numericUpDownp.Font = new Font("Bodoni MT", 8);

                NumericUpDown numericUpDownAlfa = new NumericUpDown();
                numericUpDownAlfa.Name = "numericUpDownAlfa";
                
                numericUpDownAlfa.Value = 0.01m;
                numericUpDownAlfa.Maximum = 1;
                numericUpDownAlfa.Minimum = 0;
                numericUpDownAlfa.DecimalPlaces = 2;
                numericUpDownAlfa.Increment = 0.01m;
                numericUpDownAlfa.Location = new Point(100, 30);
                numericUpDownAlfa.Font = new Font("Bodoni MT", 8);
                


                NumericUpDown numericUpDownC = new NumericUpDown();
                numericUpDownC.Name = "numericUpDownC";
                numericUpDownC.Value = 2;
                numericUpDownC.Maximum = 100000;
                numericUpDownC.Minimum = 2;
                numericUpDownC.Increment = 1;
                numericUpDownC.Location = new Point(100, 60);
                numericUpDownC.Font = new Font("Bodoni MT", 8);
                NumericUpDown numericUpDownF = new NumericUpDown();
                numericUpDownF.Name = "numericUpDownFereastra";
                numericUpDownF.Value = 4;
                numericUpDownF.Maximum = 1000;
                numericUpDownF.Minimum = 1;
                numericUpDownF.Increment = 1;
                numericUpDownF.Location = new Point(100, 90);
                numericUpDownF.Font = new Font("Bodoni MT", 8);

                panel1.Controls.Add(label1);
                panel1.Controls.Add(label2);
                panel1.Controls.Add(label3);
                panel1.Controls.Add(label4);
                panel1.Controls.Add(numericUpDownp);
                panel1.Controls.Add(numericUpDownAlfa);
                panel1.Controls.Add(numericUpDownC);
                panel1.Controls.Add(numericUpDownF);
                panel2.Controls.Add(detalii);
                panel1.Show();


            }
            if (selectedAlgorithm == "Online Gradient Descent")
            {
                numeAlgo.Text = selectedAlgorithm;
                Label label1 = new Label();
                label1.Text = "loss Type";
                Label label2 = new Label();

                label2.Text = "C";
                label2.Location = new Point(0, 30);
                Label label3 = new Label();
                label3.Text = "Lungime istorie";
                label3.Location = new Point(0, 60);
                Label detalii = new Label();
                detalii.Text = "\n" +
                    " lossType - tipul formulei de calcul a pierderii unde \n 0 - 0-1 loss \n 1 - hinge loss \n 2 - logistic loss \n 3 - square loss" + "\n" +
                    " C – constanta ce ajuta la aflarea pasului \n de invatare " + "\n"+
                    "lungime istorie - reprezinta lungimea vectorului \n de intrare";
                detalii.AutoSize = true;
                detalii.AutoEllipsis = true;


                NumericUpDown numericUpDownLoss = new NumericUpDown();
                numericUpDownLoss.Name = "numericUpDownLoss";
                numericUpDownLoss.Value = 0;
                numericUpDownLoss.Maximum = 3;
                numericUpDownLoss.Minimum = 0;
                numericUpDownLoss.Increment = 1;
                numericUpDownLoss.Location = new Point(100, 0);
                numericUpDownLoss.Font = new Font("Bodoni MT", 8);

                NumericUpDown numericUpDownC = new NumericUpDown();
                numericUpDownC.Name = "numericUpDownC";
                numericUpDownC.Value = 1;
                numericUpDownC.Maximum = 5;
                numericUpDownC.Minimum = 1;
                numericUpDownC.Increment = 1;
                numericUpDownC.Location = new Point(100, 30);
                numericUpDownC.Font = new Font("Bodoni MT", 8);

                NumericUpDown numericUpDownF = new NumericUpDown();
                numericUpDownF.Name = "numericUpDownFereastra";
                numericUpDownF.Value = 4;
                numericUpDownF.Maximum = 100;
                numericUpDownF.Minimum = 1;
                numericUpDownF.Increment = 1;
                numericUpDownF.Location = new Point(100, 60);
                numericUpDownF.Font = new Font("Bodoni MT", 8);

                panel1.Controls.Add(label1);
                panel1.Controls.Add(label2);
                panel1.Controls.Add(label3);
                panel1.Controls.Add(numericUpDownF);
                panel1.Controls.Add(numericUpDownLoss);
                panel1.Controls.Add(numericUpDownC);
                panel2.Controls.Add(detalii);
                panel1.Show();

            }
            if (selectedAlgorithm == "Second-Order Perceptron" || selectedAlgorithm== "Confidence Weighted algorithm")
            {
                numeAlgo.Text = selectedAlgorithm;

                Label label1 = new Label();
                label1.Text = "a";
                Label label2 = new Label();
                label2.Text = "Lungime istorie";
                label2.Location = new Point(0,30);
                Label detalii = new Label();
                detalii.Text = "\n" +
                    "a - folosit pentru initializarea matricei ∑" + "\n" +
                    "lungime istorie - reprezinta lungimea vectorului \n de intrare";
                detalii.AutoSize = true;
                detalii.AutoEllipsis = true;

                NumericUpDown numericUpDownA = new NumericUpDown();
                numericUpDownA.Name = "numericUpDownA";
                numericUpDownA.Value = 1;
                numericUpDownA.Maximum = 100;
                numericUpDownA.Minimum = 1;
                numericUpDownA.Increment = 1;
                numericUpDownA.Location = new Point(100, 0);
                numericUpDownA.Font = new Font("Bodoni MT", 8);

                NumericUpDown numericUpDownF = new NumericUpDown();
                numericUpDownF.Name = "numericUpDownFereastra";
                numericUpDownF.Value = 4;
                numericUpDownF.Maximum = 100;
                numericUpDownF.Minimum = 1;
                numericUpDownF.Increment = 1;
                numericUpDownF.Location = new Point(100, 30);
                numericUpDownF.Font = new Font("Bodoni MT", 8);
                
                panel1.Controls.Add(label1);
                panel1.Controls.Add(label2);
                panel1.Controls.Add(numericUpDownA);
                panel1.Controls.Add(numericUpDownF);
                panel2.Controls.Add(detalii);
                
                panel1.Show();

            }
            if (selectedAlgorithm == "Multiclass Perceptron" || selectedAlgorithm == "Multiclass Online Gradient Descent")
            {
                numeAlgo.Text = selectedAlgorithm;

                Label label1 = new Label();
                label1.Text = "Lungime istorie";
                label1.Location = new Point(0, 0);
                Label detalii = new Label();
                detalii.Text = "\n" +
                    "lungime istorie - reprezinta lungimea vectorului \n de intrare";
                detalii.AutoSize = true;
                detalii.AutoEllipsis = true;

                NumericUpDown numericUpDownF = new NumericUpDown();
                numericUpDownF.Name = "numericUpDownFereastra";
                numericUpDownF.Value = 4;
                numericUpDownF.Maximum = 100;
                numericUpDownF.Minimum = 3;
                numericUpDownF.Increment = 1;
                numericUpDownF.Location = new Point(100, 0);
                numericUpDownF.Font = new Font("Bodoni MT", 8);

                panel1.Controls.Add(label1);
                panel1.Controls.Add(numericUpDownF);
                panel2.Controls.Add(detalii);
                panel1.Show();
            }
            // add your new algo here
            if (selectedAlgorithm == "newAlgo" )
            {
                numeAlgo.Text = selectedAlgorithm;

                Label label1 = new Label();
                label1.Text = "Lungime istorie";
                label1.Location = new Point(0, 0);
                Label detalii = new Label();
                detalii.Text = "\n" +
                    "lungime istorie - reprezinta lungimea vectorului \n de intrare";
                detalii.AutoSize = true;
                detalii.AutoEllipsis = true;

                NumericUpDown numericUpDownF = new NumericUpDown();
                numericUpDownF.Name = "numericUpDownFereastra";
                numericUpDownF.Value = 4;
                numericUpDownF.Maximum = 100;
                numericUpDownF.Minimum = 3;
                numericUpDownF.Increment = 1;
                numericUpDownF.Location = new Point(100, 0);
                numericUpDownF.Font = new Font("Bodoni MT", 8);

                panel1.Controls.Add(label1);
                panel1.Controls.Add(numericUpDownF);
                panel2.Controls.Add(detalii);
                panel1.Show();
            }


            if (e.NewValue == CheckState.Checked && checkedListBox.CheckedItems.Count > 0)
                 {
                     checkedListBox.ItemCheck -= checkedListBox_ItemCheck;
                     checkedListBox.SetItemChecked(checkedListBox.CheckedIndices[0], false);
                     checkedListBox.ItemCheck += checkedListBox_ItemCheck;
                 }
            }

        private void checkedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Predictor predictor = new Predictor();
           
            
 

            if (algoritmi.Count == 0)
            {
                MessageBox.Show("Selectati un algoritm!", "Erroare",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            else
            {
                if (filename.Text == "label1")
                {
                    MessageBox.Show("Selectati un fisier .mat pentru a simula!", "Erroare",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    List<double> acuratete = new List<double>();
                    for (int i = 0; i < algoritmi.Count; i++)
                    {
                         acuratete.Add(predictor.predict(algoritmi[i], filename.Text));

                       
                    }
                    
                        new Afisare().draw(acuratete, denumireAlgoritmi);
                    
                }
            }

           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if(openFileDialog1.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                string strfilename = openFileDialog1.FileName;
              
                filename.Text = strfilename;
                string ext = Path.GetExtension(filename.Text);
                if (ext != ".mat")
                {

                    MessageBox.Show("Formatul fisierului este gresit!"+"\n Selectati un fisier .mat !", "Erroare",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                    filename.Text = "label1";
                }
            }
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {


           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // vede algo selectat ia parametrii si ii pune intr-o lista de algoritmi
            
            IAlgoritmPredictie algoritm = null;
            string numeAlgoritm = "";
            int numberHistory = 4;
            int p = 0;
            double alfa = 0;
            double C = Math.Sqrt(2);
            switch (numeAlgo.Text)
            {

                case "Passive-Aggressive learning algorithm":

                    foreach (Control childc in panel1.Controls)
                    {

                        if (childc.Name == "numericUpDownFereastra")
                        {
                            numberHistory = Int16.Parse(childc.Text);
                        }
  

                    }
                    algoritm = new AlgoPA(1, numberHistory);
                    numeAlgoritm += "PA" + " lungime istorie = " + numberHistory;
                    break;

                    
                case "Perceptron":

                    foreach (Control childc in panel1.Controls)
                    {

                        if (childc.Name == "numericUpDownFereastra")
                        {
                            numberHistory = Int16.Parse(childc.Text);
                        }
                    }
                    algoritm = new AlgoPerceptron(numberHistory);
                    numeAlgoritm += "Perceptron " + "lungime istorie = " + numberHistory;
                    break;
                case "Approximate Large Margin Algorithm":
                    
                    foreach (Control childc in panel1.Controls)
                    {

                        if (childc.Name == "numericUpDownFereastra")
                        {
                            numberHistory = Int16.Parse(childc.Text);
                        }
                    }
                    foreach (Control childc in panel1.Controls)
                    {

                        if (childc.Name == "numericUpDownp")
                        {
                            p = Int16.Parse(childc.Text);


                        }
                        if (childc.Name == "numericUpDownAlfa")
                        {
                            alfa = Double.Parse(childc.Text);


                        }
                        if (childc.Name == "numericUpDownC")
                        {
                            C = Math.Sqrt(Double.Parse(childc.Text));


                        }
                        
                        

                    }
                    algoritm = new AlgoALMA(p, alfa, C, (1 / alfa), numberHistory);
                    numeAlgoritm += "ALMA" + " p= " + p + " alfa= " + alfa + " C= " + C + "\n lungime istorie = " + numberHistory;



                    break;
                case "Relaxed Online Maximum Margin Algorithm":
                    foreach (Control childc in panel1.Controls)
                    {

                        if (childc.Name == "numericUpDownFereastra")
                        {
                            numberHistory = Int16.Parse(childc.Text);
                        }
                    }
                    algoritm = new AlgoROMMA(numberHistory);
                    numeAlgoritm += "ROMMA" + " lungime istorie = " + numberHistory;
                    break;
                case "Online Gradient Descent":
                    int Cogd = 0;
                    int loseType = 0;
                    foreach (Control childc in panel1.Controls)
                    {

                        if (childc.Name == "numericUpDownFereastra")
                        {
                            numberHistory = Int16.Parse(childc.Text);
                        }
                  
                        if (childc.Name == "numericUpDownC")
                        {
                            Cogd = Int16.Parse(childc.Text);


                        }
                        if (childc.Name == "numericUpDownLoss")
                        {
                            loseType = Int16.Parse(childc.Text);


                        }
                       
                    }
                    algoritm = new AlgoOGD(loseType, Cogd, numberHistory);
                    numeAlgoritm += "OGD" + " lossType= " + loseType + " C= " + Cogd  + " lungime istorie = " + numberHistory;
                    break;
                case "Second-Order Perceptron":
                    int a = 1;
                    foreach (Control childc in panel1.Controls)
                    {

                        if (childc.Name == "numericUpDownFereastra")
                        {
                            numberHistory = Int16.Parse(childc.Text);
                        }
                        if (childc.Name == "numericUpDownA")
                        {
                            a = Int16.Parse(childc.Text);


                        }
                       

                    }
                    algoritm = new AlgoSOP(a, numberHistory);
                    numeAlgoritm += "SOP" + " a= " + a  + " lungime istorie = " + numberHistory;
                    break;
                case "Confidence Weighted algorithm":
                    int A = 0;
                    foreach (Control childc in panel1.Controls)
                    {

                        if (childc.Name == "numericUpDownFereastra")
                        {
                            numberHistory = Int16.Parse(childc.Text);
                        }
                    
                   
                        if (childc.Name == "numericUpDownA")
                        {
                            A = Int16.Parse(childc.Text);


                        }
                       

                    }
                    algoritm = new AlgoCW(A, numberHistory);
                    numeAlgoritm += "CW" + " a= " + A + " lungime istorie = " + numberHistory;

                    break;
                case "Multiclass Perceptron":

                    foreach (Control childc in panel1.Controls)
                    {

                        if (childc.Name == "numericUpDownFereastra")
                        {
                            numberHistory = Int16.Parse(childc.Text);
                        }
                    }


                    algoritm = new AlgoMPerceptron(numberHistory);
                    numeAlgoritm += "MPerceptron " + "lungime istorie = " + numberHistory;
                    break;
                case "Multiclass Online Gradient Descent":

                    foreach (Control childc in panel1.Controls)
                    {

                        if (childc.Name == "numericUpDownFereastra")
                        {
                            numberHistory = Int16.Parse(childc.Text);
                        }
                    }


                    algoritm = new AlgoMPerceptron(numberHistory);
                    numeAlgoritm += "MOGD " + "lungime istorie = " + numberHistory;
                    break;
                case "newAlgo ":

                    foreach (Control childc in panel1.Controls)
                    {

                        if (childc.Name == "numericUpDownFereastra")
                        {
                            numberHistory = Int16.Parse(childc.Text);
                        }
                    }

                    //algoritm = new NumeleClaseiNoi(numberHistory,daca este cazul alti parametrii); !!
                    numeAlgoritm += "yourAlgoName " + "lungime istorie = " + numberHistory;// se adauga si alti parametri daca este cazul


                    break;
            }

           
            if (denumireAlgoritmi.Contains(numeAlgoritm))
            {
                MessageBox.Show("Configuratia a fost alesa deja!" + "\n Selectati alta configuratie !", "Erroare",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                denumireAlgoritmi.Add(numeAlgoritm);
                algoritmi.Add(algoritm);
            }

            Label label = new Label();
            label.AutoSize = true;
            for (int i = 0; i < denumireAlgoritmi.Count; i++)
            {
                
                label.Text += denumireAlgoritmi[i]+"\n";
            }
            panel3.Controls.Add(label);

            if (denumireAlgoritmi!= null)
            {
                startButton.Visible = true;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
          
        }
    }
}
