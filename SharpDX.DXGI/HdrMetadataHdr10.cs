using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000081 RID: 129
	public struct HdrMetadataHdr10
	{
		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000201 RID: 513 RVA: 0x000080F0 File Offset: 0x000062F0
		// (set) Token: 0x06000202 RID: 514 RVA: 0x00008116 File Offset: 0x00006316
		public short[] RedPrimary
		{
			get
			{
				short[] result;
				if ((result = this._RedPrimary) == null)
				{
					result = (this._RedPrimary = new short[2]);
				}
				return result;
			}
			private set
			{
				this._RedPrimary = value;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000203 RID: 515 RVA: 0x00008120 File Offset: 0x00006320
		// (set) Token: 0x06000204 RID: 516 RVA: 0x00008146 File Offset: 0x00006346
		public short[] GreenPrimary
		{
			get
			{
				short[] result;
				if ((result = this._GreenPrimary) == null)
				{
					result = (this._GreenPrimary = new short[2]);
				}
				return result;
			}
			private set
			{
				this._GreenPrimary = value;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000205 RID: 517 RVA: 0x00008150 File Offset: 0x00006350
		// (set) Token: 0x06000206 RID: 518 RVA: 0x00008176 File Offset: 0x00006376
		public short[] BluePrimary
		{
			get
			{
				short[] result;
				if ((result = this._BluePrimary) == null)
				{
					result = (this._BluePrimary = new short[2]);
				}
				return result;
			}
			private set
			{
				this._BluePrimary = value;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000207 RID: 519 RVA: 0x00008180 File Offset: 0x00006380
		// (set) Token: 0x06000208 RID: 520 RVA: 0x000081A6 File Offset: 0x000063A6
		public short[] WhitePoint
		{
			get
			{
				short[] result;
				if ((result = this._WhitePoint) == null)
				{
					result = (this._WhitePoint = new short[2]);
				}
				return result;
			}
			private set
			{
				this._WhitePoint = value;
			}
		}

		// Token: 0x06000209 RID: 521 RVA: 0x00004A73 File Offset: 0x00002C73
		internal void __MarshalFree(ref HdrMetadataHdr10.__Native @ref)
		{
		}

		// Token: 0x0600020A RID: 522 RVA: 0x000081B0 File Offset: 0x000063B0
		internal unsafe void __MarshalFrom(ref HdrMetadataHdr10.__Native @ref)
		{
			fixed (short* ptr = &this.RedPrimary[0])
			{
				void* value = (void*)ptr;
				fixed (short* ptr2 = &@ref.RedPrimary)
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value, (IntPtr)value2, 4);
					ptr = null;
				}
				fixed (short* ptr2 = &this.GreenPrimary[0])
				{
					void* value3 = (void*)ptr2;
					fixed (short* ptr = &@ref.GreenPrimary)
					{
						void* value4 = (void*)ptr;
						Utilities.CopyMemory((IntPtr)value3, (IntPtr)value4, 4);
						ptr2 = null;
					}
					fixed (short* ptr = &this.BluePrimary[0])
					{
						void* value5 = (void*)ptr;
						fixed (short* ptr2 = &@ref.BluePrimary)
						{
							void* value6 = (void*)ptr2;
							Utilities.CopyMemory((IntPtr)value5, (IntPtr)value6, 4);
							ptr = null;
						}
						fixed (short* ptr2 = &this.WhitePoint[0])
						{
							void* value7 = (void*)ptr2;
							fixed (short* ptr = &@ref.WhitePoint)
							{
								void* value8 = (void*)ptr;
								Utilities.CopyMemory((IntPtr)value7, (IntPtr)value8, 4);
								ptr2 = null;
							}
							this.MaxMasteringLuminance = @ref.MaxMasteringLuminance;
							this.MinMasteringLuminance = @ref.MinMasteringLuminance;
							this.MaxContentLightLevel = @ref.MaxContentLightLevel;
							this.MaxFrameAverageLightLevel = @ref.MaxFrameAverageLightLevel;
						}
					}
				}
			}
		}

		// Token: 0x0600020B RID: 523 RVA: 0x000082C4 File Offset: 0x000064C4
		internal unsafe void __MarshalTo(ref HdrMetadataHdr10.__Native @ref)
		{
			fixed (short* ptr = &this.RedPrimary[0])
			{
				void* value = (void*)ptr;
				fixed (short* ptr2 = &@ref.RedPrimary)
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value2, (IntPtr)value, 4);
					ptr = null;
				}
				fixed (short* ptr2 = &this.GreenPrimary[0])
				{
					void* value3 = (void*)ptr2;
					fixed (short* ptr = &@ref.GreenPrimary)
					{
						void* value4 = (void*)ptr;
						Utilities.CopyMemory((IntPtr)value4, (IntPtr)value3, 4);
						ptr2 = null;
					}
					fixed (short* ptr = &this.BluePrimary[0])
					{
						void* value5 = (void*)ptr;
						fixed (short* ptr2 = &@ref.BluePrimary)
						{
							void* value6 = (void*)ptr2;
							Utilities.CopyMemory((IntPtr)value6, (IntPtr)value5, 4);
							ptr = null;
						}
						fixed (short* ptr2 = &this.WhitePoint[0])
						{
							void* value7 = (void*)ptr2;
							fixed (short* ptr = &@ref.WhitePoint)
							{
								void* value8 = (void*)ptr;
								Utilities.CopyMemory((IntPtr)value8, (IntPtr)value7, 4);
								ptr2 = null;
							}
							@ref.MaxMasteringLuminance = this.MaxMasteringLuminance;
							@ref.MinMasteringLuminance = this.MinMasteringLuminance;
							@ref.MaxContentLightLevel = this.MaxContentLightLevel;
							@ref.MaxFrameAverageLightLevel = this.MaxFrameAverageLightLevel;
						}
					}
				}
			}
		}

		// Token: 0x04000C1D RID: 3101
		internal short[] _RedPrimary;

		// Token: 0x04000C1E RID: 3102
		internal short[] _GreenPrimary;

		// Token: 0x04000C1F RID: 3103
		internal short[] _BluePrimary;

		// Token: 0x04000C20 RID: 3104
		internal short[] _WhitePoint;

		// Token: 0x04000C21 RID: 3105
		public int MaxMasteringLuminance;

		// Token: 0x04000C22 RID: 3106
		public int MinMasteringLuminance;

		// Token: 0x04000C23 RID: 3107
		public short MaxContentLightLevel;

		// Token: 0x04000C24 RID: 3108
		public short MaxFrameAverageLightLevel;

		// Token: 0x02000082 RID: 130
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x04000C25 RID: 3109
			public short RedPrimary;

			// Token: 0x04000C26 RID: 3110
			public short __RedPrimary1;

			// Token: 0x04000C27 RID: 3111
			public short GreenPrimary;

			// Token: 0x04000C28 RID: 3112
			public short __GreenPrimary1;

			// Token: 0x04000C29 RID: 3113
			public short BluePrimary;

			// Token: 0x04000C2A RID: 3114
			public short __BluePrimary1;

			// Token: 0x04000C2B RID: 3115
			public short WhitePoint;

			// Token: 0x04000C2C RID: 3116
			public short __WhitePoint1;

			// Token: 0x04000C2D RID: 3117
			public int MaxMasteringLuminance;

			// Token: 0x04000C2E RID: 3118
			public int MinMasteringLuminance;

			// Token: 0x04000C2F RID: 3119
			public short MaxContentLightLevel;

			// Token: 0x04000C30 RID: 3120
			public short MaxFrameAverageLightLevel;
		}
	}
}
