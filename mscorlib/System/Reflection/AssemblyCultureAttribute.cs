using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Specifies which culture the assembly supports.</summary>
	// Token: 0x02000591 RID: 1425
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class AssemblyCultureAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.AssemblyCultureAttribute" /> class with the culture supported by the assembly being attributed.</summary>
		/// <param name="culture">The culture supported by the attributed assembly.</param>
		// Token: 0x06004346 RID: 17222 RVA: 0x000F7A5D File Offset: 0x000F5C5D
		[__DynamicallyInvokable]
		public AssemblyCultureAttribute(string culture)
		{
			this.m_culture = culture;
		}

		/// <summary>Gets the supported culture of the attributed assembly.</summary>
		/// <returns>A string containing the name of the supported culture.</returns>
		// Token: 0x17000A02 RID: 2562
		// (get) Token: 0x06004347 RID: 17223 RVA: 0x000F7A6C File Offset: 0x000F5C6C
		[__DynamicallyInvokable]
		public string Culture
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_culture;
			}
		}

		// Token: 0x04001B4C RID: 6988
		private string m_culture;
	}
}
