using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace SharpDX.Multimedia
{
	// Token: 0x0200006A RID: 106
	[StructLayout(LayoutKind.Sequential, Size = 4)]
	public struct FourCC : IEquatable<FourCC>, IFormattable
	{
		// Token: 0x0600027F RID: 639 RVA: 0x00007A1C File Offset: 0x00005C1C
		public FourCC(string fourCC)
		{
			if (fourCC.Length != 4)
			{
				throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid length for FourCC(\"{0}\". Must be be 4 characters long ", new object[]
				{
					fourCC
				}), "fourCC");
			}
			this.value = (uint)((uint)fourCC[3] << 24 | (uint)fourCC[2] << 16 | (uint)fourCC[1] << 8 | fourCC[0]);
		}

		// Token: 0x06000280 RID: 640 RVA: 0x00007A83 File Offset: 0x00005C83
		public FourCC(char byte1, char byte2, char byte3, char byte4)
		{
			this.value = (uint)((uint)byte4 << 24 | (uint)byte3 << 16 | (uint)byte2 << 8 | byte1);
		}

		// Token: 0x06000281 RID: 641 RVA: 0x00007A9B File Offset: 0x00005C9B
		public FourCC(uint fourCC)
		{
			this.value = fourCC;
		}

		// Token: 0x06000282 RID: 642 RVA: 0x00007A9B File Offset: 0x00005C9B
		public FourCC(int fourCC)
		{
			this.value = (uint)fourCC;
		}

		// Token: 0x06000283 RID: 643 RVA: 0x00007AA4 File Offset: 0x00005CA4
		public static implicit operator uint(FourCC d)
		{
			return d.value;
		}

		// Token: 0x06000284 RID: 644 RVA: 0x00007AA4 File Offset: 0x00005CA4
		public static implicit operator int(FourCC d)
		{
			return (int)d.value;
		}

		// Token: 0x06000285 RID: 645 RVA: 0x00007AAC File Offset: 0x00005CAC
		public static implicit operator FourCC(uint d)
		{
			return new FourCC(d);
		}

		// Token: 0x06000286 RID: 646 RVA: 0x00007AB4 File Offset: 0x00005CB4
		public static implicit operator FourCC(int d)
		{
			return new FourCC(d);
		}

		// Token: 0x06000287 RID: 647 RVA: 0x00007ABC File Offset: 0x00005CBC
		public static implicit operator string(FourCC d)
		{
			return d.ToString();
		}

		// Token: 0x06000288 RID: 648 RVA: 0x00007ACB File Offset: 0x00005CCB
		public static implicit operator FourCC(string d)
		{
			return new FourCC(d);
		}

		// Token: 0x06000289 RID: 649 RVA: 0x00007AD4 File Offset: 0x00005CD4
		public override string ToString()
		{
			return string.Format("{0}", new string(new char[]
			{
				(char)(this.value & 255U),
				(char)(this.value >> 8 & 255U),
				(char)(this.value >> 16 & 255U),
				(char)(this.value >> 24 & 255U)
			}));
		}

		// Token: 0x0600028A RID: 650 RVA: 0x00007B3E File Offset: 0x00005D3E
		public bool Equals(FourCC other)
		{
			return this.value == other.value;
		}

		// Token: 0x0600028B RID: 651 RVA: 0x00007B4E File Offset: 0x00005D4E
		public override bool Equals(object obj)
		{
			return obj != null && obj is FourCC && this.Equals((FourCC)obj);
		}

		// Token: 0x0600028C RID: 652 RVA: 0x00007AA4 File Offset: 0x00005CA4
		public override int GetHashCode()
		{
			return (int)this.value;
		}

		// Token: 0x0600028D RID: 653 RVA: 0x00007B6C File Offset: 0x00005D6C
		public string ToString(string format, IFormatProvider formatProvider)
		{
			if (string.IsNullOrEmpty(format))
			{
				format = "G";
			}
			if (formatProvider == null)
			{
				formatProvider = CultureInfo.CurrentCulture;
			}
			string a = format.ToUpperInvariant();
			if (a == "G")
			{
				return this.ToString();
			}
			if (!(a == "I"))
			{
				return this.value.ToString(format, formatProvider);
			}
			return this.value.ToString("X08", formatProvider);
		}

		// Token: 0x0600028E RID: 654 RVA: 0x00007BE1 File Offset: 0x00005DE1
		public static bool operator ==(FourCC left, FourCC right)
		{
			return left.Equals(right);
		}

		// Token: 0x0600028F RID: 655 RVA: 0x00007BEB File Offset: 0x00005DEB
		public static bool operator !=(FourCC left, FourCC right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04000D77 RID: 3447
		public static readonly FourCC Empty = new FourCC(0);

		// Token: 0x04000D78 RID: 3448
		private uint value;
	}
}
