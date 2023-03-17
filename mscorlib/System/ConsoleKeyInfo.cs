using System;

namespace System
{
	/// <summary>Describes the console key that was pressed, including the character represented by the console key and the state of the SHIFT, ALT, and CTRL modifier keys.</summary>
	// Token: 0x020000C7 RID: 199
	[Serializable]
	public struct ConsoleKeyInfo
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.ConsoleKeyInfo" /> structure using the specified character, console key, and modifier keys.</summary>
		/// <param name="keyChar">The Unicode character that corresponds to the <paramref name="key" /> parameter.</param>
		/// <param name="key">The console key that corresponds to the <paramref name="keyChar" /> parameter.</param>
		/// <param name="shift">
		///   <see langword="true" /> to indicate that a SHIFT key was pressed; otherwise, <see langword="false" />.</param>
		/// <param name="alt">
		///   <see langword="true" /> to indicate that an ALT key was pressed; otherwise, <see langword="false" />.</param>
		/// <param name="control">
		///   <see langword="true" /> to indicate that a CTRL key was pressed; otherwise, <see langword="false" />.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The numeric value of the <paramref name="key" /> parameter is less than 0 or greater than 255.</exception>
		// Token: 0x06000B9A RID: 2970 RVA: 0x00024F68 File Offset: 0x00023168
		public ConsoleKeyInfo(char keyChar, ConsoleKey key, bool shift, bool alt, bool control)
		{
			if (key < (ConsoleKey)0 || key > (ConsoleKey)255)
			{
				throw new ArgumentOutOfRangeException("key", Environment.GetResourceString("ArgumentOutOfRange_ConsoleKey"));
			}
			this._keyChar = keyChar;
			this._key = key;
			this._mods = (ConsoleModifiers)0;
			if (shift)
			{
				this._mods |= ConsoleModifiers.Shift;
			}
			if (alt)
			{
				this._mods |= ConsoleModifiers.Alt;
			}
			if (control)
			{
				this._mods |= ConsoleModifiers.Control;
			}
		}

		/// <summary>Gets the Unicode character represented by the current <see cref="T:System.ConsoleKeyInfo" /> object.</summary>
		/// <returns>An object that corresponds to the console key represented by the current <see cref="T:System.ConsoleKeyInfo" /> object.</returns>
		// Token: 0x1700017F RID: 383
		// (get) Token: 0x06000B9B RID: 2971 RVA: 0x00024FE0 File Offset: 0x000231E0
		public char KeyChar
		{
			get
			{
				return this._keyChar;
			}
		}

		/// <summary>Gets the console key represented by the current <see cref="T:System.ConsoleKeyInfo" /> object.</summary>
		/// <returns>A value that identifies the console key that was pressed.</returns>
		// Token: 0x17000180 RID: 384
		// (get) Token: 0x06000B9C RID: 2972 RVA: 0x00024FE8 File Offset: 0x000231E8
		public ConsoleKey Key
		{
			get
			{
				return this._key;
			}
		}

		/// <summary>Gets a bitwise combination of <see cref="T:System.ConsoleModifiers" /> values that specifies one or more modifier keys pressed simultaneously with the console key.</summary>
		/// <returns>A bitwise combination of the enumeration values. There is no default value.</returns>
		// Token: 0x17000181 RID: 385
		// (get) Token: 0x06000B9D RID: 2973 RVA: 0x00024FF0 File Offset: 0x000231F0
		public ConsoleModifiers Modifiers
		{
			get
			{
				return this._mods;
			}
		}

		/// <summary>Gets a value indicating whether the specified object is equal to the current <see cref="T:System.ConsoleKeyInfo" /> object.</summary>
		/// <param name="value">An object to compare to the current <see cref="T:System.ConsoleKeyInfo" /> object.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="value" /> is a <see cref="T:System.ConsoleKeyInfo" /> object and is equal to the current <see cref="T:System.ConsoleKeyInfo" /> object; otherwise, <see langword="false" />.</returns>
		// Token: 0x06000B9E RID: 2974 RVA: 0x00024FF8 File Offset: 0x000231F8
		public override bool Equals(object value)
		{
			return value is ConsoleKeyInfo && this.Equals((ConsoleKeyInfo)value);
		}

		/// <summary>Gets a value indicating whether the specified <see cref="T:System.ConsoleKeyInfo" /> object is equal to the current <see cref="T:System.ConsoleKeyInfo" /> object.</summary>
		/// <param name="obj">An object to compare to the current <see cref="T:System.ConsoleKeyInfo" /> object.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="obj" /> is equal to the current <see cref="T:System.ConsoleKeyInfo" /> object; otherwise, <see langword="false" />.</returns>
		// Token: 0x06000B9F RID: 2975 RVA: 0x00025010 File Offset: 0x00023210
		public bool Equals(ConsoleKeyInfo obj)
		{
			return obj._keyChar == this._keyChar && obj._key == this._key && obj._mods == this._mods;
		}

		/// <summary>Indicates whether the specified <see cref="T:System.ConsoleKeyInfo" /> objects are equal.</summary>
		/// <param name="a">The first object to compare.</param>
		/// <param name="b">The second object to compare.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="a" /> is equal to <paramref name="b" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06000BA0 RID: 2976 RVA: 0x0002503E File Offset: 0x0002323E
		public static bool operator ==(ConsoleKeyInfo a, ConsoleKeyInfo b)
		{
			return a.Equals(b);
		}

		/// <summary>Indicates whether the specified <see cref="T:System.ConsoleKeyInfo" /> objects are not equal.</summary>
		/// <param name="a">The first object to compare.</param>
		/// <param name="b">The second object to compare.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="a" /> is not equal to <paramref name="b" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06000BA1 RID: 2977 RVA: 0x00025048 File Offset: 0x00023248
		public static bool operator !=(ConsoleKeyInfo a, ConsoleKeyInfo b)
		{
			return !(a == b);
		}

		/// <summary>Returns the hash code for the current <see cref="T:System.ConsoleKeyInfo" /> object.</summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		// Token: 0x06000BA2 RID: 2978 RVA: 0x00025054 File Offset: 0x00023254
		public override int GetHashCode()
		{
			return (int)((ConsoleModifiers)this._keyChar | this._mods);
		}

		// Token: 0x04000527 RID: 1319
		private char _keyChar;

		// Token: 0x04000528 RID: 1320
		private ConsoleKey _key;

		// Token: 0x04000529 RID: 1321
		private ConsoleModifiers _mods;
	}
}
