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
using Synethia.App.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Synethia.App.Pages;
/// <summary>
/// Interaction logic for DashboardPage.xaml
/// </summary>
public partial class DashboardPage : Page
{
	public DashboardPage()
	{
		InitializeComponent();
		LoadData();
	}

	internal void LoadData()
	{
		Page1ScoreTxt.Text = $"Total time spent: {Global.Page1.TotalTime}\n" +
			$"Number of interaction(s): {Global.Page1.TotalInteractionCount}\n" +
			$"Synethia Score: {Global.Page1.TotalTime * (Global.Page1.TotalInteractionCount > 0 ? Global.Page1.TotalInteractionCount / 2d : 1d)}";

		Page2ScoreTxt.Text = $"Total time spent: {Global.Page2.TotalTime}\n" +
			$"Number of interaction(s): {Global.Page2.TotalInteractionCount}\n" +
			$"Synethia Score: {Global.Page2.TotalTime * (Global.Page2.TotalInteractionCount > 0 ? Global.Page2.TotalInteractionCount / 2d : 1d)}";

		Page3ScoreTxt.Text = $"Total time spent: {Global.Page3.TotalTime}\n" +
			$"Number of interaction(s): {Global.Page3.TotalInteractionCount}\n" +
			$"Synethia Score: {Global.Page3.TotalTime * (Global.Page3.TotalInteractionCount > 0 ? Global.Page3.TotalInteractionCount / 2d : 1d)}";


		// Recommanded page section
		Dictionary<AppPages, double> appScores = new();
		appScores.Add(AppPages.Page1, Global.Page1.TotalTime * (Global.Page1.TotalInteractionCount > 0 ? Global.Page1.TotalInteractionCount / 2d : 1d));
		appScores.Add(AppPages.Page2, Global.Page2.TotalTime * (Global.Page2.TotalInteractionCount > 0 ? Global.Page2.TotalInteractionCount / 2d : 1d));
		appScores.Add(AppPages.Page3, Global.Page3.TotalTime * (Global.Page3.TotalInteractionCount > 0 ? Global.Page3.TotalInteractionCount / 2d : 1d));

		// Sort by score
		var sorted = appScores.OrderByDescending(x => x.Value);

		// Display to the user (RecommandedTxt)
		RecommandedTxt.Text = ""; // Clear text
		int c = 0;
		foreach (var item in sorted)
		{
			c++;
			RecommandedTxt.Text += $"#{c} - {item.Key} - {item.Value}\n";
		}
	}
}
