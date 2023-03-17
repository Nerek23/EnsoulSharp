using System;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.Win32;

namespace System.Globalization
{
	/// <summary>Represents the Hijri calendar.</summary>
	// Token: 0x02000395 RID: 917
	[ComVisible(true)]
	[Serializable]
	public class HijriCalendar : Calendar
	{
		/// <summary>Gets the earliest date and time supported by this calendar.</summary>
		/// <returns>The earliest date and time supported by the <see cref="T:System.Globalization.HijriCalendar" /> type, which is equivalent to the first moment of July 18, 622 C.E. in the Gregorian calendar.</returns>
		// Token: 0x17000664 RID: 1636
		// (get) Token: 0x06002EA3 RID: 11939 RVA: 0x000B3224 File Offset: 0x000B1424
		[ComVisible(false)]
		public override DateTime MinSupportedDateTime
		{
			get
			{
				return HijriCalendar.calendarMinValue;
			}
		}

		/// <summary>Gets the latest date and time supported by this calendar.</summary>
		/// <returns>The latest date and time supported by the <see cref="T:System.Globalization.HijriCalendar" /> type, which is equivalent to the last moment of December 31, 9999 C.E. in the Gregorian calendar.</returns>
		// Token: 0x17000665 RID: 1637
		// (get) Token: 0x06002EA4 RID: 11940 RVA: 0x000B322B File Offset: 0x000B142B
		[ComVisible(false)]
		public override DateTime MaxSupportedDateTime
		{
			get
			{
				return HijriCalendar.calendarMaxValue;
			}
		}

		/// <summary>Gets a value that indicates whether the current calendar is solar-based, lunar-based, or a combination of both.</summary>
		/// <returns>Always returns <see cref="F:System.Globalization.CalendarAlgorithmType.LunarCalendar" />.</returns>
		// Token: 0x17000666 RID: 1638
		// (get) Token: 0x06002EA5 RID: 11941 RVA: 0x000B3232 File Offset: 0x000B1432
		[ComVisible(false)]
		public override CalendarAlgorithmType AlgorithmType
		{
			get
			{
				return CalendarAlgorithmType.LunarCalendar;
			}
		}

		// Token: 0x17000667 RID: 1639
		// (get) Token: 0x06002EA7 RID: 11943 RVA: 0x000B3248 File Offset: 0x000B1448
		internal override int ID
		{
			get
			{
				return 6;
			}
		}

		/// <summary>Gets the number of days in the year that precedes the year that is specified by the <see cref="P:System.Globalization.HijriCalendar.MinSupportedDateTime" /> property.</summary>
		/// <returns>The number of days in the year that precedes the year specified by <see cref="P:System.Globalization.HijriCalendar.MinSupportedDateTime" />.</returns>
		// Token: 0x17000668 RID: 1640
		// (get) Token: 0x06002EA8 RID: 11944 RVA: 0x000B324B File Offset: 0x000B144B
		protected override int DaysInYearBeforeMinSupportedYear
		{
			get
			{
				return 354;
			}
		}

		// Token: 0x06002EA9 RID: 11945 RVA: 0x000B3252 File Offset: 0x000B1452
		private long GetAbsoluteDateHijri(int y, int m, int d)
		{
			return this.DaysUpToHijriYear(y) + (long)HijriCalendar.HijriMonthDays[m - 1] + (long)d - 1L - (long)this.HijriAdjustment;
		}

		// Token: 0x06002EAA RID: 11946 RVA: 0x000B3274 File Offset: 0x000B1474
		private long DaysUpToHijriYear(int HijriYear)
		{
			int num = (HijriYear - 1) / 30 * 30;
			int i = HijriYear - num - 1;
			long num2 = (long)num * 10631L / 30L + 227013L;
			while (i > 0)
			{
				num2 += (long)(354 + (this.IsLeapYear(i, 0) ? 1 : 0));
				i--;
			}
			return num2;
		}

		/// <summary>Gets or sets the number of days to add or subtract from the calendar to accommodate the variances in the start and the end of Ramadan and to accommodate the date difference between countries/regions.</summary>
		/// <returns>An integer from -2 to 2 that represents the number of days to add or subtract from the calendar.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The property is being set to an invalid value.</exception>
		// Token: 0x17000669 RID: 1641
		// (get) Token: 0x06002EAB RID: 11947 RVA: 0x000B32C9 File Offset: 0x000B14C9
		// (set) Token: 0x06002EAC RID: 11948 RVA: 0x000B32EC File Offset: 0x000B14EC
		public int HijriAdjustment
		{
			[SecuritySafeCritical]
			get
			{
				if (this.m_HijriAdvance == -2147483648)
				{
					this.m_HijriAdvance = HijriCalendar.GetAdvanceHijriDate();
				}
				return this.m_HijriAdvance;
			}
			set
			{
				if (value < -2 || value > 2)
				{
					throw new ArgumentOutOfRangeException("HijriAdjustment", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Bounds_Lower_Upper"), -2, 2));
				}
				base.VerifyWritable();
				this.m_HijriAdvance = value;
			}
		}

		// Token: 0x06002EAD RID: 11949 RVA: 0x000B333C File Offset: 0x000B153C
		[SecurityCritical]
		private static int GetAdvanceHijriDate()
		{
			int result = 0;
			RegistryKey registryKey = null;
			try
			{
				registryKey = Registry.CurrentUser.InternalOpenSubKey("Control Panel\\International", false);
			}
			catch (ObjectDisposedException)
			{
				return 0;
			}
			catch (ArgumentException)
			{
				return 0;
			}
			if (registryKey != null)
			{
				try
				{
					object obj = registryKey.InternalGetValue("AddHijriDate", null, false, false);
					if (obj == null)
					{
						return 0;
					}
					string text = obj.ToString();
					if (string.Compare(text, 0, "AddHijriDate", 0, "AddHijriDate".Length, StringComparison.OrdinalIgnoreCase) == 0)
					{
						if (text.Length == "AddHijriDate".Length)
						{
							result = -1;
						}
						else
						{
							text = text.Substring("AddHijriDate".Length);
							try
							{
								int num = int.Parse(text.ToString(), CultureInfo.InvariantCulture);
								if (num >= -2 && num <= 2)
								{
									result = num;
								}
							}
							catch (ArgumentException)
							{
							}
							catch (FormatException)
							{
							}
							catch (OverflowException)
							{
							}
						}
					}
				}
				finally
				{
					registryKey.Close();
				}
			}
			return result;
		}

		// Token: 0x06002EAE RID: 11950 RVA: 0x000B3460 File Offset: 0x000B1660
		internal static void CheckTicksRange(long ticks)
		{
			if (ticks < HijriCalendar.calendarMinValue.Ticks || ticks > HijriCalendar.calendarMaxValue.Ticks)
			{
				throw new ArgumentOutOfRangeException("time", string.Format(CultureInfo.InvariantCulture, Environment.GetResourceString("ArgumentOutOfRange_CalendarRange"), HijriCalendar.calendarMinValue, HijriCalendar.calendarMaxValue));
			}
		}

		// Token: 0x06002EAF RID: 11951 RVA: 0x000B34C0 File Offset: 0x000B16C0
		internal static void CheckEraRange(int era)
		{
			if (era != 0 && era != HijriCalendar.HijriEra)
			{
				throw new ArgumentOutOfRangeException("era", Environment.GetResourceString("ArgumentOutOfRange_InvalidEraValue"));
			}
		}

		// Token: 0x06002EB0 RID: 11952 RVA: 0x000B34E4 File Offset: 0x000B16E4
		internal static void CheckYearRange(int year, int era)
		{
			HijriCalendar.CheckEraRange(era);
			if (year < 1 || year > 9666)
			{
				throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 1, 9666));
			}
		}

		// Token: 0x06002EB1 RID: 11953 RVA: 0x000B3534 File Offset: 0x000B1734
		internal static void CheckYearMonthRange(int year, int month, int era)
		{
			HijriCalendar.CheckYearRange(year, era);
			if (year == 9666 && month > 4)
			{
				throw new ArgumentOutOfRangeException("month", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 1, 4));
			}
			if (month < 1 || month > 12)
			{
				throw new ArgumentOutOfRangeException("month", Environment.GetResourceString("ArgumentOutOfRange_Month"));
			}
		}

		// Token: 0x06002EB2 RID: 11954 RVA: 0x000B35A0 File Offset: 0x000B17A0
		internal virtual int GetDatePart(long ticks, int part)
		{
			HijriCalendar.CheckTicksRange(ticks);
			long num = ticks / 864000000000L + 1L;
			num += (long)this.HijriAdjustment;
			int num2 = (int)((num - 227013L) * 30L / 10631L) + 1;
			long num3 = this.DaysUpToHijriYear(num2);
			long num4 = (long)this.GetDaysInYear(num2, 0);
			if (num < num3)
			{
				num3 -= num4;
				num2--;
			}
			else if (num == num3)
			{
				num2--;
				num3 -= (long)this.GetDaysInYear(num2, 0);
			}
			else if (num > num3 + num4)
			{
				num3 += num4;
				num2++;
			}
			if (part == 0)
			{
				return num2;
			}
			int num5 = 1;
			num -= num3;
			if (part == 1)
			{
				return (int)num;
			}
			while (num5 <= 12 && num > (long)HijriCalendar.HijriMonthDays[num5 - 1])
			{
				num5++;
			}
			num5--;
			if (part == 2)
			{
				return num5;
			}
			int result = (int)(num - (long)HijriCalendar.HijriMonthDays[num5 - 1]);
			if (part == 3)
			{
				return result;
			}
			throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_DateTimeParsing"));
		}

		/// <summary>Returns a <see cref="T:System.DateTime" /> that is the specified number of months away from the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to add months to.</param>
		/// <param name="months">The number of months to add.</param>
		/// <returns>The <see cref="T:System.DateTime" /> that results from adding the specified number of months to the specified <see cref="T:System.DateTime" />.</returns>
		/// <exception cref="T:System.ArgumentException">The resulting <see cref="T:System.DateTime" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="months" /> is less than -120000.  
		/// -or-  
		/// <paramref name="months" /> is greater than 120000.</exception>
		// Token: 0x06002EB3 RID: 11955 RVA: 0x000B368C File Offset: 0x000B188C
		public override DateTime AddMonths(DateTime time, int months)
		{
			if (months < -120000 || months > 120000)
			{
				throw new ArgumentOutOfRangeException("months", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), -120000, 120000));
			}
			int num = this.GetDatePart(time.Ticks, 0);
			int num2 = this.GetDatePart(time.Ticks, 2);
			int num3 = this.GetDatePart(time.Ticks, 3);
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
			int daysInMonth = this.GetDaysInMonth(num, num2);
			if (num3 > daysInMonth)
			{
				num3 = daysInMonth;
			}
			long ticks = this.GetAbsoluteDateHijri(num, num2, num3) * 864000000000L + time.Ticks % 864000000000L;
			Calendar.CheckAddResult(ticks, this.MinSupportedDateTime, this.MaxSupportedDateTime);
			return new DateTime(ticks);
		}

		/// <summary>Returns a <see cref="T:System.DateTime" /> that is the specified number of years away from the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to add years to.</param>
		/// <param name="years">The number of years to add.</param>
		/// <returns>The <see cref="T:System.DateTime" /> that results from adding the specified number of years to the specified <see cref="T:System.DateTime" />.</returns>
		/// <exception cref="T:System.ArgumentException">The resulting <see cref="T:System.DateTime" /> is outside the supported range.</exception>
		// Token: 0x06002EB4 RID: 11956 RVA: 0x000B378A File Offset: 0x000B198A
		public override DateTime AddYears(DateTime time, int years)
		{
			return this.AddMonths(time, years * 12);
		}

		/// <summary>Returns the day of the month in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <returns>An integer from 1 to 30 that represents the day of the month in the specified <see cref="T:System.DateTime" />.</returns>
		// Token: 0x06002EB5 RID: 11957 RVA: 0x000B3797 File Offset: 0x000B1997
		public override int GetDayOfMonth(DateTime time)
		{
			return this.GetDatePart(time.Ticks, 3);
		}

		/// <summary>Returns the day of the week in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <returns>A <see cref="T:System.DayOfWeek" /> value that represents the day of the week in the specified <see cref="T:System.DateTime" />.</returns>
		// Token: 0x06002EB6 RID: 11958 RVA: 0x000B37A7 File Offset: 0x000B19A7
		public override DayOfWeek GetDayOfWeek(DateTime time)
		{
			return (DayOfWeek)(time.Ticks / 864000000000L + 1L) % (DayOfWeek)7;
		}

		/// <summary>Returns the day of the year in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <returns>An integer from 1 to 355 that represents the day of the year in the specified <see cref="T:System.DateTime" />.</returns>
		// Token: 0x06002EB7 RID: 11959 RVA: 0x000B37C0 File Offset: 0x000B19C0
		public override int GetDayOfYear(DateTime time)
		{
			return this.GetDatePart(time.Ticks, 1);
		}

		/// <summary>Returns the number of days in the specified month of the specified year and era.</summary>
		/// <param name="year">An integer that represents the year.</param>
		/// <param name="month">An integer from 1 to 12 that represents the month.</param>
		/// <param name="era">An integer that represents the era.</param>
		/// <returns>The number of days in the specified month in the specified year in the specified era.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="era" /> is outside the range supported by this calendar.  
		/// -or-  
		/// <paramref name="year" /> is outside the range supported by this calendar.  
		/// -or-  
		/// <paramref name="month" /> is outside the range supported by this calendar.</exception>
		// Token: 0x06002EB8 RID: 11960 RVA: 0x000B37D0 File Offset: 0x000B19D0
		public override int GetDaysInMonth(int year, int month, int era)
		{
			HijriCalendar.CheckYearMonthRange(year, month, era);
			if (month == 12)
			{
				if (!this.IsLeapYear(year, 0))
				{
					return 29;
				}
				return 30;
			}
			else
			{
				if (month % 2 != 1)
				{
					return 29;
				}
				return 30;
			}
		}

		/// <summary>Returns the number of days in the specified year and era.</summary>
		/// <param name="year">An integer that represents the year.</param>
		/// <param name="era">An integer that represents the era.</param>
		/// <returns>The number of days in the specified year and era. The number of days is 354 in a common year or 355 in a leap year.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="year" /> or <paramref name="era" /> is outside the range supported by this calendar.</exception>
		// Token: 0x06002EB9 RID: 11961 RVA: 0x000B37FA File Offset: 0x000B19FA
		public override int GetDaysInYear(int year, int era)
		{
			HijriCalendar.CheckYearRange(year, era);
			if (!this.IsLeapYear(year, 0))
			{
				return 354;
			}
			return 355;
		}

		/// <summary>Returns the era in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <returns>An integer that represents the era in the specified <see cref="T:System.DateTime" />.</returns>
		// Token: 0x06002EBA RID: 11962 RVA: 0x000B3818 File Offset: 0x000B1A18
		public override int GetEra(DateTime time)
		{
			HijriCalendar.CheckTicksRange(time.Ticks);
			return HijriCalendar.HijriEra;
		}

		/// <summary>Gets the list of eras in the <see cref="T:System.Globalization.HijriCalendar" />.</summary>
		/// <returns>An array of integers that represents the eras in the <see cref="T:System.Globalization.HijriCalendar" />.</returns>
		// Token: 0x1700066A RID: 1642
		// (get) Token: 0x06002EBB RID: 11963 RVA: 0x000B382B File Offset: 0x000B1A2B
		public override int[] Eras
		{
			get
			{
				return new int[]
				{
					HijriCalendar.HijriEra
				};
			}
		}

		/// <summary>Returns the month in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <returns>An integer from 1 to 12 that represents the month in the specified <see cref="T:System.DateTime" />.</returns>
		// Token: 0x06002EBC RID: 11964 RVA: 0x000B383B File Offset: 0x000B1A3B
		public override int GetMonth(DateTime time)
		{
			return this.GetDatePart(time.Ticks, 2);
		}

		/// <summary>Returns the number of months in the specified year and era.</summary>
		/// <param name="year">An integer that represents the year.</param>
		/// <param name="era">An integer that represents the era.</param>
		/// <returns>The number of months in the specified year and era.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="era" /> is outside the range supported by this calendar.  
		/// -or-  
		/// <paramref name="year" /> is outside the range supported by this calendar.</exception>
		// Token: 0x06002EBD RID: 11965 RVA: 0x000B384B File Offset: 0x000B1A4B
		public override int GetMonthsInYear(int year, int era)
		{
			HijriCalendar.CheckYearRange(year, era);
			return 12;
		}

		/// <summary>Returns the year in the specified <see cref="T:System.DateTime" />.</summary>
		/// <param name="time">The <see cref="T:System.DateTime" /> to read.</param>
		/// <returns>An integer that represents the year in the specified <see cref="T:System.DateTime" />.</returns>
		// Token: 0x06002EBE RID: 11966 RVA: 0x000B3856 File Offset: 0x000B1A56
		public override int GetYear(DateTime time)
		{
			return this.GetDatePart(time.Ticks, 0);
		}

		/// <summary>Determines whether the specified date is a leap day.</summary>
		/// <param name="year">An integer that represents the year.</param>
		/// <param name="month">An integer from 1 to 12 that represents the month.</param>
		/// <param name="day">An integer from 1 to 30 that represents the day.</param>
		/// <param name="era">An integer that represents the era.</param>
		/// <returns>
		///   <see langword="true" /> if the specified day is a leap day; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="era" /> is outside the range supported by this calendar.  
		/// -or-  
		/// <paramref name="year" /> is outside the range supported by this calendar.  
		/// -or-  
		/// <paramref name="month" /> is outside the range supported by this calendar.  
		/// -or-  
		/// <paramref name="day" /> is outside the range supported by this calendar.</exception>
		// Token: 0x06002EBF RID: 11967 RVA: 0x000B3868 File Offset: 0x000B1A68
		public override bool IsLeapDay(int year, int month, int day, int era)
		{
			int daysInMonth = this.GetDaysInMonth(year, month, era);
			if (day < 1 || day > daysInMonth)
			{
				throw new ArgumentOutOfRangeException("day", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Day"), daysInMonth, month));
			}
			return this.IsLeapYear(year, era) && month == 12 && day == 30;
		}

		/// <summary>Calculates the leap month for a specified year and era.</summary>
		/// <param name="year">A year.</param>
		/// <param name="era">An era. Specify <see cref="F:System.Globalization.Calendar.CurrentEra" /> or <see cref="F:System.Globalization.HijriCalendar.HijriEra" />.</param>
		/// <returns>Always 0 because the <see cref="T:System.Globalization.HijriCalendar" /> type does not support the notion of a leap month.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="year" /> is less than the Hijri calendar year 1 or greater than the year 9666.  
		/// -or-  
		/// <paramref name="era" /> is not <see cref="F:System.Globalization.Calendar.CurrentEra" /> or <see cref="F:System.Globalization.HijriCalendar.HijriEra" />.</exception>
		// Token: 0x06002EC0 RID: 11968 RVA: 0x000B38CA File Offset: 0x000B1ACA
		[ComVisible(false)]
		public override int GetLeapMonth(int year, int era)
		{
			HijriCalendar.CheckYearRange(year, era);
			return 0;
		}

		/// <summary>Determines whether the specified month in the specified year and era is a leap month.</summary>
		/// <param name="year">An integer that represents the year.</param>
		/// <param name="month">An integer from 1 to 12 that represents the month.</param>
		/// <param name="era">An integer that represents the era.</param>
		/// <returns>This method always returns <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="era" /> is outside the range supported by this calendar.  
		/// -or-  
		/// <paramref name="year" /> is outside the range supported by this calendar.  
		/// -or-  
		/// <paramref name="month" /> is outside the range supported by this calendar.</exception>
		// Token: 0x06002EC1 RID: 11969 RVA: 0x000B38D4 File Offset: 0x000B1AD4
		public override bool IsLeapMonth(int year, int month, int era)
		{
			HijriCalendar.CheckYearMonthRange(year, month, era);
			return false;
		}

		/// <summary>Determines whether the specified year in the specified era is a leap year.</summary>
		/// <param name="year">An integer that represents the year.</param>
		/// <param name="era">An integer that represents the era.</param>
		/// <returns>
		///   <see langword="true" /> if the specified year is a leap year; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="era" /> is outside the range supported by this calendar.  
		/// -or-  
		/// <paramref name="year" /> is outside the range supported by this calendar.</exception>
		// Token: 0x06002EC2 RID: 11970 RVA: 0x000B38DF File Offset: 0x000B1ADF
		public override bool IsLeapYear(int year, int era)
		{
			HijriCalendar.CheckYearRange(year, era);
			return (year * 11 + 14) % 30 < 11;
		}

		/// <summary>Returns a <see cref="T:System.DateTime" /> that is set to the specified date, time, and era.</summary>
		/// <param name="year">An integer that represents the year.</param>
		/// <param name="month">An integer from 1 to 12 that represents the month.</param>
		/// <param name="day">An integer from 1 to 30 that represents the day.</param>
		/// <param name="hour">An integer from 0 to 23 that represents the hour.</param>
		/// <param name="minute">An integer from 0 to 59 that represents the minute.</param>
		/// <param name="second">An integer from 0 to 59 that represents the second.</param>
		/// <param name="millisecond">An integer from 0 to 999 that represents the millisecond.</param>
		/// <param name="era">An integer that represents the era.</param>
		/// <returns>The <see cref="T:System.DateTime" /> that is set to the specified date and time in the current era.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="era" /> is outside the range supported by this calendar.  
		/// -or-  
		/// <paramref name="year" /> is outside the range supported by this calendar.  
		/// -or-  
		/// <paramref name="month" /> is outside the range supported by this calendar.  
		/// -or-  
		/// <paramref name="day" /> is outside the range supported by this calendar.  
		/// -or-  
		/// <paramref name="hour" /> is less than zero or greater than 23.  
		/// -or-  
		/// <paramref name="minute" /> is less than zero or greater than 59.  
		/// -or-  
		/// <paramref name="second" /> is less than zero or greater than 59.  
		/// -or-  
		/// <paramref name="millisecond" /> is less than zero or greater than 999.</exception>
		// Token: 0x06002EC3 RID: 11971 RVA: 0x000B38F8 File Offset: 0x000B1AF8
		public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era)
		{
			int daysInMonth = this.GetDaysInMonth(year, month, era);
			if (day < 1 || day > daysInMonth)
			{
				throw new ArgumentOutOfRangeException("day", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Day"), daysInMonth, month));
			}
			long absoluteDateHijri = this.GetAbsoluteDateHijri(year, month, day);
			if (absoluteDateHijri >= 0L)
			{
				return new DateTime(absoluteDateHijri * 864000000000L + Calendar.TimeToTicks(hour, minute, second, millisecond));
			}
			throw new ArgumentOutOfRangeException(null, Environment.GetResourceString("ArgumentOutOfRange_BadYearMonthDay"));
		}

		/// <summary>Gets or sets the last year of a 100-year range that can be represented by a 2-digit year.</summary>
		/// <returns>The last year of a 100-year range that can be represented by a 2-digit year.</returns>
		/// <exception cref="T:System.InvalidOperationException">This calendar is read-only.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value in a set operation is less than 100 or greater than 9666.</exception>
		// Token: 0x1700066B RID: 1643
		// (get) Token: 0x06002EC4 RID: 11972 RVA: 0x000B3981 File Offset: 0x000B1B81
		// (set) Token: 0x06002EC5 RID: 11973 RVA: 0x000B39A8 File Offset: 0x000B1BA8
		public override int TwoDigitYearMax
		{
			get
			{
				if (this.twoDigitYearMax == -1)
				{
					this.twoDigitYearMax = Calendar.GetSystemTwoDigitYearSetting(this.ID, 1451);
				}
				return this.twoDigitYearMax;
			}
			set
			{
				base.VerifyWritable();
				if (value < 99 || value > 9666)
				{
					throw new ArgumentOutOfRangeException("value", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 99, 9666));
				}
				this.twoDigitYearMax = value;
			}
		}

		/// <summary>Converts the specified year to a four-digit year by using the <see cref="P:System.Globalization.HijriCalendar.TwoDigitYearMax" /> property to determine the appropriate century.</summary>
		/// <param name="year">A two-digit or four-digit integer that represents the year to convert.</param>
		/// <returns>An integer that contains the four-digit representation of <paramref name="year" />.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="year" /> is outside the range supported by this calendar.</exception>
		// Token: 0x06002EC6 RID: 11974 RVA: 0x000B3A00 File Offset: 0x000B1C00
		public override int ToFourDigitYear(int year)
		{
			if (year < 0)
			{
				throw new ArgumentOutOfRangeException("year", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (year < 100)
			{
				return base.ToFourDigitYear(year);
			}
			if (year > 9666)
			{
				throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 1, 9666));
			}
			return year;
		}

		/// <summary>Represents the current era. This field is constant.</summary>
		// Token: 0x040013AD RID: 5037
		public static readonly int HijriEra = 1;

		// Token: 0x040013AE RID: 5038
		internal const int DatePartYear = 0;

		// Token: 0x040013AF RID: 5039
		internal const int DatePartDayOfYear = 1;

		// Token: 0x040013B0 RID: 5040
		internal const int DatePartMonth = 2;

		// Token: 0x040013B1 RID: 5041
		internal const int DatePartDay = 3;

		// Token: 0x040013B2 RID: 5042
		internal const int MinAdvancedHijri = -2;

		// Token: 0x040013B3 RID: 5043
		internal const int MaxAdvancedHijri = 2;

		// Token: 0x040013B4 RID: 5044
		internal static readonly int[] HijriMonthDays = new int[]
		{
			0,
			30,
			59,
			89,
			118,
			148,
			177,
			207,
			236,
			266,
			295,
			325,
			355
		};

		// Token: 0x040013B5 RID: 5045
		private const string InternationalRegKey = "Control Panel\\International";

		// Token: 0x040013B6 RID: 5046
		private const string HijriAdvanceRegKeyEntry = "AddHijriDate";

		// Token: 0x040013B7 RID: 5047
		private int m_HijriAdvance = int.MinValue;

		// Token: 0x040013B8 RID: 5048
		internal const int MaxCalendarYear = 9666;

		// Token: 0x040013B9 RID: 5049
		internal const int MaxCalendarMonth = 4;

		// Token: 0x040013BA RID: 5050
		internal const int MaxCalendarDay = 3;

		// Token: 0x040013BB RID: 5051
		internal static readonly DateTime calendarMinValue = new DateTime(622, 7, 18);

		// Token: 0x040013BC RID: 5052
		internal static readonly DateTime calendarMaxValue = DateTime.MaxValue;

		// Token: 0x040013BD RID: 5053
		private const int DEFAULT_TWO_DIGIT_YEAR_MAX = 1451;
	}
}
