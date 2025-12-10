using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfUrhajok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Urhajo
        {
            public string Nev {  get; set; }
            public int Legenyseg { get; set; }
            public int MaxHatotav { get; set; }
            public int UzemanyagSzint { get; set; }
            public string Gyarto {  get; set; }
            public string KuldetesStatusz { get; set; }
            public int InditasEve {  get; set; }

            public Urhajo(string nev, int legenyseg, int maxHatotav, int uzemanyagSzint, string gyarto, string kuldetesStatusz, int inditasEve)
            {
                Nev = nev;
                Legenyseg = legenyseg;
                MaxHatotav = maxHatotav;
                UzemanyagSzint = uzemanyagSzint;
                Gyarto = gyarto;
                KuldetesStatusz = kuldetesStatusz;
                InditasEve = inditasEve;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        List<Urhajo> urhajok = new List<Urhajo>();

        private void betoltes(object sender, RoutedEventArgs e)
        {
            urhajok = new List<Urhajo>()
            {
                new Urhajo("Falcon-9", 7, 550000, 87, "SpaceX", "Sikeres", 2020),
                new Urhajo("Orion-X1", 4, 820000, 73, "NASA", "Folyamatban", 2023),
                new Urhajo("StarRider", 12, 910000, 66, "Boeing", "Sikeres", 2019),
                new Urhajo("SolarWind", 3, 300000, 92, "ESA", "Sikertelen", 2018),
                new Urhajo("Galaxy-Cruiser", 18, 1200000, 54, "Blue Origin", "Sikeres", 2022),
                new Urhajo("Nova-Prime", 10, 760000, 80, "Roscosmos", "Sikeres", 2017),
                new Urhajo("Pioneer-VII", 6, 640000, 70, "NASA", "Folyamatban", 2024),
                new Urhajo("Titan-Hawk", 14, 1050000, 48, "SpaceX", "Sikeres", 2021),
                new Urhajo("CosmoJet", 5, 430000, 93, "JAXA", "Sikertelen", 2016),
                new Urhajo("Nebula-FX", 11, 870000, 60, "ESA", "Sikeres", 2020)
            };

            dataGrid.ItemsSource = urhajok;
        }

        private void mennyiseg(object sender, RoutedEventArgs e)
        {
            if (urhajok.Count == 0)
            {
                MessageBox.Show("Nincs űrhajó.");
            }
            else {
                MessageBox.Show($"Az űrhajók száma: {urhajok.Count()}");
            }
                

        }
        private void legnagyobbHatotav(object sender, RoutedEventArgs e)
        {
            if (urhajok.Count == 0)
            {
                MessageBox.Show("Nincs űrhajó.");
            }
            else
            {
                Urhajo legnagyobbHat = urhajok.MaxBy(x => x.MaxHatotav);
                MessageBox.Show($"Név: {legnagyobbHat.Nev} \nHatótáv: {legnagyobbHat.MaxHatotav} km");
            }


        }

        private void sikeres(object sender, RoutedEventArgs e)
        {
            if(urhajok != null&& urhajok.Count !=0)
            {
                dataGrid.ItemsSource=urhajok.Where(x => x.KuldetesStatusz == "Sikeres");
                
            }
            else
            {
                MessageBox.Show("Nincs űrhajó!");
            }
        }
        private void AvgLegenyseg(object sender, RoutedEventArgs e)
        {
            if(urhajok == null || urhajok.Count == 0)
            {
                MessageBox.Show("Nincsenek űrhajók");
            }
            else
            {
                double atlag = urhajok.Average(x => x.Legenyseg);
                MessageBox.Show($"Az átlagos legénység száma: {atlag:F2}");
            }
        }

        private void GyartokSzerint(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = urhajok.GroupBy(x => x.Gyarto).Select(g=> new {gyarto = g.Key, Darab = g.Count()}).ToList();
        }

        private void KeresesNevAlapjan(object sender, RoutedEventArgs e)
        {
            if (urhajok != null && urhajok.Count != 0)
            {
                List<Urhajo> ujlista = new List<Urhajo>();
                foreach (var urhajo in urhajok)
                {
                    if (urhajo.Nev == textBox.Text)
                    {
                        ujlista.Add(urhajo);
                    }
                }
                dataGrid.ItemsSource = ujlista;
                dataGrid.ItemsSource = urhajok.Where(urhajo => urhajo.Nev == textBox.Text).ToList();
            }
            else
            {
                MessageBox.Show("Nincsennek űrhajók.");
            }
            
        }

        private void uzemanyag(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem is Urhajo)
            {
                progBar.Value = ((Urhajo)dataGrid.SelectedItem).UzemanyagSzint;
            }

        }
    }
}