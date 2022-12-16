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
/// Interaction logic for Page2.xaml
/// </summary>
public partial class Page2 : Page
{

	bool code = false;
	public Page2()
	{
		InitializeComponent();
		SynethiaManager.InjectSynethiaCode(this, Global.SynethiaConfig.PagesInfo, 1, ref code);
	}

	private void Btn1_Click(object sender, RoutedEventArgs e)
	{
		TextBox1.Text = "Click";
		Global.SynethiaConfig.ActionsInfo[1].UsageCount++;
	}

	private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
	{
		Text1.Text = TextBox1.Text; // Set the text while the user is typing
	}
}
