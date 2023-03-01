using System;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;
using SharpDX.DXGI;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000013 RID: 19
	[Guid("db6f6ddb-ac77-4e88-8253-819df9bbf140")]
	public class Device : ComObject
	{
		// Token: 0x06000059 RID: 89 RVA: 0x00002FD6 File Offset: 0x000011D6
		public Device(DriverType driverType) : this(driverType, DeviceCreationFlags.None)
		{
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00002FE0 File Offset: 0x000011E0
		public Device(Adapter adapter) : this(adapter, DeviceCreationFlags.None)
		{
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00002FEA File Offset: 0x000011EA
		public Device(DriverType driverType, DeviceCreationFlags flags)
		{
			this.CreateDevice(null, driverType, flags, null);
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00002FFC File Offset: 0x000011FC
		public Device(Adapter adapter, DeviceCreationFlags flags)
		{
			this.CreateDevice(adapter, DriverType.Unknown, flags, null);
		}

		// Token: 0x0600005D RID: 93 RVA: 0x0000300E File Offset: 0x0000120E
		public Device(DriverType driverType, DeviceCreationFlags flags, params FeatureLevel[] featureLevels)
		{
			this.CreateDevice(null, driverType, flags, featureLevels);
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00003020 File Offset: 0x00001220
		public Device(Adapter adapter, DeviceCreationFlags flags, params FeatureLevel[] featureLevels)
		{
			this.CreateDevice(adapter, DriverType.Unknown, flags, featureLevels);
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00003032 File Offset: 0x00001232
		public static void CreateWithSwapChain(DriverType driverType, DeviceCreationFlags flags, SwapChainDescription swapChainDescription, out Device device, out SwapChain swapChain)
		{
			Device.CreateWithSwapChain(null, driverType, flags, null, swapChainDescription, out device, out swapChain);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00003041 File Offset: 0x00001241
		public static void CreateWithSwapChain(Adapter adapter, DeviceCreationFlags flags, SwapChainDescription swapChainDescription, out Device device, out SwapChain swapChain)
		{
			Device.CreateWithSwapChain(adapter, DriverType.Unknown, flags, null, swapChainDescription, out device, out swapChain);
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00003050 File Offset: 0x00001250
		public static void CreateWithSwapChain(DriverType driverType, DeviceCreationFlags flags, FeatureLevel[] featureLevels, SwapChainDescription swapChainDescription, out Device device, out SwapChain swapChain)
		{
			Device.CreateWithSwapChain(null, driverType, flags, featureLevels, swapChainDescription, out device, out swapChain);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00003060 File Offset: 0x00001260
		public static void CreateWithSwapChain(Adapter adapter, DeviceCreationFlags flags, FeatureLevel[] featureLevels, SwapChainDescription swapChainDescription, out Device device, out SwapChain swapChain)
		{
			Device.CreateWithSwapChain(adapter, DriverType.Unknown, flags, featureLevels, swapChainDescription, out device, out swapChain);
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00003070 File Offset: 0x00001270
		private static void CreateWithSwapChain(Adapter adapter, DriverType driverType, DeviceCreationFlags flags, FeatureLevel[] featureLevels, SwapChainDescription swapChainDescription, out Device device, out SwapChain swapChain)
		{
			device = ((adapter == null) ? new Device(driverType, flags, featureLevels) : new Device(adapter, flags, featureLevels));
			using (Factory1 factory = new Factory1())
			{
				swapChain = new SwapChain(factory, device, swapChainDescription);
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x000030C8 File Offset: 0x000012C8
		public unsafe CounterMetadata GetCounterMetadata(CounterDescription counterDescription)
		{
			CounterMetadata counterMetadata = new CounterMetadata();
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			CounterType type;
			int hardwareCounterCount;
			this.CheckCounter(counterDescription, out type, out hardwareCounterCount, IntPtr.Zero, new IntPtr((void*)(&num)), IntPtr.Zero, new IntPtr((void*)(&num2)), IntPtr.Zero, new IntPtr((void*)(&num3)));
			sbyte* value = stackalloc sbyte[(UIntPtr)num];
			sbyte* value2 = stackalloc sbyte[(UIntPtr)num2];
			sbyte* value3 = stackalloc sbyte[(UIntPtr)num3];
			this.CheckCounter(counterDescription, out type, out hardwareCounterCount, new IntPtr((void*)value), new IntPtr((void*)(&num)), new IntPtr((void*)value2), new IntPtr((void*)(&num2)), new IntPtr((void*)value3), new IntPtr((void*)(&num3)));
			counterMetadata.Type = type;
			counterMetadata.HardwareCounterCount = hardwareCounterCount;
			counterMetadata.Name = Marshal.PtrToStringAnsi((IntPtr)((void*)value), num);
			counterMetadata.Units = Marshal.PtrToStringAnsi((IntPtr)((void*)value2), num2);
			counterMetadata.Description = Marshal.PtrToStringAnsi((IntPtr)((void*)value3), num3);
			return counterMetadata;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x000031AC File Offset: 0x000013AC
		public T OpenSharedResource<T>(IntPtr resourceHandle) where T : ComObject
		{
			IntPtr comObjectPtr;
			this.OpenSharedResource(resourceHandle, Utilities.GetGuidFromType(typeof(T)), out comObjectPtr);
			return CppObject.FromPointer<T>(comObjectPtr);
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000031D8 File Offset: 0x000013D8
		public unsafe ComputeShaderFormatSupport CheckComputeShaderFormatSupport(Format format)
		{
			FeatureDataFormatSupport2 featureDataFormatSupport = default(FeatureDataFormatSupport2);
			featureDataFormatSupport.InFormat = format;
			if (this.CheckFeatureSupport(Feature.ComputeShaders, new IntPtr((void*)(&featureDataFormatSupport)), Utilities.SizeOf<FeatureDataFormatSupport2>()).Failure)
			{
				return ComputeShaderFormatSupport.None;
			}
			return featureDataFormatSupport.OutFormatSupport2;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000321C File Offset: 0x0000141C
		public unsafe FeatureDataD3D11Options CheckD3D11Feature()
		{
			FeatureDataD3D11Options result = default(FeatureDataD3D11Options);
			if (this.CheckFeatureSupport(Feature.D3D11Options, new IntPtr((void*)(&result)), Utilities.SizeOf<FeatureDataD3D11Options>()).Failure)
			{
				return default(FeatureDataD3D11Options);
			}
			return result;
		}

		// Token: 0x06000068 RID: 104 RVA: 0x0000325C File Offset: 0x0000145C
		public unsafe FeatureDataShaderMinimumPrecisionSupport CheckShaderMinimumPrecisionSupport()
		{
			FeatureDataShaderMinimumPrecisionSupport result = default(FeatureDataShaderMinimumPrecisionSupport);
			if (this.CheckFeatureSupport(Feature.ShaderMinimumPrecisionSupport, new IntPtr((void*)(&result)), Utilities.SizeOf<FeatureDataShaderMinimumPrecisionSupport>()).Failure)
			{
				return default(FeatureDataShaderMinimumPrecisionSupport);
			}
			return result;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x0000329C File Offset: 0x0000149C
		public unsafe bool CheckFullNonPow2TextureSupport()
		{
			FeatureDataD3D9Options featureDataD3D9Options = default(FeatureDataD3D9Options);
			Result result = this.CheckFeatureSupport(Feature.D3D9Options, new IntPtr((void*)(&featureDataD3D9Options)), Utilities.SizeOf<FeatureDataD3D9Options>());
			if (this.FeatureLevel <= FeatureLevel.Level_9_3)
			{
				return result.Failure;
			}
			return !result.Failure && featureDataD3D9Options.FullNonPow2TextureSupport;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000032F4 File Offset: 0x000014F4
		public unsafe bool CheckTileBasedDeferredRendererSupport()
		{
			FeatureDataArchitectureInformation featureDataArchitectureInformation = default(FeatureDataArchitectureInformation);
			return !this.CheckFeatureSupport(Feature.ArchitectureInformation, new IntPtr((void*)(&featureDataArchitectureInformation)), Utilities.SizeOf<FeatureDataArchitectureInformation>()).Failure && featureDataArchitectureInformation.TileBasedDeferredRenderer;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00003334 File Offset: 0x00001534
		public unsafe FeatureDataD3D11Options1 CheckD3D112Feature()
		{
			FeatureDataD3D11Options1 result = default(FeatureDataD3D11Options1);
			if (this.CheckFeatureSupport(Feature.D3D11Options1, new IntPtr((void*)(&result)), Utilities.SizeOf<FeatureDataD3D11Options1>()).Failure)
			{
				return default(FeatureDataD3D11Options1);
			}
			return result;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00003374 File Offset: 0x00001574
		public unsafe FeatureDataD3D11Options2 CheckD3D113Features2()
		{
			FeatureDataD3D11Options2 result = default(FeatureDataD3D11Options2);
			if (this.CheckFeatureSupport(Feature.D3D11Options2, new IntPtr((void*)(&result)), Utilities.SizeOf<FeatureDataD3D11Options2>()).Failure)
			{
				return default(FeatureDataD3D11Options2);
			}
			return result;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x000033B4 File Offset: 0x000015B4
		public unsafe FeatureDataD3D11Options3 CheckD3D113Features3()
		{
			FeatureDataD3D11Options3 result = default(FeatureDataD3D11Options3);
			if (this.CheckFeatureSupport(Feature.D3D11Options3, new IntPtr((void*)(&result)), Utilities.SizeOf<FeatureDataD3D11Options3>()).Failure)
			{
				return default(FeatureDataD3D11Options3);
			}
			return result;
		}

		// Token: 0x0600006E RID: 110 RVA: 0x000033F4 File Offset: 0x000015F4
		public unsafe FeatureDataD3D11Options4 CheckD3D113Features4()
		{
			FeatureDataD3D11Options4 result = default(FeatureDataD3D11Options4);
			if (this.CheckFeatureSupport(Feature.D3D11Options4, new IntPtr((void*)(&result)), Utilities.SizeOf<FeatureDataD3D11Options4>()).Failure)
			{
				return default(FeatureDataD3D11Options4);
			}
			return result;
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00003434 File Offset: 0x00001634
		public unsafe bool CheckFeatureSupport(Feature feature)
		{
			if (feature == Feature.ShaderDoubles)
			{
				FeatureDataDoubles featureDataDoubles;
				return !this.CheckFeatureSupport(Feature.ShaderDoubles, new IntPtr((void*)(&featureDataDoubles)), Utilities.SizeOf<FeatureDataDoubles>()).Failure && featureDataDoubles.DoublePrecisionFloatShaderOps;
			}
			if (feature - Feature.ComputeShaders > 1)
			{
				throw new SharpDXException("Unsupported Feature. Use specialized CheckXXX methods", new object[0]);
			}
			FeatureDataD3D10XHardwareOptions featureDataD3D10XHardwareOptions;
			return !this.CheckFeatureSupport(Feature.D3D10XHardwareOptions, new IntPtr((void*)(&featureDataD3D10XHardwareOptions)), Utilities.SizeOf<FeatureDataD3D10XHardwareOptions>()).Failure && featureDataD3D10XHardwareOptions.ComputeShadersPlusRawAndStructuredBuffersViaShader4X;
		}

		// Token: 0x06000070 RID: 112 RVA: 0x000034B8 File Offset: 0x000016B8
		public unsafe Result CheckThreadingSupport(out bool supportsConcurrentResources, out bool supportsCommandLists)
		{
			FeatureDataThreading featureDataThreading = default(FeatureDataThreading);
			Result result = this.CheckFeatureSupport(Feature.Threading, new IntPtr((void*)(&featureDataThreading)), Utilities.SizeOf<FeatureDataThreading>());
			if (result.Failure)
			{
				supportsConcurrentResources = false;
				supportsCommandLists = false;
			}
			else
			{
				supportsConcurrentResources = featureDataThreading.DriverConcurrentCreates;
				supportsCommandLists = featureDataThreading.DriverCommandLists;
			}
			return result;
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00003510 File Offset: 0x00001710
		public static bool IsSupportedFeatureLevel(FeatureLevel featureLevel)
		{
			Device device = new Device(IntPtr.Zero);
			DeviceContext deviceContext = null;
			bool result;
			try
			{
				FeatureLevel featureLevel2;
				result = (D3D11.CreateDevice(null, DriverType.Hardware, IntPtr.Zero, DeviceCreationFlags.None, new FeatureLevel[]
				{
					featureLevel
				}, 1, 7, device, out featureLevel2, out deviceContext).Success && featureLevel2 == featureLevel);
			}
			finally
			{
				if (deviceContext != null)
				{
					deviceContext.Dispose();
				}
				if (device.NativePointer != IntPtr.Zero)
				{
					device.Dispose();
				}
			}
			return result;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00003594 File Offset: 0x00001794
		public static bool IsSupportedFeatureLevel(Adapter adapter, FeatureLevel featureLevel)
		{
			Device device = new Device(IntPtr.Zero);
			DeviceContext deviceContext = null;
			bool result;
			try
			{
				FeatureLevel featureLevel2;
				result = (D3D11.CreateDevice(adapter, DriverType.Unknown, IntPtr.Zero, DeviceCreationFlags.None, new FeatureLevel[]
				{
					featureLevel
				}, 1, 7, device, out featureLevel2, out deviceContext).Success && featureLevel2 == featureLevel);
			}
			finally
			{
				if (deviceContext != null)
				{
					deviceContext.Dispose();
				}
				if (device.NativePointer != IntPtr.Zero)
				{
					device.Dispose();
				}
			}
			return result;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00003618 File Offset: 0x00001818
		public static FeatureLevel GetSupportedFeatureLevel()
		{
			Device device = new Device(IntPtr.Zero);
			FeatureLevel result;
			DeviceContext deviceContext;
			D3D11.CreateDevice(null, DriverType.Hardware, IntPtr.Zero, DeviceCreationFlags.None, null, 0, 7, device, out result, out deviceContext).CheckError();
			deviceContext.Dispose();
			device.Dispose();
			return result;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x0000365C File Offset: 0x0000185C
		public static FeatureLevel GetSupportedFeatureLevel(Adapter adapter)
		{
			Device device = new Device(IntPtr.Zero);
			FeatureLevel result;
			DeviceContext deviceContext;
			D3D11.CreateDevice(adapter, DriverType.Unknown, IntPtr.Zero, DeviceCreationFlags.None, null, 0, 7, device, out result, out deviceContext).CheckError();
			deviceContext.Dispose();
			device.Dispose();
			return result;
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000075 RID: 117 RVA: 0x000036A0 File Offset: 0x000018A0
		public bool IsReferenceDevice
		{
			get
			{
				bool result;
				try
				{
					using (SwitchToRef switchToRef = this.QueryInterface<SwitchToRef>())
					{
						result = switchToRef.GetUseRef();
					}
				}
				catch (SharpDXException)
				{
					result = false;
				}
				return result;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000076 RID: 118 RVA: 0x000036F0 File Offset: 0x000018F0
		// (set) Token: 0x06000077 RID: 119 RVA: 0x00003740 File Offset: 0x00001940
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
				IntPtr dataRef = Utilities.StringToHGlobalAnsi(value);
				this.SetPrivateData(CommonGuid.DebugObjectName, value.Length, dataRef);
			}
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00003780 File Offset: 0x00001980
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.ImmediateContext__ != null)
			{
				this.ImmediateContext__.Dispose();
				this.ImmediateContext__ = null;
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x000037A8 File Offset: 0x000019A8
		private void CreateDevice(Adapter adapter, DriverType driverType, DeviceCreationFlags flags, FeatureLevel[] featureLevels)
		{
			FeatureLevel featureLevel;
			D3D11.CreateDevice(adapter, driverType, IntPtr.Zero, flags, featureLevels, (featureLevels == null) ? 0 : featureLevels.Length, 7, this, out featureLevel, out this.ImmediateContext__).CheckError();
			if (this.ImmediateContext__ != null)
			{
				((IUnknown)this).AddReference();
				this.ImmediateContext__.Device__ = this;
			}
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000037FC File Offset: 0x000019FC
		public static Device CreateFromDirect3D12(ComObject d3D12Device, DeviceCreationFlags flags, FeatureLevel[] featureLevels, Adapter adapter, params ComObject[] commandQueues)
		{
			if (d3D12Device == null)
			{
				throw new ArgumentNullException("d3D12Device");
			}
			Device result;
			DeviceContext deviceContext;
			FeatureLevel featureLevel;
			D3D11.On12CreateDevice(d3D12Device, flags, featureLevels, (featureLevels == null) ? 0 : featureLevels.Length, commandQueues, commandQueues.Length, 0, out result, out deviceContext, out featureLevel);
			deviceContext.Dispose();
			return result;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x0000383E File Offset: 0x00001A3E
		public Device(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00003847 File Offset: 0x00001A47
		public new static explicit operator Device(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Device(nativePtr);
			}
			return null;
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600007D RID: 125 RVA: 0x0000385E File Offset: 0x00001A5E
		public FeatureLevel FeatureLevel
		{
			get
			{
				return this.GetFeatureLevel();
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600007E RID: 126 RVA: 0x00003866 File Offset: 0x00001A66
		public DeviceCreationFlags CreationFlags
		{
			get
			{
				return this.GetCreationFlags();
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600007F RID: 127 RVA: 0x0000386E File Offset: 0x00001A6E
		public Result DeviceRemovedReason
		{
			get
			{
				return this.GetDeviceRemovedReason();
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000080 RID: 128 RVA: 0x00003876 File Offset: 0x00001A76
		public DeviceContext ImmediateContext
		{
			get
			{
				if (this.ImmediateContext__ == null)
				{
					this.GetImmediateContext(out this.ImmediateContext__);
				}
				return this.ImmediateContext__;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000081 RID: 129 RVA: 0x00003892 File Offset: 0x00001A92
		// (set) Token: 0x06000082 RID: 130 RVA: 0x0000389A File Offset: 0x00001A9A
		public int ExceptionMode
		{
			get
			{
				return this.GetExceptionMode();
			}
			set
			{
				this.SetExceptionMode(value);
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x000038A4 File Offset: 0x00001AA4
		internal unsafe void CreateBuffer(ref BufferDescription descRef, DataBox? initialDataRef, Buffer bufferOut)
		{
			IntPtr zero = IntPtr.Zero;
			DataBox value;
			if (initialDataRef != null)
			{
				value = initialDataRef.Value;
			}
			Result result;
			fixed (BufferDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, ptr2, (initialDataRef == null) ? null : (&value), &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			}
			bufferOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00003918 File Offset: 0x00001B18
		internal unsafe void CreateTexture1D(ref Texture1DDescription descRef, DataBox[] initialDataRef, Texture1D texture1DOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (DataBox[] array = initialDataRef)
			{
				void* ptr;
				if (initialDataRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (Texture1DDescription* ptr2 = &descRef)
				{
					void* ptr3 = (void*)ptr2;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, ptr3, ptr, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
				}
			}
			texture1DOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00003988 File Offset: 0x00001B88
		internal unsafe void CreateTexture2D(ref Texture2DDescription descRef, DataBox[] initialDataRef, Texture2D texture2DOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (DataBox[] array = initialDataRef)
			{
				void* ptr;
				if (initialDataRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (Texture2DDescription* ptr2 = &descRef)
				{
					void* ptr3 = (void*)ptr2;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, ptr3, ptr, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
				}
			}
			texture2DOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000086 RID: 134 RVA: 0x000039F8 File Offset: 0x00001BF8
		internal unsafe void CreateTexture3D(ref Texture3DDescription descRef, DataBox[] initialDataRef, Texture3D texture3DOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (DataBox[] array = initialDataRef)
			{
				void* ptr;
				if (initialDataRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (Texture3DDescription* ptr2 = &descRef)
				{
					void* ptr3 = (void*)ptr2;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, ptr3, ptr, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
				}
			}
			texture3DOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00003A68 File Offset: 0x00001C68
		internal unsafe void CreateShaderResourceView(Resource resourceRef, ShaderResourceViewDescription? descRef, ShaderResourceView sRViewOut)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Resource>(resourceRef);
			ShaderResourceViewDescription value2;
			if (descRef != null)
			{
				value2 = descRef.Value;
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (descRef == null) ? null : (&value2), &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			sRViewOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00003AE4 File Offset: 0x00001CE4
		internal unsafe void CreateUnorderedAccessView(Resource resourceRef, UnorderedAccessViewDescription? descRef, UnorderedAccessView uAViewOut)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Resource>(resourceRef);
			UnorderedAccessViewDescription value2;
			if (descRef != null)
			{
				value2 = descRef.Value;
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (descRef == null) ? null : (&value2), &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			uAViewOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00003B60 File Offset: 0x00001D60
		internal unsafe void CreateRenderTargetView(Resource resourceRef, RenderTargetViewDescription? descRef, RenderTargetView rTViewOut)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Resource>(resourceRef);
			RenderTargetViewDescription value2;
			if (descRef != null)
			{
				value2 = descRef.Value;
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (descRef == null) ? null : (&value2), &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			rTViewOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00003BDC File Offset: 0x00001DDC
		internal unsafe void CreateDepthStencilView(Resource resourceRef, DepthStencilViewDescription? descRef, DepthStencilView depthStencilViewOut)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Resource>(resourceRef);
			DepthStencilViewDescription value2;
			if (descRef != null)
			{
				value2 = descRef.Value;
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (descRef == null) ? null : (&value2), &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			depthStencilViewOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00003C58 File Offset: 0x00001E58
		internal unsafe void CreateInputLayout(InputElement[] inputElementDescsRef, int numElements, IntPtr shaderBytecodeWithInputSignatureRef, PointerSize bytecodeLength, InputLayout inputLayoutOut)
		{
			InputElement.__Native[] array = new InputElement.__Native[inputElementDescsRef.Length];
			IntPtr zero = IntPtr.Zero;
			for (int i = 0; i < inputElementDescsRef.Length; i++)
			{
				inputElementDescsRef[i].__MarshalTo(ref array[i]);
			}
			InputElement.__Native[] array2;
			void* ptr;
			if ((array2 = array) == null || array2.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = (void*)(&array2[0]);
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, ptr, numElements, (void*)shaderBytecodeWithInputSignatureRef, bytecodeLength, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			array2 = null;
			inputLayoutOut.NativePointer = zero;
			for (int j = 0; j < inputElementDescsRef.Length; j++)
			{
				inputElementDescsRef[j].__MarshalFree(ref array[j]);
			}
			result.CheckError();
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00003D24 File Offset: 0x00001F24
		internal unsafe void CreateVertexShader(IntPtr shaderBytecodeRef, PointerSize bytecodeLength, ClassLinkage classLinkageRef, VertexShader vertexShaderOut)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<ClassLinkage>(classLinkageRef);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)shaderBytecodeRef, bytecodeLength, (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			vertexShaderOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00003D8C File Offset: 0x00001F8C
		internal unsafe void CreateGeometryShader(IntPtr shaderBytecodeRef, PointerSize bytecodeLength, ClassLinkage classLinkageRef, GeometryShader geometryShaderOut)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<ClassLinkage>(classLinkageRef);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)shaderBytecodeRef, bytecodeLength, (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			geometryShaderOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00003DF4 File Offset: 0x00001FF4
		internal unsafe void CreateGeometryShaderWithStreamOutput(IntPtr shaderBytecodeRef, PointerSize bytecodeLength, StreamOutputElement[] sODeclarationRef, int numEntries, int[] bufferStridesRef, int numStrides, int rasterizedStream, ClassLinkage classLinkageRef, GeometryShader geometryShaderOut)
		{
			StreamOutputElement.__Native[] array = (sODeclarationRef == null) ? null : new StreamOutputElement.__Native[sODeclarationRef.Length];
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			if (sODeclarationRef != null)
			{
				for (int i = 0; i < sODeclarationRef.Length; i++)
				{
					if (sODeclarationRef != null)
					{
						sODeclarationRef[i].__MarshalTo(ref array[i]);
					}
				}
			}
			value = CppObject.ToCallbackPtr<ClassLinkage>(classLinkageRef);
			Result result;
			fixed (int[] array2 = bufferStridesRef)
			{
				void* ptr;
				if (bufferStridesRef == null || array2.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array2[0]);
				}
				StreamOutputElement.__Native[] array3;
				void* ptr2;
				if ((array3 = array) == null || array3.Length == 0)
				{
					ptr2 = null;
				}
				else
				{
					ptr2 = (void*)(&array3[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Int32,System.Void*,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, (void*)shaderBytecodeRef, bytecodeLength, ptr2, numEntries, ptr, numStrides, rasterizedStream, (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
				array3 = null;
			}
			geometryShaderOut.NativePointer = zero;
			if (sODeclarationRef != null)
			{
				for (int j = 0; j < sODeclarationRef.Length; j++)
				{
					if (sODeclarationRef != null)
					{
						sODeclarationRef[j].__MarshalFree(ref array[j]);
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00003F14 File Offset: 0x00002114
		internal unsafe void CreatePixelShader(IntPtr shaderBytecodeRef, PointerSize bytecodeLength, ClassLinkage classLinkageRef, PixelShader pixelShaderOut)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<ClassLinkage>(classLinkageRef);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)shaderBytecodeRef, bytecodeLength, (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
			pixelShaderOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00003F7C File Offset: 0x0000217C
		internal unsafe void CreateHullShader(IntPtr shaderBytecodeRef, PointerSize bytecodeLength, ClassLinkage classLinkageRef, HullShader hullShaderOut)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<ClassLinkage>(classLinkageRef);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)shaderBytecodeRef, bytecodeLength, (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*)));
			hullShaderOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00003FE4 File Offset: 0x000021E4
		internal unsafe void CreateDomainShader(IntPtr shaderBytecodeRef, PointerSize bytecodeLength, ClassLinkage classLinkageRef, DomainShader domainShaderOut)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<ClassLinkage>(classLinkageRef);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)shaderBytecodeRef, bytecodeLength, (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
			domainShaderOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0000404C File Offset: 0x0000224C
		internal unsafe void CreateComputeShader(IntPtr shaderBytecodeRef, PointerSize bytecodeLength, ClassLinkage classLinkageRef, ComputeShader computeShaderOut)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<ClassLinkage>(classLinkageRef);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)shaderBytecodeRef, bytecodeLength, (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
			computeShaderOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000093 RID: 147 RVA: 0x000040B4 File Offset: 0x000022B4
		internal unsafe void CreateClassLinkage(ClassLinkage linkageOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
			linkageOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000094 RID: 148 RVA: 0x000040FC File Offset: 0x000022FC
		internal unsafe void CreateBlendState(ref BlendStateDescription blendStateDescRef, BlendState blendStateOut)
		{
			BlendStateDescription.__Native _Native = default(BlendStateDescription.__Native);
			IntPtr zero = IntPtr.Zero;
			blendStateDescRef.__MarshalTo(ref _Native);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &_Native, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*)));
			blendStateOut.NativePointer = zero;
			blendStateDescRef.__MarshalFree(ref _Native);
			result.CheckError();
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00004160 File Offset: 0x00002360
		internal unsafe void CreateDepthStencilState(ref DepthStencilStateDescription depthStencilDescRef, DepthStencilState depthStencilStateOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (DepthStencilStateDescription* ptr = &depthStencilDescRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*)));
			}
			depthStencilStateOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000096 RID: 150 RVA: 0x000041B4 File Offset: 0x000023B4
		internal unsafe void CreateRasterizerState(ref RasterizerStateDescription rasterizerDescRef, RasterizerState rasterizerStateOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (RasterizerStateDescription* ptr = &rasterizerDescRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)22 * (IntPtr)sizeof(void*)));
			}
			rasterizerStateOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00004208 File Offset: 0x00002408
		internal unsafe void CreateSamplerState(ref SamplerStateDescription samplerDescRef, SamplerState samplerStateOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (SamplerStateDescription* ptr = &samplerDescRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*)));
			}
			samplerStateOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000425C File Offset: 0x0000245C
		internal unsafe void CreateQuery(QueryDescription queryDescRef, Query queryOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &queryDescRef, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)24 * (IntPtr)sizeof(void*)));
			queryOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000099 RID: 153 RVA: 0x000042A8 File Offset: 0x000024A8
		internal unsafe void CreatePredicate(QueryDescription predicateDescRef, Predicate predicateOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &predicateDescRef, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)25 * (IntPtr)sizeof(void*)));
			predicateOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600009A RID: 154 RVA: 0x000042F4 File Offset: 0x000024F4
		internal unsafe void CreateCounter(CounterDescription counterDescRef, Counter counterOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &counterDescRef, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)26 * (IntPtr)sizeof(void*)));
			counterOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00004340 File Offset: 0x00002540
		internal unsafe void CreateDeferredContext(int contextFlags, DeviceContext deferredContextOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, contextFlags, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)27 * (IntPtr)sizeof(void*)));
			deferredContextOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600009C RID: 156 RVA: 0x0000438C File Offset: 0x0000258C
		internal unsafe void OpenSharedResource(IntPtr hResource, Guid returnedInterface, out IntPtr resourceOut)
		{
			Result result;
			fixed (IntPtr* ptr = &resourceOut)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)hResource, &returnedInterface, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)28 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600009D RID: 157 RVA: 0x000043D8 File Offset: 0x000025D8
		public unsafe FormatSupport CheckFormatSupport(Format format)
		{
			FormatSupport result;
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, format, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)29 * (IntPtr)sizeof(void*)));
			return result;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00004410 File Offset: 0x00002610
		public unsafe int CheckMultisampleQualityLevels(Format format, int sampleCount)
		{
			int result;
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, format, sampleCount, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)30 * (IntPtr)sizeof(void*)));
			return result;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00004448 File Offset: 0x00002648
		public unsafe CounterCapabilities GetCounterCapabilities()
		{
			CounterCapabilities result;
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)31 * (IntPtr)sizeof(void*)));
			return result;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00004478 File Offset: 0x00002678
		internal unsafe void CheckCounter(CounterDescription descRef, out CounterType typeRef, out int activeCountersRef, IntPtr szName, IntPtr nameLengthRef, IntPtr szUnits, IntPtr unitsLengthRef, IntPtr szDescription, IntPtr descriptionLengthRef)
		{
			Result result;
			fixed (int* ptr = &activeCountersRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (CounterType* ptr3 = &typeRef)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &descRef, ptr4, ptr2, (void*)szName, (void*)nameLengthRef, (void*)szUnits, (void*)unitsLengthRef, (void*)szDescription, (void*)descriptionLengthRef, *(*(IntPtr*)this._nativePointer + (IntPtr)32 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x000044F2 File Offset: 0x000026F2
		internal unsafe Result CheckFeatureSupport(Feature feature, IntPtr featureSupportDataRef, int featureSupportDataSize)
		{
			return calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, feature, (void*)featureSupportDataRef, featureSupportDataSize, *(*(IntPtr*)this._nativePointer + (IntPtr)33 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00004520 File Offset: 0x00002720
		public unsafe Result GetPrivateData(Guid guid, ref int dataSizeRef, IntPtr dataRef)
		{
			Result result;
			fixed (int* ptr = &dataSizeRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &guid, ptr2, (void*)dataRef, *(*(IntPtr*)this._nativePointer + (IntPtr)34 * (IntPtr)sizeof(void*)));
			}
			return result;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00004564 File Offset: 0x00002764
		public unsafe void SetPrivateData(Guid guid, int dataSize, IntPtr dataRef)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, &guid, dataSize, (void*)dataRef, *(*(IntPtr*)this._nativePointer + (IntPtr)35 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x000045A8 File Offset: 0x000027A8
		public unsafe void SetPrivateDataInterface(Guid guid, IUnknown dataRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IUnknown>(dataRef);
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &guid, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)36 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x000045F6 File Offset: 0x000027F6
		internal unsafe FeatureLevel GetFeatureLevel()
		{
			return calli(SharpDX.Direct3D.FeatureLevel(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)37 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00004616 File Offset: 0x00002816
		internal unsafe DeviceCreationFlags GetCreationFlags()
		{
			return calli(SharpDX.Direct3D11.DeviceCreationFlags(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)38 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00004636 File Offset: 0x00002836
		internal unsafe Result GetDeviceRemovedReason()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)39 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000465C File Offset: 0x0000285C
		internal unsafe void GetImmediateContext(out DeviceContext immediateContextOut)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)40 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				immediateContextOut = new DeviceContext(zero);
				return;
			}
			immediateContextOut = null;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x000046AC File Offset: 0x000028AC
		internal unsafe void SetExceptionMode(int raiseFlags)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, raiseFlags, *(*(IntPtr*)this._nativePointer + (IntPtr)41 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000046E5 File Offset: 0x000028E5
		internal unsafe int GetExceptionMode()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)42 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0400002E RID: 46
		public const int MultisampleCountMaximum = 32;

		// Token: 0x0400002F RID: 47
		protected internal DeviceContext ImmediateContext__;
	}
}
