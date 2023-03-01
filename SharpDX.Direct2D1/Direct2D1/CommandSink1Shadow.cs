using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000186 RID: 390
	internal class CommandSink1Shadow : ComObjectShadow
	{
		// Token: 0x06000758 RID: 1880 RVA: 0x0001652D File Offset: 0x0001472D
		public static IntPtr ToIntPtr(CommandSink1 callback)
		{
			return CppObject.ToCallbackPtr<CommandSink1>(callback);
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x06000759 RID: 1881 RVA: 0x00016535 File Offset: 0x00014735
		protected override CppObjectVtbl GetVtbl
		{
			get
			{
				return CommandSink1Shadow.Vtbl;
			}
		}

		// Token: 0x040005F9 RID: 1529
		private static readonly CommandSink1Shadow.CommandSink1Vtbl Vtbl = new CommandSink1Shadow.CommandSink1Vtbl();

		// Token: 0x02000187 RID: 391
		public class CommandSink1Vtbl : CommandSinkShadow.CommandSinkVtbl
		{
			// Token: 0x0600075C RID: 1884 RVA: 0x00016548 File Offset: 0x00014748
			public CommandSink1Vtbl() : base(1)
			{
				base.AddMethod(new CommandSink1Shadow.CommandSink1Vtbl.SetPrimitiveBlend1Delegate(CommandSink1Shadow.CommandSink1Vtbl.SetPrimitiveBlend1Impl));
			}

			// Token: 0x0600075D RID: 1885 RVA: 0x00016564 File Offset: 0x00014764
			private static int SetPrimitiveBlend1Impl(IntPtr thisPtr, PrimitiveBlend primitiveBlend)
			{
				try
				{
					((CommandSink1)CppObjectShadow.ToShadow<CommandSink1Shadow>(thisPtr).Callback).PrimitiveBlend1 = primitiveBlend;
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x02000188 RID: 392
			// (Invoke) Token: 0x0600075F RID: 1887
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int SetPrimitiveBlend1Delegate(IntPtr thisPtr, PrimitiveBlend primitiveBlend);
		}
	}
}
