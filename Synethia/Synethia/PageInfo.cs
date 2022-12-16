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

namespace Synethia
{
	/// <summary>
	/// Class that contain information about the interactions, the usage of a specific page.
	/// </summary>
	public class PageInfo
	{
		/// <summary>
		/// The name of the page.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The time the user entered the page, stored using UnixTime.
		/// </summary>
		public int EnterUnixTime { get; set; }

		/// <summary>
		/// The time the user left the page, stored using UnixTime.
		/// </summary>
		public int LeaveUnixTime { get; set; }

		/// <summary>
		/// The total time spent by the user on that page.
		/// </summary>
		public int TotalTimeSpent { get; set; }

		/// <summary>
		/// The number of global interactions the user made. Can be button clicks, text input, checkboxed or radiobuttons.
		/// </summary>
		public int InteractionCount { get; set; }

		/// <summary>
		/// The Synethia score of the page.
		/// </summary>
		public double Score => TotalTimeSpent * (InteractionCount > 0 ? InteractionCount / 2d : 1d);

		/// <summary>
		/// Initializes this class with a specified name.
		/// </summary>
		/// <param name="name">The name of the page.</param>
		public PageInfo(string name)
		{
			Name = name;
		}
	}
}
