using System;
using System.Runtime.InteropServices;

namespace System.Threading
{
	/// <summary>Defines the lock that implements single-writer/multiple-reader semantics. This is a value type.</summary>
	// Token: 0x020004D1 RID: 1233
	[ComVisible(true)]
	public struct LockCookie
	{
		/// <summary>Returns the hash code for this instance.</summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		// Token: 0x06003B37 RID: 15159 RVA: 0x000DF822 File Offset: 0x000DDA22
		public override int GetHashCode()
		{
			return this._dwFlags + this._dwWriterSeqNum + this._wReaderAndWriterLevel + this._dwThreadID;
		}

		/// <summary>Indicates whether a specified object is a <see cref="T:System.Threading.LockCookie" /> and is equal to the current instance.</summary>
		/// <param name="obj">The object to compare to the current instance.</param>
		/// <returns>
		///   <see langword="true" /> if the value of <paramref name="obj" /> is equal to the value of the current instance; otherwise, <see langword="false" />.</returns>
		// Token: 0x06003B38 RID: 15160 RVA: 0x000DF83F File Offset: 0x000DDA3F
		public override bool Equals(object obj)
		{
			return obj is LockCookie && this.Equals((LockCookie)obj);
		}

		/// <summary>Indicates whether the current instance is equal to the specified <see cref="T:System.Threading.LockCookie" />.</summary>
		/// <param name="obj">The <see cref="T:System.Threading.LockCookie" /> to compare to the current instance.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="obj" /> is equal to the value of the current instance; otherwise, <see langword="false" />.</returns>
		// Token: 0x06003B39 RID: 15161 RVA: 0x000DF857 File Offset: 0x000DDA57
		public bool Equals(LockCookie obj)
		{
			return obj._dwFlags == this._dwFlags && obj._dwWriterSeqNum == this._dwWriterSeqNum && obj._wReaderAndWriterLevel == this._wReaderAndWriterLevel && obj._dwThreadID == this._dwThreadID;
		}

		/// <summary>Indicates whether two <see cref="T:System.Threading.LockCookie" /> structures are equal.</summary>
		/// <param name="a">The <see cref="T:System.Threading.LockCookie" /> to compare to <paramref name="b" />.</param>
		/// <param name="b">The <see cref="T:System.Threading.LockCookie" /> to compare to <paramref name="a" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="a" /> is equal to <paramref name="b" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06003B3A RID: 15162 RVA: 0x000DF893 File Offset: 0x000DDA93
		public static bool operator ==(LockCookie a, LockCookie b)
		{
			return a.Equals(b);
		}

		/// <summary>Indicates whether two <see cref="T:System.Threading.LockCookie" /> structures are not equal.</summary>
		/// <param name="a">The <see cref="T:System.Threading.LockCookie" /> to compare to <paramref name="b" />.</param>
		/// <param name="b">The <see cref="T:System.Threading.LockCookie" /> to compare to <paramref name="a" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="a" /> is not equal to <paramref name="b" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06003B3B RID: 15163 RVA: 0x000DF89D File Offset: 0x000DDA9D
		public static bool operator !=(LockCookie a, LockCookie b)
		{
			return !(a == b);
		}

		// Token: 0x040018E4 RID: 6372
		private int _dwFlags;

		// Token: 0x040018E5 RID: 6373
		private int _dwWriterSeqNum;

		// Token: 0x040018E6 RID: 6374
		private int _wReaderAndWriterLevel;

		// Token: 0x040018E7 RID: 6375
		private int _dwThreadID;
	}
}
