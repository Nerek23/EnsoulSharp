using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	Args for <see cref="T:EnsoulSharp.GameObject" /> integer property change event.
	/// </summary>
	// Token: 0x0200003E RID: 62
	public class GameObjectIntegerPropertyChangeEventArgs : EventArgs
	{
		// Token: 0x06000293 RID: 659 RVA: 0x0000C58C File Offset: 0x0000B98C
		internal GameObjectIntegerPropertyChangeEventArgs(string property, int oldValue, int newValue)
		{
			this.m_property = property;
			this.m_oldValue = oldValue;
			this.m_newValue = newValue;
		}

		/// <summary>
		/// 	Gets the property name.
		/// </summary>
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000294 RID: 660 RVA: 0x0000C5B4 File Offset: 0x0000B9B4
		public string Property
		{
			get
			{
				return this.m_property;
			}
		}

		/// <summary>
		/// 	Gets the old property value.
		/// </summary>
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000295 RID: 661 RVA: 0x0000C5C8 File Offset: 0x0000B9C8
		public int OldValue
		{
			get
			{
				return this.m_oldValue;
			}
		}

		/// <summary>
		/// 	Gets the new property value.
		/// </summary>
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000296 RID: 662 RVA: 0x0000C5DC File Offset: 0x0000B9DC
		public int NewValue
		{
			get
			{
				return this.m_newValue;
			}
		}

		// Token: 0x0400034B RID: 843
		private string m_property;

		// Token: 0x0400034C RID: 844
		private int m_oldValue;

		// Token: 0x0400034D RID: 845
		private int m_newValue;
	}
}
