using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000BD RID: 189
	[Guid("c0bfa96c-e089-44fb-8eaf-26f8796190da")]
	public class PixelShaderStage : CommonShaderStage<PixelShader>
	{
		// Token: 0x060003B4 RID: 948 RVA: 0x0000EA22 File Offset: 0x0000CC22
		public PixelShaderStage(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x0000EA2B File Offset: 0x0000CC2B
		public static explicit operator PixelShaderStage(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new PixelShaderStage(nativePtr);
			}
			return null;
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x0000EA42 File Offset: 0x0000CC42
		internal unsafe override void SetShaderResources(int startSlot, int numViews, IntPtr shaderResourceViewsOut)
		{
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, startSlot, numViews, (void*)shaderResourceViewsOut, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x0000EA6C File Offset: 0x0000CC6C
		internal unsafe override void SetShader(PixelShader pixelShaderRef, ClassInstance[] classInstancesOut, int numClassInstances)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr* ptr = null;
			if (classInstancesOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)classInstancesOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			value = CppObject.ToCallbackPtr<PixelShader>(pixelShaderRef);
			if (classInstancesOut != null)
			{
				for (int i = 0; i < classInstancesOut.Length; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = CppObject.ToCallbackPtr<ClassInstance>(classInstancesOut[i]);
				}
			}
			calli(System.Void(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)value, ptr, numClassInstances, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x0000EAE5 File Offset: 0x0000CCE5
		internal unsafe override void SetSamplers(int startSlot, int numSamplers, IntPtr samplersOut)
		{
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, startSlot, numSamplers, (void*)samplersOut, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x0000EB0D File Offset: 0x0000CD0D
		internal unsafe override void SetConstantBuffers(int startSlot, int numBuffers, IntPtr constantBuffersOut)
		{
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, startSlot, numBuffers, (void*)constantBuffersOut, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060003BA RID: 954 RVA: 0x0000EB38 File Offset: 0x0000CD38
		internal unsafe override void GetShaderResources(int startSlot, int numViews, ShaderResourceView[] shaderResourceViewsOut)
		{
			IntPtr* ptr = null;
			if (shaderResourceViewsOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)shaderResourceViewsOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, startSlot, numViews, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)73 * (IntPtr)sizeof(void*)));
			if (shaderResourceViewsOut != null)
			{
				for (int i = 0; i < shaderResourceViewsOut.Length; i++)
				{
					if (ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] != IntPtr.Zero)
					{
						shaderResourceViewsOut[i] = new ShaderResourceView(ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
					}
					else
					{
						shaderResourceViewsOut[i] = null;
					}
				}
			}
		}

		// Token: 0x060003BB RID: 955 RVA: 0x0000EBC0 File Offset: 0x0000CDC0
		internal unsafe override void GetShader(out PixelShader pixelShaderOut, ClassInstance[] classInstancesOut, ref int numClassInstancesRef)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr* ptr = null;
			if (classInstancesOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)classInstancesOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			fixed (int* ptr2 = &numClassInstancesRef)
			{
				void* ptr3 = (void*)ptr2;
				calli(System.Void(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &zero, ptr, ptr3, *(*(IntPtr*)this._nativePointer + (IntPtr)74 * (IntPtr)sizeof(void*)));
			}
			if (zero != IntPtr.Zero)
			{
				pixelShaderOut = new PixelShader(zero);
			}
			else
			{
				pixelShaderOut = null;
			}
			if (classInstancesOut != null)
			{
				for (int i = 0; i < classInstancesOut.Length; i++)
				{
					if (ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] != IntPtr.Zero)
					{
						classInstancesOut[i] = new ClassInstance(ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
					}
					else
					{
						classInstancesOut[i] = null;
					}
				}
			}
		}

		// Token: 0x060003BC RID: 956 RVA: 0x0000EC78 File Offset: 0x0000CE78
		internal unsafe override void GetSamplers(int startSlot, int numSamplers, SamplerState[] samplersOut)
		{
			IntPtr* ptr = null;
			if (samplersOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)samplersOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, startSlot, numSamplers, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)75 * (IntPtr)sizeof(void*)));
			if (samplersOut != null)
			{
				for (int i = 0; i < samplersOut.Length; i++)
				{
					if (ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] != IntPtr.Zero)
					{
						samplersOut[i] = new SamplerState(ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
					}
					else
					{
						samplersOut[i] = null;
					}
				}
			}
		}

		// Token: 0x060003BD RID: 957 RVA: 0x0000ED00 File Offset: 0x0000CF00
		internal unsafe override void GetConstantBuffers(int startSlot, int numBuffers, Buffer[] constantBuffersOut)
		{
			IntPtr* ptr = null;
			if (constantBuffersOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)constantBuffersOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, startSlot, numBuffers, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)77 * (IntPtr)sizeof(void*)));
			if (constantBuffersOut != null)
			{
				for (int i = 0; i < constantBuffersOut.Length; i++)
				{
					if (ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] != IntPtr.Zero)
					{
						constantBuffersOut[i] = new Buffer(ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
					}
					else
					{
						constantBuffersOut[i] = null;
					}
				}
			}
		}

		// Token: 0x060003BE RID: 958 RVA: 0x0000ED88 File Offset: 0x0000CF88
		internal unsafe override void SetShader(PixelShader pixelShaderRef, ComArray<ClassInstance> classInstancesOut, int numClassInstances)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<PixelShader>(pixelShaderRef);
			calli(System.Void(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)value, (void*)((classInstancesOut != null) ? classInstancesOut.NativePointer : IntPtr.Zero), numClassInstances, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060003BF RID: 959 RVA: 0x0000EDDC File Offset: 0x0000CFDC
		private unsafe void SetShader(IntPtr pixelShaderRef, IntPtr classInstancesOut, int numClassInstances)
		{
			calli(System.Void(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)pixelShaderRef, (void*)classInstancesOut, numClassInstances, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0400089D RID: 2205
		public const float PixelCenterFractionalComponent = 0.5f;

		// Token: 0x0400089E RID: 2206
		public const int FrontfacingDefaultValue = -1;

		// Token: 0x0400089F RID: 2207
		public const int FrontfacingFalseValue = 0;

		// Token: 0x040008A0 RID: 2208
		public const int FrontfacingTrueValue = -1;

		// Token: 0x040008A1 RID: 2209
		public const int InputRegisterComponents = 4;

		// Token: 0x040008A2 RID: 2210
		public const int InputRegisterComponentBitCount = 32;

		// Token: 0x040008A3 RID: 2211
		public const int InputRegisterCount = 32;

		// Token: 0x040008A4 RID: 2212
		public const int InputRegisterReadsPerInst = 2;

		// Token: 0x040008A5 RID: 2213
		public const int InputRegisterReadPorts = 1;

		// Token: 0x040008A6 RID: 2214
		public const int LegacyPixelCenterFractionalComponent = 0;

		// Token: 0x040008A7 RID: 2215
		public const int OutputDepthRegisterComponents = 1;

		// Token: 0x040008A8 RID: 2216
		public const int OutputDepthRegisterComponentBitCount = 32;

		// Token: 0x040008A9 RID: 2217
		public const int OutputDepthRegisterCount = 1;

		// Token: 0x040008AA RID: 2218
		public const int OutputMaskRegisterComponents = 1;

		// Token: 0x040008AB RID: 2219
		public const int OutputMaskRegisterComponentBitCount = 32;

		// Token: 0x040008AC RID: 2220
		public const int OutputMaskRegisterCount = 1;

		// Token: 0x040008AD RID: 2221
		public const int OutputRegisterComponents = 4;

		// Token: 0x040008AE RID: 2222
		public const int OutputRegisterComponentBitCount = 32;

		// Token: 0x040008AF RID: 2223
		public const int OutputRegisterCount = 8;
	}
}
