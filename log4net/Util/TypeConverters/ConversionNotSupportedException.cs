using System;
using System.Runtime.Serialization;

namespace log4net.Util.TypeConverters
{
	// Token: 0x02000036 RID: 54
	[Serializable]
	public class ConversionNotSupportedException : ApplicationException
	{
		// Token: 0x06000229 RID: 553 RVA: 0x00006EAB File Offset: 0x00005EAB
		public ConversionNotSupportedException()
		{
		}

		// Token: 0x0600022A RID: 554 RVA: 0x00006EB3 File Offset: 0x00005EB3
		public ConversionNotSupportedException(string message) : base(message)
		{
		}

		// Token: 0x0600022B RID: 555 RVA: 0x00006EBC File Offset: 0x00005EBC
		public ConversionNotSupportedException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x0600022C RID: 556 RVA: 0x00006EC6 File Offset: 0x00005EC6
		protected ConversionNotSupportedException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x0600022D RID: 557 RVA: 0x00006ED0 File Offset: 0x00005ED0
		public static ConversionNotSupportedException Create(Type destinationType, object sourceValue)
		{
			return ConversionNotSupportedException.Create(destinationType, sourceValue, null);
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00006EDC File Offset: 0x00005EDC
		public static ConversionNotSupportedException Create(Type destinationType, object sourceValue, Exception innerException)
		{
			if (sourceValue == null)
			{
				return new ConversionNotSupportedException("Cannot convert value [null] to type [" + ((destinationType != null) ? destinationType.ToString() : null) + "]", innerException);
			}
			string[] array = new string[7];
			array[0] = "Cannot convert from type [";
			int num = 1;
			Type type = sourceValue.GetType();
			array[num] = ((type != null) ? type.ToString() : null);
			array[2] = "] value [";
			array[3] = ((sourceValue != null) ? sourceValue.ToString() : null);
			array[4] = "] to type [";
			array[5] = ((destinationType != null) ? destinationType.ToString() : null);
			array[6] = "]";
			return new ConversionNotSupportedException(string.Concat(array), innerException);
		}
	}
}
