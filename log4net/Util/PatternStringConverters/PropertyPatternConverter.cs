using System;
using System.IO;

namespace log4net.Util.PatternStringConverters
{
	// Token: 0x02000049 RID: 73
	internal sealed class PropertyPatternConverter : PatternConverter
	{
		// Token: 0x0600026D RID: 621 RVA: 0x000079F0 File Offset: 0x000069F0
		protected override void Convert(TextWriter writer, object state)
		{
			CompositeProperties compositeProperties = new CompositeProperties();
			PropertiesDictionary properties = LogicalThreadContext.Properties.GetProperties(false);
			if (properties != null)
			{
				compositeProperties.Add(properties);
			}
			PropertiesDictionary properties2 = ThreadContext.Properties.GetProperties(false);
			if (properties2 != null)
			{
				compositeProperties.Add(properties2);
			}
			compositeProperties.Add(GlobalContext.Properties.GetReadOnlyProperties());
			if (this.Option != null)
			{
				PatternConverter.WriteObject(writer, null, compositeProperties[this.Option]);
				return;
			}
			PatternConverter.WriteDictionary(writer, null, compositeProperties.Flatten());
		}
	}
}
