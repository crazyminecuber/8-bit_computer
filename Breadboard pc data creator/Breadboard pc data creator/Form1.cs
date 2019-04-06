using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;


namespace Breadboard_pc_data_creator
{
    public partial class Form1 : Form
    {

        /// <summary>
        /// TODO
        /// lägg till ladda från address till registrerna
        /// </summary>
        const int HLT = 1;
        const int RA = 2;
        const int RO = 4;
        const int RI = 8;
        const int AO = 16;
        const int BO = 32;
        const int AI = 64;
        const int BI = 128;
        const int Sub = 256;
        const int UO = 512;
        const int CE = 1024;
        const int CI = 2048;
        const int CO = 4096;
        const int MA = 8192;
        const int IO = 16384;
        const int GO = 32768;
        const int GI = 65536;
        const int II = 131072;
        const int FI = II * 2;
    
        const int Fzero = 1;
        const int Fcarry = 2;

        const int maxInstruktioner = 16;
        const int maxSteg = 8;
        const int maxSignaler = 24;
        const int maxFlag = 4;
        int instNr = 0;



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Instruktion[] NOP = SkapaInstruktion(instNr, new List<int[]>() { new int[] { 0 } });
            Instruktion[] LDA = SkapaInstruktion(instNr, new List<int[]>() { new int[] { MA + RO + AI } });
            Instruktion[] LDB = SkapaInstruktion(instNr, new List<int[]>() { new int[] { MA + RO + BI } });
            Instruktion[] LDG = SkapaInstruktion(instNr, new List<int[]>() { new int[] { MA + RO + GI } });

            //Extra klock cyckel med utput på innan write?
            Instruktion[] STA = SkapaInstruktion(instNr, new List<int[]>() { new int[] { RO + MA + RA, AO + RI } });
            Instruktion[] STB = SkapaInstruktion(instNr, new List<int[]>() { new int[] { RO + MA + RA, BO + RI } });
            Instruktion[] STG = SkapaInstruktion(instNr, new List<int[]>() { new int[] { RO + MA + RA, GO + RI } });

            Instruktion[] ADD = SkapaInstruktion(instNr, new List<int[]>() { new int[] { MA + RO + BI, UO + AI + FI} });
            Instruktion[] SUB = SkapaInstruktion(instNr, new List<int[]>() { new int[] { MA + RO + BI, UO + AI + Sub + FI} });

            Instruktion[] JMP = SkapaInstruktion(instNr, new List<int[]>() { new int[] { MA + RO + CI } });
            Instruktion[] JPZ = SkapaInstruktion(instNr, new List<int[]>() { new int[] { 0 }, new int[] { MA + RO + CI } }, 1);
            Instruktion[] JPC = SkapaInstruktion(instNr, new List<int[]>() { new int[] {0 }, new int[] { MA + RO + CI } }, 2);
            Instruktion[] PRG = SkapaInstruktion(instNr, new List<int[]>() { new int[] {MA + RO + GI} });


            List<Instruktion> instruktioner = new List<Instruktion>();

            instruktioner.AddRange(NOP);    //0
            instruktioner.AddRange(LDA);    //1
            instruktioner.AddRange(LDB);    //2
            instruktioner.AddRange(LDG);    //3
            instruktioner.AddRange(STA);    //4
            instruktioner.AddRange(STB);    //5
            instruktioner.AddRange(STG);    //6
            instruktioner.AddRange(ADD);    //7
            instruktioner.AddRange(SUB);    //8
            instruktioner.AddRange(JMP);    //9
            instruktioner.AddRange(JPZ);    //10
            instruktioner.AddRange(JPC);    //11
            instruktioner.AddRange(PRG);    //12


            while (instruktioner.Count < maxFlag * maxInstruktioner)
                instruktioner.AddRange(SkapaInstruktion(instNr, new List<int[]>() { new int[] { 0 } }));
            string addressText = TextaAddresser(instruktioner);
            tbxAddress.Text = addressText;
            tbxA.Text = TextaData(instruktioner, 0);
            tbxB.Text = TextaData(instruktioner, 1);
            tbxC.Text = TextaData(instruktioner, 2);
            tbxBigAdd.Text = TextaAddresserBin(instruktioner);

        }

        string TextaAddresser(List<Instruktion> instruktioner) 
        {
            string svar = "";
            for (int i = 0; i < maxInstruktioner * maxFlag; i++)
            {
                for (int j = 0; j < maxSteg; j++)
                {

                    svar += instruktioner[i].mictroinstuktioner[j].address.ToString() + ", ";
                }


            }
            return svar;
        }



        string TextaAddresserBin(List<Instruktion> instruktioner)
        {
            string svar = "";
            for (int i = 0; i < maxInstruktioner * maxFlag; i++)
            {
                for (int j = 0; j < maxSteg; j++)
                {
                    string temp = Convert.ToString(instruktioner[i].mictroinstuktioner[j].address, 2);
                    while (temp.Length < 9) temp = temp.Insert(0, "0");
                    temp = temp.Insert(6, "   ");
                    temp = temp.Insert(2, "   ");
                    svar += (temp + ", " + "\r\n");
                }

                svar += "\r\n";

            }
            return svar;
        }



        string TextaData(List<Instruktion> instruktioner, int nr)
        {
            string svar = "";
            for (int i = 0; i < maxInstruktioner * maxFlag; i++)
            {
                for (int j = 0; j < maxSteg; j++)
                {
                    int temp = instruktioner[i].mictroinstuktioner[j].kontroll;
                    string data = Convert.ToString(temp, 2);
                    while (data.Length < maxSignaler)
                    {
                        data = data.Insert(0, "0");
                    }

                    if (nr == 0)
                    {
                        svar += "B" + data.Substring(0, 8) + ", ";
                    }

                    else if (nr == 1)
                    {
                        svar += "B" + data.Substring(8, 8) + ", ";
                    }

                    else if (nr == 2)
                    {
                        svar += "B" + data.Substring(16, 8) + ", ";
                    }

                }
                svar += "\r\n" + "\r\n";

            }
            return svar;
        }

        Instruktion[] SkapaInstruktion(int kod, List<int[]> kontroll, int flag = 0) 
        {
            List<Instruktion> instruktioner = new List<Instruktion>();
            for (int i = 0; i < maxFlag; i++)
            {
                if(i == flag && i != 0) instruktioner.Add(new Instruktion(kod, kontroll[1], flag));
                else if(flag == 3) instruktioner.Add(new Instruktion(kod, kontroll[1], flag));
                else instruktioner.Add(new Instruktion(kod, kontroll[0], i));               
            }
            instNr++;
            return instruktioner.ToArray();
        }













        

        //klassen för en instruktion som sammanfattar allt på ett bra sätt. Varje instruktion har samma start och slut
        class Instruktion
        {
            public List<MicroInstruktion> mictroinstuktioner;
            public int nr;
            public int steg;
            public int flags;
            private bool counterIn = false;
            int[] start = { CO + RA, RO + II };
            int[] slut = { CE };

            public Instruktion(int kod, int[] kontroll, int flag)
            {
                this.nr = kod;
                this.flags = flag;
                this.mictroinstuktioner = SkapaInstruktion(kod, kontroll, flag);
                this.steg = mictroinstuktioner.Count;
            }

            //skapar instruktionenå genom att lägga till start, instruktion och slut för att få komplett instruktion.
           private List<MicroInstruktion> SkapaInstruktion(int kod, int[] kontrollSignaler, int flag)
            {
                List<MicroInstruktion> instruktion = new List<MicroInstruktion>();

                instruktion.AddRange(AddDelInstruktion(kod, start, instruktion.Count, flag));
                instruktion.AddRange(AddDelInstruktion(kod, kontrollSignaler, instruktion.Count, flag));
                instruktion.AddRange(AddDelInstruktion(kod, slut, instruktion.Count, flag));
                if (instruktion.Count > maxSteg) MessageBox.Show("För lång instruktion!!!");
                for (int i = instruktion.Count; i < maxSteg; i++) instruktion.Add(new MicroInstruktion(0, i, kod, flag));
                

                return instruktion;
            }

            //lägger till instruktioner som är int[] till mictroinstruktioner
            List<MicroInstruktion> AddDelInstruktion(int kod, int[] kontrollSignaler, int instruktionerFöre, int flag)
            {
                List<MicroInstruktion> delInstruktion = new List<MicroInstruktion>();
                for (int i = 0; i < kontrollSignaler.Length; i++)
                {
                    MicroInstruktion temp = new MicroInstruktion(kontrollSignaler[i], i + instruktionerFöre, kod, flag);
                    delInstruktion.Add(temp);
                    BitArray A = new BitArray(new int[] { kontrollSignaler[i] });
                    BitArray B = new BitArray(new int[] { CI });
                    BitArray C = A.And(B);
                    for(int k = 0; k < C.Length; k++)
                    {
                        if(C[k])
                        {
                            counterIn = true;
                            break;
                        }
                    }
                }
                return delInstruktion;
            }

        }









        //Class för en nano instruktion det vill säga lagrar information om vad som ska stå på vilken address på de tre eeprommen och vad de olika delarna i addressen är. 
        class MicroInstruktion
        {
            public int kontroll;
            public int address;
            public int steg;
            public int flags;
            public int instruktion;

            public MicroInstruktion(int kontroll, int steg, int instruktion, int flags)
            {
                this.kontroll = kontroll;
                this.steg = steg;
                this.instruktion = instruktion;
                this.flags = flags;
                this.address = steg + shiftTal(instruktion, 3) + shiftTal(flags, 7);
            }

            private int shiftTal(int tal, int shiftSteps)
            {
                if (shiftSteps < 0)
                {
                    for (; shiftSteps < 0; shiftSteps++)
                    {
                        if (tal == 1) tal = 0;
                        else tal /= 2;
                    }
                }
                else
                {
                    for (; shiftSteps > 0; shiftSteps--)
                    {
                        
                        tal *= 2;
                    }
                }
                return tal;
            }
        }

        private void tbxAddress_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
