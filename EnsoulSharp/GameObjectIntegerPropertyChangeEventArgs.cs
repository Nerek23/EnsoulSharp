using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	Args for <see cref="T:EnsoulSharp.GameObject" /> integer property change event.
	/// </summary>
	// Token: 0x0200003E RID: 62
	public class GameObjectIntegerPropertyChangeEventArgs : EventArgs
	{
		// Token: 0x0600029A RID: 666 RVA: 0x0000C67C File Offset: 0x0000BA7C
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
		// (get) Token: 0x0600029B RID: 667 RVA: 0x0000C6A4 File Offset: 0x0000BAA4
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
		// (get) Token: 0x0600029C RID: 668 RVA: 0x0000C6B8 File Offset: 0x0000BAB8
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
		// (get) Token: 0x0600029D RID: 669 RVA: 0x0000C6CC File Offset: 0x0000BACC
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
