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
using Synethia.App.Enums;
using System.Collections.Generic;

namespace Synethia.App.Classes;
public class SynethiaConfig
{
	public SynethiaConfig()
	{
		Page1Info = new();
		Page2Info = new();
		Page3Info = new();

		Actions = Global.DefaultRelevantActions;
	}

	public PageInfo Page1Info { get; set; }
	public PageInfo Page2Info { get; set; }
	public PageInfo Page3Info { get; set; }

	public List<Action> Actions { get; set; }
}

public class PageInfo
{
	public PageInfo()
	{
		EnterUnixTime = 0;
		LeaveUnixTime = 0;
		TotalTimeSpent = 0;
		InteractionCount = 0;
		Score = 0;
	}

	public int EnterUnixTime { get; set; }
	public int LeaveUnixTime { get; set; }
	public int TotalTimeSpent { get; set; }
	public int InteractionCount { get; set; }
	public double Score { get; set; }
}

public class Action
{
	public int Id { get; init; }
	public int UsageCount { get; set; }
	public string Name { get; init; }

	public Action(int id, int usage, string name)
	{
		Id = id;
		UsageCount = usage;
		Name = name;
	}
}