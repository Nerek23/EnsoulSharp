using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	Args for <see cref="T:EnsoulSharp.GameObject" /> float property change event.
	/// </summary>
	// Token: 0x0200003D RID: 61
	public class GameObjectFloatPropertyChangeEventArgs : EventArgs
	{
		// Token: 0x0600028F RID: 655 RVA: 0x0000C528 File Offset: 0x0000B928
		internal GameObjectFloatPropertyChangeEventArgs(string property, float oldValue, float newValue)
		{
			this.m_property = property;
			this.m_oldValue = oldValue;
			this.m_newValue = newValue;
		}

		/// <summary>
		/// 	Gets the property name.
		/// </summary>
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000290 RID: 656 RVA: 0x0000C550 File Offset: 0x0000B950
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
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000291 RID: 657 RVA: 0x0000C564 File Offset: 0x0000B964
		public float OldValue
		{
			get
			{
				return this.m_oldValue;
			}
		}

		/// <summary>
		/// 	Gets the new property value;
		/// </summary>
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000292 RID: 658 RVA: 0x0000C578 File Offset: 0x0000B978
		public float NewValue
		{
			get
			{
				return this.m_newValue;
			}
		}

		// Token: 0x04000348 RID: 840
		private string m_property;

		// Token: 0x04000349 RID: 841
		private float m_oldValue;

		// Token: 0x0400034A RID: 842
		private float m_newValue;
	}
}
