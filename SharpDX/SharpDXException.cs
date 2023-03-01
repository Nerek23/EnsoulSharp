using System;
using System.Globalization;

namespace SharpDX
{
	// Token: 0x0200002F RID: 47
	public class SharpDXException : Exception
	{
		// Token: 0x0600016C RID: 364 RVA: 0x00004E93 File Offset: 0x00003093
		public SharpDXException() : base("A SharpDX exception occurred.")
		{
			this.descriptor = ResultDescriptor.Find(Result.Fail);
			base.HResult = (int)Result.Fail;
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00004EC5 File Offset: 0x000030C5
		public SharpDXException(Result result) : this(ResultDescriptor.Find(result))
		{
			base.HResult = (int)result;
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00004EDF File Offset: 0x000030DF
		public SharpDXException(ResultDescriptor descriptor) : base(descriptor.ToString())
		{
			this.descriptor = descriptor;
			base.HResult = (int)descriptor.Result;
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00004F05 File Offset: 0x00003105
		public SharpDXException(Result result, string message) : base(message)
		{
			this.descriptor = ResultDescriptor.Find(result);
			base.HResult = (int)result;
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00004F26 File Offset: 0x00003126
		public SharpDXException(Result result, string message, params object[] args) : base(string.Format(CultureInfo.InvariantCulture, message, args))
		{
			this.descriptor = ResultDescriptor.Find(result);
			base.HResult = (int)result;
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00004F52 File Offset: 0x00003152
		public SharpDXException(string message, params object[] args) : this(Result.Fail, message, args)
		{
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00004F66 File Offset: 0x00003166
		public SharpDXException(string message, Exception innerException, params object[] args) : base(string.Format(CultureInfo.InvariantCulture, message, args), innerException)
		{
			this.descriptor = ResultDescriptor.Find(Result.Fail);
			base.HResult = (int)Result.Fail;
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000173 RID: 371 RVA: 0x00004FA0 File Offset: 0x000031A0
		public Result ResultCode
		{
			get
			{
				return this.descriptor.Result;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000174 RID: 372 RVA: 0x00004FAD File Offset: 0x000031AD
		public ResultDescriptor Descriptor
		{
			get
			{
				return this.descriptor;
			}
		}

		// Token: 0x0400005A RID: 90
		private ResultDescriptor descriptor;
	}
}
