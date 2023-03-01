using System;
using System.Globalization;
using System.Runtime.InteropServices;
using SharpDX.DXGI;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200001C RID: 28
	[Guid("c0bfa96c-e089-44fb-8eaf-26f8796190da")]
	public class DeviceContext : DeviceChild
	{
		// Token: 0x0600011A RID: 282 RVA: 0x00005D11 File Offset: 0x00003F11
		public DeviceContext(Device device) : base(IntPtr.Zero)
		{
			device.CreateDeferredContext(0, this);
			((IUnknown)device).AddReference();
			this.Device__ = device;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00005D34 File Offset: 0x00003F34
		public CommandList FinishCommandList(bool restoreState)
		{
			CommandList result;
			this.FinishCommandListInternal(restoreState, out result);
			return result;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00005D50 File Offset: 0x00003F50
		public bool IsDataAvailable(Asynchronous data)
		{
			return this.IsDataAvailable(data, AsynchronousFlags.None);
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00005D5A File Offset: 0x00003F5A
		public bool IsDataAvailable(Asynchronous data, AsynchronousFlags flags)
		{
			return this.GetDataInternal(data, IntPtr.Zero, 0, flags) == Result.Ok;
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00005D74 File Offset: 0x00003F74
		public DataStream GetData(Asynchronous data)
		{
			return this.GetData(data, AsynchronousFlags.None);
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00005D7E File Offset: 0x00003F7E
		public T GetData<T>(Asynchronous data) where T : struct
		{
			return this.GetData<T>(data, AsynchronousFlags.None);
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00005D88 File Offset: 0x00003F88
		public bool GetData<T>(Asynchronous data, out T result) where T : struct
		{
			return this.GetData<T>(data, AsynchronousFlags.None, out result);
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00005D94 File Offset: 0x00003F94
		public DataStream GetData(Asynchronous data, AsynchronousFlags flags)
		{
			DataStream dataStream = new DataStream(data.DataSize, true, true);
			this.GetDataInternal(data, dataStream.DataPointer, (int)dataStream.Length, flags);
			return dataStream;
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00005DC8 File Offset: 0x00003FC8
		public T GetData<T>(Asynchronous data, AsynchronousFlags flags) where T : struct
		{
			T result;
			this.GetData<T>(data, flags, out result);
			return result;
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00005DE4 File Offset: 0x00003FE4
		public unsafe bool GetData<T>(Asynchronous data, AsynchronousFlags flags, out T result) where T : struct
		{
			result = default(T);
			fixed (T* value = &result)
			{
				return this.GetDataInternal(data, (IntPtr)((void*)value), Utilities.SizeOf<T>(), flags) == Result.Ok;
			}
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00005E17 File Offset: 0x00004017
		public void CopyResource(Resource source, Resource destination)
		{
			this.CopyResource_(destination, source);
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00005E24 File Offset: 0x00004024
		public void CopySubresourceRegion(Resource source, int sourceSubresource, ResourceRegion? sourceRegion, Resource destination, int destinationSubResource, int dstX = 0, int dstY = 0, int dstZ = 0)
		{
			this.CopySubresourceRegion_(destination, destinationSubResource, dstX, dstY, dstZ, source, sourceSubresource, sourceRegion);
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00005E44 File Offset: 0x00004044
		public void ResolveSubresource(Resource source, int sourceSubresource, Resource destination, int destinationSubresource, Format format)
		{
			this.ResolveSubresource_(destination, destinationSubresource, source, sourceSubresource, format);
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00005E54 File Offset: 0x00004054
		public DataBox MapSubresource(Texture1D resource, int mipSlice, int arraySlice, MapMode mode, MapFlags flags, out DataStream stream)
		{
			int num;
			DataBox dataBox = this.MapSubresource(resource, mipSlice, arraySlice, mode, flags, out num);
			stream = new DataStream(dataBox.DataPointer, (long)(num * resource.Description.Format.SizeOfInBytes()), true, true);
			return dataBox;
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00005E98 File Offset: 0x00004098
		public DataBox MapSubresource(Texture2D resource, int mipSlice, int arraySlice, MapMode mode, MapFlags flags, out DataStream stream)
		{
			int num;
			DataBox dataBox = this.MapSubresource(resource, mipSlice, arraySlice, mode, flags, out num);
			stream = new DataStream(dataBox.DataPointer, (long)(num * dataBox.RowPitch), true, true);
			return dataBox;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00005ED0 File Offset: 0x000040D0
		public DataBox MapSubresource(Texture3D resource, int mipSlice, int arraySlice, MapMode mode, MapFlags flags, out DataStream stream)
		{
			int num;
			DataBox dataBox = this.MapSubresource(resource, mipSlice, arraySlice, mode, flags, out num);
			stream = new DataStream(dataBox.DataPointer, (long)(num * dataBox.SlicePitch), true, true);
			return dataBox;
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00005F08 File Offset: 0x00004108
		public DataBox MapSubresource(Buffer resource, MapMode mode, MapFlags flags, out DataStream stream)
		{
			DataBox dataBox = this.MapSubresource(resource, 0, mode, flags);
			stream = new DataStream(dataBox.DataPointer, (long)resource.Description.SizeInBytes, true, true);
			return dataBox;
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00005F40 File Offset: 0x00004140
		public DataBox MapSubresource(Resource resource, int mipSlice, int arraySlice, MapMode mode, MapFlags flags, out int mipSize)
		{
			int subresource = resource.CalculateSubResourceIndex(mipSlice, arraySlice, out mipSize);
			return this.MapSubresource(resource, subresource, mode, flags);
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00005F64 File Offset: 0x00004164
		public DataBox MapSubresource(Resource resource, int subresource, MapMode mode, MapFlags flags, out DataStream stream)
		{
			switch (resource.Dimension)
			{
			case ResourceDimension.Buffer:
				return this.MapSubresource((Buffer)resource, mode, flags, out stream);
			case ResourceDimension.Texture1D:
			{
				Texture1D texture1D = (Texture1D)resource;
				int mipLevels = texture1D.Description.MipLevels;
				return this.MapSubresource(texture1D, subresource % mipLevels, subresource / mipLevels, mode, flags, out stream);
			}
			case ResourceDimension.Texture2D:
			{
				Texture2D texture2D = (Texture2D)resource;
				int mipLevels = texture2D.Description.MipLevels;
				return this.MapSubresource(texture2D, subresource % mipLevels, subresource / mipLevels, mode, flags, out stream);
			}
			case ResourceDimension.Texture3D:
			{
				Texture3D texture3D = (Texture3D)resource;
				int mipLevels = texture3D.Description.MipLevels;
				return this.MapSubresource(texture3D, subresource % mipLevels, subresource / mipLevels, mode, flags, out stream);
			}
			default:
				throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "MapSubresource is not supported for Resource [{0}]", new object[]
				{
					resource.Dimension
				}));
			}
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00006044 File Offset: 0x00004244
		public DataBox MapSubresource(Resource resourceRef, int subresource, MapMode mapType, MapFlags mapFlags)
		{
			DataBox result = default(DataBox);
			Result left = this.MapSubresource(resourceRef, subresource, mapType, mapFlags, out result);
			if ((mapFlags & MapFlags.DoNotWait) != MapFlags.None && left == ResultCode.WasStillDrawing)
			{
				return result;
			}
			left.CheckError();
			return result;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00006090 File Offset: 0x00004290
		public unsafe void UpdateSubresource<T>(ref T data, Resource resource, int subresource = 0, int rowPitch = 0, int depthPitch = 0, ResourceRegion? region = null) where T : struct
		{
			fixed (T* value = &data)
			{
				this.UpdateSubresource(resource, subresource, region, (IntPtr)((void*)value), rowPitch, depthPitch);
			}
		}

		// Token: 0x0600012F RID: 303 RVA: 0x000060B4 File Offset: 0x000042B4
		public unsafe void UpdateSubresource<T>(T[] data, Resource resource, int subresource = 0, int rowPitch = 0, int depthPitch = 0, ResourceRegion? region = null) where T : struct
		{
			fixed (T* value = &data[0])
			{
				this.UpdateSubresource(resource, subresource, region, (IntPtr)((void*)value), rowPitch, depthPitch);
			}
		}

		// Token: 0x06000130 RID: 304 RVA: 0x000060E0 File Offset: 0x000042E0
		public void UpdateSubresource(DataBox source, Resource resource, int subresource = 0)
		{
			this.UpdateSubresource(resource, subresource, null, source.DataPointer, source.RowPitch, source.SlicePitch);
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00006110 File Offset: 0x00004310
		public void UpdateSubresource(DataBox source, Resource resource, int subresource, ResourceRegion region)
		{
			this.UpdateSubresource(resource, subresource, new ResourceRegion?(region), source.DataPointer, source.RowPitch, source.SlicePitch);
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00006134 File Offset: 0x00004334
		public unsafe void UpdateSubresourceSafe<T>(ref T data, Resource resource, int srcBytesPerElement, int subresource = 0, int rowPitch = 0, int depthPitch = 0, bool isCompressedResource = false) where T : struct
		{
			ResourceRegion? dstBoxRef = null;
			fixed (T* value = &data)
			{
				this.UpdateSubresourceSafe(resource, subresource, dstBoxRef, (IntPtr)((void*)value), rowPitch, depthPitch, srcBytesPerElement, isCompressedResource);
			}
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00006164 File Offset: 0x00004364
		public unsafe void UpdateSubresourceSafe<T>(T[] data, Resource resource, int srcBytesPerElement, int subresource = 0, int rowPitch = 0, int depthPitch = 0, bool isCompressedResource = false) where T : struct
		{
			ResourceRegion? dstBoxRef = null;
			fixed (T* value = &data[0])
			{
				this.UpdateSubresourceSafe(resource, subresource, dstBoxRef, (IntPtr)((void*)value), rowPitch, depthPitch, srcBytesPerElement, isCompressedResource);
			}
		}

		// Token: 0x06000134 RID: 308 RVA: 0x0000619C File Offset: 0x0000439C
		public void UpdateSubresourceSafe(DataBox source, Resource resource, int srcBytesPerElement, int subresource = 0, bool isCompressedResource = false)
		{
			this.UpdateSubresourceSafe(resource, subresource, null, source.DataPointer, source.RowPitch, source.SlicePitch, srcBytesPerElement, isCompressedResource);
		}

		// Token: 0x06000135 RID: 309 RVA: 0x000061D4 File Offset: 0x000043D4
		public void UpdateSubresourceSafe(DataBox source, Resource resource, int srcBytesPerElement, int subresource, ResourceRegion region, bool isCompressedResource = false)
		{
			this.UpdateSubresourceSafe(resource, subresource, new ResourceRegion?(region), source.DataPointer, source.RowPitch, source.SlicePitch, srcBytesPerElement, isCompressedResource);
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00006208 File Offset: 0x00004408
		internal unsafe bool UpdateSubresourceSafe(Resource dstResourceRef, int dstSubresource, ResourceRegion? dstBoxRef, IntPtr pSrcData, int srcRowPitch, int srcDepthPitch, int srcBytesPerElement, bool isCompressedResource)
		{
			bool flag = false;
			if (!this.isCheckThreadingSupport)
			{
				bool flag2;
				base.Device.CheckThreadingSupport(out flag2, out this.supportsCommandLists);
				this.isCheckThreadingSupport = true;
			}
			if (dstBoxRef != null && this.TypeInfo == DeviceContextType.Deferred)
			{
				flag = !this.supportsCommandLists;
			}
			IntPtr srcDataRef = pSrcData;
			if (flag)
			{
				ResourceRegion value = dstBoxRef.Value;
				if (isCompressedResource)
				{
					value.Left /= 4;
					value.Right /= 4;
					value.Top /= 4;
					value.Bottom /= 4;
				}
				srcDataRef = (IntPtr)((void*)((byte*)((byte*)((byte*)((void*)pSrcData) - value.Front * srcDepthPitch) - value.Top * srcRowPitch) - value.Left * srcBytesPerElement));
			}
			this.UpdateSubresource(dstResourceRef, dstSubresource, dstBoxRef, srcDataRef, srcRowPitch, srcDepthPitch);
			return flag;
		}

		// Token: 0x06000137 RID: 311 RVA: 0x000062D4 File Offset: 0x000044D4
		public DeviceContext(IntPtr nativePtr) : base(nativePtr)
		{
			this.VertexShader = new VertexShaderStage(nativePtr);
			this.PixelShader = new PixelShaderStage(nativePtr);
			this.InputAssembler = new InputAssemblerStage(nativePtr);
			this.GeometryShader = new GeometryShaderStage(nativePtr);
			this.OutputMerger = new OutputMergerStage(nativePtr);
			this.StreamOutput = new StreamOutputStage(nativePtr);
			this.Rasterizer = new RasterizerStage(nativePtr);
			this.HullShader = new HullShaderStage(nativePtr);
			this.DomainShader = new DomainShaderStage(nativePtr);
			this.ComputeShader = new ComputeShaderStage(nativePtr);
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00006360 File Offset: 0x00004560
		public new static explicit operator DeviceContext(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DeviceContext(nativePtr);
			}
			return null;
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00006378 File Offset: 0x00004578
		protected override void NativePointerUpdated(IntPtr oldPointer)
		{
			base.NativePointerUpdated(oldPointer);
			if (this.VertexShader == null)
			{
				this.VertexShader = new VertexShaderStage(IntPtr.Zero);
			}
			this.VertexShader.NativePointer = base.NativePointer;
			if (this.PixelShader == null)
			{
				this.PixelShader = new PixelShaderStage(IntPtr.Zero);
			}
			this.PixelShader.NativePointer = base.NativePointer;
			if (this.InputAssembler == null)
			{
				this.InputAssembler = new InputAssemblerStage(IntPtr.Zero);
			}
			this.InputAssembler.NativePointer = base.NativePointer;
			if (this.GeometryShader == null)
			{
				this.GeometryShader = new GeometryShaderStage(IntPtr.Zero);
			}
			this.GeometryShader.NativePointer = base.NativePointer;
			if (this.OutputMerger == null)
			{
				this.OutputMerger = new OutputMergerStage(IntPtr.Zero);
			}
			this.OutputMerger.NativePointer = base.NativePointer;
			if (this.StreamOutput == null)
			{
				this.StreamOutput = new StreamOutputStage(IntPtr.Zero);
			}
			this.StreamOutput.NativePointer = base.NativePointer;
			if (this.Rasterizer == null)
			{
				this.Rasterizer = new RasterizerStage(IntPtr.Zero);
			}
			this.Rasterizer.NativePointer = base.NativePointer;
			if (this.HullShader == null)
			{
				this.HullShader = new HullShaderStage(IntPtr.Zero);
			}
			this.HullShader.NativePointer = base.NativePointer;
			if (this.DomainShader == null)
			{
				this.DomainShader = new DomainShaderStage(IntPtr.Zero);
			}
			this.DomainShader.NativePointer = base.NativePointer;
			if (this.ComputeShader == null)
			{
				this.ComputeShader = new ComputeShaderStage(IntPtr.Zero);
			}
			this.ComputeShader.NativePointer = base.NativePointer;
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600013A RID: 314 RVA: 0x00006526 File Offset: 0x00004726
		// (set) Token: 0x0600013B RID: 315 RVA: 0x0000652E File Offset: 0x0000472E
		public VertexShaderStage VertexShader { get; private set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600013C RID: 316 RVA: 0x00006537 File Offset: 0x00004737
		// (set) Token: 0x0600013D RID: 317 RVA: 0x0000653F File Offset: 0x0000473F
		public PixelShaderStage PixelShader { get; private set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600013E RID: 318 RVA: 0x00006548 File Offset: 0x00004748
		// (set) Token: 0x0600013F RID: 319 RVA: 0x00006550 File Offset: 0x00004750
		public InputAssemblerStage InputAssembler { get; private set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000140 RID: 320 RVA: 0x00006559 File Offset: 0x00004759
		// (set) Token: 0x06000141 RID: 321 RVA: 0x00006561 File Offset: 0x00004761
		public GeometryShaderStage GeometryShader { get; private set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000142 RID: 322 RVA: 0x0000656A File Offset: 0x0000476A
		// (set) Token: 0x06000143 RID: 323 RVA: 0x00006572 File Offset: 0x00004772
		public OutputMergerStage OutputMerger { get; private set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000144 RID: 324 RVA: 0x0000657B File Offset: 0x0000477B
		// (set) Token: 0x06000145 RID: 325 RVA: 0x00006583 File Offset: 0x00004783
		public StreamOutputStage StreamOutput { get; private set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000146 RID: 326 RVA: 0x0000658C File Offset: 0x0000478C
		// (set) Token: 0x06000147 RID: 327 RVA: 0x00006594 File Offset: 0x00004794
		public RasterizerStage Rasterizer { get; private set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000148 RID: 328 RVA: 0x0000659D File Offset: 0x0000479D
		// (set) Token: 0x06000149 RID: 329 RVA: 0x000065A5 File Offset: 0x000047A5
		public HullShaderStage HullShader { get; private set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600014A RID: 330 RVA: 0x000065AE File Offset: 0x000047AE
		// (set) Token: 0x0600014B RID: 331 RVA: 0x000065B6 File Offset: 0x000047B6
		public DomainShaderStage DomainShader { get; private set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600014C RID: 332 RVA: 0x000065BF File Offset: 0x000047BF
		// (set) Token: 0x0600014D RID: 333 RVA: 0x000065C7 File Offset: 0x000047C7
		public ComputeShaderStage ComputeShader { get; private set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600014E RID: 334 RVA: 0x000065D0 File Offset: 0x000047D0
		public DeviceContextType TypeInfo
		{
			get
			{
				return this.GetTypeInfo();
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600014F RID: 335 RVA: 0x000065D8 File Offset: 0x000047D8
		public int ContextFlags
		{
			get
			{
				return this.GetContextFlags();
			}
		}

		// Token: 0x06000150 RID: 336 RVA: 0x000065E0 File Offset: 0x000047E0
		public unsafe void DrawIndexed(int indexCount, int startIndexLocation, int baseVertexLocation)
		{
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Int32), this._nativePointer, indexCount, startIndexLocation, baseVertexLocation, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00006603 File Offset: 0x00004803
		public unsafe void Draw(int vertexCount, int startVertexLocation)
		{
			calli(System.Void(System.Void*,System.Int32,System.Int32), this._nativePointer, vertexCount, startVertexLocation, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00006628 File Offset: 0x00004828
		internal unsafe Result MapSubresource(Resource resourceRef, int subresource, MapMode mapType, MapFlags mapFlags, out DataBox mappedResourceRef)
		{
			IntPtr value = IntPtr.Zero;
			mappedResourceRef = default(DataBox);
			value = CppObject.ToCallbackPtr<Resource>(resourceRef);
			Result result;
			fixed (DataBox* ptr = &mappedResourceRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Int32,System.Int32,System.Void*), this._nativePointer, (void*)value, subresource, mapType, mapFlags, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
			}
			return result;
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00006684 File Offset: 0x00004884
		public unsafe void UnmapSubresource(Resource resourceRef, int subresource)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Resource>(resourceRef);
			calli(System.Void(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)value, subresource, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000154 RID: 340 RVA: 0x000066C4 File Offset: 0x000048C4
		public unsafe void DrawIndexedInstanced(int indexCountPerInstance, int instanceCount, int startIndexLocation, int baseVertexLocation, int startInstanceLocation)
		{
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), this._nativePointer, indexCountPerInstance, instanceCount, startIndexLocation, baseVertexLocation, startInstanceLocation, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000155 RID: 341 RVA: 0x000066F6 File Offset: 0x000048F6
		public unsafe void DrawInstanced(int vertexCountPerInstance, int instanceCount, int startVertexLocation, int startInstanceLocation)
		{
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Int32,System.Int32), this._nativePointer, vertexCountPerInstance, instanceCount, startVertexLocation, startInstanceLocation, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000156 RID: 342 RVA: 0x0000671C File Offset: 0x0000491C
		public unsafe void Begin(Asynchronous asyncRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Asynchronous>(asyncRef);
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)27 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000157 RID: 343 RVA: 0x0000675C File Offset: 0x0000495C
		public unsafe void End(Asynchronous asyncRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Asynchronous>(asyncRef);
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)28 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000158 RID: 344 RVA: 0x0000679C File Offset: 0x0000499C
		internal unsafe Result GetDataInternal(Asynchronous asyncRef, IntPtr dataRef, int dataSize, AsynchronousFlags getDataFlags)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Asynchronous>(asyncRef);
			return calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32,System.Int32), this._nativePointer, (void*)value, (void*)dataRef, dataSize, getDataFlags, *(*(IntPtr*)this._nativePointer + (IntPtr)29 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000159 RID: 345 RVA: 0x000067E8 File Offset: 0x000049E8
		public unsafe void SetPredication(Predicate predicateRef, RawBool predicateValue)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Predicate>(predicateRef);
			calli(System.Void(System.Void*,System.Void*,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, (void*)value, predicateValue, *(*(IntPtr*)this._nativePointer + (IntPtr)30 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00006827 File Offset: 0x00004A27
		public unsafe void DrawAuto()
		{
			calli(System.Void(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)38 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00006848 File Offset: 0x00004A48
		public unsafe void DrawIndexedInstancedIndirect(Buffer bufferForArgsRef, int alignedByteOffsetForArgs)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Buffer>(bufferForArgsRef);
			calli(System.Void(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)value, alignedByteOffsetForArgs, *(*(IntPtr*)this._nativePointer + (IntPtr)39 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00006888 File Offset: 0x00004A88
		public unsafe void DrawInstancedIndirect(Buffer bufferForArgsRef, int alignedByteOffsetForArgs)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Buffer>(bufferForArgsRef);
			calli(System.Void(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)value, alignedByteOffsetForArgs, *(*(IntPtr*)this._nativePointer + (IntPtr)40 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600015D RID: 349 RVA: 0x000068C7 File Offset: 0x00004AC7
		public unsafe void Dispatch(int threadGroupCountX, int threadGroupCountY, int threadGroupCountZ)
		{
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Int32), this._nativePointer, threadGroupCountX, threadGroupCountY, threadGroupCountZ, *(*(IntPtr*)this._nativePointer + (IntPtr)41 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600015E RID: 350 RVA: 0x000068EC File Offset: 0x00004AEC
		public unsafe void DispatchIndirect(Buffer bufferForArgsRef, int alignedByteOffsetForArgs)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Buffer>(bufferForArgsRef);
			calli(System.Void(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)value, alignedByteOffsetForArgs, *(*(IntPtr*)this._nativePointer + (IntPtr)42 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600015F RID: 351 RVA: 0x0000692C File Offset: 0x00004B2C
		internal unsafe void CopySubresourceRegion_(Resource dstResourceRef, int dstSubresource, int dstX, int dstY, int dstZ, Resource srcResourceRef, int srcSubresource, ResourceRegion? srcBoxRef)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Resource>(dstResourceRef);
			value2 = CppObject.ToCallbackPtr<Resource>(srcResourceRef);
			ResourceRegion value3;
			if (srcBoxRef != null)
			{
				value3 = srcBoxRef.Value;
			}
			calli(System.Void(System.Void*,System.Void*,System.Int32,System.Int32,System.Int32,System.Int32,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)value, dstSubresource, dstX, dstY, dstZ, (void*)value2, srcSubresource, (srcBoxRef == null) ? null : (&value3), *(*(IntPtr*)this._nativePointer + (IntPtr)46 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000160 RID: 352 RVA: 0x000069A8 File Offset: 0x00004BA8
		internal unsafe void CopyResource_(Resource dstResourceRef, Resource srcResourceRef)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Resource>(dstResourceRef);
			value2 = CppObject.ToCallbackPtr<Resource>(srcResourceRef);
			calli(System.Void(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)value2, *(*(IntPtr*)this._nativePointer + (IntPtr)47 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000161 RID: 353 RVA: 0x000069FC File Offset: 0x00004BFC
		public unsafe void UpdateSubresource(Resource dstResourceRef, int dstSubresource, ResourceRegion? dstBoxRef, IntPtr srcDataRef, int srcRowPitch, int srcDepthPitch)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Resource>(dstResourceRef);
			ResourceRegion value2;
			if (dstBoxRef != null)
			{
				value2 = dstBoxRef.Value;
			}
			calli(System.Void(System.Void*,System.Void*,System.Int32,System.Void*,System.Void*,System.Int32,System.Int32), this._nativePointer, (void*)value, dstSubresource, (dstBoxRef == null) ? null : (&value2), (void*)srcDataRef, srcRowPitch, srcDepthPitch, *(*(IntPtr*)this._nativePointer + (IntPtr)48 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00006A68 File Offset: 0x00004C68
		public unsafe void CopyStructureCount(Buffer dstBufferRef, int dstAlignedByteOffset, UnorderedAccessView srcViewRef)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Buffer>(dstBufferRef);
			value2 = CppObject.ToCallbackPtr<UnorderedAccessView>(srcViewRef);
			calli(System.Void(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)value, dstAlignedByteOffset, (void*)value2, *(*(IntPtr*)this._nativePointer + (IntPtr)49 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00006ABC File Offset: 0x00004CBC
		public unsafe void ClearRenderTargetView(RenderTargetView renderTargetViewRef, RawColor4 colorRGBA)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<RenderTargetView>(renderTargetViewRef);
			calli(System.Void(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &colorRGBA, *(*(IntPtr*)this._nativePointer + (IntPtr)50 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00006B00 File Offset: 0x00004D00
		public unsafe void ClearUnorderedAccessView(UnorderedAccessView unorderedAccessViewRef, RawInt4 values)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<UnorderedAccessView>(unorderedAccessViewRef);
			calli(System.Void(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &values, *(*(IntPtr*)this._nativePointer + (IntPtr)51 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00006B44 File Offset: 0x00004D44
		public unsafe void ClearUnorderedAccessView(UnorderedAccessView unorderedAccessViewRef, RawVector4 values)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<UnorderedAccessView>(unorderedAccessViewRef);
			calli(System.Void(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &values, *(*(IntPtr*)this._nativePointer + (IntPtr)52 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00006B88 File Offset: 0x00004D88
		public unsafe void ClearDepthStencilView(DepthStencilView depthStencilViewRef, DepthStencilClearFlags clearFlags, float depth, byte stencil)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<DepthStencilView>(depthStencilViewRef);
			calli(System.Void(System.Void*,System.Void*,System.Int32,System.Single,System.Byte), this._nativePointer, (void*)value, clearFlags, depth, stencil, *(*(IntPtr*)this._nativePointer + (IntPtr)53 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00006BCC File Offset: 0x00004DCC
		public unsafe void GenerateMips(ShaderResourceView shaderResourceViewRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<ShaderResourceView>(shaderResourceViewRef);
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)54 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00006C0C File Offset: 0x00004E0C
		public unsafe void SetMinimumLod(Resource resourceRef, float minLOD)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Resource>(resourceRef);
			calli(System.Void(System.Void*,System.Void*,System.Single), this._nativePointer, (void*)value, minLOD, *(*(IntPtr*)this._nativePointer + (IntPtr)55 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00006C4C File Offset: 0x00004E4C
		public unsafe float GetMinimumLod(Resource resourceRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Resource>(resourceRef);
			return calli(System.Single(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)56 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00006C8C File Offset: 0x00004E8C
		internal unsafe void ResolveSubresource_(Resource dstResourceRef, int dstSubresource, Resource srcResourceRef, int srcSubresource, Format format)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Resource>(dstResourceRef);
			value2 = CppObject.ToCallbackPtr<Resource>(srcResourceRef);
			calli(System.Void(System.Void*,System.Void*,System.Int32,System.Void*,System.Int32,System.Int32), this._nativePointer, (void*)value, dstSubresource, (void*)value2, srcSubresource, format, *(*(IntPtr*)this._nativePointer + (IntPtr)57 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00006CE4 File Offset: 0x00004EE4
		public unsafe void ExecuteCommandList(CommandList commandListRef, RawBool restoreContextState)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<CommandList>(commandListRef);
			calli(System.Void(System.Void*,System.Void*,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, (void*)value, restoreContextState, *(*(IntPtr*)this._nativePointer + (IntPtr)58 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00006D24 File Offset: 0x00004F24
		public unsafe Predicate GetPredication(out RawBool predicateValueRef)
		{
			IntPtr zero = IntPtr.Zero;
			predicateValueRef = default(RawBool);
			fixed (RawBool* ptr = &predicateValueRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*,System.Void*), this._nativePointer, &zero, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)86 * (IntPtr)sizeof(void*)));
			}
			Predicate result;
			if (zero != IntPtr.Zero)
			{
				result = new Predicate(zero);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00006D81 File Offset: 0x00004F81
		public unsafe void ClearState()
		{
			calli(System.Void(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)110 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00006DA1 File Offset: 0x00004FA1
		public unsafe void Flush()
		{
			calli(System.Void(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)111 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00006DC1 File Offset: 0x00004FC1
		internal unsafe DeviceContextType GetTypeInfo()
		{
			return calli(SharpDX.Direct3D11.DeviceContextType(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)112 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00006DE1 File Offset: 0x00004FE1
		internal unsafe int GetContextFlags()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)113 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00006E04 File Offset: 0x00005004
		internal unsafe void FinishCommandListInternal(RawBool restoreDeferredContextState, out CommandList commandListOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,SharpDX.Mathematics.Interop.RawBool,System.Void*), this._nativePointer, restoreDeferredContextState, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)114 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				commandListOut = new CommandList(zero);
			}
			else
			{
				commandListOut = null;
			}
			result.CheckError();
		}

		// Token: 0x0400006D RID: 109
		private bool isCheckThreadingSupport;

		// Token: 0x0400006E RID: 110
		private bool supportsCommandLists;
	}
}
