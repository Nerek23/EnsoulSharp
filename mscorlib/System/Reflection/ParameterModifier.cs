using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Attaches a modifier to parameters so that binding can work with parameter signatures in which the types have been modified.</summary>
	// Token: 0x020005EB RID: 1515
	[ComVisible(true)]
	[Serializable]
	public struct ParameterModifier
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.ParameterModifier" /> structure representing the specified number of parameters.</summary>
		/// <param name="parameterCount">The number of parameters.</param>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="parameterCount" /> is negative.</exception>
		// Token: 0x06004729 RID: 18217 RVA: 0x0010220A File Offset: 0x0010040A
		public ParameterModifier(int parameterCount)
		{
			if (parameterCount <= 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_ParmArraySize"));
			}
			this._byRef = new bool[parameterCount];
		}

		// Token: 0x17000B25 RID: 2853
		// (get) Token: 0x0600472A RID: 18218 RVA: 0x0010222C File Offset: 0x0010042C
		internal bool[] IsByRefArray
		{
			get
			{
				return this._byRef;
			}
		}

		/// <summary>Gets or sets a value that specifies whether the parameter at the specified index position is to be modified by the current <see cref="T:System.Reflection.ParameterModifier" />.</summary>
		/// <param name="index">The index position of the parameter whose modification status is being examined or set.</param>
		/// <returns>
		///   <see langword="true" /> if the parameter at this index position is to be modified by this <see cref="T:System.Reflection.ParameterModifier" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000B26 RID: 2854
		public bool this[int index]
		{
			get
			{
				return this._byRef[index];
			}
			set
			{
				this._byRef[index] = value;
			}
		}

		// Token: 0x04001D44 RID: 7492
		private bool[] _byRef;
	}
}
