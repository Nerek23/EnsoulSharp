using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;
using SharpDX.Mathematics.Interop;
using SharpDX.WIC;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001DC RID: 476
	[Guid("3d9f916b-27dc-4ad7-b4f1-64945340f563")]
	public class EffectContext : ComObject
	{
		// Token: 0x1700015F RID: 351
		// (get) Token: 0x060009A8 RID: 2472 RVA: 0x0001BF34 File Offset: 0x0001A134
		public RawVector2 Dpi
		{
			get
			{
				RawVector2 result;
				this.GetDpi(out result.X, out result.Y);
				return result;
			}
		}

		// Token: 0x060009A9 RID: 2473 RVA: 0x0001BF56 File Offset: 0x0001A156
		public FeatureLevel GetMaximumSupportedFeatureLevel(FeatureLevel[] featureLevels)
		{
			return this.GetMaximumSupportedFeatureLevel(featureLevels, featureLevels.Length);
		}

		// Token: 0x060009AA RID: 2474 RVA: 0x0001BF62 File Offset: 0x0001A162
		public void LoadPixelShader(Guid shaderId, byte[] shaderBytecode)
		{
			this.LoadPixelShader(shaderId, shaderBytecode, shaderBytecode.Length);
		}

		// Token: 0x060009AB RID: 2475 RVA: 0x0001BF6F File Offset: 0x0001A16F
		public void LoadVertexShader(Guid shaderId, byte[] shaderBytecode)
		{
			this.LoadVertexShader(shaderId, shaderBytecode, shaderBytecode.Length);
		}

		// Token: 0x060009AC RID: 2476 RVA: 0x0001BF7C File Offset: 0x0001A17C
		public void LoadComputeShader(Guid shaderId, byte[] shaderBytecode)
		{
			this.LoadComputeShader(shaderId, shaderBytecode, shaderBytecode.Length);
		}

		// Token: 0x060009AD RID: 2477 RVA: 0x0001BF8C File Offset: 0x0001A18C
		public unsafe bool CheckFeatureSupport(Feature feature)
		{
			if (feature == Feature.Doubles)
			{
				FeatureDataDoubles featureDataDoubles;
				return !this.CheckFeatureSupport(Feature.Doubles, new IntPtr((void*)(&featureDataDoubles)), Utilities.SizeOf<FeatureDataDoubles>()).Failure && featureDataDoubles.DoublePrecisionFloatShaderOps;
			}
			if (feature != Feature.D3D10XHardwareOptions)
			{
				throw new SharpDXException("Unsupported Feature. Use specialized CheckXXX methods", new object[0]);
			}
			FeatureDataD3D10XHardwareOptions featureDataD3D10XHardwareOptions;
			return !this.CheckFeatureSupport(Feature.D3D10XHardwareOptions, new IntPtr((void*)(&featureDataD3D10XHardwareOptions)), Utilities.SizeOf<FeatureDataD3D10XHardwareOptions>()).Failure && featureDataD3D10XHardwareOptions.ComputeShadersPlusRawAndStructuredBuffersViaShader4X;
		}

		// Token: 0x060009AE RID: 2478 RVA: 0x00002A7F File Offset: 0x00000C7F
		public EffectContext(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060009AF RID: 2479 RVA: 0x0001C00A File Offset: 0x0001A20A
		public new static explicit operator EffectContext(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new EffectContext(nativePtr);
			}
			return null;
		}

		// Token: 0x060009B0 RID: 2480 RVA: 0x0001C024 File Offset: 0x0001A224
		internal unsafe void GetDpi(out float dpiX, out float dpiY)
		{
			fixed (float* ptr = &dpiY)
			{
				void* ptr2 = (void*)ptr;
				fixed (float* ptr3 = &dpiX)
				{
					void* ptr4 = (void*)ptr3;
					calli(System.Void(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
				}
			}
		}

		// Token: 0x060009B1 RID: 2481 RVA: 0x0001C060 File Offset: 0x0001A260
		internal unsafe void CreateEffect(Guid effectId, Effect effect)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &effectId, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			effect.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060009B2 RID: 2482 RVA: 0x0001C0AC File Offset: 0x0001A2AC
		internal unsafe FeatureLevel GetMaximumSupportedFeatureLevel(FeatureLevel[] featureLevels, int featureLevelsCount)
		{
			FeatureLevel result2;
			Result result;
			fixed (FeatureLevel[] array = featureLevels)
			{
				void* ptr;
				if (featureLevels == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, ptr, featureLevelsCount, &result2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x060009B3 RID: 2483 RVA: 0x0001C104 File Offset: 0x0001A304
		public unsafe TransformNode CreateTransformNodeFromEffect(Effect effect)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Effect>(effect);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			TransformNode result2;
			if (zero != IntPtr.Zero)
			{
				result2 = new TransformNodeNative(zero);
			}
			else
			{
				result2 = null;
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x0001C170 File Offset: 0x0001A370
		internal unsafe void CreateBlendTransform(int numInputs, ref BlendDescription blendDescription, BlendTransform transform)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (BlendDescription* ptr = &blendDescription)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, numInputs, ptr2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
			transform.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x0001C1C4 File Offset: 0x0001A3C4
		internal unsafe void CreateBorderTransform(ExtendMode extendModeX, ExtendMode extendModeY, BorderTransform transform)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, extendModeX, extendModeY, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			transform.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060009B6 RID: 2486 RVA: 0x0001C210 File Offset: 0x0001A410
		internal unsafe void CreateOffsetTransform(RawPoint offset, OffsetTransform transform)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,SharpDX.Mathematics.Interop.RawPoint,System.Void*), this._nativePointer, offset, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			transform.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060009B7 RID: 2487 RVA: 0x0001C25C File Offset: 0x0001A45C
		internal unsafe void CreateBoundsAdjustmentTransform(RawRectangle outputRectangle, BoundsAdjustmentTransform transform)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &outputRectangle, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			transform.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060009B8 RID: 2488 RVA: 0x0001C2A8 File Offset: 0x0001A4A8
		internal unsafe void LoadPixelShader(Guid shaderId, byte[] shaderBuffer, int shaderBufferCount)
		{
			Result result;
			fixed (byte[] array = shaderBuffer)
			{
				void* ptr;
				if (shaderBuffer == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, &shaderId, ptr, shaderBufferCount, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060009B9 RID: 2489 RVA: 0x0001C300 File Offset: 0x0001A500
		internal unsafe void LoadVertexShader(Guid resourceId, byte[] shaderBuffer, int shaderBufferCount)
		{
			Result result;
			fixed (byte[] array = shaderBuffer)
			{
				void* ptr;
				if (shaderBuffer == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, &resourceId, ptr, shaderBufferCount, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060009BA RID: 2490 RVA: 0x0001C358 File Offset: 0x0001A558
		internal unsafe void LoadComputeShader(Guid resourceId, byte[] shaderBuffer, int shaderBufferCount)
		{
			Result result;
			fixed (byte[] array = shaderBuffer)
			{
				void* ptr;
				if (shaderBuffer == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, &resourceId, ptr, shaderBufferCount, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060009BB RID: 2491 RVA: 0x0001C3AF File Offset: 0x0001A5AF
		public unsafe RawBool IsShaderLoaded(Guid shaderId)
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*,System.Void*), this._nativePointer, &shaderId, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060009BC RID: 2492 RVA: 0x0001C3D4 File Offset: 0x0001A5D4
		internal unsafe void CreateResourceTexture(Guid? resourceId, IntPtr resourceTextureProperties, byte[] data, int[] strides, int dataSize, ResourceTexture resourceTexture)
		{
			IntPtr zero = IntPtr.Zero;
			Guid value;
			if (resourceId != null)
			{
				value = resourceId.Value;
			}
			Result result;
			fixed (int[] array = strides)
			{
				void* ptr;
				if (strides == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (byte[] array2 = data)
				{
					void* ptr2;
					if (data == null || array2.Length == 0)
					{
						ptr2 = null;
					}
					else
					{
						ptr2 = (void*)(&array2[0]);
					}
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, (resourceId == null) ? null : (&value), (void*)resourceTextureProperties, ptr2, ptr, dataSize, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
				}
			}
			resourceTexture.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060009BD RID: 2493 RVA: 0x0001C488 File Offset: 0x0001A688
		public unsafe ResourceTexture FindResourceTexture(Guid resourceId)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &resourceId, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*)));
			ResourceTexture result;
			if (zero != IntPtr.Zero)
			{
				result = new ResourceTexture(zero);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060009BE RID: 2494 RVA: 0x0001C4E0 File Offset: 0x0001A6E0
		internal unsafe void CreateVertexBuffer(VertexBufferProperties vertexBufferProperties, Guid? resourceId, IntPtr customVertexBufferProperties, VertexBuffer buffer)
		{
			VertexBufferProperties.__Native _Native = default(VertexBufferProperties.__Native);
			IntPtr zero = IntPtr.Zero;
			vertexBufferProperties.__MarshalTo(ref _Native);
			Guid value;
			if (resourceId != null)
			{
				value = resourceId.Value;
			}
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &_Native, (resourceId == null) ? null : (&value), (void*)customVertexBufferProperties, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
			buffer.NativePointer = zero;
			vertexBufferProperties.__MarshalFree(ref _Native);
			result.CheckError();
		}

		// Token: 0x060009BF RID: 2495 RVA: 0x0001C56C File Offset: 0x0001A76C
		public unsafe VertexBuffer FindVertexBuffer(Guid resourceId)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &resourceId, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
			VertexBuffer result;
			if (zero != IntPtr.Zero)
			{
				result = new VertexBuffer(zero);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060009C0 RID: 2496 RVA: 0x0001C5C4 File Offset: 0x0001A7C4
		internal unsafe void CreateColorContext(ColorSpace space, byte[] rofileRef, int profileSize, ColorContext colorContext)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (byte[] array = rofileRef)
			{
				void* ptr;
				if (rofileRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32,System.Void*), this._nativePointer, space, ptr, profileSize, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
			}
			colorContext.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060009C1 RID: 2497 RVA: 0x0001C62C File Offset: 0x0001A82C
		internal unsafe void CreateColorContextFromFilename(string filename, ColorContext colorContext)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (string text = filename)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*)));
			}
			colorContext.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060009C2 RID: 2498 RVA: 0x0001C688 File Offset: 0x0001A888
		internal unsafe void CreateColorContextFromWicColorContext(ColorContext wicColorContext, ColorContext colorContext)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<ColorContext>(wicColorContext);
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*)));
			colorContext.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060009C3 RID: 2499 RVA: 0x0001C6E3 File Offset: 0x0001A8E3
		internal unsafe Result CheckFeatureSupport(Feature feature, IntPtr featureSupportData, int featureSupportDataSize)
		{
			return calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, feature, (void*)featureSupportData, featureSupportDataSize, *(*(IntPtr*)this._nativePointer + (IntPtr)22 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060009C4 RID: 2500 RVA: 0x0001C710 File Offset: 0x0001A910
		public unsafe RawBool IsBufferPrecisionSupported(BufferPrecision bufferPrecision)
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*,System.Int32), this._nativePointer, bufferPrecision, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*)));
		}
	}
}
