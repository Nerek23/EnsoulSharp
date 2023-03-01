using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000C2 RID: 194
	[Guid("B07C4FE5-310D-4ba8-A23C-4F0F206F218B")]
	public class StateBlock : ComObject
	{
		// Token: 0x060005E6 RID: 1510 RVA: 0x00002623 File Offset: 0x00000823
		public StateBlock(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x000155F8 File Offset: 0x000137F8
		public new static explicit operator StateBlock(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new StateBlock(nativePointer);
			}
			return null;
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060005E8 RID: 1512 RVA: 0x00015610 File Offset: 0x00013810
		public Device Device
		{
			get
			{
				Device result;
				this.GetDevice(out result);
				return result;
			}
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x00015628 File Offset: 0x00013828
		internal unsafe void GetDevice(out Device deviceOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			deviceOut = ((zero == IntPtr.Zero) ? null : new Device(zero));
			result.CheckError();
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x00015680 File Offset: 0x00013880
		public unsafe void Capture()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x000156B8 File Offset: 0x000138B8
		public unsafe void Apply()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060005EC RID: 1516 RVA: 0x000156EF File Offset: 0x000138EF
		public StateBlock(Device device, StateBlockType type)
		{
			device.CreateStateBlock(type, this);
		}
	}
}
