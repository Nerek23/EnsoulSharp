using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x0200008B RID: 139
	public struct JpegQuantizationTable
	{
		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600021D RID: 541 RVA: 0x00008750 File Offset: 0x00006950
		// (set) Token: 0x0600021E RID: 542 RVA: 0x00008777 File Offset: 0x00006977
		public byte[] Elements
		{
			get
			{
				byte[] result;
				if ((result = this._Elements) == null)
				{
					result = (this._Elements = new byte[64]);
				}
				return result;
			}
			private set
			{
				this._Elements = value;
			}
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00004A73 File Offset: 0x00002C73
		internal void __MarshalFree(ref JpegQuantizationTable.__Native @ref)
		{
		}

		// Token: 0x06000220 RID: 544 RVA: 0x00008780 File Offset: 0x00006980
		internal unsafe void __MarshalFrom(ref JpegQuantizationTable.__Native @ref)
		{
			fixed (byte* ptr = &this.Elements[0])
			{
				void* value = (void*)ptr;
				fixed (byte* ptr2 = &@ref.Elements)
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value, (IntPtr)value2, 64);
					ptr = null;
				}
			}
		}

		// Token: 0x06000221 RID: 545 RVA: 0x000087C0 File Offset: 0x000069C0
		internal unsafe void __MarshalTo(ref JpegQuantizationTable.__Native @ref)
		{
			fixed (byte* ptr = &this.Elements[0])
			{
				void* value = (void*)ptr;
				fixed (byte* ptr2 = &@ref.Elements)
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value2, (IntPtr)value, 64);
					ptr = null;
				}
			}
		}

		// Token: 0x04000D13 RID: 3347
		internal byte[] _Elements;

		// Token: 0x0200008C RID: 140
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x04000D14 RID: 3348
			public byte Elements;

			// Token: 0x04000D15 RID: 3349
			public byte __Elements1;

			// Token: 0x04000D16 RID: 3350
			public byte __Elements2;

			// Token: 0x04000D17 RID: 3351
			public byte __Elements3;

			// Token: 0x04000D18 RID: 3352
			public byte __Elements4;

			// Token: 0x04000D19 RID: 3353
			public byte __Elements5;

			// Token: 0x04000D1A RID: 3354
			public byte __Elements6;

			// Token: 0x04000D1B RID: 3355
			public byte __Elements7;

			// Token: 0x04000D1C RID: 3356
			public byte __Elements8;

			// Token: 0x04000D1D RID: 3357
			public byte __Elements9;

			// Token: 0x04000D1E RID: 3358
			public byte __Elements10;

			// Token: 0x04000D1F RID: 3359
			public byte __Elements11;

			// Token: 0x04000D20 RID: 3360
			public byte __Elements12;

			// Token: 0x04000D21 RID: 3361
			public byte __Elements13;

			// Token: 0x04000D22 RID: 3362
			public byte __Elements14;

			// Token: 0x04000D23 RID: 3363
			public byte __Elements15;

			// Token: 0x04000D24 RID: 3364
			public byte __Elements16;

			// Token: 0x04000D25 RID: 3365
			public byte __Elements17;

			// Token: 0x04000D26 RID: 3366
			public byte __Elements18;

			// Token: 0x04000D27 RID: 3367
			public byte __Elements19;

			// Token: 0x04000D28 RID: 3368
			public byte __Elements20;

			// Token: 0x04000D29 RID: 3369
			public byte __Elements21;

			// Token: 0x04000D2A RID: 3370
			public byte __Elements22;

			// Token: 0x04000D2B RID: 3371
			public byte __Elements23;

			// Token: 0x04000D2C RID: 3372
			public byte __Elements24;

			// Token: 0x04000D2D RID: 3373
			public byte __Elements25;

			// Token: 0x04000D2E RID: 3374
			public byte __Elements26;

			// Token: 0x04000D2F RID: 3375
			public byte __Elements27;

			// Token: 0x04000D30 RID: 3376
			public byte __Elements28;

			// Token: 0x04000D31 RID: 3377
			public byte __Elements29;

			// Token: 0x04000D32 RID: 3378
			public byte __Elements30;

			// Token: 0x04000D33 RID: 3379
			public byte __Elements31;

			// Token: 0x04000D34 RID: 3380
			public byte __Elements32;

			// Token: 0x04000D35 RID: 3381
			public byte __Elements33;

			// Token: 0x04000D36 RID: 3382
			public byte __Elements34;

			// Token: 0x04000D37 RID: 3383
			public byte __Elements35;

			// Token: 0x04000D38 RID: 3384
			public byte __Elements36;

			// Token: 0x04000D39 RID: 3385
			public byte __Elements37;

			// Token: 0x04000D3A RID: 3386
			public byte __Elements38;

			// Token: 0x04000D3B RID: 3387
			public byte __Elements39;

			// Token: 0x04000D3C RID: 3388
			public byte __Elements40;

			// Token: 0x04000D3D RID: 3389
			public byte __Elements41;

			// Token: 0x04000D3E RID: 3390
			public byte __Elements42;

			// Token: 0x04000D3F RID: 3391
			public byte __Elements43;

			// Token: 0x04000D40 RID: 3392
			public byte __Elements44;

			// Token: 0x04000D41 RID: 3393
			public byte __Elements45;

			// Token: 0x04000D42 RID: 3394
			public byte __Elements46;

			// Token: 0x04000D43 RID: 3395
			public byte __Elements47;

			// Token: 0x04000D44 RID: 3396
			public byte __Elements48;

			// Token: 0x04000D45 RID: 3397
			public byte __Elements49;

			// Token: 0x04000D46 RID: 3398
			public byte __Elements50;

			// Token: 0x04000D47 RID: 3399
			public byte __Elements51;

			// Token: 0x04000D48 RID: 3400
			public byte __Elements52;

			// Token: 0x04000D49 RID: 3401
			public byte __Elements53;

			// Token: 0x04000D4A RID: 3402
			public byte __Elements54;

			// Token: 0x04000D4B RID: 3403
			public byte __Elements55;

			// Token: 0x04000D4C RID: 3404
			public byte __Elements56;

			// Token: 0x04000D4D RID: 3405
			public byte __Elements57;

			// Token: 0x04000D4E RID: 3406
			public byte __Elements58;

			// Token: 0x04000D4F RID: 3407
			public byte __Elements59;

			// Token: 0x04000D50 RID: 3408
			public byte __Elements60;

			// Token: 0x04000D51 RID: 3409
			public byte __Elements61;

			// Token: 0x04000D52 RID: 3410
			public byte __Elements62;

			// Token: 0x04000D53 RID: 3411
			public byte __Elements63;
		}
	}
}
