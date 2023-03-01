using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000012 RID: 18
	public class CompilationResult : CompilationResultBase<ShaderBytecode>
	{
		// Token: 0x06000098 RID: 152 RVA: 0x00003E3E File Offset: 0x0000203E
		public CompilationResult(ShaderBytecode bytecode, Result resultCode, string message) : base(bytecode, resultCode, message)
		{
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00003E49 File Offset: 0x00002049
		public static implicit operator ShaderBytecode(CompilationResult input)
		{
			if (input == null)
			{
				return null;
			}
			return input.Bytecode;
		}
	}
}
