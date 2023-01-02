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

namespace Synethia
{
	/// <summary>
	/// The global Synethia config that will store all the collected data.
	/// </summary>
	public class SynethiaConfig
	{
		/// <summary>
		/// All the data about the interactions and the time spent on each page.
		/// </summary>
		public List<PageInfo> PagesInfo { get; set; }

		/// <summary>
		/// All the data about the specific actions the user used.
		/// </summary>
		public List<ActionInfo> ActionsInfo { get; set; }

		/// <summary>
		/// Initializes a new empty config.
		/// </summary>
		public SynethiaConfig()
		{
			PagesInfo = new();
			ActionsInfo = new();
		}

		/// <summary>
		/// Gets the most relevant pages.
		/// </summary>
		public List<PageInfo> MostRelevantPages => PagesInfo.OrderByDescending(x => x.Score).ToList();

		/// <summary>
		/// Gets the most relevant actions
		/// </summary>
		public List<ActionInfo> MostRelevantActions => ActionsInfo.OrderByDescending(x => x.UsageCount).ToList();
	}
}
