using System;
using System.Runtime.InteropServices;

namespace System.Globalization
{
	/// <summary>the Taiwan calendar.</summary>
	// Token: 0x020003A5 RID: 933
	[ComVisible(true)]
	[Serializable]
	public class TaiwanCalendar : Calendar
	{
		// Token: 0x06003059 RID: 12377 RVA: 0x000B951B File Offset: 0x000B771B
		internal static Calendar GetDefaultInstance()
		{
			if (TaiwanCalendar.s_defaultInstance == null)
			{
				TaiwanCalendar.s_defaultInstance = new TaiwanCalendar();
			}
			return TaiwanCalendar.s_defaultInstance;
		}

		/// <summary>Gets the earliest date and time supported by the <see cref="T:System.Globalization.TaiwanCalendar" /> class.</summary>
		/// <returns>The earliest date and time supported by the <see cref="T:System.Globalization.TaiwanCalendar" /> class, which is equivalent to the first moment of January 1, 1912 C.E. in the Gregorian calendar.</returns>
		// Token: 0x170006D5 RID: 1749
		// (get) Token: 0x0600305A RID: 12378 RVA: 0x000B9539 File Offset: 0x000B7739
		[ComVisible(false)]
		public override DateTime MinSupportedDateTime
		{
			get
			{
				return TaiwanCalendar.calendarMinValue;
			}
		}

		/// <summary>Gets the latest date and time supported by the <see cref="T:System.Globalization.TaiwanCalendar" /> class.</summary>
		/// <returns>The latest date and time supported by the <see cref="T:System.Globalization.TaiwanCalendar" /> class, which is equivalent to the last moment of December 31, 9999 C.E. in the Gregorian calendar.</returns>
		// Token: 0x170006D6 RID: 1750
		// (get) Token: 0x0600305B RID: 12379 RVA: 0x000B9540 File Offset: 0x000B7740
		[ComVisible(false)]
		public override DateTime MaxSupportedDateTime
		{
			get
			{
				return DateTime.MaxValue;
			}
		}

		/// <summary>Gets a value that indicates whether the current calendar is solar-based, lunar-based, or a combination of both.</summary>
		/// <returns>Always returns <see cref="F:System.Globalization.CalendarAlgorithmType.SolarCalendar" />.</returns>
		// Token: 0x170006D7 RID: 1751
		// (get) Token: 0x0600305C RID: 12380 RVA: 0x000B9547 File Offset: 0x000B7747
		[ComVisible(false)]
		public override CalendarAlgorithmType AlgorithmType
		{
			get
			{
				return CalendarAlgorithmType.SolarCalendar;
			}
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Globalization.TaiwanCalendar" /> class.</summary>
		/// <exception cref="T:System.TypeInitializationException">Unable to initialize a <see cref="T:System.Globalization.TaiwanCalendar" /> object because of missing culture information.</exception>
		// Token: 0x0600305D RID: 12381 RVA: 0x000B954C File Offset: 0x000B774C
		public TaiwanCalendar()
		{
			try
			{
				new CultureInfo("zh-TW");
			}
			catch (ArgumentException innerException)
			{
				throw new TypeInitializationException(base.GetType().FullName, innerException);
			}
			this.helper = new GregorianCalendarHelper(this, TaiwanCalendar.taiwanEraInfo);
		}

		// Token: 0x170006D8 RID: 1752
		// (get) Token: 0x0600305E RID: 12382 RVA: 0x000B95A0 File Offset: 0x000B77A0
		internal override int ID
		{
			get
			{
				return 4;
			}
		}

		/// <summary>Returns a <see cref="T:System.DateTime" /> that is the specified number of months away from the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to which to add months.</param>
		/// <param name="months">The number of months to add.</param>
		/// <returns>The <see cref="T:System.DateTime" /> that results from adding the specified number of months to the specified <see cref="T:System.DateTime" />.</returns>
		/// <exception cref="T:System.ArgumentException">The resulting <see cref="T:System.DateTime" /> is outside the supported range.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="months" /> is less than -120000.  
		/// -or-  
		/// <paramref name="months" /> is greater than 120000.</exception>
		// Token: 0x0600305F RID: 12383 RVA: 0x000B95A3 File Offset: 0x000B77A3
		public override DateTime AddMonths(DateTime time, int months)
		{
			return this.helper.AddMonths(time, months);
		}

		/// <summary>Returns a <see cref="T:System.DateTime" /> that is the specified number of years away from the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to which to add years.</param>
		/// <param name="years">The number of years to add.</param>
		/// <returns>The <see cref="T:System.DateTime" /> that results from adding the specified number of years to the specified <see cref="T:System.DateTime" />.</returns>
		/// <exception cref="T:System.ArgumentException">The resulting <see cref="T:System.DateTime" /> is outside the supported range.</exception>
		// Token: 0x06003060 RID: 12384 RVA: 0x000B95B2 File Offset: 0x000B77B2
		public override DateTime AddYears(DateTime time, int years)
		{
			return this.helper.AddYears(time, years);
		}

		/// <summary>Returns the number of days in the specified month in the specified year in the specified era.</summary>
		/// <param name="year">An integer that represents the year.</param>
		/// <param name="month">An integer from 1 to 12 that represents the month.</param>
		/// <param name="era">An integer that represents the era.</param>
		/// <returns>The number of days in the specified month in the specified year in the specified era.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="year" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="month" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="era" /> is outside the range supported by the calendar.</exception>
		// Token: 0x06003061 RID: 12385 RVA: 0x000B95C1 File Offset: 0x000B77C1
		public override int GetDaysInMonth(int year, int month, int era)
		{
			return this.helper.GetDaysInMonth(year, month, era);
		}

		/// <summary>Returns the number of days in the specified year in the specified era.</summary>
		/// <param name="year">An integer that represents the year.</param>
		/// <param name="era">An integer that represents the era.</param>
		/// <returns>The number of days in the specified year in the specified era.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="year" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="era" /> is outside the range supported by the calendar.</exception>
		// Token: 0x06003062 RID: 12386 RVA: 0x000B95D1 File Offset: 0x000B77D1
		public override int GetDaysInYear(int year, int era)
		{
			return this.helper.GetDaysInYear(year, era);
		}

		/// <summary>Returns the day of the month in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <returns>An integer from 1 to 31 that represents the day of the month in the specified <see cref="T:System.DateTime" />.</returns>
		// Token: 0x06003063 RID: 12387 RVA: 0x000B95E0 File Offset: 0x000B77E0
		public override int GetDayOfMonth(DateTime time)
		{
			return this.helper.GetDayOfMonth(time);
		}

		/// <summary>Returns the day of the week in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <returns>A <see cref="T:System.DayOfWeek" /> value that represents the day of the week in the specified <see cref="T:System.DateTime" />.</returns>
		// Token: 0x06003064 RID: 12388 RVA: 0x000B95EE File Offset: 0x000B77EE
		public override DayOfWeek GetDayOfWeek(DateTime time)
		{
			return this.helper.GetDayOfWeek(time);
		}

		/// <summary>Returns the day of the year in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <returns>An integer from 1 to 366 that represents the day of the year in the specified <see cref="T:System.DateTime" />.</returns>
		// Token: 0x06003065 RID: 12389 RVA: 0x000B95FC File Offset: 0x000B77FC
		public override int GetDayOfYear(DateTime time)
		{
			return this.helper.GetDayOfYear(time);
		}

		/// <summary>Returns the number of months in the specified year in the specified era.</summary>
		/// <param name="year">An integer that represents the year.</param>
		/// <param name="era">An integer that represents the era.</param>
		/// <returns>The number of months in the specified year in the specified era.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="year" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="era" /> is outside the range supported by the calendar.</exception>
		// Token: 0x06003066 RID: 12390 RVA: 0x000B960A File Offset: 0x000B780A
		public override int GetMonthsInYear(int year, int era)
		{
			return this.helper.GetMonthsInYear(year, era);
		}

		/// <summary>Returns the week of the year that includes the date in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <param name="rule">One of the <see cref="T:System.Globalization.CalendarWeekRule" /> values that defines a calendar week.</param>
		/// <param name="firstDayOfWeek">One of the <see cref="T:System.DayOfWeek" /> values that represents the first day of the week.</param>
		/// <returns>A positive integer that represents the week of the year that includes the date in the <paramref name="time" /> parameter.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="time" /> or <paramref name="firstDayOfWeek" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="rule" /> is not a valid <see cref="T:System.Globalization.CalendarWeekRule" /> value.</exception>
		// Token: 0x06003067 RID: 12391 RVA: 0x000B9619 File Offset: 0x000B7819
		[ComVisible(false)]
		public override int GetWeekOfYear(DateTime time, CalendarWeekRule rule, DayOfWeek firstDayOfWeek)
		{
			return this.helper.GetWeekOfYear(time, rule, firstDayOfWeek);
		}

		/// <summary>Returns the era in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <returns>An integer that represents the era in the specified <see cref="T:System.DateTime" />.</returns>
		// Token: 0x06003068 RID: 12392 RVA: 0x000B9629 File Offset: 0x000B7829
		public override int GetEra(DateTime time)
		{
			return this.helper.GetEra(time);
		}

		/// <summary>Returns the month in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <returns>An integer from 1 to 12 that represents the month in the specified <see cref="T:System.DateTime" />.</returns>
		// Token: 0x06003069 RID: 12393 RVA: 0x000B9637 File Offset: 0x000B7837
		public override int GetMonth(DateTime time)
		{
			return this.helper.GetMonth(time);
		}

		/// <summary>Returns the year in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <returns>An integer that represents the year in the specified <see cref="T:System.DateTime" />.</returns>
		// Token: 0x0600306A RID: 12394 RVA: 0x000B9645 File Offset: 0x000B7845
		public override int GetYear(DateTime time)
		{
			return this.helper.GetYear(time);
		}

		/// <summary>Determines whether the specified date in the specified era is a leap day.</summary>
		/// <param name="year">An integer that represents the year.</param>
		/// <param name="month">An integer from 1 to 12 that represents the month.</param>
		/// <param name="day">An integer from 1 to 31 that represents the day.</param>
		/// <param name="era">An integer that represents the era.</param>
		/// <returns>
		///   <see langword="true" /> if the specified day is a leap day; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="year" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="month" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="day" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="era" /> is outside the range supported by the calendar.</exception>
		// Token: 0x0600306B RID: 12395 RVA: 0x000B9653 File Offset: 0x000B7853
		public override bool IsLeapDay(int year, int month, int day, int era)
		{
			return this.helper.IsLeapDay(year, month, day, era);
		}

		/// <summary>Determines whether the specified year in the specified era is a leap year.</summary>
		/// <param name="year">An integer that represents the year.</param>
		/// <param name="era">An integer that represents the era.</param>
		/// <returns>
		///   <see langword="true" /> if the specified year is a leap year; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="year" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="era" /> is outside the range supported by the calendar.</exception>
		// Token: 0x0600306C RID: 12396 RVA: 0x000B9665 File Offset: 0x000B7865
		public override bool IsLeapYear(int year, int era)
		{
			return this.helper.IsLeapYear(year, era);
		}

		/// <summary>Calculates the leap month for a specified year and era.</summary>
		/// <param name="year">A year.</param>
		/// <param name="era">An era.</param>
		/// <returns>The return value is always 0 because the <see cref="T:System.Globalization.TaiwanCalendar" /> class does not support the notion of a leap month.</returns>
		// Token: 0x0600306D RID: 12397 RVA: 0x000B9674 File Offset: 0x000B7874
		[ComVisible(false)]
		public override int GetLeapMonth(int year, int era)
		{
			return this.helper.GetLeapMonth(year, era);
		}

		/// <summary>Determines whether the specified month in the specified year in the specified era is a leap month.</summary>
		/// <param name="year">An integer that represents the year.</param>
		/// <param name="month">An integer from 1 to 12 that represents the month.</param>
		/// <param name="era">An integer that represents the era.</param>
		/// <returns>This method always returns <see langword="false" />, unless overridden by a derived class.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="year" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="month" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="era" /> is outside the range supported by the calendar.</exception>
		// Token: 0x0600306E RID: 12398 RVA: 0x000B9683 File Offset: 0x000B7883
		public override bool IsLeapMonth(int year, int month, int era)
		{
			return this.helper.IsLeapMonth(year, month, era);
		}

		/// <summary>Returns a <see cref="T:System.DateTime" /> that is set to the specified date and time in the specified era.</summary>
		/// <param name="year">An integer that represents the year.</param>
		/// <param name="month">An integer from 1 to 12 that represents the month.</param>
		/// <param name="day">An integer from 1 to 31 that represents the day.</param>
		/// <param name="hour">An integer from 0 to 23 that represents the hour.</param>
		/// <param name="minute">An integer from 0 to 59 that represents the minute.</param>
		/// <param name="second">An integer from 0 to 59 that represents the second.</param>
		/// <param name="millisecond">An integer from 0 to 999 that represents the millisecond.</param>
		/// <param name="era">An integer that represents the era.</param>
		/// <returns>The <see cref="T:System.DateTime" /> that is set to the specified date and time in the current era.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="year" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="month" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="day" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="hour" /> is less than zero or greater than 23.  
		/// -or-  
		/// <paramref name="minute" /> is less than zero or greater than 59.  
		/// -or-  
		/// <paramref name="second" /> is less than zero or greater than 59.  
		/// -or-  
		/// <paramref name="millisecond" /> is less than zero or greater than 999.  
		/// -or-  
		/// <paramref name="era" /> is outside the range supported by the calendar.</exception>
		// Token: 0x0600306F RID: 12399 RVA: 0x000B9694 File Offset: 0x000B7894
		public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era)
		{
			return this.helper.ToDateTime(year, month, day, hour, minute, second, millisecond, era);
		}

		/// <summary>Gets the list of eras in the <see cref="T:System.Globalization.TaiwanCalendar" />.</summary>
		/// <returns>An array that consists of a single element for which the value is always the current era.</returns>
		// Token: 0x170006D9 RID: 1753
		// (get) Token: 0x06003070 RID: 12400 RVA: 0x000B96B9 File Offset: 0x000B78B9
		public override int[] Eras
		{
			get
			{
				return this.helper.Eras;
			}
		}

		/// <summary>Gets or sets the last year of a 100-year range that can be represented by a 2-digit year.</summary>
		/// <returns>The last year of a 100-year range that can be represented by a 2-digit year.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value specified in a set operation is less than 99.  
		///  -or-  
		///  The value specified in a set operation is greater than <see langword="MaxSupportedDateTime.Year" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">In a set operation, the current instance is read-only.</exception>
		// Token: 0x170006DA RID: 1754
		// (get) Token: 0x06003071 RID: 12401 RVA: 0x000B96C6 File Offset: 0x000B78C6
		// (set) Token: 0x06003072 RID: 12402 RVA: 0x000B96EC File Offset: 0x000B78EC
		public override int TwoDigitYearMax
		{
			get
			{
				if (this.twoDigitYearMax == -1)
				{
					this.twoDigitYearMax = Calendar.GetSystemTwoDigitYearSetting(this.ID, 99);
				}
				return this.twoDigitYearMax;
			}
			set
			{
				base.VerifyWritable();
				if (value < 99 || value > this.helper.MaxYear)
				{
					throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 99, this.helper.MaxYear));
				}
				this.twoDigitYearMax = value;
			}
		}

		/// <summary>Converts the specified year to a four-digit year by using the <see cref="P:System.Globalization.TaiwanCalendar.TwoDigitYearMax" /> property to determine the appropriate century.</summary>
		/// <param name="year">A two-digit or four-digit integer that represents the year to convert.</param>
		/// <returns>An integer that contains the four-digit representation of <paramref name="year" />.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="year" /> is outside the range supported by the calendar.</exception>
		// Token: 0x06003073 RID: 12403 RVA: 0x000B9750 File Offset: 0x000B7950
		public override int ToFourDigitYear(int year)
		{
			if (year <= 0)
			{
				throw new ArgumentOutOfRangeException("year", Environment.GetResourceString("ArgumentOutOfRange_NeedPosNum"));
			}
			if (year > this.helper.MaxYear)
			{
				throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 1, this.helper.MaxYear));
			}
			return year;
		}

		// Token: 0x04001465 RID: 5221
		internal static EraInfo[] taiwanEraInfo = new EraInfo[]
		{
			new EraInfo(1, 1912, 1, 1, 1911, 1, 8088)
		};

		// Token: 0x04001466 RID: 5222
		internal static volatile Calendar s_defaultInstance;

		// Token: 0x04001467 RID: 5223
		internal GregorianCalendarHelper helper;

		// Token: 0x04001468 RID: 5224
		internal static readonly DateTime calendarMinValue = new DateTime(1912, 1, 1);

		// Token: 0x04001469 RID: 5225
		private const int DEFAULT_TWO_DIGIT_YEAR_MAX = 99;
	}
}
