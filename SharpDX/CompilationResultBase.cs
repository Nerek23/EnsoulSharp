using System;

namespace SharpDX
{
	// Token: 0x02000018 RID: 24
	public abstract class CompilationResultBase<T> : DisposeBase where T : class, IDisposable
	{
		// Token: 0x060000B7 RID: 183 RVA: 0x0000388C File Offset: 0x00001A8C
		protected CompilationResultBase(T bytecode, Result resultCode, string message = null)
		{
			this.Bytecode = bytecode;
			this.ResultCode = resultCode;
			this.Message = message;
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x000038A9 File Offset: 0x00001AA9
		// (set) Token: 0x060000B9 RID: 185 RVA: 0x000038B1 File Offset: 0x00001AB1
		public T Bytecode { get; private set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000BA RID: 186 RVA: 0x000038BA File Offset: 0x00001ABA
		// (set) Token: 0x060000BB RID: 187 RVA: 0x000038C2 File Offset: 0x00001AC2
		public Result ResultCode { get; private set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000BC RID: 188 RVA: 0x000038CC File Offset: 0x00001ACC
		public bool HasErrors
		{
			get
			{
				return this.ResultCode.Failure;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000BD RID: 189 RVA: 0x000038E7 File Offset: 0x00001AE7
		// (set) Token: 0x060000BE RID: 190 RVA: 0x000038EF File Offset: 0x00001AEF
		public string Message { get; private set; }

		// Token: 0x060000BF RID: 191 RVA: 0x000038F8 File Offset: 0x00001AF8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.Bytecode != null)
			{
				this.Bytecode.Dispose();
				this.Bytecode = default(T);
			}
		}
	}
}
