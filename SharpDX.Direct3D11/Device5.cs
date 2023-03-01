using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000017 RID: 23
	[Guid("8ffde202-a0e7-45df-9e01-e837801b5ea0")]
	public class Device5 : Device4
	{
		// Token: 0x060000D0 RID: 208 RVA: 0x0000512C File Offset: 0x0000332C
		public Fence OpenSharedFence(IntPtr resourceHandle)
		{
			IntPtr comObjectPtr;
			this.OpenSharedFence(resourceHandle, Utilities.GetGuidFromType(typeof(Fence)), out comObjectPtr);
			return CppObject.FromPointer<Fence>(comObjectPtr);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00005157 File Offset: 0x00003357
		public Device5(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00005160 File Offset: 0x00003360
		public new static explicit operator Device5(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Device5(nativePtr);
			}
			return null;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00005178 File Offset: 0x00003378
		internal unsafe void OpenSharedFence(IntPtr hFence, Guid returnedInterface, out IntPtr fenceOut)
		{
			Result result;
			fixed (IntPtr* ptr = &fenceOut)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)hFence, &returnedInterface, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)67 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000051C4 File Offset: 0x000033C4
		internal unsafe void CreateFence(long initialValue, FenceFlags flags, Guid returnedInterface, Fence fenceOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int64,System.Int32,System.Void*,System.Void*), this._nativePointer, initialValue, flags, &returnedInterface, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)68 * (IntPtr)sizeof(void*)));
			fenceOut.NativePointer = zero;
			result.CheckError();
		}
	}
}
