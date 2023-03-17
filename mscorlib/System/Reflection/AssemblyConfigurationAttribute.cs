using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Specifies the build configuration, such as retail or debug, for an assembly.</summary>
	// Token: 0x0200058D RID: 1421
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class AssemblyConfigurationAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.AssemblyConfigurationAttribute" /> class.</summary>
		/// <param name="configuration">The assembly configuration.</param>
		// Token: 0x0600433E RID: 17214 RVA: 0x000F79F3 File Offset: 0x000F5BF3
		[__DynamicallyInvokable]
		public AssemblyConfigurationAttribute(string configuration)
		{
			this.m_configuration = configuration;
		}

		/// <summary>Gets assembly configuration information.</summary>
		/// <returns>A string containing the assembly configuration information.</returns>
		// Token: 0x170009FE RID: 2558
		// (get) Token: 0x0600433F RID: 17215 RVA: 0x000F7A02 File Offset: 0x000F5C02
		[__DynamicallyInvokable]
		public string Configuration
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_configuration;
			}
		}

		// Token: 0x04001B48 RID: 6984
		private string m_configuration;
	}
}
