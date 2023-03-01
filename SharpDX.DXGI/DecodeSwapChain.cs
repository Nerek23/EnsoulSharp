using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DXGI
{
	// Token: 0x0200005A RID: 90
	[Guid("2633066b-4514-4c7a-8fd8-12ea98059d18")]
	public class DecodeSwapChain : ComObject
	{
		// Token: 0x06000165 RID: 357 RVA: 0x0000272E File Offset: 0x0000092E
		public DecodeSwapChain(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00006212 File Offset: 0x00004412
		public new static explicit operator DecodeSwapChain(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DecodeSwapChain(nativePtr);
			}
			return null;
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000167 RID: 359 RVA: 0x0000622C File Offset: 0x0000442C
		// (set) Token: 0x06000168 RID: 360 RVA: 0x00006242 File Offset: 0x00004442
		public RawRectangle SourceRect
		{
			get
			{
				RawRectangle result;
				this.GetSourceRect(out result);
				return result;
			}
			set
			{
				this.SetSourceRect(value);
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000169 RID: 361 RVA: 0x0000624C File Offset: 0x0000444C
		// (set) Token: 0x0600016A RID: 362 RVA: 0x00006262 File Offset: 0x00004462
		public RawRectangle TargetRect
		{
			get
			{
				RawRectangle result;
				this.GetTargetRect(out result);
				return result;
			}
			set
			{
				this.SetTargetRect(value);
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600016B RID: 363 RVA: 0x0000626B File Offset: 0x0000446B
		// (set) Token: 0x0600016C RID: 364 RVA: 0x00006273 File Offset: 0x00004473
		public MultiplaneOverlayYCbCrFlags ColorSpace
		{
			get
			{
				return this.GetColorSpace();
			}
			set
			{
				this.SetColorSpace(value);
			}
		}

		// Token: 0x0600016D RID: 365 RVA: 0x0000627C File Offset: 0x0000447C
		public unsafe void PresentBuffer(int bufferToPresent, int syncInterval, int flags)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32), this._nativePointer, bufferToPresent, syncInterval, flags, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600016E RID: 366 RVA: 0x000062B8 File Offset: 0x000044B8
		internal unsafe void SetSourceRect(RawRectangle rectRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &rectRef, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600016F RID: 367 RVA: 0x000062F4 File Offset: 0x000044F4
		internal unsafe void SetTargetRect(RawRectangle rectRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &rectRef, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00006330 File Offset: 0x00004530
		public unsafe void SetDestSize(int width, int height)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32), this._nativePointer, width, height, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000171 RID: 369 RVA: 0x0000636C File Offset: 0x0000456C
		internal unsafe void GetSourceRect(out RawRectangle rectRef)
		{
			rectRef = default(RawRectangle);
			Result result;
			fixed (RawRectangle* ptr = &rectRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000172 RID: 370 RVA: 0x000063B4 File Offset: 0x000045B4
		internal unsafe void GetTargetRect(out RawRectangle rectRef)
		{
			rectRef = default(RawRectangle);
			Result result;
			fixed (RawRectangle* ptr = &rectRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000173 RID: 371 RVA: 0x000063FC File Offset: 0x000045FC
		public unsafe void GetDestSize(out int widthRef, out int heightRef)
		{
			Result result;
			fixed (int* ptr = &heightRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (int* ptr3 = &widthRef)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x06000174 RID: 372 RVA: 0x0000644C File Offset: 0x0000464C
		internal unsafe void SetColorSpace(MultiplaneOverlayYCbCrFlags colorSpace)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, colorSpace, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00006485 File Offset: 0x00004685
		internal unsafe MultiplaneOverlayYCbCrFlags GetColorSpace()
		{
			return calli(SharpDX.DXGI.MultiplaneOverlayYCbCrFlags(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
		}
	}
}
