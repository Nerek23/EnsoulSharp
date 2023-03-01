using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.WIC
{
	// Token: 0x02000072 RID: 114
	[Guid("F928B7B8-2221-40C1-B72E-7E82F1974D1A")]
	public class PlanarBitmapFrameEncode : ComObject
	{
		// Token: 0x0600024E RID: 590 RVA: 0x00002A7F File Offset: 0x00000C7F
		public PlanarBitmapFrameEncode(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600024F RID: 591 RVA: 0x000097B9 File Offset: 0x000079B9
		public new static explicit operator PlanarBitmapFrameEncode(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new PlanarBitmapFrameEncode(nativePtr);
			}
			return null;
		}

		// Token: 0x06000250 RID: 592 RVA: 0x000097D0 File Offset: 0x000079D0
		public unsafe void WritePixels(int lineCount, BitmapPlane[] planesRef, int planes)
		{
			Result result;
			fixed (BitmapPlane[] array = planesRef)
			{
				void* ptr;
				if (planesRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, lineCount, ptr, planes, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000251 RID: 593 RVA: 0x00009824 File Offset: 0x00007A24
		public unsafe void WriteSource(BitmapSource[] planesOut, int planes, RawBox? rcSourceRef)
		{
			IntPtr* ptr = null;
			if (planesOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)planesOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			if (planesOut != null)
			{
				for (int i = 0; i < planesOut.Length; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = CppObject.ToCallbackPtr<BitmapSource>(planesOut[i]);
				}
			}
			RawBox value;
			if (rcSourceRef != null)
			{
				value = rcSourceRef.Value;
			}
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, ptr, planes, (rcSourceRef == null) ? null : (&value), *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000252 RID: 594 RVA: 0x000098B8 File Offset: 0x00007AB8
		public unsafe void WriteSource(ComArray<BitmapSource> planesOut, int planes, RawBox? rcSourceRef)
		{
			RawBox value;
			if (rcSourceRef != null)
			{
				value = rcSourceRef.Value;
			}
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)((planesOut != null) ? planesOut.NativePointer : IntPtr.Zero), planes, (rcSourceRef == null) ? null : (&value), *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000253 RID: 595 RVA: 0x00009928 File Offset: 0x00007B28
		private unsafe void WriteSource(IntPtr planesOut, int planes, IntPtr rcSourceRef)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)planesOut, planes, (void*)rcSourceRef, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
