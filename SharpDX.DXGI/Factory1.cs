using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DXGI
{
	// Token: 0x0200000D RID: 13
	[Guid("770aae78-f26f-4dba-a829-253c83d1b387")]
	public class Factory1 : Factory
	{
		// Token: 0x06000044 RID: 68 RVA: 0x00002BDC File Offset: 0x00000DDC
		public Factory1() : base(IntPtr.Zero)
		{
			IntPtr nativePointer;
			DXGI.CreateDXGIFactory1(Utilities.GetGuidFromType(base.GetType()), out nativePointer);
			base.NativePointer = nativePointer;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002C10 File Offset: 0x00000E10
		public Adapter1 GetAdapter1(int index)
		{
			Adapter1 result;
			this.GetAdapter1(index, out result).CheckError();
			return result;
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000046 RID: 70 RVA: 0x00002C30 File Offset: 0x00000E30
		public Adapter1[] Adapters1
		{
			get
			{
				List<Adapter1> list = new List<Adapter1>();
				Adapter1 item;
				while (!(this.GetAdapter1(list.Count, out item) == ResultCode.NotFound))
				{
					list.Add(item);
				}
				return list.ToArray();
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002C74 File Offset: 0x00000E74
		public int GetAdapterCount1()
		{
			int num = 0;
			for (;;)
			{
				Adapter1 adapter2;
				Result adapter = this.GetAdapter1(num, out adapter2);
				if (adapter2 != null)
				{
					adapter2.Dispose();
				}
				if (adapter == ResultCode.NotFound)
				{
					break;
				}
				num++;
			}
			return num;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002CAD File Offset: 0x00000EAD
		public Factory1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002CB6 File Offset: 0x00000EB6
		public new static explicit operator Factory1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Factory1(nativePtr);
			}
			return null;
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600004A RID: 74 RVA: 0x00002CCD File Offset: 0x00000ECD
		public RawBool IsCurrent
		{
			get
			{
				return this.IsCurrent_();
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002CD8 File Offset: 0x00000ED8
		internal unsafe Result GetAdapter1(int adapter, out Adapter1 adapterOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, adapter, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				adapterOut = new Adapter1(zero);
				return result;
			}
			adapterOut = null;
			return result;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002D2B File Offset: 0x00000F2B
		internal unsafe RawBool IsCurrent_()
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
		}
	}
}
