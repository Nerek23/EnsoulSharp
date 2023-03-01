using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DXGI
{
	// Token: 0x02000065 RID: 101
	[Guid("54298223-41e1-4a41-9c08-02e8256864a1")]
	public class ISurfaceImageSourceNativeWithD2D : ComObject
	{
		// Token: 0x060001AA RID: 426 RVA: 0x0000272E File Offset: 0x0000092E
		public ISurfaceImageSourceNativeWithD2D(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001AB RID: 427 RVA: 0x00006E9F File Offset: 0x0000509F
		public new static explicit operator ISurfaceImageSourceNativeWithD2D(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ISurfaceImageSourceNativeWithD2D(nativePtr);
			}
			return null;
		}

		// Token: 0x17000030 RID: 48
		// (set) Token: 0x060001AC RID: 428 RVA: 0x00006EB6 File Offset: 0x000050B6
		public IUnknown Device
		{
			set
			{
				this.SetDevice(value);
			}
		}

		// Token: 0x060001AD RID: 429 RVA: 0x00006EC0 File Offset: 0x000050C0
		internal unsafe void SetDevice(IUnknown device)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IUnknown>(device);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001AE RID: 430 RVA: 0x00006F0C File Offset: 0x0000510C
		public unsafe void BeginDraw(RawRectangle updateRect, Guid iid, out IntPtr updateObject, out RawPoint offset)
		{
			offset = default(RawPoint);
			Result result;
			fixed (RawPoint* ptr = &offset)
			{
				void* ptr2 = (void*)ptr;
				fixed (IntPtr* ptr3 = &updateObject)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &updateRect, &iid, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x060001AF RID: 431 RVA: 0x00006F68 File Offset: 0x00005168
		public unsafe void EndDraw()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x00006FA0 File Offset: 0x000051A0
		public unsafe void SuspendDraw()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x00006FD8 File Offset: 0x000051D8
		public unsafe void ResumeDraw()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
