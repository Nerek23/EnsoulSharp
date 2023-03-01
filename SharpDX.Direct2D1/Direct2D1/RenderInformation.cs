using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200030E RID: 782
	[Guid("519ae1bd-d19a-420d-b849-364f594776b7")]
	public class RenderInformation : ComObject
	{
		// Token: 0x06000DBB RID: 3515 RVA: 0x00002A7F File Offset: 0x00000C7F
		public RenderInformation(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000DBC RID: 3516 RVA: 0x00025F9A File Offset: 0x0002419A
		public new static explicit operator RenderInformation(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new RenderInformation(nativePtr);
			}
			return null;
		}

		// Token: 0x170001D1 RID: 465
		// (set) Token: 0x06000DBD RID: 3517 RVA: 0x00025FB1 File Offset: 0x000241B1
		public RawBool Cached
		{
			set
			{
				this.SetCached(value);
			}
		}

		// Token: 0x170001D2 RID: 466
		// (set) Token: 0x06000DBE RID: 3518 RVA: 0x00025FBA File Offset: 0x000241BA
		public int InstructionCountHint
		{
			set
			{
				this.SetInstructionCountHint(value);
			}
		}

		// Token: 0x06000DBF RID: 3519 RVA: 0x00025FC4 File Offset: 0x000241C4
		public unsafe void SetInputDescription(int inputIndex, InputDescription inputDescription)
		{
			calli(System.Int32(System.Void*,System.Int32,SharpDX.Direct2D1.InputDescription), this._nativePointer, inputIndex, inputDescription, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000DC0 RID: 3520 RVA: 0x00026000 File Offset: 0x00024200
		public unsafe void SetOutputBuffer(BufferPrecision bufferPrecision, ChannelDepth channelDepth)
		{
			calli(System.Int32(System.Void*,System.Int32,System.Int32), this._nativePointer, bufferPrecision, channelDepth, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000DC1 RID: 3521 RVA: 0x0002590D File Offset: 0x00023B0D
		internal unsafe void SetCached(RawBool isCached)
		{
			calli(System.Void(System.Void*,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, isCached, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000DC2 RID: 3522 RVA: 0x000160B9 File Offset: 0x000142B9
		internal unsafe void SetInstructionCountHint(int instructionCount)
		{
			calli(System.Void(System.Void*,System.Int32), this._nativePointer, instructionCount, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
		}
	}
}
