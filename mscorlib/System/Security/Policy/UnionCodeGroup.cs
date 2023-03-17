using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace System.Security.Policy
{
	/// <summary>Represents a code group whose policy statement is the union of the current code group's policy statement and the policy statement of all its matching child code groups. This class cannot be inherited.</summary>
	// Token: 0x02000341 RID: 833
	[ComVisible(true)]
	[Obsolete("This type is obsolete and will be removed in a future release of the .NET Framework. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
	[Serializable]
	public sealed class UnionCodeGroup : CodeGroup, IUnionSemanticCodeGroup
	{
		// Token: 0x06002A56 RID: 10838 RVA: 0x0009D84E File Offset: 0x0009BA4E
		internal UnionCodeGroup()
		{
		}

		// Token: 0x06002A57 RID: 10839 RVA: 0x0009D856 File Offset: 0x0009BA56
		internal UnionCodeGroup(IMembershipCondition membershipCondition, PermissionSet permSet) : base(membershipCondition, permSet)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Policy.UnionCodeGroup" /> class.</summary>
		/// <param name="membershipCondition">A membership condition that tests evidence to determine whether this code group applies policy.</param>
		/// <param name="policy">The policy statement for the code group in the form of a permission set and attributes to grant code that matches the membership condition.</param>
		/// <exception cref="T:System.ArgumentException">The type of the <paramref name="membershipCondition" /> parameter is not valid.  
		///  -or-  
		///  The type of the <paramref name="policy" /> parameter is not valid.</exception>
		// Token: 0x06002A58 RID: 10840 RVA: 0x0009D860 File Offset: 0x0009BA60
		public UnionCodeGroup(IMembershipCondition membershipCondition, PolicyStatement policy) : base(membershipCondition, policy)
		{
		}

		/// <summary>Resolves policy for the code group and its descendants for a set of evidence.</summary>
		/// <param name="evidence">The evidence for the assembly.</param>
		/// <returns>A policy statement consisting of the permissions granted by the code group with optional attributes, or <see langword="null" /> if the code group does not apply (the membership condition does not match the specified evidence).</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="evidence" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.Security.Policy.PolicyException">More than one code group (including the parent code group and any child code groups) is marked <see cref="F:System.Security.Policy.PolicyStatementAttribute.Exclusive" />.</exception>
		// Token: 0x06002A59 RID: 10841 RVA: 0x0009D86C File Offset: 0x0009BA6C
		[SecuritySafeCritical]
		public override PolicyStatement Resolve(Evidence evidence)
		{
			if (evidence == null)
			{
				throw new ArgumentNullException("evidence");
			}
			object obj = null;
			if (PolicyManager.CheckMembershipCondition(base.MembershipCondition, evidence, out obj))
			{
				PolicyStatement policyStatement = base.PolicyStatement;
				IDelayEvaluatedEvidence delayEvaluatedEvidence = obj as IDelayEvaluatedEvidence;
				bool flag = delayEvaluatedEvidence != null && !delayEvaluatedEvidence.IsVerified;
				if (flag)
				{
					policyStatement.AddDependentEvidence(delayEvaluatedEvidence);
				}
				bool flag2 = false;
				IEnumerator enumerator = base.Children.GetEnumerator();
				while (enumerator.MoveNext() && !flag2)
				{
					PolicyStatement policyStatement2 = PolicyManager.ResolveCodeGroup(enumerator.Current as CodeGroup, evidence);
					if (policyStatement2 != null)
					{
						policyStatement.InplaceUnion(policyStatement2);
						if ((policyStatement2.Attributes & PolicyStatementAttribute.Exclusive) == PolicyStatementAttribute.Exclusive)
						{
							flag2 = true;
						}
					}
				}
				return policyStatement;
			}
			return null;
		}

		// Token: 0x06002A5A RID: 10842 RVA: 0x0009D912 File Offset: 0x0009BB12
		PolicyStatement IUnionSemanticCodeGroup.InternalResolve(Evidence evidence)
		{
			if (evidence == null)
			{
				throw new ArgumentNullException("evidence");
			}
			if (base.MembershipCondition.Check(evidence))
			{
				return base.PolicyStatement;
			}
			return null;
		}

		/// <summary>Resolves matching code groups.</summary>
		/// <param name="evidence">The evidence for the assembly.</param>
		/// <returns>The complete set of code groups that were matched by the evidence.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="evidence" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06002A5B RID: 10843 RVA: 0x0009D938 File Offset: 0x0009BB38
		public override CodeGroup ResolveMatchingCodeGroups(Evidence evidence)
		{
			if (evidence == null)
			{
				throw new ArgumentNullException("evidence");
			}
			if (base.MembershipCondition.Check(evidence))
			{
				CodeGroup codeGroup = this.Copy();
				codeGroup.Children = new ArrayList();
				foreach (object obj in base.Children)
				{
					CodeGroup codeGroup2 = ((CodeGroup)obj).ResolveMatchingCodeGroups(evidence);
					if (codeGroup2 != null)
					{
						codeGroup.AddChild(codeGroup2);
					}
				}
				return codeGroup;
			}
			return null;
		}

		/// <summary>Makes a deep copy of the current code group.</summary>
		/// <returns>An equivalent copy of the current code group, including its membership conditions and child code groups.</returns>
		// Token: 0x06002A5C RID: 10844 RVA: 0x0009D9A8 File Offset: 0x0009BBA8
		public override CodeGroup Copy()
		{
			UnionCodeGroup unionCodeGroup = new UnionCodeGroup();
			unionCodeGroup.MembershipCondition = base.MembershipCondition;
			unionCodeGroup.PolicyStatement = base.PolicyStatement;
			unionCodeGroup.Name = base.Name;
			unionCodeGroup.Description = base.Description;
			foreach (object obj in base.Children)
			{
				unionCodeGroup.AddChild((CodeGroup)obj);
			}
			return unionCodeGroup;
		}

		/// <summary>Gets the merge logic.</summary>
		/// <returns>Always the string "Union".</returns>
		// Token: 0x170005BA RID: 1466
		// (get) Token: 0x06002A5D RID: 10845 RVA: 0x0009DA13 File Offset: 0x0009BC13
		public override string MergeLogic
		{
			get
			{
				return Environment.GetResourceString("MergeLogic_Union");
			}
		}

		// Token: 0x06002A5E RID: 10846 RVA: 0x0009DA1F File Offset: 0x0009BC1F
		internal override string GetTypeName()
		{
			return "System.Security.Policy.UnionCodeGroup";
		}
	}
}
