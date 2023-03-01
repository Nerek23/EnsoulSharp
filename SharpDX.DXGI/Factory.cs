using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x0200000C RID: 12
	[Guid("7b7166ec-21c7-44ae-b21a-c9ae321ae369")]
	public class Factory : DXGIObject
	{
		// Token: 0x0600003A RID: 58 RVA: 0x00002990 File Offset: 0x00000B90
		public Adapter GetAdapter(int index)
		{
			Adapter result;
			this.GetAdapter(index, out result).CheckError();
			return result;
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600003B RID: 59 RVA: 0x000029B0 File Offset: 0x00000BB0
		public Adapter[] Adapters
		{
			get
			{
				List<Adapter> list = new List<Adapter>();
				Adapter item;
				while (!(this.GetAdapter(list.Count, out item) == ResultCode.NotFound))
				{
					list.Add(item);
				}
				return list.ToArray();
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000029F4 File Offset: 0x00000BF4
		public int GetAdapterCount()
		{
			int num = 0;
			for (;;)
			{
				Adapter adapter2;
				Result adapter = this.GetAdapter(num, out adapter2);
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

		// Token: 0x0600003D RID: 61 RVA: 0x00002165 File Offset: 0x00000365
		public Factory(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002A2D File Offset: 0x00000C2D
		public new static explicit operator Factory(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Factory(nativePtr);
			}
			return null;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002A44 File Offset: 0x00000C44
		internal unsafe Result GetAdapter(int adapter, out Adapter adapterOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, adapter, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				adapterOut = new Adapter(zero);
				return result;
			}
			adapterOut = null;
			return result;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002A98 File Offset: 0x00000C98
		public unsafe void MakeWindowAssociation(IntPtr windowHandle, WindowAssociationFlags flags)
		{
			calli(System.Int32(System.Void*,System.Void*,System.Int32), this._nativePointer, (void*)windowHandle, flags, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002AD8 File Offset: 0x00000CD8
		public unsafe IntPtr GetWindowAssociation()
		{
			IntPtr result;
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &result, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*))).CheckError();
			return result;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002B14 File Offset: 0x00000D14
		internal unsafe void CreateSwapChain(IUnknown deviceRef, ref SwapChainDescription descRef, SwapChain swapChainOut)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<IUnknown>(deviceRef);
			Result result;
			fixed (SwapChainDescription* ptr = &descRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, ptr2, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)10 * (IntPtr)sizeof(void*)));
			}
			swapChainOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002B7C File Offset: 0x00000D7C
		public unsafe Adapter CreateSoftwareAdapter(IntPtr module)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)module, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
			Adapter result2;
			if (zero != IntPtr.Zero)
			{
				result2 = new Adapter(zero);
			}
			else
			{
				result2 = null;
			}
			result.CheckError();
			return result2;
		}
	}
}
