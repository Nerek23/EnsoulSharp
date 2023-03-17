using System;
using System.Runtime.InteropServices;

namespace System.Text
{
	/// <summary>Defines the type of normalization to perform.</summary>
	// Token: 0x02000A4D RID: 2637
	[ComVisible(true)]
	public enum NormalizationForm
	{
		/// <summary>Indicates that a Unicode string is normalized using full canonical decomposition, followed by the replacement of sequences with their primary composites, if possible.</summary>
		// Token: 0x04002E22 RID: 11810
		FormC = 1,
		/// <summary>Indicates that a Unicode string is normalized using full canonical decomposition.</summary>
		// Token: 0x04002E23 RID: 11811
		FormD,
		/// <summary>Indicates that a Unicode string is normalized using full compatibility decomposition, followed by the replacement of sequences with their primary composites, if possible.</summary>
		// Token: 0x04002E24 RID: 11812
		FormKC = 5,
		/// <summary>Indicates that a Unicode string is normalized using full compatibility decomposition.</summary>
		// Token: 0x04002E25 RID: 11813
		FormKD
	}
}
