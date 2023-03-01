using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DXGI
{
	// Token: 0x0200008F RID: 143
	public struct OutputDescription
	{
		// Token: 0x06000222 RID: 546 RVA: 0x00004A73 File Offset: 0x00002C73
		internal void __MarshalFree(ref OutputDescription.__Native @ref)
		{
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00008800 File Offset: 0x00006A00
		internal unsafe void __MarshalFrom(ref OutputDescription.__Native @ref)
		{
			fixed (char* ptr = &@ref.DeviceName)
			{
				void* value = (void*)ptr;
				this.DeviceName = Utilities.PtrToStringUni((IntPtr)value, 31);
			}
			this.DesktopBounds = @ref.DesktopBounds;
			this.IsAttachedToDesktop = @ref.IsAttachedToDesktop;
			this.Rotation = @ref.Rotation;
			this.MonitorHandle = @ref.MonitorHandle;
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00008860 File Offset: 0x00006A60
		internal unsafe void __MarshalTo(ref OutputDescription.__Native @ref)
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
				@ref.DesktopBounds = this.DesktopBounds;
				@ref.IsAttachedToDesktop = this.IsAttachedToDesktop;
				@ref.Rotation = this.Rotation;
				@ref.MonitorHandle = this.MonitorHandle;
			}
		}

		// Token: 0x04000D5D RID: 3421
		public string DeviceName;

		// Token: 0x04000D5E RID: 3422
		public RawRectangle DesktopBounds;

		// Token: 0x04000D5F RID: 3423
		public RawBool IsAttachedToDesktop;

		// Token: 0x04000D60 RID: 3424
		public DisplayModeRotation Rotation;

		// Token: 0x04000D61 RID: 3425
		public IntPtr MonitorHandle;

		// Token: 0x02000090 RID: 144
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x04000D62 RID: 3426
			public char DeviceName;

			// Token: 0x04000D63 RID: 3427
			public char __DeviceName1;

			// Token: 0x04000D64 RID: 3428
			public char __DeviceName2;

			// Token: 0x04000D65 RID: 3429
			public char __DeviceName3;

			// Token: 0x04000D66 RID: 3430
			public char __DeviceName4;

			// Token: 0x04000D67 RID: 3431
			public char __DeviceName5;

			// Token: 0x04000D68 RID: 3432
			public char __DeviceName6;

			// Token: 0x04000D69 RID: 3433
			public char __DeviceName7;

			// Token: 0x04000D6A RID: 3434
			public char __DeviceName8;

			// Token: 0x04000D6B RID: 3435
			public char __DeviceName9;

			// Token: 0x04000D6C RID: 3436
			public char __DeviceName10;

			// Token: 0x04000D6D RID: 3437
			public char __DeviceName11;

			// Token: 0x04000D6E RID: 3438
			public char __DeviceName12;

			// Token: 0x04000D6F RID: 3439
			public char __DeviceName13;

			// Token: 0x04000D70 RID: 3440
			public char __DeviceName14;

			// Token: 0x04000D71 RID: 3441
			public char __DeviceName15;

			// Token: 0x04000D72 RID: 3442
			public char __DeviceName16;

			// Token: 0x04000D73 RID: 3443
			public char __DeviceName17;

			// Token: 0x04000D74 RID: 3444
			public char __DeviceName18;

			// Token: 0x04000D75 RID: 3445
			public char __DeviceName19;

			// Token: 0x04000D76 RID: 3446
			public char __DeviceName20;

			// Token: 0x04000D77 RID: 3447
			public char __DeviceName21;

			// Token: 0x04000D78 RID: 3448
			public char __DeviceName22;

			// Token: 0x04000D79 RID: 3449
			public char __DeviceName23;

			// Token: 0x04000D7A RID: 3450
			public char __DeviceName24;

			// Token: 0x04000D7B RID: 3451
			public char __DeviceName25;

			// Token: 0x04000D7C RID: 3452
			public char __DeviceName26;

			// Token: 0x04000D7D RID: 3453
			public char __DeviceName27;

			// Token: 0x04000D7E RID: 3454
			public char __DeviceName28;

			// Token: 0x04000D7F RID: 3455
			public char __DeviceName29;

			// Token: 0x04000D80 RID: 3456
			public char __DeviceName30;

			// Token: 0x04000D81 RID: 3457
			public char __DeviceName31;

			// Token: 0x04000D82 RID: 3458
			public RawRectangle DesktopBounds;

			// Token: 0x04000D83 RID: 3459
			public RawBool IsAttachedToDesktop;

			// Token: 0x04000D84 RID: 3460
			public DisplayModeRotation Rotation;

			// Token: 0x04000D85 RID: 3461
			public IntPtr MonitorHandle;
		}
	}
}
