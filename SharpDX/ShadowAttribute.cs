using System;
using System.Reflection;

namespace SharpDX
{
	// Token: 0x0200002D RID: 45
	[AttributeUsage(AttributeTargets.Interface)]
	internal class ShadowAttribute : Attribute
	{
		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000160 RID: 352 RVA: 0x00004A0D File Offset: 0x00002C0D
		public Type Type
		{
			get
			{
				return this.type;
			}
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00004A15 File Offset: 0x00002C15
		public ShadowAttribute(Type typeOfTheAssociatedShadow)
		{
			this.type = typeOfTheAssociatedShadow;
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00004A24 File Offset: 0x00002C24
		public static ShadowAttribute Get(Type type)
		{
			return type.GetTypeInfo().GetCustomAttribute<ShadowAttribute>();
		}

		// Token: 0x04000055 RID: 85
		private Type type;
	}
}
