using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace KonyvtariNyilvantarto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    class KonyvAdatok
    {
        public int KönyvID { get; set; }
        public string Szerző { get; set; }
        public string Cím { get; set; }
        public string Kiadás_Éve { get; set; }
        public string Kiadó { get; set; }
        public bool Kölcsönözhető { get; set; }
        public KonyvAdatok(string sor)
        {
            string[] resz = sor.Split(';');
            KönyvID = int.Parse(resz[0]);
            Szerző = resz[1];
            Cím = resz[2];
            Kiadás_Éve = resz[3];
            Kiadó = resz[4];
            Kölcsönözhető = bool.Parse(resz[5]);
        }

    }

    class TagAdatok
    {
        public int TagID { get; set; }
        public string Név { get; set; }
        public string Szül_dátum { get; set; }
        public int Irányítószám { get; set; }
        public string Település { get; set; }
        public string Utca_Házszám { get; set; }
        public TagAdatok(string sor)
        {
            string[] resz = sor.Split(';');
            TagID = int.Parse(resz[0]);
            Név = resz[1];
            Szül_dátum = resz[2];
            Irányítószám = int.Parse(resz[3]);
            Település = resz[4];
            Utca_Házszám = resz[5];
        }
    }

    class KolcsonzesAdatok
    {
        public int KölcsönzésID { get; set; }
        public int TagID { get; set; }
        public int KönyvID { get; set; }
        public string KölcsönzésDátuma { get; set; }
        public string VisszavételDátuma { get; set; }
        public KolcsonzesAdatok(string sor)
        {
            string[] resz = sor.Split(';');
            KölcsönzésID = int.Parse(resz[0]);
            TagID = int.Parse(resz[1]);
            KönyvID = int.Parse(resz[2]);
            KölcsönzésDátuma = resz[3];
            VisszavételDátuma = resz[4];
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            KonyvekBeolvasasa("konyvek.txt");
            TagokBeolvasasa("tagok.txt");
            KolcsonzesekBeolvasasa("kolcsonzesek.txt");
        }

        void KonyvekBeolvasasa(string fajlnev)
        {
            List<KonyvAdatok> konyvadatok = new List<KonyvAdatok>();
            foreach (var item in File.ReadAllLines(fajlnev))
            {
                konyvadatok.Add(new KonyvAdatok(item));
            }

            konyvek.ItemsSource = konyvadatok;
        }

        void TagokBeolvasasa(string fajlnev)
        {
            List<TagAdatok> tagadatok = new List<TagAdatok>();
            foreach (var item in File.ReadAllLines(fajlnev))
            {
                tagadatok.Add(new TagAdatok(item));
            }

            tagok.ItemsSource = tagadatok;
        }

        void KolcsonzesekBeolvasasa(string fajlnev)
        {
            List<KolcsonzesAdatok> kolcsonzesadatok = new List<KolcsonzesAdatok>();
            foreach (var item in File.ReadAllLines(fajlnev))
            {
                kolcsonzesadatok.Add(new KolcsonzesAdatok(item));
            }

            kolcsonzesek.ItemsSource = kolcsonzesadatok;
        }
    }
}
