using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX
{
	// Token: 0x02000003 RID: 3
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct Bool4 : IEquatable<Bool4>, IFormattable
	{
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600003D RID: 61 RVA: 0x000026BE File Offset: 0x000008BE
		// (set) Token: 0x0600003E RID: 62 RVA: 0x000026C9 File Offset: 0x000008C9
		public bool X
		{
			get
			{
				return this.iX != 0;
			}
			set
			{
				this.iX = (value ? 1 : 0);
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600003F RID: 63 RVA: 0x000026D8 File Offset: 0x000008D8
		// (set) Token: 0x06000040 RID: 64 RVA: 0x000026E3 File Offset: 0x000008E3
		public bool Y
		{
			get
			{
				return this.iY != 0;
			}
			set
			{
				this.iY = (value ? 1 : 0);
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000041 RID: 65 RVA: 0x000026F2 File Offset: 0x000008F2
		// (set) Token: 0x06000042 RID: 66 RVA: 0x000026FD File Offset: 0x000008FD
		public bool Z
		{
			get
			{
				return this.iZ != 0;
			}
			set
			{
				this.iZ = (value ? 1 : 0);
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000043 RID: 67 RVA: 0x0000270C File Offset: 0x0000090C
		// (set) Token: 0x06000044 RID: 68 RVA: 0x00002717 File Offset: 0x00000917
		public bool W
		{
			get
			{
				return this.iW != 0;
			}
			set
			{
				this.iW = (value ? 1 : 0);
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002726 File Offset: 0x00000926
		public Bool4(bool value)
		{
			this.iX = (value ? 1 : 0);
			this.iY = (value ? 1 : 0);
			this.iZ = (value ? 1 : 0);
			this.iW = (value ? 1 : 0);
		}

		// Token: 0x06000046 RID: 70 RVA: 0x0000275C File Offset: 0x0000095C
		public Bool4(bool x, bool y, bool z, bool w)
		{
			this.iX = (x ? 1 : 0);
			this.iY = (y ? 1 : 0);
			this.iZ = (z ? 1 : 0);
			this.iW = (w ? 1 : 0);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002794 File Offset: 0x00000994
		public Bool4(bool[] values)
		{
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}
			if (values.Length != 4)
			{
				throw new ArgumentOutOfRangeException("values", "There must be four and only four input values for Bool4.");
			}
			this.iX = (values[0] ? 1 : 0);
			this.iY = (values[1] ? 1 : 0);
			this.iZ = (values[2] ? 1 : 0);
			this.iW = (values[3] ? 1 : 0);
		}

		// Token: 0x17000019 RID: 25
		public bool this[int index]
		{
			get
			{
				switch (index)
				{
				case 0:
					return this.X;
				case 1:
					return this.Y;
				case 2:
					return this.Z;
				case 3:
					return this.W;
				default:
					throw new ArgumentOutOfRangeException("index", "Indices for Bool4 run from 0 to 3, inclusive.");
				}
			}
			set
			{
				switch (index)
				{
				case 0:
					this.X = value;
					return;
				case 1:
					this.Y = value;
					return;
				case 2:
					this.Z = value;
					return;
				case 3:
					this.W = value;
					return;
				default:
					throw new ArgumentOutOfRangeException("index", "Indices for Bool4 run from 0 to 3, inclusive.");
				}
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000028A8 File Offset: 0x00000AA8
		public bool[] ToArray()
		{
			return new bool[]
			{
				this.X,
				this.Y,
				this.Z,
				this.W
			};
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000028D4 File Offset: 0x00000AD4
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(Bool4 left, Bool4 right)
		{
			return left.Equals(ref right);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x000028DF File Offset: 0x00000ADF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(Bool4 left, Bool4 right)
		{
			return !left.Equals(ref right);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000028F0 File Offset: 0x00000AF0
		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1} Z:{2} W:{3}", new object[]
			{
				this.X,
				this.Y,
				this.Z,
				this.W
			});
		}

		// Token: 0x0600004E RID: 78 RVA: 0x0000294C File Offset: 0x00000B4C
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format(formatProvider, format, new object[]
			{
				this.X,
				this.Y,
				this.Z,
				this.W
			});
		}

		// Token: 0x0600004F RID: 79 RVA: 0x0000299E File Offset: 0x00000B9E
		public override int GetHashCode()
		{
			return ((this.iX * 397 ^ this.iY) * 397 ^ this.iZ) * 397 ^ this.iW;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000029CD File Offset: 0x00000BCD
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(ref Bool4 other)
		{
			return other.X == this.X && other.Y == this.Y && other.Z == this.Z && other.W == this.W;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002A09 File Offset: 0x00000C09
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(Bool4 other)
		{
			return this.Equals(ref other);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002A14 File Offset: 0x00000C14
		public override bool Equals(object value)
		{
			if (!(value is Bool4))
			{
				return false;
			}
			Bool4 @bool = (Bool4)value;
			return this.Equals(ref @bool);
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002A3A File Offset: 0x00000C3A
		public static implicit operator Bool4(bool[] input)
		{
			return new Bool4(input);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002A42 File Offset: 0x00000C42
		public static implicit operator bool[](Bool4 input)
		{
			return input.ToArray();
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002A4B File Offset: 0x00000C4B
		public unsafe static implicit operator RawBool4(Bool4 value)
		{
			return *(RawBool4*)(&value);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002A55 File Offset: 0x00000C55
		public unsafe static implicit operator Bool4(RawBool4 value)
		{
			return *(Bool4*)(&value);
		}

		// Token: 0x04000009 RID: 9
		public static readonly int SizeInBytes = Utilities.SizeOf<Bool4>();

		// Token: 0x0400000A RID: 10
		public static readonly Bool4 False = default(Bool4);

		// Token: 0x0400000B RID: 11
		public static readonly Bool4 UnitX = new Bool4(true, false, false, false);

		// Token: 0x0400000C RID: 12
		public static readonly Bool4 UnitY = new Bool4(false, true, false, false);

		// Token: 0x0400000D RID: 13
		public static readonly Bool4 UnitZ = new Bool4(false, false, true, false);

		// Token: 0x0400000E RID: 14
		public static readonly Bool4 UnitW = new Bool4(false, false, false, true);

		// Token: 0x0400000F RID: 15
		public static readonly Bool4 One = new Bool4(true, true, true, true);

		// Token: 0x04000010 RID: 16
		internal int iX;

		// Token: 0x04000011 RID: 17
		internal int iY;

		// Token: 0x04000012 RID: 18
		internal int iZ;

		// Token: 0x04000013 RID: 19
		internal int iW;
	}
}
