using System;
using log4net.Core;
using log4net.Plugin;
using log4net.Util;

namespace log4net.Config
{
	// Token: 0x020000CB RID: 203
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
	[Serializable]
	public sealed class PluginAttribute : Attribute, IPluginFactory
	{
		// Token: 0x060005A8 RID: 1448 RVA: 0x00011E1A File Offset: 0x00010E1A
		public PluginAttribute(string typeName)
		{
			this.m_typeName = typeName;
		}

		// Token: 0x060005A9 RID: 1449 RVA: 0x00011E29 File Offset: 0x00010E29
		public PluginAttribute(Type type)
		{
			this.m_type = type;
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x060005AA RID: 1450 RVA: 0x00011E38 File Offset: 0x00010E38
		// (set) Token: 0x060005AB RID: 1451 RVA: 0x00011E40 File Offset: 0x00010E40
		public Type Type
		{
			get
			{
				return this.m_type;
			}
			set
			{
				this.m_type = value;
			}
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x060005AC RID: 1452 RVA: 0x00011E49 File Offset: 0x00010E49
		// (set) Token: 0x060005AD RID: 1453 RVA: 0x00011E51 File Offset: 0x00010E51
		public string TypeName
		{
			get
			{
				return this.m_typeName;
			}
			set
			{
				this.m_typeName = value;
			}
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x00011E5C File Offset: 0x00010E5C
		public IPlugin CreatePlugin()
		{
			Type type = this.m_type;
			if (this.m_type == null)
			{
				type = SystemInfo.GetTypeFromString(this.m_typeName, true, true);
			}
			if (!typeof(IPlugin).IsAssignableFrom(type))
			{
				throw new LogException("Plugin type [" + type.FullName + "] does not implement the log4net.IPlugin interface");
			}
			return (IPlugin)Activator.CreateInstance(type);
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x00011EC4 File Offset: 0x00010EC4
		public override string ToString()
		{
			if (this.m_type != null)
			{
				return "PluginAttribute[Type=" + this.m_type.FullName + "]";
			}
			return "PluginAttribute[Type=" + this.m_typeName + "]";
		}

		// Token: 0x040001A2 RID: 418
		private string m_typeName;

		// Token: 0x040001A3 RID: 419
		private Type m_type;
	}
}
