using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200017D RID: 381
	[Guid("63ac0b32-ba44-450f-8806-7f4ca1ff2f1b")]
	public class BlendTransform : ConcreteTransform
	{
		// Token: 0x06000703 RID: 1795 RVA: 0x00015F8F File Offset: 0x0001418F
		public BlendTransform(EffectContext context, int numInputs, BlendDescription blendDescription) : base(IntPtr.Zero)
		{
			context.CreateBlendTransform(numInputs, ref blendDescription, this);
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x00015FA6 File Offset: 0x000141A6
		public BlendTransform(EffectContext context, int numInputs, ref BlendDescription blendDescription) : base(IntPtr.Zero)
		{
			context.CreateBlendTransform(numInputs, ref blendDescription, this);
		}

		// Token: 0x06000705 RID: 1797 RVA: 0x00015FBC File Offset: 0x000141BC
		public BlendTransform(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000706 RID: 1798 RVA: 0x00015FC5 File Offset: 0x000141C5
		public new static explicit operator BlendTransform(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new BlendTransform(nativePtr);
			}
			return null;
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06000707 RID: 1799 RVA: 0x00015FDC File Offset: 0x000141DC
		// (set) Token: 0x06000708 RID: 1800 RVA: 0x00015FF2 File Offset: 0x000141F2
		public BlendDescription Description
		{
			get
			{
				BlendDescription result;
				this.GetDescription(out result);
				return result;
			}
			set
			{
				this.SetDescription(ref value);
			}
		}

		// Token: 0x06000709 RID: 1801 RVA: 0x00015FFC File Offset: 0x000141FC
		internal unsafe void SetDescription(ref BlendDescription description)
		{
			fixed (BlendDescription* ptr = &description)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x00016030 File Offset: 0x00014230
		internal unsafe void GetDescription(out BlendDescription description)
		{
			description = default(BlendDescription);
			fixed (BlendDescription* ptr = &description)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			}
		}
	}
}
