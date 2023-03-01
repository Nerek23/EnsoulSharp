using System;

namespace SharpDX
{
	// Token: 0x02000025 RID: 37
	internal class Interop
	{
		// Token: 0x060000F6 RID: 246 RVA: 0x00003F3C File Offset: 0x0000213C
		public unsafe static void* Fixed<T>(ref T data)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00003F3C File Offset: 0x0000213C
		public unsafe static void* Fixed<T>(T[] data)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00003F44 File Offset: 0x00002144
		public unsafe static void* Cast<T>(ref T data) where T : struct
		{
			return (void*)(&data);
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00003F54 File Offset: 0x00002154
		public unsafe static void* CastOut<T>(out T data) where T : struct
		{
			return (void*)(&data);
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00003F64 File Offset: 0x00002164
		public static TCAST[] CastArray<TCAST, T>(T[] arrayData) where TCAST : struct where T : struct
		{
			return arrayData;
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00003F72 File Offset: 0x00002172
		public unsafe static void memcpy(void* pDest, void* pSrc, int count)
		{
			cpblk(pDest, pSrc, count);
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00003F7C File Offset: 0x0000217C
		public unsafe static void memset(void* pDest, byte value, int count)
		{
			initblk(pDest, value, count);
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00003F88 File Offset: 0x00002188
		public unsafe static void* Read<T>(void* pSrc, ref T data) where T : struct
		{
			fixed (T* ptr = &data)
			{
				T* ptr2 = ptr;
				int num = sizeof(T);
				cpblk(ptr2, pSrc, num);
				return (void*)((byte*)((IntPtr)num) + pSrc);
			}
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00003F3C File Offset: 0x0000213C
		public unsafe static T ReadInline<T>(void* pSrc) where T : struct
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00003F3C File Offset: 0x0000213C
		public unsafe static void WriteInline<T>(void* pDest, ref T data) where T : struct
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00003F3C File Offset: 0x0000213C
		public unsafe static void CopyInline<T>(ref T data, void* pSrc) where T : struct
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00003F3C File Offset: 0x0000213C
		public unsafe static void CopyInline<T>(void* pDest, ref T srcData) where T : struct
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00003F3C File Offset: 0x0000213C
		public unsafe static void CopyInlineOut<T>(out T data, void* pSrc) where T : struct
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00003FAC File Offset: 0x000021AC
		public unsafe static void* ReadOut<T>(void* pSrc, out T data) where T : struct
		{
			fixed (T* ptr = &data)
			{
				T* ptr2 = ptr;
				int num = sizeof(T);
				cpblk(ptr2, pSrc, num);
				return (void*)((byte*)((IntPtr)num) + pSrc);
			}
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00003FD0 File Offset: 0x000021D0
		public unsafe static void* Read<T>(void* pSrc, T[] data, int offset, int count) where T : struct
		{
			fixed (T* ptr = &data[offset])
			{
				T* ptr2 = ptr;
				int num = sizeof(T) * count;
				cpblk(ptr2, pSrc, num);
				return (void*)((byte*)((IntPtr)num) + pSrc);
			}
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00003FFC File Offset: 0x000021FC
		public unsafe static void* Read2D<T>(void* pSrc, T[,] data, int offset, int count) where T : struct
		{
			fixed (T* ptr = ref data[offset])
			{
				T* ptr2 = ptr;
				int num = sizeof(T) * count;
				cpblk(ptr2, pSrc, num);
				return (void*)((byte*)((IntPtr)num) + pSrc);
			}
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00003F3C File Offset: 0x0000213C
		public static int SizeOf<T>()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00004028 File Offset: 0x00002228
		public unsafe static void* Write<T>(void* pDest, ref T data) where T : struct
		{
			fixed (T* ptr = &data)
			{
				T* ptr2 = ptr;
				int num = sizeof(T);
				cpblk(pDest, ptr2, num);
				return (void*)((byte*)((IntPtr)num) + pDest);
			}
		}

		// Token: 0x06000108 RID: 264 RVA: 0x0000404C File Offset: 0x0000224C
		public unsafe static void* Write<T>(void* pDest, T[] data, int offset, int count) where T : struct
		{
			fixed (T* ptr = &data[offset])
			{
				T* ptr2 = ptr;
				int num = sizeof(T) * count;
				cpblk(pDest, ptr2, num);
				return (void*)((byte*)((IntPtr)num) + pDest);
			}
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00004078 File Offset: 0x00002278
		public unsafe static void* Write2D<T>(void* pDest, T[,] data, int offset, int count) where T : struct
		{
			fixed (T* ptr = ref data[offset])
			{
				T* ptr2 = ptr;
				int num = sizeof(T) * count;
				cpblk(pDest, ptr2, num);
				return (void*)((byte*)((IntPtr)num) + pDest);
			}
		}

		// Token: 0x0600010A RID: 266 RVA: 0x000022F0 File Offset: 0x000004F0
		[Tag("SharpDX.ModuleInit")]
		public static void ModuleInit()
		{
		}
	}
}
