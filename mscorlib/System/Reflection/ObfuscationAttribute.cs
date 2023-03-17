using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Instructs obfuscation tools to take the specified actions for an assembly, type, or member.</summary>
	// Token: 0x020005E3 RID: 1507
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	public sealed class ObfuscationAttribute : Attribute
	{
		/// <summary>Gets or sets a <see cref="T:System.Boolean" /> value indicating whether the obfuscation tool should remove this attribute after processing.</summary>
		/// <returns>
		///   <see langword="true" /> if an obfuscation tool should remove the attribute after processing; otherwise, <see langword="false" />. The default is <see langword="true" />.</returns>
		// Token: 0x17000AFB RID: 2811
		// (get) Token: 0x060046D4 RID: 18132 RVA: 0x001013B3 File Offset: 0x000FF5B3
		// (set) Token: 0x060046D5 RID: 18133 RVA: 0x001013BB File Offset: 0x000FF5BB
		public bool StripAfterObfuscation
		{
			get
			{
				return this.m_strip;
			}
			set
			{
				this.m_strip = value;
			}
		}

		/// <summary>Gets or sets a <see cref="T:System.Boolean" /> value indicating whether the obfuscation tool should exclude the type or member from obfuscation.</summary>
		/// <returns>
		///   <see langword="true" /> if the type or member to which this attribute is applied should be excluded from obfuscation; otherwise, <see langword="false" />. The default is <see langword="true" />.</returns>
		// Token: 0x17000AFC RID: 2812
		// (get) Token: 0x060046D6 RID: 18134 RVA: 0x001013C4 File Offset: 0x000FF5C4
		// (set) Token: 0x060046D7 RID: 18135 RVA: 0x001013CC File Offset: 0x000FF5CC
		public bool Exclude
		{
			get
			{
				return this.m_exclude;
			}
			set
			{
				this.m_exclude = value;
			}
		}

		/// <summary>Gets or sets a <see cref="T:System.Boolean" /> value indicating whether the attribute of a type is to apply to the members of the type.</summary>
		/// <returns>
		///   <see langword="true" /> if the attribute is to apply to the members of the type; otherwise, <see langword="false" />. The default is <see langword="true" />.</returns>
		// Token: 0x17000AFD RID: 2813
		// (get) Token: 0x060046D8 RID: 18136 RVA: 0x001013D5 File Offset: 0x000FF5D5
		// (set) Token: 0x060046D9 RID: 18137 RVA: 0x001013DD File Offset: 0x000FF5DD
		public bool ApplyToMembers
		{
			get
			{
				return this.m_applyToMembers;
			}
			set
			{
				this.m_applyToMembers = value;
			}
		}

		/// <summary>Gets or sets a string value that is recognized by the obfuscation tool, and which specifies processing options.</summary>
		/// <returns>A string value that is recognized by the obfuscation tool, and which specifies processing options. The default is "all".</returns>
		// Token: 0x17000AFE RID: 2814
		// (get) Token: 0x060046DA RID: 18138 RVA: 0x001013E6 File Offset: 0x000FF5E6
		// (set) Token: 0x060046DB RID: 18139 RVA: 0x001013EE File Offset: 0x000FF5EE
		public string Feature
		{
			get
			{
				return this.m_feature;
			}
			set
			{
				this.m_feature = value;
			}
		}

		// Token: 0x04001D0A RID: 7434
		private bool m_strip = true;

		// Token: 0x04001D0B RID: 7435
		private bool m_exclude = true;

		// Token: 0x04001D0C RID: 7436
		private bool m_applyToMembers = true;

		// Token: 0x04001D0D RID: 7437
		private string m_feature = "all";
	}
}
