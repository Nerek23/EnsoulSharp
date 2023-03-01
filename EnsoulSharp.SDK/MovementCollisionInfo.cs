using System;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000055 RID: 85
	public struct MovementCollisionInfo
	{
		// Token: 0x0600034F RID: 847 RVA: 0x00018E92 File Offset: 0x00017092
		internal MovementCollisionInfo(float collisionTime, Vector2 collisionPosition)
		{
			this.CollisionTime = collisionTime;
			this.CollisionPosition = collisionPosition;
		}

		// Token: 0x170000A0 RID: 160
		public object this[int i]
		{
			get
			{
				if (i != 0)
				{
					return this.CollisionPosition;
				}
				return this.CollisionTime;
			}
		}

		// Token: 0x040001EF RID: 495
		public float CollisionTime;

		// Token: 0x040001F0 RID: 496
		public Vector2 CollisionPosition;
	}
}
