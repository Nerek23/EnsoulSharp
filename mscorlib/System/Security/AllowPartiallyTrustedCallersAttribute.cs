using System;
using System.Runtime.InteropServices;

namespace System.Security
{
	/// <summary>Allows an assembly to be called by partially trusted code. Without this declaration, only fully trusted callers are able to use the assembly. This class cannot be inherited.</summary>
	// Token: 0x020001C4 RID: 452
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class AllowPartiallyTrustedCallersAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.AllowPartiallyTrustedCallersAttribute" /> class.</summary>
		// Token: 0x06001C1D RID: 7197 RVA: 0x00060DBD File Offset: 0x0005EFBD
		[__DynamicallyInvokable]
		public AllowPartiallyTrustedCallersAttribute()
		{
		}

		/// <summary>Gets or sets the default partial trust visibility for code that is marked with the <see cref="T:System.Security.AllowPartiallyTrustedCallersAttribute" /> (APTCA) attribute.</summary>
		/// <returns>One of the enumeration values. The default is <see cref="F:System.Security.PartialTrustVisibilityLevel.VisibleToAllHosts" />.</returns>
		// Token: 0x1700032A RID: 810
		// (get) Token: 0x06001C1E RID: 7198 RVA: 0x00060DC5 File Offset: 0x0005EFC5
		// (set) Token: 0x06001C1F RID: 7199 RVA: 0x00060DCD File Offset: 0x0005EFCD
		public PartialTrustVisibilityLevel PartialTrustVisibilityLevel
		{
			get
			{
				return this._visibilityLevel;
			}
			set
			{
				this._visibilityLevel = value;
			}
		}

		// Token: 0x040009BE RID: 2494
		private PartialTrustVisibilityLevel _visibilityLevel;
	}
}
