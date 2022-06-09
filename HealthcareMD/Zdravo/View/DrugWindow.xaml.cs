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
using System.Windows.Shapes;
using HealthcareMD.ViewModel;

namespace HealthcareMD.DoctorView
{
    /// <summary>
    /// Interaction logic for DrugWindow.xaml
    /// </summary>
    public partial class DrugWindow : Window
    {
        private DrugViewModel viewModel;
        public DrugWindow(DoctorHomeViewModel callerWindow,int drugId)
        {
            viewModel = new DrugViewModel(callerWindow,drugId);
            this.DataContext = viewModel;
            InitializeComponent();
            
        }


       
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
