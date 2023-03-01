using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000022 RID: 34
	[Guid("420d5b32-b90c-4da4-bef0-359f6a24a83a")]
	public class DeviceContext2 : DeviceContext1
	{
		// Token: 0x060001F9 RID: 505 RVA: 0x000093E1 File Offset: 0x000075E1
		public DeviceContext2(Device2 device) : base(IntPtr.Zero)
		{
			device.CreateDeferredContext2(0, this);
		}

		// Token: 0x060001FA RID: 506 RVA: 0x000093F6 File Offset: 0x000075F6
		public DeviceContext2(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060001FB RID: 507 RVA: 0x000093FF File Offset: 0x000075FF
		public new static explicit operator DeviceContext2(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DeviceContext2(nativePtr);
			}
			return null;
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060001FC RID: 508 RVA: 0x00009416 File Offset: 0x00007616
		public RawBool IsAnnotationEnabled
		{
			get
			{
				return this.IsAnnotationEnabled_();
			}
		}

		// Token: 0x060001FD RID: 509 RVA: 0x00009420 File Offset: 0x00007620
		public unsafe void UpdateTileMappings(Resource tiledResourceRef, int numTiledResourceRegions, TiledResourceCoordinate[] tiledResourceRegionStartCoordinatesRef, TileRegionSize[] tiledResourceRegionSizesRef, Buffer tilePoolRef, int numRanges, TileRangeFlags[] rangeFlagsRef, int[] tilePoolStartOffsetsRef, int[] rangeTileCountsRef, TileMappingFlags flags)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Resource>(tiledResourceRef);
			value2 = CppObject.ToCallbackPtr<Buffer>(tilePoolRef);
			Result result;
			fixed (int[] array = rangeTileCountsRef)
			{
				void* ptr;
				if (rangeTileCountsRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (int[] array2 = tilePoolStartOffsetsRef)
				{
					void* ptr2;
					if (tilePoolStartOffsetsRef == null || array2.Length == 0)
					{
						ptr2 = null;
					}
					else
					{
						ptr2 = (void*)(&array2[0]);
					}
					fixed (TileRangeFlags[] array3 = rangeFlagsRef)
					{
						void* ptr3;
						if (rangeFlagsRef == null || array3.Length == 0)
						{
							ptr3 = null;
						}
						else
						{
							ptr3 = (void*)(&array3[0]);
						}
						fixed (TileRegionSize[] array4 = tiledResourceRegionSizesRef)
						{
							void* ptr4;
							if (tiledResourceRegionSizesRef == null || array4.Length == 0)
							{
								ptr4 = null;
							}
							else
							{
								ptr4 = (void*)(&array4[0]);
							}
							fixed (TiledResourceCoordinate[] array5 = tiledResourceRegionStartCoordinatesRef)
							{
								void* ptr5;
								if (tiledResourceRegionStartCoordinatesRef == null || array5.Length == 0)
								{
									ptr5 = null;
								}
								else
								{
									ptr5 = (void*)(&array5[0]);
								}
								result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Void*,System.Void*,System.Int32,System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)value, numTiledResourceRegions, ptr5, ptr4, (void*)value2, numRanges, ptr3, ptr2, ptr, flags, *(*(IntPtr*)this._nativePointer + (IntPtr)134 * (IntPtr)sizeof(void*)));
							}
						}
					}
				}
			}
			result.CheckError();
		}

		// Token: 0x060001FE RID: 510 RVA: 0x00009534 File Offset: 0x00007734
		public unsafe void CopyTileMappings(Resource destTiledResourceRef, TiledResourceCoordinate destRegionStartCoordinateRef, Resource sourceTiledResourceRef, TiledResourceCoordinate sourceRegionStartCoordinateRef, TileRegionSize tileRegionSizeRef, TileMappingFlags flags)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Resource>(destTiledResourceRef);
			value2 = CppObject.ToCallbackPtr<Resource>(sourceTiledResourceRef);
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)value, &destRegionStartCoordinateRef, (void*)value2, &sourceRegionStartCoordinateRef, &tileRegionSizeRef, flags, *(*(IntPtr*)this._nativePointer + (IntPtr)135 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001FF RID: 511 RVA: 0x000095A0 File Offset: 0x000077A0
		public unsafe void CopyTiles(Resource tiledResourceRef, TiledResourceCoordinate tileRegionStartCoordinateRef, TileRegionSize tileRegionSizeRef, Buffer bufferRef, long bufferStartOffsetInBytes, TileMappingFlags flags)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Resource>(tiledResourceRef);
			value2 = CppObject.ToCallbackPtr<Buffer>(bufferRef);
			calli(System.Void(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Int64,System.Int32), this._nativePointer, (void*)value, &tileRegionStartCoordinateRef, &tileRegionSizeRef, (void*)value2, bufferStartOffsetInBytes, flags, *(*(IntPtr*)this._nativePointer + (IntPtr)136 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000200 RID: 512 RVA: 0x00009600 File Offset: 0x00007800
		public unsafe void UpdateTiles(Resource destTiledResourceRef, TiledResourceCoordinate destTileRegionStartCoordinateRef, TileRegionSize destTileRegionSizeRef, IntPtr sourceTileDataRef, TileMappingFlags flags)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Resource>(destTiledResourceRef);
			calli(System.Void(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)value, &destTileRegionStartCoordinateRef, &destTileRegionSizeRef, (void*)sourceTileDataRef, flags, *(*(IntPtr*)this._nativePointer + (IntPtr)137 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000201 RID: 513 RVA: 0x00009650 File Offset: 0x00007850
		public unsafe void ResizeTilePool(Buffer tilePoolRef, long newSizeInBytes)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Buffer>(tilePoolRef);
			calli(System.Int32(System.Void*,System.Void*,System.Int64), this._nativePointer, (void*)value, newSizeInBytes, *(*(IntPtr*)this._nativePointer + (IntPtr)138 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000202 RID: 514 RVA: 0x000096A0 File Offset: 0x000078A0
		public unsafe void TiledResourceBarrier(DeviceChild tiledResourceOrViewAccessBeforeBarrierRef, DeviceChild tiledResourceOrViewAccessAfterBarrierRef)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<DeviceChild>(tiledResourceOrViewAccessBeforeBarrierRef);
			value2 = CppObject.ToCallbackPtr<DeviceChild>(tiledResourceOrViewAccessAfterBarrierRef);
			calli(System.Void(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (void*)value2, *(*(IntPtr*)this._nativePointer + (IntPtr)139 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000203 RID: 515 RVA: 0x000096F4 File Offset: 0x000078F4
		internal unsafe RawBool IsAnnotationEnabled_()
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)140 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000204 RID: 516 RVA: 0x00009718 File Offset: 0x00007918
		public unsafe void SetMarkerInt(string labelRef, int data)
		{
			fixed (string text = labelRef)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				calli(System.Void(System.Void*,System.Void*,System.Int32), this._nativePointer, ptr, data, *(*(IntPtr*)this._nativePointer + (IntPtr)141 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000205 RID: 517 RVA: 0x0000975C File Offset: 0x0000795C
		public unsafe void BeginEventInt(string labelRef, int data)
		{
			fixed (string text = labelRef)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				calli(System.Void(System.Void*,System.Void*,System.Int32), this._nativePointer, ptr, data, *(*(IntPtr*)this._nativePointer + (IntPtr)142 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000206 RID: 518 RVA: 0x0000979E File Offset: 0x0000799E
		public unsafe void EndEvent()
		{
			calli(System.Void(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)143 * (IntPtr)sizeof(void*)));
		}
	}
}
