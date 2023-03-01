using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DXGI
{
	// Token: 0x02000091 RID: 145
	public struct OutputDescription1
	{
		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000225 RID: 549 RVA: 0x000088F8 File Offset: 0x00006AF8
		// (set) Token: 0x06000226 RID: 550 RVA: 0x0000891E File Offset: 0x00006B1E
		public float[] RedPrimary
		{
			get
			{
				float[] result;
				if ((result = this._RedPrimary) == null)
				{
					result = (this._RedPrimary = new float[2]);
				}
				return result;
			}
			private set
			{
				this._RedPrimary = value;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000227 RID: 551 RVA: 0x00008928 File Offset: 0x00006B28
		// (set) Token: 0x06000228 RID: 552 RVA: 0x0000894E File Offset: 0x00006B4E
		public float[] GreenPrimary
		{
			get
			{
				float[] result;
				if ((result = this._GreenPrimary) == null)
				{
					result = (this._GreenPrimary = new float[2]);
				}
				return result;
			}
			private set
			{
				this._GreenPrimary = value;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000229 RID: 553 RVA: 0x00008958 File Offset: 0x00006B58
		// (set) Token: 0x0600022A RID: 554 RVA: 0x0000897E File Offset: 0x00006B7E
		public float[] BluePrimary
		{
			get
			{
				float[] result;
				if ((result = this._BluePrimary) == null)
				{
					result = (this._BluePrimary = new float[2]);
				}
				return result;
			}
			private set
			{
				this._BluePrimary = value;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x0600022B RID: 555 RVA: 0x00008988 File Offset: 0x00006B88
		// (set) Token: 0x0600022C RID: 556 RVA: 0x000089AE File Offset: 0x00006BAE
		public float[] WhitePoint
		{
			get
			{
				float[] result;
				if ((result = this._WhitePoint) == null)
				{
					result = (this._WhitePoint = new float[2]);
				}
				return result;
			}
			private set
			{
				this._WhitePoint = value;
			}
		}

		// Token: 0x0600022D RID: 557 RVA: 0x00004A73 File Offset: 0x00002C73
		internal void __MarshalFree(ref OutputDescription1.__Native @ref)
		{
		}

		// Token: 0x0600022E RID: 558 RVA: 0x000089B8 File Offset: 0x00006BB8
		internal unsafe void __MarshalFrom(ref OutputDescription1.__Native @ref)
		{
			fixed (char* ptr = &@ref.DeviceName)
			{
				void* value = (void*)ptr;
				this.DeviceName = Utilities.PtrToStringUni((IntPtr)value, 31);
			}
			this.DesktopCoordinates = @ref.DesktopCoordinates;
			this.AttachedToDesktop = @ref.AttachedToDesktop;
			this.Rotation = @ref.Rotation;
			this.Monitor = @ref.Monitor;
			this.BitsPerColor = @ref.BitsPerColor;
			this.ColorSpace = @ref.ColorSpace;
			fixed (float* ptr2 = &this.RedPrimary[0])
			{
				void* value2 = (void*)ptr2;
				fixed (float* ptr3 = &@ref.RedPrimary)
				{
					void* value3 = (void*)ptr3;
					Utilities.CopyMemory((IntPtr)value2, (IntPtr)value3, 8);
					ptr2 = null;
				}
				fixed (float* ptr3 = &this.GreenPrimary[0])
				{
					void* value4 = (void*)ptr3;
					fixed (float* ptr2 = &@ref.GreenPrimary)
					{
						void* value5 = (void*)ptr2;
						Utilities.CopyMemory((IntPtr)value4, (IntPtr)value5, 8);
						ptr3 = null;
					}
					fixed (float* ptr2 = &this.BluePrimary[0])
					{
						void* value6 = (void*)ptr2;
						fixed (float* ptr3 = &@ref.BluePrimary)
						{
							void* value7 = (void*)ptr3;
							Utilities.CopyMemory((IntPtr)value6, (IntPtr)value7, 8);
							ptr2 = null;
						}
						fixed (float* ptr3 = &this.WhitePoint[0])
						{
							void* value8 = (void*)ptr3;
							fixed (float* ptr2 = &@ref.WhitePoint)
							{
								void* value9 = (void*)ptr2;
								Utilities.CopyMemory((IntPtr)value8, (IntPtr)value9, 8);
								ptr3 = null;
							}
							this.MinLuminance = @ref.MinLuminance;
							this.MaxLuminance = @ref.MaxLuminance;
							this.MaxFullFrameLuminance = @ref.MaxFullFrameLuminance;
						}
					}
				}
			}
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00008B40 File Offset: 0x00006D40
		internal unsafe void __MarshalTo(ref OutputDescription1.__Native @ref)
		{
			fixed (string text = this.DeviceName)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				fixed (char* ptr2 = &@ref.DeviceName)
				{
					char* ptr3 = ptr2;
					string deviceName = this.DeviceName;
					int num = Math.Min(((deviceName != null) ? deviceName.Length : 0) * 2, 62);
					Utilities.CopyMemory((IntPtr)((void*)ptr3), (IntPtr)((void*)ptr), num);
					ptr3[num] = '\0';
					text = null;
				}
				@ref.DesktopCoordinates = this.DesktopCoordinates;
				@ref.AttachedToDesktop = this.AttachedToDesktop;
				@ref.Rotation = this.Rotation;
				@ref.Monitor = this.Monitor;
				@ref.BitsPerColor = this.BitsPerColor;
				@ref.ColorSpace = this.ColorSpace;
				fixed (float* ptr4 = &this.RedPrimary[0])
				{
					void* value = (void*)ptr4;
					fixed (float* ptr5 = &@ref.RedPrimary)
					{
						void* value2 = (void*)ptr5;
						Utilities.CopyMemory((IntPtr)value2, (IntPtr)value, 8);
						ptr4 = null;
					}
					fixed (float* ptr5 = &this.GreenPrimary[0])
					{
						void* value3 = (void*)ptr5;
						fixed (float* ptr4 = &@ref.GreenPrimary)
						{
							void* value4 = (void*)ptr4;
							Utilities.CopyMemory((IntPtr)value4, (IntPtr)value3, 8);
							ptr5 = null;
						}
						fixed (float* ptr4 = &this.BluePrimary[0])
						{
							void* value5 = (void*)ptr4;
							fixed (float* ptr5 = &@ref.BluePrimary)
							{
								void* value6 = (void*)ptr5;
								Utilities.CopyMemory((IntPtr)value6, (IntPtr)value5, 8);
								ptr4 = null;
							}
							fixed (float* ptr5 = &this.WhitePoint[0])
							{
								void* value7 = (void*)ptr5;
								fixed (float* ptr4 = &@ref.WhitePoint)
								{
									void* value8 = (void*)ptr4;
									Utilities.CopyMemory((IntPtr)value8, (IntPtr)value7, 8);
									ptr5 = null;
								}
								@ref.MinLuminance = this.MinLuminance;
								@ref.MaxLuminance = this.MaxLuminance;
								@ref.MaxFullFrameLuminance = this.MaxFullFrameLuminance;
							}
						}
					}
				}
			}
		}

		// Token: 0x04000D86 RID: 3462
		public string DeviceName;

		// Token: 0x04000D87 RID: 3463
		public RawRectangle DesktopCoordinates;

		// Token: 0x04000D88 RID: 3464
		public RawBool AttachedToDesktop;

		// Token: 0x04000D89 RID: 3465
		public DisplayModeRotation Rotation;

		// Token: 0x04000D8A RID: 3466
		public IntPtr Monitor;

		// Token: 0x04000D8B RID: 3467
		public int BitsPerColor;

		// Token: 0x04000D8C RID: 3468
		public ColorSpaceType ColorSpace;

		// Token: 0x04000D8D RID: 3469
		internal float[] _RedPrimary;

		// Token: 0x04000D8E RID: 3470
		internal float[] _GreenPrimary;

		// Token: 0x04000D8F RID: 3471
		internal float[] _BluePrimary;

		// Token: 0x04000D90 RID: 3472
		internal float[] _WhitePoint;

		// Token: 0x04000D91 RID: 3473
		public float MinLuminance;

		// Token: 0x04000D92 RID: 3474
		public float MaxLuminance;

		// Token: 0x04000D93 RID: 3475
		public float MaxFullFrameLuminance;

		// Token: 0x02000092 RID: 146
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x04000D94 RID: 3476
			public char DeviceName;

			// Token: 0x04000D95 RID: 3477
			public char __DeviceName1;

			// Token: 0x04000D96 RID: 3478
			public char __DeviceName2;

			// Token: 0x04000D97 RID: 3479
			public char __DeviceName3;

			// Token: 0x04000D98 RID: 3480
			public char __DeviceName4;

			// Token: 0x04000D99 RID: 3481
			public char __DeviceName5;

			// Token: 0x04000D9A RID: 3482
			public char __DeviceName6;

			// Token: 0x04000D9B RID: 3483
			public char __DeviceName7;

			// Token: 0x04000D9C RID: 3484
			public char __DeviceName8;

			// Token: 0x04000D9D RID: 3485
			public char __DeviceName9;

			// Token: 0x04000D9E RID: 3486
			public char __DeviceName10;

			// Token: 0x04000D9F RID: 3487
			public char __DeviceName11;

			// Token: 0x04000DA0 RID: 3488
			public char __DeviceName12;

			// Token: 0x04000DA1 RID: 3489
			public char __DeviceName13;

			// Token: 0x04000DA2 RID: 3490
			public char __DeviceName14;

			// Token: 0x04000DA3 RID: 3491
			public char __DeviceName15;

			// Token: 0x04000DA4 RID: 3492
			public char __DeviceName16;

			// Token: 0x04000DA5 RID: 3493
			public char __DeviceName17;

			// Token: 0x04000DA6 RID: 3494
			public char __DeviceName18;

			// Token: 0x04000DA7 RID: 3495
			public char __DeviceName19;

			// Token: 0x04000DA8 RID: 3496
			public char __DeviceName20;

			// Token: 0x04000DA9 RID: 3497
			public char __DeviceName21;

			// Token: 0x04000DAA RID: 3498
			public char __DeviceName22;

			// Token: 0x04000DAB RID: 3499
			public char __DeviceName23;

			// Token: 0x04000DAC RID: 3500
			public char __DeviceName24;

			// Token: 0x04000DAD RID: 3501
			public char __DeviceName25;

			// Token: 0x04000DAE RID: 3502
			public char __DeviceName26;

			// Token: 0x04000DAF RID: 3503
			public char __DeviceName27;

			// Token: 0x04000DB0 RID: 3504
			public char __DeviceName28;

			// Token: 0x04000DB1 RID: 3505
			public char __DeviceName29;

			// Token: 0x04000DB2 RID: 3506
			public char __DeviceName30;

			// Token: 0x04000DB3 RID: 3507
			public char __DeviceName31;

			// Token: 0x04000DB4 RID: 3508
			public RawRectangle DesktopCoordinates;

			// Token: 0x04000DB5 RID: 3509
			public RawBool AttachedToDesktop;

			// Token: 0x04000DB6 RID: 3510
			public DisplayModeRotation Rotation;

			// Token: 0x04000DB7 RID: 3511
			public IntPtr Monitor;

			// Token: 0x04000DB8 RID: 3512
			public int BitsPerColor;

			// Token: 0x04000DB9 RID: 3513
			public ColorSpaceType ColorSpace;

			// Token: 0x04000DBA RID: 3514
			public float RedPrimary;

			// Token: 0x04000DBB RID: 3515
			public float __RedPrimary1;

			// Token: 0x04000DBC RID: 3516
			public float GreenPrimary;

			// Token: 0x04000DBD RID: 3517
			public float __GreenPrimary1;

			// Token: 0x04000DBE RID: 3518
			public float BluePrimary;

			// Token: 0x04000DBF RID: 3519
			public float __BluePrimary1;

			// Token: 0x04000DC0 RID: 3520
			public float WhitePoint;

			// Token: 0x04000DC1 RID: 3521
			public float __WhitePoint1;

			// Token: 0x04000DC2 RID: 3522
			public float MinLuminance;

			// Token: 0x04000DC3 RID: 3523
			public float MaxLuminance;

			// Token: 0x04000DC4 RID: 3524
			public float MaxFullFrameLuminance;
		}
	}
}
