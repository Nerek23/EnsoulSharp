using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000BF RID: 191
	[Guid("2f0da53a-2add-47cd-82ee-d9ec34688e75")]
	public class RenderingParams : ComObject
	{
		// Token: 0x060003C8 RID: 968 RVA: 0x0000D5F8 File Offset: 0x0000B7F8
		public RenderingParams(Factory factory)
		{
			factory.CreateRenderingParams(this);
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x0000D607 File Offset: 0x0000B807
		public RenderingParams(Factory factory, IntPtr monitorHandle)
		{
			factory.CreateMonitorRenderingParams(monitorHandle, this);
		}

		// Token: 0x060003CA RID: 970 RVA: 0x0000D617 File Offset: 0x0000B817
		public RenderingParams(Factory factory, float gamma, float enhancedContrast, float clearTypeLevel, PixelGeometry pixelGeometry, RenderingMode renderingMode)
		{
			factory.CreateCustomRenderingParams(gamma, enhancedContrast, clearTypeLevel, pixelGeometry, renderingMode, this);
		}

		// Token: 0x060003CB RID: 971 RVA: 0x00002A7F File Offset: 0x00000C7F
		public RenderingParams(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060003CC RID: 972 RVA: 0x0000D62E File Offset: 0x0000B82E
		public new static explicit operator RenderingParams(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new RenderingParams(nativePtr);
			}
			return null;
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060003CD RID: 973 RVA: 0x0000D645 File Offset: 0x0000B845
		public float Gamma
		{
			get
			{
				return this.GetGamma();
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060003CE RID: 974 RVA: 0x0000D64D File Offset: 0x0000B84D
		public float EnhancedContrast
		{
			get
			{
				return this.GetEnhancedContrast();
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060003CF RID: 975 RVA: 0x0000D655 File Offset: 0x0000B855
		public float ClearTypeLevel
		{
			get
			{
				return this.GetClearTypeLevel();
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060003D0 RID: 976 RVA: 0x0000D65D File Offset: 0x0000B85D
		public PixelGeometry PixelGeometry
		{
			get
			{
				return this.GetPixelGeometry();
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060003D1 RID: 977 RVA: 0x0000D665 File Offset: 0x0000B865
		public RenderingMode RenderingMode
		{
			get
			{
				return this.GetRenderingMode();
			}
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x0000D66D File Offset: 0x0000B86D
		internal unsafe float GetGamma()
		{
			return calli(System.Single(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x0000D68C File Offset: 0x0000B88C
		internal unsafe float GetEnhancedContrast()
		{
			return calli(System.Single(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x0000A01D File Offset: 0x0000821D
		internal unsafe float GetClearTypeLevel()
		{
			return calli(System.Single(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x0000D6AB File Offset: 0x0000B8AB
		internal unsafe PixelGeometry GetPixelGeometry()
		{
			return calli(SharpDX.DirectWrite.PixelGeometry(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x0000D6CA File Offset: 0x0000B8CA
		internal unsafe RenderingMode GetRenderingMode()
		{
			return calli(SharpDX.DirectWrite.RenderingMode(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
		}
	}
}
