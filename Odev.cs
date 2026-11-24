using System;
using System.Collections.Generic;

namespace AkilliEvProjesi
{
    enum CihazTuru
    {
        Lamba,
        Klima,
        GuvenlikSistemi
    }

    class Cihaz
    {
        public int Kimlik { get; set; }
        public string Ad { get; set; }
        public CihazTuru Tur { get; set; }
        public bool AcikMi { get; set; }

        public Cihaz(int kimlik, string ad, CihazTuru tur)
        {
            Kimlik = kimlik;
            Ad = ad;
            Tur = tur;
            AcikMi = false;
        }

        public void Ac()
        {
            AcikMi = true;
        }

        public void Kapat()
        {
            AcikMi = false;
        }
        public void BilgileriGoster()
        {
            string durum = AcikMi ? "Açık" : "Kapalı";
            Console.WriteLine($"Kimlik: {Kimlik} | Ad: {Ad} | Tür: {Tur} | Durum: {durum}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Cihaz> cihazlar = new List<Cihaz>();
            cihazlar.Add(new Cihaz(1, "Salon Lambası", CihazTuru.Lamba));
            cihazlar.Add(new Cihaz(2, "Yatak Odası Kliması", CihazTuru.Klima));
            cihazlar.Add(new Cihaz(3, "Giriş Güvenlik Sistemi", CihazTuru.GuvenlikSistemi));

            while (true)
            {
                Console.WriteLine("\n--- AKILLI EV SİSTEMİ ---");
                Console.WriteLine("1- Cihazları Listele");
                Console.WriteLine("2- Yeni Cihaz Ekle");
                Console.WriteLine("3- Cihaz Aç");
                Console.WriteLine("4- Cihaz Kapat");
                Console.WriteLine("5- Çıkış");
                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine();

                if (secim == "1")
                {
                    Console.WriteLine("\n--- Cihaz Listesi ---");
                    foreach (Cihaz c in cihazlar)
                    {
                        c.BilgileriGoster();
                    }
                }
                else if (secim == "2")
                {
                    Console.Write("Cihaz Kimliği (ID): ");
                    int yeniKimlik = int.Parse(Console.ReadLine());

                    bool ayniIdVarMi = false;
                    foreach (Cihaz c in cihazlar)
                    {
                        if (c.Kimlik == yeniKimlik)
                        {
                            ayniIdVarMi = true;
                            break;
                        }
                    }

                    if (ayniIdVarMi)
                    {
                        Console.WriteLine($"Hata: {yeniKimlik} kimliğine sahip bir cihaz zaten var!");
                    }
                    else
                    {
                        Console.Write("Cihaz Adı: ");
                        string yeniAd = Console.ReadLine();

                        Console.Write("Cihaz Türü Seçin (1: Lamba, 2: Klima, 3: Güvenlik Sistemi): ");
                        int turSecim = int.Parse(Console.ReadLine());

                        CihazTuru secilenTur = CihazTuru.Lamba;
                        if (turSecim == 1)
                        {
                            secilenTur = CihazTuru.Lamba;
                        }
                        else if (turSecim == 2)
                        {
                            secilenTur = CihazTuru.Klima;
                        }
                        else if (turSecim == 3)
                        {
                            secilenTur = CihazTuru.GuvenlikSistemi;
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz tür girdiniz, varsayılan olarak Lamba seçildi.");
                        }

                        Cihaz yeniCihaz = new Cihaz(yeniKimlik, yeniAd, secilenTur);
                        cihazlar.Add(yeniCihaz);
                        Console.WriteLine($"{yeniAd} başarıyla eklendi.");
                    }
                }
                else if (secim == "3")
                {
                    Console.Write("Açılacak cihazın kimliği: ");
                    int id = int.Parse(Console.ReadLine());

                    Cihaz bulunan = null;
                    foreach (Cihaz c in cihazlar)
                    {
                        if (c.Kimlik == id)
                        {
                            bulunan = c;
                            break;
                        }
                    }

                    if (bulunan == null)
                    {
                        Console.WriteLine($"Hata: {id} kimliğine sahip bir cihaz bulunamadı!");
                    }
                    else
                    {
                        bulunan.Ac();
                        Console.WriteLine($"{bulunan.Ad} açıldı.");
                    }
                }
                else if (secim == "4")
                {
                    Console.Write("Kapatılacak cihazın kimliği: ");
                    int id = int.Parse(Console.ReadLine());

                    Cihaz bulunan = null;
                    foreach (Cihaz c in cihazlar)
                    {
                        if (c.Kimlik == id)
                        {
                            bulunan = c;
                            break;
                        }
                    }

                    if (bulunan == null)
                    {
                        Console.WriteLine($"Hata: {id} kimliğine sahip bir cihaz bulunamadı!");
                    }
                    else
                    {
                        bulunan.Kapat();
                        Console.WriteLine($"{bulunan.Ad} kapatıldı.");
                    }
                }
                else if (secim == "5")
                {
                    Console.WriteLine("Çıkış yapılıyor...");
                    break;
                }
                else
                {
                    Console.WriteLine("Hatalı seçim yaptınız, tekrar deneyin.");
                }
            }
        }
    }
}
