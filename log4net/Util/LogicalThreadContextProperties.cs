using System;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace log4net.Util
{
	// Token: 0x02000016 RID: 22
	public sealed class LogicalThreadContextProperties : ContextPropertiesBase
	{
		// Token: 0x060000F1 RID: 241 RVA: 0x00003E83 File Offset: 0x00002E83
		internal LogicalThreadContextProperties()
		{
		}

		// Token: 0x17000028 RID: 40
		public override object this[string key]
		{
			get
			{
				PropertiesDictionary properties = this.GetProperties(false);
				if (properties != null)
				{
					return properties[key];
				}
				return null;
			}
			set
			{
				PropertiesDictionary propertiesDictionary = new PropertiesDictionary(this.GetProperties(true));
				propertiesDictionary[key] = value;
				LogicalThreadContextProperties.SetLogicalProperties(propertiesDictionary);
			}
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00003EC8 File Offset: 0x00002EC8
		public void Remove(string key)
		{
			PropertiesDictionary properties = this.GetProperties(false);
			if (properties != null)
			{
				PropertiesDictionary propertiesDictionary = new PropertiesDictionary(properties);
				propertiesDictionary.Remove(key);
				LogicalThreadContextProperties.SetLogicalProperties(propertiesDictionary);
			}
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00003EF2 File Offset: 0x00002EF2
		public void Clear()
		{
			if (this.GetProperties(false) != null)
			{
				LogicalThreadContextProperties.SetLogicalProperties(new PropertiesDictionary());
			}
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00003F08 File Offset: 0x00002F08
		internal PropertiesDictionary GetProperties(bool create)
		{
			if (!this.m_disabled)
			{
				try
				{
					PropertiesDictionary propertiesDictionary = LogicalThreadContextProperties.GetLogicalProperties();
					if (propertiesDictionary == null && create)
					{
						propertiesDictionary = new PropertiesDictionary();
						LogicalThreadContextProperties.SetLogicalProperties(propertiesDictionary);
					}
					return propertiesDictionary;
				}
				catch (SecurityException exception)
				{
					this.m_disabled = true;
					LogLog.Warn(LogicalThreadContextProperties.declaringType, "SecurityException while accessing CallContext. Disabling LogicalThreadContextProperties", exception);
				}
			}
			if (create)
			{
				return new PropertiesDictionary();
			}
			return null;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00003F74 File Offset: 0x00002F74
		[SecuritySafeCritical]
		private static PropertiesDictionary GetLogicalProperties()
		{
			return CallContext.LogicalGetData("log4net.Util.LogicalThreadContextProperties") as PropertiesDictionary;
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00003F85 File Offset: 0x00002F85
		[SecuritySafeCritical]
		private static void SetLogicalProperties(PropertiesDictionary properties)
		{
			CallContext.LogicalSetData("log4net.Util.LogicalThreadContextProperties", properties);
		}

		// Token: 0x04000020 RID: 32
		private const string c_SlotName = "log4net.Util.LogicalThreadContextProperties";

		// Token: 0x04000021 RID: 33
		private bool m_disabled;

		// Token: 0x04000022 RID: 34
		private static readonly Type declaringType = typeof(LogicalThreadContextProperties);
	}
}
