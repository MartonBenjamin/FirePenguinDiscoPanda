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
using System.Timers;
using System.Threading;
using System.Windows.Threading;

namespace Raktar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            startclock();
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            CLogin login = new CLogin();
            login.LoginTry();           
        }

        public void startclock()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += tickevent;
            timer.Start();
        }

        public void tickevent(object sender, EventArgs e)
        {
            datelbl.Text = DateTime.Now.ToString();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                if (tblogin.IsFocused)
                {
                    pswbox.Focus();
                }
                else if (pswbox.IsFocused)
                {
                    CLogin login = new CLogin();
                    login.LoginTry();                    
                }
                else
                {
                    tblogin.Focus();
                }               	                                             
            }
        }


    }
}
