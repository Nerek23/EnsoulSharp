using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000248 RID: 584
	[Guid("9b8b1336-00a5-4668-92b7-ced5d8bf9b7b")]
	public class VertexBuffer : ComObject
	{
		// Token: 0x06000D6A RID: 3434 RVA: 0x00024D3C File Offset: 0x00022F3C
		public unsafe VertexBuffer(EffectContext context, Guid resourceId, VertexBufferProperties vertexBufferProperties, CustomVertexBufferProperties customVertexBufferProperties) : base(IntPtr.Zero)
		{
			CustomVertexBufferProperties.__Native _Native = default(CustomVertexBufferProperties.__Native);
			customVertexBufferProperties.__MarshalTo(ref _Native);
			InputElement.__Native[] array = new InputElement.__Native[customVertexBufferProperties.InputElements.Length];
			try
			{
				for (int i = 0; i < customVertexBufferProperties.InputElements.Length; i++)
				{
					customVertexBufferProperties.InputElements[i].__MarshalTo(ref array[i]);
				}
				try
				{
					InputElement.__Native[] array2;
					void* value;
					if ((array2 = array) == null || array2.Length == 0)
					{
						value = null;
					}
					else
					{
						value = (void*)(&array2[0]);
					}
					_Native.InputElementsPointer = (IntPtr)value;
					_Native.ElementCount = customVertexBufferProperties.InputElements.Length;
					try
					{
						byte[] array3;
						void* value2;
						if ((array3 = customVertexBufferProperties.InputSignature) == null || array3.Length == 0)
						{
							value2 = null;
						}
						else
						{
							value2 = (void*)(&array3[0]);
						}
						_Native.ShaderBufferSize = customVertexBufferProperties.InputSignature.Length;
						_Native.ShaderBufferWithInputSignature = (IntPtr)value2;
						context.CreateVertexBuffer(vertexBufferProperties, new Guid?(resourceId), new IntPtr((void*)(&_Native)), this);
					}
					finally
					{
						byte[] array3 = null;
					}
				}
				finally
				{
					InputElement.__Native[] array2 = null;
				}
			}
			finally
			{
				for (int j = 0; j < array.Length; j++)
				{
					customVertexBufferProperties.InputElements[j].__MarshalFree(ref array[j]);
				}
			}
		}

		// Token: 0x06000D6B RID: 3435 RVA: 0x00002A7F File Offset: 0x00000C7F
		public VertexBuffer(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000D6C RID: 3436 RVA: 0x00024E94 File Offset: 0x00023094
		public new static explicit operator VertexBuffer(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new VertexBuffer(nativePtr);
			}
			return null;
		}

		// Token: 0x06000D6D RID: 3437 RVA: 0x00024EAC File Offset: 0x000230AC
		public unsafe void Map(byte[] data, int bufferSize)
		{
			Result result;
			fixed (byte[] array = data)
			{
				void* ptr;
				if (data == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, ptr, bufferSize, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000D6E RID: 3438 RVA: 0x00024F00 File Offset: 0x00023100
		public unsafe void Unmap()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
