using System;

namespace EnsoulSharp
{
	/// <summary>
	/// 	Args for <see cref="T:EnsoulSharp.GameObject" /> float property change event.
	/// </summary>
	// Token: 0x0200003D RID: 61
	public class GameObjectFloatPropertyChangeEventArgs : EventArgs
	{
		// Token: 0x06000296 RID: 662 RVA: 0x0000C618 File Offset: 0x0000BA18
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
		// (get) Token: 0x06000297 RID: 663 RVA: 0x0000C640 File Offset: 0x0000BA40
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
		// (get) Token: 0x06000298 RID: 664 RVA: 0x0000C654 File Offset: 0x0000BA54
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
		// (get) Token: 0x06000299 RID: 665 RVA: 0x0000C668 File Offset: 0x0000BA68
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
