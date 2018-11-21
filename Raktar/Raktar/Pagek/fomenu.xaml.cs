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

namespace Raktar.Pagek
{
    /// <summary>
    /// Interaction logic for fomenu.xaml
    /// </summary>
    public partial class fomenu : Page
    {
        CDolgozok loggeduser;
        public fomenu()
        {
            InitializeComponent();
            if (CDolgozokkezeles.loggeduserid != 0)
                Bejelentkezett();
            
        }

        MainWindow mainWin = Application.Current.Windows
        .Cast<Window>()
        .FirstOrDefault(window => window is MainWindow) as MainWindow;
        private void Bejelentkezett()
        {
            loggeduser = CDolgozokkezeles.LoggedUserVisszaad();
            lblloggeduser.Content =  "Bejelentkezve, mint: "+loggeduser.Vezeteknev + " " + loggeduser.Keresztnev;
        }

        private void btn_click_dolgozok(object sender, RoutedEventArgs e)
        {
            Dolgozok dolgozok = new Dolgozok();
            mainWin.Content = dolgozok;
        }

        private void btn_click_raktarak(object sender, RoutedEventArgs e)
        {
            Raktarak raktarak = new Raktarak();
            mainWin.Content = raktarak;
        }

        private void btn_click_termek(object sender, RoutedEventArgs e)
        {
            Termekek termekek = new Termekek();
            mainWin.Content = termekek;
        }

        private void Btnlogoff_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Biztosan ki szeretnél jelentkezni?", "Megerősítés", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                loggeduser = null;
                CDolgozokkezeles.loggeduserid = 0;
                lblloggeduser.Content = "Nem vagy bejelentkezve!";
                MainWindow main = new MainWindow();
                mainWin.Close();
                main.Show();
                //login ablak újra mutatása kéne
            }
            
        }
    }
}
