﻿using System;
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
            catch (Exception ex)
            {
                MessageBox.Show("Hiba");
                Logger.Logging.LogExToTxt(ex);
            }
        }

        MainWindow mainWin = Application.Current.Windows
        .Cast<Window>()
        .FirstOrDefault(window => window is MainWindow) as MainWindow;

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Dolgozok dolgozok = new Dolgozok();
            mainWin.Content = dolgozok;
        }
        private void vezeteknev_GotFocus(object sender, RoutedEventArgs e)
        {
            tbvezeteknev.Text = "";
        }
        private void keresztnev_GotFocus(object sender, RoutedEventArgs e)
        {
            tbkeresztnev.Text = "";
        }
        private void szulido_GotFocus(object sender, RoutedEventArgs e)
        {
            tbszulido.Text = "";
        }
        private void adoazon_GotFocus(object sender, RoutedEventArgs e)
        {
            tbadoazon.Text = "";
        }
        private void taj_GotFocus(object sender, RoutedEventArgs e)
        {
            tbtaj.Text = "";
        }
        private void fizetes_GotFocus(object sender, RoutedEventArgs e)
        {
            tbfizetes.Text = "";
        }
        private void irsz_GotFocus(object sender, RoutedEventArgs e)
        {
            tbirsz.Text = "";
        }
        private void anyjaneve_GotFocus(object sender, RoutedEventArgs e)
        {
            tbanyjaneve.Text = "";
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
                else btnDolgozoHozaad.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
            }
        }
    }
}
