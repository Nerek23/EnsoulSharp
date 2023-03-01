using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace SharpDX
{
	// Token: 0x0200002A RID: 42
	public struct Result : IEquatable<Result>
	{
		// Token: 0x0600012D RID: 301 RVA: 0x00004292 File Offset: 0x00002492
		public Result(int code)
		{
			this._code = code;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00004292 File Offset: 0x00002492
		public Result(uint code)
		{
			this._code = (int)code;
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600012F RID: 303 RVA: 0x0000429B File Offset: 0x0000249B
		public int Code
		{
			get
			{
				return this._code;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000130 RID: 304 RVA: 0x000042A3 File Offset: 0x000024A3
		public bool Success
		{
			get
			{
				return this.Code >= 0;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000131 RID: 305 RVA: 0x000042B1 File Offset: 0x000024B1
		public bool Failure
		{
			get
			{
				return this.Code < 0;
			}
		}

		// Token: 0x06000132 RID: 306 RVA: 0x000042BC File Offset: 0x000024BC
		public static explicit operator int(Result result)
		{
			return result.Code;
		}

		// Token: 0x06000133 RID: 307 RVA: 0x000042BC File Offset: 0x000024BC
		public static explicit operator uint(Result result)
		{
			return (uint)result.Code;
		}

		// Token: 0x06000134 RID: 308 RVA: 0x000042C5 File Offset: 0x000024C5
		public static implicit operator Result(int result)
		{
			return new Result(result);
		}

		// Token: 0x06000135 RID: 309 RVA: 0x000042CD File Offset: 0x000024CD
		public static implicit operator Result(uint result)
		{
			return new Result(result);
		}

		// Token: 0x06000136 RID: 310 RVA: 0x000042D5 File Offset: 0x000024D5
		public bool Equals(Result other)
		{
			return this.Code == other.Code;
		}

		// Token: 0x06000137 RID: 311 RVA: 0x000042E6 File Offset: 0x000024E6
		public override bool Equals(object obj)
		{
			return obj is Result && this.Equals((Result)obj);
		}

		// Token: 0x06000138 RID: 312 RVA: 0x000042FE File Offset: 0x000024FE
		public override int GetHashCode()
		{
			return this.Code;
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00004306 File Offset: 0x00002506
		public static bool operator ==(Result left, Result right)
		{
			return left.Code == right.Code;
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00004318 File Offset: 0x00002518
		public static bool operator !=(Result left, Result right)
		{
			return left.Code != right.Code;
		}

		// Token: 0x0600013B RID: 315 RVA: 0x0000432D File Offset: 0x0000252D
		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "HRESULT = 0x{0:X}", new object[]
			{
				this._code
			});
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00004352 File Offset: 0x00002552
		public void CheckError()
		{
			if (this._code < 0)
			{
				throw new SharpDXException(this);
			}
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00004369 File Offset: 0x00002569
		public static Result GetResultFromException(Exception ex)
		{
			return new Result(Marshal.GetHRForException(ex));
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00004376 File Offset: 0x00002576
		public static Result GetResultFromWin32Error(int win32Error)
		{
			return (win32Error <= 0) ? win32Error : ((int)((long)((win32Error & 65535) | 458752) | (long)((ulong)int.MinValue)));
		}

		// Token: 0x0400003A RID: 58
		private int _code;

		// Token: 0x0400003B RID: 59
		public static readonly Result Ok = new Result(0);

		// Token: 0x0400003C RID: 60
		public static readonly Result False = new Result(1);

		// Token: 0x0400003D RID: 61
		public static readonly ResultDescriptor Abort = new ResultDescriptor(-2147467260, "General", "E_ABORT", "Operation aborted", null);

		// Token: 0x0400003E RID: 62
		public static readonly ResultDescriptor AccessDenied = new ResultDescriptor(-2147024891, "General", "E_ACCESSDENIED", "General access denied error", null);

		// Token: 0x0400003F RID: 63
		public static readonly ResultDescriptor Fail = new ResultDescriptor(-2147467259, "General", "E_FAIL", "Unspecified error", null);

		// Token: 0x04000040 RID: 64
		public static readonly ResultDescriptor Handle = new ResultDescriptor(-2147024890, "General", "E_HANDLE", "Invalid handle", null);

		// Token: 0x04000041 RID: 65
		public static readonly ResultDescriptor InvalidArg = new ResultDescriptor(-2147024809, "General", "E_INVALIDARG", "Invalid Arguments", null);

		// Token: 0x04000042 RID: 66
		public static readonly ResultDescriptor NoInterface = new ResultDescriptor(-2147467262, "General", "E_NOINTERFACE", "No such interface supported", null);

		// Token: 0x04000043 RID: 67
		public static readonly ResultDescriptor NotImplemented = new ResultDescriptor(-2147467263, "General", "E_NOTIMPL", "Not implemented", null);

		// Token: 0x04000044 RID: 68
		public static readonly ResultDescriptor OutOfMemory = new ResultDescriptor(-2147024882, "General", "E_OUTOFMEMORY", "Out of memory", null);

		// Token: 0x04000045 RID: 69
		public static readonly ResultDescriptor InvalidPointer = new ResultDescriptor(-2147467261, "General", "E_POINTER", "Invalid pointer", null);

		// Token: 0x04000046 RID: 70
		public static readonly ResultDescriptor UnexpectedFailure = new ResultDescriptor(-2147418113, "General", "E_UNEXPECTED", "Catastrophic failure", null);

		// Token: 0x04000047 RID: 71
		public static readonly ResultDescriptor WaitAbandoned = new ResultDescriptor(128, "General", "WAIT_ABANDONED", "WaitAbandoned", null);

		// Token: 0x04000048 RID: 72
		public static readonly ResultDescriptor WaitTimeout = new ResultDescriptor(258, "General", "WAIT_TIMEOUT", "WaitTimeout", null);

		// Token: 0x04000049 RID: 73
		public static readonly ResultDescriptor Pending = new ResultDescriptor(-2147483638, "General", "E_PENDING", "Pending", null);
	}
}
