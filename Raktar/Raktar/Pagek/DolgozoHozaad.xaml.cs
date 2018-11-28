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
using Raktar.Services;
using Raktar.Modell;

namespace Raktar.Pagek
{
    /// <summary>
    /// Interaction logic for DolgozoHozaad.xaml
    /// </summary>
    public partial class DolgozoHozaad : Page
    {  
        public DolgozoHozaad()
        {
            InitializeComponent();
            cbFeltolt();
        }
        

        private void btnDolgozoHozaad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CDolgozokkezeles.DolgozokHozaad(tbvezeteknev.Text, tbkeresztnev.Text, tbszulido.Text,
                tbadoazon.Text, tbtaj.Text, tbirsz.Text, tbanyjaneve.Text, Convert.ToInt32(tbfizetes.Text));
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Hibás beviteli érték!");
                Logger.Logging.LogExToTxt(ex);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Hiba:\nElméretezett érték található!");
                Logger.Logging.LogExToTxt(ex);
            }
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Hiba");
            //    Logger.Logging.LogExToTxt(ex);
            //}
        }

        MainWindow mainWin = Application.Current.Windows
        .Cast<Window>()
        .FirstOrDefault(window => window is MainWindow) as MainWindow;

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Dolgozok dolgozok = new Dolgozok();
            mainWin.Content = dolgozok;
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            List<TextBox> TextBoxes = new List<TextBox> { tbvezeteknev, tbkeresztnev, tbszulido, tbadoazon, tbtaj, tbirsz, tbanyjaneve, tbfizetes };
            if (e.Key == Key.Enter)
            {
                if (TextBoxes[0].IsFocused) TextBoxes[1].Focus();
                else if (TextBoxes[1].IsFocused) TextBoxes[2].Focus();
                else if (TextBoxes[2].IsFocused) TextBoxes[3].Focus();
                else if (TextBoxes[3].IsFocused) TextBoxes[4].Focus();
                else if (TextBoxes[4].IsFocused) TextBoxes[5].Focus();
                else if (TextBoxes[5].IsFocused) TextBoxes[6].Focus();
                else if (TextBoxes[6].IsFocused) TextBoxes[7].Focus();
                else
                {
                    btnDolgozoHozaad.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
                    tbvezeteknev.Focus();
                }
            }
        }
        private void vezeteknev_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbvezeteknev.Text == "Vezetéknév")
                tbvezeteknev.Text = "";
            lblvezeteknevinfo.Visibility = Visibility.Visible;
        }
        private void keresztnev_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbkeresztnev.Text == "Keresztnév")
                tbkeresztnev.Text = "";
            lblkeresztnevinfo.Visibility = Visibility.Visible;
        }
        private void szulido_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbszulido.Text == "Születési idő")
                tbszulido.Text = "";
            lblszulidoinfo.Visibility = Visibility.Visible;
        }
        private void adoazon_GotFocus(object sender, RoutedEventArgs e)
        { 
            if(tbadoazon.Text == "Adóazonosító szám")
                tbadoazon.Text = "";
            lbladoazoninfo.Visibility = Visibility.Visible;
        }
        private void taj_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbtaj.Text == "Taj szám")
                tbtaj.Text = "";
            lbltajszaminfo.Visibility = Visibility.Visible;
        }
        private void fizetes_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbfizetes.Text == "Fizetés")
                tbfizetes.Text = "";
            lblfizetesinfo.Visibility = Visibility.Visible;
        }
        private void irsz_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbirsz.Text == "Irányítószám")
                tbirsz.Text = "";
            lbliranyitoinfo.Visibility = Visibility.Visible;
        }
        private void anyjaneve_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbanyjaneve.Text == "Anyja neve")
                tbanyjaneve.Text = "";
            lblanyjaneveinfo.Visibility = Visibility.Visible;
        }


        private void tbvezeteknev_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbvezeteknev.Text == "")
            {
                tbvezeteknev.Text = "Vezetéknév"; 
                lblvezeteknevinfo.Visibility = Visibility.Hidden;
            }
        }
        private void tbkeresztnev_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbkeresztnev.Text == "")
            {
                tbkeresztnev.Text = "Keresztnév";
                lblkeresztnevinfo.Visibility = Visibility.Hidden;
            }
        }

        private void tbszulido_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbszulido.Text == "")
            {
                tbszulido.Text = "Születési idő";
                lblszulidoinfo.Visibility = Visibility.Hidden;
            }

        }

        private void tbadoazon_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbadoazon.Text == "")
            {
                tbadoazon.Text = "Adóazonosító szám";
                lbladoazoninfo.Visibility = Visibility.Hidden;
            }
        }

        private void tbtaj_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbtaj.Text == "")
            {
                tbtaj.Text = "Taj szám";
                lbltajszaminfo.Visibility = Visibility.Hidden;
            }
        }

        private void tbirsz_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbirsz.Text == "")
            {
                tbirsz.Text = "Irányítószám";
                lbliranyitoinfo.Visibility = Visibility.Hidden;
            }
        }

        private void tbanyjaneve_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbanyjaneve.Text == "")
            {
                tbanyjaneve.Text = "Anyja neve";
                lblanyjaneveinfo.Visibility = Visibility.Hidden;
            }
        }

        private void tbfizetes_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbfizetes.Text == "")
            {
                tbfizetes.Text = "Fizetés";
                lblfizetesinfo.Visibility = Visibility.Hidden;
            }
        }
        private void cbFeltolt()
        {
            List<VarosModell> varosok = Varoskezeles.VarosokVisszaad();
            for (int i = 0; i < varosok.Count; i++)
                cbVarosok.Items.Add(varosok[i].Varosmegnevezes);
        }
        private void CbVarosok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<VarosModell> varosok = Varoskezeles.VarosokVisszaad();
            using (firepenguinEntities1 db = new firepenguinEntities1())
            {
                Város selectedvaros = db.Város.FirstOrDefault(p => p.Város1 == cbVarosok.SelectedItem);
                tbirsz.Text = selectedvaros.Irányítószám;
            }

        }
    }
}
