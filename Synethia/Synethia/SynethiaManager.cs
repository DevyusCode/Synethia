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
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Synethia
{
	/// <summary>
	/// The class containing all the methods to work with Synethia.
	/// </summary>
	public static class SynethiaManager
	{
		/// <summary>
		/// Loads a Synethia JSON config file stored in a specified location. Falls back to a default config if none is found.
		/// </summary>
		/// <param name="path">The location of the Synthia JSON file.</param>
		/// <param name="defaultConfig">The fallback Synethia configuration.</param>
		/// <returns>The <see cref="SynethiaConfig"/> stored in the specified JSON file.</returns>
		public static SynethiaConfig Load(string path, SynethiaConfig defaultConfig)
		{
			if (!Directory.Exists(Path.GetDirectoryName(path))) Directory.CreateDirectory(Path.GetDirectoryName(path));

			if (!File.Exists(path)) // If no Synethia config exists
			{
				string json = JsonSerializer.Serialize(defaultConfig, new JsonSerializerOptions { WriteIndented = true });
				File.WriteAllText(path, json);
				return defaultConfig;
			}

			// If Synethia config exists
			// Deserialize the file to Synethia config (using JSON)
			return JsonSerializer.Deserialize<SynethiaConfig>(File.ReadAllText(path)) ?? defaultConfig;

		}

		/// <summary>
		/// Saves the specified <see cref="SynethiaConfig"/> to a Synethia JSON file at a specfied location.
		/// </summary>
		/// <param name="synethiaConfig">The <see cref="SynethiaConfig"/> to save.</param>
		/// <param name="path">The location where the file is going to be written.</param>
		public static void Save(SynethiaConfig synethiaConfig, string path)
		{
			string json = JsonSerializer.Serialize(synethiaConfig, new JsonSerializerOptions { WriteIndented = true });
			File.WriteAllText(path, json);
		}

		/// <summary>
		/// Injects Synethia triggers and event handler to a page, so that Synethia can start monitoring user activity.
		/// </summary>
		/// <remarks>This method should be injected in the <see cref="Page"/> constructor.</remarks>
		/// <param name="page">The page where the code needs to be injected.</param>
		/// <param name="pageInfo">The list of all the <see cref="PageInfo"/>.</param>
		/// <param name="index">The index of the corresponding <see cref="PageInfo"/> of the specified <paramref name="page"/> in the <paramref name="pageInfo"/> list.</param>
		/// <param name="codeInjected">Assuming this code is injected in the constructor, this parameter is used to stop the method if the code is already injected.</param>
		public static void InjectSynethiaCode(Page page, List<PageInfo> pageInfo, int index, ref bool codeInjected)
		{
			PageInfo info = pageInfo[index];
			bool code = codeInjected;

			page.Loaded += (o, e) =>
			{
				if (!code)
				{
					code = true;
					// For each button of the page
					foreach (Button b in FindVisualChildren<Button>(page))
					{
						b.Click += (sender, e) =>
						{
							info.InteractionCount++;
						};
					}

					// For each TextBox of the page
					foreach (TextBox textBox in FindVisualChildren<TextBox>(page))
					{
						textBox.GotFocus += (o, e) =>
						{
							info.InteractionCount++;
						};
					}

					// For each CheckBox/RadioButton of the page
					foreach (CheckBox checkBox in FindVisualChildren<CheckBox>(page))
					{
						checkBox.Checked += (o, e) =>
						{
							info.InteractionCount++;
						};
						checkBox.Unchecked += (o, e) =>
						{
							info.InteractionCount++;
						};
					}

					foreach (RadioButton radioButton in FindVisualChildren<RadioButton>(page))
					{
						radioButton.Checked += (o, e) =>
						{
							info.InteractionCount++;
						};
						radioButton.Unchecked += (o, e) =>
						{
							info.InteractionCount++;
						};
					}
				}
			};

			pageInfo[index] = info;
			codeInjected = true;
		}

		private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
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
}
