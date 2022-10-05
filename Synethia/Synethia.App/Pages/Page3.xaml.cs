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
using Synethia.App.Classes;
using System.Windows;
using System.Windows.Controls;

namespace Synethia.App.Pages;
/// <summary>
/// Interaction logic for Page3.xaml
/// </summary>
public partial class Page3 : Page
{

	bool code = false;
	public Page3()
	{
		InitializeComponent();
		Loaded += (o, e) =>
		{
			if (!code)
			{
				code = true;
				// For each button of the page
				foreach (Button b in Global.FindVisualChildren<Button>(this))
				{
					b.Click += (sender, e) =>
					{
						Global.SynethiaConfig.Page3Info.InteractionCount++;
					};
				}

				// For each TextBox of the page
				foreach (TextBox textBox in Global.FindVisualChildren<TextBox>(this))
				{
					textBox.GotFocus += (o, e) =>
					{
						Global.SynethiaConfig.Page3Info.InteractionCount++;
					};
				}

				// For each CheckBox/RadioButton of the page
				foreach (CheckBox checkBox in Global.FindVisualChildren<CheckBox>(this))
				{
					checkBox.Checked += (o, e) =>
					{
						Global.SynethiaConfig.Page3Info.InteractionCount++;
					};
					checkBox.Unchecked += (o, e) =>
					{
						Global.SynethiaConfig.Page3Info.InteractionCount++;
					};
				}

				foreach (RadioButton radioButton in Global.FindVisualChildren<RadioButton>(this))
				{
					radioButton.Checked += (o, e) =>
					{
						Global.SynethiaConfig.Page3Info.InteractionCount++;
					};
					radioButton.Unchecked += (o, e) =>
					{
						Global.SynethiaConfig.Page3Info.InteractionCount++;
					};
				}
			}
		};
	}

	private void Check1_Checked(object sender, RoutedEventArgs e)
	{
		MessageBox.Show(Check1.IsChecked ?? false ? "Checked!" : "Unchecked!");
	}

	private void Radio1_Checked(object sender, RoutedEventArgs e)
	{
		MessageBox.Show(Radio1.IsChecked ?? false ? "Checked!" : "Unchecked!");
	}

	private void Btn1_Click(object sender, RoutedEventArgs e)
	{
		MessageBox.Show("Hello!");
	}

	private void Btn2_Click(object sender, RoutedEventArgs e)
	{
		MessageBox.Show("Welcome!");
	}
}
