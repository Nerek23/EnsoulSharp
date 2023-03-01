using System;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000018 RID: 24
	[Guid("1841e5c8-16b0-489b-bcc8-44cfb0d5deae")]
	public class DeviceChild : ComObject
	{
		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x00005214 File Offset: 0x00003414
		// (set) Token: 0x060000D6 RID: 214 RVA: 0x00005264 File Offset: 0x00003464
		public unsafe string DebugName
		{
			get
			{
				byte* ptr = stackalloc byte[(UIntPtr)1024];
				int num = 1023;
				if (this.GetPrivateData(CommonGuid.DebugObjectName, ref num, new IntPtr((void*)ptr)).Failure)
				{
					return string.Empty;
				}
				ptr[num] = 0;
				return Marshal.PtrToStringAnsi(new IntPtr((void*)ptr));
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					this.SetPrivateData(CommonGuid.DebugObjectName, 0, IntPtr.Zero);
					return;
				}
				IntPtr intPtr = Utilities.StringToHGlobalAnsi(value);
				this.SetPrivateData(CommonGuid.DebugObjectName, value.Length, intPtr);
				Marshal.FreeHGlobal(intPtr);
			}
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x000052AA File Offset: 0x000034AA
		protected override void NativePointerUpdated(IntPtr oldNativePointer)
		{
			this.DisposeDevice();
			base.NativePointerUpdated(oldNativePointer);
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x000052B9 File Offset: 0x000034B9
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.DisposeDevice();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x000052CB File Offset: 0x000034CB
		private void DisposeDevice()
		{
			if (this.Device__ != null)
			{
				((IUnknown)this.Device__).Release();
				this.Device__ = null;
			}
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000383E File Offset: 0x00001A3E
		public DeviceChild(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060000DB RID: 219 RVA: 0x000052E8 File Offset: 0x000034E8
		public new static explicit operator DeviceChild(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DeviceChild(nativePtr);
			}
			return null;
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000DC RID: 220 RVA: 0x000052FF File Offset: 0x000034FF
		public Device Device
		{
			get
			{
				if (this.Device__ == null)
				{
					this.GetDevice(out this.Device__);
				}
				return this.Device__;
			}
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0000531C File Offset: 0x0000351C
		internal unsafe void GetDevice(out Device deviceOut)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				deviceOut = new Device(zero);
				return;
			}
			deviceOut = null;
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00005368 File Offset: 0x00003568
		public unsafe Result GetPrivateData(Guid guid, ref int dataSizeRef, IntPtr dataRef)
		{
			Result result;
			fixed (int* ptr = &dataSizeRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &guid, ptr2, (void*)dataRef, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			}
			return result;
		}

		// Token: 0x060000DF RID: 223 RVA: 0x000053AC File Offset: 0x000035AC
		public unsafe void SetPrivateData(Guid guid, int dataSize, IntPtr dataRef)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, &guid, dataSize, (void*)dataRef, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x000053F0 File Offset: 0x000035F0
		public unsafe void SetPrivateDataInterface(Guid guid, IUnknown dataRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IUnknown>(dataRef);
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &guid, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x04000033 RID: 51
		protected internal Device Device__;
	}
}
