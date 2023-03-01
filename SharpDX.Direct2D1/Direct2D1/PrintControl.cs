using System;
using System.Runtime.InteropServices;
using SharpDX.WIC;
using SharpDX.Win32;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200020A RID: 522
	[Guid("2c1d867d-c290-41c8-ae7e-34a98702e9a5")]
	public class PrintControl : ComObject
	{
		// Token: 0x06000B1F RID: 2847 RVA: 0x0001FBB4 File Offset: 0x0001DDB4
		public PrintControl(Device device, ImagingFactory wicFactory, ComObject documentTarget)
		{
			device.CreatePrintControl(wicFactory, documentTarget, null, this);
		}

		// Token: 0x06000B20 RID: 2848 RVA: 0x0001FBD9 File Offset: 0x0001DDD9
		public PrintControl(Device device, ImagingFactory wicFactory, ComObject documentTarget, PrintControlProperties rintControlPropertiesRef)
		{
			device.CreatePrintControl(wicFactory, documentTarget, new PrintControlProperties?(rintControlPropertiesRef), this);
		}

		// Token: 0x06000B21 RID: 2849 RVA: 0x0001FBF4 File Offset: 0x0001DDF4
		public void AddPage(CommandList commandList, Size2F pageSize)
		{
			long num;
			long num2;
			this.AddPage(commandList, pageSize, out num, out num2);
		}

		// Token: 0x06000B22 RID: 2850 RVA: 0x0001FC0D File Offset: 0x0001DE0D
		public void AddPage(CommandList commandList, Size2F pageSize, out long tag1, out long tag2)
		{
			this.AddPage(commandList, pageSize, null, out tag1, out tag2);
		}

		// Token: 0x06000B23 RID: 2851 RVA: 0x00002A7F File Offset: 0x00000C7F
		public PrintControl(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000B24 RID: 2852 RVA: 0x0001FC1B File Offset: 0x0001DE1B
		public new static explicit operator PrintControl(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new PrintControl(nativePtr);
			}
			return null;
		}

		// Token: 0x06000B25 RID: 2853 RVA: 0x0001FC34 File Offset: 0x0001DE34
		public unsafe void AddPage(CommandList commandList, Size2F pageSize, IStream agePrintTicketStreamRef, out long tag1, out long tag2)
		{
			IntPtr value = IntPtr.Zero;
			IntPtr value2 = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<CommandList>(commandList);
			value2 = CppObject.ToCallbackPtr<IStream>(agePrintTicketStreamRef);
			Result result;
			fixed (long* ptr = &tag2)
			{
				void* ptr2 = (void*)ptr;
				fixed (long* ptr3 = &tag1)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Void*,SharpDX.Size2F,System.Void*,System.Void*,System.Void*), this._nativePointer, (void*)value, pageSize, (void*)value2, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x06000B26 RID: 2854 RVA: 0x0001FCB0 File Offset: 0x0001DEB0
		public unsafe void Close()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
