using System;
using System.Runtime.InteropServices;
using SharpDX.DXGI;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000015 RID: 21
	[Guid("9d06dffa-d1e5-4d07-83a8-1bb123f2f841")]
	public class Device2 : Device1
	{
		// Token: 0x060000B9 RID: 185 RVA: 0x00004A74 File Offset: 0x00002C74
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.ImmediateContext2__ != null)
			{
				this.ImmediateContext2__.Dispose();
				this.ImmediateContext2__ = null;
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00004A9A File Offset: 0x00002C9A
		public Device2(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00004AA3 File Offset: 0x00002CA3
		public new static explicit operator Device2(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Device2(nativePtr);
			}
			return null;
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000BC RID: 188 RVA: 0x00004ABA File Offset: 0x00002CBA
		public DeviceContext2 ImmediateContext2
		{
			get
			{
				if (this.ImmediateContext2__ == null)
				{
					this.GetImmediateContext2(out this.ImmediateContext2__);
				}
				return this.ImmediateContext2__;
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00004AD8 File Offset: 0x00002CD8
		internal unsafe void GetImmediateContext2(out DeviceContext2 immediateContextOut)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)50 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				immediateContextOut = new DeviceContext2(zero);
				return;
			}
			immediateContextOut = null;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00004B28 File Offset: 0x00002D28
		internal unsafe void CreateDeferredContext2(int contextFlags, DeviceContext2 deferredContextOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, contextFlags, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)51 * (IntPtr)sizeof(void*)));
			deferredContextOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00004B74 File Offset: 0x00002D74
		public unsafe void GetResourceTiling(Resource tiledResourceRef, out int numTilesForEntireResourceRef, out PackedMipDescription packedMipDescRef, out TileShape standardTileShapeForNonPackedMipsRef, ref int numSubresourceTilingsRef, int firstSubresourceTilingToGet, SubResourceTiling[] subresourceTilingsForNonPackedMipsRef)
		{
			IntPtr value = IntPtr.Zero;
			packedMipDescRef = default(PackedMipDescription);
			standardTileShapeForNonPackedMipsRef = default(TileShape);
			value = CppObject.ToCallbackPtr<Resource>(tiledResourceRef);
			fixed (SubResourceTiling[] array = subresourceTilingsForNonPackedMipsRef)
			{
				void* ptr;
				if (subresourceTilingsForNonPackedMipsRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (int* ptr2 = &numSubresourceTilingsRef)
				{
					void* ptr3 = (void*)ptr2;
					fixed (TileShape* ptr4 = &standardTileShapeForNonPackedMipsRef)
					{
						void* ptr5 = (void*)ptr4;
						fixed (PackedMipDescription* ptr6 = &packedMipDescRef)
						{
							void* ptr7 = (void*)ptr6;
							fixed (int* ptr8 = &numTilesForEntireResourceRef)
							{
								void* ptr9 = (void*)ptr8;
								calli(System.Void(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)value, ptr9, ptr7, ptr5, ptr3, firstSubresourceTilingToGet, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)52 * (IntPtr)sizeof(void*)));
							}
						}
					}
				}
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00004C18 File Offset: 0x00002E18
		public unsafe int CheckMultisampleQualityLevels1(Format format, int sampleCount, CheckMultisampleQualityLevelsFlags flags)
		{
			int result;
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Void*), this._nativePointer, format, sampleCount, flags, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)53 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x04000031 RID: 49
		protected internal DeviceContext2 ImmediateContext2__;
	}
}
