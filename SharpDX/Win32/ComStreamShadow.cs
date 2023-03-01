using System;
using System.IO;
using System.Runtime.InteropServices;

namespace SharpDX.Win32
{
	// Token: 0x02000042 RID: 66
	internal class ComStreamShadow : ComStreamBaseShadow
	{
		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000206 RID: 518 RVA: 0x00006551 File Offset: 0x00004751
		protected override CppObjectVtbl GetVtbl
		{
			get
			{
				return ComStreamShadow.Vtbl;
			}
		}

		// Token: 0x06000207 RID: 519 RVA: 0x00006558 File Offset: 0x00004758
		public static IntPtr ToIntPtr(IStream stream)
		{
			return CppObject.ToCallbackPtr<IStream>(stream);
		}

		// Token: 0x040000A2 RID: 162
		private static readonly ComStreamShadow.ComStreamVtbl Vtbl = new ComStreamShadow.ComStreamVtbl();

		// Token: 0x02000043 RID: 67
		private class ComStreamVtbl : ComStreamBaseShadow.ComStreamBaseVtbl
		{
			// Token: 0x0600020A RID: 522 RVA: 0x00006574 File Offset: 0x00004774
			public ComStreamVtbl() : base(9)
			{
				base.AddMethod(new ComStreamShadow.ComStreamVtbl.SeekDelegate(ComStreamShadow.ComStreamVtbl.SeekImpl));
				base.AddMethod(new ComStreamShadow.ComStreamVtbl.SetSizeDelegate(ComStreamShadow.ComStreamVtbl.SetSizeImpl));
				base.AddMethod(new ComStreamShadow.ComStreamVtbl.CopyToDelegate(ComStreamShadow.ComStreamVtbl.CopyToImpl));
				base.AddMethod(new ComStreamShadow.ComStreamVtbl.CommitDelegate(ComStreamShadow.ComStreamVtbl.CommitImpl));
				base.AddMethod(new ComStreamShadow.ComStreamVtbl.RevertDelegate(ComStreamShadow.ComStreamVtbl.RevertImpl));
				base.AddMethod(new ComStreamShadow.ComStreamVtbl.LockRegionDelegate(ComStreamShadow.ComStreamVtbl.LockRegionImpl));
				base.AddMethod(new ComStreamShadow.ComStreamVtbl.UnlockRegionDelegate(ComStreamShadow.ComStreamVtbl.UnlockRegionImpl));
				base.AddMethod(new ComStreamShadow.ComStreamVtbl.StatDelegate(ComStreamShadow.ComStreamVtbl.StatImpl));
				base.AddMethod(new ComStreamShadow.ComStreamVtbl.CloneDelegate(ComStreamShadow.ComStreamVtbl.CloneImpl));
			}

			// Token: 0x0600020B RID: 523 RVA: 0x0000662C File Offset: 0x0000482C
			private unsafe static int SeekImpl(IntPtr thisPtr, long offset, SeekOrigin origin, IntPtr newPosition)
			{
				try
				{
					long num = ((IStream)CppObjectShadow.ToShadow<ComStreamShadow>(thisPtr).Callback).Seek(offset, origin);
					if (newPosition != IntPtr.Zero)
					{
						*(long*)((void*)newPosition) = num;
					}
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x0600020C RID: 524 RVA: 0x00006694 File Offset: 0x00004894
			private static Result SetSizeImpl(IntPtr thisPtr, long newSize)
			{
				Result result = Result.Ok;
				try
				{
					((IStream)CppObjectShadow.ToShadow<ComStreamShadow>(thisPtr).Callback).SetSize(newSize);
				}
				catch (SharpDXException ex)
				{
					result = ex.ResultCode;
				}
				catch (Exception)
				{
					result = Result.Fail.Code;
				}
				return result;
			}

			// Token: 0x0600020D RID: 525 RVA: 0x000066F8 File Offset: 0x000048F8
			private static int CopyToImpl(IntPtr thisPtr, IntPtr streamPointer, long numberOfBytes, out long numberOfBytesRead, out long numberOfBytesWritten)
			{
				numberOfBytesRead = 0L;
				numberOfBytesWritten = 0L;
				try
				{
					IStream stream = (IStream)CppObjectShadow.ToShadow<ComStreamShadow>(thisPtr).Callback;
					numberOfBytesRead = stream.CopyTo(new ComStream(streamPointer), numberOfBytes, out numberOfBytesWritten);
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x0600020E RID: 526 RVA: 0x00006760 File Offset: 0x00004960
			private static Result CommitImpl(IntPtr thisPtr, CommitFlags flags)
			{
				Result result = Result.Ok;
				try
				{
					((IStream)CppObjectShadow.ToShadow<ComStreamShadow>(thisPtr).Callback).Commit(flags);
				}
				catch (SharpDXException ex)
				{
					result = ex.ResultCode;
				}
				catch (Exception)
				{
					result = Result.Fail.Code;
				}
				return result;
			}

			// Token: 0x0600020F RID: 527 RVA: 0x000067C4 File Offset: 0x000049C4
			private static Result RevertImpl(IntPtr thisPtr)
			{
				Result result = Result.Ok;
				try
				{
					((IStream)CppObjectShadow.ToShadow<ComStreamShadow>(thisPtr).Callback).Revert();
				}
				catch (SharpDXException ex)
				{
					result = ex.ResultCode;
				}
				catch (Exception)
				{
					result = Result.Fail.Code;
				}
				return result;
			}

			// Token: 0x06000210 RID: 528 RVA: 0x00006828 File Offset: 0x00004A28
			private static Result LockRegionImpl(IntPtr thisPtr, long offset, long numberOfBytes, LockType lockType)
			{
				Result result = Result.Ok;
				try
				{
					((IStream)CppObjectShadow.ToShadow<ComStreamShadow>(thisPtr).Callback).LockRegion(offset, numberOfBytes, lockType);
				}
				catch (SharpDXException ex)
				{
					result = ex.ResultCode;
				}
				catch (Exception)
				{
					result = Result.Fail.Code;
				}
				return result;
			}

			// Token: 0x06000211 RID: 529 RVA: 0x00006890 File Offset: 0x00004A90
			private static Result UnlockRegionImpl(IntPtr thisPtr, long offset, long numberOfBytes, LockType lockType)
			{
				Result result = Result.Ok;
				try
				{
					((IStream)CppObjectShadow.ToShadow<ComStreamShadow>(thisPtr).Callback).UnlockRegion(offset, numberOfBytes, lockType);
				}
				catch (SharpDXException ex)
				{
					result = ex.ResultCode;
				}
				catch (Exception)
				{
					result = Result.Fail.Code;
				}
				return result;
			}

			// Token: 0x06000212 RID: 530 RVA: 0x000068F8 File Offset: 0x00004AF8
			private static Result StatImpl(IntPtr thisPtr, ref StorageStatistics.__Native statisticsPtr, StorageStatisticsFlags flags)
			{
				try
				{
					((IStream)CppObjectShadow.ToShadow<ComStreamShadow>(thisPtr).Callback).GetStatistics(flags).__MarshalTo(ref statisticsPtr);
				}
				catch (SharpDXException ex)
				{
					return ex.ResultCode;
				}
				catch (Exception)
				{
					return Result.Fail.Code;
				}
				return Result.Ok;
			}

			// Token: 0x06000213 RID: 531 RVA: 0x00006964 File Offset: 0x00004B64
			private static Result CloneImpl(IntPtr thisPtr, out IntPtr streamPointer)
			{
				streamPointer = IntPtr.Zero;
				Result result = Result.Ok;
				try
				{
					IStream stream = ((IStream)CppObjectShadow.ToShadow<ComStreamShadow>(thisPtr).Callback).Clone();
					streamPointer = ComStreamShadow.ToIntPtr(stream);
				}
				catch (SharpDXException ex)
				{
					result = ex.ResultCode;
				}
				catch (Exception)
				{
					result = Result.Fail.Code;
				}
				return result;
			}

			// Token: 0x02000044 RID: 68
			// (Invoke) Token: 0x06000215 RID: 533
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int SeekDelegate(IntPtr thisPtr, long offset, SeekOrigin origin, IntPtr newPosition);

			// Token: 0x02000045 RID: 69
			// (Invoke) Token: 0x06000219 RID: 537
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate Result SetSizeDelegate(IntPtr thisPtr, long newSize);

			// Token: 0x02000046 RID: 70
			// (Invoke) Token: 0x0600021D RID: 541
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int CopyToDelegate(IntPtr thisPtr, IntPtr streamPointer, long numberOfBytes, out long numberOfBytesRead, out long numberOfBytesWritten);

			// Token: 0x02000047 RID: 71
			// (Invoke) Token: 0x06000221 RID: 545
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate Result CommitDelegate(IntPtr thisPtr, CommitFlags flags);

			// Token: 0x02000048 RID: 72
			// (Invoke) Token: 0x06000225 RID: 549
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate Result RevertDelegate(IntPtr thisPtr);

			// Token: 0x02000049 RID: 73
			// (Invoke) Token: 0x06000229 RID: 553
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate Result LockRegionDelegate(IntPtr thisPtr, long offset, long numberOfBytes, LockType lockType);

			// Token: 0x0200004A RID: 74
			// (Invoke) Token: 0x0600022D RID: 557
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate Result UnlockRegionDelegate(IntPtr thisPtr, long offset, long numberOfBytes, LockType lockType);

			// Token: 0x0200004B RID: 75
			// (Invoke) Token: 0x06000231 RID: 561
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate Result StatDelegate(IntPtr thisPtr, ref StorageStatistics.__Native statisticsPtr, StorageStatisticsFlags flags);

			// Token: 0x0200004C RID: 76
			// (Invoke) Token: 0x06000235 RID: 565
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate Result CloneDelegate(IntPtr thisPtr, out IntPtr streamPointer);
		}
	}
}
