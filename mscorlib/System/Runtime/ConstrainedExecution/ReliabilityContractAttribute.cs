using System;

namespace System.Runtime.ConstrainedExecution
{
	/// <summary>Defines a contract for reliability between the author of some code, and the developers who have a dependency on that code.</summary>
	// Token: 0x020006FF RID: 1791
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Interface, Inherited = false)]
	public sealed class ReliabilityContractAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.ConstrainedExecution.ReliabilityContractAttribute" /> class with the specified <see cref="T:System.Runtime.ConstrainedExecution.Consistency" /> guarantee and <see cref="T:System.Runtime.ConstrainedExecution.Cer" /> value.</summary>
		/// <param name="consistencyGuarantee">One of the <see cref="T:System.Runtime.ConstrainedExecution.Consistency" /> values.</param>
		/// <param name="cer">One of the <see cref="T:System.Runtime.ConstrainedExecution.Cer" /> values.</param>
		// Token: 0x06005054 RID: 20564 RVA: 0x0011A6F4 File Offset: 0x001188F4
		public ReliabilityContractAttribute(Consistency consistencyGuarantee, Cer cer)
		{
			this._consistency = consistencyGuarantee;
			this._cer = cer;
		}

		/// <summary>Gets the value of the <see cref="T:System.Runtime.ConstrainedExecution.Consistency" /> reliability contract.</summary>
		/// <returns>One of the <see cref="T:System.Runtime.ConstrainedExecution.Consistency" /> values.</returns>
		// Token: 0x17000D58 RID: 3416
		// (get) Token: 0x06005055 RID: 20565 RVA: 0x0011A70A File Offset: 0x0011890A
		public Consistency ConsistencyGuarantee
		{
			get
			{
				return this._consistency;
			}
		}

		/// <summary>Gets the value that determines the behavior of a method, type, or assembly when called under a Constrained Execution Region (CER).</summary>
		/// <returns>One of the <see cref="T:System.Runtime.ConstrainedExecution.Cer" /> values.</returns>
		// Token: 0x17000D59 RID: 3417
		// (get) Token: 0x06005056 RID: 20566 RVA: 0x0011A712 File Offset: 0x00118912
		public Cer Cer
		{
			get
			{
				return this._cer;
			}
		}

		// Token: 0x0400237D RID: 9085
		private Consistency _consistency;

		// Token: 0x0400237E RID: 9086
		private Cer _cer;
	}
}
