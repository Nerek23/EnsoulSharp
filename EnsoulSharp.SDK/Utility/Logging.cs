using System;
using System.IO;
using System.Runtime.CompilerServices;
using EnsoulSharp.SDK.Core;

namespace EnsoulSharp.SDK.Utility
{
	// Token: 0x02000085 RID: 133
	public class Logging
	{
		// Token: 0x060004E5 RID: 1253 RVA: 0x000247EE File Offset: 0x000229EE
		public static Logging.WriteDelegate Write(bool logToFile = false, bool printColor = true, [CallerMemberName] string memberName = "")
		{
			return delegate(LogLevel logLevel, object value, object[] args)
			{
				object obj = value;
				if (args.Length != 0)
				{
					try
					{
						obj = string.Format(value.ToString(), args);
					}
					catch
					{
					}
				}
				Logging.Write(logLevel, obj.ToString(), logToFile, printColor, memberName);
			};
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x00024818 File Offset: 0x00022A18
		public static void Write(LogLevel logLevel, object value, object[] args, bool logToFile = false, bool printColor = true, [CallerMemberName] string memberName = "")
		{
			object obj = value;
			if (args.Length != 0)
			{
				try
				{
					obj = string.Format(value.ToString(), args);
				}
				catch
				{
				}
			}
			Logging.Write(logLevel, obj.ToString(), logToFile, printColor, memberName);
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x00024860 File Offset: 0x00022A60
		private static void Write(LogLevel logLevel, string message, bool logToFile, bool printColor, string memberName)
		{
			string value = string.Format("[{0:MM-dd-yyyy HH:mm:ss} - {1}]: ({2}) -> {3}", new object[]
			{
				DateTime.Now,
				logLevel,
				memberName,
				message
			});
			if (logLevel == LogLevel.Bootstrap || logLevel == LogLevel.Info)
			{
				value = string.Format("[{0:MM-dd-yyyy HH:mm:ss} - {1}]: {2}", DateTime.Now, logLevel, message);
			}
			else if (logLevel == LogLevel.NoTopic)
			{
				value = string.Format("[{0:MM-dd-yyyy HH:mm:ss}]: {1}", DateTime.Now, message);
			}
			if (printColor)
			{
				ConsoleColor foregroundColor = Console.ForegroundColor;
				switch (logLevel)
				{
				case LogLevel.Info:
				case LogLevel.Bootstrap:
				case LogLevel.NoTopic:
					foregroundColor = ConsoleColor.Cyan;
					break;
				case LogLevel.Debug:
					foregroundColor = ConsoleColor.White;
					break;
				case LogLevel.Trace:
					foregroundColor = ConsoleColor.White;
					break;
				case LogLevel.Warn:
					foregroundColor = ConsoleColor.Yellow;
					break;
				case LogLevel.Error:
					foregroundColor = ConsoleColor.Red;
					break;
				case LogLevel.Fatal:
					foregroundColor = ConsoleColor.Magenta;
					break;
				}
				Console.ForegroundColor = foregroundColor;
			}
			Console.WriteLine(value);
			Console.ResetColor();
			if (logToFile)
			{
				if (logLevel != LogLevel.Error && logLevel != LogLevel.Fatal && logLevel != LogLevel.Warn)
				{
					return;
				}
				try
				{
					if (!Directory.Exists(Config.LogDirectory))
					{
						Directory.CreateDirectory(Config.LogDirectory);
					}
					using (StreamWriter streamWriter = new StreamWriter(Path.Combine(Config.LogDirectory, Config.LogFileName), true))
					{
						streamWriter.WriteLine(value);
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
		}

		// Token: 0x020004D2 RID: 1234
		// (Invoke) Token: 0x06001667 RID: 5735
		public delegate void WriteDelegate(LogLevel logLevel, object value, params object[] args);
	}
}
