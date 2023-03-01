using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each perk.
	/// </summary>
	// Token: 0x020000BA RID: 186
	public class Perk
	{
		// Token: 0x060004D5 RID: 1237 RVA: 0x0000E058 File Offset: 0x0000D458
		internal Perk(int id, string name)
		{
			this.m_id = id;
			this.m_name = name;
		}

		/// <summary>
		/// 	Gets the id of the perk.
		/// </summary>
		// Token: 0x17000118 RID: 280
		// (get) Token: 0x060004D6 RID: 1238 RVA: 0x0000E07C File Offset: 0x0000D47C
		public int Id
		{
			get
			{
				return this.m_id;
			}
		}

		/// <summary>
		/// 	Gets the name of the perk.
		/// </summary>
		// Token: 0x17000117 RID: 279
		// (get) Token: 0x060004D7 RID: 1239 RVA: 0x0000E090 File Offset: 0x0000D490
		public string Name
		{
			get
			{
				return this.m_name;
			}
		}

		// Token: 0x040003BB RID: 955
		private int m_id;

		// Token: 0x040003BC RID: 956
		private string m_name;
	}
}
