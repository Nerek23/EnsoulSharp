using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200001B RID: 27
	[Guid("c0bfa96c-e089-44fb-8eaf-26f8796190da")]
	public class ComputeShaderStage : CommonShaderStage<ComputeShader>
	{
		// Token: 0x06000107 RID: 263 RVA: 0x00005774 File Offset: 0x00003974
		public UnorderedAccessView[] GetUnorderedAccessViews(int startSlot, int count)
		{
			UnorderedAccessView[] array = new UnorderedAccessView[count];
			this.GetUnorderedAccessViews(startSlot, count, array);
			return array;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00005792 File Offset: 0x00003992
		public void SetUnorderedAccessView(int startSlot, UnorderedAccessView unorderedAccessView)
		{
			this.SetUnorderedAccessView(startSlot, unorderedAccessView, -1);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x0000579D File Offset: 0x0000399D
		public void SetUnorderedAccessView(int startSlot, UnorderedAccessView unorderedAccessView, int uavInitialCount)
		{
			this.SetUnorderedAccessViews(startSlot, new UnorderedAccessView[]
			{
				unorderedAccessView
			}, new int[]
			{
				uavInitialCount
			});
		}

		// Token: 0x0600010A RID: 266 RVA: 0x000057BC File Offset: 0x000039BC
		public void SetUnorderedAccessViews(int startSlot, params UnorderedAccessView[] unorderedAccessViews)
		{
			int[] array = new int[unorderedAccessViews.Length];
			for (int i = 0; i < unorderedAccessViews.Length; i++)
			{
				array[i] = -1;
			}
			this.SetUnorderedAccessViews(startSlot, unorderedAccessViews, array);
		}

		// Token: 0x0600010B RID: 267 RVA: 0x000057F0 File Offset: 0x000039F0
		public unsafe void SetUnorderedAccessViews(int startSlot, UnorderedAccessView[] unorderedAccessViews, int[] uavInitialCounts)
		{
			IntPtr* ptr = null;
			if (unorderedAccessViews != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)unorderedAccessViews.Length) * (UIntPtr)sizeof(IntPtr))];
				for (int i = 0; i < unorderedAccessViews.Length; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = ((unorderedAccessViews[i] == null) ? IntPtr.Zero : unorderedAccessViews[i].NativePointer);
				}
			}
			fixed (int[] array = uavInitialCounts)
			{
				void* value;
				if (uavInitialCounts == null || array.Length == 0)
				{
					value = null;
				}
				else
				{
					value = (void*)(&array[0]);
				}
				this.SetUnorderedAccessViews(startSlot, (unorderedAccessViews != null) ? unorderedAccessViews.Length : 0, (IntPtr)((void*)ptr), (IntPtr)value);
			}
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00005875 File Offset: 0x00003A75
		public ComputeShaderStage(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600010D RID: 269 RVA: 0x0000587E File Offset: 0x00003A7E
		public static explicit operator ComputeShaderStage(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ComputeShaderStage(nativePtr);
			}
			return null;
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00005895 File Offset: 0x00003A95
		internal unsafe override void SetShaderResources(int startSlot, int numViews, IntPtr shaderResourceViewsOut)
		{
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, startSlot, numViews, (void*)shaderResourceViewsOut, *(*(IntPtr*)this._nativePointer + (IntPtr)67 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600010F RID: 271 RVA: 0x000058BD File Offset: 0x00003ABD
		internal unsafe override void SetUnorderedAccessViews(int startSlot, int numUAVs, IntPtr unorderedAccessViewsOut, IntPtr uAVInitialCountsRef)
		{
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*), this._nativePointer, startSlot, numUAVs, (void*)unorderedAccessViewsOut, (void*)uAVInitialCountsRef, *(*(IntPtr*)this._nativePointer + (IntPtr)68 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000110 RID: 272 RVA: 0x000058EC File Offset: 0x00003AEC
		internal unsafe override void SetShader(ComputeShader computeShaderRef, ClassInstance[] classInstancesOut, int numClassInstances)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr* ptr = null;
			if (classInstancesOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)classInstancesOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			value = CppObject.ToCallbackPtr<ComputeShader>(computeShaderRef);
			if (classInstancesOut != null)
			{
				for (int i = 0; i < classInstancesOut.Length; i++)
				{
					ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = CppObject.ToCallbackPtr<ClassInstance>(classInstancesOut[i]);
				}
			}
			calli(System.Void(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)value, ptr, numClassInstances, *(*(IntPtr*)this._nativePointer + (IntPtr)69 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00005965 File Offset: 0x00003B65
		internal unsafe override void SetSamplers(int startSlot, int numSamplers, IntPtr samplersOut)
		{
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, startSlot, numSamplers, (void*)samplersOut, *(*(IntPtr*)this._nativePointer + (IntPtr)70 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000112 RID: 274 RVA: 0x0000598D File Offset: 0x00003B8D
		internal unsafe override void SetConstantBuffers(int startSlot, int numBuffers, IntPtr constantBuffersOut)
		{
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, startSlot, numBuffers, (void*)constantBuffersOut, *(*(IntPtr*)this._nativePointer + (IntPtr)71 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000113 RID: 275 RVA: 0x000059B8 File Offset: 0x00003BB8
		internal unsafe override void GetShaderResources(int startSlot, int numViews, ShaderResourceView[] shaderResourceViewsOut)
		{
			IntPtr* ptr = null;
			if (shaderResourceViewsOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)shaderResourceViewsOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, startSlot, numViews, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)105 * (IntPtr)sizeof(void*)));
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

		// Token: 0x06000114 RID: 276 RVA: 0x00005A40 File Offset: 0x00003C40
		internal unsafe void GetUnorderedAccessViews(int startSlot, int numUAVs, UnorderedAccessView[] unorderedAccessViewsOut)
		{
			IntPtr* ptr = null;
			if (unorderedAccessViewsOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)unorderedAccessViewsOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, startSlot, numUAVs, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)106 * (IntPtr)sizeof(void*)));
			if (unorderedAccessViewsOut != null)
			{
				for (int i = 0; i < unorderedAccessViewsOut.Length; i++)
				{
					if (ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] != IntPtr.Zero)
					{
						unorderedAccessViewsOut[i] = new UnorderedAccessView(ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
					}
					else
					{
						unorderedAccessViewsOut[i] = null;
					}
				}
			}
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00005AC8 File Offset: 0x00003CC8
		internal unsafe override void GetShader(out ComputeShader computeShaderOut, ClassInstance[] classInstancesOut, ref int numClassInstancesRef)
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
				calli(System.Void(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &zero, ptr, ptr3, *(*(IntPtr*)this._nativePointer + (IntPtr)107 * (IntPtr)sizeof(void*)));
			}
			if (zero != IntPtr.Zero)
			{
				computeShaderOut = new ComputeShader(zero);
			}
			else
			{
				computeShaderOut = null;
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

		// Token: 0x06000116 RID: 278 RVA: 0x00005B80 File Offset: 0x00003D80
		internal unsafe override void GetSamplers(int startSlot, int numSamplers, SamplerState[] samplersOut)
		{
			IntPtr* ptr = null;
			if (samplersOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)samplersOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, startSlot, numSamplers, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)108 * (IntPtr)sizeof(void*)));
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

		// Token: 0x06000117 RID: 279 RVA: 0x00005C08 File Offset: 0x00003E08
		internal unsafe override void GetConstantBuffers(int startSlot, int numBuffers, Buffer[] constantBuffersOut)
		{
			IntPtr* ptr = null;
			if (constantBuffersOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)constantBuffersOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*), this._nativePointer, startSlot, numBuffers, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)109 * (IntPtr)sizeof(void*)));
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

		// Token: 0x06000118 RID: 280 RVA: 0x00005C90 File Offset: 0x00003E90
		internal unsafe override void SetShader(ComputeShader computeShaderRef, ComArray<ClassInstance> classInstancesOut, int numClassInstances)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<ComputeShader>(computeShaderRef);
			calli(System.Void(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)value, (void*)((classInstancesOut != null) ? classInstancesOut.NativePointer : IntPtr.Zero), numClassInstances, *(*(IntPtr*)this._nativePointer + (IntPtr)69 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00005CE4 File Offset: 0x00003EE4
		private unsafe void SetShader(IntPtr computeShaderRef, IntPtr classInstancesOut, int numClassInstances)
		{
			calli(System.Void(System.Void*,System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)computeShaderRef, (void*)classInstancesOut, numClassInstances, *(*(IntPtr*)this._nativePointer + (IntPtr)69 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x04000057 RID: 87
		public const int UnorderedAccessViewSlotCount = 8;

		// Token: 0x04000058 RID: 88
		public const int DispatchMaximumThreadGroupsPerDimension = 65535;

		// Token: 0x04000059 RID: 89
		public const int ThreadGroupSharedMemoryRegisterCount = 8192;

		// Token: 0x0400005A RID: 90
		public const int ThreadGroupSharedMemoryRegisterReadsPerInst = 1;

		// Token: 0x0400005B RID: 91
		public const int ThreadGroupSharedMemoryResourceRegisterComponents = 1;

		// Token: 0x0400005C RID: 92
		public const int ThreadGroupSharedMemoryResourceRegisterReadPorts = 1;

		// Token: 0x0400005D RID: 93
		public const int ThreadgroupidRegisterComponents = 3;

		// Token: 0x0400005E RID: 94
		public const int ThreadgroupidRegisterCount = 1;

		// Token: 0x0400005F RID: 95
		public const int ThreadidingroupflattenedRegisterComponents = 1;

		// Token: 0x04000060 RID: 96
		public const int ThreadidingroupflattenedRegisterCount = 1;

		// Token: 0x04000061 RID: 97
		public const int ThreadidingroupRegisterComponents = 3;

		// Token: 0x04000062 RID: 98
		public const int ThreadidingroupRegisterCount = 1;

		// Token: 0x04000063 RID: 99
		public const int ThreadidRegisterComponents = 3;

		// Token: 0x04000064 RID: 100
		public const int ThreadidRegisterCount = 1;

		// Token: 0x04000065 RID: 101
		public const int ThreadGroupMaximumThreadsPerGroup = 1024;

		// Token: 0x04000066 RID: 102
		public const int ThreadGroupMaximumX = 1024;

		// Token: 0x04000067 RID: 103
		public const int ThreadGroupMaximumY = 1024;

		// Token: 0x04000068 RID: 104
		public const int ThreadGroupMaximumZ = 64;

		// Token: 0x04000069 RID: 105
		public const int ThreadGroupMinimumX = 1;

		// Token: 0x0400006A RID: 106
		public const int ThreadGroupMinimumY = 1;

		// Token: 0x0400006B RID: 107
		public const int ThreadGroupMinimumZ = 1;

		// Token: 0x0400006C RID: 108
		public const int ThreadLocalTempRegisterPool = 16384;
	}
}
