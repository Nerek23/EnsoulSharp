using System;
using System.Runtime.InteropServices;

namespace System.Globalization
{
	/// <summary>Specifies whether a calendar is solar-based, lunar-based, or lunisolar-based.</summary>
	// Token: 0x02000377 RID: 887
	[ComVisible(true)]
	public enum CalendarAlgorithmType
	{
		/// <summary>An unknown calendar basis.</summary>
		// Token: 0x0400123C RID: 4668
		Unknown,
		/// <summary>A solar-based calendar.</summary>
		// Token: 0x0400123D RID: 4669
		SolarCalendar,
		/// <summary>A lunar-based calendar.</summary>
		// Token: 0x0400123E RID: 4670
		LunarCalendar,
		/// <summary>A lunisolar-based calendar.</summary>
		// Token: 0x0400123F RID: 4671
		LunisolarCalendar
	}
}
