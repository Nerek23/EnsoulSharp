using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	/// <summary>Determines the set of valid key sizes for the symmetric cryptographic algorithms.</summary>
	// Token: 0x02000242 RID: 578
	[ComVisible(true)]
	public sealed class KeySizes
	{
		/// <summary>Specifies the minimum key size in bits.</summary>
		/// <returns>The minimum key size in bits.</returns>
		// Token: 0x170003E8 RID: 1000
		// (get) Token: 0x060020A8 RID: 8360 RVA: 0x000727E7 File Offset: 0x000709E7
		public int MinSize
		{
			get
			{
				return this.m_minSize;
			}
		}

		/// <summary>Specifies the maximum key size in bits.</summary>
		/// <returns>The maximum key size in bits.</returns>
		// Token: 0x170003E9 RID: 1001
		// (get) Token: 0x060020A9 RID: 8361 RVA: 0x000727EF File Offset: 0x000709EF
		public int MaxSize
		{
			get
			{
				return this.m_maxSize;
			}
		}

		/// <summary>Specifies the interval between valid key sizes in bits.</summary>
		/// <returns>The interval between valid key sizes in bits.</returns>
		// Token: 0x170003EA RID: 1002
		// (get) Token: 0x060020AA RID: 8362 RVA: 0x000727F7 File Offset: 0x000709F7
		public int SkipSize
		{
			get
			{
				return this.m_skipSize;
			}
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Cryptography.KeySizes" /> class with the specified key values.</summary>
		/// <param name="minSize">The minimum valid key size.</param>
		/// <param name="maxSize">The maximum valid key size.</param>
		/// <param name="skipSize">The interval between valid key sizes.</param>
		// Token: 0x060020AB RID: 8363 RVA: 0x000727FF File Offset: 0x000709FF
		public KeySizes(int minSize, int maxSize, int skipSize)
		{
			this.m_minSize = minSize;
			this.m_maxSize = maxSize;
			this.m_skipSize = skipSize;
		}

		// Token: 0x04000BDE RID: 3038
		private int m_minSize;

		// Token: 0x04000BDF RID: 3039
		private int m_maxSize;

		// Token: 0x04000BE0 RID: 3040
		private int m_skipSize;
	}
}
