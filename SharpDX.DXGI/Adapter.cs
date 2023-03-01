using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000002 RID: 2
	[Guid("2411e7e1-12ac-4ccf-bd14-9798e8534dc0")]
	public class Adapter : DXGIObject
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
		public Output[] Outputs
		{
			get
			{
				List<Output> list = new List<Output>();
				Output output;
				while (!(this.GetOutput(list.Count, out output) == ResultCode.NotFound) && output != null)
				{
					list.Add(output);
				}
				return list.ToArray();
			}
		}

		// Token: 0x06000003 RID: 3 RVA: 0x0000209C File Offset: 0x0000029C
		public bool IsInterfaceSupported(Type type)
		{
			long num;
			return this.IsInterfaceSupported(type, out num);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000020B4 File Offset: 0x000002B4
		public bool IsInterfaceSupported<T>() where T : ComObject
		{
			long num;
			return this.IsInterfaceSupported(typeof(T), out num);
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020D3 File Offset: 0x000002D3
		public bool IsInterfaceSupported<T>(out long userModeVersion) where T : ComObject
		{
			return this.IsInterfaceSupported(typeof(T), out userModeVersion);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000020E8 File Offset: 0x000002E8
		public bool IsInterfaceSupported(Type type, out long userModeVersion)
		{
			return this.CheckInterfaceSupport(Utilities.GetGuidFromType(type), out userModeVersion).Success;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x0000210C File Offset: 0x0000030C
		public Output GetOutput(int outputIndex)
		{
			Output result;
			this.GetOutput(outputIndex, out result).CheckError();
			return result;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x0000212C File Offset: 0x0000032C
		public int GetOutputCount()
		{
			int num = 0;
			Output output;
			while (!(this.GetOutput(num, out output) == ResultCode.NotFound) && output != null)
			{
				output.Dispose();
				num++;
			}
			return num;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002165 File Offset: 0x00000365
		public Adapter(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600000A RID: 10 RVA: 0x0000216E File Offset: 0x0000036E
		public new static explicit operator Adapter(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Adapter(nativePtr);
			}
			return null;
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000B RID: 11 RVA: 0x00002188 File Offset: 0x00000388
		public AdapterDescription Description
		{
			get
			{
				AdapterDescription result;
				this.GetDescription(out result);
				return result;
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000021A0 File Offset: 0x000003A0
		internal unsafe Result GetOutput(int output, out Output outputOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, output, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				outputOut = new Output(zero);
				return result;
			}
			outputOut = null;
			return result;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000021F4 File Offset: 0x000003F4
		internal unsafe void GetDescription(out AdapterDescription descRef)
		{
			AdapterDescription.__Native _Native = default(AdapterDescription.__Native);
			descRef = default(AdapterDescription);
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			descRef.__MarshalFrom(ref _Native);
			result.CheckError();
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002248 File Offset: 0x00000448
		internal unsafe Result CheckInterfaceSupport(Guid interfaceName, out long uMDVersionRef)
		{
			Result result;
			fixed (long* ptr = &uMDVersionRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*,System.Void*), this._nativePointer, &interfaceName, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
			}
			return result;
		}
	}
}
