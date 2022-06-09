using Controller;
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
using System.Windows.Shapes;
using HealthcareMD.ViewModel;

namespace HealthcareMD.DoctorWindows
{
    /// <summary>
    /// Interaction logic for PrescriptionWindow.xaml
    /// </summary>
    public partial class PrescriptionWindow : Window
    {
        private PrescriptionViewModel viewModel;
        private int chosenDrug;
        private int errorCode;

        public PrescriptionWindow(int id)
        {
            InitializeComponent();
            viewModel = new PrescriptionViewModel(id);
            DataContext = viewModel;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Row_DoubleClick(object sender, RoutedEventArgs e)
        {
            object item = drugTable.SelectedItem;
            errorCode=viewModel.ShowDrug(int.Parse((drugTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text));
            if (errorCode == -1) MessageBox.Show("Lek ne postoji u bazi!", "Interna greška");
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            object item = drugTable.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Niste odabrali lek!", "Greška");
            }
            else
            {
                chosenDrug = int.Parse((drugTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                if (viewModel.CheckAllergies(chosenDrug) == 0) this.Close();
                
            }
            
            
        }
    }
}
