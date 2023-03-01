using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000AF RID: 175
	[Guid("79aab587-6dbc-4fa7-82de-37fa1781c5ce")]
	public class EffectStateManager : ComObject
	{
		// Token: 0x060004A6 RID: 1190 RVA: 0x00002623 File Offset: 0x00000823
		public EffectStateManager(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x000116FF File Offset: 0x0000F8FF
		public new static explicit operator EffectStateManager(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new EffectStateManager(nativePointer);
			}
			return null;
		}

		// Token: 0x17000052 RID: 82
		// (set) Token: 0x060004A8 RID: 1192 RVA: 0x00011716 File Offset: 0x0000F916
		public Material Material
		{
			set
			{
				this.SetMaterial(ref value);
			}
		}

		// Token: 0x17000053 RID: 83
		// (set) Token: 0x060004A9 RID: 1193 RVA: 0x00011720 File Offset: 0x0000F920
		public float NPatchMode
		{
			set
			{
				this.SetNPatchMode(value);
			}
		}

		// Token: 0x17000054 RID: 84
		// (set) Token: 0x060004AA RID: 1194 RVA: 0x00011729 File Offset: 0x0000F929
		public VertexFormat VertexFormat
		{
			set
			{
				this.SetVertexFormat(value);
			}
		}

		// Token: 0x17000055 RID: 85
		// (set) Token: 0x060004AB RID: 1195 RVA: 0x00011732 File Offset: 0x0000F932
		public VertexShader VertexShader
		{
			set
			{
				this.SetVertexShader(value);
			}
		}

		// Token: 0x17000056 RID: 86
		// (set) Token: 0x060004AC RID: 1196 RVA: 0x0001173B File Offset: 0x0000F93B
		public PixelShader PixelShader
		{
			set
			{
				this.SetPixelShader(value);
			}
		}

		// Token: 0x060004AD RID: 1197 RVA: 0x00011744 File Offset: 0x0000F944
		public unsafe void SetTransform(TransformState state, ref RawMatrix matrixRef)
		{
			Result result;
			fixed (RawMatrix* ptr = &matrixRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, state, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x00011788 File Offset: 0x0000F988
		internal unsafe void SetMaterial(ref Material materialRef)
		{
			Result result;
			fixed (Material* ptr = &materialRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x000117C8 File Offset: 0x0000F9C8
		public unsafe void SetLight(int index, ref Light lightRef)
		{
			Result result;
			fixed (Light* ptr = &lightRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, index, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x0001180C File Offset: 0x0000FA0C
		public unsafe void LightEnable(int index, RawBool enable)
		{
			calli(System.Int32(System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, index, enable, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x00011848 File Offset: 0x0000FA48
		public unsafe void SetRenderState(RenderState state, int value)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32), this._nativePointer, state, value, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x00011884 File Offset: 0x0000FA84
		public unsafe void SetTexture(int stage, BaseTexture textureRef)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, stage, (void*)((textureRef == null) ? IntPtr.Zero : textureRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x000118D4 File Offset: 0x0000FAD4
		public unsafe void SetTextureStageState(int stage, TextureStage type, int value)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32), this._nativePointer, stage, type, value, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x00011910 File Offset: 0x0000FB10
		public unsafe void SetSamplerState(int sampler, SamplerState type, int value)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32), this._nativePointer, sampler, type, value, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x0001194C File Offset: 0x0000FB4C
		internal unsafe void SetNPatchMode(float numSegments)
		{
			calli(System.Int32(System.Void*,System.Single), this._nativePointer, numSegments, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x00011988 File Offset: 0x0000FB88
		internal unsafe void SetVertexFormat(VertexFormat vertexFormat)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, vertexFormat, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x000119C4 File Offset: 0x0000FBC4
		internal unsafe void SetVertexShader(VertexShader shaderRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)((shaderRef == null) ? IntPtr.Zero : shaderRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x00011A14 File Offset: 0x0000FC14
		public unsafe void SetVertexShaderConstantF(int registerIndex, float constantDataRef, int registerCount)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, registerIndex, &constantDataRef, registerCount, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x00011A54 File Offset: 0x0000FC54
		public unsafe void SetVertexShaderConstantI(int registerIndex, int constantDataRef, int registerCount)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, registerIndex, &constantDataRef, registerCount, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x00011A94 File Offset: 0x0000FC94
		public unsafe void SetVertexShaderConstantB(int registerIndex, RawBool constantDataRef, int registerCount)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, registerIndex, &constantDataRef, registerCount, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x00011AD4 File Offset: 0x0000FCD4
		internal unsafe void SetPixelShader(PixelShader shaderRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)((shaderRef == null) ? IntPtr.Zero : shaderRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x00011B24 File Offset: 0x0000FD24
		public unsafe void SetPixelShaderConstantF(int registerIndex, float constantDataRef, int registerCount)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, registerIndex, &constantDataRef, registerCount, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x00011B64 File Offset: 0x0000FD64
		public unsafe void SetPixelShaderConstantI(int registerIndex, int constantDataRef, int registerCount)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, registerIndex, &constantDataRef, registerCount, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x00011BA4 File Offset: 0x0000FDA4
		public unsafe void SetPixelShaderConstantB(int registerIndex, RawBool constantDataRef, int registerCount)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, registerIndex, &constantDataRef, registerCount, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
