using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000017 RID: 23
	[Guid("D0223B96-BF7A-43fd-92BD-A43B0D82B9EB")]
	public class Device : ComObject
	{
		// Token: 0x060000FD RID: 253 RVA: 0x00005509 File Offset: 0x00003709
		public Device(Direct3D direct3D, int adapter, DeviceType deviceType, IntPtr hFocusWindow, CreateFlags behaviorFlags, params PresentParameters[] presentationParametersRef)
		{
			direct3D.CreateDevice(adapter, deviceType, hFocusWindow, behaviorFlags, presentationParametersRef, this);
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060000FE RID: 254 RVA: 0x00005520 File Offset: 0x00003720
		public long AvailableTextureMemory
		{
			get
			{
				return (long)((ulong)this.GetAvailableTextureMem());
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060000FF RID: 255 RVA: 0x00005529 File Offset: 0x00003729
		public DriverLevel DriverLevel
		{
			get
			{
				return (DriverLevel)D3DX9.GetDriverLevel(this);
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000100 RID: 256 RVA: 0x00005531 File Offset: 0x00003731
		public string PixelShaderProfile
		{
			get
			{
				return D3DX9.GetPixelShaderProfile(this);
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000101 RID: 257 RVA: 0x00005539 File Offset: 0x00003739
		public string VertexShaderProfile
		{
			get
			{
				return D3DX9.GetVertexShaderProfile(this);
			}
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00005541 File Offset: 0x00003741
		public void Clear(ClearFlags clearFlags, RawColorBGRA color, float zdepth, int stencil)
		{
			this.Clear_(0, null, clearFlags, color, zdepth, stencil);
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00005550 File Offset: 0x00003750
		public void Clear(ClearFlags clearFlags, RawColorBGRA color, float zdepth, int stencil, RawRectangle[] rectangles)
		{
			this.Clear_((rectangles == null) ? 0 : rectangles.Length, rectangles, clearFlags, color, zdepth, stencil);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0000556C File Offset: 0x0000376C
		public void ColorFill(Surface surfaceRef, RawColorBGRA color)
		{
			this.ColorFill(surfaceRef, null, color);
		}

		// Token: 0x06000105 RID: 261 RVA: 0x0000558C File Offset: 0x0000378C
		public void DrawIndexedUserPrimitives<S, T>(PrimitiveType primitiveType, int minimumVertexIndex, int vertexCount, int primitiveCount, S[] indexData, Format indexDataFormat, T[] vertexData) where S : struct where T : struct
		{
			this.DrawIndexedUserPrimitives<S, T>(primitiveType, 0, 0, minimumVertexIndex, vertexCount, primitiveCount, indexData, indexDataFormat, vertexData);
		}

		// Token: 0x06000106 RID: 262 RVA: 0x000055AC File Offset: 0x000037AC
		public void DrawIndexedUserPrimitives<S, T>(PrimitiveType primitiveType, int startIndex, int minimumVertexIndex, int vertexCount, int primitiveCount, S[] indexData, Format indexDataFormat, T[] vertexData) where S : struct where T : struct
		{
			this.DrawIndexedUserPrimitives<S, T>(primitiveType, startIndex, 0, minimumVertexIndex, vertexCount, primitiveCount, indexData, indexDataFormat, vertexData);
		}

		// Token: 0x06000107 RID: 263 RVA: 0x000055D0 File Offset: 0x000037D0
		public unsafe void DrawIndexedUserPrimitives<S, T>(PrimitiveType primitiveType, int startIndex, int startVertex, int minimumVertexIndex, int vertexCount, int primitiveCount, S[] indexData, Format indexDataFormat, T[] vertexData) where S : struct where T : struct
		{
			fixed (S* value = &indexData[startIndex])
			{
				IntPtr indexDataRef = (IntPtr)((void*)value);
				fixed (T* value2 = &vertexData[startVertex])
				{
					this.DrawIndexedPrimitiveUP(primitiveType, minimumVertexIndex, vertexCount, primitiveCount, indexDataRef, indexDataFormat, (IntPtr)((void*)value2), Utilities.SizeOf<T>());
				}
			}
		}

		// Token: 0x06000108 RID: 264 RVA: 0x0000560F File Offset: 0x0000380F
		public void DrawRectanglePatch(int handle, float[] segmentCounts)
		{
			this.DrawRectanglePatch(handle, segmentCounts, IntPtr.Zero);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x0000561E File Offset: 0x0000381E
		public unsafe void DrawRectanglePatch(int handle, float[] segmentCounts, RectanglePatchInfo info)
		{
			this.DrawRectanglePatch(handle, segmentCounts, new IntPtr((void*)(&info)));
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00005630 File Offset: 0x00003830
		public void DrawTrianglePatch(int handle, float[] segmentCounts)
		{
			this.DrawTrianglePatch(handle, segmentCounts, IntPtr.Zero);
		}

		// Token: 0x0600010B RID: 267 RVA: 0x0000563F File Offset: 0x0000383F
		public unsafe void DrawTrianglePatch(int handle, float[] segmentCounts, TrianglePatchInfo info)
		{
			this.DrawTrianglePatch(handle, segmentCounts, new IntPtr((void*)(&info)));
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00005651 File Offset: 0x00003851
		public void DrawUserPrimitives<T>(PrimitiveType primitiveType, int primitiveCount, T[] data) where T : struct
		{
			this.DrawUserPrimitives<T>(primitiveType, 0, primitiveCount, data);
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00005660 File Offset: 0x00003860
		public unsafe void DrawUserPrimitives<T>(PrimitiveType primitiveType, int startIndex, int primitiveCount, T[] data) where T : struct
		{
			fixed (T* value = &data[startIndex])
			{
				this.DrawPrimitiveUP(primitiveType, primitiveCount, (IntPtr)((void*)value), Utilities.SizeOf<T>());
			}
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00005689 File Offset: 0x00003889
		public Surface GetBackBuffer(int swapChain, int backBuffer)
		{
			return this.GetBackBuffer(swapChain, backBuffer, BackBufferType.Mono);
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00005694 File Offset: 0x00003894
		public PaletteEntry[] GetPaletteEntries(int paletteNumber)
		{
			PaletteEntry[] array = new PaletteEntry[256];
			this.GetPaletteEntries(paletteNumber, array);
			return array;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x000056B8 File Offset: 0x000038B8
		public unsafe bool[] GetPixelShaderBooleanConstant(int startRegister, int count)
		{
			if (count < 1024)
			{
				int* ptr = stackalloc int[checked(unchecked((UIntPtr)count) * 4)];
				this.GetPixelShaderConstantB(startRegister, (IntPtr)((void*)ptr), count);
				return Utilities.ConvertToBoolArray(ptr, count);
			}
			RawBool[] array2;
			RawBool[] array = array2 = new RawBool[count];
			void* value;
			if (array == null || array2.Length == 0)
			{
				value = null;
			}
			else
			{
				value = (void*)(&array2[0]);
			}
			this.GetPixelShaderConstantB(startRegister, (IntPtr)value, count);
			array2 = null;
			return Utilities.ConvertToBoolArray(array);
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00005720 File Offset: 0x00003920
		public float[] GetPixelShaderFloatConstant(int startRegister, int count)
		{
			float[] array = new float[count];
			this.GetPixelShaderConstantF(startRegister, array, count);
			return array;
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00005740 File Offset: 0x00003940
		public int[] GetPixelShaderIntegerConstant(int startRegister, int count)
		{
			int[] array = new int[count];
			this.GetPixelShaderConstantI(startRegister, array, count);
			return array;
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00005760 File Offset: 0x00003960
		public unsafe int GetRenderState(RenderState state)
		{
			int result = 0;
			this.GetRenderState(state, new IntPtr((void*)(&result)));
			return result;
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00005780 File Offset: 0x00003980
		public unsafe T GetRenderState<T>(RenderState state) where T : struct
		{
			T result = default(T);
			fixed (T* value = &result)
			{
				this.GetRenderState(state, (IntPtr)((void*)value));
				return result;
			}
		}

		// Token: 0x06000115 RID: 277 RVA: 0x000057A8 File Offset: 0x000039A8
		public unsafe int GetSamplerState(int sampler, SamplerState state)
		{
			int result = 0;
			this.GetSamplerState(sampler, state, new IntPtr((void*)(&result)));
			return result;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x000057C8 File Offset: 0x000039C8
		public unsafe T GetSamplerState<T>(int sampler, SamplerState state) where T : struct
		{
			T result = default(T);
			fixed (T* value = &result)
			{
				this.GetSamplerState(sampler, state, (IntPtr)((void*)value));
				return result;
			}
		}

		// Token: 0x06000117 RID: 279 RVA: 0x000057F0 File Offset: 0x000039F0
		public unsafe int GetTextureStageState(int stage, TextureStage type)
		{
			int result = 0;
			this.GetTextureStageState(stage, type, new IntPtr((void*)(&result)));
			return result;
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00005810 File Offset: 0x00003A10
		public unsafe T GetTextureStageState<T>(int stage, TextureStage type) where T : struct
		{
			T result = default(T);
			fixed (T* value = &result)
			{
				this.GetTextureStageState(stage, type, (IntPtr)((void*)value));
				return result;
			}
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00005838 File Offset: 0x00003A38
		public unsafe bool[] GetVertexShaderBooleanConstant(int startRegister, int count)
		{
			if (count < 1024)
			{
				return Utilities.ConvertToBoolArray(stackalloc int[checked(unchecked((UIntPtr)count) * 4)], count);
			}
			RawBool[] array2;
			RawBool[] array = array2 = new RawBool[count];
			void* value;
			if (array == null || array2.Length == 0)
			{
				value = null;
			}
			else
			{
				value = (void*)(&array2[0]);
			}
			this.GetVertexShaderConstantB(startRegister, (IntPtr)value, count);
			array2 = null;
			return Utilities.ConvertToBoolArray(array);
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00005890 File Offset: 0x00003A90
		public float[] GetVertexShaderFloatConstant(int startRegister, int count)
		{
			float[] array = new float[count];
			this.GetVertexShaderConstantF(startRegister, array, count);
			return array;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x000058B0 File Offset: 0x00003AB0
		public int[] GetVertexShaderIntegerConstant(int startRegister, int count)
		{
			int[] array = new int[count];
			this.GetVertexShaderConstantI(startRegister, array, count);
			return array;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x000058CE File Offset: 0x00003ACE
		public void SetCursorPosition(RawPoint point, bool flags)
		{
			this.SetCursorPosition(point.X, point.Y, flags);
		}

		// Token: 0x0600011D RID: 285 RVA: 0x000058E3 File Offset: 0x00003AE3
		public void SetCursorPosition(int x, int y, bool flags)
		{
			this.SetCursorPosition(x, y, flags ? 1 : 0);
		}

		// Token: 0x0600011E RID: 286 RVA: 0x000058F4 File Offset: 0x00003AF4
		public void SetCursorProperties(RawPoint point, Surface cursorBitmapRef)
		{
			this.SetCursorProperties(point.X, point.Y, cursorBitmapRef);
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00005909 File Offset: 0x00003B09
		public void SetGammaRamp(int swapChain, ref GammaRamp rampRef, bool calibrate)
		{
			this.SetGammaRamp(swapChain, calibrate ? 1 : 0, ref rampRef);
		}

		// Token: 0x06000120 RID: 288 RVA: 0x0000591A File Offset: 0x00003B1A
		public void Present()
		{
			this.Present(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00005936 File Offset: 0x00003B36
		public void Present(RawRectangle sourceRectangle, RawRectangle destinationRectangle)
		{
			this.Present(sourceRectangle, destinationRectangle, IntPtr.Zero);
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00005945 File Offset: 0x00003B45
		public unsafe void Present(RawRectangle sourceRectangle, RawRectangle destinationRectangle, IntPtr windowOverride)
		{
			this.Present(new IntPtr((void*)(&sourceRectangle)), new IntPtr((void*)(&destinationRectangle)), windowOverride, IntPtr.Zero);
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00005963 File Offset: 0x00003B63
		public unsafe void Present(RawRectangle sourceRectangle, RawRectangle destinationRectangle, IntPtr windowOverride, IntPtr dirtyRegionRGNData)
		{
			this.Present(new IntPtr((void*)(&sourceRectangle)), new IntPtr((void*)(&destinationRectangle)), windowOverride, dirtyRegionRGNData);
		}

		// Token: 0x06000124 RID: 292 RVA: 0x0000597E File Offset: 0x00003B7E
		public void ResetStreamSourceFrequency(int stream)
		{
			this.SetStreamSourceFrequency(stream, 1);
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00005988 File Offset: 0x00003B88
		public unsafe void SetPixelShaderConstant(int startRegister, RawMatrix[] data)
		{
			fixed (RawMatrix[] array = data)
			{
				void* value;
				if (data == null || array.Length == 0)
				{
					value = null;
				}
				else
				{
					value = (void*)(&array[0]);
				}
				this.SetPixelShaderConstantF(startRegister, (IntPtr)value, data.Length << 2);
			}
		}

		// Token: 0x06000126 RID: 294 RVA: 0x000059C4 File Offset: 0x00003BC4
		public unsafe void SetPixelShaderConstant(int startRegister, RawVector4[] data)
		{
			fixed (RawVector4[] array = data)
			{
				void* value;
				if (data == null || array.Length == 0)
				{
					value = null;
				}
				else
				{
					value = (void*)(&array[0]);
				}
				this.SetPixelShaderConstantF(startRegister, (IntPtr)value, data.Length);
			}
		}

		// Token: 0x06000127 RID: 295 RVA: 0x000059FC File Offset: 0x00003BFC
		public unsafe void SetPixelShaderConstant(int startRegister, bool[] data)
		{
			if (data.Length < 1024)
			{
				int* ptr = stackalloc int[checked(unchecked((UIntPtr)data.Length) * 4)];
				Utilities.ConvertToIntArray(data, ptr);
				this.SetPixelShaderConstantB(startRegister, (IntPtr)((void*)ptr), data.Length);
				return;
			}
			RawBool[] array;
			void* value;
			if ((array = Utilities.ConvertToIntArray(data)) == null || array.Length == 0)
			{
				value = null;
			}
			else
			{
				value = (void*)(&array[0]);
			}
			this.SetPixelShaderConstantB(startRegister, (IntPtr)value, data.Length);
			array = null;
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00005A64 File Offset: 0x00003C64
		public unsafe void SetPixelShaderConstant(int startRegister, int[] data)
		{
			fixed (int[] array = data)
			{
				void* value;
				if (data == null || array.Length == 0)
				{
					value = null;
				}
				else
				{
					value = (void*)(&array[0]);
				}
				this.SetPixelShaderConstantI(startRegister, (IntPtr)value, data.Length >> 2);
			}
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00005AA0 File Offset: 0x00003CA0
		public unsafe void SetPixelShaderConstant(int startRegister, float[] data)
		{
			fixed (float[] array = data)
			{
				void* value;
				if (data == null || array.Length == 0)
				{
					value = null;
				}
				else
				{
					value = (void*)(&array[0]);
				}
				this.SetPixelShaderConstantF(startRegister, (IntPtr)value, data.Length >> 2);
			}
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00005AD9 File Offset: 0x00003CD9
		public unsafe void SetPixelShaderConstant(int startRegister, RawMatrix* data)
		{
			this.SetPixelShaderConstantF(startRegister, (IntPtr)((void*)data), 4);
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00005AE9 File Offset: 0x00003CE9
		public unsafe void SetPixelShaderConstant(int startRegister, RawMatrix data)
		{
			this.SetPixelShaderConstantF(startRegister, new IntPtr((void*)(&data)), 4);
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00005AFB File Offset: 0x00003CFB
		public unsafe void SetPixelShaderConstant(int startRegister, RawMatrix* data, int count)
		{
			this.SetPixelShaderConstantF(startRegister, (IntPtr)((void*)data), count << 2);
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00005B10 File Offset: 0x00003D10
		public unsafe void SetPixelShaderConstant(int startRegister, RawMatrix[] data, int offset, int count)
		{
			fixed (RawMatrix* ptr = &data[offset])
			{
				void* value = (void*)ptr;
				this.SetPixelShaderConstantF(startRegister, (IntPtr)value, count << 2);
			}
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00005B3C File Offset: 0x00003D3C
		public unsafe void SetPixelShaderConstant(int startRegister, RawVector4[] data, int offset, int count)
		{
			fixed (RawVector4* ptr = &data[offset])
			{
				void* value = (void*)ptr;
				this.SetPixelShaderConstantF(startRegister, (IntPtr)value, count);
			}
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00005B68 File Offset: 0x00003D68
		public unsafe void SetPixelShaderConstant(int startRegister, bool[] data, int offset, int count)
		{
			if (count < 1024)
			{
				int* ptr = stackalloc int[checked(unchecked((UIntPtr)data.Length) * 4)];
				Utilities.ConvertToIntArray(data, ptr);
				this.SetPixelShaderConstantB(startRegister, new IntPtr((void*)(ptr + offset)), count);
				return;
			}
			fixed (RawBool* ptr2 = &Utilities.ConvertToIntArray(data)[offset])
			{
				void* value = (void*)ptr2;
				this.SetPixelShaderConstantB(startRegister, (IntPtr)value, count);
			}
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00005BC8 File Offset: 0x00003DC8
		public unsafe void SetPixelShaderConstant(int startRegister, int[] data, int offset, int count)
		{
			fixed (int* ptr = &data[offset])
			{
				void* value = (void*)ptr;
				this.SetPixelShaderConstantI(startRegister, (IntPtr)value, count);
			}
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00005BF4 File Offset: 0x00003DF4
		public unsafe void SetPixelShaderConstant(int startRegister, float[] data, int offset, int count)
		{
			fixed (float* ptr = &data[offset])
			{
				void* value = (void*)ptr;
				this.SetPixelShaderConstantF(startRegister, (IntPtr)value, count);
			}
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00005C1E File Offset: 0x00003E1E
		public void SetRenderState(RenderState renderState, bool enable)
		{
			this.SetRenderState(renderState, enable ? 1 : 0);
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00005C2E File Offset: 0x00003E2E
		public unsafe void SetRenderState(RenderState renderState, float value)
		{
			this.SetRenderState(renderState, *(int*)(&value));
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00005C3C File Offset: 0x00003E3C
		public void SetRenderState<T>(RenderState renderState, T value) where T : struct, IConvertible
		{
			if (!typeof(T).GetTypeInfo().IsEnum)
			{
				throw new ArgumentException("T must be an enum type", "value");
			}
			this.SetRenderState(renderState, value.ToInt32(CultureInfo.InvariantCulture));
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00005C88 File Offset: 0x00003E88
		public void SetSamplerState(int sampler, SamplerState type, TextureFilter textureFilter)
		{
			this.SetSamplerState(sampler, type, (int)textureFilter);
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00005C88 File Offset: 0x00003E88
		public void SetSamplerState(int sampler, SamplerState type, TextureAddress textureAddress)
		{
			this.SetSamplerState(sampler, type, (int)textureAddress);
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00005C93 File Offset: 0x00003E93
		public unsafe void SetSamplerState(int sampler, SamplerState type, float value)
		{
			this.SetSamplerState(sampler, type, *(int*)(&value));
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00005CA4 File Offset: 0x00003EA4
		public void SetStreamSourceFrequency(int stream, int frequency, StreamSource source)
		{
			int num = (source == StreamSource.IndexedData) ? 1073741824 : int.MinValue;
			this.SetStreamSourceFrequency(stream, frequency | num);
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00005CD0 File Offset: 0x00003ED0
		public void SetTextureStageState(int stage, TextureStage type, TextureArgument textureArgument)
		{
			this.SetTextureStageState(stage, type, (int)textureArgument);
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00005CD0 File Offset: 0x00003ED0
		public void SetTextureStageState(int stage, TextureStage type, TextureOperation textureOperation)
		{
			this.SetTextureStageState(stage, type, (int)textureOperation);
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00005CD0 File Offset: 0x00003ED0
		public void SetTextureStageState(int stage, TextureStage type, TextureTransform textureTransform)
		{
			this.SetTextureStageState(stage, type, (int)textureTransform);
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00005CDB File Offset: 0x00003EDB
		public unsafe void SetTextureStageState(int stage, TextureStage type, float value)
		{
			this.SetTextureStageState(stage, type, *(int*)(&value));
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00005CE9 File Offset: 0x00003EE9
		public void SetTransform(TransformState state, ref RawMatrix matrixRef)
		{
			this.SetTransform_((int)state, ref matrixRef);
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00005CF3 File Offset: 0x00003EF3
		public void SetTransform(int index, ref RawMatrix matrixRef)
		{
			this.SetTransform_(index + 256, ref matrixRef);
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00005D03 File Offset: 0x00003F03
		public void SetTransform(TransformState state, RawMatrix matrixRef)
		{
			this.SetTransform_((int)state, ref matrixRef);
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00005D0E File Offset: 0x00003F0E
		public void SetTransform(int index, RawMatrix matrixRef)
		{
			this.SetTransform_(index + 256, ref matrixRef);
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00005D20 File Offset: 0x00003F20
		public unsafe void SetVertexShaderConstant(int startRegister, RawMatrix[] data)
		{
			fixed (RawMatrix[] array = data)
			{
				void* value;
				if (data == null || array.Length == 0)
				{
					value = null;
				}
				else
				{
					value = (void*)(&array[0]);
				}
				this.SetVertexShaderConstantF(startRegister, (IntPtr)value, data.Length << 2);
			}
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00005D5C File Offset: 0x00003F5C
		public unsafe void SetVertexShaderConstant(int startRegister, RawVector4[] data)
		{
			fixed (RawVector4[] array = data)
			{
				void* value;
				if (data == null || array.Length == 0)
				{
					value = null;
				}
				else
				{
					value = (void*)(&array[0]);
				}
				this.SetVertexShaderConstantF(startRegister, (IntPtr)value, data.Length >> 2);
			}
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00005D98 File Offset: 0x00003F98
		public unsafe void SetVertexShaderConstant(int startRegister, bool[] data)
		{
			if (data.Length < 1024)
			{
				int* ptr = stackalloc int[checked(unchecked((UIntPtr)data.Length) * 4)];
				Utilities.ConvertToIntArray(data, ptr);
				this.SetVertexShaderConstantB(startRegister, (IntPtr)((void*)ptr), data.Length);
				return;
			}
			RawBool[] array;
			void* value;
			if ((array = Utilities.ConvertToIntArray(data)) == null || array.Length == 0)
			{
				value = null;
			}
			else
			{
				value = (void*)(&array[0]);
			}
			this.SetVertexShaderConstantB(startRegister, (IntPtr)value, data.Length);
			array = null;
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00005E00 File Offset: 0x00004000
		public unsafe void SetVertexShaderConstant(int startRegister, int[] data)
		{
			fixed (int[] array = data)
			{
				void* value;
				if (data == null || array.Length == 0)
				{
					value = null;
				}
				else
				{
					value = (void*)(&array[0]);
				}
				this.SetVertexShaderConstantI(startRegister, (IntPtr)value, data.Length >> 2);
			}
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00005E3C File Offset: 0x0000403C
		public unsafe void SetVertexShaderConstant(int startRegister, float[] data)
		{
			fixed (float[] array = data)
			{
				void* value;
				if (data == null || array.Length == 0)
				{
					value = null;
				}
				else
				{
					value = (void*)(&array[0]);
				}
				this.SetVertexShaderConstantF(startRegister, (IntPtr)value, data.Length >> 2);
			}
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00005E75 File Offset: 0x00004075
		public unsafe void SetVertexShaderConstant(int startRegister, RawMatrix* data)
		{
			this.SetVertexShaderConstantF(startRegister, (IntPtr)((void*)data), 4);
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00005E85 File Offset: 0x00004085
		public unsafe void SetVertexShaderConstant(int startRegister, RawMatrix data)
		{
			this.SetVertexShaderConstantF(startRegister, new IntPtr((void*)(&data)), 4);
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00005E97 File Offset: 0x00004097
		public unsafe void SetVertexShaderConstant(int startRegister, RawMatrix* data, int count)
		{
			this.SetVertexShaderConstantF(startRegister, (IntPtr)((void*)data), count << 2);
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00005EAC File Offset: 0x000040AC
		public unsafe void SetVertexShaderConstant(int startRegister, RawMatrix[] data, int offset, int count)
		{
			fixed (RawMatrix* ptr = &data[offset])
			{
				void* value = (void*)ptr;
				this.SetVertexShaderConstantF(startRegister, (IntPtr)value, count << 2);
			}
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00005ED8 File Offset: 0x000040D8
		public unsafe void SetVertexShaderConstant(int startRegister, RawVector4[] data, int offset, int count)
		{
			fixed (RawVector4* ptr = &data[offset])
			{
				void* value = (void*)ptr;
				this.SetVertexShaderConstantF(startRegister, (IntPtr)value, count >> 2);
			}
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00005F04 File Offset: 0x00004104
		public unsafe void SetVertexShaderConstant(int startRegister, bool[] data, int offset, int count)
		{
			if (count < 1024)
			{
				int* ptr = stackalloc int[checked(unchecked((UIntPtr)data.Length) * 4)];
				Utilities.ConvertToIntArray(data, ptr);
				this.SetVertexShaderConstantB(startRegister, new IntPtr((void*)(ptr + offset)), count);
				return;
			}
			fixed (RawBool* ptr2 = &Utilities.ConvertToIntArray(data)[offset])
			{
				void* value = (void*)ptr2;
				this.SetVertexShaderConstantB(startRegister, (IntPtr)value, count);
			}
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00005F64 File Offset: 0x00004164
		public unsafe void SetVertexShaderConstant(int startRegister, int[] data, int offset, int count)
		{
			fixed (int* ptr = &data[offset])
			{
				void* value = (void*)ptr;
				this.SetVertexShaderConstantI(startRegister, (IntPtr)value, count);
			}
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00005F90 File Offset: 0x00004190
		public unsafe void SetVertexShaderConstant(int startRegister, float[] data, int offset, int count)
		{
			fixed (float* ptr = &data[offset])
			{
				void* value = (void*)ptr;
				this.SetVertexShaderConstantF(startRegister, (IntPtr)value, count);
			}
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00005FBC File Offset: 0x000041BC
		public void StretchRectangle(Surface sourceSurfaceRef, Surface destSurfaceRef, TextureFilter filter)
		{
			this.StretchRectangle(sourceSurfaceRef, null, destSurfaceRef, null, filter);
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600014F RID: 335 RVA: 0x00005FE4 File Offset: 0x000041E4
		// (set) Token: 0x06000150 RID: 336 RVA: 0x00006011 File Offset: 0x00004211
		public bool ShowCursor
		{
			get
			{
				bool flag = this.GetSetShowCursor(true);
				this.GetSetShowCursor(flag);
				return flag;
			}
			set
			{
				this.GetSetShowCursor(value);
			}
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00006020 File Offset: 0x00004220
		public void UpdateSurface(Surface sourceSurfaceRef, Surface destinationSurfaceRef)
		{
			this.UpdateSurface(sourceSurfaceRef, null, destinationSurfaceRef, null);
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00002623 File Offset: 0x00000823
		public Device(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00006047 File Offset: 0x00004247
		public new static explicit operator Device(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new Device(nativePointer);
			}
			return null;
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000154 RID: 340 RVA: 0x00006060 File Offset: 0x00004260
		public Direct3D Direct3D
		{
			get
			{
				Direct3D result;
				this.GetDirect3D(out result);
				return result;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000155 RID: 341 RVA: 0x00006078 File Offset: 0x00004278
		public Capabilities Capabilities
		{
			get
			{
				Capabilities result;
				this.GetCapabilities(out result);
				return result;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000156 RID: 342 RVA: 0x00006090 File Offset: 0x00004290
		public CreationParameters CreationParameters
		{
			get
			{
				CreationParameters result;
				this.GetCreationParameters(out result);
				return result;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000157 RID: 343 RVA: 0x000060A6 File Offset: 0x000042A6
		public int SwapChainCount
		{
			get
			{
				return this.GetSwapChainCount();
			}
		}

		// Token: 0x1700001F RID: 31
		// (set) Token: 0x06000158 RID: 344 RVA: 0x000060AE File Offset: 0x000042AE
		public RawBool DialogBoxMode
		{
			set
			{
				this.SetDialogBoxMode(value);
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000159 RID: 345 RVA: 0x000060B8 File Offset: 0x000042B8
		// (set) Token: 0x0600015A RID: 346 RVA: 0x000060CE File Offset: 0x000042CE
		public Surface DepthStencilSurface
		{
			get
			{
				Surface result;
				this.GetDepthStencilSurface(out result);
				return result;
			}
			set
			{
				this.SetDepthStencilSurface(value);
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600015B RID: 347 RVA: 0x000060D8 File Offset: 0x000042D8
		// (set) Token: 0x0600015C RID: 348 RVA: 0x000060EE File Offset: 0x000042EE
		public RawViewport Viewport
		{
			get
			{
				RawViewport result;
				this.GetViewport(out result);
				return result;
			}
			set
			{
				this.SetViewport(value);
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600015D RID: 349 RVA: 0x000060F8 File Offset: 0x000042F8
		// (set) Token: 0x0600015E RID: 350 RVA: 0x0000610E File Offset: 0x0000430E
		public Material Material
		{
			get
			{
				Material result;
				this.GetMaterial(out result);
				return result;
			}
			set
			{
				this.SetMaterial(ref value);
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600015F RID: 351 RVA: 0x00006118 File Offset: 0x00004318
		// (set) Token: 0x06000160 RID: 352 RVA: 0x0000612E File Offset: 0x0000432E
		public ClipStatus ClipStatus
		{
			get
			{
				ClipStatus result;
				this.GetClipStatus(out result);
				return result;
			}
			set
			{
				this.SetClipStatus(value);
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000161 RID: 353 RVA: 0x00006138 File Offset: 0x00004338
		// (set) Token: 0x06000162 RID: 354 RVA: 0x0000614E File Offset: 0x0000434E
		public int CurrentTexturePalette
		{
			get
			{
				int result;
				this.GetCurrentTexturePalette(out result);
				return result;
			}
			set
			{
				this.SetCurrentTexturePalette(value);
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000163 RID: 355 RVA: 0x00006158 File Offset: 0x00004358
		// (set) Token: 0x06000164 RID: 356 RVA: 0x0000616E File Offset: 0x0000436E
		public RawRectangle ScissorRect
		{
			get
			{
				RawRectangle result;
				this.GetScissorRect(out result);
				return result;
			}
			set
			{
				this.SetScissorRect(value);
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000165 RID: 357 RVA: 0x00006177 File Offset: 0x00004377
		// (set) Token: 0x06000166 RID: 358 RVA: 0x0000617F File Offset: 0x0000437F
		public RawBool SoftwareVertexProcessing
		{
			get
			{
				return this.GetSoftwareVertexProcessing();
			}
			set
			{
				this.SetSoftwareVertexProcessing(value);
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000167 RID: 359 RVA: 0x00006188 File Offset: 0x00004388
		// (set) Token: 0x06000168 RID: 360 RVA: 0x00006190 File Offset: 0x00004390
		public float NPatchMode
		{
			get
			{
				return this.GetNPatchMode();
			}
			set
			{
				this.SetNPatchMode(value);
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000169 RID: 361 RVA: 0x0000619C File Offset: 0x0000439C
		// (set) Token: 0x0600016A RID: 362 RVA: 0x000061B2 File Offset: 0x000043B2
		public VertexDeclaration VertexDeclaration
		{
			get
			{
				VertexDeclaration result;
				this.GetVertexDeclaration(out result);
				return result;
			}
			set
			{
				this.SetVertexDeclaration(value);
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600016B RID: 363 RVA: 0x000061BC File Offset: 0x000043BC
		// (set) Token: 0x0600016C RID: 364 RVA: 0x000061D2 File Offset: 0x000043D2
		public VertexFormat VertexFormat
		{
			get
			{
				VertexFormat result;
				this.GetVertexFormat(out result);
				return result;
			}
			set
			{
				this.SetVertexFormat(value);
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600016D RID: 365 RVA: 0x000061DC File Offset: 0x000043DC
		// (set) Token: 0x0600016E RID: 366 RVA: 0x000061F2 File Offset: 0x000043F2
		public VertexShader VertexShader
		{
			get
			{
				VertexShader result;
				this.GetVertexShader(out result);
				return result;
			}
			set
			{
				this.SetVertexShader(value);
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600016F RID: 367 RVA: 0x000061FC File Offset: 0x000043FC
		// (set) Token: 0x06000170 RID: 368 RVA: 0x00006212 File Offset: 0x00004412
		public IndexBuffer Indices
		{
			get
			{
				IndexBuffer result;
				this.GetIndices(out result);
				return result;
			}
			set
			{
				this.SetIndices(value);
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000171 RID: 369 RVA: 0x0000621C File Offset: 0x0000441C
		// (set) Token: 0x06000172 RID: 370 RVA: 0x00006232 File Offset: 0x00004432
		public PixelShader PixelShader
		{
			get
			{
				PixelShader result;
				this.GetPixelShader(out result);
				return result;
			}
			set
			{
				this.SetPixelShader(value);
			}
		}

		// Token: 0x06000173 RID: 371 RVA: 0x0000623B File Offset: 0x0000443B
		public unsafe Result TestCooperativeLevel()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00004001 File Offset: 0x00002201
		internal unsafe int GetAvailableTextureMem()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00006260 File Offset: 0x00004460
		public unsafe void EvictManagedResources()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00006298 File Offset: 0x00004498
		internal unsafe void GetDirect3D(out Direct3D d3D9Out)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			d3D9Out = ((zero == IntPtr.Zero) ? null : new Direct3D(zero));
			result.CheckError();
		}

		// Token: 0x06000177 RID: 375 RVA: 0x000062F0 File Offset: 0x000044F0
		internal unsafe void GetCapabilities(out Capabilities capsRef)
		{
			capsRef = default(Capabilities);
			Result result;
			fixed (Capabilities* ptr = &capsRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00006338 File Offset: 0x00004538
		public unsafe DisplayMode GetDisplayMode(int iSwapChain)
		{
			DisplayMode result = default(DisplayMode);
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, iSwapChain, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x06000179 RID: 377 RVA: 0x0000637C File Offset: 0x0000457C
		internal unsafe void GetCreationParameters(out CreationParameters parametersRef)
		{
			parametersRef = default(CreationParameters);
			Result result;
			fixed (CreationParameters* ptr = &parametersRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600017A RID: 378 RVA: 0x000063C4 File Offset: 0x000045C4
		public unsafe void SetCursorProperties(int xHotSpot, int yHotSpot, Surface cursorBitmapRef)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, xHotSpot, yHotSpot, (void*)((cursorBitmapRef == null) ? IntPtr.Zero : cursorBitmapRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00006413 File Offset: 0x00004613
		internal unsafe void SetCursorPosition(int x, int y, int flags)
		{
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Int32), this._nativePointer, x, y, flags, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00006436 File Offset: 0x00004636
		public unsafe RawBool GetSetShowCursor(RawBool bShow)
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, bShow, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00006458 File Offset: 0x00004658
		internal unsafe void CreateAdditionalSwapChain(ref PresentParameters presentationParametersRef, SwapChain swapChainRef)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (PresentParameters* ptr = &presentationParametersRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			}
			swapChainRef.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600017E RID: 382 RVA: 0x000064AC File Offset: 0x000046AC
		public unsafe SwapChain GetSwapChain(int iSwapChain)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, iSwapChain, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
			SwapChain result2 = (zero == IntPtr.Zero) ? null : new SwapChain(zero);
			result.CheckError();
			return result2;
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00006504 File Offset: 0x00004704
		internal unsafe int GetSwapChainCount()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00006524 File Offset: 0x00004724
		public unsafe void Reset(params PresentParameters[] presentationParametersRef)
		{
			Result result;
			fixed (PresentParameters[] array = presentationParametersRef)
			{
				void* ptr;
				if (presentationParametersRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00006578 File Offset: 0x00004778
		internal unsafe void Present(IntPtr sourceRectRef, IntPtr destRectRef, IntPtr hDestWindowOverride, IntPtr dirtyRegionRef)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)sourceRectRef, (void*)destRectRef, (void*)hDestWindowOverride, (void*)dirtyRegionRef, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000182 RID: 386 RVA: 0x000065CC File Offset: 0x000047CC
		internal unsafe Surface GetBackBuffer(int iSwapChain, int iBackBuffer, BackBufferType type)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Void*), this._nativePointer, iSwapChain, iBackBuffer, type, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
			Surface result2 = (zero == IntPtr.Zero) ? null : new Surface(zero);
			result.CheckError();
			return result2;
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00006628 File Offset: 0x00004828
		public unsafe RasterStatus GetRasterStatus(int iSwapChain)
		{
			RasterStatus result = default(RasterStatus);
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, iSwapChain, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00006670 File Offset: 0x00004870
		internal unsafe void SetDialogBoxMode(RawBool bEnableDialogs)
		{
			calli(System.Int32(System.Void*,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, bEnableDialogs, *(*(IntPtr*)this._nativePointer + (IntPtr)20 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000185 RID: 389 RVA: 0x000066AC File Offset: 0x000048AC
		internal unsafe void SetGammaRamp(int iSwapChain, int flags, ref GammaRamp rampRef)
		{
			GammaRamp.__Native _Native = default(GammaRamp.__Native);
			rampRef.__MarshalTo(ref _Native);
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, iSwapChain, flags, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)21 * (IntPtr)sizeof(void*)));
			rampRef.__MarshalFree(ref _Native);
		}

		// Token: 0x06000186 RID: 390 RVA: 0x000066F4 File Offset: 0x000048F4
		public unsafe GammaRamp GetGammaRamp(int iSwapChain)
		{
			GammaRamp.__Native _Native = default(GammaRamp.__Native);
			calli(System.Void(System.Void*,System.Int32,System.Void*), this._nativePointer, iSwapChain, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)22 * (IntPtr)sizeof(void*)));
			GammaRamp result = default(GammaRamp);
			result.__MarshalFrom(ref _Native);
			return result;
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00006740 File Offset: 0x00004940
		internal unsafe void CreateTexture(int width, int height, int levels, int usage, Format format, Pool pool, Texture textureOut, IntPtr sharedHandleRef)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, width, height, levels, usage, format, pool, &zero, (void*)sharedHandleRef, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*)));
			textureOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000188 RID: 392 RVA: 0x0000679C File Offset: 0x0000499C
		internal unsafe void CreateVolumeTexture(int width, int height, int depth, int levels, int usage, Format format, Pool pool, VolumeTexture volumeTextureOut, IntPtr sharedHandleRef)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, width, height, depth, levels, usage, format, pool, &zero, (void*)sharedHandleRef, *(*(IntPtr*)this._nativePointer + (IntPtr)24 * (IntPtr)sizeof(void*)));
			volumeTextureOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000189 RID: 393 RVA: 0x000067F8 File Offset: 0x000049F8
		internal unsafe void CreateCubeTexture(int edgeLength, int levels, int usage, Format format, Pool pool, CubeTexture cubeTextureOut, IntPtr sharedHandleRef)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, edgeLength, levels, usage, format, pool, &zero, (void*)sharedHandleRef, *(*(IntPtr*)this._nativePointer + (IntPtr)25 * (IntPtr)sizeof(void*)));
			cubeTextureOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00006850 File Offset: 0x00004A50
		internal unsafe void CreateVertexBuffer(int length, Usage usage, VertexFormat vertexFormat, Pool pool, VertexBuffer vertexBufferOut, IntPtr sharedHandleRef)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, length, usage, vertexFormat, pool, &zero, (void*)sharedHandleRef, *(*(IntPtr*)this._nativePointer + (IntPtr)26 * (IntPtr)sizeof(void*)));
			vertexBufferOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600018B RID: 395 RVA: 0x000068A8 File Offset: 0x00004AA8
		internal unsafe void CreateIndexBuffer(int length, int usage, Format format, Pool pool, IndexBuffer indexBufferOut, IntPtr sharedHandleRef)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, length, usage, format, pool, &zero, (void*)sharedHandleRef, *(*(IntPtr*)this._nativePointer + (IntPtr)27 * (IntPtr)sizeof(void*)));
			indexBufferOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x0600018C RID: 396 RVA: 0x00006900 File Offset: 0x00004B00
		internal unsafe Surface CreateRenderTarget(int width, int height, Format format, MultisampleType multiSample, int multisampleQuality, RawBool lockable, IntPtr sharedHandleRef)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,SharpDX.Mathematics.Interop.RawBool,System.Void*,System.Void*), this._nativePointer, width, height, format, multiSample, multisampleQuality, lockable, &zero, (void*)sharedHandleRef, *(*(IntPtr*)this._nativePointer + (IntPtr)28 * (IntPtr)sizeof(void*)));
			Surface result2 = (zero == IntPtr.Zero) ? null : new Surface(zero);
			result.CheckError();
			return result2;
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00006968 File Offset: 0x00004B68
		internal unsafe Surface CreateDepthStencilSurface(int width, int height, Format format, MultisampleType multiSample, int multisampleQuality, RawBool discard, IntPtr sharedHandleRef)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,SharpDX.Mathematics.Interop.RawBool,System.Void*,System.Void*), this._nativePointer, width, height, format, multiSample, multisampleQuality, discard, &zero, (void*)sharedHandleRef, *(*(IntPtr*)this._nativePointer + (IntPtr)29 * (IntPtr)sizeof(void*)));
			Surface result2 = (zero == IntPtr.Zero) ? null : new Surface(zero);
			result.CheckError();
			return result2;
		}

		// Token: 0x0600018E RID: 398 RVA: 0x000069D0 File Offset: 0x00004BD0
		public unsafe void UpdateSurface(Surface sourceSurfaceRef, RawRectangle? sourceRectRef, Surface destinationSurfaceRef, RawPoint? destPointRef)
		{
			RawRectangle value;
			if (sourceRectRef != null)
			{
				value = sourceRectRef.Value;
			}
			RawPoint value2;
			if (destPointRef != null)
			{
				value2 = destPointRef.Value;
			}
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)((sourceSurfaceRef == null) ? IntPtr.Zero : sourceSurfaceRef.NativePointer), (sourceRectRef != null) ? ((void*)(&value)) : ((void*)IntPtr.Zero), (void*)((destinationSurfaceRef == null) ? IntPtr.Zero : destinationSurfaceRef.NativePointer), (destPointRef != null) ? ((void*)(&value2)) : ((void*)IntPtr.Zero), *(*(IntPtr*)this._nativePointer + (IntPtr)30 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00006A84 File Offset: 0x00004C84
		public unsafe void UpdateTexture(BaseTexture sourceTextureRef, BaseTexture destinationTextureRef)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)((sourceTextureRef == null) ? IntPtr.Zero : sourceTextureRef.NativePointer), (void*)((destinationTextureRef == null) ? IntPtr.Zero : destinationTextureRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)31 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00006AE8 File Offset: 0x00004CE8
		public unsafe void GetRenderTargetData(Surface renderTargetRef, Surface destSurfaceRef)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)((renderTargetRef == null) ? IntPtr.Zero : renderTargetRef.NativePointer), (void*)((destSurfaceRef == null) ? IntPtr.Zero : destSurfaceRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)32 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00006B4C File Offset: 0x00004D4C
		public unsafe void GetFrontBufferData(int iSwapChain, Surface destSurfaceRef)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, iSwapChain, (void*)((destSurfaceRef == null) ? IntPtr.Zero : destSurfaceRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)33 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000192 RID: 402 RVA: 0x00006B9C File Offset: 0x00004D9C
		public unsafe void StretchRectangle(Surface sourceSurfaceRef, RawRectangle? sourceRectRef, Surface destSurfaceRef, RawRectangle? destRectRef, TextureFilter filter)
		{
			RawRectangle value;
			if (sourceRectRef != null)
			{
				value = sourceRectRef.Value;
			}
			RawRectangle value2;
			if (destRectRef != null)
			{
				value2 = destRectRef.Value;
			}
			calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)((sourceSurfaceRef == null) ? IntPtr.Zero : sourceSurfaceRef.NativePointer), (sourceRectRef != null) ? ((void*)(&value)) : ((void*)IntPtr.Zero), (void*)((destSurfaceRef == null) ? IntPtr.Zero : destSurfaceRef.NativePointer), (destRectRef != null) ? ((void*)(&value2)) : ((void*)IntPtr.Zero), filter, *(*(IntPtr*)this._nativePointer + (IntPtr)34 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00006C54 File Offset: 0x00004E54
		public unsafe void ColorFill(Surface surfaceRef, RawRectangle? rectRef, RawColorBGRA color)
		{
			RawRectangle value;
			if (rectRef != null)
			{
				value = rectRef.Value;
			}
			calli(System.Int32(System.Void*,System.Void*,System.Void*,SharpDX.Mathematics.Interop.RawColorBGRA), this._nativePointer, (void*)((surfaceRef == null) ? IntPtr.Zero : surfaceRef.NativePointer), (rectRef != null) ? ((void*)(&value)) : ((void*)IntPtr.Zero), color, *(*(IntPtr*)this._nativePointer + (IntPtr)35 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000194 RID: 404 RVA: 0x00006CCC File Offset: 0x00004ECC
		internal unsafe Surface CreateOffscreenPlainSurface(int width, int height, Format format, Pool pool, IntPtr sharedHandleRef)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, width, height, format, pool, &zero, (void*)sharedHandleRef, *(*(IntPtr*)this._nativePointer + (IntPtr)36 * (IntPtr)sizeof(void*)));
			Surface result2 = (zero == IntPtr.Zero) ? null : new Surface(zero);
			result.CheckError();
			return result2;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00006D30 File Offset: 0x00004F30
		public unsafe void SetRenderTarget(int renderTargetIndex, Surface renderTargetRef)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, renderTargetIndex, (void*)((renderTargetRef == null) ? IntPtr.Zero : renderTargetRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)37 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00006D80 File Offset: 0x00004F80
		public unsafe Surface GetRenderTarget(int renderTargetIndex)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, renderTargetIndex, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)38 * (IntPtr)sizeof(void*)));
			Surface result2 = (zero == IntPtr.Zero) ? null : new Surface(zero);
			result.CheckError();
			return result2;
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00006DD8 File Offset: 0x00004FD8
		internal unsafe void SetDepthStencilSurface(Surface newZStencilRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)((newZStencilRef == null) ? IntPtr.Zero : newZStencilRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)39 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00006E28 File Offset: 0x00005028
		internal unsafe void GetDepthStencilSurface(out Surface zStencilSurfaceOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)40 * (IntPtr)sizeof(void*)));
			zStencilSurfaceOut = ((zero == IntPtr.Zero) ? null : new Surface(zero));
			result.CheckError();
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00006E84 File Offset: 0x00005084
		public unsafe void BeginScene()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)41 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600019A RID: 410 RVA: 0x00006EBC File Offset: 0x000050BC
		public unsafe void EndScene()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)42 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00006EF4 File Offset: 0x000050F4
		internal unsafe void Clear_(int count, RawRectangle[] rectsRef, ClearFlags flags, RawColorBGRA color, float z, int stencil)
		{
			Result result;
			fixed (RawRectangle[] array = rectsRef)
			{
				void* ptr;
				if (rectsRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawColorBGRA,System.Single,System.Int32), this._nativePointer, count, ptr, flags, color, z, stencil, *(*(IntPtr*)this._nativePointer + (IntPtr)43 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00006F50 File Offset: 0x00005150
		internal unsafe void SetTransform_(int state, ref RawMatrix matrixRef)
		{
			Result result;
			fixed (RawMatrix* ptr = &matrixRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, state, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)44 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00006F94 File Offset: 0x00005194
		public unsafe RawMatrix GetTransform(TransformState state)
		{
			RawMatrix result = default(RawMatrix);
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, state, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)45 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00006FDC File Offset: 0x000051DC
		public unsafe void MultiplyTransform(TransformState arg0, ref RawMatrix arg1)
		{
			Result result;
			fixed (RawMatrix* ptr = &arg1)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, arg0, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)46 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00007020 File Offset: 0x00005220
		internal unsafe void SetViewport(RawViewport viewportRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &viewportRef, *(*(IntPtr*)this._nativePointer + (IntPtr)47 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x0000705C File Offset: 0x0000525C
		internal unsafe void GetViewport(out RawViewport viewportRef)
		{
			viewportRef = default(RawViewport);
			Result result;
			fixed (RawViewport* ptr = &viewportRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)48 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x000070A4 File Offset: 0x000052A4
		internal unsafe void SetMaterial(ref Material materialRef)
		{
			Result result;
			fixed (Material* ptr = &materialRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)49 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x000070E8 File Offset: 0x000052E8
		internal unsafe void GetMaterial(out Material materialRef)
		{
			materialRef = default(Material);
			Result result;
			fixed (Material* ptr = &materialRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)50 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x00007130 File Offset: 0x00005330
		public unsafe void SetLight(int index, ref Light arg1)
		{
			Result result;
			fixed (Light* ptr = &arg1)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, index, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)51 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x00007174 File Offset: 0x00005374
		public unsafe Light GetLight(int index)
		{
			Light result = default(Light);
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, index, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)52 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x000071BC File Offset: 0x000053BC
		public unsafe void EnableLight(int index, RawBool enable)
		{
			calli(System.Int32(System.Void*,System.Int32,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, index, enable, *(*(IntPtr*)this._nativePointer + (IntPtr)53 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x000071F8 File Offset: 0x000053F8
		public unsafe RawBool IsLightEnabled(int index)
		{
			RawBool result = default(RawBool);
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, index, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)54 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x00007240 File Offset: 0x00005440
		public unsafe void SetClipPlane(int index, RawVector4 planeRef)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, index, &planeRef, *(*(IntPtr*)this._nativePointer + (IntPtr)55 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x0000727C File Offset: 0x0000547C
		public unsafe float GetClipPlane(int index)
		{
			float result;
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, index, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)56 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x000072BC File Offset: 0x000054BC
		public unsafe void SetRenderState(RenderState state, int value)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32), this._nativePointer, state, value, *(*(IntPtr*)this._nativePointer + (IntPtr)57 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001AA RID: 426 RVA: 0x000072F8 File Offset: 0x000054F8
		internal unsafe void GetRenderState(RenderState state, IntPtr valueRef)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, state, (void*)valueRef, *(*(IntPtr*)this._nativePointer + (IntPtr)58 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001AB RID: 427 RVA: 0x00007338 File Offset: 0x00005538
		internal unsafe void CreateStateBlock(StateBlockType type, StateBlock sBOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, type, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)59 * (IntPtr)sizeof(void*)));
			sBOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060001AC RID: 428 RVA: 0x00007384 File Offset: 0x00005584
		public unsafe void BeginStateBlock()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)60 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001AD RID: 429 RVA: 0x000073BC File Offset: 0x000055BC
		public unsafe StateBlock EndStateBlock()
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)61 * (IntPtr)sizeof(void*)));
			StateBlock result2 = (zero == IntPtr.Zero) ? null : new StateBlock(zero);
			result.CheckError();
			return result2;
		}

		// Token: 0x060001AE RID: 430 RVA: 0x00007414 File Offset: 0x00005614
		internal unsafe void SetClipStatus(ClipStatus clipStatusRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &clipStatusRef, *(*(IntPtr*)this._nativePointer + (IntPtr)62 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001AF RID: 431 RVA: 0x00007450 File Offset: 0x00005650
		internal unsafe void GetClipStatus(out ClipStatus clipStatusRef)
		{
			clipStatusRef = default(ClipStatus);
			Result result;
			fixed (ClipStatus* ptr = &clipStatusRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)63 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x00007498 File Offset: 0x00005698
		public unsafe BaseTexture GetTexture(int stage)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, stage, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)64 * (IntPtr)sizeof(void*)));
			BaseTexture result2 = (zero == IntPtr.Zero) ? null : new BaseTexture(zero);
			result.CheckError();
			return result2;
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x000074F0 File Offset: 0x000056F0
		public unsafe void SetTexture(int stage, BaseTexture textureRef)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, stage, (void*)((textureRef == null) ? IntPtr.Zero : textureRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)65 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x00007540 File Offset: 0x00005740
		internal unsafe void GetTextureStageState(int stage, TextureStage type, IntPtr valueRef)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, stage, type, (void*)valueRef, *(*(IntPtr*)this._nativePointer + (IntPtr)66 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x00007580 File Offset: 0x00005780
		public unsafe void SetTextureStageState(int stage, TextureStage type, int value)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32), this._nativePointer, stage, type, value, *(*(IntPtr*)this._nativePointer + (IntPtr)67 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x000075BC File Offset: 0x000057BC
		internal unsafe void GetSamplerState(int sampler, SamplerState type, IntPtr valueRef)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, sampler, type, (void*)valueRef, *(*(IntPtr*)this._nativePointer + (IntPtr)68 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x000075FC File Offset: 0x000057FC
		public unsafe void SetSamplerState(int sampler, SamplerState type, int value)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32), this._nativePointer, sampler, type, value, *(*(IntPtr*)this._nativePointer + (IntPtr)69 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x00007638 File Offset: 0x00005838
		public unsafe void ValidateDevice(int numPassesRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &numPassesRef, *(*(IntPtr*)this._nativePointer + (IntPtr)70 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x00007674 File Offset: 0x00005874
		public unsafe void SetPaletteEntries(int paletteNumber, PaletteEntry[] entriesRef)
		{
			Result result;
			fixed (PaletteEntry[] array = entriesRef)
			{
				void* ptr;
				if (entriesRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, paletteNumber, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)71 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x000076C8 File Offset: 0x000058C8
		internal unsafe void GetPaletteEntries(int paletteNumber, PaletteEntry[] entriesRef)
		{
			Result result;
			fixed (PaletteEntry[] array = entriesRef)
			{
				void* ptr;
				if (entriesRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, paletteNumber, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)72 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x0000771C File Offset: 0x0000591C
		internal unsafe void SetCurrentTexturePalette(int paletteNumber)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, paletteNumber, *(*(IntPtr*)this._nativePointer + (IntPtr)73 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001BA RID: 442 RVA: 0x00007758 File Offset: 0x00005958
		internal unsafe void GetCurrentTexturePalette(out int paletteNumber)
		{
			Result result;
			fixed (int* ptr = &paletteNumber)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)74 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060001BB RID: 443 RVA: 0x0000779C File Offset: 0x0000599C
		internal unsafe void SetScissorRect(RawRectangle rectRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &rectRef, *(*(IntPtr*)this._nativePointer + (IntPtr)75 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001BC RID: 444 RVA: 0x000077D8 File Offset: 0x000059D8
		internal unsafe void GetScissorRect(out RawRectangle rectRef)
		{
			rectRef = default(RawRectangle);
			Result result;
			fixed (RawRectangle* ptr = &rectRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)76 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060001BD RID: 445 RVA: 0x00007820 File Offset: 0x00005A20
		internal unsafe void SetSoftwareVertexProcessing(RawBool bSoftware)
		{
			calli(System.Int32(System.Void*,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, bSoftware, *(*(IntPtr*)this._nativePointer + (IntPtr)77 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001BE RID: 446 RVA: 0x00007859 File Offset: 0x00005A59
		internal unsafe RawBool GetSoftwareVertexProcessing()
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)78 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060001BF RID: 447 RVA: 0x0000787C File Offset: 0x00005A7C
		internal unsafe void SetNPatchMode(float nSegments)
		{
			calli(System.Int32(System.Void*,System.Single), this._nativePointer, nSegments, *(*(IntPtr*)this._nativePointer + (IntPtr)79 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x000078B5 File Offset: 0x00005AB5
		internal unsafe float GetNPatchMode()
		{
			return calli(System.Single(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)80 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x000078D8 File Offset: 0x00005AD8
		public unsafe void DrawPrimitives(PrimitiveType primitiveType, int startVertex, int primitiveCount)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32), this._nativePointer, primitiveType, startVertex, primitiveCount, *(*(IntPtr*)this._nativePointer + (IntPtr)81 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x00007914 File Offset: 0x00005B14
		public unsafe void DrawIndexedPrimitive(PrimitiveType arg0, int baseVertexIndex, int minVertexIndex, int numVertices, int startIndex, int primCount)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), this._nativePointer, arg0, baseVertexIndex, minVertexIndex, numVertices, startIndex, primCount, *(*(IntPtr*)this._nativePointer + (IntPtr)82 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x00007958 File Offset: 0x00005B58
		internal unsafe void DrawPrimitiveUP(PrimitiveType primitiveType, int primitiveCount, IntPtr vertexStreamZeroDataRef, int vertexStreamZeroStride)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*,System.Int32), this._nativePointer, primitiveType, primitiveCount, (void*)vertexStreamZeroDataRef, vertexStreamZeroStride, *(*(IntPtr*)this._nativePointer + (IntPtr)83 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x0000799C File Offset: 0x00005B9C
		internal unsafe void DrawIndexedPrimitiveUP(PrimitiveType primitiveType, int minVertexIndex, int numVertices, int primitiveCount, IntPtr indexDataRef, Format indexDataFormat, IntPtr vertexStreamZeroDataRef, int vertexStreamZeroStride)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Int32,System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, primitiveType, minVertexIndex, numVertices, primitiveCount, (void*)indexDataRef, indexDataFormat, (void*)vertexStreamZeroDataRef, vertexStreamZeroStride, *(*(IntPtr*)this._nativePointer + (IntPtr)84 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x000079EC File Offset: 0x00005BEC
		public unsafe void ProcessVertices(int srcStartIndex, int destIndex, int vertexCount, VertexBuffer destBufferRef, VertexDeclaration vertexDeclRef, LockFlags flags)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Void*,System.Void*,System.Int32), this._nativePointer, srcStartIndex, destIndex, vertexCount, (void*)((destBufferRef == null) ? IntPtr.Zero : destBufferRef.NativePointer), (void*)((vertexDeclRef == null) ? IntPtr.Zero : vertexDeclRef.NativePointer), flags, *(*(IntPtr*)this._nativePointer + (IntPtr)85 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x00007A58 File Offset: 0x00005C58
		internal unsafe void CreateVertexDeclaration(VertexElement[] vertexElementsRef, VertexDeclaration declOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (VertexElement[] array = vertexElementsRef)
			{
				void* ptr;
				if (vertexElementsRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, ptr, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)86 * (IntPtr)sizeof(void*)));
			}
			declOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x00007ABC File Offset: 0x00005CBC
		internal unsafe void SetVertexDeclaration(VertexDeclaration declRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)((declRef == null) ? IntPtr.Zero : declRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)87 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x00007B0C File Offset: 0x00005D0C
		internal unsafe void GetVertexDeclaration(out VertexDeclaration declOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)88 * (IntPtr)sizeof(void*)));
			declOut = ((zero == IntPtr.Zero) ? null : new VertexDeclaration(zero));
			result.CheckError();
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x00007B68 File Offset: 0x00005D68
		internal unsafe void SetVertexFormat(VertexFormat vertexFormat)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, vertexFormat, *(*(IntPtr*)this._nativePointer + (IntPtr)89 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001CA RID: 458 RVA: 0x00007BA4 File Offset: 0x00005DA4
		internal unsafe void GetVertexFormat(out VertexFormat ertexFormatRef)
		{
			Result result;
			fixed (VertexFormat* ptr = &ertexFormatRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)90 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060001CB RID: 459 RVA: 0x00007BE8 File Offset: 0x00005DE8
		internal unsafe void CreateVertexShader(IntPtr functionRef, VertexShader shaderOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)functionRef, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)91 * (IntPtr)sizeof(void*)));
			shaderOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060001CC RID: 460 RVA: 0x00007C38 File Offset: 0x00005E38
		internal unsafe void SetVertexShader(VertexShader shaderRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)((shaderRef == null) ? IntPtr.Zero : shaderRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)92 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001CD RID: 461 RVA: 0x00007C88 File Offset: 0x00005E88
		internal unsafe void GetVertexShader(out VertexShader shaderOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)93 * (IntPtr)sizeof(void*)));
			shaderOut = ((zero == IntPtr.Zero) ? null : new VertexShader(zero));
			result.CheckError();
		}

		// Token: 0x060001CE RID: 462 RVA: 0x00007CE4 File Offset: 0x00005EE4
		internal unsafe void SetVertexShaderConstantF(int startRegister, IntPtr constantDataRef, int vector4fCount)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, startRegister, (void*)constantDataRef, vector4fCount, *(*(IntPtr*)this._nativePointer + (IntPtr)94 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001CF RID: 463 RVA: 0x00007D24 File Offset: 0x00005F24
		internal unsafe void GetVertexShaderConstantF(int startRegister, float[] constantDataRef, int vector4fCount)
		{
			Result result;
			fixed (float[] array = constantDataRef)
			{
				void* ptr;
				if (constantDataRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, startRegister, ptr, vector4fCount, *(*(IntPtr*)this._nativePointer + (IntPtr)95 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x00007D7C File Offset: 0x00005F7C
		internal unsafe void SetVertexShaderConstantI(int startRegister, IntPtr constantDataRef, int vector4iCount)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, startRegister, (void*)constantDataRef, vector4iCount, *(*(IntPtr*)this._nativePointer + (IntPtr)96 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x00007DBC File Offset: 0x00005FBC
		internal unsafe void GetVertexShaderConstantI(int startRegister, int[] constantDataRef, int vector4iCount)
		{
			Result result;
			fixed (int[] array = constantDataRef)
			{
				void* ptr;
				if (constantDataRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, startRegister, ptr, vector4iCount, *(*(IntPtr*)this._nativePointer + (IntPtr)97 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x00007E14 File Offset: 0x00006014
		internal unsafe void SetVertexShaderConstantB(int startRegister, IntPtr constantDataRef, int boolCount)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, startRegister, (void*)constantDataRef, boolCount, *(*(IntPtr*)this._nativePointer + (IntPtr)98 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x00007E54 File Offset: 0x00006054
		internal unsafe void GetVertexShaderConstantB(int startRegister, IntPtr constantDataRef, int boolCount)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, startRegister, (void*)constantDataRef, boolCount, *(*(IntPtr*)this._nativePointer + (IntPtr)99 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x00007E94 File Offset: 0x00006094
		public unsafe void SetStreamSource(int streamNumber, VertexBuffer streamDataRef, int offsetInBytes, int stride)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32,System.Int32), this._nativePointer, streamNumber, (void*)((streamDataRef == null) ? IntPtr.Zero : streamDataRef.NativePointer), offsetInBytes, stride, *(*(IntPtr*)this._nativePointer + (IntPtr)100 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x00007EE8 File Offset: 0x000060E8
		public unsafe void GetStreamSource(int streamNumber, out VertexBuffer streamDataOut, out int offsetInBytesRef, out int strideRef)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (int* ptr = &offsetInBytesRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (int* ptr3 = &strideRef)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, streamNumber, &zero, ptr2, ptr4, *(*(IntPtr*)this._nativePointer + (IntPtr)101 * (IntPtr)sizeof(void*)));
				}
			}
			streamDataOut = ((zero == IntPtr.Zero) ? null : new VertexBuffer(zero));
			result.CheckError();
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x00007F5C File Offset: 0x0000615C
		internal unsafe void SetStreamSourceFrequency(int streamNumber, int setting)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32), this._nativePointer, streamNumber, setting, *(*(IntPtr*)this._nativePointer + (IntPtr)102 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x00007F98 File Offset: 0x00006198
		public unsafe void GetStreamSourceFrequency(int streamNumber, out int settingRef)
		{
			Result result;
			fixed (int* ptr = &settingRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, streamNumber, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)103 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x00007FDC File Offset: 0x000061DC
		internal unsafe void SetIndices(IndexBuffer indexDataRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)((indexDataRef == null) ? IntPtr.Zero : indexDataRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)104 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x0000802C File Offset: 0x0000622C
		internal unsafe void GetIndices(out IndexBuffer indexDataOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)105 * (IntPtr)sizeof(void*)));
			indexDataOut = ((zero == IntPtr.Zero) ? null : new IndexBuffer(zero));
			result.CheckError();
		}

		// Token: 0x060001DA RID: 474 RVA: 0x00008088 File Offset: 0x00006288
		internal unsafe void CreatePixelShader(IntPtr functionRef, PixelShader shaderOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)functionRef, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)106 * (IntPtr)sizeof(void*)));
			shaderOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060001DB RID: 475 RVA: 0x000080D8 File Offset: 0x000062D8
		internal unsafe void SetPixelShader(PixelShader shaderRef)
		{
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)((shaderRef == null) ? IntPtr.Zero : shaderRef.NativePointer), *(*(IntPtr*)this._nativePointer + (IntPtr)107 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001DC RID: 476 RVA: 0x00008128 File Offset: 0x00006328
		internal unsafe void GetPixelShader(out PixelShader shaderOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)108 * (IntPtr)sizeof(void*)));
			shaderOut = ((zero == IntPtr.Zero) ? null : new PixelShader(zero));
			result.CheckError();
		}

		// Token: 0x060001DD RID: 477 RVA: 0x00008184 File Offset: 0x00006384
		internal unsafe void SetPixelShaderConstantF(int startRegister, IntPtr constantDataRef, int vector4fCount)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, startRegister, (void*)constantDataRef, vector4fCount, *(*(IntPtr*)this._nativePointer + (IntPtr)109 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001DE RID: 478 RVA: 0x000081C4 File Offset: 0x000063C4
		internal unsafe void GetPixelShaderConstantF(int startRegister, float[] constantDataRef, int vector4fCount)
		{
			Result result;
			fixed (float[] array = constantDataRef)
			{
				void* ptr;
				if (constantDataRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, startRegister, ptr, vector4fCount, *(*(IntPtr*)this._nativePointer + (IntPtr)110 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060001DF RID: 479 RVA: 0x0000821C File Offset: 0x0000641C
		internal unsafe void SetPixelShaderConstantI(int startRegister, IntPtr constantDataRef, int vector4iCount)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, startRegister, (void*)constantDataRef, vector4iCount, *(*(IntPtr*)this._nativePointer + (IntPtr)111 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x0000825C File Offset: 0x0000645C
		internal unsafe void GetPixelShaderConstantI(int startRegister, int[] constantDataRef, int vector4iCount)
		{
			Result result;
			fixed (int[] array = constantDataRef)
			{
				void* ptr;
				if (constantDataRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, startRegister, ptr, vector4iCount, *(*(IntPtr*)this._nativePointer + (IntPtr)112 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x000082B4 File Offset: 0x000064B4
		internal unsafe void SetPixelShaderConstantB(int startRegister, IntPtr constantDataRef, int boolCount)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, startRegister, (void*)constantDataRef, boolCount, *(*(IntPtr*)this._nativePointer + (IntPtr)113 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x000082F4 File Offset: 0x000064F4
		internal unsafe void GetPixelShaderConstantB(int startRegister, IntPtr constantDataRef, int boolCount)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Int32), this._nativePointer, startRegister, (void*)constantDataRef, boolCount, *(*(IntPtr*)this._nativePointer + (IntPtr)114 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00008334 File Offset: 0x00006534
		internal unsafe void DrawRectanglePatch(int handle, float[] numSegsRef, IntPtr rectPatchInfoRef)
		{
			Result result;
			fixed (float[] array = numSegsRef)
			{
				void* ptr;
				if (numSegsRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, handle, ptr, (void*)rectPatchInfoRef, *(*(IntPtr*)this._nativePointer + (IntPtr)115 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x00008390 File Offset: 0x00006590
		internal unsafe void DrawTrianglePatch(int handle, float[] numSegsRef, IntPtr triPatchInfoRef)
		{
			Result result;
			fixed (float[] array = numSegsRef)
			{
				void* ptr;
				if (numSegsRef == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, handle, ptr, (void*)triPatchInfoRef, *(*(IntPtr*)this._nativePointer + (IntPtr)116 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x000083EC File Offset: 0x000065EC
		public unsafe void DeletePatch(int handle)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, handle, *(*(IntPtr*)this._nativePointer + (IntPtr)117 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x00008428 File Offset: 0x00006628
		internal unsafe void CreateQuery(QueryType type, Query queryOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, type, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)118 * (IntPtr)sizeof(void*)));
			queryOut.NativePointer = zero;
			result.CheckError();
		}
	}
}
