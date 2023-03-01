using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000BA RID: 186
	[Guid("c0bfa96c-e089-44fb-8eaf-26f8796190da")]
	public class GeometryShaderStage : CommonShaderStage<GeometryShader>
	{
		// Token: 0x06000396 RID: 918 RVA: 0x0000E1DD File Offset: 0x0000C3DD
		public GeometryShaderStage(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000397 RID: 919 RVA: 0x0000E1E6 File Offset: 0x0000C3E6
		public static explicit operator GeometryShaderStage(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new GeometryShaderStage(nativePtr);
			}
			return null;
		}

		// Token: 0x06000398 RID: 920 RVA: 0x0000E1FD File Offset: 0x0000C3FD
		internal unsafe override void SetConstantBuffers(int startSlot, int numBuffers, IntPtr constantBuffersOut)
		{
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, startSlot, numBuffers, (void*)constantBuffersOut, *(*(IntPtr*)this._nativePointer + (IntPtr)22 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000399 RID: 921 RVA: 0x0000E228 File Offset: 0x0000C428
		internal unsafe override void SetShader(GeometryShader shaderRef, ClassInstance[] classInstancesOut, int numClassInstances)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr* ptr = null;
			if (classInstancesOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)classInstancesOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			value = CppObject.ToCallbackPtr<GeometryShader>(shaderRef);
			if (classInstancesOut != null)
			{
				for (int i = 0; i < classInstancesOut.Length; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = CppObject.ToCallbackPtr<ClassInstance>(classInstancesOut[i]);
				}
			}
			calli(System.Void(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)value, ptr, numClassInstances, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600039A RID: 922 RVA: 0x0000E2A1 File Offset: 0x0000C4A1
		internal unsafe override void SetShaderResources(int startSlot, int numViews, IntPtr shaderResourceViewsOut)
		{
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, startSlot, numViews, (void*)shaderResourceViewsOut, *(*(IntPtr*)this._nativePointer + (IntPtr)31 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600039B RID: 923 RVA: 0x0000E2C9 File Offset: 0x0000C4C9
		internal unsafe override void SetSamplers(int startSlot, int numSamplers, IntPtr samplersOut)
		{
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, startSlot, numSamplers, (void*)samplersOut, *(*(IntPtr*)this._nativePointer + (IntPtr)32 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600039C RID: 924 RVA: 0x0000E2F4 File Offset: 0x0000C4F4
		internal unsafe override void GetConstantBuffers(int startSlot, int numBuffers, Buffer[] constantBuffersOut)
		{
			IntPtr* ptr = null;
			if (constantBuffersOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)constantBuffersOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, startSlot, numBuffers, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)81 * (IntPtr)sizeof(void*)));
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

		// Token: 0x0600039D RID: 925 RVA: 0x0000E37C File Offset: 0x0000C57C
		internal unsafe override void GetShader(out GeometryShader geometryShaderOut, ClassInstance[] classInstancesOut, ref int numClassInstancesRef)
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
				calli(System.Void(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &zero, ptr, ptr3, *(*(IntPtr*)this._nativePointer + (IntPtr)82 * (IntPtr)sizeof(void*)));
			}
			if (zero != IntPtr.Zero)
			{
				geometryShaderOut = new GeometryShader(zero);
			}
			else
			{
				geometryShaderOut = null;
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

		// Token: 0x0600039E RID: 926 RVA: 0x0000E434 File Offset: 0x0000C634
		internal unsafe override void GetShaderResources(int startSlot, int numViews, ShaderResourceView[] shaderResourceViewsOut)
		{
			IntPtr* ptr = null;
			if (shaderResourceViewsOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)shaderResourceViewsOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, startSlot, numViews, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)87 * (IntPtr)sizeof(void*)));
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

		// Token: 0x0600039F RID: 927 RVA: 0x0000E4BC File Offset: 0x0000C6BC
		internal unsafe override void GetSamplers(int startSlot, int numSamplers, SamplerState[] samplersOut)
		{
			IntPtr* ptr = null;
			if (samplersOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)samplersOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, startSlot, numSamplers, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)88 * (IntPtr)sizeof(void*)));
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

		// Token: 0x060003A0 RID: 928 RVA: 0x0000E544 File Offset: 0x0000C744
		internal unsafe override void SetShader(GeometryShader shaderRef, ComArray<ClassInstance> classInstancesOut, int numClassInstances)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<GeometryShader>(shaderRef);
			calli(System.Void(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)value, (void*)((classInstancesOut != null) ? classInstancesOut.NativePointer : IntPtr.Zero), numClassInstances, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x0000E598 File Offset: 0x0000C798
		private unsafe void SetShader(IntPtr shaderRef, IntPtr classInstancesOut, int numClassInstances)
		{
			calli(System.Void(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)shaderRef, (void*)classInstancesOut, numClassInstances, *(*(IntPtr*)this._nativePointer + (IntPtr)23 * (IntPtr)sizeof(void*)));
		}
	}
}
