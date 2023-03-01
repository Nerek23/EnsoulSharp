using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000B9 RID: 185
	[Guid("c0bfa96c-e089-44fb-8eaf-26f8796190da")]
	public class DomainShaderStage : CommonShaderStage<DomainShader>
	{
		// Token: 0x0600038A RID: 906 RVA: 0x0000DDF6 File Offset: 0x0000BFF6
		public DomainShaderStage(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600038B RID: 907 RVA: 0x0000DDFF File Offset: 0x0000BFFF
		public static explicit operator DomainShaderStage(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new DomainShaderStage(nativePtr);
			}
			return null;
		}

		// Token: 0x0600038C RID: 908 RVA: 0x0000DE16 File Offset: 0x0000C016
		internal unsafe override void SetShaderResources(int startSlot, int numViews, IntPtr shaderResourceViewsOut)
		{
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, startSlot, numViews, (void*)shaderResourceViewsOut, *(*(IntPtr*)this._nativePointer + (IntPtr)63 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600038D RID: 909 RVA: 0x0000DE40 File Offset: 0x0000C040
		internal unsafe override void SetShader(DomainShader domainShaderRef, ClassInstance[] classInstancesOut, int numClassInstances)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr* ptr = null;
			if (classInstancesOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)classInstancesOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			value = CppObject.ToCallbackPtr<DomainShader>(domainShaderRef);
			if (classInstancesOut != null)
			{
				for (int i = 0; i < classInstancesOut.Length; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = CppObject.ToCallbackPtr<ClassInstance>(classInstancesOut[i]);
				}
			}
			calli(System.Void(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)value, ptr, numClassInstances, *(*(IntPtr*)this._nativePointer + (IntPtr)64 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600038E RID: 910 RVA: 0x0000DEB9 File Offset: 0x0000C0B9
		internal unsafe override void SetSamplers(int startSlot, int numSamplers, IntPtr samplersOut)
		{
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, startSlot, numSamplers, (void*)samplersOut, *(*(IntPtr*)this._nativePointer + (IntPtr)65 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600038F RID: 911 RVA: 0x0000DEE1 File Offset: 0x0000C0E1
		internal unsafe override void SetConstantBuffers(int startSlot, int numBuffers, IntPtr constantBuffersOut)
		{
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, startSlot, numBuffers, (void*)constantBuffersOut, *(*(IntPtr*)this._nativePointer + (IntPtr)66 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000390 RID: 912 RVA: 0x0000DF0C File Offset: 0x0000C10C
		internal unsafe override void GetShaderResources(int startSlot, int numViews, ShaderResourceView[] shaderResourceViewsOut)
		{
			IntPtr* ptr = null;
			if (shaderResourceViewsOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)shaderResourceViewsOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, startSlot, numViews, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)101 * (IntPtr)sizeof(void*)));
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

		// Token: 0x06000391 RID: 913 RVA: 0x0000DF94 File Offset: 0x0000C194
		internal unsafe override void GetShader(out DomainShader domainShaderOut, ClassInstance[] classInstancesOut, ref int numClassInstancesRef)
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
				calli(System.Void(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &zero, ptr, ptr3, *(*(IntPtr*)this._nativePointer + (IntPtr)102 * (IntPtr)sizeof(void*)));
			}
			if (zero != IntPtr.Zero)
			{
				domainShaderOut = new DomainShader(zero);
			}
			else
			{
				domainShaderOut = null;
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

		// Token: 0x06000392 RID: 914 RVA: 0x0000E04C File Offset: 0x0000C24C
		internal unsafe override void GetSamplers(int startSlot, int numSamplers, SamplerState[] samplersOut)
		{
			IntPtr* ptr = null;
			if (samplersOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)samplersOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, startSlot, numSamplers, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)103 * (IntPtr)sizeof(void*)));
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

		// Token: 0x06000393 RID: 915 RVA: 0x0000E0D4 File Offset: 0x0000C2D4
		internal unsafe override void GetConstantBuffers(int startSlot, int numBuffers, Buffer[] constantBuffersOut)
		{
			IntPtr* ptr = null;
			if (constantBuffersOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)constantBuffersOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, startSlot, numBuffers, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)104 * (IntPtr)sizeof(void*)));
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

		// Token: 0x06000394 RID: 916 RVA: 0x0000E15C File Offset: 0x0000C35C
		internal unsafe override void SetShader(DomainShader domainShaderRef, ComArray<ClassInstance> classInstancesOut, int numClassInstances)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<DomainShader>(domainShaderRef);
			calli(System.Void(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)value, (void*)((classInstancesOut != null) ? classInstancesOut.NativePointer : IntPtr.Zero), numClassInstances, *(*(IntPtr*)this._nativePointer + (IntPtr)64 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000395 RID: 917 RVA: 0x0000E1B0 File Offset: 0x0000C3B0
		private unsafe void SetShader(IntPtr domainShaderRef, IntPtr classInstancesOut, int numClassInstances)
		{
			calli(System.Void(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)domainShaderRef, (void*)classInstancesOut, numClassInstances, *(*(IntPtr*)this._nativePointer + (IntPtr)64 * (IntPtr)sizeof(void*)));
		}
	}
}
