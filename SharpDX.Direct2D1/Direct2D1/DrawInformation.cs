using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001D2 RID: 466
	[Guid("693ce632-7f2f-45de-93fe-18d88b37aa21")]
	public class DrawInformation : RenderInformation
	{
		// Token: 0x06000962 RID: 2402 RVA: 0x0001B2E5 File Offset: 0x000194E5
		public void SetVertexConstantBuffer(DataStream dataStream)
		{
			this.SetVertexShaderConstantBuffer(dataStream.DataPointer, (int)dataStream.Length);
		}

		// Token: 0x06000963 RID: 2403 RVA: 0x0001B2FC File Offset: 0x000194FC
		public unsafe void SetVertexConstantBuffer<T>(T value) where T : struct
		{
			fixed (T* value2 = &value)
			{
				this.SetVertexShaderConstantBuffer((IntPtr)((void*)value2), Utilities.SizeOf<T>());
			}
		}

		// Token: 0x06000964 RID: 2404 RVA: 0x0001B320 File Offset: 0x00019520
		public unsafe void SetVertexConstantBuffer<T>(ref T value) where T : struct
		{
			fixed (T* value2 = &value)
			{
				this.SetVertexShaderConstantBuffer((IntPtr)((void*)value2), Utilities.SizeOf<T>());
			}
		}

		// Token: 0x06000965 RID: 2405 RVA: 0x0001B340 File Offset: 0x00019540
		public void SetPixelConstantBuffer(DataStream dataStream)
		{
			this.SetPixelShaderConstantBuffer(dataStream.DataPointer, (int)dataStream.Length);
		}

		// Token: 0x06000966 RID: 2406 RVA: 0x0001B358 File Offset: 0x00019558
		public unsafe void SetPixelConstantBuffer<T>(T value) where T : struct
		{
			fixed (T* value2 = &value)
			{
				this.SetPixelShaderConstantBuffer((IntPtr)((void*)value2), Utilities.SizeOf<T>());
			}
		}

		// Token: 0x06000967 RID: 2407 RVA: 0x0001B37C File Offset: 0x0001957C
		public unsafe void SetPixelConstantBuffer<T>(ref T value) where T : struct
		{
			fixed (T* value2 = &value)
			{
				this.SetPixelShaderConstantBuffer((IntPtr)((void*)value2), Utilities.SizeOf<T>());
			}
		}

		// Token: 0x06000968 RID: 2408 RVA: 0x00017F34 File Offset: 0x00016134
		public DrawInformation(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000969 RID: 2409 RVA: 0x0001B39C File Offset: 0x0001959C
		public new static explicit operator DrawInformation(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DrawInformation(nativePtr);
			}
			return null;
		}

		// Token: 0x0600096A RID: 2410 RVA: 0x0001B3B4 File Offset: 0x000195B4
		internal unsafe void SetPixelShaderConstantBuffer(IntPtr buffer, int bufferCount)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)buffer, bufferCount, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600096B RID: 2411 RVA: 0x0001B3F4 File Offset: 0x000195F4
		public unsafe void SetResourceTexture(int textureIndex, ResourceTexture resourceTexture)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<ResourceTexture>(resourceTexture);
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, textureIndex, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600096C RID: 2412 RVA: 0x0001B440 File Offset: 0x00019640
		internal unsafe void SetVertexShaderConstantBuffer(IntPtr buffer, int bufferCount)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)buffer, bufferCount, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x0001B480 File Offset: 0x00019680
		public unsafe void SetPixelShader(Guid shaderId, PixelOptions pixelOptions)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, &shaderId, pixelOptions, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x0001B4BC File Offset: 0x000196BC
		public unsafe void SetVertexProcessing(VertexBuffer vertexBuffer, VertexOptions vertexOptions, BlendDescription? blendDescription = null, VertexRange? vertexRange = null, Guid? vertexShader = null)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VertexBuffer>(vertexBuffer);
			BlendDescription value2;
			if (blendDescription != null)
			{
				value2 = blendDescription.Value;
			}
			VertexRange value3;
			if (vertexRange != null)
			{
				value3 = vertexRange.Value;
			}
			Guid value4;
			if (vertexShader != null)
			{
				value4 = vertexShader.Value;
			}
			calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, vertexOptions, (blendDescription == null) ? null : (&value2), (vertexRange == null) ? null : (&value3), (vertexShader == null) ? null : (&value4), *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
