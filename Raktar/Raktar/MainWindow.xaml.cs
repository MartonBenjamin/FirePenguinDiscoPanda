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
using System.Timers;
using System.Threading;

namespace Raktar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string nev = "teszt";
        static string jelszo = "123";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            lblloginfo.Visibility = Visibility.Hidden;
            if (tblogin.Text == nev && pswbox.Password == jelszo)
            {
                lblloginfo.Visibility = Visibility.Visible;
                lblloginfo.Content = "Sikeres bejelentkezés!";
                Bejelentkezes();
            }
            else
            {
                lblloginfo.Visibility = Visibility.Visible;
                lblloginfo.Content = "Hibás felhasználónév vagy jelszó!";

            }
        }
        private void Bejelentkezes()
        {
            
        }
    }
}