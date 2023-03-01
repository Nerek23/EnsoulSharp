using System;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;
using SharpDX.DXGI;

namespace SharpDX.Direct3D11
{
	// Token: 0x0200001D RID: 29
	[Guid("c0bfa96c-e089-44fb-8eaf-26f8796190da")]
	public class InputAssemblerStage : CppObject
	{
		// Token: 0x06000172 RID: 370 RVA: 0x00006E60 File Offset: 0x00005060
		public unsafe void SetVertexBuffers(int slot, VertexBufferBinding vertexBufferBinding)
		{
			int stride = vertexBufferBinding.Stride;
			int offset = vertexBufferBinding.Offset;
			IntPtr intPtr = (vertexBufferBinding.Buffer == null) ? IntPtr.Zero : vertexBufferBinding.Buffer.NativePointer;
			this.SetVertexBuffers(slot, 1, new IntPtr((void*)(&intPtr)), new IntPtr((void*)(&stride)), new IntPtr((void*)(&offset)));
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00006EBC File Offset: 0x000050BC
		public unsafe void SetVertexBuffers(int firstSlot, params VertexBufferBinding[] vertexBufferBindings)
		{
			int num = vertexBufferBindings.Length;
			IntPtr* ptr;
			int* ptr2;
			int* ptr3;
			checked
			{
				ptr = stackalloc IntPtr[unchecked((UIntPtr)num) * (UIntPtr)sizeof(IntPtr)];
				ptr2 = stackalloc int[unchecked((UIntPtr)num) * 4];
				ptr3 = stackalloc int[unchecked((UIntPtr)num) * 4];
			}
			for (int i = 0; i < vertexBufferBindings.Length; i++)
			{
				ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = ((vertexBufferBindings[i].Buffer == null) ? IntPtr.Zero : vertexBufferBindings[i].Buffer.NativePointer);
				ptr2[i] = vertexBufferBindings[i].Stride;
				ptr3[i] = vertexBufferBindings[i].Offset;
			}
			this.SetVertexBuffers(firstSlot, num, new IntPtr((void*)ptr), new IntPtr((void*)ptr2), new IntPtr((void*)ptr3));
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00006F74 File Offset: 0x00005174
		public unsafe void SetVertexBuffers(int slot, Buffer[] vertexBuffers, int[] stridesRef, int[] offsetsRef)
		{
			IntPtr* ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)vertexBuffers.Length) * (UIntPtr)sizeof(IntPtr))];
			for (int i = 0; i < vertexBuffers.Length; i++)
			{
				ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = ((vertexBuffers[i] == null) ? IntPtr.Zero : vertexBuffers[i].NativePointer);
			}
			fixed (int[] array = stridesRef)
			{
				void* value;
				if (stridesRef == null || array.Length == 0)
				{
					value = null;
				}
				else
				{
					value = (void*)(&array[0]);
				}
				fixed (int[] array2 = offsetsRef)
				{
					void* value2;
					if (offsetsRef == null || array2.Length == 0)
					{
						value2 = null;
					}
					else
					{
						value2 = (void*)(&array2[0]);
					}
					this.SetVertexBuffers(slot, vertexBuffers.Length, new IntPtr((void*)ptr), (IntPtr)value, (IntPtr)value2);
				}
			}
		}

		// Token: 0x06000175 RID: 373 RVA: 0x0000543D File Offset: 0x0000363D
		public InputAssemblerStage(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00007015 File Offset: 0x00005215
		public static explicit operator InputAssemblerStage(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new InputAssemblerStage(nativePtr);
			}
			return null;
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000177 RID: 375 RVA: 0x0000702C File Offset: 0x0000522C
		// (set) Token: 0x06000178 RID: 376 RVA: 0x00007042 File Offset: 0x00005242
		public InputLayout InputLayout
		{
			get
			{
				InputLayout result;
				this.GetInputLayout(out result);
				return result;
			}
			set
			{
				this.SetInputLayout(value);
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000179 RID: 377 RVA: 0x0000704C File Offset: 0x0000524C
		// (set) Token: 0x0600017A RID: 378 RVA: 0x00007062 File Offset: 0x00005262
		public PrimitiveTopology PrimitiveTopology
		{
			get
			{
				PrimitiveTopology result;
				this.GetPrimitiveTopology(out result);
				return result;
			}
			set
			{
				this.SetPrimitiveTopology(value);
			}
		}

		// Token: 0x0600017B RID: 379 RVA: 0x0000706C File Offset: 0x0000526C
		internal unsafe void SetInputLayout(InputLayout inputLayoutRef)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<InputLayout>(inputLayoutRef);
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600017C RID: 380 RVA: 0x000070AC File Offset: 0x000052AC
		public unsafe void SetVertexBuffers(int startSlot, int numBuffers, IntPtr vertexBuffersOut, IntPtr stridesRef, IntPtr offsetsRef)
		{
			calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, startSlot, numBuffers, (void*)vertexBuffersOut, (void*)stridesRef, (void*)offsetsRef, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600017D RID: 381 RVA: 0x000070F0 File Offset: 0x000052F0
		public unsafe void SetIndexBuffer(Buffer indexBufferRef, Format format, int offset)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Buffer>(indexBufferRef);
			calli(System.Void(System.Void*,System.Void*,System.Int32,System.Int32), this._nativePointer, (void*)value, format, offset, *(*(IntPtr*)this._nativePointer + (IntPtr)19 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00007130 File Offset: 0x00005330
		internal unsafe void SetPrimitiveTopology(PrimitiveTopology topology)
		{
			calli(System.Void(System.Void*,System.Int32), this._nativePointer, topology, *(*(IntPtr*)this._nativePointer + (IntPtr)24 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00007154 File Offset: 0x00005354
		internal unsafe void GetInputLayout(out InputLayout inputLayoutOut)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)78 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				inputLayoutOut = new InputLayout(zero);
				return;
			}
			inputLayoutOut = null;
		}

		// Token: 0x06000180 RID: 384 RVA: 0x000071A4 File Offset: 0x000053A4
		public unsafe void GetVertexBuffers(int startSlot, int numBuffers, Buffer[] vertexBuffersOut, int[] stridesRef, int[] offsetsRef)
		{
			IntPtr* ptr = null;
			if (vertexBuffersOut != null)
			{
				ptr = stackalloc IntPtr[checked(unchecked((UIntPtr)vertexBuffersOut.Length) * (UIntPtr)sizeof(IntPtr))];
			}
			fixed (int[] array = offsetsRef)
			{
				void* ptr2;
				if (offsetsRef == null || array.Length == 0)
				{
					ptr2 = null;
				}
				else
				{
					ptr2 = (void*)(&array[0]);
				}
				fixed (int[] array2 = stridesRef)
				{
					void* ptr3;
					if (stridesRef == null || array2.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array2[0]);
					}
					calli(System.Void(System.Void*,System.Int32,System.Int32,System.Void*,System.Void*,System.Void*), this._nativePointer, startSlot, numBuffers, ptr, ptr3, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)79 * (IntPtr)sizeof(void*)));
				}
			}
			if (vertexBuffersOut != null)
			{
				for (int i = 0; i < vertexBuffersOut.Length; i++)
				{
					if (ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] != IntPtr.Zero)
					{
						vertexBuffersOut[i] = new Buffer(ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
					}
					else
					{
						vertexBuffersOut[i] = null;
					}
				}
			}
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00007270 File Offset: 0x00005470
		public unsafe void GetIndexBuffer(out Buffer indexBufferRef, out Format format, out int offset)
		{
			IntPtr zero = IntPtr.Zero;
			fixed (int* ptr = &offset)
			{
				void* ptr2 = (void*)ptr;
				fixed (Format* ptr3 = &format)
				{
					void* ptr4 = (void*)ptr3;
					calli(System.Void(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &zero, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)80 * (IntPtr)sizeof(void*)));
				}
			}
			if (zero != IntPtr.Zero)
			{
				indexBufferRef = new Buffer(zero);
				return;
			}
			indexBufferRef = null;
		}

		// Token: 0x06000182 RID: 386 RVA: 0x000072D4 File Offset: 0x000054D4
		internal unsafe void GetPrimitiveTopology(out PrimitiveTopology topologyRef)
		{
			fixed (PrimitiveTopology* ptr = &topologyRef)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)83 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x04000079 RID: 121
		public const int DefaultIndexBufferOffsetInBytes = 0;

		// Token: 0x0400007A RID: 122
		public const int DefaultPrimitiveTopology = 0;

		// Token: 0x0400007B RID: 123
		public const int DefaultVertexBufferOffsetInBytes = 0;

		// Token: 0x0400007C RID: 124
		public const int IndexInputResourceSlotCount = 1;

		// Token: 0x0400007D RID: 125
		public const int InstanceIdBitCount = 32;

		// Token: 0x0400007E RID: 126
		public const int IntegerArithmeticBitCount = 32;

		// Token: 0x0400007F RID: 127
		public const int PatchMaximumControlPointCount = 32;

		// Token: 0x04000080 RID: 128
		public const int PrimitiveIdBitCount = 32;

		// Token: 0x04000081 RID: 129
		public const int VertexIdBitCount = 32;

		// Token: 0x04000082 RID: 130
		public const int VertexInputResourceSlotCount = 32;

		// Token: 0x04000083 RID: 131
		public const int VertexInputStructureElementsComponents = 128;

		// Token: 0x04000084 RID: 132
		public const int VertexInputStructureElementCount = 32;
	}
}
