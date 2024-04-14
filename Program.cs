using System;
using System.IO;
using System.Text;

namespace GCodeSplitter {
	class MainClass
	{
		private static string comment(string v) {
			return '(' + v.Replace('(', '[').Replace(')', ']') + ')';
		}

		public static void Main(string[] args)
		{
			if (args.Length != 1) {
				Console.Error.WriteLine("Syntax: gcode-splitter file.nc");
				System.Environment.Exit(1);
			}

			string fileName = args[0];
			using(var r = File.OpenText(fileName)) {
				using(var w = new SwitchStream(fileName)) {
					string l;
					while((l = r.ReadLine()) != null) {
						if (l.Trim().StartsWith("M06", StringComparison.InvariantCultureIgnoreCase)) {
							w.NextFile();
							w.Current.WriteLine(comment(l));
						} else {
							w.Current.WriteLine(l);
						}
					}
				}
			}
		}
	}
}