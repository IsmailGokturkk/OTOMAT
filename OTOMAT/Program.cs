using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTOMAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] urun = new string[3];

            urun[0] = "0-kola";
            urun[1] = "1-Bisküvi";
            urun[2] = "2-Çikolata";

            int[] fiyat = new int[3];

            fiyat[0] = 7;
            fiyat[1] = 3;
            fiyat[2] = 2;

        BAS:
            int password = 111;    
       
            Console.WriteLine("Lütfen müşteri için 1\nYetkili için 2'i seçiniz");
            string girici=Console.ReadLine();

            int bakiye = 0;

        CIKIS:
            
            bakiye = 0;

            if (girici == "1")
            {
                
                foreach(string item in urun)
                {
                    Console.WriteLine(item);
                }
               GERİ:
                Console.WriteLine("Lütfen alamk istediğiniz ürünün numarasını giriniz seçiniz\n");
                int secim = Convert.ToInt32(Console.ReadLine());
                
                if(secim>=0||secim<urun.Length) {               

                    Console.WriteLine("Almak istediğiniz ürünün fiyatı:" + fiyat[secim]);

                    Console.WriteLine("Lütfen ödemeyi yapınız");
                
                    BAKIYE:
                    if (bakiye >= fiyat[secim])
                    {
                        bakiye -= fiyat[secim];

                        Console.WriteLine("Ödeme başarılı kalan bakiyeniz=" + bakiye);
                    }
                    else
                    {
                        Console.WriteLine("Yetersiz bakiye");
                        Console.WriteLine("Lütfen para giriniz");
                        bakiye = Convert.ToInt32(Console.ReadLine());
                        goto BAKIYE;
                    }
                }
                else
                {
                    Console.WriteLine("Hatalı ürün numarası girişi");
                                 }
            SECİM:
                Console.WriteLine("Lütfen çıkış yapmak için 1\nGeri dönmek için 2'w basınız");
                int geri = Convert.ToInt32(Console.ReadLine());

                if (geri == 1)
                {
                    Console.WriteLine("Para üstünüz=" + bakiye);
                    goto BAS;
                }
                else if (geri == 2)
                {
                    goto GERİ;
                }
                else
                {
                    Console.WriteLine("Lütfen 1 veya 2 seçiniz");
                    goto SECİM;
                }
          
            }
            else if(girici == "2")
            {
               SIFRE:
                Console.WriteLine("Lütfen şifrenizi giriniz");
                int sifre=Convert.ToInt32(Console.ReadLine());
                if (sifre == password)
                {
                    Console.WriteLine("Giriş başarılı");

                    DSECİM:
                    Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz\nFiyatları güncellemek için 1\nYeni ürün eklemek için 2");
                    string yetki=Console.ReadLine();
                    GERİ1:
                    if(yetki == "1")
                    {
                        USECİM:
                        Console.WriteLine("Güncellemek istediğiniz ürününün numarasını giriniz");
                        int fiyatGüncel=Convert.ToInt32(Console.ReadLine());
                        if (fiyatGüncel >= 0 || fiyatGüncel < urun.Length)
                        {
                            Console.WriteLine("Lütfen yeni fiyatı giriniz");
                            int yenifiyat = Convert.ToInt32(Console.ReadLine());

                            fiyat[fiyatGüncel] = yenifiyat;

                            Console.WriteLine("Ürünün yeni fiyatı=" + yenifiyat);
                        }
                        else
                        {
                            Console.WriteLine("Hatalı ürün seçimi");
                            goto USECİM;
                        }

                    }
                    else if (yetki == "2")
                    {
                        Console.WriteLine("Lütfen eklemek istediğiniz ürünün adını yazınız");
                        string yeniurun=Console.ReadLine();

                       
                        Console.Write("Yeni ürün fiyatını girin: ");
                        int yeniUrunFiyati = int.Parse(Console.ReadLine());

                        Array.Resize(ref urun, urun.Length + 1);
                        Array.Resize(ref fiyat, fiyat.Length + 1);

                        urun[urun.Length-1] = yeniurun;
                        fiyat[urun.Length-1] = yeniUrunFiyati;
                    }
                    else
                    { Console.WriteLine("Hatalı seçim"); }
                    SECİM1:
                    Console.WriteLine("Lütfen çıkış yapmak için 1\nGeri dönmek için 2'w basınız");
                    int geri = Convert.ToInt32(Console.ReadLine());

                    if (geri == 1)
                    {
                        Console.WriteLine("Para üstünüz=" + bakiye);
                        goto BAS;
                    }
                    else if (geri == 2)
                    {
                        goto GERİ1;
                    }
                    else
                    {
                        Console.WriteLine("Lütfen 1 veya 2 seçiniz");
                        goto SECİM1;
                    }
                }
                else
                {
                    Console.WriteLine("Hatalı parola\nLütfen tekrar deneyiniz");
                    goto SIFRE;
                }
            }
            else
            {
                Console.WriteLine("Hatalı secim lütfen yeniden deneyiniz");
                goto CIKIS;        
            }
        Console.ReadLine();
        }
    }
}
