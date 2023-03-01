using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000185 RID: 389
	[Guid("9eb767fd-4269-4467-b8c2-eb30cb305743")]
	internal class CommandSink1Native : CommandSinkNative, CommandSink1, CommandSink, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x17000129 RID: 297
		// (set) Token: 0x06000753 RID: 1875 RVA: 0x000164CB File Offset: 0x000146CB
		public PrimitiveBlend PrimitiveBlend1
		{
			set
			{
				this.SetPrimitiveBlend1_(value);
			}
		}

		// Token: 0x06000754 RID: 1876 RVA: 0x000164D4 File Offset: 0x000146D4
		public CommandSink1Native(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000755 RID: 1877 RVA: 0x000164DD File Offset: 0x000146DD
		public new static explicit operator CommandSink1Native(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new CommandSink1Native(nativePtr);
			}
			return null;
		}

		// Token: 0x1700012A RID: 298
		// (set) Token: 0x06000756 RID: 1878 RVA: 0x000164CB File Offset: 0x000146CB
		public PrimitiveBlend PrimitiveBlend1_
		{
			set
			{
				this.SetPrimitiveBlend1_(value);
			}
		}

		// Token: 0x06000757 RID: 1879 RVA: 0x000164F4 File Offset: 0x000146F4
		internal unsafe void SetPrimitiveBlend1_(PrimitiveBlend primitiveBlend)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, primitiveBlend, *(*(IntPtr*)this._nativePointer + (IntPtr)28 * (IntPtr)sizeof(void*))).CheckError();
		}
	}
}
