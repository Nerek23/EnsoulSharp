using System;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001BB RID: 443
	[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
	public class CustomEffectInputAttribute : Attribute
	{
		// Token: 0x06000886 RID: 2182 RVA: 0x00018983 File Offset: 0x00016B83
		public CustomEffectInputAttribute(string input)
		{
			this.input = input;
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x06000887 RID: 2183 RVA: 0x00018992 File Offset: 0x00016B92
		public string Input
		{
			get
			{
				return this.input;
			}
		}

		// Token: 0x04000610 RID: 1552
		private string input;
	}
}
