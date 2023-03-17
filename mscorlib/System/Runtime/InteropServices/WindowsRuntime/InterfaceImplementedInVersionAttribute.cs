using System;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	/// <summary>Specifies the version of the target type that first implemented the specified interface.</summary>
	// Token: 0x0200099B RID: 2459
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, Inherited = false, AllowMultiple = true)]
	[__DynamicallyInvokable]
	public sealed class InterfaceImplementedInVersionAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.WindowsRuntime.InterfaceImplementedInVersionAttribute" /> class, specifying the interface that the target type implements and the version in which that interface was first implemented.</summary>
		/// <param name="interfaceType">The interface that was first implemented in the specified version of the target type.</param>
		/// <param name="majorVersion">The major component of the version of the target type that first implemented <paramref name="interfaceType" />.</param>
		/// <param name="minorVersion">The minor component of the version of the target type that first implemented <paramref name="interfaceType" />.</param>
		/// <param name="buildVersion">The build component of the version of the target type that first implemented <paramref name="interfaceType" />.</param>
		/// <param name="revisionVersion">The revision component of the version of the target type that first implemented <paramref name="interfaceType" />.</param>
		// Token: 0x060062A6 RID: 25254 RVA: 0x0014FDAA File Offset: 0x0014DFAA
		[__DynamicallyInvokable]
		public InterfaceImplementedInVersionAttribute(Type interfaceType, byte majorVersion, byte minorVersion, byte buildVersion, byte revisionVersion)
		{
			this.m_interfaceType = interfaceType;
			this.m_majorVersion = majorVersion;
			this.m_minorVersion = minorVersion;
			this.m_buildVersion = buildVersion;
			this.m_revisionVersion = revisionVersion;
		}

		/// <summary>Gets the type of the interface that the target type implements.</summary>
		/// <returns>The type of the interface.</returns>
		// Token: 0x17001123 RID: 4387
		// (get) Token: 0x060062A7 RID: 25255 RVA: 0x0014FDD7 File Offset: 0x0014DFD7
		[__DynamicallyInvokable]
		public Type InterfaceType
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_interfaceType;
			}
		}

		/// <summary>Gets the major component of the version of the target type that first implemented the interface.</summary>
		/// <returns>The major component of the version.</returns>
		// Token: 0x17001124 RID: 4388
		// (get) Token: 0x060062A8 RID: 25256 RVA: 0x0014FDDF File Offset: 0x0014DFDF
		[__DynamicallyInvokable]
		public byte MajorVersion
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_majorVersion;
			}
		}

		/// <summary>Gets the minor component of the version of the target type that first implemented the interface.</summary>
		/// <returns>The minor component of the version.</returns>
		// Token: 0x17001125 RID: 4389
		// (get) Token: 0x060062A9 RID: 25257 RVA: 0x0014FDE7 File Offset: 0x0014DFE7
		[__DynamicallyInvokable]
		public byte MinorVersion
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_minorVersion;
			}
		}

		/// <summary>Gets the build component of the version of the target type that first implemented the interface.</summary>
		/// <returns>The build component of the version.</returns>
		// Token: 0x17001126 RID: 4390
		// (get) Token: 0x060062AA RID: 25258 RVA: 0x0014FDEF File Offset: 0x0014DFEF
		[__DynamicallyInvokable]
		public byte BuildVersion
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_buildVersion;
			}
		}

		/// <summary>Gets the revision component of the version of the target type that first implemented the interface.</summary>
		/// <returns>The revision component of the version.</returns>
		// Token: 0x17001127 RID: 4391
		// (get) Token: 0x060062AB RID: 25259 RVA: 0x0014FDF7 File Offset: 0x0014DFF7
		[__DynamicallyInvokable]
		public byte RevisionVersion
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_revisionVersion;
			}
		}

		// Token: 0x04002C20 RID: 11296
		private Type m_interfaceType;

		// Token: 0x04002C21 RID: 11297
		private byte m_majorVersion;

		// Token: 0x04002C22 RID: 11298
		private byte m_minorVersion;

		// Token: 0x04002C23 RID: 11299
		private byte m_buildVersion;

		// Token: 0x04002C24 RID: 11300
		private byte m_revisionVersion;
	}
}
