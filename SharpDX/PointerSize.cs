using System;
using System.Globalization;

namespace SharpDX
{
	// Token: 0x02000029 RID: 41
	public struct PointerSize : IEquatable<PointerSize>
	{
		// Token: 0x06000112 RID: 274 RVA: 0x000040B4 File Offset: 0x000022B4
		public PointerSize(IntPtr size)
		{
			this._size = size;
		}

		// Token: 0x06000113 RID: 275 RVA: 0x000040BD File Offset: 0x000022BD
		private unsafe PointerSize(void* size)
		{
			this._size = new IntPtr(size);
		}

		// Token: 0x06000114 RID: 276 RVA: 0x000040CB File Offset: 0x000022CB
		public PointerSize(int size)
		{
			this._size = new IntPtr(size);
		}

		// Token: 0x06000115 RID: 277 RVA: 0x000040D9 File Offset: 0x000022D9
		public PointerSize(long size)
		{
			this._size = new IntPtr(size);
		}

		// Token: 0x06000116 RID: 278 RVA: 0x000040E7 File Offset: 0x000022E7
		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "{0}", new object[]
			{
				this._size
			});
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0000410C File Offset: 0x0000230C
		public string ToString(string format)
		{
			if (format == null)
			{
				return this.ToString();
			}
			return string.Format(CultureInfo.CurrentCulture, "{0}", new object[]
			{
				this._size.ToString(format)
			});
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00004142 File Offset: 0x00002342
		public override int GetHashCode()
		{
			return this._size.GetHashCode();
		}

		// Token: 0x06000119 RID: 281 RVA: 0x0000414F File Offset: 0x0000234F
		public bool Equals(PointerSize other)
		{
			return this._size.Equals(other._size);
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00004167 File Offset: 0x00002367
		public override bool Equals(object value)
		{
			return value != null && value is PointerSize && this.Equals((PointerSize)value);
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00004184 File Offset: 0x00002384
		public static PointerSize operator +(PointerSize left, PointerSize right)
		{
			return new PointerSize(left._size.ToInt64() + right._size.ToInt64());
		}

		// Token: 0x0600011C RID: 284 RVA: 0x000041A4 File Offset: 0x000023A4
		public static PointerSize operator +(PointerSize value)
		{
			return value;
		}

		// Token: 0x0600011D RID: 285 RVA: 0x000041A7 File Offset: 0x000023A7
		public static PointerSize operator -(PointerSize left, PointerSize right)
		{
			return new PointerSize(left._size.ToInt64() - right._size.ToInt64());
		}

		// Token: 0x0600011E RID: 286 RVA: 0x000041C7 File Offset: 0x000023C7
		public static PointerSize operator -(PointerSize value)
		{
			return new PointerSize(-value._size.ToInt64());
		}

		// Token: 0x0600011F RID: 287 RVA: 0x000041DB File Offset: 0x000023DB
		public static PointerSize operator *(int scale, PointerSize value)
		{
			return new PointerSize((long)scale * value._size.ToInt64());
		}

		// Token: 0x06000120 RID: 288 RVA: 0x000041F1 File Offset: 0x000023F1
		public static PointerSize operator *(PointerSize value, int scale)
		{
			return new PointerSize((long)scale * value._size.ToInt64());
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00004207 File Offset: 0x00002407
		public static PointerSize operator /(PointerSize value, int scale)
		{
			return new PointerSize(value._size.ToInt64() / (long)scale);
		}

		// Token: 0x06000122 RID: 290 RVA: 0x0000421D File Offset: 0x0000241D
		public static bool operator ==(PointerSize left, PointerSize right)
		{
			return left.Equals(right);
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00004227 File Offset: 0x00002427
		public static bool operator !=(PointerSize left, PointerSize right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00004234 File Offset: 0x00002434
		public static implicit operator int(PointerSize value)
		{
			return value._size.ToInt32();
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00004242 File Offset: 0x00002442
		public static implicit operator long(PointerSize value)
		{
			return value._size.ToInt64();
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00004250 File Offset: 0x00002450
		public static implicit operator PointerSize(int value)
		{
			return new PointerSize(value);
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00004258 File Offset: 0x00002458
		public static implicit operator PointerSize(long value)
		{
			return new PointerSize(value);
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00004260 File Offset: 0x00002460
		public static implicit operator PointerSize(IntPtr value)
		{
			return new PointerSize(value);
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00004268 File Offset: 0x00002468
		public static implicit operator IntPtr(PointerSize value)
		{
			return value._size;
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00004270 File Offset: 0x00002470
		public unsafe static implicit operator PointerSize(void* value)
		{
			return new PointerSize(value);
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00004278 File Offset: 0x00002478
		public unsafe static implicit operator void*(PointerSize value)
		{
			return (void*)value._size;
		}

		// Token: 0x04000038 RID: 56
		private IntPtr _size;

		// Token: 0x04000039 RID: 57
		public static readonly PointerSize Zero = new PointerSize(0);
	}
}
