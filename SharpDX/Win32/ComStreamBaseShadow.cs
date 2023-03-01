using System;
using System.Runtime.InteropServices;

namespace SharpDX.Win32
{
	// Token: 0x0200003D RID: 61
	internal class ComStreamBaseShadow : ComObjectShadow
	{
		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060001EB RID: 491 RVA: 0x00006270 File Offset: 0x00004470
		protected override CppObjectVtbl GetVtbl
		{
			get
			{
				return ComStreamBaseShadow.Vtbl;
			}
		}

		// Token: 0x0400009F RID: 159
		private static readonly ComStreamBaseShadow.ComStreamBaseVtbl Vtbl = new ComStreamBaseShadow.ComStreamBaseVtbl(0);

		// Token: 0x0200003E RID: 62
		internal class ComStreamBaseVtbl : ComObjectShadow.ComObjectVtbl
		{
			// Token: 0x060001EE RID: 494 RVA: 0x00006284 File Offset: 0x00004484
			public ComStreamBaseVtbl(int numberOfMethods) : base(numberOfMethods + 2)
			{
				base.AddMethod(new ComStreamBaseShadow.ComStreamBaseVtbl.ReadDelegate(ComStreamBaseShadow.ComStreamBaseVtbl.ReadImpl));
				base.AddMethod(new ComStreamBaseShadow.ComStreamBaseVtbl.WriteDelegate(ComStreamBaseShadow.ComStreamBaseVtbl.WriteImpl));
			}

			// Token: 0x060001EF RID: 495 RVA: 0x000062B4 File Offset: 0x000044B4
			private static int ReadImpl(IntPtr thisPtr, IntPtr buffer, int sizeOfBytes, out int bytesRead)
			{
				bytesRead = 0;
				try
				{
					IStream stream = (IStream)CppObjectShadow.ToShadow<ComStreamBaseShadow>(thisPtr).Callback;
					bytesRead = stream.Read(buffer, sizeOfBytes);
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x060001F0 RID: 496 RVA: 0x00006310 File Offset: 0x00004510
			private static int WriteImpl(IntPtr thisPtr, IntPtr buffer, int sizeOfBytes, out int bytesWrite)
			{
				bytesWrite = 0;
				try
				{
					IStream stream = (IStream)CppObjectShadow.ToShadow<ComStreamBaseShadow>(thisPtr).Callback;
					bytesWrite = stream.Write(buffer, sizeOfBytes);
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x0200003F RID: 63
			// (Invoke) Token: 0x060001F2 RID: 498
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int ReadDelegate(IntPtr thisPtr, IntPtr buffer, int sizeOfBytes, out int bytesRead);

			// Token: 0x02000040 RID: 64
			// (Invoke) Token: 0x060001F6 RID: 502
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int WriteDelegate(IntPtr thisPtr, IntPtr buffer, int sizeOfBytes, out int bytesWrite);
		}
	}
}
