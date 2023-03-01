using System;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000B9 RID: 185
	[Guid("6D3BDBDC-5B02-4415-B852-CE5E8BCCB289")]
	public class PixelShader : ComObject
	{
		// Token: 0x06000545 RID: 1349 RVA: 0x00002623 File Offset: 0x00000823
		public PixelShader(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x0001354C File Offset: 0x0001174C
		public new static explicit operator PixelShader(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new PixelShader(nativePointer);
			}
			return null;
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000547 RID: 1351 RVA: 0x00013564 File Offset: 0x00011764
		public Device Device
		{
			get
			{
				Device result;
				this.GetDevice(out result);
				return result;
			}
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x0001357C File Offset: 0x0001177C
		internal unsafe void GetDevice(out Device deviceOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			deviceOut = ((zero == IntPtr.Zero) ? null : new Device(zero));
			result.CheckError();
		}

		// Token: 0x06000549 RID: 1353 RVA: 0x000135D4 File Offset: 0x000117D4
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

		// Token: 0x0600054A RID: 1354 RVA: 0x0001361A File Offset: 0x0001181A
		public PixelShader(Device device, ShaderBytecode function)
		{
			device.CreatePixelShader(function.BufferPointer, this);
			this.function = function;
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x0600054B RID: 1355 RVA: 0x00013638 File Offset: 0x00011838
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

		// Token: 0x040009C8 RID: 2504
		public const int MaxDynamicFlowControlDepth = 24;

		// Token: 0x040009C9 RID: 2505
		public const int MinDynamicFlowControlDepth = 0;

		// Token: 0x040009CA RID: 2506
		public const int MaxTemps = 32;

		// Token: 0x040009CB RID: 2507
		public const int MinTemps = 12;

		// Token: 0x040009CC RID: 2508
		public const int MaxStaticFlowControlDepth = 4;

		// Token: 0x040009CD RID: 2509
		public const int MinStaticFlowControlDepth = 0;

		// Token: 0x040009CE RID: 2510
		public const int MaxInstructionSlots = 512;

		// Token: 0x040009CF RID: 2511
		public const int MinInstructionSlots = 96;

		// Token: 0x040009D0 RID: 2512
		private ShaderBytecode function;
	}
}
