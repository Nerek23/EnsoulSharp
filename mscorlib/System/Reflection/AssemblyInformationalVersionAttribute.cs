using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Defines additional version information for an assembly manifest.</summary>
	// Token: 0x0200058F RID: 1423
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class AssemblyInformationalVersionAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.AssemblyInformationalVersionAttribute" /> class.</summary>
		/// <param name="informationalVersion">The assembly version information.</param>
		// Token: 0x06004342 RID: 17218 RVA: 0x000F7A21 File Offset: 0x000F5C21
		[__DynamicallyInvokable]
		public AssemblyInformationalVersionAttribute(string informationalVersion)
		{
			this.m_informationalVersion = informationalVersion;
		}

		/// <summary>Gets version information.</summary>
		/// <returns>A string containing the version information.</returns>
		// Token: 0x17000A00 RID: 2560
		// (get) Token: 0x06004343 RID: 17219 RVA: 0x000F7A30 File Offset: 0x000F5C30
		[__DynamicallyInvokable]
		public string InformationalVersion
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_informationalVersion;
			}
		}

		// Token: 0x04001B4A RID: 6986
		private string m_informationalVersion;
	}
}
