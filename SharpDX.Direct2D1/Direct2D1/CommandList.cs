using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000182 RID: 386
	[Guid("b4f34a19-2383-4d76-94f6-ec343657c3dc")]
	public class CommandList : Image
	{
		// Token: 0x06000734 RID: 1844 RVA: 0x0001641C File Offset: 0x0001461C
		public CommandList(DeviceContext deviceContext) : base(IntPtr.Zero)
		{
			deviceContext.CreateCommandList(this);
		}

		// Token: 0x06000735 RID: 1845 RVA: 0x000154AE File Offset: 0x000136AE
		public CommandList(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000736 RID: 1846 RVA: 0x00016430 File Offset: 0x00014630
		public new static explicit operator CommandList(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new CommandList(nativePtr);
			}
			return null;
		}

		// Token: 0x06000737 RID: 1847 RVA: 0x00016448 File Offset: 0x00014648
		public unsafe void Stream(CommandSink sink)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<CommandSink>(sink);
			calli(System.Int32(System.Void*,System.Void*), this._nativePointer, (void*)value, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x00016494 File Offset: 0x00014694
		public unsafe void Close()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
