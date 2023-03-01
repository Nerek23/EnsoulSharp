using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200018E RID: 398
	[Guid("c78a6519-40d6-4218-b2de-beeeb744bb3e")]
	internal class CommandSink4Native : CommandSink3Native, CommandSink4, CommandSink3, CommandSink2, CommandSink1, CommandSink, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x06000773 RID: 1907 RVA: 0x000167DD File Offset: 0x000149DD
		public void SetPrimitiveBlend2(PrimitiveBlend primitiveBlend)
		{
			this.SetPrimitiveBlend2_(primitiveBlend);
		}

		// Token: 0x06000774 RID: 1908 RVA: 0x000167E6 File Offset: 0x000149E6
		public CommandSink4Native(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000775 RID: 1909 RVA: 0x000167EF File Offset: 0x000149EF
		public new static explicit operator CommandSink4Native(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new CommandSink4Native(nativePtr);
			}
			return null;
		}

		// Token: 0x1700012C RID: 300
		// (set) Token: 0x06000776 RID: 1910 RVA: 0x000167DD File Offset: 0x000149DD
		public PrimitiveBlend PrimitiveBlend2_
		{
			set
			{
				this.SetPrimitiveBlend2_(value);
			}
		}

		// Token: 0x06000777 RID: 1911 RVA: 0x00016808 File Offset: 0x00014A08
		internal unsafe void SetPrimitiveBlend2_(PrimitiveBlend primitiveBlend)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, primitiveBlend, *(*(IntPtr*)this._nativePointer + (IntPtr)33 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
