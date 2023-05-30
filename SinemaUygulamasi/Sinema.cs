using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinemaUygulamasi
{
    internal class Sinema
    {
        public string FilmAdi { get; }
        public int Kapasite{ get; }
        public int TamBiletFiyati{ get; set; }
        public int YarimBiletFiyati{ get; set; }
        public int ToplamTamBiletAdeti{ get; private set; }
        public int ToplamYarimBiletAdeti{ get; private set; }
        public float Ciro
        {
            get
            {
                return this.ToplamTamBiletAdeti * this.TamBiletFiyati + this.ToplamYarimBiletAdeti * this.YarimBiletFiyati;
            }


        }        
            

        public Sinema(string filmAdi, int kap, int tamBiletFiyati, int yarimBiletFiyati)
        {
            this.FilmAdi = filmAdi;
            this.Kapasite = kap;
            this.TamBiletFiyati = tamBiletFiyati;
            this.YarimBiletFiyati = yarimBiletFiyati;
        }
        public void BiletSatisi(int tamBiletAdeti, int yarimBiletAdeti)
        {
            if (tamBiletAdeti + yarimBiletAdeti <= BosKoltukAdedi())
            {
                this.ToplamTamBiletAdeti += tamBiletAdeti;
                this.ToplamYarimBiletAdeti += yarimBiletAdeti;

                //CiroHesapla();
                Console.WriteLine("İşlem Gerçekleştirildi.");
            }
            
            else
            {
                Console.WriteLine(BosKoltukAdedi() +" adet boş koltuk olduğundan işlem gerçekleşmedi. ");
            }
        }

        //private void CiroHesapla()  
        //{
        //    this.Ciro = this.ToplamTamBiletAdeti * this.TamBiletFiyati + this.ToplamYarimBiletAdeti * this.YarimBiletFiyati;
        //}
        public void BiletIadesi(int tamBiletAdeti, int yarimBiletAdeti)
        {
            if (tamBiletAdeti <= this.ToplamTamBiletAdeti && yarimBiletAdeti <= this.ToplamYarimBiletAdeti)
            {
                this.ToplamTamBiletAdeti -= tamBiletAdeti;
                this.ToplamYarimBiletAdeti -= yarimBiletAdeti;
               // CiroHesapla();

                Console.WriteLine("İşlem Gerçekleştirildi.");
            }
            else
            {
                Console.WriteLine("Satılmış olan bilet adetinden fazla iade yapılamaz. ");
            }
        }

        public int BosKoltukAdedi()
        {
            int Bos = this.Kapasite -this.ToplamTamBiletAdeti -this.ToplamYarimBiletAdeti;
            return Bos;
        }
    }
}
