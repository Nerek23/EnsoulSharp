using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000024 RID: 36
	[Guid("79cf2233-7536-4948-9d36-1e4692dc5760")]
	public class DeviceDebug : ComObject
	{
		// Token: 0x0600020F RID: 527 RVA: 0x000098A6 File Offset: 0x00007AA6
		public DeviceDebug(Device device)
		{
			base.QueryInterfaceFrom<Device>(device);
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000210 RID: 528 RVA: 0x000098B5 File Offset: 0x00007AB5
		// (set) Token: 0x06000211 RID: 529 RVA: 0x000098BD File Offset: 0x00007ABD
		public DebugFeatureFlags FeatureFlags
		{
			get
			{
				return (DebugFeatureFlags)this.GetFeatureFlags();
			}
			set
			{
				this.SetFeatureFlags((int)value);
			}
		}

		// Token: 0x06000212 RID: 530 RVA: 0x0000383E File Offset: 0x00001A3E
		public DeviceDebug(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000213 RID: 531 RVA: 0x000098C6 File Offset: 0x00007AC6
		public new static explicit operator DeviceDebug(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DeviceDebug(nativePtr);
			}
			return null;
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000214 RID: 532 RVA: 0x000098DD File Offset: 0x00007ADD
		// (set) Token: 0x06000215 RID: 533 RVA: 0x000098E5 File Offset: 0x00007AE5
		public int PresentDelay
		{
			get
			{
				return this.GetPresentDelay();
			}
			set
			{
				this.SetPresentDelay(value);
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000216 RID: 534 RVA: 0x000098F0 File Offset: 0x00007AF0
		// (set) Token: 0x06000217 RID: 535 RVA: 0x00009906 File Offset: 0x00007B06
		public SwapChain SwapChain
		{
			get
			{
				SwapChain result;
				this.GetSwapChain(out result);
				return result;
			}
			set
			{
				this.SetSwapChain(value);
			}
		}

		// Token: 0x06000218 RID: 536 RVA: 0x00009910 File Offset: 0x00007B10
		internal unsafe void SetFeatureFlags(int mask)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, mask, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000219 RID: 537 RVA: 0x00009948 File Offset: 0x00007B48
		internal unsafe int GetFeatureFlags()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600021A RID: 538 RVA: 0x00009968 File Offset: 0x00007B68
		internal unsafe void SetPresentDelay(int milliseconds)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, milliseconds, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600021B RID: 539 RVA: 0x000099A0 File Offset: 0x00007BA0
		internal unsafe int GetPresentDelay()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600021C RID: 540 RVA: 0x000099C0 File Offset: 0x00007BC0
		internal unsafe void SetSwapChain(SwapChain swapChainRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<SwapChain>(swapChainRef);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00009A0C File Offset: 0x00007C0C
		internal unsafe void GetSwapChain(out SwapChain swapChainOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				swapChainOut = new SwapChain(zero);
			}
			else
			{
				swapChainOut = null;
			}
			result.CheckError();
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00009A68 File Offset: 0x00007C68
		public unsafe void ValidateContext(DeviceContext contextRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<DeviceContext>(contextRef);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00009AB4 File Offset: 0x00007CB4
		public unsafe void ReportLiveDeviceObjects(ReportingLevel flags)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, flags, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000220 RID: 544 RVA: 0x00009AF0 File Offset: 0x00007CF0
		public unsafe void ValidateContextForDispatch(DeviceContext contextRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<DeviceContext>(contextRef);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
