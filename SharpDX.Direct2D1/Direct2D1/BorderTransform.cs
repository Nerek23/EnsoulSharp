using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x0200017E RID: 382
	[Guid("4998735c-3a19-473c-9781-656847e3a347")]
	public class BorderTransform : ConcreteTransform
	{
		// Token: 0x0600070B RID: 1803 RVA: 0x0001606A File Offset: 0x0001426A
		public BorderTransform(EffectContext context, ExtendMode extendModeX, ExtendMode extendModeY) : base(IntPtr.Zero)
		{
			context.CreateBorderTransform(extendModeX, extendModeY, this);
		}

		// Token: 0x0600070C RID: 1804 RVA: 0x00015FBC File Offset: 0x000141BC
		public BorderTransform(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x00016080 File Offset: 0x00014280
		public new static explicit operator BorderTransform(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new BorderTransform(nativePtr);
			}
			return null;
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x0600070E RID: 1806 RVA: 0x00016097 File Offset: 0x00014297
		// (set) Token: 0x0600070F RID: 1807 RVA: 0x0001609F File Offset: 0x0001429F
		public ExtendMode ExtendModeX
		{
			get
			{
				return this.GetExtendModeX();
			}
			set
			{
				this.SetExtendModeX(value);
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06000710 RID: 1808 RVA: 0x000160A8 File Offset: 0x000142A8
		// (set) Token: 0x06000711 RID: 1809 RVA: 0x000160B0 File Offset: 0x000142B0
		public ExtendMode ExtendModeY
		{
			get
			{
				return this.GetExtendModeY();
			}
			set
			{
				this.SetExtendModeY(value);
			}
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x000160B9 File Offset: 0x000142B9
		internal unsafe void SetExtendModeX(ExtendMode extendMode)
		{
			calli(System.Void(System.Void*,System.Int32), this._nativePointer, extendMode, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x000160D9 File Offset: 0x000142D9
		internal unsafe void SetExtendModeY(ExtendMode extendMode)
		{
			calli(System.Void(System.Void*,System.Int32), this._nativePointer, extendMode, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x000160F9 File Offset: 0x000142F9
		internal unsafe ExtendMode GetExtendModeX()
		{
			return calli(SharpDX.Direct2D1.ExtendMode(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x00016118 File Offset: 0x00014318
		internal unsafe ExtendMode GetExtendModeY()
		{
			return calli(SharpDX.Direct2D1.ExtendMode(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)9 * (IntPtr)sizeof(void*)));
		}
	}
}
