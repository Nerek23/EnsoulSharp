using System;

namespace log4net.Util.TypeConverters
{
	// Token: 0x0200003F RID: 63
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Interface)]
	public sealed class TypeConverterAttribute : Attribute
	{
		// Token: 0x0600024D RID: 589 RVA: 0x000074A8 File Offset: 0x000064A8
		public TypeConverterAttribute()
		{
		}

		// Token: 0x0600024E RID: 590 RVA: 0x000074B0 File Offset: 0x000064B0
		public TypeConverterAttribute(string typeName)
		{
			this.m_typeName = typeName;
		}

		// Token: 0x0600024F RID: 591 RVA: 0x000074BF File Offset: 0x000064BF
		public TypeConverterAttribute(Type converterType)
		{
			this.m_typeName = SystemInfo.AssemblyQualifiedName(converterType);
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000250 RID: 592 RVA: 0x000074D3 File Offset: 0x000064D3
		// (set) Token: 0x06000251 RID: 593 RVA: 0x000074DB File Offset: 0x000064DB
		public string ConverterTypeName
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

		// Token: 0x0400007D RID: 125
		private string m_typeName;
	}
}
