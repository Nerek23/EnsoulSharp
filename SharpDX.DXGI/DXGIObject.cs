using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x0200000B RID: 11
	[Guid("aec22fb8-76f3-4639-9be0-28eb43a67a2e")]
	public class DXGIObject : ComObject
	{
		// Token: 0x06000033 RID: 51 RVA: 0x00002830 File Offset: 0x00000A30
		public T GetParent<T>() where T : ComObject
		{
			IntPtr comObjectPtr;
			this.GetParent(Utilities.GetGuidFromType(typeof(T)), out comObjectPtr);
			return CppObject.FromPointer<T>(comObjectPtr);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x0000272E File Offset: 0x0000092E
		public DXGIObject(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000035 RID: 53 RVA: 0x0000285A File Offset: 0x00000A5A
		public new static explicit operator DXGIObject(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DXGIObject(nativePtr);
			}
			return null;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002874 File Offset: 0x00000A74
		public unsafe void SetPrivateData(Guid name, int dataSize, IntPtr dataRef)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, &name, dataSize, (void*)dataRef, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000028B8 File Offset: 0x00000AB8
		public unsafe void SetPrivateDataInterface(Guid name, IUnknown unknownRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IUnknown>(unknownRef);
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &name, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002908 File Offset: 0x00000B08
		public unsafe Result GetPrivateData(Guid name, ref int dataSizeRef, IntPtr dataRef)
		{
			Result result;
			fixed (int* ptr = &dataSizeRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &name, ptr2, (void*)dataRef, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			}
			return result;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x0000294C File Offset: 0x00000B4C
		public unsafe void GetParent(Guid riid, out IntPtr parentOut)
		{
			Result result;
			fixed (IntPtr* ptr = &parentOut)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &riid, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
