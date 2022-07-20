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
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Synethia.App.Pages;
/// <summary>
/// Interaction logic for Page1.xaml
/// </summary>
public partial class Page1 : Page
{
	internal int EnterUnixTime { get; set; }
	internal int ExitUnixTime { get; set; }
	internal int TotalTime { get; set; } = 0;
	internal int TotalInteractionCount { get; set; }

	bool code = false;
	public Page1()
	{
		InitializeComponent();
		Loaded += (o, e) => 
		{
			if (!code)
			{
				// For each button of the page
				foreach (Button b in FindVisualChildren<Button>(this))
				{
					b.Click += (sender, e) =>
					{
						TotalInteractionCount++;
					};
				}
			}
		};
	}

	private void Btn1_Click(object sender, RoutedEventArgs e)
	{
		MessageBox.Show("You clicked Button 1!");		
	}

	private void Btn2_Click(object sender, RoutedEventArgs e)
	{
		MessageBox.Show("You clicked Button 2!");
	}

	public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
	{
		if (depObj == null) yield return (T)Enumerable.Empty<T>();
		for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
		{
			DependencyObject ithChild = VisualTreeHelper.GetChild(depObj, i);
			if (ithChild == null) continue;
			if (ithChild is T t) yield return t;
			foreach (T childOfChild in FindVisualChildren<T>(ithChild)) yield return childOfChild;
		}
	}
}
