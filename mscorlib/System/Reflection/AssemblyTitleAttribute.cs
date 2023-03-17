using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Specifies a description for an assembly.</summary>
	// Token: 0x0200058C RID: 1420
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class AssemblyTitleAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.AssemblyTitleAttribute" /> class.</summary>
		/// <param name="title">The assembly title.</param>
		// Token: 0x0600433C RID: 17212 RVA: 0x000F79DC File Offset: 0x000F5BDC
		[__DynamicallyInvokable]
		public AssemblyTitleAttribute(string title)
		{
			this.m_title = title;
		}

		/// <summary>Gets assembly title information.</summary>
		/// <returns>The assembly title.</returns>
		// Token: 0x170009FD RID: 2557
		// (get) Token: 0x0600433D RID: 17213 RVA: 0x000F79EB File Offset: 0x000F5BEB
		[__DynamicallyInvokable]
		public string Title
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_title;
			}
		}

		// Token: 0x04001B47 RID: 6983
		private string m_title;
	}
}
