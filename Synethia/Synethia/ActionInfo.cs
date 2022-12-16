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
	/// Class that can be used to contains information about a specific interaction or action.
	/// </summary>
	public class ActionInfo
	{
		/// <summary>
		/// The identifier number for the action.
		/// </summary>
		public int Id { get; init; }

		/// <summary>
		/// The number of time the action has been used.
		/// </summary>
		public int UsageCount { get; set; }

		/// <summary>
		/// The action name.
		/// </summary>
		public string Name { get; init; }

		/// <summary>
		/// Intializes an action.
		/// </summary>
		/// <param name="id">The action ID.</param>
		/// <param name="name">The action name</param>
		/// <param name="usageCount">The default usage count. (0 by default)</param>
		public ActionInfo(int id, string name, int usageCount = 0)
		{
			Id = id;
			UsageCount = usageCount;
			Name = name;
		}
	}
}
