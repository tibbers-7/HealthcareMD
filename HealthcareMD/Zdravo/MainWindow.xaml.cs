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
using System.Threading;
using Service;
using HealthcareMD.FileHandler;

namespace HealthcareMD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //TimeService ts = new TimeService();
            //Thread th = new Thread(new ThreadStart(ts.ThreadFunction));
            //th.IsBackground = true;
            //th.Start();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool pronadjen=false;
            string[] lines = System.IO.File.ReadAllLines("data/accounts.txt");
            foreach(string s in lines)
            {
                string[] parameters = s.Split(',');
                String lozinka = tbPassword.Password.ToString();
                if (tbUsername.Text.Equals(parameters[0]) && lozinka.Equals(parameters[1]))
                {
                    pronadjen = true;
                    if (parameters[2].Equals("S")){
                        //otvara se sekretar page
                       
                       //SecretaryHome sh = new SecretaryHome();
                       // sh.Show();
                        this.Close();
                    }
                    if (parameters[2].Equals("U")){
                        //otvara se upravnik page
                       // ManagerHome mh = new ManagerHome();
                       // mh.Show();
                        this.Close();
                    }
                    if (parameters[2].Equals("L")) {
                        DoctorHome dh=new DoctorHome(int.Parse(parameters[3]));
                        dh.Show();
                        this.Close();
                        //otvara se lekar page
                    }
                }
                
            }
            if (!pronadjen)
            {
                errorLabel.Content = "Pogresno korisnicko ime ili lozinka!";
            }
        }
    }
}
