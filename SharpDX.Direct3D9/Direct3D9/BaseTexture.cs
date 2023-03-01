using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D9
{
	// Token: 0x0200000E RID: 14
	[Guid("580CA87E-1D3C-4d54-991D-B7D3E3C298CE")]
	public class BaseTexture : Resource
	{
		// Token: 0x0600007E RID: 126 RVA: 0x00003B9A File Offset: 0x00001D9A
		public void FilterTexture(int sourceLevel, Filter filter)
		{
			D3DX9.FilterTexture(this, null, sourceLevel, filter);
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00003BA5 File Offset: 0x00001DA5
		public void FilterTexture(int sourceLevel, Filter filter, PaletteEntry[] palette)
		{
			D3DX9.FilterTexture(this, palette, sourceLevel, filter);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00003BB0 File Offset: 0x00001DB0
		public static void ToFile(BaseTexture texture, string fileName, ImageFileFormat format)
		{
			D3DX9.SaveTextureToFileW(fileName, format, texture, null);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00003BBB File Offset: 0x00001DBB
		public static void ToFile(BaseTexture texture, string fileName, ImageFileFormat format, PaletteEntry[] palette)
		{
			D3DX9.SaveTextureToFileW(fileName, format, texture, palette);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00003BC6 File Offset: 0x00001DC6
		public static DataStream ToStream(BaseTexture texture, ImageFileFormat format)
		{
			return new DataStream(D3DX9.SaveTextureToFileInMemory(format, texture, null));
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00003BD5 File Offset: 0x00001DD5
		public static DataStream ToStream(BaseTexture texture, ImageFileFormat format, PaletteEntry[] palette)
		{
			return new DataStream(D3DX9.SaveTextureToFileInMemory(format, texture, palette));
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000084 RID: 132 RVA: 0x00003BE4 File Offset: 0x00001DE4
		// (set) Token: 0x06000085 RID: 133 RVA: 0x00003BEC File Offset: 0x00001DEC
		public int LevelOfDetails
		{
			get
			{
				return this.GetLOD();
			}
			set
			{
				this.SetLOD(value);
			}
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00003BF6 File Offset: 0x00001DF6
		public BaseTexture(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00003BFF File Offset: 0x00001DFF
		public new static explicit operator BaseTexture(IntPtr nativePointer)
		{
			if (!(nativePointer == IntPtr.Zero))
			{
				return new BaseTexture(nativePointer);
			}
			return null;
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000088 RID: 136 RVA: 0x00003C16 File Offset: 0x00001E16
		public int LevelCount
		{
			get
			{
				return this.GetLevelCount();
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000089 RID: 137 RVA: 0x00003C1E File Offset: 0x00001E1E
		// (set) Token: 0x0600008A RID: 138 RVA: 0x00003C26 File Offset: 0x00001E26
		public TextureFilter AutoMipGenerationFilter
		{
			get
			{
				return this.GetAutoMipGenerationFilter();
			}
			set
			{
				this.SetAutoMipGenerationFilter(value);
			}
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00003C2F File Offset: 0x00001E2F
		internal unsafe int SetLOD(int lODNew)
		{
			return calli(System.Int32(System.Void*,System.Int32), this._nativePointer, lODNew, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00003C50 File Offset: 0x00001E50
		internal unsafe int GetLOD()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00003C70 File Offset: 0x00001E70
		internal unsafe int GetLevelCount()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00003C90 File Offset: 0x00001E90
		internal unsafe void SetAutoMipGenerationFilter(TextureFilter filterType)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, filterType, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00003CC9 File Offset: 0x00001EC9
		internal unsafe TextureFilter GetAutoMipGenerationFilter()
		{
			return calli(SharpDX.Direct3D9.TextureFilter(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00003CE9 File Offset: 0x00001EE9
		public unsafe void GenerateMipSubLevels()
		{
			calli(System.Void(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*)));
		}
	}
}
