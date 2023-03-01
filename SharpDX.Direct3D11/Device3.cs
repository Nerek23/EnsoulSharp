using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000016 RID: 22
	[Guid("A05C8C37-D2C6-4732-B3A0-9CE0B0DC9AE6")]
	public class Device3 : Device2
	{
		// Token: 0x060000C1 RID: 193 RVA: 0x00004C57 File Offset: 0x00002E57
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.ImmediateContext3__ != null)
			{
				this.ImmediateContext3__.Dispose();
				this.ImmediateContext3__ = null;
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00004C7D File Offset: 0x00002E7D
		public Device3(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00004C86 File Offset: 0x00002E86
		public new static explicit operator Device3(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Device3(nativePtr);
			}
			return null;
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x00004C9D File Offset: 0x00002E9D
		public DeviceContext3 ImmediateContext3
		{
			get
			{
				if (this.ImmediateContext3__ == null)
				{
					this.GetImmediateContext3(out this.ImmediateContext3__);
				}
				return this.ImmediateContext3__;
			}
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00004CBC File Offset: 0x00002EBC
		internal unsafe void CreateTexture2D1(ref Texture2DDescription1 desc1Ref, DataBox[] initialDataRef, Texture2D1 texture2DOut)
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
				fixed (Texture2DDescription1* ptr2 = &desc1Ref)
				{
					void* ptr3 = (void*)ptr2;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, ptr3, ptr, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)54 * (IntPtr)sizeof(void*)));
				}
			}
			texture2DOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00004D30 File Offset: 0x00002F30
		internal unsafe void CreateTexture3D1(ref Texture3DDescription1 desc1Ref, DataBox[] initialDataRef, Texture3D1 texture3DOut)
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
				fixed (Texture3DDescription1* ptr2 = &desc1Ref)
				{
					void* ptr3 = (void*)ptr2;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, ptr3, ptr, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)55 * (IntPtr)sizeof(void*)));
				}
			}
			texture3DOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00004DA4 File Offset: 0x00002FA4
		internal unsafe void CreateRasterizerState2(ref RasterizerStateDescription2 rasterizerDescRef, RasterizerState2 rasterizerStateOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (RasterizerStateDescription2* ptr = &rasterizerDescRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)56 * (IntPtr)sizeof(void*)));
			}
			rasterizerStateOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00004DF8 File Offset: 0x00002FF8
		internal unsafe void CreateShaderResourceView1(Resource resourceRef, ShaderResourceViewDescription1? desc1Ref, ShaderResourceView1 sRView1Out)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Resource>(resourceRef);
			ShaderResourceViewDescription1 value2;
			if (desc1Ref != null)
			{
				value2 = desc1Ref.Value;
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (desc1Ref == null) ? null : (&value2), &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)57 * (IntPtr)sizeof(void*)));
			sRView1Out.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00004E74 File Offset: 0x00003074
		internal unsafe void CreateUnorderedAccessView1(Resource resourceRef, UnorderedAccessViewDescription1? desc1Ref, UnorderedAccessView1 uAView1Out)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Resource>(resourceRef);
			UnorderedAccessViewDescription1 value2;
			if (desc1Ref != null)
			{
				value2 = desc1Ref.Value;
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (desc1Ref == null) ? null : (&value2), &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)58 * (IntPtr)sizeof(void*)));
			uAView1Out.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00004EF0 File Offset: 0x000030F0
		internal unsafe void CreateRenderTargetView1(Resource resourceRef, RenderTargetViewDescription1? desc1Ref, RenderTargetView1 rTView1Out)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Resource>(resourceRef);
			RenderTargetViewDescription1 value2;
			if (desc1Ref != null)
			{
				value2 = desc1Ref.Value;
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, (desc1Ref == null) ? null : (&value2), &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)59 * (IntPtr)sizeof(void*)));
			rTView1Out.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00004F6C File Offset: 0x0000316C
		internal unsafe void CreateQuery1(QueryDescription1 queryDesc1Ref, Query1 query1Out)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &queryDesc1Ref, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)60 * (IntPtr)sizeof(void*)));
			query1Out.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00004FB8 File Offset: 0x000031B8
		internal unsafe void GetImmediateContext3(out DeviceContext3 immediateContextOut)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)61 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				immediateContextOut = new DeviceContext3(zero);
				return;
			}
			immediateContextOut = null;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00005008 File Offset: 0x00003208
		internal unsafe void CreateDeferredContext3(int contextFlags, DeviceContext3 deferredContextOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, contextFlags, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)62 * (IntPtr)sizeof(void*)));
			deferredContextOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00005054 File Offset: 0x00003254
		public unsafe void WriteToSubresource(Resource dstResourceRef, int dstSubresource, ResourceRegion? dstBoxRef, IntPtr srcDataRef, int srcRowPitch, int srcDepthPitch)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Resource>(dstResourceRef);
			ResourceRegion value2;
			if (dstBoxRef != null)
			{
				value2 = dstBoxRef.Value;
			}
			calli(System.Void(System.Void*,System.Void*,System.Int32,System.Void*,System.Void*,System.Int32,System.Int32), this._nativePointer, (void*)value, dstSubresource, (dstBoxRef == null) ? null : (&value2), (void*)srcDataRef, srcRowPitch, srcDepthPitch, *(*(IntPtr*)this._nativePointer + (IntPtr)63 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060000CF RID: 207 RVA: 0x000050C0 File Offset: 0x000032C0
		public unsafe void ReadFromSubresource(IntPtr dstDataRef, int dstRowPitch, int dstDepthPitch, Resource srcResourceRef, int srcSubresource, ResourceRegion? srcBoxRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Resource>(srcResourceRef);
			ResourceRegion value2;
			if (srcBoxRef != null)
			{
				value2 = srcBoxRef.Value;
			}
			calli(System.Void(System.Void*,System.Void*,System.Int32,System.Int32,System.Void*,System.Int32,System.Void*), this._nativePointer, (void*)dstDataRef, dstRowPitch, dstDepthPitch, (void*)value, srcSubresource, (srcBoxRef == null) ? null : (&value2), *(*(IntPtr*)this._nativePointer + (IntPtr)64 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x04000032 RID: 50
		protected internal DeviceContext3 ImmediateContext3__;
	}
}
