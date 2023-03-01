using System;
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Text;
using log4net.Core;
using log4net.Util.TypeConverters;

namespace log4net.Util
{
	// Token: 0x02000022 RID: 34
	public sealed class OptionConverter
	{
		// Token: 0x06000157 RID: 343 RVA: 0x000048E1 File Offset: 0x000038E1
		private OptionConverter()
		{
		}

		// Token: 0x06000158 RID: 344 RVA: 0x000048EC File Offset: 0x000038EC
		public static bool ToBoolean(string argValue, bool defaultValue)
		{
			if (argValue != null && argValue.Length > 0)
			{
				try
				{
					return bool.Parse(argValue);
				}
				catch (Exception exception)
				{
					LogLog.Error(OptionConverter.declaringType, "[" + argValue + "] is not in proper bool form.", exception);
				}
				return defaultValue;
			}
			return defaultValue;
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00004940 File Offset: 0x00003940
		public static long ToFileSize(string argValue, long defaultValue)
		{
			if (argValue == null)
			{
				return defaultValue;
			}
			string text = argValue.Trim().ToUpperInvariant();
			long num = 1L;
			int length;
			if ((length = text.IndexOf("KB")) != -1)
			{
				num = 1024L;
				text = text.Substring(0, length);
			}
			else if ((length = text.IndexOf("MB")) != -1)
			{
				num = 1048576L;
				text = text.Substring(0, length);
			}
			else if ((length = text.IndexOf("GB")) != -1)
			{
				num = 1073741824L;
				text = text.Substring(0, length);
			}
			if (text != null)
			{
				text = text.Trim();
				long num2;
				if (SystemInfo.TryParse(text, out num2))
				{
					return num2 * num;
				}
				LogLog.Error(OptionConverter.declaringType, "OptionConverter: [" + text + "] is not in the correct file size syntax.");
			}
			return defaultValue;
		}

		// Token: 0x0600015A RID: 346 RVA: 0x000049F8 File Offset: 0x000039F8
		public static object ConvertStringTo(Type target, string txt)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (typeof(string) == target || typeof(object) == target)
			{
				return txt;
			}
			IConvertFrom convertFrom = ConverterRegistry.GetConvertFrom(target);
			if (convertFrom != null && convertFrom.CanConvertFrom(typeof(string)))
			{
				return convertFrom.ConvertFrom(txt);
			}
			if (target.IsEnum)
			{
				return OptionConverter.ParseEnum(target, txt, true);
			}
			MethodInfo method = target.GetMethod("Parse", new Type[]
			{
				typeof(string)
			});
			if (method != null)
			{
				return method.Invoke(null, BindingFlags.InvokeMethod, null, new object[]
				{
					txt
				}, CultureInfo.InvariantCulture);
			}
			return null;
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00004ABC File Offset: 0x00003ABC
		public static bool CanConvertTypeTo(Type sourceType, Type targetType)
		{
			if (sourceType == null || targetType == null)
			{
				return false;
			}
			if (targetType.IsAssignableFrom(sourceType))
			{
				return true;
			}
			IConvertTo convertTo = ConverterRegistry.GetConvertTo(sourceType, targetType);
			if (convertTo != null && convertTo.CanConvertTo(targetType))
			{
				return true;
			}
			IConvertFrom convertFrom = ConverterRegistry.GetConvertFrom(targetType);
			return convertFrom != null && convertFrom.CanConvertFrom(sourceType);
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00004B14 File Offset: 0x00003B14
		public static object ConvertTypeTo(object sourceInstance, Type targetType)
		{
			Type type = sourceInstance.GetType();
			if (targetType.IsAssignableFrom(type))
			{
				return sourceInstance;
			}
			IConvertTo convertTo = ConverterRegistry.GetConvertTo(type, targetType);
			if (convertTo != null && convertTo.CanConvertTo(targetType))
			{
				return convertTo.ConvertTo(sourceInstance, targetType);
			}
			IConvertFrom convertFrom = ConverterRegistry.GetConvertFrom(targetType);
			if (convertFrom != null && convertFrom.CanConvertFrom(type))
			{
				return convertFrom.ConvertFrom(sourceInstance);
			}
			throw new ArgumentException(string.Concat(new string[]
			{
				"Cannot convert source object [",
				sourceInstance.ToString(),
				"] to target type [",
				targetType.Name,
				"]"
			}), "sourceInstance");
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00004BAC File Offset: 0x00003BAC
		public static object InstantiateByClassName(string className, Type superClass, object defaultValue)
		{
			if (className != null)
			{
				try
				{
					Type typeFromString = SystemInfo.GetTypeFromString(className, true, true);
					if (!superClass.IsAssignableFrom(typeFromString))
					{
						LogLog.Error(OptionConverter.declaringType, string.Concat(new string[]
						{
							"OptionConverter: A [",
							className,
							"] object is not assignable to a [",
							superClass.FullName,
							"] variable."
						}));
						return defaultValue;
					}
					return Activator.CreateInstance(typeFromString);
				}
				catch (Exception exception)
				{
					LogLog.Error(OptionConverter.declaringType, "Could not instantiate class [" + className + "].", exception);
				}
				return defaultValue;
			}
			return defaultValue;
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00004C48 File Offset: 0x00003C48
		public static string SubstituteVariables(string value, IDictionary props)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			int num2;
			for (;;)
			{
				num2 = value.IndexOf("${", num);
				if (num2 == -1)
				{
					break;
				}
				stringBuilder.Append(value.Substring(num, num2 - num));
				int num3 = value.IndexOf('}', num2);
				if (num3 == -1)
				{
					goto Block_3;
				}
				num2 += 2;
				string key = value.Substring(num2, num3 - num2);
				string text = props[key] as string;
				if (text != null)
				{
					stringBuilder.Append(text);
				}
				num = num3 + 1;
			}
			if (num == 0)
			{
				return value;
			}
			stringBuilder.Append(value.Substring(num, value.Length - num));
			return stringBuilder.ToString();
			Block_3:
			throw new LogException(string.Concat(new string[]
			{
				"[",
				value,
				"] has no closing brace. Opening brace at position [",
				num2.ToString(),
				"]"
			}));
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00004D1A File Offset: 0x00003D1A
		private static object ParseEnum(Type enumType, string value, bool ignoreCase)
		{
			return Enum.Parse(enumType, value, ignoreCase);
		}

		// Token: 0x04000041 RID: 65
		private static readonly Type declaringType = typeof(OptionConverter);

		// Token: 0x04000042 RID: 66
		private const string DELIM_START = "${";

		// Token: 0x04000043 RID: 67
		private const char DELIM_STOP = '}';

		// Token: 0x04000044 RID: 68
		private const int DELIM_START_LEN = 2;

		// Token: 0x04000045 RID: 69
		private const int DELIM_STOP_LEN = 1;
	}
}
