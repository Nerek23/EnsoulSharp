using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x0200006D RID: 109
	[Guid("068346e8-aaec-4b84-add7-137f513f77a1")]
	public class Output6 : Output5
	{
		// Token: 0x060001CB RID: 459 RVA: 0x00007372 File Offset: 0x00005572
		public Output6(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001CC RID: 460 RVA: 0x0000737B File Offset: 0x0000557B
		public new static explicit operator Output6(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Output6(nativePtr);
			}
			return null;
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060001CD RID: 461 RVA: 0x00007394 File Offset: 0x00005594
		public OutputDescription1 Description1
		{
			get
			{
				OutputDescription1 result;
				this.GetDescription1(out result);
				return result;
			}
		}

		// Token: 0x060001CE RID: 462 RVA: 0x000073AC File Offset: 0x000055AC
		internal unsafe void GetDescription1(out OutputDescription1 descRef)
		{
			OutputDescription1.__Native _Native = default(OutputDescription1.__Native);
			descRef = default(OutputDescription1);
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)27 * (IntPtr)sizeof(void*)));
			descRef.__MarshalFrom(ref _Native);
			result.CheckError();
		}

		// Token: 0x060001CF RID: 463 RVA: 0x00007400 File Offset: 0x00005600
		public unsafe void CheckHardwareCompositionSupport(out int flagsRef)
		{
			Result result;
			fixed (int* ptr = &flagsRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)28 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
