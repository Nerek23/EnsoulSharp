using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.WIC
{
	// Token: 0x02000071 RID: 113
	[Guid("A9DB33A2-AF5F-43C7-B679-74F5984B5AA4")]
	public class PixelFormatInfo2 : PixelFormatInfo
	{
		// Token: 0x06000248 RID: 584 RVA: 0x000096DF File Offset: 0x000078DF
		public PixelFormatInfo2(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000249 RID: 585 RVA: 0x000096E8 File Offset: 0x000078E8
		public new static explicit operator PixelFormatInfo2(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new PixelFormatInfo2(nativePtr);
			}
			return null;
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x0600024A RID: 586 RVA: 0x00009700 File Offset: 0x00007900
		public RawBool IsSupportingTransparency
		{
			get
			{
				RawBool result;
				this.IsSupportingTransparency_(out result);
				return result;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x0600024B RID: 587 RVA: 0x00009718 File Offset: 0x00007918
		public PixelFormatNumericRepresentation NumericRepresentation
		{
			get
			{
				PixelFormatNumericRepresentation result;
				this.GetNumericRepresentation(out result);
				return result;
			}
		}

		// Token: 0x0600024C RID: 588 RVA: 0x00009730 File Offset: 0x00007930
		internal unsafe void IsSupportingTransparency_(out RawBool fSupportsTransparencyRef)
		{
			fSupportsTransparencyRef = default(RawBool);
			Result result;
			fixed (RawBool* ptr = &fSupportsTransparencyRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600024D RID: 589 RVA: 0x00009778 File Offset: 0x00007978
		internal unsafe void GetNumericRepresentation(out PixelFormatNumericRepresentation numericRepresentationRef)
		{
			Result result;
			fixed (PixelFormatNumericRepresentation* ptr = &numericRepresentationRef)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}
