using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x0200002C RID: 44
	public class Spell
	{
		// Token: 0x060001CF RID: 463 RVA: 0x0000B9B5 File Offset: 0x00009BB5
		public Spell()
		{
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x0000B9DD File Offset: 0x00009BDD
		public Spell(SpellSlot slot)
		{
			this.Slot = slot;
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x0000BA0C File Offset: 0x00009C0C
		public Spell(SpellSlot slot, float range) : this(slot)
		{
			this.Range = range;
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060001D2 RID: 466 RVA: 0x0000BA1C File Offset: 0x00009C1C
		public SpellDataInst Instance
		{
			get
			{
				return GameObjects.Player.Spellbook.GetSpell(this.Slot);
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x0000BA33 File Offset: 0x00009C33
		// (set) Token: 0x060001D4 RID: 468 RVA: 0x0000BA3B File Offset: 0x00009C3B
		public bool AddHitBox { get; set; } = true;

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060001D5 RID: 469 RVA: 0x0000BA44 File Offset: 0x00009C44
		public int Ammo
		{
			get
			{
				return this.Instance.Ammo;
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060001D6 RID: 470 RVA: 0x0000BA51 File Offset: 0x00009C51
		// (set) Token: 0x060001D7 RID: 471 RVA: 0x0000BA59 File Offset: 0x00009C59
		public Spell.CastControlDelegate CastControl { get; set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060001D8 RID: 472 RVA: 0x0000BA62 File Offset: 0x00009C62
		// (set) Token: 0x060001D9 RID: 473 RVA: 0x0000BA6A File Offset: 0x00009C6A
		public string ChargedBuffName { get; set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060001DA RID: 474 RVA: 0x0000BA73 File Offset: 0x00009C73
		// (set) Token: 0x060001DB RID: 475 RVA: 0x0000BA7B File Offset: 0x00009C7B
		public int ChargedMaxRange { get; set; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060001DC RID: 476 RVA: 0x0000BA84 File Offset: 0x00009C84
		// (set) Token: 0x060001DD RID: 477 RVA: 0x0000BA8C File Offset: 0x00009C8C
		public int ChargedMinRange { get; set; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060001DE RID: 478 RVA: 0x0000BA95 File Offset: 0x00009C95
		// (set) Token: 0x060001DF RID: 479 RVA: 0x0000BA9D File Offset: 0x00009C9D
		public string ChargedSpellName { get; set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060001E0 RID: 480 RVA: 0x0000BAA6 File Offset: 0x00009CA6
		// (set) Token: 0x060001E1 RID: 481 RVA: 0x0000BAAE File Offset: 0x00009CAE
		public float ChargeDuration { get; set; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060001E2 RID: 482 RVA: 0x0000BAB7 File Offset: 0x00009CB7
		// (set) Token: 0x060001E3 RID: 483 RVA: 0x0000BABF File Offset: 0x00009CBF
		public bool Collision { get; set; }

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060001E4 RID: 484 RVA: 0x0000BAC8 File Offset: 0x00009CC8
		// (set) Token: 0x060001E5 RID: 485 RVA: 0x0000BAD0 File Offset: 0x00009CD0
		public float MaxCollisionCount { get; set; }

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060001E6 RID: 486 RVA: 0x0000BAD9 File Offset: 0x00009CD9
		public float CooldownTime
		{
			get
			{
				if (this.SData != null)
				{
					return Math.Max(this.Instance.CooldownExpires - Game.Time, 0f);
				}
				return float.MaxValue;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060001E7 RID: 487 RVA: 0x0000BB04 File Offset: 0x00009D04
		// (set) Token: 0x060001E8 RID: 488 RVA: 0x0000BB0C File Offset: 0x00009D0C
		public float Delay { get; set; }

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060001E9 RID: 489 RVA: 0x0000BB15 File Offset: 0x00009D15
		// (set) Token: 0x060001EA RID: 490 RVA: 0x0000BB1D File Offset: 0x00009D1D
		public float LastCastAttemptTime { get; set; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060001EB RID: 491 RVA: 0x0000BB26 File Offset: 0x00009D26
		// (set) Token: 0x060001EC RID: 492 RVA: 0x0000BB2E File Offset: 0x00009D2E
		public float ChargeRequestSentTime { get; set; }

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060001ED RID: 493 RVA: 0x0000BB37 File Offset: 0x00009D37
		// (set) Token: 0x060001EE RID: 494 RVA: 0x0000BB3F File Offset: 0x00009D3F
		public float ChargedCastedTime { get; set; }

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060001EF RID: 495 RVA: 0x0000BB48 File Offset: 0x00009D48
		// (set) Token: 0x060001F0 RID: 496 RVA: 0x0000BB68 File Offset: 0x00009D68
		public Vector3 From
		{
			get
			{
				if (this.from.IsValid())
				{
					return this.from;
				}
				return GameObjects.Player.ServerPosition;
			}
			set
			{
				this.from = value;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060001F1 RID: 497 RVA: 0x0000BB71 File Offset: 0x00009D71
		// (set) Token: 0x060001F2 RID: 498 RVA: 0x0000BB79 File Offset: 0x00009D79
		public Spell.CustomDamageDelegate GetCustomDamages { get; set; }

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060001F3 RID: 499 RVA: 0x0000BB82 File Offset: 0x00009D82
		// (set) Token: 0x060001F4 RID: 500 RVA: 0x0000BB8A File Offset: 0x00009D8A
		public int GetCustomDamageStage { get; set; }

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060001F5 RID: 501 RVA: 0x0000BB93 File Offset: 0x00009D93
		// (set) Token: 0x060001F6 RID: 502 RVA: 0x0000BB9B File Offset: 0x00009D9B
		public bool HumanizerCast { get; set; }

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x0000BBA4 File Offset: 0x00009DA4
		// (set) Token: 0x060001F8 RID: 504 RVA: 0x0000BBAC File Offset: 0x00009DAC
		public HitChance MinHitChance { get; set; } = HitChance.High;

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060001F9 RID: 505 RVA: 0x0000BBB5 File Offset: 0x00009DB5
		// (set) Token: 0x060001FA RID: 506 RVA: 0x0000BBBD File Offset: 0x00009DBD
		public DamageType DamageType { get; set; } = DamageType.True;

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060001FB RID: 507 RVA: 0x0000BBC6 File Offset: 0x00009DC6
		public float Mana
		{
			get
			{
				if (this.SData != null)
				{
					return this.Instance.ManaCost;
				}
				return 0f;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060001FC RID: 508 RVA: 0x0000BBE1 File Offset: 0x00009DE1
		public string Name
		{
			get
			{
				return this.Instance.Name;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060001FD RID: 509 RVA: 0x0000BBEE File Offset: 0x00009DEE
		// (set) Token: 0x060001FE RID: 510 RVA: 0x0000BBF6 File Offset: 0x00009DF6
		public bool IsChargedSpell { get; set; }

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060001FF RID: 511 RVA: 0x0000BBFF File Offset: 0x00009DFF
		public bool IsCharging
		{
			get
			{
				return this.IsReady(0) && (GameObjects.Player.HasBuff(this.ChargedBuffName) || (float)Variables.GameTimeTickCount - this.ChargedCastedTime < (float)(300 + Game.Ping));
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000200 RID: 512 RVA: 0x0000BC3B File Offset: 0x00009E3B
		// (set) Token: 0x06000201 RID: 513 RVA: 0x0000BC43 File Offset: 0x00009E43
		public bool IsSkillShot { get; set; }

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000202 RID: 514 RVA: 0x0000BC4C File Offset: 0x00009E4C
		public int Level
		{
			get
			{
				return this.Instance.Level;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000203 RID: 515 RVA: 0x0000BC59 File Offset: 0x00009E59
		// (set) Token: 0x06000204 RID: 516 RVA: 0x0000BC61 File Offset: 0x00009E61
		public bool PredictionCloserPosition { get; set; }

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000205 RID: 517 RVA: 0x0000BC6C File Offset: 0x00009E6C
		// (set) Token: 0x06000206 RID: 518 RVA: 0x0000BCDC File Offset: 0x00009EDC
		public float Range
		{
			get
			{
				if (!this.IsChargedSpell)
				{
					return this.range;
				}
				if (this.IsCharging)
				{
					return (float)this.ChargedMinRange + Math.Min((float)(this.ChargedMaxRange - this.ChargedMinRange), ((float)Variables.GameTimeTickCount - this.ChargedCastedTime) * (float)(this.ChargedMaxRange - this.ChargedMinRange) / this.ChargeDuration - 150f);
				}
				return (float)this.ChargedMaxRange;
			}
			set
			{
				this.range = value;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000207 RID: 519 RVA: 0x0000BCE5 File Offset: 0x00009EE5
		// (set) Token: 0x06000208 RID: 520 RVA: 0x0000BD0A File Offset: 0x00009F0A
		public Vector3 RangeCheckFrom
		{
			get
			{
				if (this.rangeCheckFrom.ToVector2().IsValid())
				{
					return this.rangeCheckFrom;
				}
				return GameObjects.Player.ServerPosition;
			}
			set
			{
				this.rangeCheckFrom = value;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000209 RID: 521 RVA: 0x0000BD13 File Offset: 0x00009F13
		public SpellData SData
		{
			get
			{
				return this.Instance.SData;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x0600020A RID: 522 RVA: 0x0000BD20 File Offset: 0x00009F20
		// (set) Token: 0x0600020B RID: 523 RVA: 0x0000BD28 File Offset: 0x00009F28
		public SpellSlot Slot { get; set; }

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x0600020C RID: 524 RVA: 0x0000BD31 File Offset: 0x00009F31
		public SpellState State
		{
			get
			{
				return this.Instance.State;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x0600020D RID: 525 RVA: 0x0000BD3E File Offset: 0x00009F3E
		// (set) Token: 0x0600020E RID: 526 RVA: 0x0000BD46 File Offset: 0x00009F46
		public float Speed { get; set; }

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x0600020F RID: 527 RVA: 0x0000BD4F File Offset: 0x00009F4F
		public SpellToggleState ToggleState
		{
			get
			{
				return this.Instance.ToggleState;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000210 RID: 528 RVA: 0x0000BD5C File Offset: 0x00009F5C
		// (set) Token: 0x06000211 RID: 529 RVA: 0x0000BD64 File Offset: 0x00009F64
		public SpellType Type { get; set; }

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000212 RID: 530 RVA: 0x0000BD6D File Offset: 0x00009F6D
		// (set) Token: 0x06000213 RID: 531 RVA: 0x0000BD75 File Offset: 0x00009F75
		public float Width { get; set; }

		// Token: 0x06000214 RID: 532 RVA: 0x0000BD80 File Offset: 0x00009F80
		public bool CanCast(AIBaseClient unit)
		{
			return this.IsReady(0) && unit.IsValidTarget(this.Range, true, default(Vector3));
		}

		// Token: 0x06000215 RID: 533 RVA: 0x0000BDB0 File Offset: 0x00009FB0
		public CastStates Cast(AIBaseClient target, bool exactHitChance = false, bool areaOfEffect = false, int minTargets = -1, HitChance tempHitChance = HitChance.None)
		{
			if ((this.HumanizerCast || Library.GameCache.HumainzerSpellCast) && this.LastCastAttemptTime + 100f > (float)Variables.GameTimeTickCount)
			{
				return CastStates.HumanizerDisable;
			}
			if (!this.IsReady(0))
			{
				return CastStates.NotReady;
			}
			if (target == null || !target.IsValid())
			{
				return CastStates.InvalidTarget;
			}
			if (this.CastControl != null && !this.CastControl())
			{
				return CastStates.FailedControl;
			}
			if (!areaOfEffect && minTargets != -1)
			{
				areaOfEffect = true;
			}
			if (this.IsSkillShot || this.IsChargedSpell)
			{
				PredictionOutput prediction = this.GetPrediction(target, areaOfEffect, -1f, null);
				if (minTargets != -1 && prediction.AoeTargetsHitCount <= minTargets)
				{
					return CastStates.NotEnoughTargets;
				}
				if (prediction.CollisionObjects.Count > 0)
				{
					return CastStates.Collision;
				}
				if ((double)this.RangeCheckFrom.DistanceSquared(prediction.CastPosition) > Math.Pow((double)this.range, 2.0))
				{
					return CastStates.OutOfRange;
				}
				if (prediction.Hitchance < ((tempHitChance == HitChance.None) ? this.MinHitChance : tempHitChance) || (exactHitChance && prediction.Hitchance != ((tempHitChance == HitChance.None) ? this.MinHitChance : tempHitChance)))
				{
					return CastStates.LowHitChance;
				}
				if (this.IsChargedSpell)
				{
					if (this.IsCharging)
					{
						if (GameObjects.Player.Spellbook.UpdateChargedSpell(this.Slot, prediction.CastPosition, true))
						{
							this.LastCastAttemptTime = (float)Variables.GameTimeTickCount;
							return CastStates.SuccessfullyCasted;
						}
					}
					else if (this.StartCharging())
					{
						return CastStates.SuccessfullyCasted;
					}
				}
				else if (GameObjects.Player.Spellbook.CastSpell(this.Slot, prediction.CastPosition))
				{
					this.LastCastAttemptTime = (float)Variables.GameTimeTickCount;
					return CastStates.SuccessfullyCasted;
				}
			}
			else if (GameObjects.Player.Spellbook.CastSpell(this.Slot, target))
			{
				this.LastCastAttemptTime = (float)Variables.GameTimeTickCount;
				return CastStates.SuccessfullyCasted;
			}
			return CastStates.NotCasted;
		}

		// Token: 0x06000216 RID: 534 RVA: 0x0000BF64 File Offset: 0x0000A164
		public bool Cast()
		{
			if ((this.HumanizerCast || Library.GameCache.HumainzerSpellCast) && this.LastCastAttemptTime + 100f > (float)Variables.GameTimeTickCount)
			{
				return false;
			}
			if (!this.IsReady(0))
			{
				return false;
			}
			this.LastCastAttemptTime = (float)Variables.GameTimeTickCount;
			return GameObjects.Player.Spellbook.CastSpell(this.Slot, GameObjects.Player);
		}

		// Token: 0x06000217 RID: 535 RVA: 0x0000BFCC File Offset: 0x0000A1CC
		public bool Cast(Vector2 position)
		{
			if ((this.HumanizerCast || Library.GameCache.HumainzerSpellCast) && this.LastCastAttemptTime + 100f > (float)Variables.GameTimeTickCount)
			{
				return false;
			}
			if (!this.IsReady(0))
			{
				return false;
			}
			this.LastCastAttemptTime = (float)Variables.GameTimeTickCount;
			if (!this.IsChargedSpell)
			{
				return GameObjects.Player.Spellbook.CastSpell(this.Slot, position.ToVector3(0f));
			}
			if (!this.IsCharging)
			{
				return this.StartCharging();
			}
			return this.ShootChargedSpell(position);
		}

		// Token: 0x06000218 RID: 536 RVA: 0x0000C05C File Offset: 0x0000A25C
		public bool Cast(Vector3 position)
		{
			if ((this.HumanizerCast || Library.GameCache.HumainzerSpellCast) && this.LastCastAttemptTime + 100f > (float)Variables.GameTimeTickCount)
			{
				return false;
			}
			if (!this.IsReady(0))
			{
				return false;
			}
			this.LastCastAttemptTime = (float)Variables.GameTimeTickCount;
			if (!this.IsChargedSpell)
			{
				return GameObjects.Player.Spellbook.CastSpell(this.Slot, position);
			}
			if (!this.IsCharging)
			{
				return this.StartCharging();
			}
			return this.ShootChargedSpell(position);
		}

		// Token: 0x06000219 RID: 537 RVA: 0x0000C0E0 File Offset: 0x0000A2E0
		public bool Cast(Vector2 start, Vector2 end)
		{
			if ((this.HumanizerCast || Library.GameCache.HumainzerSpellCast) && this.LastCastAttemptTime + 100f > (float)Variables.GameTimeTickCount)
			{
				return false;
			}
			if (!this.IsReady(0))
			{
				return false;
			}
			if (this.IsChargedSpell)
			{
				return false;
			}
			this.LastCastAttemptTime = (float)Variables.GameTimeTickCount;
			return GameObjects.Player.Spellbook.CastSpell(this.Slot, start.ToVector3(0f), end.ToVector3(0f));
		}

		// Token: 0x0600021A RID: 538 RVA: 0x0000C164 File Offset: 0x0000A364
		public bool Cast(Vector3 start, Vector3 end)
		{
			if ((this.HumanizerCast || Library.GameCache.HumainzerSpellCast) && this.LastCastAttemptTime + 100f > (float)Variables.GameTimeTickCount)
			{
				return false;
			}
			if (!this.IsReady(0))
			{
				return false;
			}
			if (this.IsChargedSpell)
			{
				return false;
			}
			this.LastCastAttemptTime = (float)Variables.GameTimeTickCount;
			return GameObjects.Player.Spellbook.CastSpell(this.Slot, start, end);
		}

		// Token: 0x0600021B RID: 539 RVA: 0x0000C1D3 File Offset: 0x0000A3D3
		public CastStates CastIfHitchanceEquals(AIBaseClient unit, HitChance hitChance)
		{
			return this.Cast(unit, true, false, -1, hitChance);
		}

		// Token: 0x0600021C RID: 540 RVA: 0x0000C1E0 File Offset: 0x0000A3E0
		public CastStates CastIfHitchanceMinimum(AIBaseClient unit, HitChance hitChance)
		{
			return this.Cast(unit, false, false, -1, hitChance);
		}

		// Token: 0x0600021D RID: 541 RVA: 0x0000C1ED File Offset: 0x0000A3ED
		public CastStates CastIfWillHit(AIBaseClient unit, int minTargets = 5)
		{
			return this.Cast(unit, false, true, minTargets, HitChance.None);
		}

		// Token: 0x0600021E RID: 542 RVA: 0x0000C1FC File Offset: 0x0000A3FC
		public CastStates CastOnBestTarget(float extraRange = 0f, bool areaOfEffect = false, int minTargets = -1)
		{
			AIHeroClient target = this.GetTarget(extraRange, null);
			if (target == null || !target.IsValidTarget(3.4028235E+38f, true, default(Vector3)))
			{
				return CastStates.NotCasted;
			}
			return this.Cast(target, false, areaOfEffect, minTargets, HitChance.None);
		}

		// Token: 0x0600021F RID: 543 RVA: 0x0000C240 File Offset: 0x0000A440
		public bool CastOnUnit(GameObject unit)
		{
			this.LastCastAttemptTime = (float)Variables.GameTimeTickCount;
			return GameObjects.Player.Spellbook.CastSpell(this.Slot, unit);
		}

		// Token: 0x06000220 RID: 544 RVA: 0x0000C264 File Offset: 0x0000A464
		public List<AIBaseClient> GetCollision(Vector2 fromVector2, List<Vector2> to, float delayOverride = -1f)
		{
			return Collisions.GetCollision((from h in to
			select h.ToVector3(0f)).ToList<Vector3>(), new PredictionInput
			{
				From = fromVector2.ToVector3(0f),
				Type = this.Type,
				Radius = this.Width,
				Delay = ((delayOverride > 0f) ? delayOverride : this.Delay),
				Speed = this.Speed
			});
		}

		// Token: 0x06000221 RID: 545 RVA: 0x0000C2F4 File Offset: 0x0000A4F4
		public FarmLocation GetCircularFarmLocation(IEnumerable<AIBaseClient> minions, float overrideWidth = -1f)
		{
			List<Vector2> minionsPredictedPositions = FarmPrediction.GetMinionsPredictedPositions(minions, this.Delay, this.Width, this.Speed, this.From, this.Range, false, SpellType.Circle, default(Vector3));
			return this.GetCircularFarmLocation(minionsPredictedPositions, overrideWidth);
		}

		// Token: 0x06000222 RID: 546 RVA: 0x0000C33C File Offset: 0x0000A53C
		public FarmLocation GetCircularFarmLocation(IEnumerable<AIMinionClient> minions, float overrideWidth = -1f)
		{
			List<Vector2> minionsPredictedPositions = FarmPrediction.GetMinionsPredictedPositions(minions, this.Delay, this.Width, this.Speed, this.From, this.Range, false, SpellType.Circle, default(Vector3));
			return this.GetCircularFarmLocation(minionsPredictedPositions, overrideWidth);
		}

		// Token: 0x06000223 RID: 547 RVA: 0x0000C381 File Offset: 0x0000A581
		public FarmLocation GetCircularFarmLocation(List<Vector2> minionPositions, float overrideWidth = -1f)
		{
			return FarmPrediction.GetBestCircularFarmLocation(minionPositions, (overrideWidth >= 0f) ? overrideWidth : this.Width, this.Range, 9);
		}

		// Token: 0x06000224 RID: 548 RVA: 0x0000C3A2 File Offset: 0x0000A5A2
		public float GetDamage(AIBaseClient target, int stage = 0)
		{
			if (this.GetCustomDamages != null && this.GetCustomDamageStage == stage)
			{
				return (float)this.GetCustomDamages(target);
			}
			return (float)GameObjects.Player.GetSpellDamage(target, this.Slot, stage);
		}

		// Token: 0x06000225 RID: 549 RVA: 0x0000C3D8 File Offset: 0x0000A5D8
		public float GetHealthPrediction(AIBaseClient unit)
		{
			float num = this.Delay * 1000f - 100f + (float)Game.Ping / 2f;
			if (Math.Abs(this.Speed - 3.4028235E+38f) > 1E-45f)
			{
				num += 1000f * unit.Distance(this.From) / this.Speed;
			}
			return HealthPrediction.GetPrediction(unit, (int)num, 70, HealthPredictionType.Default);
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0000C444 File Offset: 0x0000A644
		public float GetHitCount(HitChance hitChance = HitChance.High)
		{
			return (float)(from e in GameObjects.EnemyHeroes
			select this.GetPrediction(e, false, -1f, null)).Count((PredictionOutput p) => p.Hitchance >= hitChance);
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0000C490 File Offset: 0x0000A690
		public FarmLocation GetLineFarmLocation(List<AIBaseClient> minions, float overrideWidth = -1f)
		{
			List<Vector2> minionsPredictedPositions = FarmPrediction.GetMinionsPredictedPositions(minions, this.Delay, this.Width, this.Speed, this.From, this.Range, false, SpellType.Line, default(Vector3));
			return this.GetLineFarmLocation(minionsPredictedPositions, (overrideWidth >= 0f) ? overrideWidth : this.Width);
		}

		// Token: 0x06000228 RID: 552 RVA: 0x0000C4E8 File Offset: 0x0000A6E8
		public FarmLocation GetLineFarmLocation(HashSet<AIBaseClient> minions, float overrideWidth = -1f)
		{
			List<Vector2> minionsPredictedPositions = FarmPrediction.GetMinionsPredictedPositions(minions, this.Delay, this.Width, this.Speed, this.From, this.Range, false, SpellType.Line, default(Vector3));
			return this.GetLineFarmLocation(minionsPredictedPositions, (overrideWidth >= 0f) ? overrideWidth : this.Width);
		}

		// Token: 0x06000229 RID: 553 RVA: 0x0000C540 File Offset: 0x0000A740
		public FarmLocation GetLineFarmLocation(List<AIMinionClient> minions, float overrideWidth = -1f)
		{
			List<Vector2> minionsPredictedPositions = FarmPrediction.GetMinionsPredictedPositions(minions.Cast<AIBaseClient>().ToList<AIBaseClient>(), this.Delay, this.Width, this.Speed, this.From, this.Range, false, SpellType.Line, default(Vector3));
			return this.GetLineFarmLocation(minionsPredictedPositions, (overrideWidth >= 0f) ? overrideWidth : this.Width);
		}

		// Token: 0x0600022A RID: 554 RVA: 0x0000C5A0 File Offset: 0x0000A7A0
		public FarmLocation GetLineFarmLocation(HashSet<AIMinionClient> minions, float overrideWidth = -1f)
		{
			List<Vector2> minionsPredictedPositions = FarmPrediction.GetMinionsPredictedPositions(minions, this.Delay, this.Width, this.Speed, this.From, this.Range, false, SpellType.Line, default(Vector3));
			return this.GetLineFarmLocation(minionsPredictedPositions, (overrideWidth >= 0f) ? overrideWidth : this.Width);
		}

		// Token: 0x0600022B RID: 555 RVA: 0x0000C5F5 File Offset: 0x0000A7F5
		public FarmLocation GetLineFarmLocation(List<Vector2> minionPositions, float overrideWidth = -1f)
		{
			return FarmPrediction.GetBestLineFarmLocation(minionPositions, (overrideWidth >= 0f) ? overrideWidth : this.Width, this.Range);
		}

		// Token: 0x0600022C RID: 556 RVA: 0x0000C614 File Offset: 0x0000A814
		public PredictionOutput GetPrediction(AIBaseClient target, bool aoe = false, float overrideRange = -1f, CollisionObjects[] collisionable = null)
		{
			PredictionInput predictionInput = new PredictionInput();
			predictionInput.Unit = target;
			predictionInput.Delay = this.Delay;
			predictionInput.Radius = this.Width;
			predictionInput.Speed = this.Speed;
			predictionInput.From = this.From;
			predictionInput.Range = ((overrideRange > 0f) ? overrideRange : this.Range);
			predictionInput.Collision = this.Collision;
			predictionInput.Type = this.Type;
			predictionInput.RangeCheckFrom = this.RangeCheckFrom;
			predictionInput.Aoe = (aoe || (this.Width > 85f && !this.Collision));
			predictionInput.AddHitBox = this.AddHitBox;
			predictionInput.ChoiceCloserPosition = this.PredictionCloserPosition;
			predictionInput.MaxCollisionCount = this.MaxCollisionCount;
			predictionInput.Spell = this;
			PredictionInput predictionInput2 = predictionInput;
			CollisionObjects[] collisionObjects = collisionable;
			if (collisionable == null)
			{
				RuntimeHelpers.InitializeArray(collisionObjects = new CollisionObjects[3], fieldof(<PrivateImplementationDetails>.809EB107E1D93404BCAF0291C3A9C43761D2A6CE).FieldHandle);
			}
			predictionInput2.CollisionObjects = collisionObjects;
			return Prediction.GetPrediction(predictionInput);
		}

		// Token: 0x0600022D RID: 557 RVA: 0x0000C70C File Offset: 0x0000A90C
		public AIHeroClient GetTarget(float extraRange = 0f, IEnumerable<AIHeroClient> champsToIgnore = null)
		{
			if (champsToIgnore == null)
			{
				return TargetSelector.GetTarget(this.Range + extraRange, this.DamageType, true, null, null);
			}
			return TargetSelector.GetTargets(this.Range + extraRange, this.DamageType, true, null, null).FirstOrDefault((AIHeroClient x) => champsToIgnore.All((AIHeroClient i) => !i.Compare(i)));
		}

		// Token: 0x0600022E RID: 558 RVA: 0x0000C77C File Offset: 0x0000A97C
		public bool IsInRange(GameObject obj, float otherRange = -1f)
		{
			AIBaseClient aibaseClient = obj as AIBaseClient;
			return this.IsInRange((aibaseClient != null) ? aibaseClient.ServerPosition.ToVector2() : obj.Position.ToVector2(), otherRange);
		}

		// Token: 0x0600022F RID: 559 RVA: 0x0000C7A6 File Offset: 0x0000A9A6
		public bool IsInRange(Vector2 point, float otherRange = -1f)
		{
			return (double)this.RangeCheckFrom.DistanceSquared(point) < ((otherRange < 0f) ? Math.Pow((double)this.range, 2.0) : ((double)(otherRange * otherRange)));
		}

		// Token: 0x06000230 RID: 560 RVA: 0x0000C7DA File Offset: 0x0000A9DA
		public bool IsInRange(Vector3 point, float otherRange = -1f)
		{
			return this.IsInRange(point.ToVector2(), otherRange);
		}

		// Token: 0x06000231 RID: 561 RVA: 0x0000C7EC File Offset: 0x0000A9EC
		public bool IsReady(int time = 0)
		{
			if (this.Slot == SpellSlot.Unknown)
			{
				return false;
			}
			if (this.Instance != null && this.Instance.Learned)
			{
				if (this.Instance.State == SpellState.Ready)
				{
					return true;
				}
				if (this.Instance.State == SpellState.Cooldown && time > 0 && this.Instance.CooldownExpires - Game.Time <= (float)time / 1000f)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000232 RID: 562 RVA: 0x0000C85C File Offset: 0x0000AA5C
		public void SetCharged(string spellName, string buffName, int minRange, int maxRange, float chargeDurationSeconds)
		{
			this.IsChargedSpell = true;
			this.ChargedSpellName = spellName;
			this.ChargedBuffName = buffName;
			this.ChargedMaxRange = maxRange;
			this.ChargedMinRange = minRange;
			this.ChargeDuration = chargeDurationSeconds * 1000f;
			this.ChargedCastedTime = 0f;
			AIBaseClient.OnDoCast += this.OnChargeDoCast;
			Spellbook.OnCastSpell += this.OnChargeCastSpell;
		}

		// Token: 0x06000233 RID: 563 RVA: 0x0000C8C8 File Offset: 0x0000AAC8
		private void OnChargeDoCast(AIBaseClient sender, AIBaseClientProcessSpellCastEventArgs args)
		{
			if (sender.IsMe && args.SData.Name == this.ChargedSpellName)
			{
				this.ChargedCastedTime = (float)Variables.GameTimeTickCount;
			}
		}

		// Token: 0x06000234 RID: 564 RVA: 0x0000C8F6 File Offset: 0x0000AAF6
		private void OnChargeCastSpell(Spellbook sender, SpellbookCastSpellEventArgs args)
		{
			if (args.Slot == this.Slot && (float)Variables.GameTimeTickCount - this.ChargeRequestSentTime > 500f && this.IsCharging)
			{
				this.Cast((Vector2)args.EndPosition);
			}
		}

		// Token: 0x06000235 RID: 565 RVA: 0x0000C934 File Offset: 0x0000AB34
		public void SetCustomDamage(Spell.CustomDamageDelegate damagefunc, int stage = 0)
		{
			this.GetCustomDamages = damagefunc;
			this.GetCustomDamageStage = stage;
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0000C944 File Offset: 0x0000AB44
		public void SetSkillshot(float delay, float width, float speed, bool collision, SpellType type, HitChance hitchance = HitChance.High, Vector3 fromVector3 = default(Vector3), Vector3 rangeCheckFromVector3 = default(Vector3))
		{
			this.Delay = delay;
			this.Width = width;
			this.Speed = speed;
			this.Type = type;
			this.Collision = collision;
			this.IsSkillShot = true;
			this.MinHitChance = hitchance;
			this.From = fromVector3;
			this.RangeCheckFrom = rangeCheckFromVector3;
		}

		// Token: 0x06000237 RID: 567 RVA: 0x0000C995 File Offset: 0x0000AB95
		public void SetTargetted(float delay, float speed, Vector3 fromVector3 = default(Vector3), Vector3 rangeCheckFromVector3 = default(Vector3))
		{
			this.Delay = delay;
			this.Speed = speed;
			this.From = fromVector3;
			this.RangeCheckFrom = rangeCheckFromVector3;
			this.IsSkillShot = false;
		}

		// Token: 0x06000238 RID: 568 RVA: 0x0000C9BB File Offset: 0x0000ABBB
		public bool ShootChargedSpell(Vector2 position)
		{
			return this.ShootChargedSpell(position.ToVector3(0f));
		}

		// Token: 0x06000239 RID: 569 RVA: 0x0000C9CE File Offset: 0x0000ABCE
		public bool ShootChargedSpell(Vector3 position)
		{
			this.LastCastAttemptTime = (float)Variables.GameTimeTickCount;
			GameObjects.Player.Spellbook.UpdateChargedSpell(this.Slot, position, true);
			return true;
		}

		// Token: 0x0600023A RID: 570 RVA: 0x0000C9F8 File Offset: 0x0000ABF8
		public bool StartCharging()
		{
			if (this.IsCharging || (float)Variables.GameTimeTickCount - this.ChargeRequestSentTime <= (float)(400 + Game.Ping))
			{
				return false;
			}
			this.ChargeRequestSentTime = (float)Variables.GameTimeTickCount;
			this.LastCastAttemptTime = (float)Variables.GameTimeTickCount;
			return GameObjects.Player.Spellbook.CastSpell(this.Slot, Game.CursorPos);
		}

		// Token: 0x0600023B RID: 571 RVA: 0x0000CA5C File Offset: 0x0000AC5C
		public bool StartCharging(Vector2 StartPosition)
		{
			if (this.IsCharging || (float)Variables.GameTimeTickCount - this.ChargeRequestSentTime <= (float)(400 + Game.Ping))
			{
				return false;
			}
			this.ChargeRequestSentTime = (float)Variables.GameTimeTickCount;
			this.LastCastAttemptTime = (float)Variables.GameTimeTickCount;
			return GameObjects.Player.Spellbook.CastSpell(this.Slot, StartPosition.ToVector3(0f));
		}

		// Token: 0x0600023C RID: 572 RVA: 0x0000CAC8 File Offset: 0x0000ACC8
		public bool StartCharging(Vector3 StartPosition)
		{
			if (this.IsCharging || (float)Variables.GameTimeTickCount - this.ChargeRequestSentTime <= (float)(400 + Game.Ping))
			{
				return false;
			}
			this.ChargeRequestSentTime = (float)Variables.GameTimeTickCount;
			this.LastCastAttemptTime = (float)Variables.GameTimeTickCount;
			return GameObjects.Player.Spellbook.CastSpell(this.Slot, StartPosition);
		}

		// Token: 0x0600023D RID: 573 RVA: 0x0000CB28 File Offset: 0x0000AD28
		public void UpdateSourcePosition(Vector3 fromVector3 = default(Vector3), Vector3 rangeCheckFromVector3 = default(Vector3))
		{
			this.from = fromVector3;
			this.RangeCheckFrom = rangeCheckFromVector3;
		}

		// Token: 0x0600023E RID: 574 RVA: 0x0000CB38 File Offset: 0x0000AD38
		public bool WillHit(AIBaseClient unit, Vector3 castPosition, int extraWidth = 0, HitChance minHitChance = HitChance.High)
		{
			PredictionOutput prediction = this.GetPrediction(unit, false, -1f, null);
			return prediction.Hitchance >= minHitChance && this.WillHit(prediction.UnitPosition, castPosition, extraWidth);
		}

		// Token: 0x0600023F RID: 575 RVA: 0x0000CB70 File Offset: 0x0000AD70
		public bool WillHit(Vector3 point, Vector3 castPosition, int extraWidth = 0)
		{
			float num = this.Width + (float)extraWidth;
			if (this.Type == SpellType.Circle)
			{
				if ((double)point.DistanceSquared(castPosition) < Math.Pow((double)num, 2.0))
				{
					return true;
				}
			}
			else if (this.Type == SpellType.Line)
			{
				if ((double)point.ToVector2().DistanceSquared(castPosition.ToVector2(), this.From.ToVector2(), true) < Math.Pow((double)num, 2.0))
				{
					return true;
				}
			}
			else if (this.Type == SpellType.Cone)
			{
				Vector2 vector = (castPosition.ToVector2() - this.From.ToVector2()).Rotated(-num / 2f);
				Vector2 other = vector.Rotated(num);
				Vector2 vector2 = point.ToVector2() - this.From.ToVector2();
				if ((double)point.DistanceSquared(this.From) < Math.Pow((double)this.Range, 2.0) && vector.CrossProduct(vector2) > 0f && vector2.CrossProduct(other) > 0f)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x040000EC RID: 236
		private Vector3 from;

		// Token: 0x040000ED RID: 237
		private Vector3 rangeCheckFrom;

		// Token: 0x040000EE RID: 238
		private float range = float.MaxValue;

		// Token: 0x02000458 RID: 1112
		// (Invoke) Token: 0x06001498 RID: 5272
		public delegate bool CastControlDelegate();

		// Token: 0x02000459 RID: 1113
		// (Invoke) Token: 0x0600149C RID: 5276
		public delegate double CustomDamageDelegate(AIBaseClient target);
	}
}
