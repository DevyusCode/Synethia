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

namespace Synethia.App;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
	}

	private void ResetCheckStatus()
	{
		DashboardBtn.IsChecked = false;
		Page1Btn.IsChecked = false;
		Page2Btn.IsChecked = false;
		Page3Btn.IsChecked = false;
	}

	private void DashboardBtn_Click(object sender, RoutedEventArgs e)
	{
		ResetCheckStatus(); // Reset "IsChecked" state
		DashboardBtn.IsChecked = true;
	}

	private void Page1Btn_Click(object sender, RoutedEventArgs e)
	{
		ResetCheckStatus(); // Reset "IsChecked" state
		Page1Btn.IsChecked = true;
	}

	private void Page2Btn_Click(object sender, RoutedEventArgs e)
	{
		ResetCheckStatus(); // Reset "IsChecked" state
		Page2Btn.IsChecked = true;
	}

	private void Page3Btn_Click(object sender, RoutedEventArgs e)
	{
		ResetCheckStatus(); // Reset "IsChecked" state
		Page3Btn.IsChecked = true;
	}
}
