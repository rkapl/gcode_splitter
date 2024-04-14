using System;
using System.IO;

namespace GCodeSplitter
{
	public class SwitchStream: IDisposable
	{
		private int index;
		private string prefix;
		private string suffix;
		private StreamWriter writer;

		public SwitchStream(string referencePath)
		{
			index = 1;
			prefix = Path.Combine(Path.GetDirectoryName(referencePath), $"{Path.GetFileNameWithoutExtension(referencePath)}_");
			suffix = Path.GetExtension(referencePath);

			ReOpen();
		}

		public TextWriter Current {
			get {
				return writer;
			}
		}

		public void Dispose()
		{
			if (writer != null) {
				writer.Close();
			}
		}

		public void NextFile() {
			index++;
			ReOpen();
		}

		private void ReOpen() {
			if (writer != null) {
				writer.Close();
				writer = null;
			}
			writer = File.CreateText(prefix + index.ToString() + suffix);
		}
	}
}
