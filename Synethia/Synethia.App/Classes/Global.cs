﻿/*
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
using Synethia.App.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Synethia.App.Classes;
public static class Global
{
	public static SynethiaConfig SynethiaConfig { get; set; } = SynethiaManager.Load(SynethiaPath, Default);

	public static DashboardPage DashboardPage { get; set; } = new();
	public static Page1? Page1 { get; set; }
	public static Page2? Page2 { get; set; }
	public static Page3? Page3 { get; set; }

	public static SynethiaConfig Default => new()
	{
		PagesInfo = new List<PageInfo>()
		{
			new("Page1"),
			new("Page2"),
			new("Page3")
		},
		ActionsInfo = new()
		{
			new(0, "Page1.Button1"),
			new(1, "Page2.Button1"),
			new(2, "Page3.Button1")
		}
	};

	public static List<ActionInfo> DefaultRelevantActions => new()
	{
		new(0, "Page1.Button1"),
		new(1, "Page2.Button1"),
		new(2, "Page3.Button1")
	};

	internal static string SynethiaPath => $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\Léo Corporation\Synethia\SynethiaConfig.json";

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
