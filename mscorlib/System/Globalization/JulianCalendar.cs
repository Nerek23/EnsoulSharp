using System;
using System.Runtime.InteropServices;

namespace System.Globalization
{
	/// <summary>Represents the Julian calendar.</summary>
	// Token: 0x0200039A RID: 922
	[ComVisible(true)]
	[Serializable]
	public class JulianCalendar : Calendar
	{
		/// <summary>Gets the earliest date and time supported by the <see cref="T:System.Globalization.JulianCalendar" /> class.</summary>
		/// <returns>The earliest date and time supported by the <see cref="T:System.Globalization.JulianCalendar" /> class, which is equivalent to the first moment of January 1, 0001 C.E. in the Gregorian calendar.</returns>
		// Token: 0x17000691 RID: 1681
		// (get) Token: 0x06002F3E RID: 12094 RVA: 0x000B51C4 File Offset: 0x000B33C4
		[ComVisible(false)]
		public override DateTime MinSupportedDateTime
		{
			get
			{
				return DateTime.MinValue;
			}
		}

		/// <summary>Gets the latest date and time supported by the <see cref="T:System.Globalization.JulianCalendar" /> class.</summary>
		/// <returns>The latest date and time supported by the <see cref="T:System.Globalization.JulianCalendar" /> class, which is equivalent to the last moment of December 31, 9999 C.E. in the Gregorian calendar.</returns>
		// Token: 0x17000692 RID: 1682
		// (get) Token: 0x06002F3F RID: 12095 RVA: 0x000B51CB File Offset: 0x000B33CB
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
		// Token: 0x17000693 RID: 1683
		// (get) Token: 0x06002F40 RID: 12096 RVA: 0x000B51D2 File Offset: 0x000B33D2
		[ComVisible(false)]
		public override CalendarAlgorithmType AlgorithmType
		{
			get
			{
				return CalendarAlgorithmType.SolarCalendar;
			}
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Globalization.JulianCalendar" /> class.</summary>
		// Token: 0x06002F41 RID: 12097 RVA: 0x000B51D5 File Offset: 0x000B33D5
		public JulianCalendar()
		{
			this.twoDigitYearMax = 2029;
		}

		// Token: 0x17000694 RID: 1684
		// (get) Token: 0x06002F42 RID: 12098 RVA: 0x000B51F3 File Offset: 0x000B33F3
		internal override int ID
		{
			get
			{
				return 13;
			}
		}

		// Token: 0x06002F43 RID: 12099 RVA: 0x000B51F7 File Offset: 0x000B33F7
		internal static void CheckEraRange(int era)
		{
			if (era != 0 && era != JulianCalendar.JulianEra)
			{
				throw new ArgumentOutOfRangeException("era", Environment.GetResourceString("ArgumentOutOfRange_InvalidEraValue"));
			}
		}

		// Token: 0x06002F44 RID: 12100 RVA: 0x000B521C File Offset: 0x000B341C
		internal void CheckYearEraRange(int year, int era)
		{
			JulianCalendar.CheckEraRange(era);
			if (year <= 0 || year > this.MaxYear)
			{
				throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 1, this.MaxYear));
			}
		}

		// Token: 0x06002F45 RID: 12101 RVA: 0x000B526C File Offset: 0x000B346C
		internal static void CheckMonthRange(int month)
		{
			if (month < 1 || month > 12)
			{
				throw new ArgumentOutOfRangeException("month", Environment.GetResourceString("ArgumentOutOfRange_Month"));
			}
		}

		// Token: 0x06002F46 RID: 12102 RVA: 0x000B528C File Offset: 0x000B348C
		internal static void CheckDayRange(int year, int month, int day)
		{
			if (year == 1 && month == 1 && day < 3)
			{
				throw new ArgumentOutOfRangeException(null, Environment.GetResourceString("ArgumentOutOfRange_BadYearMonthDay"));
			}
			int[] array = (year % 4 == 0) ? JulianCalendar.DaysToMonth366 : JulianCalendar.DaysToMonth365;
			int num = array[month] - array[month - 1];
			if (day < 1 || day > num)
			{
				throw new ArgumentOutOfRangeException("day", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 1, num));
			}
		}

		// Token: 0x06002F47 RID: 12103 RVA: 0x000B530C File Offset: 0x000B350C
		internal static int GetDatePart(long ticks, int part)
		{
			long num = ticks + 1728000000000L;
			int i = (int)(num / 864000000000L);
			int num2 = i / 1461;
			i -= num2 * 1461;
			int num3 = i / 365;
			if (num3 == 4)
			{
				num3 = 3;
			}
			if (part == 0)
			{
				return num2 * 4 + num3 + 1;
			}
			i -= num3 * 365;
			if (part == 1)
			{
				return i + 1;
			}
			int[] array = (num3 == 3) ? JulianCalendar.DaysToMonth366 : JulianCalendar.DaysToMonth365;
			int num4 = i >> 6;
			while (i >= array[num4])
			{
				num4++;
			}
			if (part == 2)
			{
				return num4;
			}
			return i - array[num4 - 1] + 1;
		}

		// Token: 0x06002F48 RID: 12104 RVA: 0x000B53B0 File Offset: 0x000B35B0
		internal static long DateToTicks(int year, int month, int day)
		{
			int[] array = (year % 4 == 0) ? JulianCalendar.DaysToMonth366 : JulianCalendar.DaysToMonth365;
			int num = year - 1;
			int num2 = num * 365 + num / 4 + array[month - 1] + day - 1;
			return (long)(num2 - 2) * 864000000000L;
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
		// Token: 0x06002F49 RID: 12105 RVA: 0x000B53F8 File Offset: 0x000B35F8
		public override DateTime AddMonths(DateTime time, int months)
		{
			if (months < -120000 || months > 120000)
			{
				throw new ArgumentOutOfRangeException("months", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), -120000, 120000));
			}
			int num = JulianCalendar.GetDatePart(time.Ticks, 0);
			int num2 = JulianCalendar.GetDatePart(time.Ticks, 2);
			int num3 = JulianCalendar.GetDatePart(time.Ticks, 3);
			int num4 = num2 - 1 + months;
			if (num4 >= 0)
			{
				num2 = num4 % 12 + 1;
				num += num4 / 12;
			}
			else
			{
				num2 = 12 + (num4 + 1) % 12;
				num += (num4 - 11) / 12;
			}
			int[] array = (num % 4 == 0 && (num % 100 != 0 || num % 400 == 0)) ? JulianCalendar.DaysToMonth366 : JulianCalendar.DaysToMonth365;
			int num5 = array[num2] - array[num2 - 1];
			if (num3 > num5)
			{
				num3 = num5;
			}
			long ticks = JulianCalendar.DateToTicks(num, num2, num3) + time.Ticks % 864000000000L;
			Calendar.CheckAddResult(ticks, this.MinSupportedDateTime, this.MaxSupportedDateTime);
			return new DateTime(ticks);
		}

		/// <summary>Returns a <see cref="T:System.DateTime" /> that is the specified number of years away from the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to which to add years.</param>
		/// <param name="years">The number of years to add.</param>
		/// <returns>The <see cref="T:System.DateTime" /> that results from adding the specified number of years to the specified <see cref="T:System.DateTime" />.</returns>
		/// <exception cref="T:System.ArgumentException">The resulting <see cref="T:System.DateTime" /> is outside the supported range.</exception>
		// Token: 0x06002F4A RID: 12106 RVA: 0x000B550D File Offset: 0x000B370D
		public override DateTime AddYears(DateTime time, int years)
		{
			return this.AddMonths(time, years * 12);
		}

		/// <summary>Returns the day of the month in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <returns>An integer from 1 to 31 that represents the day of the month in <paramref name="time" />.</returns>
		// Token: 0x06002F4B RID: 12107 RVA: 0x000B551A File Offset: 0x000B371A
		public override int GetDayOfMonth(DateTime time)
		{
			return JulianCalendar.GetDatePart(time.Ticks, 3);
		}

		/// <summary>Returns the day of the week in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <returns>A <see cref="T:System.DayOfWeek" /> value that represents the day of the week in <paramref name="time" />.</returns>
		// Token: 0x06002F4C RID: 12108 RVA: 0x000B5529 File Offset: 0x000B3729
		public override DayOfWeek GetDayOfWeek(DateTime time)
		{
			return (DayOfWeek)(time.Ticks / 864000000000L + 1L) % (DayOfWeek)7;
		}

		/// <summary>Returns the day of the year in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <returns>An integer from 1 to 366 that represents the day of the year in <paramref name="time" />.</returns>
		// Token: 0x06002F4D RID: 12109 RVA: 0x000B5542 File Offset: 0x000B3742
		public override int GetDayOfYear(DateTime time)
		{
			return JulianCalendar.GetDatePart(time.Ticks, 1);
		}

		/// <summary>Returns the number of days in the specified month in the specified year in the specified era.</summary>
		/// <param name="year">An integer that represents the year.</param>
		/// <param name="month">An integer from 1 to 12 that represents the month.</param>
		/// <param name="era">An integer that represents the era.</param>
		/// <returns>The number of days in the specified month in the specified year in the specified era.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="era" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="year" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="month" /> is outside the range supported by the calendar.</exception>
		// Token: 0x06002F4E RID: 12110 RVA: 0x000B5554 File Offset: 0x000B3754
		public override int GetDaysInMonth(int year, int month, int era)
		{
			this.CheckYearEraRange(year, era);
			JulianCalendar.CheckMonthRange(month);
			int[] array = (year % 4 == 0) ? JulianCalendar.DaysToMonth366 : JulianCalendar.DaysToMonth365;
			return array[month] - array[month - 1];
		}

		/// <summary>Returns the number of days in the specified year in the specified era.</summary>
		/// <param name="year">An integer that represents the year.</param>
		/// <param name="era">An integer that represents the era.</param>
		/// <returns>The number of days in the specified year in the specified era.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="era" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="year" /> is outside the range supported by the calendar.</exception>
		// Token: 0x06002F4F RID: 12111 RVA: 0x000B558A File Offset: 0x000B378A
		public override int GetDaysInYear(int year, int era)
		{
			if (!this.IsLeapYear(year, era))
			{
				return 365;
			}
			return 366;
		}

		/// <summary>Returns the era in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <returns>An integer that represents the era in <paramref name="time" />.</returns>
		// Token: 0x06002F50 RID: 12112 RVA: 0x000B55A1 File Offset: 0x000B37A1
		public override int GetEra(DateTime time)
		{
			return JulianCalendar.JulianEra;
		}

		/// <summary>Returns the month in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <returns>An integer from 1 to 12 that represents the month in <paramref name="time" />.</returns>
		// Token: 0x06002F51 RID: 12113 RVA: 0x000B55A8 File Offset: 0x000B37A8
		public override int GetMonth(DateTime time)
		{
			return JulianCalendar.GetDatePart(time.Ticks, 2);
		}

		/// <summary>Gets the list of eras in the <see cref="T:System.Globalization.JulianCalendar" />.</summary>
		/// <returns>An array of integers that represents the eras in the <see cref="T:System.Globalization.JulianCalendar" />.</returns>
		// Token: 0x17000695 RID: 1685
		// (get) Token: 0x06002F52 RID: 12114 RVA: 0x000B55B7 File Offset: 0x000B37B7
		public override int[] Eras
		{
			get
			{
				return new int[]
				{
					JulianCalendar.JulianEra
				};
			}
		}

		/// <summary>Returns the number of months in the specified year in the specified era.</summary>
		/// <param name="year">An integer that represents the year.</param>
		/// <param name="era">An integer that represents the era.</param>
		/// <returns>The number of months in the specified year in the specified era.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="era" /> is outside the range supported by the calendar.  
		/// -or-  
		/// <paramref name="year" /> is outside the range supported by the calendar.</exception>
		// Token: 0x06002F53 RID: 12115 RVA: 0x000B55C7 File Offset: 0x000B37C7
		public override int GetMonthsInYear(int year, int era)
		{
			this.CheckYearEraRange(year, era);
			return 12;
		}

		/// <summary>Returns the year in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <returns>An integer that represents the year in <paramref name="time" />.</returns>
		// Token: 0x06002F54 RID: 12116 RVA: 0x000B55D3 File Offset: 0x000B37D3
		public override int GetYear(DateTime time)
		{
			return JulianCalendar.GetDatePart(time.Ticks, 0);
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
		// Token: 0x06002F55 RID: 12117 RVA: 0x000B55E2 File Offset: 0x000B37E2
		public override bool IsLeapDay(int year, int month, int day, int era)
		{
			JulianCalendar.CheckMonthRange(month);
			if (this.IsLeapYear(year, era))
			{
				JulianCalendar.CheckDayRange(year, month, day);
				return month == 2 && day == 29;
			}
			JulianCalendar.CheckDayRange(year, month, day);
			return false;
		}

		/// <summary>Calculates the leap month for a specified year and era.</summary>
		/// <param name="year">An integer that represents the year.</param>
		/// <param name="era">An integer that represents the era.</param>
		/// <returns>A positive integer that indicates the leap month in the specified year and era. Alternatively, this method returns zero if the calendar does not support a leap month, or if <paramref name="year" /> and <paramref name="era" /> do not specify a leap year.</returns>
		// Token: 0x06002F56 RID: 12118 RVA: 0x000B5612 File Offset: 0x000B3812
		[ComVisible(false)]
		public override int GetLeapMonth(int year, int era)
		{
			this.CheckYearEraRange(year, era);
			return 0;
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
		// Token: 0x06002F57 RID: 12119 RVA: 0x000B561D File Offset: 0x000B381D
		public override bool IsLeapMonth(int year, int month, int era)
		{
			this.CheckYearEraRange(year, era);
			JulianCalendar.CheckMonthRange(month);
			return false;
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
		// Token: 0x06002F58 RID: 12120 RVA: 0x000B562E File Offset: 0x000B382E
		public override bool IsLeapYear(int year, int era)
		{
			this.CheckYearEraRange(year, era);
			return year % 4 == 0;
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
		// Token: 0x06002F59 RID: 12121 RVA: 0x000B5640 File Offset: 0x000B3840
		public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era)
		{
			this.CheckYearEraRange(year, era);
			JulianCalendar.CheckMonthRange(month);
			JulianCalendar.CheckDayRange(year, month, day);
			if (millisecond < 0 || millisecond >= 1000)
			{
				throw new ArgumentOutOfRangeException("millisecond", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 0, 999));
			}
			if (hour >= 0 && hour < 24 && minute >= 0 && minute < 60 && second >= 0 && second < 60)
			{
				return new DateTime(JulianCalendar.DateToTicks(year, month, day) + new TimeSpan(0, hour, minute, second, millisecond).Ticks);
			}
			throw new ArgumentOutOfRangeException(null, Environment.GetResourceString("ArgumentOutOfRange_BadHourMinuteSecond"));
		}

		/// <summary>Gets or sets the last year of a 100-year range that can be represented by a 2-digit year.</summary>
		/// <returns>The last year of a 100-year range that can be represented by a 2-digit year.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value specified in a set operation is less than 99.  
		///  -or-  
		///  The value specified in a set operation is greater than <see langword="MaxSupportedDateTime.Year" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">In a set operation, the current instance is read-only.</exception>
		// Token: 0x17000696 RID: 1686
		// (get) Token: 0x06002F5A RID: 12122 RVA: 0x000B56F7 File Offset: 0x000B38F7
		// (set) Token: 0x06002F5B RID: 12123 RVA: 0x000B5700 File Offset: 0x000B3900
		public override int TwoDigitYearMax
		{
			get
			{
				return this.twoDigitYearMax;
			}
			set
			{
				base.VerifyWritable();
				if (value < 99 || value > this.MaxYear)
				{
					throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 99, this.MaxYear));
				}
				this.twoDigitYearMax = value;
			}
		}

		/// <summary>Converts the specified year to a four-digit year by using the <see cref="P:System.Globalization.JulianCalendar.TwoDigitYearMax" /> property to determine the appropriate century.</summary>
		/// <param name="year">A two-digit or four-digit integer that represents the year to convert.</param>
		/// <returns>An integer that contains the four-digit representation of <paramref name="year" />.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="year" /> is outside the range supported by the calendar.</exception>
		// Token: 0x06002F5C RID: 12124 RVA: 0x000B575C File Offset: 0x000B395C
		public override int ToFourDigitYear(int year)
		{
			if (year < 0)
			{
				throw new ArgumentOutOfRangeException("year", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (year > this.MaxYear)
			{
				throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Bounds_Lower_Upper"), 1, this.MaxYear));
			}
			return base.ToFourDigitYear(year);
		}

		/// <summary>Represents the current era. This field is constant.</summary>
		// Token: 0x040013F0 RID: 5104
		public static readonly int JulianEra = 1;

		// Token: 0x040013F1 RID: 5105
		private const int DatePartYear = 0;

		// Token: 0x040013F2 RID: 5106
		private const int DatePartDayOfYear = 1;

		// Token: 0x040013F3 RID: 5107
		private const int DatePartMonth = 2;

		// Token: 0x040013F4 RID: 5108
		private const int DatePartDay = 3;

		// Token: 0x040013F5 RID: 5109
		private const int JulianDaysPerYear = 365;

		// Token: 0x040013F6 RID: 5110
		private const int JulianDaysPer4Years = 1461;

		// Token: 0x040013F7 RID: 5111
		private static readonly int[] DaysToMonth365 = new int[]
		{
			0,
			31,
			59,
			90,
			120,
			151,
			181,
			212,
			243,
			273,
			304,
			334,
			365
		};

		// Token: 0x040013F8 RID: 5112
		private static readonly int[] DaysToMonth366 = new int[]
		{
			0,
			31,
			60,
			91,
			121,
			152,
			182,
			213,
			244,
			274,
			305,
			335,
			366
		};

		// Token: 0x040013F9 RID: 5113
		internal int MaxYear = 9999;
	}
}
