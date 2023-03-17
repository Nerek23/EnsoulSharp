using System;
using System.Runtime.InteropServices;

namespace System.Globalization
{
	/// <summary>Represents the Thai Buddhist calendar.</summary>
	// Token: 0x020003A8 RID: 936
	[ComVisible(true)]
	[Serializable]
	public class ThaiBuddhistCalendar : Calendar
	{
		/// <summary>Gets the earliest date and time supported by the <see cref="T:System.Globalization.ThaiBuddhistCalendar" /> class.</summary>
		/// <returns>The earliest date and time supported by the <see cref="T:System.Globalization.ThaiBuddhistCalendar" /> class, which is equivalent to the first moment of January 1, 0001 C.E. in the Gregorian calendar.</returns>
		// Token: 0x170006E8 RID: 1768
		// (get) Token: 0x060030B1 RID: 12465 RVA: 0x000BA1D5 File Offset: 0x000B83D5
		[ComVisible(false)]
		public override DateTime MinSupportedDateTime
		{
			get
			{
				return DateTime.MinValue;
			}
		}

		/// <summary>Gets the latest date and time supported by the <see cref="T:System.Globalization.ThaiBuddhistCalendar" /> class.</summary>
		/// <returns>The latest date and time supported by the <see cref="T:System.Globalization.ThaiBuddhistCalendar" /> class, which is equivalent to the last moment of December 31, 9999 C.E. in the Gregorian calendar.</returns>
		// Token: 0x170006E9 RID: 1769
		// (get) Token: 0x060030B2 RID: 12466 RVA: 0x000BA1DC File Offset: 0x000B83DC
		[ComVisible(false)]
		public override DateTime MaxSupportedDateTime
		{
			get
			{
				return DateTime.MaxValue;
			}
		}

		/// <summary>Gets a value indicating whether the current calendar is solar-based, lunar-based, or a combination of both.</summary>
		/// <returns>Always returns <see cref="F:System.Globalization.CalendarAlgorithmType.SolarCalendar" />.</returns>
		// Token: 0x170006EA RID: 1770
		// (get) Token: 0x060030B3 RID: 12467 RVA: 0x000BA1E3 File Offset: 0x000B83E3
		[ComVisible(false)]
		public override CalendarAlgorithmType AlgorithmType
		{
			get
			{
				return CalendarAlgorithmType.SolarCalendar;
			}
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Globalization.ThaiBuddhistCalendar" /> class.</summary>
		// Token: 0x060030B4 RID: 12468 RVA: 0x000BA1E6 File Offset: 0x000B83E6
		public ThaiBuddhistCalendar()
		{
			this.helper = new GregorianCalendarHelper(this, ThaiBuddhistCalendar.thaiBuddhistEraInfo);
		}

		// Token: 0x170006EB RID: 1771
		// (get) Token: 0x060030B5 RID: 12469 RVA: 0x000BA1FF File Offset: 0x000B83FF
		internal override int ID
		{
			get
			{
				return 7;
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
		// Token: 0x060030B6 RID: 12470 RVA: 0x000BA202 File Offset: 0x000B8402
		public override DateTime AddMonths(DateTime time, int months)
		{
			return this.helper.AddMonths(time, months);
		}

		/// <summary>Returns a <see cref="T:System.DateTime" /> that is the specified number of years away from the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to which to add years.</param>
		/// <param name="years">The number of years to add.</param>
		/// <returns>The <see cref="T:System.DateTime" /> that results from adding the specified number of years to the specified <see cref="T:System.DateTime" />.</returns>
		/// <exception cref="T:System.ArgumentException">The resulting <see cref="T:System.DateTime" /> is outside the supported range.</exception>
		// Token: 0x060030B7 RID: 12471 RVA: 0x000BA211 File Offset: 0x000B8411
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
		// Token: 0x060030B8 RID: 12472 RVA: 0x000BA220 File Offset: 0x000B8420
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
		// Token: 0x060030B9 RID: 12473 RVA: 0x000BA230 File Offset: 0x000B8430
		public override int GetDaysInYear(int year, int era)
		{
			return this.helper.GetDaysInYear(year, era);
		}

		/// <summary>Returns the day of the month in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <returns>An integer from 1 to 31 that represents the day of the month in the specified <see cref="T:System.DateTime" />.</returns>
		// Token: 0x060030BA RID: 12474 RVA: 0x000BA23F File Offset: 0x000B843F
		public override int GetDayOfMonth(DateTime time)
		{
			return this.helper.GetDayOfMonth(time);
		}

		/// <summary>Returns the day of the week in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <returns>A <see cref="T:System.DayOfWeek" /> value that represents the day of the week in the specified <see cref="T:System.DateTime" />.</returns>
		// Token: 0x060030BB RID: 12475 RVA: 0x000BA24D File Offset: 0x000B844D
		public override DayOfWeek GetDayOfWeek(DateTime time)
		{
			return this.helper.GetDayOfWeek(time);
		}

		/// <summary>Returns the day of the year in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <returns>An integer from 1 to 366 that represents the day of the year in the specified <see cref="T:System.DateTime" />.</returns>
		// Token: 0x060030BC RID: 12476 RVA: 0x000BA25B File Offset: 0x000B845B
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
		// Token: 0x060030BD RID: 12477 RVA: 0x000BA269 File Offset: 0x000B8469
		public override int GetMonthsInYear(int year, int era)
		{
			return this.helper.GetMonthsInYear(year, era);
		}

		/// <summary>Returns the week of the year that includes the date in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <param name="rule">One of the <see cref="T:System.Globalization.CalendarWeekRule" /> values that defines a calendar week.</param>
		/// <param name="firstDayOfWeek">One of the <see cref="T:System.DayOfWeek" /> values that represents the first day of the week.</param>
		/// <returns>A 1-based positive integer that represents the week of the year that includes the date in the <paramref name="time" /> parameter.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="time" /> or <paramref name="firstDayOfWeek" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="rule" /> is not a valid <see cref="T:System.Globalization.CalendarWeekRule" /> value.</exception>
		// Token: 0x060030BE RID: 12478 RVA: 0x000BA278 File Offset: 0x000B8478
		[ComVisible(false)]
		public override int GetWeekOfYear(DateTime time, CalendarWeekRule rule, DayOfWeek firstDayOfWeek)
		{
			return this.helper.GetWeekOfYear(time, rule, firstDayOfWeek);
		}

		/// <summary>Returns the era in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <returns>An integer that represents the era in the specified <see cref="T:System.DateTime" />.</returns>
		// Token: 0x060030BF RID: 12479 RVA: 0x000BA288 File Offset: 0x000B8488
		public override int GetEra(DateTime time)
		{
			return this.helper.GetEra(time);
		}

		/// <summary>Returns the month in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <returns>An integer from 1 to 12 that represents the month in the specified <see cref="T:System.DateTime" />.</returns>
		// Token: 0x060030C0 RID: 12480 RVA: 0x000BA296 File Offset: 0x000B8496
		public override int GetMonth(DateTime time)
		{
			return this.helper.GetMonth(time);
		}

		/// <summary>Returns the year in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <returns>An integer that represents the year in the specified <see cref="T:System.DateTime" />.</returns>
		// Token: 0x060030C1 RID: 12481 RVA: 0x000BA2A4 File Offset: 0x000B84A4
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
		// Token: 0x060030C2 RID: 12482 RVA: 0x000BA2B2 File Offset: 0x000B84B2
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
		// Token: 0x060030C3 RID: 12483 RVA: 0x000BA2C4 File Offset: 0x000B84C4
		public override bool IsLeapYear(int year, int era)
		{
			return this.helper.IsLeapYear(year, era);
		}

		/// <summary>Calculates the leap month for a specified year and era.</summary>
		/// <param name="year">A year.</param>
		/// <param name="era">An era.</param>
		/// <returns>The return value is always 0 because the <see cref="T:System.Globalization.ThaiBuddhistCalendar" /> class does not support the notion of a leap month.</returns>
		// Token: 0x060030C4 RID: 12484 RVA: 0x000BA2D3 File Offset: 0x000B84D3
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
		// Token: 0x060030C5 RID: 12485 RVA: 0x000BA2E2 File Offset: 0x000B84E2
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
		// Token: 0x060030C6 RID: 12486 RVA: 0x000BA2F4 File Offset: 0x000B84F4
		public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era)
		{
			return this.helper.ToDateTime(year, month, day, hour, minute, second, millisecond, era);
		}

		/// <summary>Gets the list of eras in the <see cref="T:System.Globalization.ThaiBuddhistCalendar" /> class.</summary>
		/// <returns>An array that consists of a single element having a value that is always the current era.</returns>
		// Token: 0x170006EC RID: 1772
		// (get) Token: 0x060030C7 RID: 12487 RVA: 0x000BA319 File Offset: 0x000B8519
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
		// Token: 0x170006ED RID: 1773
		// (get) Token: 0x060030C8 RID: 12488 RVA: 0x000BA326 File Offset: 0x000B8526
		// (set) Token: 0x060030C9 RID: 12489 RVA: 0x000BA350 File Offset: 0x000B8550
		public override int TwoDigitYearMax
		{
			get
			{
				if (this.twoDigitYearMax == -1)
				{
					this.twoDigitYearMax = Calendar.GetSystemTwoDigitYearSetting(this.ID, 2572);
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

		/// <summary>Converts the specified year to a four-digit year by using the <see cref="P:System.Globalization.ThaiBuddhistCalendar.TwoDigitYearMax" /> property to determine the appropriate century.</summary>
		/// <param name="year">A two-digit or four-digit integer that represents the year to convert.</param>
		/// <returns>An integer that contains the four-digit representation of <paramref name="year" />.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="year" /> is outside the range supported by the calendar.</exception>
		// Token: 0x060030CA RID: 12490 RVA: 0x000BA3B3 File Offset: 0x000B85B3
		public override int ToFourDigitYear(int year)
		{
			if (year < 0)
			{
				throw new ArgumentOutOfRangeException("year", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			return this.helper.ToFourDigitYear(year, this.TwoDigitYearMax);
		}

		// Token: 0x04001481 RID: 5249
		internal static EraInfo[] thaiBuddhistEraInfo = new EraInfo[]
		{
			new EraInfo(1, 1, 1, 1, -543, 544, 10542)
		};

		/// <summary>Represents the current era. This field is constant.</summary>
		// Token: 0x04001482 RID: 5250
		public const int ThaiBuddhistEra = 1;

		// Token: 0x04001483 RID: 5251
		internal GregorianCalendarHelper helper;

		// Token: 0x04001484 RID: 5252
		private const int DEFAULT_TWO_DIGIT_YEAR_MAX = 2572;
	}
}
