using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001A8 RID: 424
	[Guid("5598b14b-9fd7-48b7-9bdb-8f0964eb38bc")]
	public class ComputeInformation : RenderInformation
	{
		// Token: 0x06000829 RID: 2089 RVA: 0x00017ED8 File Offset: 0x000160D8
		public void SetConstantBuffer(DataStream dataStream)
		{
			this.SetComputeShaderConstantBuffer(dataStream.DataPointer, (int)dataStream.Length);
		}

		// Token: 0x0600082A RID: 2090 RVA: 0x00017EF0 File Offset: 0x000160F0
		public unsafe void SetConstantBuffer<T>(T value) where T : struct
		{
			fixed (T* value2 = &value)
			{
				this.SetComputeShaderConstantBuffer((IntPtr)((void*)value2), Utilities.SizeOf<T>());
			}
		}

		// Token: 0x0600082B RID: 2091 RVA: 0x00017F14 File Offset: 0x00016114
		public unsafe void SetConstantBuffer<T>(ref T value) where T : struct
		{
			fixed (T* value2 = &value)
			{
				this.SetComputeShaderConstantBuffer((IntPtr)((void*)value2), Utilities.SizeOf<T>());
			}
		}

		// Token: 0x0600082C RID: 2092 RVA: 0x00017F34 File Offset: 0x00016134
		public ComputeInformation(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600082D RID: 2093 RVA: 0x00017F3D File Offset: 0x0001613D
		public new static explicit operator ComputeInformation(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ComputeInformation(nativePtr);
			}
			return null;
		}

		// Token: 0x1700013A RID: 314
		// (set) Token: 0x0600082E RID: 2094 RVA: 0x00017F54 File Offset: 0x00016154
		public Guid ComputeShader
		{
			set
			{
				this.SetComputeShader(value);
			}
		}

		// Token: 0x0600082F RID: 2095 RVA: 0x00017F60 File Offset: 0x00016160
		internal unsafe void SetComputeShaderConstantBuffer(IntPtr buffer, int bufferCount)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)buffer, bufferCount, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000830 RID: 2096 RVA: 0x00017FA0 File Offset: 0x000161A0
		internal unsafe void SetComputeShader(Guid shaderId)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &shaderId, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000831 RID: 2097 RVA: 0x00017FDC File Offset: 0x000161DC
		public unsafe void SetResourceTexture(int textureIndex, ResourceTexture resourceTexture)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<ResourceTexture>(resourceTexture);
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, textureIndex, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
