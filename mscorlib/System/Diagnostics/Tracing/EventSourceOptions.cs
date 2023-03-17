using System;

namespace System.Diagnostics.Tracing
{
	/// <summary>Specifies overrides of default event settings such as the log level, keywords and operation code when the <see cref="M:System.Diagnostics.Tracing.EventSource.Write``1(System.String,System.Diagnostics.Tracing.EventSourceOptions,``0)" /> method is called.</summary>
	// Token: 0x0200041B RID: 1051
	[__DynamicallyInvokable]
	public struct EventSourceOptions
	{
		/// <summary>Gets or sets the event level applied to the event.</summary>
		/// <returns>The event level for the event. If not set, the default is Verbose (5).</returns>
		// Token: 0x170007EF RID: 2031
		// (get) Token: 0x06003514 RID: 13588 RVA: 0x000CDF56 File Offset: 0x000CC156
		// (set) Token: 0x06003515 RID: 13589 RVA: 0x000CDF5E File Offset: 0x000CC15E
		[__DynamicallyInvokable]
		public EventLevel Level
		{
			[__DynamicallyInvokable]
			get
			{
				return (EventLevel)this.level;
			}
			[__DynamicallyInvokable]
			set
			{
				this.level = checked((byte)value);
				this.valuesSet |= 4;
			}
		}

		/// <summary>Gets or sets the operation code to use for the specified event.</summary>
		/// <returns>The operation code to use for the specified event. If not set, the default is <see langword="Info" /> (0).</returns>
		// Token: 0x170007F0 RID: 2032
		// (get) Token: 0x06003516 RID: 13590 RVA: 0x000CDF77 File Offset: 0x000CC177
		// (set) Token: 0x06003517 RID: 13591 RVA: 0x000CDF7F File Offset: 0x000CC17F
		[__DynamicallyInvokable]
		public EventOpcode Opcode
		{
			[__DynamicallyInvokable]
			get
			{
				return (EventOpcode)this.opcode;
			}
			[__DynamicallyInvokable]
			set
			{
				this.opcode = checked((byte)value);
				this.valuesSet |= 8;
			}
		}

		// Token: 0x170007F1 RID: 2033
		// (get) Token: 0x06003518 RID: 13592 RVA: 0x000CDF98 File Offset: 0x000CC198
		internal bool IsOpcodeSet
		{
			get
			{
				return (this.valuesSet & 8) > 0;
			}
		}

		/// <summary>Gets or sets the keywords applied to the event. If this property is not set, the event's keywords will be <see langword="None" />.</summary>
		/// <returns>The keywords applied to the event, or <see langword="None" /> if no keywords are set.</returns>
		// Token: 0x170007F2 RID: 2034
		// (get) Token: 0x06003519 RID: 13593 RVA: 0x000CDFA5 File Offset: 0x000CC1A5
		// (set) Token: 0x0600351A RID: 13594 RVA: 0x000CDFAD File Offset: 0x000CC1AD
		[__DynamicallyInvokable]
		public EventKeywords Keywords
		{
			[__DynamicallyInvokable]
			get
			{
				return this.keywords;
			}
			[__DynamicallyInvokable]
			set
			{
				this.keywords = value;
				this.valuesSet |= 1;
			}
		}

		/// <summary>The event tags defined for this event source.</summary>
		/// <returns>Returns <see cref="T:System.Diagnostics.Tracing.EventTags" />.</returns>
		// Token: 0x170007F3 RID: 2035
		// (get) Token: 0x0600351B RID: 13595 RVA: 0x000CDFC5 File Offset: 0x000CC1C5
		// (set) Token: 0x0600351C RID: 13596 RVA: 0x000CDFCD File Offset: 0x000CC1CD
		[__DynamicallyInvokable]
		public EventTags Tags
		{
			[__DynamicallyInvokable]
			get
			{
				return this.tags;
			}
			[__DynamicallyInvokable]
			set
			{
				this.tags = value;
				this.valuesSet |= 2;
			}
		}

		/// <summary>The activity options defined for this event source.</summary>
		/// <returns>Returns <see cref="T:System.Diagnostics.Tracing.EventActivityOptions" />.</returns>
		// Token: 0x170007F4 RID: 2036
		// (get) Token: 0x0600351D RID: 13597 RVA: 0x000CDFE5 File Offset: 0x000CC1E5
		// (set) Token: 0x0600351E RID: 13598 RVA: 0x000CDFED File Offset: 0x000CC1ED
		[__DynamicallyInvokable]
		public EventActivityOptions ActivityOptions
		{
			[__DynamicallyInvokable]
			get
			{
				return this.activityOptions;
			}
			[__DynamicallyInvokable]
			set
			{
				this.activityOptions = value;
				this.valuesSet |= 16;
			}
		}

		// Token: 0x0400177C RID: 6012
		internal EventKeywords keywords;

		// Token: 0x0400177D RID: 6013
		internal EventTags tags;

		// Token: 0x0400177E RID: 6014
		internal EventActivityOptions activityOptions;

		// Token: 0x0400177F RID: 6015
		internal byte level;

		// Token: 0x04001780 RID: 6016
		internal byte opcode;

		// Token: 0x04001781 RID: 6017
		internal byte valuesSet;

		// Token: 0x04001782 RID: 6018
		internal const byte keywordsSet = 1;

		// Token: 0x04001783 RID: 6019
		internal const byte tagsSet = 2;

		// Token: 0x04001784 RID: 6020
		internal const byte levelSet = 4;

		// Token: 0x04001785 RID: 6021
		internal const byte opcodeSet = 8;

		// Token: 0x04001786 RID: 6022
		internal const byte activityOptionsSet = 16;
	}
}
