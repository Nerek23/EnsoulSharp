using System;
using System.Collections;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Security;
using System.Threading;

namespace log4net.Util
{
	// Token: 0x0200002D RID: 45
	public sealed class SystemInfo
	{
		// Token: 0x060001CC RID: 460 RVA: 0x00005F33 File Offset: 0x00004F33
		private SystemInfo()
		{
		}

		// Token: 0x060001CD RID: 461 RVA: 0x00005F3C File Offset: 0x00004F3C
		static SystemInfo()
		{
			string text = "(null)";
			string text2 = "NOT AVAILABLE";
			string appSetting = SystemInfo.GetAppSetting("log4net.NullText");
			if (appSetting != null && appSetting.Length > 0)
			{
				LogLog.Debug(SystemInfo.declaringType, "Initializing NullText value to [" + appSetting + "].");
				text = appSetting;
			}
			string appSetting2 = SystemInfo.GetAppSetting("log4net.NotAvailableText");
			if (appSetting2 != null && appSetting2.Length > 0)
			{
				LogLog.Debug(SystemInfo.declaringType, "Initializing NotAvailableText value to [" + appSetting2 + "].");
				text2 = appSetting2;
			}
			SystemInfo.s_notAvailableText = text2;
			SystemInfo.s_nullText = text;
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060001CE RID: 462 RVA: 0x00005FEB File Offset: 0x00004FEB
		public static string NewLine
		{
			get
			{
				return Environment.NewLine;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060001CF RID: 463 RVA: 0x00005FF2 File Offset: 0x00004FF2
		public static string ApplicationBaseDirectory
		{
			get
			{
				return AppDomain.CurrentDomain.BaseDirectory;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060001D0 RID: 464 RVA: 0x00005FFE File Offset: 0x00004FFE
		public static string ConfigurationFileLocation
		{
			get
			{
				return AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060001D1 RID: 465 RVA: 0x0000600F File Offset: 0x0000500F
		public static string EntryAssemblyLocation
		{
			get
			{
				return Assembly.GetEntryAssembly().Location;
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060001D2 RID: 466 RVA: 0x0000601B File Offset: 0x0000501B
		public static int CurrentThreadId
		{
			get
			{
				return Thread.CurrentThread.ManagedThreadId;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x00006028 File Offset: 0x00005028
		public static string HostName
		{
			get
			{
				if (SystemInfo.s_hostName == null)
				{
					try
					{
						SystemInfo.s_hostName = Dns.GetHostName();
					}
					catch (SocketException)
					{
						LogLog.Debug(SystemInfo.declaringType, "Socket exception occurred while getting the dns hostname. Error Ignored.");
					}
					catch (SecurityException)
					{
						LogLog.Debug(SystemInfo.declaringType, "Security exception occurred while getting the dns hostname. Error Ignored.");
					}
					catch (Exception exception)
					{
						LogLog.Debug(SystemInfo.declaringType, "Some other exception occurred while getting the dns hostname. Error Ignored.", exception);
					}
					if (SystemInfo.s_hostName == null || SystemInfo.s_hostName.Length == 0)
					{
						try
						{
							SystemInfo.s_hostName = Environment.MachineName;
						}
						catch (InvalidOperationException)
						{
						}
						catch (SecurityException)
						{
						}
					}
					if (SystemInfo.s_hostName == null || SystemInfo.s_hostName.Length == 0)
					{
						SystemInfo.s_hostName = SystemInfo.s_notAvailableText;
						LogLog.Debug(SystemInfo.declaringType, "Could not determine the hostname. Error Ignored. Empty host name will be used");
					}
				}
				return SystemInfo.s_hostName;
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060001D4 RID: 468 RVA: 0x0000611C File Offset: 0x0000511C
		public static string ApplicationFriendlyName
		{
			get
			{
				if (SystemInfo.s_appFriendlyName == null)
				{
					try
					{
						SystemInfo.s_appFriendlyName = AppDomain.CurrentDomain.FriendlyName;
					}
					catch (SecurityException)
					{
						LogLog.Debug(SystemInfo.declaringType, "Security exception while trying to get current domain friendly name. Error Ignored.");
					}
					if (SystemInfo.s_appFriendlyName == null || SystemInfo.s_appFriendlyName.Length == 0)
					{
						try
						{
							SystemInfo.s_appFriendlyName = Path.GetFileName(SystemInfo.EntryAssemblyLocation);
						}
						catch (SecurityException)
						{
						}
					}
					if (SystemInfo.s_appFriendlyName == null || SystemInfo.s_appFriendlyName.Length == 0)
					{
						SystemInfo.s_appFriendlyName = SystemInfo.s_notAvailableText;
					}
				}
				return SystemInfo.s_appFriendlyName;
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060001D5 RID: 469 RVA: 0x000061BC File Offset: 0x000051BC
		[Obsolete("Use ProcessStartTimeUtc and convert to local time if needed.")]
		public static DateTime ProcessStartTime
		{
			get
			{
				return SystemInfo.s_processStartTimeUtc.ToLocalTime();
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060001D6 RID: 470 RVA: 0x000061C8 File Offset: 0x000051C8
		public static DateTime ProcessStartTimeUtc
		{
			get
			{
				return SystemInfo.s_processStartTimeUtc;
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060001D7 RID: 471 RVA: 0x000061CF File Offset: 0x000051CF
		// (set) Token: 0x060001D8 RID: 472 RVA: 0x000061D6 File Offset: 0x000051D6
		public static string NullText
		{
			get
			{
				return SystemInfo.s_nullText;
			}
			set
			{
				SystemInfo.s_nullText = value;
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060001D9 RID: 473 RVA: 0x000061DE File Offset: 0x000051DE
		// (set) Token: 0x060001DA RID: 474 RVA: 0x000061E5 File Offset: 0x000051E5
		public static string NotAvailableText
		{
			get
			{
				return SystemInfo.s_notAvailableText;
			}
			set
			{
				SystemInfo.s_notAvailableText = value;
			}
		}

		// Token: 0x060001DB RID: 475 RVA: 0x000061F0 File Offset: 0x000051F0
		public static string AssemblyLocationInfo(Assembly myAssembly)
		{
			if (myAssembly.GlobalAssemblyCache)
			{
				return "Global Assembly Cache";
			}
			string result;
			try
			{
				if (myAssembly.IsDynamic)
				{
					result = "Dynamic Assembly";
				}
				else
				{
					result = myAssembly.Location;
				}
			}
			catch (NotSupportedException)
			{
				result = "Dynamic Assembly";
			}
			catch (TargetInvocationException ex)
			{
				result = "Location Detect Failed (" + ex.Message + ")";
			}
			catch (ArgumentException ex2)
			{
				result = "Location Detect Failed (" + ex2.Message + ")";
			}
			catch (SecurityException)
			{
				result = "Location Permission Denied";
			}
			return result;
		}

		// Token: 0x060001DC RID: 476 RVA: 0x000062A0 File Offset: 0x000052A0
		public static string AssemblyQualifiedName(Type type)
		{
			return type.FullName + ", " + type.Assembly.FullName;
		}

		// Token: 0x060001DD RID: 477 RVA: 0x000062C0 File Offset: 0x000052C0
		public static string AssemblyShortName(Assembly myAssembly)
		{
			string text = myAssembly.FullName;
			int num = text.IndexOf(',');
			if (num > 0)
			{
				text = text.Substring(0, num);
			}
			return text.Trim();
		}

		// Token: 0x060001DE RID: 478 RVA: 0x000062F0 File Offset: 0x000052F0
		public static string AssemblyFileName(Assembly myAssembly)
		{
			return Path.GetFileName(myAssembly.Location);
		}

		// Token: 0x060001DF RID: 479 RVA: 0x000062FD File Offset: 0x000052FD
		public static Type GetTypeFromString(Type relativeType, string typeName, bool throwOnError, bool ignoreCase)
		{
			return SystemInfo.GetTypeFromString(relativeType.Assembly, typeName, throwOnError, ignoreCase);
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x0000630D File Offset: 0x0000530D
		public static Type GetTypeFromString(string typeName, bool throwOnError, bool ignoreCase)
		{
			return SystemInfo.GetTypeFromString(Assembly.GetCallingAssembly(), typeName, throwOnError, ignoreCase);
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x0000631C File Offset: 0x0000531C
		public static Type GetTypeFromString(Assembly relativeAssembly, string typeName, bool throwOnError, bool ignoreCase)
		{
			if (typeName.IndexOf(',') != -1)
			{
				return Type.GetType(typeName, throwOnError, ignoreCase);
			}
			Type type = relativeAssembly.GetType(typeName, false, ignoreCase);
			if (type != null)
			{
				return type;
			}
			Assembly[] array = null;
			try
			{
				array = AppDomain.CurrentDomain.GetAssemblies();
			}
			catch (SecurityException)
			{
			}
			if (array != null)
			{
				Type type2 = null;
				foreach (Assembly assembly in array)
				{
					Type type3 = assembly.GetType(typeName, false, ignoreCase);
					if (type3 != null)
					{
						LogLog.Debug(SystemInfo.declaringType, string.Concat(new string[]
						{
							"Loaded type [",
							typeName,
							"] from assembly [",
							assembly.FullName,
							"] by searching loaded assemblies."
						}));
						if (!assembly.GlobalAssemblyCache)
						{
							return type3;
						}
						type2 = type3;
					}
				}
				if (type2 != null)
				{
					return type2;
				}
			}
			if (throwOnError)
			{
				throw new TypeLoadException(string.Concat(new string[]
				{
					"Could not load type [",
					typeName,
					"]. Tried assembly [",
					relativeAssembly.FullName,
					"] and all loaded assemblies"
				}));
			}
			return null;
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x00006440 File Offset: 0x00005440
		public static Guid NewGuid()
		{
			return Guid.NewGuid();
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00006447 File Offset: 0x00005447
		public static ArgumentOutOfRangeException CreateArgumentOutOfRangeException(string parameterName, object actualValue, string message)
		{
			return new ArgumentOutOfRangeException(parameterName, actualValue, message);
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x00006454 File Offset: 0x00005454
		public static bool TryParse(string s, out int val)
		{
			val = 0;
			try
			{
				double value;
				if (double.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out value))
				{
					val = Convert.ToInt32(value);
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00006498 File Offset: 0x00005498
		public static bool TryParse(string s, out long val)
		{
			val = 0L;
			try
			{
				double value;
				if (double.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out value))
				{
					val = Convert.ToInt64(value);
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x000064E0 File Offset: 0x000054E0
		public static bool TryParse(string s, out short val)
		{
			val = 0;
			try
			{
				double value;
				if (double.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out value))
				{
					val = Convert.ToInt16(value);
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00006524 File Offset: 0x00005524
		public static string GetAppSetting(string key)
		{
			try
			{
				return ConfigurationManager.AppSettings[key];
			}
			catch (Exception exception)
			{
				LogLog.Error(SystemInfo.declaringType, "Exception while reading ConfigurationSettings. Check your .config file is well formed XML.", exception);
			}
			return null;
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00006568 File Offset: 0x00005568
		public static string ConvertToFullPath(string path)
		{
			if (path == null)
			{
				throw new ArgumentNullException("path");
			}
			string text = "";
			try
			{
				string applicationBaseDirectory = SystemInfo.ApplicationBaseDirectory;
				if (applicationBaseDirectory != null)
				{
					Uri uri = new Uri(applicationBaseDirectory);
					if (uri.IsFile)
					{
						text = uri.LocalPath;
					}
				}
			}
			catch
			{
			}
			if (text != null && text.Length > 0)
			{
				return Path.GetFullPath(Path.Combine(text, path));
			}
			return Path.GetFullPath(path);
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x000065DC File Offset: 0x000055DC
		public static Hashtable CreateCaseInsensitiveHashtable()
		{
			return new Hashtable(StringComparer.OrdinalIgnoreCase);
		}

		// Token: 0x060001EA RID: 490 RVA: 0x000065E8 File Offset: 0x000055E8
		public static bool EqualsIgnoringCase(string a, string b)
		{
			return string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
		}

		// Token: 0x04000060 RID: 96
		private const string DEFAULT_NULL_TEXT = "(null)";

		// Token: 0x04000061 RID: 97
		private const string DEFAULT_NOT_AVAILABLE_TEXT = "NOT AVAILABLE";

		// Token: 0x04000062 RID: 98
		public static readonly Type[] EmptyTypes = new Type[0];

		// Token: 0x04000063 RID: 99
		private static readonly Type declaringType = typeof(SystemInfo);

		// Token: 0x04000064 RID: 100
		private static string s_hostName;

		// Token: 0x04000065 RID: 101
		private static string s_appFriendlyName;

		// Token: 0x04000066 RID: 102
		private static string s_nullText;

		// Token: 0x04000067 RID: 103
		private static string s_notAvailableText;

		// Token: 0x04000068 RID: 104
		private static DateTime s_processStartTimeUtc = DateTime.UtcNow;
	}
}
