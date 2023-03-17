using System;

namespace System.Runtime
{
	/// <summary>Indicates that the .NET Framework class library method to which this attribute is applied is unlikely to be affected by servicing releases, and therefore is eligible to be inlined across Native Image Generator (NGen) images.</summary>
	// Token: 0x020006EC RID: 1772
	[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
	public sealed class TargetedPatchingOptOutAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.TargetedPatchingOptOutAttribute" /> class.</summary>
		/// <param name="reason">The reason why the method to which the <see cref="T:System.Runtime.TargetedPatchingOptOutAttribute" /> attribute is applied is considered to be eligible for inlining across Native Image Generator (NGen) images.</param>
		// Token: 0x06005012 RID: 20498 RVA: 0x00119BF6 File Offset: 0x00117DF6
		public TargetedPatchingOptOutAttribute(string reason)
		{
			this.m_reason = reason;
		}

		/// <summary>Gets the reason why the method to which this attribute is applied is considered to be eligible for inlining across Native Image Generator (NGen) images.</summary>
		/// <returns>The reason why the method is considered to be eligible for inlining across NGen images.</returns>
		// Token: 0x17000D43 RID: 3395
		// (get) Token: 0x06005013 RID: 20499 RVA: 0x00119C05 File Offset: 0x00117E05
		public string Reason
		{
			get
			{
				return this.m_reason;
			}
		}

		// Token: 0x06005014 RID: 20500 RVA: 0x00119C0D File Offset: 0x00117E0D
		private TargetedPatchingOptOutAttribute()
		{
		}

		// Token: 0x04002341 RID: 9025
		private string m_reason;
	}
}
