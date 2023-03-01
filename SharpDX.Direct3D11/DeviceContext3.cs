using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000023 RID: 35
	[Guid("b4e3c01d-e79e-4637-91b2-510e9f4c9b8f")]
	public class DeviceContext3 : DeviceContext2
	{
		// Token: 0x06000207 RID: 519 RVA: 0x000097C1 File Offset: 0x000079C1
		public DeviceContext3(Device3 device) : base(IntPtr.Zero)
		{
			device.CreateDeferredContext3(0, this);
		}

		// Token: 0x06000208 RID: 520 RVA: 0x000097D6 File Offset: 0x000079D6
		public DeviceContext3(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000209 RID: 521 RVA: 0x000097DF File Offset: 0x000079DF
		public new static explicit operator DeviceContext3(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DeviceContext3(nativePtr);
			}
			return null;
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600020A RID: 522 RVA: 0x000097F8 File Offset: 0x000079F8
		// (set) Token: 0x0600020B RID: 523 RVA: 0x0000980E File Offset: 0x00007A0E
		public RawBool HardwareProtectionState
		{
			get
			{
				RawBool result;
				this.GetHardwareProtectionState(out result);
				return result;
			}
			set
			{
				this.SetHardwareProtectionState(value);
			}
		}

		// Token: 0x0600020C RID: 524 RVA: 0x00009817 File Offset: 0x00007A17
		public unsafe void Flush1(ContextType contextType, IntPtr hEvent)
		{
			calli(System.Void(System.Void*,System.Int32,System.Void*), this._nativePointer, contextType, (void*)hEvent, *(*(IntPtr*)this._nativePointer + (IntPtr)144 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600020D RID: 525 RVA: 0x00009841 File Offset: 0x00007A41
		internal unsafe void SetHardwareProtectionState(RawBool hwProtectionEnable)
		{
			calli(System.Void(System.Void*,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, hwProtectionEnable, *(*(IntPtr*)this._nativePointer + (IntPtr)145 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600020E RID: 526 RVA: 0x00009868 File Offset: 0x00007A68
		internal unsafe void GetHardwareProtectionState(out RawBool hwProtectionEnableRef)
		{
			hwProtectionEnableRef = default(RawBool);
			fixed (RawBool* ptr = &hwProtectionEnableRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)146 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
