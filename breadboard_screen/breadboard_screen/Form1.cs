using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace breadboard_screen
{
   
    public partial class Form1 : Form
    {
        static int DATA = 0;
        static int ADDRESS = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] komando = GenereraKomandoData();
            tbxKomandoAddresser.Text = komando[1];
            tbxKomandoData.Text = komando[0];
            string[] tecken = GenereraTeckenData();
            tbxTeckenAddress.Text = komando[1];
            tbxTeckenData.Text = komando[0];
        }

        private string[] GenereraTeckenData()
        {
            int D0 = 1;
            int D1 = 2;
            int D2 = 4;
            int D3 = 8;
            int D4 = 16;
            int D5 = 32;
            int D6 = 64;
            int D7 = 128;
            int S0 = 256;
            int S1 = 512;
            int L = 1024;

            string[] svar = { "", "" };

            //normalmode 1:1
            for (int i = 0; i < Math.Pow(2, 8); i++)
            {
                svar[DATA] += ToBinary(i) + ",\n";
                svar[ADDRESS] += (i).ToString() + ",\n";
            }
            for(int j = 0; j < 4; j++)
            {
                for (int i = 0; i < Math.Pow(2, 8); i++)
                {
                    string tal = i.ToString();
                    //Detta måste ändras och tänkas över!!!
                    if (j >= tal.Length)
                    {
                        svar[DATA] += "B00000001";
                    }
                    //detta fungerar troligtvis inte eftersom displayen inte använder ascii
                    else
                    {
                        svar[DATA] += "B" + ToBinary((int)tal[j]) +  ",\n";
                    }
                    //Kom på rätt data!
                   // svar[DATA] += ToBinary(i) + ",\n";
                    svar[ADDRESS] += (i + L + j * S0).ToString() + ",\n";
                }
            }
            return svar;
        }

        private string[] GenereraKomandoData()
        {

            string[] svar = {"", "" };
            int B0 = 128;
            int B1 = 64;
            int B2 = 32;
            int B3 = 16;
            int B4 = 8;
            int B5 = 4;
            int B6 = 2;
            int B7 = 1;
            int S0 = 256;
            int S1 = 512;
            int S2 = 1024;
            int S3 = 2048;
            int Null0 = 4096;
            //Ändringsbara                                                           --                                       --    -----------
            string[] uppstartSekvens = { "B00110000", "B00110000", "B00110000", "B00111100", "B00001000", "B00000001", "B00000110", "B00000110"};
            //Skapar starten genom att köra igenom att den inte bryr sig av vad datan är

            int test = (int)Math.Pow(2, 8);
            //för varje uppstartsteg
            for (int j = 0; j < 8; j++)
            {
                for (int i = 0; i < Math.Pow(2, 8); i++)
                {
                    svar[DATA] += uppstartSekvens[j] + ",\n";
                    svar[ADDRESS] += (i + S0 * j).ToString() + ",\n";
                }
            }

            //för övriga komandon
            for (int j = 8; j < 16; j++)
            {
                for (int i = 0; i < Math.Pow(2, 8); i++)
                {
                    svar[DATA] += "B" + ToBinary(i) + ",\n";
                    svar[ADDRESS] += (i + S0 * j).ToString() + ",\n";
                }
            }
            return svar;
        }

        public static string ToBinary(int myValue)
        {
            string binVal = Convert.ToString(myValue, 2);
            int bits = 0;
            int bitblock = 8;

            for (int i = 0; i < binVal.Length; i = i + bitblock)
            { bits += bitblock; }

            return binVal.PadLeft(bits, '0');
        }
    }
}
