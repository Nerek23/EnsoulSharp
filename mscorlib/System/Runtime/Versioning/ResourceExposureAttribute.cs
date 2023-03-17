using System;
using System.Diagnostics;

namespace System.Runtime.Versioning
{
	/// <summary>Specifies the resource exposure for a member of a class. This class cannot be inherited.</summary>
	// Token: 0x020006F3 RID: 1779
	[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field, Inherited = false)]
	[Conditional("RESOURCE_ANNOTATION_WORK")]
	public sealed class ResourceExposureAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Versioning.ResourceExposureAttribute" /> class with the specified exposure level.</summary>
		/// <param name="exposureLevel">The scope of the resource.</param>
		// Token: 0x0600503B RID: 20539 RVA: 0x0011A2F8 File Offset: 0x001184F8
		public ResourceExposureAttribute(ResourceScope exposureLevel)
		{
			this._resourceExposureLevel = exposureLevel;
		}

		/// <summary>Gets the resource exposure scope.</summary>
		/// <returns>A <see cref="T:System.Runtime.Versioning.ResourceScope" /> object.</returns>
		// Token: 0x17000D55 RID: 3413
		// (get) Token: 0x0600503C RID: 20540 RVA: 0x0011A307 File Offset: 0x00118507
		public ResourceScope ResourceExposureLevel
		{
			get
			{
				return this._resourceExposureLevel;
			}
		}

		// Token: 0x04002356 RID: 9046
		private ResourceScope _resourceExposureLevel;
	}
}
