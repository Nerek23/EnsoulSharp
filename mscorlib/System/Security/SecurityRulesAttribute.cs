using System;

namespace System.Security
{
	/// <summary>Indicates the set of security rules the common language runtime should enforce for an assembly.</summary>
	// Token: 0x020001CC RID: 460
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
	public sealed class SecurityRulesAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.SecurityRulesAttribute" /> class using the specified rule set value.</summary>
		/// <param name="ruleSet">One of the enumeration values that specifies the transparency rules set.</param>
		// Token: 0x06001C26 RID: 7206 RVA: 0x00060E0D File Offset: 0x0005F00D
		public SecurityRulesAttribute(SecurityRuleSet ruleSet)
		{
			this.m_ruleSet = ruleSet;
		}

		/// <summary>Determines whether fully trusted transparent code should skip Microsoft intermediate language (MSIL) verification.</summary>
		/// <returns>
		///   <see langword="true" /> if MSIL verification should be skipped; otherwise, <see langword="false" />. The default is <see langword="false" />.</returns>
		// Token: 0x1700032C RID: 812
		// (get) Token: 0x06001C27 RID: 7207 RVA: 0x00060E1C File Offset: 0x0005F01C
		// (set) Token: 0x06001C28 RID: 7208 RVA: 0x00060E24 File Offset: 0x0005F024
		public bool SkipVerificationInFullTrust
		{
			get
			{
				return this.m_skipVerificationInFullTrust;
			}
			set
			{
				this.m_skipVerificationInFullTrust = value;
			}
		}

		/// <summary>Gets the rule set to be applied.</summary>
		/// <returns>One of the enumeration values that specifies the transparency rules to be applied.</returns>
		// Token: 0x1700032D RID: 813
		// (get) Token: 0x06001C29 RID: 7209 RVA: 0x00060E2D File Offset: 0x0005F02D
		public SecurityRuleSet RuleSet
		{
			get
			{
				return this.m_ruleSet;
			}
		}

		// Token: 0x040009CA RID: 2506
		private SecurityRuleSet m_ruleSet;

		// Token: 0x040009CB RID: 2507
		private bool m_skipVerificationInFullTrust;
	}
}
