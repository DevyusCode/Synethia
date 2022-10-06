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
using LeoCorpLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Synethia.App.Classes;
public static class SynethiaManager
{
	public static SynethiaConfig Load()
	{
		if (!Directory.Exists($@"{Env.AppDataPath}\Léo Corporation\Synethia\"))
		{
			Directory.CreateDirectory($@"{Env.AppDataPath}\Léo Corporation\Synethia\");
		}

		if (!File.Exists(Global.SynethiaPath)) // If no Synethia config exists
		{
			Global.SynethiaConfig = new();
			string json = JsonSerializer.Serialize(Global.SynethiaConfig, new JsonSerializerOptions { WriteIndented = true });
			File.WriteAllText(Global.SynethiaPath, json);
			return new();
		}

		// If Synethia config exists
		// Deserialize the file to Synethia config (using JSON)
		return JsonSerializer.Deserialize<SynethiaConfig>(File.ReadAllText(Global.SynethiaPath)) ?? new();
	}

	public static void Save(SynethiaConfig synethiaConfig)
	{
		string json = JsonSerializer.Serialize(synethiaConfig, new JsonSerializerOptions { WriteIndented = true });
		File.WriteAllText(Global.SynethiaPath, json);
	}
}