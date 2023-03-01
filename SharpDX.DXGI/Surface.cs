using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000024 RID: 36
	[Guid("cafcb56c-6ac3-4889-bf47-9e23bbd260ec")]
	public class Surface : DeviceChild
	{
		// Token: 0x060000EF RID: 239 RVA: 0x00004B94 File Offset: 0x00002D94
		public DataRectangle Map(MapFlags flags)
		{
			MappedRectangle mappedRectangle;
			this.Map(out mappedRectangle, (int)flags);
			return new DataRectangle(mappedRectangle.PBits, mappedRectangle.Pitch);
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00004BBC File Offset: 0x00002DBC
		public DataRectangle Map(MapFlags flags, out DataStream dataStream)
		{
			DataRectangle dataRectangle = this.Map(flags);
			dataStream = new DataStream(dataRectangle.DataPointer, (long)(this.Description.Height * dataRectangle.Pitch), true, true);
			return dataRectangle;
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00004BF4 File Offset: 0x00002DF4
		public static Surface FromSwapChain(SwapChain swapChain, int index)
		{
			IntPtr nativePtr;
			swapChain.GetBuffer(index, Utilities.GetGuidFromType(typeof(Surface)), out nativePtr);
			return new Surface(nativePtr);
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00004C1F File Offset: 0x00002E1F
		public Surface(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00004C28 File Offset: 0x00002E28
		public new static explicit operator Surface(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Surface(nativePtr);
			}
			return null;
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060000F4 RID: 244 RVA: 0x00004C40 File Offset: 0x00002E40
		public SurfaceDescription Description
		{
			get
			{
				SurfaceDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00004C58 File Offset: 0x00002E58
		internal unsafe void GetDescription(out SurfaceDescription descRef)
		{
			descRef = default(SurfaceDescription);
			Result result;
			fixed (SurfaceDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00004CA0 File Offset: 0x00002EA0
		internal unsafe void Map(out MappedRectangle lockedRectRef, int mapFlags)
		{
			lockedRectRef = default(MappedRectangle);
			Result result;
			fixed (MappedRectangle* ptr = &lockedRectRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, ptr2, mapFlags, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00004CEC File Offset: 0x00002EEC
		public unsafe void Unmap()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
