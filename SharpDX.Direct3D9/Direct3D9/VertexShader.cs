using System;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000CA RID: 202
	[Guid("EFC5557E-6265-4613-8A94-43857889EB36")]
	public class VertexShader : ComObject
	{
		// Token: 0x06000694 RID: 1684 RVA: 0x00002623 File Offset: 0x00000823
		public VertexShader(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x00017A5E File Offset: 0x00015C5E
		public new static explicit operator VertexShader(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new VertexShader(nativePointer);
			}
			return null;
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000696 RID: 1686 RVA: 0x00017A78 File Offset: 0x00015C78
		public Device Device
		{
			get
			{
				Device result;
				this.GetDevice(out result);
				return result;
			}
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x00017A90 File Offset: 0x00015C90
		internal unsafe void GetDevice(out Device deviceOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			deviceOut = ((zero == IntPtr.Zero) ? null : new Device(zero));
			result.CheckError();
		}

		// Token: 0x06000698 RID: 1688 RVA: 0x00017AE8 File Offset: 0x00015CE8
		internal unsafe void GetFunction(IntPtr arg0, ref int sizeOfDataRef)
		{
			Result result;
			fixed (int* ptr = &sizeOfDataRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)arg0, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x00017B2E File Offset: 0x00015D2E
		public VertexShader(Device device, ShaderBytecode function)
		{
			device.CreateVertexShader(function.BufferPointer, this);
			this.function = function;
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x0600069A RID: 1690 RVA: 0x00017B4C File Offset: 0x00015D4C
		public ShaderBytecode Function
		{
			get
			{
				if (this.function != null)
				{
					return this.function;
				}
				int numBytes = 0;
				this.GetFunction(IntPtr.Zero, ref numBytes);
				Blob blob;
				D3DX9.CreateBuffer(numBytes, out blob);
				this.GetFunction(blob.BufferPointer, ref numBytes);
				this.function = new ShaderBytecode(blob);
				return this.function;
			}
		}

		// Token: 0x040009D2 RID: 2514
		public const int MaxDynamicFlowControlDepth = 24;

		// Token: 0x040009D3 RID: 2515
		public const int MinDynamicFlowControlDepth = 0;

		// Token: 0x040009D4 RID: 2516
		public const int MaxTemps = 32;

		// Token: 0x040009D5 RID: 2517
		public const int MinTemps = 12;

		// Token: 0x040009D6 RID: 2518
		public const int MaxStaticFlowControlDepth = 4;

		// Token: 0x040009D7 RID: 2519
		public const int MinStaticFlowControlDepth = 1;

		// Token: 0x040009D8 RID: 2520
		private ShaderBytecode function;
	}
}
