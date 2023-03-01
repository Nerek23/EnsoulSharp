using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x0200001A RID: 26
	[Guid("81BDCBCA-64D4-426d-AE8D-AD0147F4275C")]
	public class Direct3D : ComObject
	{
		// Token: 0x0600020C RID: 524 RVA: 0x00008C28 File Offset: 0x00006E28
		public Direct3D()
		{
			base.FromTemp(D3D9.Create9(32));
			this.Adapters = new AdapterCollection(this);
		}

		// Token: 0x0600020D RID: 525 RVA: 0x00008C49 File Offset: 0x00006E49
		public static void CheckVersion()
		{
			if (!D3DX.CheckVersion())
			{
				throw new SharpDXException("Direct3DX9 was not found. Install latest DirectX redistributable runtimes from Microsoft", new object[0]);
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600020E RID: 526 RVA: 0x00008C63 File Offset: 0x00006E63
		// (set) Token: 0x0600020F RID: 527 RVA: 0x00008C6B File Offset: 0x00006E6B
		public AdapterCollection Adapters { get; internal set; }

		// Token: 0x06000210 RID: 528 RVA: 0x00008C74 File Offset: 0x00006E74
		public bool CheckDepthStencilMatch(int adapter, DeviceType deviceType, Format adapterFormat, Format renderTargetFormat, Format depthStencilFormat)
		{
			return this.CheckDepthStencilMatch_(adapter, deviceType, adapterFormat, renderTargetFormat, depthStencilFormat) == 0;
		}

		// Token: 0x06000211 RID: 529 RVA: 0x00008C8E File Offset: 0x00006E8E
		public bool CheckDepthStencilMatch(int adapter, DeviceType deviceType, Format adapterFormat, Format renderTargetFormat, Format depthStencilFormat, out Result result)
		{
			result = this.CheckDepthStencilMatch_(adapter, deviceType, adapterFormat, renderTargetFormat, depthStencilFormat);
			return result == 0;
		}

		// Token: 0x06000212 RID: 530 RVA: 0x00008CB6 File Offset: 0x00006EB6
		public bool CheckDeviceFormat(int adapter, DeviceType deviceType, Format adapterFormat, Usage usage, ResourceType resourceType, Format checkFormat)
		{
			return this.CheckDeviceFormat_(adapter, deviceType, adapterFormat, (int)usage, resourceType, checkFormat) == 0;
		}

		// Token: 0x06000213 RID: 531 RVA: 0x00008CD2 File Offset: 0x00006ED2
		public bool CheckDeviceFormat(int adapter, DeviceType deviceType, Format adapterFormat, Usage usage, ResourceType resourceType, Format checkFormat, out Result result)
		{
			result = this.CheckDeviceFormat_(adapter, deviceType, adapterFormat, (int)usage, resourceType, checkFormat);
			return result == 0;
		}

		// Token: 0x06000214 RID: 532 RVA: 0x00008CFC File Offset: 0x00006EFC
		public bool CheckDeviceFormatConversion(int adapter, DeviceType deviceType, Format sourceFormat, Format targetFormat)
		{
			return this.CheckDeviceFormatConversion_(adapter, deviceType, sourceFormat, targetFormat) == 0;
		}

		// Token: 0x06000215 RID: 533 RVA: 0x00008D14 File Offset: 0x00006F14
		public bool CheckDeviceFormatConversion(int adapter, DeviceType deviceType, Format sourceFormat, Format targetFormat, out Result result)
		{
			result = this.CheckDeviceFormatConversion_(adapter, deviceType, sourceFormat, targetFormat);
			return result == 0;
		}

		// Token: 0x06000216 RID: 534 RVA: 0x00008D3C File Offset: 0x00006F3C
		public bool CheckDeviceMultisampleType(int adapter, DeviceType deviceType, Format surfaceFormat, bool windowed, MultisampleType multisampleType)
		{
			int num;
			return this.CheckDeviceMultiSampleType_(adapter, deviceType, surfaceFormat, windowed, multisampleType, out num) == 0;
		}

		// Token: 0x06000217 RID: 535 RVA: 0x00008D68 File Offset: 0x00006F68
		public bool CheckDeviceMultisampleType(int adapter, DeviceType deviceType, Format surfaceFormat, bool windowed, MultisampleType multisampleType, out int qualityLevels)
		{
			return this.CheckDeviceMultiSampleType_(adapter, deviceType, surfaceFormat, windowed, multisampleType, out qualityLevels) == 0;
		}

		// Token: 0x06000218 RID: 536 RVA: 0x00008D89 File Offset: 0x00006F89
		public bool CheckDeviceMultisampleType(int adapter, DeviceType deviceType, Format surfaceFormat, bool windowed, MultisampleType multisampleType, out int qualityLevels, out Result result)
		{
			result = this.CheckDeviceMultiSampleType_(adapter, deviceType, surfaceFormat, windowed, multisampleType, out qualityLevels);
			return result == 0;
		}

		// Token: 0x06000219 RID: 537 RVA: 0x00008DB8 File Offset: 0x00006FB8
		public bool CheckDeviceType(int adapter, DeviceType deviceType, Format adapterFormat, Format backBufferFormat, bool windowed)
		{
			return this.CheckDeviceType_(adapter, deviceType, adapterFormat, backBufferFormat, windowed) == 0;
		}

		// Token: 0x0600021A RID: 538 RVA: 0x00008DD7 File Offset: 0x00006FD7
		public bool CheckDeviceType(int adapter, DeviceType deviceType, Format adapterFormat, Format backBufferFormat, bool windowed, out Result result)
		{
			result = this.CheckDeviceType_(adapter, deviceType, adapterFormat, backBufferFormat, windowed);
			return result == 0;
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00008E04 File Offset: 0x00007004
		public AdapterDetails GetAdapterIdentifier(int adapter)
		{
			return this.GetAdapterIdentifier(adapter, 0);
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00002623 File Offset: 0x00000823
		public Direct3D(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00008E0E File Offset: 0x0000700E
		public new static explicit operator Direct3D(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new Direct3D(nativePointer);
			}
			return null;
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600021E RID: 542 RVA: 0x00008E25 File Offset: 0x00007025
		public int AdapterCount
		{
			get
			{
				return this.GetAdapterCount();
			}
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00008E30 File Offset: 0x00007030
		public unsafe void RegisterSoftwareDevice(IntPtr initializeFunctionRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)initializeFunctionRef, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000220 RID: 544 RVA: 0x00004001 File Offset: 0x00002201
		internal unsafe int GetAdapterCount()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00008E70 File Offset: 0x00007070
		internal unsafe AdapterDetails GetAdapterIdentifier(int adapter, int flags)
		{
			AdapterDetails.__Native _Native = default(AdapterDetails.__Native);
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, adapter, flags, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			AdapterDetails adapterDetails = new AdapterDetails();
			adapterDetails.__MarshalFrom(ref _Native);
			result.CheckError();
			return adapterDetails;
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00008EC1 File Offset: 0x000070C1
		public unsafe int GetAdapterModeCount(int adapter, Format format)
		{
			return calli(System.Int32(System.Void*,System.Int32,System.Int32), this._nativePointer, adapter, format, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00008EE4 File Offset: 0x000070E4
		public unsafe DisplayMode EnumAdapterModes(int adapter, Format format, int mode)
		{
			DisplayMode result = default(DisplayMode);
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Void*), this._nativePointer, adapter, format, mode, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00008F2C File Offset: 0x0000712C
		public unsafe DisplayMode GetAdapterDisplayMode(int adapter)
		{
			DisplayMode result = default(DisplayMode);
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, adapter, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x06000225 RID: 549 RVA: 0x00008F70 File Offset: 0x00007170
		internal unsafe Result CheckDeviceType_(int adapter, DeviceType devType, Format adapterFormat, Format backBufferFormat, RawBool bWindowed)
		{
			return calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Int32,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, adapter, devType, adapterFormat, backBufferFormat, bWindowed, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000226 RID: 550 RVA: 0x00008FA8 File Offset: 0x000071A8
		internal unsafe Result CheckDeviceFormat_(int adapter, DeviceType deviceType, Format adapterFormat, int usage, ResourceType rType, Format checkFormat)
		{
			return calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), this._nativePointer, adapter, deviceType, adapterFormat, usage, rType, checkFormat, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00008FE4 File Offset: 0x000071E4
		internal unsafe Result CheckDeviceMultiSampleType_(int adapter, DeviceType deviceType, Format surfaceFormat, RawBool windowed, MultisampleType multiSampleType, out int qualityLevelsRef)
		{
			Result result;
			fixed (int* ptr = &qualityLevelsRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,SharpDX.Mathematics.Interop.RawBool,System.Int32,System.Void*), this._nativePointer, adapter, deviceType, surfaceFormat, windowed, multiSampleType, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			}
			return result;
		}

		// Token: 0x06000228 RID: 552 RVA: 0x00009028 File Offset: 0x00007228
		internal unsafe Result CheckDepthStencilMatch_(int adapter, DeviceType deviceType, Format adapterFormat, Format renderTargetFormat, Format depthStencilFormat)
		{
			return calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), this._nativePointer, adapter, deviceType, adapterFormat, renderTargetFormat, depthStencilFormat, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000229 RID: 553 RVA: 0x0000905F File Offset: 0x0000725F
		internal unsafe Result CheckDeviceFormatConversion_(int adapter, DeviceType deviceType, Format sourceFormat, Format targetFormat)
		{
			return calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Int32), this._nativePointer, adapter, deviceType, sourceFormat, targetFormat, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600022A RID: 554 RVA: 0x0000908C File Offset: 0x0000728C
		public unsafe Capabilities GetDeviceCaps(int adapter, DeviceType deviceType)
		{
			Capabilities result = default(Capabilities);
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, adapter, deviceType, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x0600022B RID: 555 RVA: 0x000090D2 File Offset: 0x000072D2
		public unsafe IntPtr GetAdapterMonitor(int adapter)
		{
			return calli(System.IntPtr(System.Void*,System.Int32), this._nativePointer, adapter, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600022C RID: 556 RVA: 0x000090F4 File Offset: 0x000072F4
		internal unsafe void CreateDevice(int adapter, DeviceType deviceType, IntPtr hFocusWindow, CreateFlags behaviorFlags, PresentParameters[] presentationParametersRef, Device returnedDeviceInterfaceOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (PresentParameters[] array = presentationParametersRef)
			{
				void* ptr;
				if (presentationParametersRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, adapter, deviceType, (void*)hFocusWindow, behaviorFlags, ptr, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*)));
			}
			returnedDeviceInterfaceOut.NativePointer = zero;
			result.CheckError();
		}
	}
}
