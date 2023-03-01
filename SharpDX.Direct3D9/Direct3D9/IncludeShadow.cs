using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using SharpDX.Collections;

namespace SharpDX.Direct3D9
{
	// Token: 0x0200011D RID: 285
	internal class IncludeShadow : CppObjectShadow
	{
		// Token: 0x06000766 RID: 1894 RVA: 0x0001A848 File Offset: 0x00018A48
		public static IntPtr ToIntPtr(Include callback)
		{
			return CppObject.ToCallbackPtr<Include>(callback);
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x06000767 RID: 1895 RVA: 0x0001A850 File Offset: 0x00018A50
		protected override CppObjectVtbl GetVtbl
		{
			get
			{
				return IncludeShadow.Vtbl;
			}
		}

		// Token: 0x04000E92 RID: 3730
		private static readonly IncludeShadow.IncludeVtbl Vtbl = new IncludeShadow.IncludeVtbl();

		// Token: 0x04000E93 RID: 3731
		private readonly Dictionary<IntPtr, IncludeShadow.Frame> frames = new Dictionary<IntPtr, IncludeShadow.Frame>(EqualityComparer.DefaultIntPtr);

		// Token: 0x0200011E RID: 286
		private struct Frame
		{
			// Token: 0x0600076A RID: 1898 RVA: 0x0001A87B File Offset: 0x00018A7B
			public Frame(Stream stream, GCHandle handle)
			{
				this.Stream = stream;
				this.Handle = handle;
			}

			// Token: 0x0600076B RID: 1899 RVA: 0x0001A88B File Offset: 0x00018A8B
			public void Close()
			{
				if (this.Handle.IsAllocated)
				{
					this.Handle.Free();
				}
			}

			// Token: 0x04000E94 RID: 3732
			public Stream Stream;

			// Token: 0x04000E95 RID: 3733
			public GCHandle Handle;
		}

		// Token: 0x0200011F RID: 287
		private class IncludeVtbl : CppObjectVtbl
		{
			// Token: 0x0600076C RID: 1900 RVA: 0x0001A8A5 File Offset: 0x00018AA5
			public IncludeVtbl() : base(2)
			{
				base.AddMethod(new IncludeShadow.IncludeVtbl.OpenDelegate(IncludeShadow.IncludeVtbl.OpenImpl));
				base.AddMethod(new IncludeShadow.IncludeVtbl.CloseDelegate(IncludeShadow.IncludeVtbl.CloseImpl));
			}

			// Token: 0x0600076D RID: 1901 RVA: 0x0001A8D4 File Offset: 0x00018AD4
			private static Result OpenImpl(IntPtr thisPtr, IncludeType includeType, IntPtr fileNameRef, IntPtr pParentData, ref IntPtr dataRef, ref int bytesRef)
			{
				Result result;
				try
				{
					IncludeShadow includeShadow = CppObjectShadow.ToShadow<IncludeShadow>(thisPtr);
					Include include = (Include)includeShadow.Callback;
					Stream parentStream = null;
					if (includeShadow.frames.ContainsKey(pParentData))
					{
						parentStream = includeShadow.frames[pParentData].Stream;
					}
					Stream stream = include.Open(includeType, Marshal.PtrToStringAnsi(fileNameRef), parentStream);
					if (stream == null)
					{
						result = Result.Fail;
					}
					else
					{
						GCHandle handle;
						if (stream is DataStream)
						{
							DataStream dataStream = (DataStream)stream;
							dataRef = dataStream.PositionPointer;
							bytesRef = (int)(dataStream.Length - dataStream.Position);
							handle = default(GCHandle);
						}
						else
						{
							byte[] array = Utilities.ReadStream(stream);
							handle = GCHandle.Alloc(array, GCHandleType.Pinned);
							dataRef = handle.AddrOfPinnedObject();
							bytesRef = array.Length;
						}
						includeShadow.frames.Add(dataRef, new IncludeShadow.Frame(stream, handle));
						result = Result.Ok;
					}
				}
				catch (SharpDXException ex)
				{
					result = ex.ResultCode.Code;
				}
				catch (Exception)
				{
					result = Result.Fail;
				}
				return result;
			}

			// Token: 0x0600076E RID: 1902 RVA: 0x0001A9F4 File Offset: 0x00018BF4
			private static Result CloseImpl(IntPtr thisPtr, IntPtr pData)
			{
				Result result;
				try
				{
					IncludeShadow includeShadow = CppObjectShadow.ToShadow<IncludeShadow>(thisPtr);
					Include include = (Include)includeShadow.Callback;
					IncludeShadow.Frame frame;
					if (includeShadow.frames.TryGetValue(pData, out frame))
					{
						includeShadow.frames.Remove(pData);
						include.Close(frame.Stream);
						frame.Close();
					}
					result = Result.Ok;
				}
				catch (SharpDXException ex)
				{
					result = ex.ResultCode.Code;
				}
				catch (Exception)
				{
					result = Result.Fail;
				}
				return result;
			}

			// Token: 0x02000120 RID: 288
			// (Invoke) Token: 0x06000770 RID: 1904
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate Result OpenDelegate(IntPtr thisPtr, IncludeType includeType, IntPtr fileNameRef, IntPtr pParentData, ref IntPtr dataRef, ref int bytesRef);

			// Token: 0x02000121 RID: 289
			// (Invoke) Token: 0x06000774 RID: 1908
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate Result CloseDelegate(IntPtr thisPtr, IntPtr pData);
		}
	}
}
