using System;

namespace System.Runtime.Versioning
{
	/// <summary>Identifies the version of the .NET Framework that a particular assembly was compiled against.</summary>
	// Token: 0x020006F7 RID: 1783
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
	[__DynamicallyInvokable]
	public sealed class TargetFrameworkAttribute : Attribute
	{
		/// <summary>Initializes an instance of the <see cref="T:System.Runtime.Versioning.TargetFrameworkAttribute" /> class by specifying the .NET Framework version against which an assembly was built.</summary>
		/// <param name="frameworkName">The version of the .NET Framework against which the assembly was built.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="frameworkName" /> is <see langword="null" />.</exception>
		// Token: 0x06005042 RID: 20546 RVA: 0x0011A5AD File Offset: 0x001187AD
		[__DynamicallyInvokable]
		public TargetFrameworkAttribute(string frameworkName)
		{
			if (frameworkName == null)
			{
				throw new ArgumentNullException("frameworkName");
			}
			this._frameworkName = frameworkName;
		}

		/// <summary>Gets the name of the .NET Framework version against which a particular assembly was compiled.</summary>
		/// <returns>The name of the .NET Framework version with which the assembly was compiled.</returns>
		// Token: 0x17000D56 RID: 3414
		// (get) Token: 0x06005043 RID: 20547 RVA: 0x0011A5CA File Offset: 0x001187CA
		[__DynamicallyInvokable]
		public string FrameworkName
		{
			[__DynamicallyInvokable]
			get
			{
				return this._frameworkName;
			}
		}

		/// <summary>Gets the display name of the .NET Framework version against which an assembly was built.</summary>
		/// <returns>The display name of the .NET Framework version.</returns>
		// Token: 0x17000D57 RID: 3415
		// (get) Token: 0x06005044 RID: 20548 RVA: 0x0011A5D2 File Offset: 0x001187D2
		// (set) Token: 0x06005045 RID: 20549 RVA: 0x0011A5DA File Offset: 0x001187DA
		[__DynamicallyInvokable]
		public string FrameworkDisplayName
		{
			[__DynamicallyInvokable]
			get
			{
				return this._frameworkDisplayName;
			}
			[__DynamicallyInvokable]
			set
			{
				this._frameworkDisplayName = value;
			}
		}

		// Token: 0x04002368 RID: 9064
		private string _frameworkName;

		// Token: 0x04002369 RID: 9065
		private string _frameworkDisplayName;
	}
}
