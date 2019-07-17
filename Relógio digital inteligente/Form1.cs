using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Drawing.Text;

namespace Relógio_digital_inteligente
{
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            
            InitializeComponent();
      
           textBox1.Visible = false;
            pictureBox1.Visible = true;
            label1.Visible = true;
            Chamarbotao();
        }

        SpeechRecognitionEngine sRecognize = new SpeechRecognitionEngine();
        private const int CS_DropShadow = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                 CreateParams cp = base.CreateParams;
                cp.ClassStyle = CS_DropShadow;
                return cp;
            }
        }
        public void Chamarbotao() 
        {
            SpeechSynthesizer sSynth = new SpeechSynthesizer();
            PromptBuilder pBuilder = new PromptBuilder();

            Choices sList = new Choices();
            sList.Add(new string[] {"time","close"});
            Grammar gr = new Grammar (new GrammarBuilder(sList));

            try
            {
                sRecognize.RequestRecognizerUpdate();
                sRecognize.LoadGrammar(gr);
                sRecognize.SpeechRecognized += sRecognize_speechRecognized;
                sRecognize.SetInputToDefaultAudioDevice();
                sRecognize.RecognizeAsync(RecognizeMode.Multiple);
                sRecognize.Recognize();
            }
            catch
            {
                return;
            }
        }

        public void fontes(){

            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile("D:/Futured.ttf");
            foreach(Control c in this.Controls)
            {
                c.Font = new Font(pfc.Families[0], 72, FontStyle.Regular);
            }
        }

        private void sRecognize_speechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if(e.Result.Text == "time")
            {
                pictureBox1.Visible = true;
                label1.Visible = true;
            }
            if (e.Result.Text == "close")
            {
                pictureBox1.Visible = false;
                label1.Visible = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string gx;
            DateTime x = new DateTime();
            //label1.Text = x.ToLongTimeString();
            label1.Text = DateTime.Now.ToString("hh:mm:ss");
             gx = DateTime.Now.ToString("hh");
             textBox1.Text = gx;

             int llt;
             llt = Convert.ToInt32(textBox1.Text);
             if (llt >= 8 & llt <= 18)
             {
                 pictureBox1.Image = Relógio_digital_inteligente.Properties.Resources.capcha_00001;
                 label1.ForeColor = Color.FromArgb(224, 181, 5);
                 label1.BackColor = Color.FromArgb(172, 138, 0);
             }
             else
             {
                 pictureBox1.Image = Relógio_digital_inteligente.Properties.Resources.capchat_00000;
                 label1.ForeColor = Color.FromArgb(17, 108, 185);
                 label1.BackColor = Color.FromArgb(0, 55, 101);
             }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            fontes();
            //Choices lista = new Choices();

            //lista.Add(new string[] { "amarillo", "rojo" });

            //Grammar gramatica = new Grammar(new GrammarBuilder(lista));

            //try 
            //{
            //    rec.SetInputToDefaultAudioDevice();
            //    rec.LoadGrammar(gramatica);
            //    rec.SpeechRecognized += reconhecimento;
            //    rec.RecognizeAsync(RecognizeMode.Multiple);
            //}
            //catch (Exception)
            //{
            //    throw;
            //}

        }

        //void reconhecimento(object sender, SpeechRecognizedEventArgs e)
        //{
        //    if (e.Result.Text == "amarillo")
        //    {
        //       
        //    }
        //    else if (e.Result.Text == "rojo")
        //    {
        //      
        //    }
            
            
        //}
    }
}
