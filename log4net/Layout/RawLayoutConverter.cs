using System;
using log4net.Util.TypeConverters;

namespace log4net.Layout
{
	// Token: 0x0200006F RID: 111
	public class RawLayoutConverter : IConvertFrom
	{
		// Token: 0x060003A9 RID: 937 RVA: 0x0000C15E File Offset: 0x0000B15E
		public bool CanConvertFrom(Type sourceType)
		{
			return typeof(ILayout).IsAssignableFrom(sourceType);
		}

		// Token: 0x060003AA RID: 938 RVA: 0x0000C170 File Offset: 0x0000B170
		public object ConvertFrom(object source)
		{
			ILayout layout = source as ILayout;
			if (layout != null)
			{
				return new Layout2RawLayoutAdapter(layout);
			}
			throw ConversionNotSupportedException.Create(typeof(IRawLayout), source);
		}
	}
}
