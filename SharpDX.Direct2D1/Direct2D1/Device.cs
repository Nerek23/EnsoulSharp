using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;
using SharpDX.WIC;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001C5 RID: 453
	[Guid("47dd575d-ac05-4cdd-8049-9b02cd16f44c")]
	public class Device : Resource
	{
		// Token: 0x060008C9 RID: 2249 RVA: 0x00019004 File Offset: 0x00017204
		public Device(Device device) : base(IntPtr.Zero)
		{
			D2D1.CreateDevice(device, null, this);
		}

		// Token: 0x060008CA RID: 2250 RVA: 0x0001902C File Offset: 0x0001722C
		public Device(Device device, CreationProperties creationProperties) : base(IntPtr.Zero)
		{
			D2D1.CreateDevice(device, new CreationProperties?(creationProperties), this);
		}

		// Token: 0x060008CB RID: 2251 RVA: 0x00019046 File Offset: 0x00017246
		public Device(Factory1 factory, Device device) : base(IntPtr.Zero)
		{
			factory.CreateDevice(device, this);
		}

		// Token: 0x060008CC RID: 2252 RVA: 0x00016258 File Offset: 0x00014458
		public Device(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060008CD RID: 2253 RVA: 0x0001905B File Offset: 0x0001725B
		public new static explicit operator Device(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Device(nativePtr);
			}
			return null;
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x060008CE RID: 2254 RVA: 0x00019072 File Offset: 0x00017272
		// (set) Token: 0x060008CF RID: 2255 RVA: 0x0001907A File Offset: 0x0001727A
		public long MaximumTextureMemory
		{
			get
			{
				return this.GetMaximumTextureMemory();
			}
			set
			{
				this.SetMaximumTextureMemory(value);
			}
		}

		// Token: 0x060008D0 RID: 2256 RVA: 0x00019084 File Offset: 0x00017284
		internal unsafe void CreateDeviceContext(DeviceContextOptions options, DeviceContext deviceContext)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, options, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			deviceContext.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060008D1 RID: 2257 RVA: 0x000190CC File Offset: 0x000172CC
		internal unsafe void CreatePrintControl(ImagingFactory wicFactory, ComObject documentTarget, PrintControlProperties? rintControlPropertiesRef, PrintControl rintControlRef)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<ImagingFactory>(wicFactory);
			value2 = CppObject.ToCallbackPtr<ComObject>(documentTarget);
			PrintControlProperties value3;
			if (rintControlPropertiesRef != null)
			{
				value3 = rintControlPropertiesRef.Value;
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)value2, (rintControlPropertiesRef == null) ? null : (&value3), &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			rintControlRef.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060008D2 RID: 2258 RVA: 0x0001915C File Offset: 0x0001735C
		internal unsafe void SetMaximumTextureMemory(long maximumInBytes)
		{
			calli(System.Void(System.Void*,System.Int64), this._nativePointer, maximumInBytes, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060008D3 RID: 2259 RVA: 0x0001917C File Offset: 0x0001737C
		internal unsafe long GetMaximumTextureMemory()
		{
			return calli(System.Int64(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x00015ABF File Offset: 0x00013CBF
		public unsafe void ClearResources(int millisecondsSinceUse)
		{
			calli(System.Void(System.Void*,System.Int32), this._nativePointer, millisecondsSinceUse, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
		}
	}
}
