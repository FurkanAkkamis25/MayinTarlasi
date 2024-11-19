using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MayinTarlasi
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        int skor = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            MayinDoldur(20, 20);
        }
        void MayinDoldur(int mayin,int boyut)
        {
            flowLayoutPanel1.Controls.Clear();
            int[] mayinlar = new int[mayin];
            Random rnd = new Random();
            for(int i=0;i< 20; i++)
            {
               int secilen = rnd.Next(0, boyut * boyut);
                if (mayinlar.Contains(secilen))
                {
                    i--;
                    continue;
                }
                mayinlar[i] = secilen;
            }

            for(int i = 0; i < boyut * boyut; i++)
            {
                Button btn = new Button();
                btn.Width = 25;
                btn.Height = 25;
                btn.Margin = new Padding(0);
                btn.Tag = mayinlar.Contains(i);
                btn.Click += btn_click;
                flowLayoutPanel1.Controls.Add(btn);
            }
        }
        void btn_click(object sender,EventArgs e)
        {
            Button tiklanan = (Button)sender;
            bool durum = (bool)tiklanan.Tag;
            if (durum == true)
            {
                tiklanan.BackColor = Color.Red;
                oyunBitir(); 
            }
            else
            {
                tiklanan.BackColor = Color.Green;
                skor++;
                textBox1.Text = skor.ToString();
            }

        }
        void oyunBitir()
        {
            skor = 0;
            foreach(Button item in flowLayoutPanel1.Controls)
            {
                bool durum = (bool)item.Tag;
                if (durum)
                {
                    item.BackColor = Color.Red;
                }
                else
                {
                    item.BackColor = Color.Green;
                }
            }
          DialogResult sonuc=  MessageBox.Show("Oyun Bitti :( Yeniden Oynamak İster Misiniz ?","İster Misiniz ?",MessageBoxButtons.YesNo);
            if (sonuc == DialogResult.Yes)
                MayinDoldur(20, 20);
        }
      
    }
}
