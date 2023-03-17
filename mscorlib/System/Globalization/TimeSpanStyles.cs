using System;

namespace System.Globalization
{
	/// <summary>Defines the formatting options that customize string parsing for the <see cref="Overload:System.TimeSpan.ParseExact" /> and <see cref="Overload:System.TimeSpan.TryParseExact" /> methods.</summary>
	// Token: 0x020003AA RID: 938
	[Flags]
	[__DynamicallyInvokable]
	public enum TimeSpanStyles
	{
		/// <summary>Indicates that input is interpreted as a negative time interval only if a negative sign is present.</summary>
		// Token: 0x04001488 RID: 5256
		[__DynamicallyInvokable]
		None = 0,
		/// <summary>Indicates that input is always interpreted as a negative time interval.</summary>
		// Token: 0x04001489 RID: 5257
		[__DynamicallyInvokable]
		AssumeNegative = 1
	}
}
