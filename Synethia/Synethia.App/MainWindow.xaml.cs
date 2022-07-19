/*
MIT License

Copyright (c) Léo Corporation

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
using LeoCorpLibrary;
using Synethia.App.Classes;
using Synethia.App.Pages;
using System.Windows;

namespace Synethia.App;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
		InitUI(); // Initialize the UI
	}

	private void InitUI()
	{
		DashboardBtn.IsChecked = true;
		ContentFrame.Navigate(Global.DashboardPage);
	}

	private void ResetCheckStatus()
	{
		DashboardBtn.IsChecked = false;
		Page1Btn.IsChecked = false;
		Page2Btn.IsChecked = false;
		Page3Btn.IsChecked = false;
	}

	private void LeavePage()
	{
		if (ContentFrame.Content is Page1)
		{
			Global.Page1.ExitUnixTime = Env.UnixTime;
			Global.Page1.TotalTime += Global.Page1.ExitUnixTime - Global.Page1.EnterUnixTime;
		}
	}

	private void DashboardBtn_Click(object sender, RoutedEventArgs e)
	{
		LeavePage();

		ResetCheckStatus(); // Reset "IsChecked" state
		DashboardBtn.IsChecked = true;

		ContentFrame.Navigate(Global.DashboardPage); // Show the corresponding page
		Global.DashboardPage.LoadData();
	}

	private void Page1Btn_Click(object sender, RoutedEventArgs e)
	{
		ResetCheckStatus(); // Reset "IsChecked" state
		Page1Btn.IsChecked = true;

		ContentFrame.Navigate(Global.Page1); // Show the corresponding page
		Global.Page1.EnterUnixTime = Env.UnixTime;
	}

	private void Page2Btn_Click(object sender, RoutedEventArgs e)
	{
		LeavePage();

		ResetCheckStatus(); // Reset "IsChecked" state
		Page2Btn.IsChecked = true;
	}

	private void Page3Btn_Click(object sender, RoutedEventArgs e)
	{
		LeavePage();

		ResetCheckStatus(); // Reset "IsChecked" state
		Page3Btn.IsChecked = true;
	}
}
