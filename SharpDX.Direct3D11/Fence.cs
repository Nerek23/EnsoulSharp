using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Win32;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000026 RID: 38
	[Guid("affde9d1-1df7-4bb7-8a34-0f46251dab80")]
	public class Fence : DeviceChild
	{
		// Token: 0x06000224 RID: 548 RVA: 0x00009BAE File Offset: 0x00007DAE
		public Fence(Device5 device, long initialValue, FenceFlags flags) : base(IntPtr.Zero)
		{
			device.CreateFence(initialValue, flags, Utilities.GetGuidFromType(typeof(Fence)), this);
		}

		// Token: 0x06000225 RID: 549 RVA: 0x00002075 File Offset: 0x00000275
		public Fence(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000226 RID: 550 RVA: 0x00009BD3 File Offset: 0x00007DD3
		public new static explicit operator Fence(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Fence(nativePtr);
			}
			return null;
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000227 RID: 551 RVA: 0x00009BEA File Offset: 0x00007DEA
		public long CompletedValue
		{
			get
			{
				return this.GetCompletedValue();
			}
		}

		// Token: 0x06000228 RID: 552 RVA: 0x00009BF4 File Offset: 0x00007DF4
		public unsafe IntPtr CreateSharedHandle(SecurityAttributes? attributesRef, int dwAccess, string lpName)
		{
			SecurityAttributes value;
			if (attributesRef != null)
			{
				value = attributesRef.Value;
			}
			IntPtr result2;
			Result result;
			fixed (string text = lpName)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, (attributesRef == null) ? null : (&value), dwAccess, ptr, &result2, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00009C67 File Offset: 0x00007E67
		internal unsafe long GetCompletedValue()
		{
			return calli(System.Int64(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600022A RID: 554 RVA: 0x00009C88 File Offset: 0x00007E88
		public unsafe void SetEventOnCompletion(long value, IntPtr hEvent)
		{
			calli(System.Int32(System.Void*,System.Int64,System.Void*), this._nativePointer, value, (void*)hEvent, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
