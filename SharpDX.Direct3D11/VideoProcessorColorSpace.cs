using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000177 RID: 375
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
	public struct VideoProcessorColorSpace
	{
		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000494 RID: 1172 RVA: 0x000116E2 File Offset: 0x0000F8E2
		// (set) Token: 0x06000495 RID: 1173 RVA: 0x000116EF File Offset: 0x0000F8EF
		public bool Usage
		{
			get
			{
				return (this._Usage & 1) != 0;
			}
			set
			{
				this._Usage = ((this._Usage & -2) | ((value ? 1 : 0) & 1));
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000496 RID: 1174 RVA: 0x0001170A File Offset: 0x0000F90A
		// (set) Token: 0x06000497 RID: 1175 RVA: 0x00011719 File Offset: 0x0000F919
		public bool RgbRange
		{
			get
			{
				return (this._RgbRange >> 1 & 1) != 0;
			}
			set
			{
				this._RgbRange = ((this._RgbRange & -3) | ((value ? 1 : 0) & 1) << 1);
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000498 RID: 1176 RVA: 0x00011736 File Offset: 0x0000F936
		// (set) Token: 0x06000499 RID: 1177 RVA: 0x00011745 File Offset: 0x0000F945
		public bool YCbCrMatrix
		{
			get
			{
				return (this._YCbCrMatrix >> 2 & 1) != 0;
			}
			set
			{
				this._YCbCrMatrix = ((this._YCbCrMatrix & -5) | ((value ? 1 : 0) & 1) << 2);
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x0600049A RID: 1178 RVA: 0x00011762 File Offset: 0x0000F962
		// (set) Token: 0x0600049B RID: 1179 RVA: 0x00011771 File Offset: 0x0000F971
		public bool YCbCrXvYCC
		{
			get
			{
				return (this._YCbCrXvYCC >> 3 & 1) != 0;
			}
			set
			{
				this._YCbCrXvYCC = ((this._YCbCrXvYCC & -9) | ((value ? 1 : 0) & 1) << 3);
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x0600049C RID: 1180 RVA: 0x0001178E File Offset: 0x0000F98E
		// (set) Token: 0x0600049D RID: 1181 RVA: 0x0001179A File Offset: 0x0000F99A
		public int NominalRange
		{
			get
			{
				return this._NominalRange >> 4 & 3;
			}
			set
			{
				this._NominalRange = ((this._NominalRange & -49) | (value & 3) << 4);
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x0600049E RID: 1182 RVA: 0x000117B1 File Offset: 0x0000F9B1
		// (set) Token: 0x0600049F RID: 1183 RVA: 0x000117C1 File Offset: 0x0000F9C1
		public int Reserved
		{
			get
			{
				return this._Reserved >> 6 & 67108863;
			}
			set
			{
				this._Reserved = ((this._Reserved & 63) | (value & 67108863) << 6);
			}
		}

		// Token: 0x04000B4A RID: 2890
		[FieldOffset(0)]
		internal int _Usage;

		// Token: 0x04000B4B RID: 2891
		[FieldOffset(0)]
		internal int _RgbRange;

		// Token: 0x04000B4C RID: 2892
		[FieldOffset(0)]
		internal int _YCbCrMatrix;

		// Token: 0x04000B4D RID: 2893
		[FieldOffset(0)]
		internal int _YCbCrXvYCC;

		// Token: 0x04000B4E RID: 2894
		[FieldOffset(0)]
		internal int _NominalRange;

		// Token: 0x04000B4F RID: 2895
		[FieldOffset(0)]
		internal int _Reserved;
	}
}
