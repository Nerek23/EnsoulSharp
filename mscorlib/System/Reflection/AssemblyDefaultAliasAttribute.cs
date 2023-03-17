using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Defines a friendly default alias for an assembly manifest.</summary>
	// Token: 0x0200058E RID: 1422
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class AssemblyDefaultAliasAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.AssemblyDefaultAliasAttribute" /> class.</summary>
		/// <param name="defaultAlias">The assembly default alias information.</param>
		// Token: 0x06004340 RID: 17216 RVA: 0x000F7A0A File Offset: 0x000F5C0A
		[__DynamicallyInvokable]
		public AssemblyDefaultAliasAttribute(string defaultAlias)
		{
			this.m_defaultAlias = defaultAlias;
		}

		/// <summary>Gets default alias information.</summary>
		/// <returns>A string containing the default alias information.</returns>
		// Token: 0x170009FF RID: 2559
		// (get) Token: 0x06004341 RID: 17217 RVA: 0x000F7A19 File Offset: 0x000F5C19
		[__DynamicallyInvokable]
		public string DefaultAlias
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_defaultAlias;
			}
		}

		// Token: 0x04001B49 RID: 6985
		private string m_defaultAlias;
	}
}
