using System;

namespace System.Diagnostics.CodeAnalysis
{
	/// <summary>Suppresses reporting of a specific static analysis tool rule violation, allowing multiple suppressions on a single code artifact.</summary>
	// Token: 0x020003ED RID: 1005
	[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
	[Conditional("CODE_ANALYSIS")]
	[__DynamicallyInvokable]
	public sealed class SuppressMessageAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.CodeAnalysis.SuppressMessageAttribute" /> class, specifying the category of the static analysis tool and the identifier for an analysis rule.</summary>
		/// <param name="category">The category for the attribute.</param>
		/// <param name="checkId">The identifier of the analysis tool rule the attribute applies to.</param>
		// Token: 0x0600330E RID: 13070 RVA: 0x000C2245 File Offset: 0x000C0445
		[__DynamicallyInvokable]
		public SuppressMessageAttribute(string category, string checkId)
		{
			this.category = category;
			this.checkId = checkId;
		}

		/// <summary>Gets the category identifying the classification of the attribute.</summary>
		/// <returns>The category identifying the attribute.</returns>
		// Token: 0x1700079C RID: 1948
		// (get) Token: 0x0600330F RID: 13071 RVA: 0x000C225B File Offset: 0x000C045B
		[__DynamicallyInvokable]
		public string Category
		{
			[__DynamicallyInvokable]
			get
			{
				return this.category;
			}
		}

		/// <summary>Gets the identifier of the static analysis tool rule to be suppressed.</summary>
		/// <returns>The identifier of the static analysis tool rule to be suppressed.</returns>
		// Token: 0x1700079D RID: 1949
		// (get) Token: 0x06003310 RID: 13072 RVA: 0x000C2263 File Offset: 0x000C0463
		[__DynamicallyInvokable]
		public string CheckId
		{
			[__DynamicallyInvokable]
			get
			{
				return this.checkId;
			}
		}

		/// <summary>Gets or sets the scope of the code that is relevant for the attribute.</summary>
		/// <returns>The scope of the code that is relevant for the attribute.</returns>
		// Token: 0x1700079E RID: 1950
		// (get) Token: 0x06003311 RID: 13073 RVA: 0x000C226B File Offset: 0x000C046B
		// (set) Token: 0x06003312 RID: 13074 RVA: 0x000C2273 File Offset: 0x000C0473
		[__DynamicallyInvokable]
		public string Scope
		{
			[__DynamicallyInvokable]
			get
			{
				return this.scope;
			}
			[__DynamicallyInvokable]
			set
			{
				this.scope = value;
			}
		}

		/// <summary>Gets or sets a fully qualified path that represents the target of the attribute.</summary>
		/// <returns>A fully qualified path that represents the target of the attribute.</returns>
		// Token: 0x1700079F RID: 1951
		// (get) Token: 0x06003313 RID: 13075 RVA: 0x000C227C File Offset: 0x000C047C
		// (set) Token: 0x06003314 RID: 13076 RVA: 0x000C2284 File Offset: 0x000C0484
		[__DynamicallyInvokable]
		public string Target
		{
			[__DynamicallyInvokable]
			get
			{
				return this.target;
			}
			[__DynamicallyInvokable]
			set
			{
				this.target = value;
			}
		}

		/// <summary>Gets or sets an optional argument expanding on exclusion criteria.</summary>
		/// <returns>A string containing the expanded exclusion criteria.</returns>
		// Token: 0x170007A0 RID: 1952
		// (get) Token: 0x06003315 RID: 13077 RVA: 0x000C228D File Offset: 0x000C048D
		// (set) Token: 0x06003316 RID: 13078 RVA: 0x000C2295 File Offset: 0x000C0495
		[__DynamicallyInvokable]
		public string MessageId
		{
			[__DynamicallyInvokable]
			get
			{
				return this.messageId;
			}
			[__DynamicallyInvokable]
			set
			{
				this.messageId = value;
			}
		}

		/// <summary>Gets or sets the justification for suppressing the code analysis message.</summary>
		/// <returns>The justification for suppressing the message.</returns>
		// Token: 0x170007A1 RID: 1953
		// (get) Token: 0x06003317 RID: 13079 RVA: 0x000C229E File Offset: 0x000C049E
		// (set) Token: 0x06003318 RID: 13080 RVA: 0x000C22A6 File Offset: 0x000C04A6
		[__DynamicallyInvokable]
		public string Justification
		{
			[__DynamicallyInvokable]
			get
			{
				return this.justification;
			}
			[__DynamicallyInvokable]
			set
			{
				this.justification = value;
			}
		}

		// Token: 0x04001666 RID: 5734
		private string category;

		// Token: 0x04001667 RID: 5735
		private string justification;

		// Token: 0x04001668 RID: 5736
		private string checkId;

		// Token: 0x04001669 RID: 5737
		private string scope;

		// Token: 0x0400166A RID: 5738
		private string target;

		// Token: 0x0400166B RID: 5739
		private string messageId;
	}
}
