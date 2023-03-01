using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x0200006C RID: 108
	[Guid("80A07424-AB52-42EB-833C-0C42FD282D98")]
	public class Output5 : Output4
	{
		// Token: 0x060001C8 RID: 456 RVA: 0x000072BD File Offset: 0x000054BD
		public Output5(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x000072C6 File Offset: 0x000054C6
		public new static explicit operator Output5(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Output5(nativePtr);
			}
			return null;
		}

		// Token: 0x060001CA RID: 458 RVA: 0x000072E0 File Offset: 0x000054E0
		public unsafe OutputDuplication DuplicateOutput1(IUnknown deviceRef, int flags, int supportedFormatsCount, Format[] supportedFormatsRef)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IUnknown>(deviceRef);
			Result result;
			fixed (Format[] array = supportedFormatsRef)
			{
				void* ptr;
				if (supportedFormatsRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, (void*)value, flags, supportedFormatsCount, ptr, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)26 * (IntPtr)sizeof(void*)));
			}
			OutputDuplication result2;
			if (zero != IntPtr.Zero)
			{
				result2 = new OutputDuplication(zero);
			}
			else
			{
				result2 = null;
			}
			result.CheckError();
			return result2;
		}
	}
}
