using System.Windows;
using System.Windows.Controls;

namespace WPFAgeCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AgeViewModel _ageViewModel;
        
        public MainWindow()
        {
            InitializeComponent();
            AgeText.Visibility = Visibility.Collapsed;
            DataContext = _ageViewModel = new AgeViewModel();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_ageViewModel.IsValidBirthDate())
            {
                AgeText.Visibility = Visibility.Visible;
                if (_ageViewModel.IsBirthdayToday())
                    MessageBox.Show("Happy birthday!", "Congratulations", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                AgeText.Visibility = Visibility.Collapsed;
                MessageBox.Show("Age cannot be more than 135 or less than 0", "Invalid age", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}