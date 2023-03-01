using System;
using System.Collections.Generic;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000029 RID: 41
	public class PredictionOutput
	{
		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060001C1 RID: 449 RVA: 0x0000B705 File Offset: 0x00009905
		// (set) Token: 0x060001C2 RID: 450 RVA: 0x0000B70D File Offset: 0x0000990D
		public List<AIHeroClient> AoeTargetsHit
		{
			get
			{
				return this._aoeTargetsHit;
			}
			set
			{
				this._aoeTargetsHit = value;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x0000B716 File Offset: 0x00009916
		// (set) Token: 0x060001C4 RID: 452 RVA: 0x0000B72E File Offset: 0x0000992E
		public int AoeTargetsHitCount
		{
			get
			{
				return Math.Max(this._aoeTargetsHitCount, this.AoeTargetsHit.Count);
			}
			set
			{
				this._aoeTargetsHitCount = value;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060001C5 RID: 453 RVA: 0x0000B737 File Offset: 0x00009937
		// (set) Token: 0x060001C6 RID: 454 RVA: 0x0000B74F File Offset: 0x0000994F
		public HitChance OriginHitchance
		{
			get
			{
				if (this.Hitchance == HitChance.Collision)
				{
					return this._originHitchance;
				}
				return this.Hitchance;
			}
			set
			{
				this._originHitchance = value;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x0000B758 File Offset: 0x00009958
		// (set) Token: 0x060001C8 RID: 456 RVA: 0x0000B7C6 File Offset: 0x000099C6
		public Vector3 CastPosition
		{
			get
			{
				if (this._castPosition.IsValid() && this._castPosition.ToVector2().IsValid())
				{
					return this._castPosition;
				}
				if (this.Input.Unit != null && this.Input.Unit.IsValid)
				{
					return this.Input.Unit.ServerPosition;
				}
				return Vector3.Zero;
			}
			set
			{
				this._castPosition = value;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x0000B7D0 File Offset: 0x000099D0
		// (set) Token: 0x060001CA RID: 458 RVA: 0x0000B83E File Offset: 0x00009A3E
		public Vector3 UnitPosition
		{
			get
			{
				if (this._unitPosition.IsValid() && this._unitPosition.ToVector2().IsValid())
				{
					return this._unitPosition;
				}
				if (this.Input.Unit != null && this.Input.Unit.IsValid)
				{
					return this.Input.Unit.ServerPosition;
				}
				return Vector3.Zero;
			}
			set
			{
				this._unitPosition = value;
			}
		}

		// Token: 0x040000D7 RID: 215
		internal int _aoeTargetsHitCount;

		// Token: 0x040000D8 RID: 216
		internal List<AIHeroClient> _aoeTargetsHit = new List<AIHeroClient>();

		// Token: 0x040000D9 RID: 217
		internal Vector3 _castPosition = Vector3.Zero;

		// Token: 0x040000DA RID: 218
		internal Vector3 _unitPosition = Vector3.Zero;

		// Token: 0x040000DB RID: 219
		internal HitChance _originHitchance = HitChance.None;

		// Token: 0x040000DC RID: 220
		public string Idle = "";

		// Token: 0x040000DD RID: 221
		public List<AIBaseClient> CollisionObjects = new List<AIBaseClient>();

		// Token: 0x040000DE RID: 222
		public HitChance Hitchance = HitChance.None;

		// Token: 0x040000DF RID: 223
		public PredictionInput Input;
	}
}
