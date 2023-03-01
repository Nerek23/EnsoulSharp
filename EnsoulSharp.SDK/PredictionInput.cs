using System;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000028 RID: 40
	public class PredictionInput
	{
		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060001BB RID: 443 RVA: 0x0000B60A File Offset: 0x0000980A
		// (set) Token: 0x060001BC RID: 444 RVA: 0x0000B62F File Offset: 0x0000982F
		public Vector3 From
		{
			get
			{
				if (!this._from.ToVector2().IsValid())
				{
					return GameObjects.Player.ServerPosition;
				}
				return this._from;
			}
			set
			{
				this._from = value;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060001BD RID: 445 RVA: 0x0000B638 File Offset: 0x00009838
		// (set) Token: 0x060001BE RID: 446 RVA: 0x0000B676 File Offset: 0x00009876
		public Vector3 RangeCheckFrom
		{
			get
			{
				if (this._rangeCheckFrom.ToVector2().IsValid())
				{
					return this._rangeCheckFrom;
				}
				if (!this.From.ToVector2().IsValid())
				{
					return GameObjects.Player.ServerPosition;
				}
				return this.From;
			}
			set
			{
				this._rangeCheckFrom = value;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060001BF RID: 447 RVA: 0x0000B67F File Offset: 0x0000987F
		public float RealRadius
		{
			get
			{
				if (!this.AddHitBox)
				{
					return this.Radius;
				}
				return this.Radius + this.Unit.BoundingRadius;
			}
		}

		// Token: 0x040000C8 RID: 200
		internal Vector3 _from;

		// Token: 0x040000C9 RID: 201
		internal Vector3 _rangeCheckFrom;

		// Token: 0x040000CA RID: 202
		public bool AddHitBox = true;

		// Token: 0x040000CB RID: 203
		public bool Aoe;

		// Token: 0x040000CC RID: 204
		public bool ChoiceCloserPosition;

		// Token: 0x040000CD RID: 205
		public bool Collision;

		// Token: 0x040000CE RID: 206
		public CollisionObjects[] CollisionObjects = new CollisionObjects[]
		{
			EnsoulSharp.SDK.CollisionObjects.Minions,
			EnsoulSharp.SDK.CollisionObjects.YasuoWall
		};

		// Token: 0x040000CF RID: 207
		public float Delay;

		// Token: 0x040000D0 RID: 208
		public float MaxCollisionCount;

		// Token: 0x040000D1 RID: 209
		public float Radius = 1f;

		// Token: 0x040000D2 RID: 210
		public float Range = float.MaxValue;

		// Token: 0x040000D3 RID: 211
		public float Speed = float.MaxValue;

		// Token: 0x040000D4 RID: 212
		public SpellType Type = SpellType.None;

		// Token: 0x040000D5 RID: 213
		public Spell Spell;

		// Token: 0x040000D6 RID: 214
		public AIBaseClient Unit = GameObjects.Player;
	}
}
