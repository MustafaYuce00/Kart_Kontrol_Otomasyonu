using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uygulama2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
        }
        string KartNoTemizle(string text)
        {
            text = text.Replace("-", "").Replace(" ", "").Replace("(", "").Replace(")", "").Replace("_", "");
            return text;
        }
        bool KartNoUzunlukKontrol(string kartno)
        {
            if (kartno.Length == 16)
                return true;
            else
                return false;
        }
        bool SayisalDegerKontrol(string deger)
        {
            foreach (char chr in deger)
            {
                if (!Char.IsNumber(chr)) return false;
            }
            return true;
        }
        int SayiBasamaklariTopla(int sayi)
        {
            int toplam = 0;
            while (sayi > 0)
            {
                toplam += sayi % 10;
                sayi /= 10;
            }
            return toplam;
        }
        bool Kredi_Kart_Lunh_Algoritmasi(string kartno)
        {
            kartno = KartNoTemizle(kartno); // kart numarasını temizledik.

            if (KartNoUzunlukKontrol(kartno) == false) // uzunluğu kontrol ettik
                return false;
            else if (SayisalDegerKontrol(kartno) == false) // sayısal değerleri kontrol ettik
                return false;
            else
            {
                int ciftlerin_toplami = 0;
                int teklerin_toplami = 0;
                for (int i = 0; i < kartno.Length; i++)
                {
                    int eleman = Convert.ToInt32(kartno[i].ToString());
                    if (i % 2 == 0)
                        ciftlerin_toplami += SayiBasamaklariTopla(eleman * 2);
                    else
                        teklerin_toplami += eleman;
                }
                int sonuc = (teklerin_toplami + ciftlerin_toplami) % 10;
                if (sonuc == 0)
                    return true;
                else
                    return false;
            }
        }
        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (Kredi_Kart_Lunh_Algoritmasi(maskedTextBox1.Text) == true)
                label2.Text = "Kart No Geçerli";
            else
                label2.Text = "Kart No Geçersiz! Tekrar kontrol ediniz";

            string kart_no = KartNoTemizle(maskedTextBox1.Text);
            label3.Text = Kart_Turu(kart_no);
            label4.Text = BIN_Kodu(kart_no);
            label5.Text = Hesap_No(kart_no);
            label6.Text = Luhn_Kod(kart_no);
            label12.Text = bin_kontrol(kart_no);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Kredi_Kart_Lunh_Algoritmasi(maskedTextBox1.Text) == true)
                label2.Text = "Kart No Geçerli";
            else
                label2.Text = "Kart No Geçersiz! Tekrar kontrol ediniz";

            string kart_no = KartNoTemizle(maskedTextBox1.Text);
            label3.Text = Kart_Turu(kart_no);
            label4.Text = BIN_Kodu(kart_no);
            label5.Text = Hesap_No(kart_no);
            label6.Text = Luhn_Kod(kart_no);
            label12.Text = bin_kontrol(kart_no);

        }
        string Kart_Turu(string kart_no)
        {
            switch (kart_no.Substring(0, 1))
            {   //case "2": goto case "1";
                case "1": return "Hava Yolları Kartı";
                case "2": return "Hava Yolları Kartı";
                case "3": return "Seyahat/Eğlence Kartı";
                case "4": return "Hesap Kartı";
                case "5": return "Hesap Kartı";
                case "6": return "Alışveriş Kartı";
                case "7": return "Akaryakıt Kartı";
                case "8": return "Haberleşme Kartı";
                case "9": return "Uluslararası Kart";
                default: return "Bilinmeyen Kart Türü";
            }
        }
        string bin_kontrol(string kart_no)
        {
            switch (kart_no.Substring(0, 6))
            {
                case "478500": return label12.Text = "İNİNAL";
                case "434727": return label12.Text = "PAYCELL";
                case "979216": return  label12.Text = "KUVEYT TÜRK";
                default: return "Bilinmeyen Kart Türü";     
            }   
        }
        string BIN_Kodu(string kart_no)
        {
            return kart_no.Substring(0, 6);
        }
        string Hesap_No(string kart_no)
        {
            return kart_no.Substring(6, 9);
        }
        string Luhn_Kod(string kart_no)
        {
            return kart_no.Substring(kart_no.Length - 1, 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
