using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000C3 RID: 195
	[Guid("c0bfa96c-e089-44fb-8eaf-26f8796190da")]
	public class VertexShaderStage : CommonShaderStage<VertexShader>
	{
		// Token: 0x060003D6 RID: 982 RVA: 0x0000F049 File Offset: 0x0000D249
		public VertexShaderStage(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x0000F052 File Offset: 0x0000D252
		public static explicit operator VertexShaderStage(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new VertexShaderStage(nativePtr);
			}
			return null;
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x0000F069 File Offset: 0x0000D269
		internal unsafe override void SetConstantBuffers(int startSlot, int numBuffers, IntPtr constantBuffersOut)
		{
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, startSlot, numBuffers, (void*)constantBuffersOut, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x0000F090 File Offset: 0x0000D290
		internal unsafe override void SetShader(VertexShader vertexShaderRef, ClassInstance[] classInstancesOut, int numClassInstances)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr* ptr = null;
			if (classInstancesOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)classInstancesOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			value = CppObject.ToCallbackPtr<VertexShader>(vertexShaderRef);
			if (classInstancesOut != null)
			{
				for (int i = 0; i < classInstancesOut.Length; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = CppObject.ToCallbackPtr<ClassInstance>(classInstancesOut[i]);
				}
			}
			calli(System.Void(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)value, ptr, numClassInstances, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060003DA RID: 986 RVA: 0x0000F109 File Offset: 0x0000D309
		internal unsafe override void SetShaderResources(int startSlot, int numViews, IntPtr shaderResourceViewsOut)
		{
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, startSlot, numViews, (void*)shaderResourceViewsOut, *(*(IntPtr*)this._nativePointer + (IntPtr)25 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060003DB RID: 987 RVA: 0x0000F131 File Offset: 0x0000D331
		internal unsafe override void SetSamplers(int startSlot, int numSamplers, IntPtr samplersOut)
		{
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, startSlot, numSamplers, (void*)samplersOut, *(*(IntPtr*)this._nativePointer + (IntPtr)26 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060003DC RID: 988 RVA: 0x0000F15C File Offset: 0x0000D35C
		internal unsafe override void GetConstantBuffers(int startSlot, int numBuffers, Buffer[] constantBuffersOut)
		{
			IntPtr* ptr = null;
			if (constantBuffersOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)constantBuffersOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, startSlot, numBuffers, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)72 * (IntPtr)sizeof(void*)));
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

		// Token: 0x060003DD RID: 989 RVA: 0x0000F1E4 File Offset: 0x0000D3E4
		internal unsafe override void GetShader(out VertexShader vertexShaderOut, ClassInstance[] classInstancesOut, ref int numClassInstancesRef)
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
				calli(System.Void(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &zero, ptr, ptr3, *(*(IntPtr*)this._nativePointer + (IntPtr)76 * (IntPtr)sizeof(void*)));
			}
			if (zero != IntPtr.Zero)
			{
				vertexShaderOut = new VertexShader(zero);
			}
			else
			{
				vertexShaderOut = null;
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

		// Token: 0x060003DE RID: 990 RVA: 0x0000F29C File Offset: 0x0000D49C
		internal unsafe override void GetShaderResources(int startSlot, int numViews, ShaderResourceView[] shaderResourceViewsOut)
		{
			IntPtr* ptr = null;
			if (shaderResourceViewsOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)shaderResourceViewsOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, startSlot, numViews, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)84 * (IntPtr)sizeof(void*)));
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

		// Token: 0x060003DF RID: 991 RVA: 0x0000F324 File Offset: 0x0000D524
		internal unsafe override void GetSamplers(int startSlot, int numSamplers, SamplerState[] samplersOut)
		{
			IntPtr* ptr = null;
			if (samplersOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)samplersOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, startSlot, numSamplers, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)85 * (IntPtr)sizeof(void*)));
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

		// Token: 0x060003E0 RID: 992 RVA: 0x0000F3AC File Offset: 0x0000D5AC
		internal unsafe override void SetShader(VertexShader vertexShaderRef, ComArray<ClassInstance> classInstancesOut, int numClassInstances)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<VertexShader>(vertexShaderRef);
			calli(System.Void(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)value, (void*)((classInstancesOut != null) ? classInstancesOut.NativePointer : IntPtr.Zero), numClassInstances, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x0000F400 File Offset: 0x0000D600
		private unsafe void SetShader(IntPtr vertexShaderRef, IntPtr classInstancesOut, int numClassInstances)
		{
			calli(System.Void(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)vertexShaderRef, (void*)classInstancesOut, numClassInstances, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
		}
	}
}
