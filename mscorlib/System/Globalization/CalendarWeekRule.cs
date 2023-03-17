using System;
using System.Runtime.InteropServices;

namespace System.Globalization
{
	/// <summary>Defines different rules for determining the first week of the year.</summary>
	// Token: 0x02000378 RID: 888
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum CalendarWeekRule
	{
		/// <summary>Indicates that the first week of the year starts on the first day of the year and ends before the following designated first day of the week. The value is 0.</summary>
		// Token: 0x04001241 RID: 4673
		[__DynamicallyInvokable]
		FirstDay,
		/// <summary>Indicates that the first week of the year begins on the first occurrence of the designated first day of the week on or after the first day of the year. The value is 1.</summary>
		// Token: 0x04001242 RID: 4674
		[__DynamicallyInvokable]
		FirstFullWeek,
		/// <summary>Indicates that the first week of the year is the first week with four or more days before the designated first day of the week. The value is 2.</summary>
		// Token: 0x04001243 RID: 4675
		[__DynamicallyInvokable]
		FirstFourDayWeek
	}
}
