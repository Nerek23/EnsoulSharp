using System;
using System.Collections;
using System.Net;
using System.Text;
using log4net.Layout;

namespace log4net.Util.TypeConverters
{
	// Token: 0x02000037 RID: 55
	public sealed class ConverterRegistry
	{
		// Token: 0x0600022F RID: 559 RVA: 0x00006F74 File Offset: 0x00005F74
		private ConverterRegistry()
		{
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00006F7C File Offset: 0x00005F7C
		static ConverterRegistry()
		{
			ConverterRegistry.AddConverter(typeof(bool), typeof(BooleanConverter));
			ConverterRegistry.AddConverter(typeof(Encoding), typeof(EncodingConverter));
			ConverterRegistry.AddConverter(typeof(Type), typeof(TypeConverter));
			ConverterRegistry.AddConverter(typeof(PatternLayout), typeof(PatternLayoutConverter));
			ConverterRegistry.AddConverter(typeof(PatternString), typeof(PatternStringConverter));
			ConverterRegistry.AddConverter(typeof(IPAddress), typeof(IPAddressConverter));
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00007038 File Offset: 0x00006038
		public static void AddConverter(Type destinationType, object converter)
		{
			if (destinationType != null && converter != null)
			{
				Hashtable obj = ConverterRegistry.s_type2converter;
				lock (obj)
				{
					ConverterRegistry.s_type2converter[destinationType] = converter;
				}
			}
		}

		// Token: 0x06000232 RID: 562 RVA: 0x0000708C File Offset: 0x0000608C
		public static void AddConverter(Type destinationType, Type converterType)
		{
			ConverterRegistry.AddConverter(destinationType, ConverterRegistry.CreateConverterInstance(converterType));
		}

		// Token: 0x06000233 RID: 563 RVA: 0x0000709C File Offset: 0x0000609C
		public static IConvertTo GetConvertTo(Type sourceType, Type destinationType)
		{
			Hashtable obj = ConverterRegistry.s_type2converter;
			IConvertTo result;
			lock (obj)
			{
				IConvertTo convertTo = ConverterRegistry.s_type2converter[sourceType] as IConvertTo;
				if (convertTo == null)
				{
					convertTo = (ConverterRegistry.GetConverterFromAttribute(sourceType) as IConvertTo);
					if (convertTo != null)
					{
						ConverterRegistry.s_type2converter[sourceType] = convertTo;
					}
				}
				result = convertTo;
			}
			return result;
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00007108 File Offset: 0x00006108
		public static IConvertFrom GetConvertFrom(Type destinationType)
		{
			Hashtable obj = ConverterRegistry.s_type2converter;
			IConvertFrom result;
			lock (obj)
			{
				IConvertFrom convertFrom = ConverterRegistry.s_type2converter[destinationType] as IConvertFrom;
				if (convertFrom == null)
				{
					convertFrom = (ConverterRegistry.GetConverterFromAttribute(destinationType) as IConvertFrom);
					if (convertFrom != null)
					{
						ConverterRegistry.s_type2converter[destinationType] = convertFrom;
					}
				}
				result = convertFrom;
			}
			return result;
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00007174 File Offset: 0x00006174
		private static object GetConverterFromAttribute(Type destinationType)
		{
			object[] customAttributes = destinationType.GetCustomAttributes(typeof(TypeConverterAttribute), true);
			if (customAttributes == null)
			{
				return null;
			}
			object[] array = customAttributes;
			for (int i = 0; i < array.Length; i++)
			{
				TypeConverterAttribute typeConverterAttribute = array[i] as TypeConverterAttribute;
				if (typeConverterAttribute != null)
				{
					return ConverterRegistry.CreateConverterInstance(SystemInfo.GetTypeFromString(destinationType, typeConverterAttribute.ConverterTypeName, false, true));
				}
			}
			return null;
		}

		// Token: 0x06000236 RID: 566 RVA: 0x000071CC File Offset: 0x000061CC
		private static object CreateConverterInstance(Type converterType)
		{
			if (converterType == null)
			{
				throw new ArgumentNullException("converterType", "CreateConverterInstance cannot create instance, converterType is null");
			}
			if (typeof(IConvertFrom).IsAssignableFrom(converterType) || typeof(IConvertTo).IsAssignableFrom(converterType))
			{
				try
				{
					return Activator.CreateInstance(converterType);
				}
				catch (Exception exception)
				{
					LogLog.Error(ConverterRegistry.declaringType, "Cannot CreateConverterInstance of type [" + converterType.FullName + "], Exception in call to Activator.CreateInstance", exception);
					goto IL_89;
				}
			}
			LogLog.Error(ConverterRegistry.declaringType, "Cannot CreateConverterInstance of type [" + converterType.FullName + "], type does not implement IConvertFrom or IConvertTo");
			IL_89:
			return null;
		}

		// Token: 0x0400007A RID: 122
		private static readonly Type declaringType = typeof(ConverterRegistry);

		// Token: 0x0400007B RID: 123
		private static Hashtable s_type2converter = new Hashtable();
	}
}
