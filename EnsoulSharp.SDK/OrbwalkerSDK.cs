using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using EnsoulSharp.SDK.MenuUI;
using EnsoulSharp.SDK.Rendering;
using EnsoulSharp.SDK.Utility;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000044 RID: 68
	internal class OrbwalkerSDK : IOrbwalker, IDisposable
	{
		// Token: 0x060002D5 RID: 725 RVA: 0x00012118 File Offset: 0x00010318
		private void Initialize()
		{
			if (this._initialize)
			{
				return;
			}
			this._initialize = true;
			this.AttackEnabled = true;
			this.MoveEnabled = true;
			this.Menu = new Menu("Orbwalker", "Orbwalker", true).Attach();
			this.AttackMenu = this.Menu.Add<Menu>(new Menu("Attackable", "Attackable Unit", false));
			this.AttackMenu.Add<MenuBool>(new MenuBool("Barrels", "Barrels", true));
			this.AttackMenu.Add<MenuBool>(new MenuBool("JunglePlant", "Jungle Plant", false));
			this.AttackMenu.Add<MenuBool>(new MenuBool("SpecialMinions", "Pets", true));
			this.AttackMenu.Add<MenuBool>(new MenuBool("Wards", "Wards", true));
			this.PrioritizeMenu = this.Menu.Add<Menu>(new Menu("Prioritize", "Prioritize", false));
			this.PrioritizeMenu.Add<MenuBool>(new MenuBool("FarmOverHarass", "Farm Over Harass", true));
			this.PrioritizeMenu.Add<MenuBool>(new MenuBool("SpecialMinion", "Special Minion", false));
			this.PrioritizeMenu.Add<MenuBool>(new MenuBool("SmallJungle", "Small Jungle", false));
			this.PrioritizeMenu.Add<MenuBool>(new MenuBool("Turret", "Turret", true));
			this.OrbwalkerMenu = this.Menu.Add<Menu>(new Menu("Orbwalker", "Orbwalker", false));
			this.OrbwalkerMenu.Add<MenuSlider>(new MenuSlider("ExtraHold", "Extra Hold Position", 50, 0, 250));
			this.OrbwalkerMenu.Add<MenuBool>(new MenuBool("MoveRandom", "Randomize Movement when too close", false));
			this.OrbwalkerMenu.Add<MenuSlider>(new MenuSlider("WindupDelay", "Windup Delay", 60, 0, 250));
			this.OrbwalkerMenu.Add<MenuBool>(new MenuBool("LimitAttack", "Don't Kite if Attack Speed > 2.5", false));
			this.FarmMenu = this.Menu.Add<Menu>(new Menu("Farm", "Farm", false));
			this.FarmMenu.Add<MenuSlider>(new MenuSlider("FarmDelay", "Farm Delay", 30, 0, 200));
			this.FarmMenu.Add<MenuList>(new MenuList("TurretFarm", "Turret Farm Logic", new string[]
			{
				"Enabled",
				"Off"
			}, 0));
			this.FarmMenu.Add<MenuSlider>(new MenuSlider("TurretFramMaxLevel", "Disable Turret Farm When Player Level >= x", 13, 1, 18));
			this.AdvancedMenu = this.Menu.Add<Menu>(new Menu("Advanced", "Advanced", false));
			this.AdvancedMenu.Add<MenuBool>(new MenuBool("CalcItemDamage", "Calculate Item Damage", false));
			this.AdvancedMenu.Add<MenuBool>(new MenuBool("YasuoWallCheck", "Check Yasuo WindWall", true));
			this.AdvancedMenu.Add<MenuBool>(new MenuBool("MissileCheck", "Use Missile Checks", true));
			this.AdvancedMenu.Add<MenuBool>(new MenuBool("SupportMode_" + GameObjects.Player.CharacterName, "Support Mode", false));
			this.DrawMenu = this.Menu.Add<Menu>(new Menu("Drawing", "Drawing", false));
			this.DrawMenu.Add<MenuBool>(new MenuBool("DrawAttackRange", "Draw Attack Range", true));
			this.DrawMenu.Add<MenuBool>(new MenuBool("DrawHoldPosition", "Draw Hold Position", false));
			this.DrawMenu.Add<MenuBool>(new MenuBool("DrawKillableMinion", "Draw Killable Minion", false));
			this.DrawMenu.Add<MenuBool>(new MenuBool("ShowFakeClick", "Show FakeClick", false));
			this.Menu.Add<MenuKeyBind>(new MenuKeyBind("Combo", "Combo", Keys.Space, KeyBindType.Press, false));
			this.Menu.Add<MenuKeyBind>(new MenuKeyBind("ComboWithMove", "Combo Without Move", Keys.N, KeyBindType.Press, false));
			this.Menu.Add<MenuKeyBind>(new MenuKeyBind("Harass", "Harass", Keys.C, KeyBindType.Press, false));
			this.Menu.Add<MenuKeyBind>(new MenuKeyBind("LaneClear", "LaneClear", Keys.V, KeyBindType.Press, false));
			this.Menu.Add<MenuKeyBind>(new MenuKeyBind("LastHit", "LastHit", Keys.X, KeyBindType.Press, false));
			this.Menu.Add<MenuKeyBind>(new MenuKeyBind("Flee", "Flee", Keys.Z, KeyBindType.Press, false));
			string characterName = GameObjects.Player.CharacterName;
			if (!(characterName == "Aphelios"))
			{
				if (!(characterName == "Graves"))
				{
					if (!(characterName == "Jhin"))
					{
						if (!(characterName == "Kalista"))
						{
							if (!(characterName == "Rengar"))
							{
								if (characterName == "Sett")
								{
									this.isSett = true;
								}
							}
							else
							{
								this.isRengar = true;
							}
						}
						else
						{
							this.isKalista = true;
						}
					}
					else
					{
						this.isJhin = true;
					}
				}
				else
				{
					this.isGraves = true;
				}
			}
			else
			{
				this.isAphelios = true;
			}
			foreach (AIHeroClient aiheroClient in from x in GameObjects.Heroes
			where x != null && x.IsValid
			select x)
			{
				if (aiheroClient.IsEnemy)
				{
					if (aiheroClient.CharacterName == "Jax")
					{
						this.JaxInGame = true;
					}
					if (aiheroClient.CharacterName == "Gangplank")
					{
						this.GangplankInGame = true;
					}
				}
				if (!aiheroClient.IsMe && aiheroClient.CharacterName == "TahmKench")
				{
					this.TahmKenchInGame = true;
				}
			}
			GameEvent.OnGameTick += this.OnUpdate;
			Render.OnDraw += this.OnDraw;
			ThreadPool.SetMinThreads(2, 4);
			new Thread(delegate()
			{
				AIBaseClient.OnDoCast += this.OnDoCast;
				AIBaseClient.OnProcessSpellCast += this.OnProcessSpellCast;
				AIBaseClient.OnPlayAnimation += this.OnPlayAnimation;
				Spellbook.OnStopCast += this.OnStopCast;
				GameObject.OnDelete += this.OnDelete;
			})
			{
				IsBackground = true
			}.Start();
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x00012730 File Offset: 0x00010930
		private float GetAttackCastDelay()
		{
			if (this.isSett && this.nextAttackIsPassive)
			{
				return GameObjects.Player.AttackCastDelay - GameObjects.Player.AttackCastDelay / 8f;
			}
			return GameObjects.Player.AttackCastDelay;
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x00012768 File Offset: 0x00010968
		private float GetProjectileSpeed()
		{
			string characterName = GameObjects.Player.CharacterName;
			uint num = <PrivateImplementationDetails>.ComputeStringHash(characterName);
			if (num <= 2116636923U)
			{
				if (num <= 785412301U)
				{
					if (num != 295451893U)
					{
						if (num != 528224650U)
						{
							if (num != 785412301U)
							{
								goto IL_2FA;
							}
							if (!(characterName == "Neeko"))
							{
								goto IL_2FA;
							}
							if (!GameObjects.Player.HasBuff("neekowpassiveready"))
							{
								return this.GetBasicAttackMissileSpeed();
							}
							return float.MaxValue;
						}
						else
						{
							if (!(characterName == "Jinx"))
							{
								goto IL_2FA;
							}
							if (!GameObjects.Player.HasBuff("JinxQ"))
							{
								return this.GetBasicAttackMissileSpeed();
							}
							return 2000f;
						}
					}
					else if (!(characterName == "Zeri"))
					{
						goto IL_2FA;
					}
				}
				else if (num != 1021974584U)
				{
					if (num != 2063770139U)
					{
						if (num != 2116636923U)
						{
							goto IL_2FA;
						}
						if (!(characterName == "Kayle"))
						{
							goto IL_2FA;
						}
						if (GameObjects.Player.AttackRange >= 530f)
						{
							return 2250f;
						}
						return float.MaxValue;
					}
					else
					{
						if (!(characterName == "Jayce"))
						{
							goto IL_2FA;
						}
						if (string.Equals(GameObjects.Player.Spellbook.GetSpell(SpellSlot.Q).Name, "jayceshockblast", StringComparison.CurrentCultureIgnoreCase))
						{
							return 2000f;
						}
						return float.MaxValue;
					}
				}
				else if (!(characterName == "Velkoz"))
				{
					goto IL_2FA;
				}
			}
			else if (num <= 2978615609U)
			{
				if (num != 2361879110U)
				{
					if (num != 2834820125U)
					{
						if (num != 2978615609U)
						{
							goto IL_2FA;
						}
						if (!(characterName == "Azir"))
						{
							goto IL_2FA;
						}
					}
					else
					{
						if (!(characterName == "Ivern"))
						{
							goto IL_2FA;
						}
						if (!GameObjects.Player.HasBuff("ivernwpassive"))
						{
							return this.GetBasicAttackMissileSpeed();
						}
						return 1600f;
					}
				}
				else
				{
					if (!(characterName == "Viktor"))
					{
						goto IL_2FA;
					}
					if (!GameObjects.Player.HasBuff("ViktorPowerTransferReturn"))
					{
						return this.GetBasicAttackMissileSpeed();
					}
					return float.MaxValue;
				}
			}
			else if (num != 3554680443U)
			{
				if (num != 3798837943U)
				{
					if (num != 4223981326U)
					{
						goto IL_2FA;
					}
					if (!(characterName == "Aphelios"))
					{
						goto IL_2FA;
					}
					float num2 = GameObjects.Player.Spellbook.GetSpell(SpellSlot.Q).TooltipVars[2];
					if (num2 == 1f)
					{
						return 2500f;
					}
					if (num2 == 2f)
					{
						return float.MaxValue;
					}
					if (num2 == 3f)
					{
						return 1500f;
					}
					if (num2 == 4f)
					{
						return 4000f;
					}
					return 1500f;
				}
				else if (!(characterName == "Thresh"))
				{
					goto IL_2FA;
				}
			}
			else
			{
				if (!(characterName == "Poppy"))
				{
					goto IL_2FA;
				}
				if (!GameObjects.Player.HasBuff("poppypassivebuff"))
				{
					return this.GetBasicAttackMissileSpeed();
				}
				return 1600f;
			}
			return float.MaxValue;
			IL_2FA:
			return this.GetBasicAttackMissileSpeed();
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x00012A75 File Offset: 0x00010C75
		private float GetBasicAttackMissileSpeed()
		{
			if (!GameObjects.Player.IsMelee)
			{
				return GameObjects.Player.BasicAttack.MissileSpeed;
			}
			return float.MaxValue;
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x00012A98 File Offset: 0x00010C98
		private bool CanAttackWithWindWall(AttackableUnit target)
		{
			if (!this._initialize)
			{
				return false;
			}
			if (target == null || !target.IsValidTarget(3.4028235E+38f, true, default(Vector3)))
			{
				return false;
			}
			if (this.JaxInGame)
			{
				AIHeroClient aiheroClient = target as AIHeroClient;
				if (aiheroClient != null && aiheroClient.IsValid && !aiheroClient.IsDead && aiheroClient.CharacterName == "Jax" && aiheroClient.HasBuff("JaxCounterStrike"))
				{
					return false;
				}
			}
			if (!this.AdvancedMenu["YasuoWallCheck"].GetValue<MenuBool>().Enabled)
			{
				return true;
			}
			if (this.WindWallBrokenChampions.Any((string x) => string.Equals(GameObjects.Player.CharacterName, x, StringComparison.CurrentCultureIgnoreCase)) && Collisions.HasYasuoWindWallCollision(GameObjects.Player.ServerPosition, target.Position))
			{
				return false;
			}
			if (this.SpecialWindWallChampions.Any((string x) => string.Equals(GameObjects.Player.CharacterName, x, StringComparison.CurrentCultureIgnoreCase)))
			{
				if (GameObjects.Player.CharacterName == "Elise")
				{
					if (string.Equals(GameObjects.Player.Spellbook.GetSpell(SpellSlot.R).Name, "eliser", StringComparison.CurrentCultureIgnoreCase) && Collisions.HasYasuoWindWallCollision(GameObjects.Player.ServerPosition, target.Position))
					{
						return false;
					}
				}
				else if (GameObjects.Player.CharacterName == "Nidalee")
				{
					if (string.Equals(GameObjects.Player.Spellbook.GetSpell(SpellSlot.Q).Name, "javelintoss", StringComparison.CurrentCultureIgnoreCase) && Collisions.HasYasuoWindWallCollision(GameObjects.Player.ServerPosition, target.Position))
					{
						return false;
					}
				}
				else if (GameObjects.Player.CharacterName == "Jayce")
				{
					if (string.Equals(GameObjects.Player.Spellbook.GetSpell(SpellSlot.Q).Name, "jayceshockblast", StringComparison.CurrentCultureIgnoreCase) && Collisions.HasYasuoWindWallCollision(GameObjects.Player.ServerPosition, target.Position))
					{
						return false;
					}
				}
				else if (GameObjects.Player.CharacterName == "Gnar")
				{
					if (string.Equals(GameObjects.Player.Spellbook.GetSpell(SpellSlot.Q).Name, "gnarq", StringComparison.CurrentCultureIgnoreCase) && Collisions.HasYasuoWindWallCollision(GameObjects.Player.ServerPosition, target.Position))
					{
						return false;
					}
				}
				else if (GameObjects.Player.CharacterName == "Azir" && GameObjects.AzirSoldiers.All((EffectEmitter x) => x != null && x.IsValid && x.Distance(target.Position) > 350f))
				{
					if (Collisions.HasYasuoWindWallCollision(GameObjects.Player.ServerPosition, target.Position))
					{
						return false;
					}
				}
				else if (GameObjects.Player.CharacterName == "Neeko" && Collisions.HasYasuoWindWallCollision(GameObjects.Player.ServerPosition, target.Position))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060002DA RID: 730 RVA: 0x00012DC0 File Offset: 0x00010FC0
		private List<AIMinionClient> GetMinions(float range = 0f)
		{
			if (!this._initialize)
			{
				return new List<AIMinionClient>();
			}
			List<AIMinionClient> list = new List<AIMinionClient>();
			list.AddRange(from m in GameObjects.EnemyMinions
			where m.InCurrentAutoAttackRange(range, true) && !this.ignoreMinions.Any((string b) => string.Equals(m.CharacterName, b, StringComparison.CurrentCultureIgnoreCase)) && !m.GetMinionType().HasFlag(MinionTypes.JunglePlant) && m.IsMinion()
			select m);
			list.AddRange(from j in GameObjects.Jungle
			where j.InCurrentAutoAttackRange(range, true) && j.IsJungle() && !j.GetMinionType().HasFlag(MinionTypes.JunglePlant)
			select j);
			return list;
		}

		// Token: 0x060002DB RID: 731 RVA: 0x00012E2C File Offset: 0x0001102C
		private AttackableUnit GetSpecialMinion(OrbwalkerMode mode)
		{
			if (!this._initialize)
			{
				return null;
			}
			if (this.AttackMenu == null)
			{
				return null;
			}
			List<AIMinionClient> list = new List<AIMinionClient>();
			if (this.AttackMenu["SpecialMinions"].GetValue<MenuBool>().Enabled)
			{
				list.AddRange((from s in GameObjects.EnemyMinions
				where s.InCurrentAutoAttackRange(0f, true) && s.IsPet(true)
				select s).ToList<AIMinionClient>());
			}
			if (this.AttackMenu["Wards"].GetValue<MenuBool>().Enabled && mode != OrbwalkerMode.Combo)
			{
				list.AddRange((from w in GameObjects.EnemyWards
				where w.InCurrentAutoAttackRange(0f, true)
				select w).ToList<AIMinionClient>());
			}
			if (this.AttackMenu["JunglePlant"].GetValue<MenuBool>().Enabled && mode != OrbwalkerMode.Combo)
			{
				list.AddRange((from p in GameObjects.JunglePlant
				where p.InCurrentAutoAttackRange(0f, true)
				select p).ToList<AIMinionClient>());
			}
			return list.FirstOrDefault<AIMinionClient>();
		}

		// Token: 0x060002DC RID: 732 RVA: 0x00012F50 File Offset: 0x00011150
		private bool ShouldWait(IEnumerable<AIMinionClient> minions)
		{
			if (!this._initialize)
			{
				return false;
			}
			foreach (AIMinionClient aiminionClient in minions)
			{
				int value = this.FarmMenu["FarmDelay"].GetValue<MenuSlider>().Value;
				float num = (float)Math.Min(50, Game.Ping) + (GameObjects.Player.AttackDelay + this.GetAttackCastDelay()) * 1000f;
				if ((double)HealthPrediction.GetPrediction(aiminionClient, (int)num, value, HealthPredictionType.Simulated) < GameObjects.Player.GetAutoAttackDamage(aiminionClient, true, this.CalcItemDamage))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060002DD RID: 733 RVA: 0x00013004 File Offset: 0x00011204
		private bool CanTurretFarm(List<AIMinionClient> minions)
		{
			if (!this._initialize)
			{
				return false;
			}
			Menu farmMenu = this.FarmMenu;
			if (farmMenu != null && farmMenu["TurretFarm"].GetValue<MenuList>().Index == 1)
			{
				return false;
			}
			if (this.IsSupportMode())
			{
				return false;
			}
			if (GameObjects.Player.Level >= this.FarmMenu["TurretFramMaxLevel"].GetValue<MenuSlider>().Value)
			{
				return false;
			}
			if (minions.Count == 0)
			{
				return false;
			}
			if (minions.Any((AIMinionClient x) => x.HasBuff("exaltedwithbaronnashorminion") && x.IsMinion()))
			{
				return false;
			}
			return !minions.Any((AIMinionClient x) => x.CharacterName.Contains("MinionSuper") && x.IsMinion());
		}

		// Token: 0x060002DE RID: 734 RVA: 0x000130D4 File Offset: 0x000112D4
		private bool IsSupportMode()
		{
			if (!this._initialize)
			{
				return false;
			}
			Menu advancedMenu = this.AdvancedMenu;
			if (((advancedMenu != null) ? advancedMenu["SupportMode_" + GameObjects.Player.CharacterName] : null) == null)
			{
				return false;
			}
			if (!this.AdvancedMenu["SupportMode_" + GameObjects.Player.CharacterName].GetValue<MenuBool>().Enabled)
			{
				return false;
			}
			float realAutoAttackRange = GameObjects.Player.GetRealAutoAttackRange();
			float range = Math.Max(1200f, realAutoAttackRange * 2f);
			if (GameObjects.Player.CountAllyHeroesInRange(range, GameObjects.Player) > 0)
			{
				if (GameObjects.Player.HasBuff("talentreaperstacksone") || GameObjects.Player.HasBuff("talentreaperstackstwo") || GameObjects.Player.HasBuff("talentreaperstacksthree") || GameObjects.Player.HasBuff("talentreaperstacksfour"))
				{
					return false;
				}
			}
			else if (GameObjects.Player.CountAllyHeroesInRange(2000f, GameObjects.Player) == 0)
			{
				return false;
			}
			return true;
		}

		// Token: 0x060002DF RID: 735 RVA: 0x000131D4 File Offset: 0x000113D4
		private void OnOrbwalkerProcessSpellCastDelayed(AIBaseClientProcessSpellCastEventArgs args)
		{
			if (this.IsAutoAttackReset(args.SData.Name))
			{
				this.ResetAutoAttackTimer();
			}
			if (this.IsAutoAttack(args.SData.Name))
			{
				Orbwalker.FireAfterAttack(args.Target as AttackableUnit, "SDK");
				this.MissileLaunched = true;
			}
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x0001322C File Offset: 0x0001142C
		private void OnDoCast(AIBaseClient sender, AIBaseClientProcessSpellCastEventArgs args)
		{
			if (!this._initialize)
			{
				return;
			}
			if (!sender.IsMe)
			{
				return;
			}
			string name = args.SData.Name;
			if (this.IsAutoAttackReset(name) && args.CastTime == 0f)
			{
				this.ResetAutoAttackTimer();
			}
			if (!this.IsAutoAttack(name))
			{
				return;
			}
			AttackableUnit attackableUnit = args.Target as AttackableUnit;
			if (attackableUnit != null && attackableUnit.IsValid)
			{
				this.LastAutoAttackTick = Variables.GameTimeTickCount - Game.Ping / 2;
				this.MissileLaunched = false;
				this.LastMovementTick = 0;
				this.AutoAttackCounter++;
				if (!attackableUnit.Compare(this.LastTarget))
				{
					this.LastTarget = attackableUnit;
				}
				Orbwalker.FireOnAttack(attackableUnit, "SDK");
			}
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x000132EC File Offset: 0x000114EC
		private void OnProcessSpellCast(AIBaseClient sender, AIBaseClientProcessSpellCastEventArgs args)
		{
			if (!this._initialize)
			{
				return;
			}
			if (!sender.IsMe)
			{
				return;
			}
			if (this.isSett && args.Slot == SpellSlot.Q)
			{
				this.nextAttackIsPassive = false;
			}
			if (Game.Ping <= 30)
			{
				DelayAction.Add(30 - Game.Ping, delegate
				{
					this.OnOrbwalkerProcessSpellCastDelayed(args);
				});
				return;
			}
			this.OnOrbwalkerProcessSpellCastDelayed(args);
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x0001336C File Offset: 0x0001156C
		private void OnPlayAnimation(AIBaseClient sender, AIBaseClientPlayAnimationEventArgs args)
		{
			if (!this._initialize)
			{
				return;
			}
			if (!sender.IsMe)
			{
				return;
			}
			if (this.isRengar && args.Animation == "Spell5")
			{
				int num = 0;
				if (this.LastTarget != null && this.LastTarget.IsValid && this.LastTarget.Position.IsValid())
				{
					num += (int)Math.Min(GameObjects.Player.Distance(this.LastTarget) / 1.5f, 0.6f);
				}
				this.LastAutoAttackTick = Variables.GameTimeTickCount - Game.Ping / 2 + num;
			}
			if (this.isSett)
			{
				if (args.Animation.Contains("Attack"))
				{
					if (args.Animation.Contains("Passive"))
					{
						this.Info = new OrbwalkerSDK.SettAttackInfo(true, Variables.GameTimeTickCount);
						this.nextAttackIsPassive = false;
						return;
					}
					this.Info = new OrbwalkerSDK.SettAttackInfo(false, Variables.GameTimeTickCount);
					this.nextAttackIsPassive = true;
					return;
				}
				else
				{
					if (args.Animation == "Spell1_A")
					{
						this.Info = new OrbwalkerSDK.SettAttackInfo(false, Variables.GameTimeTickCount);
						this.nextAttackIsPassive = true;
						return;
					}
					if (args.Animation == "Spell1_B")
					{
						this.Info = new OrbwalkerSDK.SettAttackInfo(true, Variables.GameTimeTickCount);
						this.nextAttackIsPassive = false;
					}
				}
			}
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x000134C4 File Offset: 0x000116C4
		private void OnStopCast(Spellbook sender, SpellbookStopCastEventArgs args)
		{
			if (!this._initialize)
			{
				return;
			}
			if (((sender != null) ? sender.Owner : null) != null && sender.Owner.IsMe && args.DestroyMissile && args.KeepAnimationPlaying)
			{
				this.ResetAutoAttackTimer();
			}
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x00013514 File Offset: 0x00011714
		private void OnDelete(GameObject sender, EventArgs args)
		{
			if (!this._initialize)
			{
				return;
			}
			if (sender == null || !sender.IsValid)
			{
				return;
			}
			if (this.ForceTarget != null && sender.Compare(this.ForceTarget))
			{
				this.ForceTarget = null;
			}
			if (this.LaneClearMinion != null && sender.Compare(this.LaneClearMinion))
			{
				this.LaneClearMinion = null;
			}
			if (this.LastTarget != null && sender.Compare(this.LastTarget))
			{
				this.LastTarget = null;
			}
			if (this.isAphelios && sender.Type == GameObjectType.MissileClient)
			{
				MissileClient missileClient = sender as MissileClient;
				if (((missileClient != null) ? missileClient.SData : null) != null && missileClient.SpellCaster != null && missileClient.SpellCaster.IsMe && missileClient.Name == "ApheliosCrescendumAttackMisIn")
				{
					this.ResetAutoAttackTimer();
				}
			}
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x00013600 File Offset: 0x00011800
		private void OnUpdate(EventArgs args)
		{
			if (!this._initialize)
			{
				return;
			}
			if (this.isSett && this.nextAttackIsPassive && this.Info.AttackTime > 0 && Variables.GameTimeTickCount - this.Info.AttackTime > 2000)
			{
				this.nextAttackIsPassive = false;
			}
			this.CalcItemDamage = this.AdvancedMenu["CalcItemDamage"].GetValue<MenuBool>().Enabled;
			if (GameObjects.Player == null || !GameObjects.Player.IsValid || GameObjects.Player.IsDead)
			{
				return;
			}
			if (MenuGUI.IsChatOpen || MenuGUI.IsShopOpen)
			{
				return;
			}
			if (this.ActiveMode == OrbwalkerMode.None)
			{
				return;
			}
			AttackableUnit target = this.GetTarget();
			this.Orbwalk(target, this._orbwalkerPosition);
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x000136C8 File Offset: 0x000118C8
		private void OnDraw(EventArgs args)
		{
			if (!this._initialize)
			{
				return;
			}
			if (GameObjects.Player == null || GameObjects.Player.IsDead)
			{
				return;
			}
			if (MenuGUI.IsChatOpen || MenuGUI.IsShopOpen)
			{
				return;
			}
			if (GameObjects.Player.Position.IsValid())
			{
				if (this.DrawMenu["DrawAttackRange"].GetValue<MenuBool>().Enabled && GameObjects.Player.Position.IsOnScreen(GameObjects.Player.GetRealAutoAttackRange()))
				{
					CircleRender.Draw(GameObjects.Player.Position, GameObjects.Player.GetRealAutoAttackRange(), Color.DeepSkyBlue, 3, false);
				}
				if (this.DrawMenu["DrawHoldPosition"].GetValue<MenuBool>().Enabled && GameObjects.Player.Position.IsOnScreen(0f))
				{
					CircleRender.Draw(GameObjects.Player.Position, GameObjects.Player.BoundingRadius + (float)this.OrbwalkerMenu["ExtraHold"].GetValue<MenuSlider>().Value, Color.Purple, 3, false);
				}
			}
			if (this.DrawMenu["DrawKillableMinion"].GetValue<MenuBool>().Enabled)
			{
				foreach (AIMinionClient aiminionClient in from x in GameObjects.EnemyMinions
				where x.IsValidTarget(GameObjects.Player.GetRealAutoAttackRange() * 2f, true, default(Vector3)) && x.IsMinion() && x.Position.IsOnScreen(0f) && (double)x.Health < GameObjects.Player.GetAutoAttackDamage(x, true, this.CalcItemDamage)
				select x)
				{
					CircleRender.Draw(aiminionClient.Position, aiminionClient.BoundingRadius * 2f, new Color(0, 255, 0, 255), 3, false);
				}
			}
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x00013870 File Offset: 0x00011A70
		public OrbwalkerSDK()
		{
			this.Initialize();
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060002E8 RID: 744 RVA: 0x00013F11 File Offset: 0x00012111
		// (set) Token: 0x060002E9 RID: 745 RVA: 0x00013F19 File Offset: 0x00012119
		public AttackableUnit ForceTarget { get; set; }

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060002EA RID: 746 RVA: 0x00013F22 File Offset: 0x00012122
		// (set) Token: 0x060002EB RID: 747 RVA: 0x00013F2A File Offset: 0x0001212A
		public AttackableUnit LastTarget { get; set; }

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060002EC RID: 748 RVA: 0x00013F33 File Offset: 0x00012133
		// (set) Token: 0x060002ED RID: 749 RVA: 0x00013F3B File Offset: 0x0001213B
		public int LastAutoAttackTick { get; set; }

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060002EE RID: 750 RVA: 0x00013F44 File Offset: 0x00012144
		// (set) Token: 0x060002EF RID: 751 RVA: 0x00013F4C File Offset: 0x0001214C
		public int LastMovementTick { get; set; }

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060002F0 RID: 752 RVA: 0x00013F58 File Offset: 0x00012158
		// (set) Token: 0x060002F1 RID: 753 RVA: 0x00014032 File Offset: 0x00012232
		public OrbwalkerMode ActiveMode
		{
			get
			{
				if (!this._initialize)
				{
					return OrbwalkerMode.None;
				}
				if (this._activeMode != OrbwalkerMode.None)
				{
					return this._activeMode;
				}
				if (this.Menu["Combo"].GetValue<MenuKeyBind>().Active || this.Menu["ComboWithMove"].GetValue<MenuKeyBind>().Active)
				{
					return OrbwalkerMode.Combo;
				}
				if (this.Menu["Harass"].GetValue<MenuKeyBind>().Active)
				{
					return OrbwalkerMode.Harass;
				}
				if (this.Menu["LaneClear"].GetValue<MenuKeyBind>().Active)
				{
					return OrbwalkerMode.LaneClear;
				}
				if (this.Menu["LastHit"].GetValue<MenuKeyBind>().Active)
				{
					return OrbwalkerMode.LastHit;
				}
				if (!this.Menu["Flee"].GetValue<MenuKeyBind>().Active)
				{
					return OrbwalkerMode.None;
				}
				return OrbwalkerMode.Flee;
			}
			set
			{
				this._activeMode = value;
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060002F2 RID: 754 RVA: 0x0001403B File Offset: 0x0001223B
		// (set) Token: 0x060002F3 RID: 755 RVA: 0x00014043 File Offset: 0x00012243
		public bool AttackEnabled { get; set; }

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060002F4 RID: 756 RVA: 0x0001404C File Offset: 0x0001224C
		// (set) Token: 0x060002F5 RID: 757 RVA: 0x00014054 File Offset: 0x00012254
		public bool MoveEnabled { get; set; }

		// Token: 0x060002F6 RID: 758 RVA: 0x00014060 File Offset: 0x00012260
		public bool IsAutoAttack(string name)
		{
			return (name.IndexOf("attack", StringComparison.CurrentCultureIgnoreCase) >= 0 && !this.NoAttacks.Any((string x) => string.Equals(name, x, StringComparison.CurrentCultureIgnoreCase))) || this.Attacks.Any((string x) => string.Equals(name, x, StringComparison.CurrentCultureIgnoreCase));
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x000140C0 File Offset: 0x000122C0
		public bool IsAutoAttackReset(string name)
		{
			return this.AttackResets.Any((string x) => string.Equals(name, x, StringComparison.CurrentCultureIgnoreCase));
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x000140F1 File Offset: 0x000122F1
		public void ResetAutoAttackTimer()
		{
			this.AllPauseTick = 0;
			this.AttackPauseTick = 0;
			this.LastAutoAttackTick = 0;
			this.MovePauseTick = 0;
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x0001410F File Offset: 0x0001230F
		public void SetOrbwalkerPosition(Vector3 position)
		{
			this._orbwalkerPosition = position;
		}

		// Token: 0x060002FA RID: 762 RVA: 0x00014118 File Offset: 0x00012318
		public void SetPauseTime(int time)
		{
			this.AllPauseTick = Variables.GameTimeTickCount + time;
		}

		// Token: 0x060002FB RID: 763 RVA: 0x00014127 File Offset: 0x00012327
		public void SetServerPauseTime()
		{
			this.AllPauseTick = Variables.GameTimeTickCount + Game.Ping + 1;
		}

		// Token: 0x060002FC RID: 764 RVA: 0x0001413C File Offset: 0x0001233C
		public void SetAttackPauseTime(int time)
		{
			this.AttackPauseTick = Variables.GameTimeTickCount + time;
		}

		// Token: 0x060002FD RID: 765 RVA: 0x0001414B File Offset: 0x0001234B
		public void SetAttackServerPauseTime()
		{
			this.AttackPauseTick = Variables.GameTimeTickCount + Game.Ping + 1;
		}

		// Token: 0x060002FE RID: 766 RVA: 0x00014160 File Offset: 0x00012360
		public void SetMovePauseTime(int time)
		{
			this.MovePauseTick = Variables.GameTimeTickCount + time;
		}

		// Token: 0x060002FF RID: 767 RVA: 0x0001416F File Offset: 0x0001236F
		public void SetMoveServerPauseTime()
		{
			this.MovePauseTick = Variables.GameTimeTickCount + Game.Ping + 1;
		}

		// Token: 0x06000300 RID: 768 RVA: 0x00014184 File Offset: 0x00012384
		public AttackableUnit GetTarget()
		{
			if (!this._initialize)
			{
				return null;
			}
			OrbwalkerMode activeMode = this.ActiveMode;
			if (activeMode == OrbwalkerMode.None || activeMode == OrbwalkerMode.Flee)
			{
				return null;
			}
			AttackableUnit attackableUnit = null;
			List<AIMinionClient> minions = this.GetMinions(200f);
			if ((activeMode == OrbwalkerMode.Harass || (activeMode == OrbwalkerMode.LaneClear && !GameObjects.Player.IsUnderEnemyTurret(0f))) && !this.PrioritizeMenu["FarmOverHarass"].GetValue<MenuBool>().Enabled)
			{
				AIHeroClient target = TargetSelector.GetTarget(from x in GameObjects.EnemyHeroes
				where x.InCurrentAutoAttackRange(0f, true)
				select x, DamageType.Physical, true, null);
				if (target != null && target.InCurrentAutoAttackRange(0f, true))
				{
					return target;
				}
			}
			if (this.AttackMenu["Barrels"].GetValue<MenuBool>().Enabled && this.GangplankInGame)
			{
				foreach (AIMinionClient aiminionClient in (from j in GameObjects.Jungle
				where j.InCurrentAutoAttackRange(0f, true) && string.Equals(j.CharacterName, "gangplankbarrel", StringComparison.CurrentCultureIgnoreCase)
				select j).ToList<AIMinionClient>())
				{
					if (aiminionClient.InCurrentAutoAttackRange(0f, true) && aiminionClient.Health > 0f)
					{
						AIHeroClient aiheroClient = aiminionClient.Owner as AIHeroClient;
						if (aiheroClient != null && aiheroClient.IsValid && aiheroClient.Level > 0)
						{
							if (aiminionClient.Health <= 1f)
							{
								return aiminionClient;
							}
							if (aiminionClient.HasBuff("gangplankebarrelactive") && aiminionClient.Health <= 2f)
							{
								BuffInstance buff = aiminionClient.GetBuff("gangplankebarrelactive");
								float num = GameObjects.Player.ServerPosition.Distance(aiminionClient.ServerPosition) - GameObjects.Player.BoundingRadius;
								float num2 = Math.Max(1f, 1000f * Math.Max(0f, num / this.GetProjectileSpeed()));
								float num3 = this.GetAttackCastDelay() * 1000f + (float)Game.Ping / 2f + num2;
								double num4 = (aiheroClient.Level >= 13) ? 0.5 : ((double)((aiheroClient.Level >= 7) ? 1 : 2));
								double num5 = (double)buff.StartTime + num4 * 2.0;
								if ((double)buff.StartTime + num4 > (double)Game.Time)
								{
									num5 = (double)buff.StartTime + num4;
								}
								if (num5 < (double)(Game.Time + num3 / 1000f))
								{
									return aiminionClient;
								}
							}
						}
					}
				}
			}
			if (activeMode != OrbwalkerMode.Combo && !this.IsSupportMode())
			{
				foreach (AIMinionClient aiminionClient2 in (from m in minions
				where m.InCurrentAutoAttackRange(0f, true) && !m.IsJungle()
				orderby m.CharacterName.Contains("Siege") descending, m.CharacterName.Contains("Super")
				select m).ThenBy((AIMinionClient x) => Math.Ceiling((double)(x.Health / GameObjects.Player.TotalAttackDamage))).ThenByDescending((AIMinionClient m) => m.MaxHealth).ToList<AIMinionClient>())
				{
					if (aiminionClient2.MaxHealth <= 10f)
					{
						if (aiminionClient2.Health <= 1f)
						{
							return aiminionClient2;
						}
					}
					else
					{
						float projectileSpeed = this.GetProjectileSpeed();
						float num6 = this.GetAttackCastDelay() * 1000f - 100f + (float)Game.Ping / 2f + 1000f * Math.Max(0f, GameObjects.Player.Distance(aiminionClient2) - GameObjects.Player.BoundingRadius) / projectileSpeed;
						float prediction = HealthPrediction.GetPrediction(aiminionClient2, (int)num6, this.FarmMenu["FarmDelay"].GetValue<MenuSlider>().Value, HealthPredictionType.Default);
						if (prediction <= 0f)
						{
							Orbwalker.FireNonKillableMinion(aiminionClient2, "SDK");
						}
						double autoAttackDamage = GameObjects.Player.GetAutoAttackDamage(aiminionClient2, true, this.CalcItemDamage);
						if ((double)prediction <= autoAttackDamage)
						{
							return aiminionClient2;
						}
					}
				}
			}
			if (this.ForceTarget != null && this.ForceTarget.IsValidTarget(3.4028235E+38f, true, default(Vector3)) && this.ForceTarget.InCurrentAutoAttackRange(0f, true))
			{
				return this.ForceTarget;
			}
			if (activeMode != OrbwalkerMode.Combo && (!minions.Any<AIMinionClient>() || this.PrioritizeMenu["Turret"].GetValue<MenuBool>().Enabled))
			{
				using (IEnumerator<AITurretClient> enumerator2 = (from t in GameObjects.EnemyTurrets
				where t.IsValidTarget(float.MaxValue, true, default(Vector3)) && t.InCurrentAutoAttackRange(0f, true)
				select t).GetEnumerator())
				{
					if (enumerator2.MoveNext())
					{
						return enumerator2.Current;
					}
				}
				using (IEnumerator<BarracksDampenerClient> enumerator3 = (from i in GameObjects.EnemyInhibitors
				where i.IsValidTarget(float.MaxValue, true, default(Vector3)) && i.InCurrentAutoAttackRange(0f, true)
				select i).GetEnumerator())
				{
					if (enumerator3.MoveNext())
					{
						return enumerator3.Current;
					}
				}
				if (GameObjects.EnemyNexus != null && GameObjects.EnemyNexus.IsValidTarget(3.4028235E+38f, true, default(Vector3)) && GameObjects.EnemyNexus.InCurrentAutoAttackRange(0f, true))
				{
					return GameObjects.EnemyNexus;
				}
			}
			if (activeMode != OrbwalkerMode.LastHit && (activeMode != OrbwalkerMode.LaneClear || !this.ShouldWait(minions)))
			{
				AIHeroClient target2 = TargetSelector.GetTarget(from x in GameObjects.EnemyHeroes
				where x.InCurrentAutoAttackRange(0f, true)
				select x, DamageType.Physical, true, null);
				if (target2 != null && target2.InCurrentAutoAttackRange(0f, true))
				{
					return target2;
				}
			}
			if (this.PrioritizeMenu["SpecialMinion"].GetValue<MenuBool>().Enabled && activeMode != OrbwalkerMode.Combo && !this.ShouldWait(minions))
			{
				AttackableUnit specialMinion = this.GetSpecialMinion(activeMode);
				if (specialMinion != null && specialMinion.InCurrentAutoAttackRange(0f, true))
				{
					return specialMinion;
				}
			}
			if (activeMode == OrbwalkerMode.Harass || activeMode == OrbwalkerMode.LaneClear || activeMode == OrbwalkerMode.LastHit)
			{
				IEnumerable<AIMinionClient> source = from j in minions
				where j.Team == GameObjectTeam.Neutral && j.InCurrentAutoAttackRange(0f, true)
				select j;
				AttackableUnit attackableUnit2;
				if (!this.PrioritizeMenu["SmallJungle"].GetValue<MenuBool>().Enabled)
				{
					attackableUnit2 = (from m in source
					orderby m.MaxHealth descending
					select m).FirstOrDefault<AIMinionClient>();
				}
				else
				{
					attackableUnit2 = (from m in source
					orderby m.MaxHealth
					select m).FirstOrDefault<AIMinionClient>();
				}
				attackableUnit = attackableUnit2;
				if (attackableUnit != null && attackableUnit.InCurrentAutoAttackRange(0f, true))
				{
					return attackableUnit;
				}
			}
			if (activeMode != OrbwalkerMode.Combo && this.FarmMenu["TurretFarm"].GetValue<MenuList>().Index == 0)
			{
				AITurretClient closestTower = (from t in GameObjects.AllyTurrets
				where t.IsValidTarget(1500f, false, default(Vector3))
				select t into x
				orderby x.DistanceToPlayer()
				select x).FirstOrDefault<AITurretClient>();
				if (closestTower != null && closestTower.IsValidTarget(1500f, false, default(Vector3)) && this.CanTurretFarm(minions))
				{
					List<AIMinionClient> source2 = (from x in minions
					where (double)x.DistanceSquared(closestTower) < Math.Pow(900.0, 2.0)
					orderby x.Distance(closestTower)
					select x).ToList<AIMinionClient>();
					if (source2.Any<AIMinionClient>())
					{
						AIMinionClient aiminionClient3 = source2.FirstOrDefault(new Func<AIMinionClient, bool>(HealthPrediction.HasTurretAggro));
						if (aiminionClient3 != null)
						{
							float projectileSpeed2 = this.GetProjectileSpeed();
							double autoAttackDamage2 = closestTower.GetAutoAttackDamage(aiminionClient3, true, false);
							float num7 = closestTower.AttackCastDelay * 1000f + 1000f * Math.Max(0f, aiminionClient3.Distance(closestTower) - closestTower.BoundingRadius) / (closestTower.BasicAttack.MissileSpeed + 70f);
							float num8 = this.GetAttackCastDelay() * 1000f - 100f + (float)Game.Ping / 2f + 1000f * Math.Max(0f, GameObjects.Player.Distance(aiminionClient3) - GameObjects.Player.BoundingRadius) / projectileSpeed2;
							if ((double)HealthPrediction.GetPrediction(aiminionClient3, (int)(num7 + num8), 70, HealthPredictionType.Simulated) > autoAttackDamage2)
							{
								foreach (AIMinionClient aiminionClient4 in from x in source2
								where x.IsValidTarget(float.MaxValue, true, default(Vector3)) && !HealthPrediction.HasTurretAggro(x)
								select x)
								{
									double autoAttackDamage3 = GameObjects.Player.GetAutoAttackDamage(aiminionClient4, true, this.CalcItemDamage);
									double autoAttackDamage4 = closestTower.GetAutoAttackDamage(aiminionClient4, true, false);
									if (!HealthPrediction.HasMinionAggro(aiminionClient4))
									{
										float num9 = this.GetAttackCastDelay() * 1000f - 100f + (float)Game.Ping / 2f + 1000f * Math.Max(0f, GameObjects.Player.Distance(aiminionClient4) - GameObjects.Player.BoundingRadius) / projectileSpeed2;
										float prediction2 = HealthPrediction.GetPrediction(aiminionClient4, (int)(num9 + num7), 70, HealthPredictionType.Simulated);
										if ((double)prediction2 < autoAttackDamage4 * 2.0 || (double)prediction2 > autoAttackDamage4 * 2.0 + autoAttackDamage3)
										{
											if ((double)prediction2 > autoAttackDamage4 + autoAttackDamage3 && (double)prediction2 <= autoAttackDamage4 + autoAttackDamage3 * 2.0)
											{
												return aiminionClient4;
											}
											if ((double)prediction2 > autoAttackDamage4 * 2.0 + autoAttackDamage3 * 2.0)
											{
												return aiminionClient4;
											}
										}
									}
								}
							}
							return null;
						}
						AIMinionClient aiminionClient5 = source2.FirstOrDefault<AIMinionClient>();
						if (aiminionClient5 != null)
						{
							double autoAttackDamage5 = closestTower.GetAutoAttackDamage(aiminionClient5, true, false);
							double num10 = (double)HealthPrediction.GetPrediction(aiminionClient5, 1500, 70, HealthPredictionType.Simulated) - autoAttackDamage5 * 1.100000023841858;
							if (num10 > GameObjects.Player.GetAutoAttackDamage(aiminionClient5, true, this.CalcItemDamage) && num10 < autoAttackDamage5 * 1.100000023841858)
							{
								return aiminionClient5;
							}
							if (num10 > autoAttackDamage5 * 2.0 + GameObjects.Player.GetAutoAttackDamage(aiminionClient5, true, this.CalcItemDamage) * 2.0)
							{
								return aiminionClient5;
							}
						}
						return null;
					}
				}
			}
			if (activeMode == OrbwalkerMode.LaneClear && !this.ShouldWait(minions))
			{
				if (this.LaneClearMinion != null && this.LaneClearMinion.IsValid && this.LaneClearMinion.IsValidTarget(3.4028235E+38f, true, default(Vector3)) && this.LaneClearMinion.InCurrentAutoAttackRange(0f, true))
				{
					if (this.LaneClearMinion.MaxHealth <= 10f)
					{
						return this.LaneClearMinion;
					}
					float prediction3 = HealthPrediction.GetPrediction(this.LaneClearMinion, (int)(GameObjects.Player.AttackDelay * 2000f), this.FarmMenu["FarmDelay"].GetValue<MenuSlider>().Value, HealthPredictionType.Simulated);
					if ((double)prediction3 >= 2.0 * GameObjects.Player.GetAutoAttackDamage(this.LaneClearMinion, true, this.CalcItemDamage) || Math.Abs(prediction3 - this.LaneClearMinion.Health) < 1E-45f)
					{
						return this.LaneClearMinion;
					}
				}
				attackableUnit = (from m in minions
				where m.InCurrentAutoAttackRange(0f, true) && !m.IsJungle()
				select m into minion
				let predHealth = HealthPrediction.GetPrediction(minion, (int)(GameObjects.Player.AttackDelay * 2000f), this.FarmMenu["FarmDelay"].GetValue<MenuSlider>().Value, HealthPredictionType.Simulated)
				where (double)predHealth >= 2.0 * GameObjects.Player.GetAutoAttackDamage(minion, true, this.CalcItemDamage) || Math.Abs(predHealth - minion.Health) < float.Epsilon
				select minion into m
				orderby m.Health descending
				select m).FirstOrDefault<AIMinionClient>();
				if (attackableUnit != null && attackableUnit.InCurrentAutoAttackRange(0f, true))
				{
					this.LaneClearMinion = (AIMinionClient)attackableUnit;
					return attackableUnit;
				}
			}
			if (!this.ShouldWait(minions) && activeMode != OrbwalkerMode.Combo)
			{
				AttackableUnit specialMinion2 = this.GetSpecialMinion(activeMode);
				if (specialMinion2 != null && specialMinion2.InCurrentAutoAttackRange(0f, true))
				{
					return specialMinion2;
				}
			}
			return attackableUnit;
		}

		// Token: 0x06000301 RID: 769 RVA: 0x00014F60 File Offset: 0x00013160
		public bool CanAttack()
		{
			return this._initialize && this.CanAttack(0f);
		}

		// Token: 0x06000302 RID: 770 RVA: 0x00014F78 File Offset: 0x00013178
		public bool CanAttack(float extraWindup)
		{
			if (!this._initialize)
			{
				return false;
			}
			if (this.AllPauseTick > 0 && this.AllPauseTick - Variables.GameTimeTickCount > 0)
			{
				return false;
			}
			if (this.AttackPauseTick > 0 && this.AttackPauseTick - Variables.GameTimeTickCount > 0)
			{
				return false;
			}
			if (!ObjectManager.Player.CanAttack)
			{
				return false;
			}
			if (this.TahmKenchInGame && GameObjects.Player.HasBuff("tahmkenchwhasdevouredtarget"))
			{
				return false;
			}
			if (GameObjects.Player.HasBuffOfType(BuffType.Fear))
			{
				return false;
			}
			if (GameObjects.Player.HasBuffOfType(BuffType.Polymorph) || GameObjects.Player.HasBuff("Polymorph"))
			{
				return false;
			}
			if (!this.isKalista && GameObjects.Player.HasBuffOfType(BuffType.Blind))
			{
				return false;
			}
			if (this.isRengar && (GameObjects.Player.HasBuff("RengarQ") || GameObjects.Player.HasBuff("RengarQEmp")))
			{
				return true;
			}
			if (this.isAphelios && GameObjects.Player.HasBuff("apheliospreload"))
			{
				return false;
			}
			if (this.isJhin && GameObjects.Player.HasBuff("JhinPassiveReload"))
			{
				return false;
			}
			float num = GameObjects.Player.AttackDelay * 1000f;
			if (this.isGraves)
			{
				if (!GameObjects.Player.HasBuff("gravesbasicattackammo1"))
				{
					return false;
				}
				num = GameObjects.Player.AttackDelay * 1000f * 1.0740297f - 716.2381f;
			}
			else if (this.isSett && this.nextAttackIsPassive)
			{
				num = GameObjects.Player.AttackDelay * 1000f / 8f;
			}
			return (float)Variables.GameTimeTickCount + (float)Game.Ping / 2f + 25f >= (float)this.LastAutoAttackTick + num + extraWindup;
		}

		// Token: 0x06000303 RID: 771 RVA: 0x00015132 File Offset: 0x00013332
		public bool CanMove()
		{
			return this._initialize && this.CanMove(0f, false);
		}

		// Token: 0x06000304 RID: 772 RVA: 0x0001514C File Offset: 0x0001334C
		public bool CanMove(float extraWindup, bool disableMissileCheck)
		{
			if (!this._initialize)
			{
				return false;
			}
			if (this.AllPauseTick > 0 && this.AllPauseTick - Variables.GameTimeTickCount > 0)
			{
				return false;
			}
			if (this.MovePauseTick > 0 && this.MovePauseTick - Variables.GameTimeTickCount > 0)
			{
				return false;
			}
			if (!ObjectManager.Player.CanMove)
			{
				return false;
			}
			if (this.TahmKenchInGame && GameObjects.Player.HasBuff("tahmkenchwhasdevouredtarget"))
			{
				return false;
			}
			if (this.isKalista)
			{
				return true;
			}
			if (this.MissileLaunched && !disableMissileCheck && this.AdvancedMenu["MissileCheck"].GetValue<MenuBool>().Enabled)
			{
				return true;
			}
			int num = 0;
			if (this.isRengar && (GameObjects.Player.HasBuff("RengarQ") || GameObjects.Player.HasBuff("RengarQEmp")))
			{
				num = 200;
			}
			return (float)Variables.GameTimeTickCount + (float)Game.Ping / 2f >= (float)this.LastAutoAttackTick + this.GetAttackCastDelay() * 1000f + extraWindup + (float)num;
		}

		// Token: 0x06000305 RID: 773 RVA: 0x00015258 File Offset: 0x00013458
		public bool Attack(AttackableUnit target)
		{
			if (!this._initialize)
			{
				return false;
			}
			if (ObjectManager.Player.Spellbook.IsWindingUp)
			{
				return false;
			}
			if (target == null || !target.InCurrentAutoAttackRange(0f, true))
			{
				return false;
			}
			if (!this.CanAttackWithWindWall(target))
			{
				return false;
			}
			if (Orbwalker.FireBeforeAttack(target, "SDK").Process)
			{
				if (this.isKalista)
				{
					this.MissileLaunched = false;
				}
				if (GameObjects.Player.IssueOrder(GameObjectOrder.AttackUnit, target))
				{
					this.LastLocalAttackTick = Variables.GameTimeTickCount;
					this.LastTarget = target;
				}
				return true;
			}
			return false;
		}

		// Token: 0x06000306 RID: 774 RVA: 0x000152EC File Offset: 0x000134EC
		public void Move(Vector3 position)
		{
			if (!this._initialize)
			{
				return;
			}
			Vector3 vector = position;
			if (!vector.IsValid())
			{
				return;
			}
			float num = Math.Max(30f, (float)this.OrbwalkerMenu["ExtraHold"].GetValue<MenuSlider>().Value);
			if ((double)vector.DistanceSquared(GameObjects.Player.ServerPosition) < Math.Pow((double)num, 2.0))
			{
				if (GameObjects.Player.Path.Length != 0)
				{
					this.LastMovementTick = Variables.GameTimeTickCount - 70;
				}
				return;
			}
			if (this.OrbwalkerMenu["MoveRandom"].GetValue<MenuBool>().Enabled && (double)GameObjects.Player.Position.DistanceSquared(vector) < Math.Pow(150.0, 2.0))
			{
				vector = GameObjects.Player.ServerPosition.Extend(position, (this.random.NextFloat(0.6f, 1f) + 0.2f) * 400f);
			}
			float num2 = 0f;
			List<Vector2> waypoints = GameObjects.Player.GetWaypoints();
			if (waypoints.Count > 1 && waypoints.PathLength() > 100f)
			{
				Vector3[] path = GameObjects.Player.GetPath(vector);
				if (path.Length > 1)
				{
					Vector2 vector2 = waypoints[1] - waypoints[0];
					Vector3 toVector = path[1] - path[0];
					num2 = vector2.AngleBetween(toVector);
					float num3 = path.LastOrDefault<Vector3>().DistanceSquared(waypoints.LastOrDefault<Vector2>());
					if ((num2 < 10f && (double)num3 < Math.Pow(500.0, 2.0)) || (double)num3 < Math.Pow(50.0, 2.0))
					{
						return;
					}
				}
			}
			if (Variables.GameTimeTickCount - this.LastMovementTick < 70 + Math.Min(60, Game.Ping) && num2 < 60f)
			{
				return;
			}
			if (num2 >= 60f && Variables.GameTimeTickCount - this.LastMovementTick < 60)
			{
				return;
			}
			BeforeMoveEventArgs beforeMoveEventArgs = Orbwalker.FirePreMove(vector, "SDK");
			if (beforeMoveEventArgs.Process && GameObjects.Player.IssueOrder(GameObjectOrder.MoveTo, beforeMoveEventArgs.MovePosition))
			{
				this.LastMovementTick = Variables.GameTimeTickCount;
				if (this.DrawMenu["ShowFakeClick"].GetValue<MenuBool>().Enabled && (float)(Variables.GameTimeTickCount - this.LastFakeClickTick) > 250f - (float)Game.Ping * 10f)
				{
					Hud.ShowClick(ClickType.Move, beforeMoveEventArgs.MovePosition);
					this.LastFakeClickTick = Variables.GameTimeTickCount;
				}
			}
		}

		// Token: 0x06000307 RID: 775 RVA: 0x00015580 File Offset: 0x00013780
		public void Orbwalk(AttackableUnit target, Vector3 position)
		{
			if (!this._initialize)
			{
				return;
			}
			if ((float)(Variables.GameTimeTickCount - this.LastLocalAttackTick) < this.GetAttackCastDelay() * 1000f - (float)Game.Ping / 4f)
			{
				return;
			}
			if (this.AttackEnabled && this.CanAttack() && this.Attack(target))
			{
				return;
			}
			if (this.MoveEnabled && this.CanMove((float)this.OrbwalkerMenu["WindupDelay"].GetValue<MenuSlider>().Value, false))
			{
				if (this.Menu["ComboWithMove"].GetValue<MenuKeyBind>().Active)
				{
					return;
				}
				if (this.OrbwalkerMenu["LimitAttack"].GetValue<MenuBool>().Enabled && GameObjects.Player.AttackDelay < 0.3846154f && this.AutoAttackCounter % 3 != 0 && !this.CanMove(500f, true))
				{
					return;
				}
				Vector3 position2 = position.IsValid() ? position : Game.CursorPos;
				this.Move(position2);
			}
		}

		// Token: 0x06000308 RID: 776 RVA: 0x00015684 File Offset: 0x00013884
		public void Dispose()
		{
			if (!this._initialize)
			{
				return;
			}
			this._initialize = false;
			Logging.Write(false, true, "Dispose")(LogLevel.Info, "SDK Orbwalker Dispose", Array.Empty<object>());
			Orbwalker.RemoveSDK();
			MenuManager.Instance.Remove(this.Menu);
			AIBaseClient.OnDoCast -= this.OnDoCast;
			AIBaseClient.OnProcessSpellCast -= this.OnProcessSpellCast;
			AIBaseClient.OnPlayAnimation -= this.OnPlayAnimation;
			Spellbook.OnStopCast -= this.OnStopCast;
			GameObject.OnDelete -= this.OnDelete;
			GameEvent.OnGameTick -= this.OnUpdate;
			Render.OnDraw -= this.OnDraw;
		}

		// Token: 0x0400017A RID: 378
		private readonly string[] AttackResets = new string[]
		{
			"asheq",
			"camilleq2",
			"camilleq",
			"dariusnoxiantacticsonh",
			"elisespiderw",
			"fiorae",
			"gravesmove",
			"garenq",
			"gangplankqwrapper",
			"illaoiw",
			"jaycehypercharge",
			"jaxempowertwo",
			"kaylee",
			"luciane",
			"leonashieldofdaybreakattack",
			"leonashieldofdaybreak",
			"mordekaisermaceofspades",
			"monkeykingdoubleattack",
			"meditate",
			"masochism",
			"netherblade",
			"nautiluspiercinggaze",
			"nasusq",
			"powerfist",
			"rengarqemp",
			"rengarq",
			"renektonpreexecute",
			"reksaiq",
			"settq",
			"sivirw",
			"shyvanadoubleattack",
			"sejuaninorthernwinds",
			"trundletrollsmash",
			"talonnoxiandiplomacy",
			"takedown",
			"vorpalspikes",
			"volibearq",
			"vie",
			"vaynetumble",
			"xinzhaoq",
			"xinzhaocombotarget",
			"yorickspectral",
			"apheliosinfernumq",
			"gravesautoattackrecoilcastedummy"
		};

		// Token: 0x0400017B RID: 379
		private readonly string[] Attacks = new string[]
		{
			"caitlynpassivemissile",
			"itemtitanichydracleave",
			"itemtiamatcleave",
			"kennenmegaproc",
			"masteryidoublestrike",
			"quinnwenhanced",
			"renektonsuperexecute",
			"renektonexecute",
			"trundleq",
			"viktorqbuff",
			"xinzhaoqthrust1",
			"xinzhaoqthrust2",
			"xinzhaoqthrust3"
		};

		// Token: 0x0400017C RID: 380
		private readonly string[] NoAttacks = new string[]
		{
			"asheqattacknoonhit",
			"annietibbersbasicattack",
			"annietibbersbasicattack2",
			"bluecardattack",
			"dravenattackp_r",
			"dravenattackp_rc",
			"dravenattackp_rq",
			"dravenattackp_l",
			"dravenattackp_lc",
			"dravenattackp_lq",
			"elisespiderlingbasicattack",
			"gravesbasicattackspread",
			"gravesautoattackrecoil",
			"goldcardattack",
			"heimertyellowbasicattack",
			"heimertyellowbasicattack2",
			"heimertbluebasicattack",
			"heimerdingerwattack2",
			"heimerdingerwattack2ult",
			"ivernminionbasicattack2",
			"ivernminionbasicattack",
			"kindredwolfbasicattack",
			"monkeykingdoubleattack",
			"malzaharvoidlingbasicattack",
			"malzaharvoidlingbasicattack2",
			"malzaharvoidlingbasicattack3",
			"redcardattack",
			"shyvanadoubleattackdragon",
			"shyvanadoubleattack",
			"talonqdashattack",
			"talonqattack",
			"volleyattackwithsound",
			"volleyattack",
			"yorickghoulmeleebasicattack",
			"yorickghoulmeleebasicattack2",
			"yorickghoulmeleebasicattack3",
			"yorickbigghoulbasicattack",
			"zyraeplantattack",
			"zoebasicattackspecial1",
			"zoebasicattackspecial2",
			"zoebasicattackspecial3",
			"zoebasicattackspecial4",
			"apheliosseverumattackmis",
			"aphelioscrescendumattackmisin",
			"aphelioscrescendumattackmisout",
			"gravesautoattackrecoilcastedummy",
			"gravesautoattackrecoil",
			"gravesbasicattackspread"
		};

		// Token: 0x0400017D RID: 381
		private readonly string[] WindWallBrokenChampions = new string[]
		{
			"annie",
			"twistedfate",
			"leblanc",
			"urgot",
			"vladimir",
			"fiddlesticks",
			"ryze",
			"sivir",
			"soraka",
			"teemo",
			"tristana",
			"missfortune",
			"ashe",
			"morgana",
			"zilean",
			"twitch",
			"karthus",
			"anivia",
			"sona",
			"janna",
			"corki",
			"karma",
			"veigar",
			"swain",
			"caitlyn",
			"orianna",
			"brand",
			"vayne",
			"cassiopeia",
			"heimerdinger",
			"ezreal",
			"kennen",
			"kogmaw",
			"lux",
			"xerath",
			"ahri",
			"graves",
			"varus",
			"viktor",
			"lulu",
			"ziggs",
			"draven",
			"quinn",
			"syndra",
			"aurelionsol",
			"zoe",
			"zyra",
			"kaisa",
			"taliyah",
			"jhin",
			"kindred",
			"jinx",
			"lucian",
			"yuumi",
			"thresh",
			"kalista",
			"xayah",
			"aphelios",
			"bard",
			"ivern",
			"nami",
			"velkoz",
			"lissandra",
			"malzahar"
		};

		// Token: 0x0400017E RID: 382
		private readonly string[] SpecialWindWallChampions = new string[]
		{
			"kayle",
			"elise",
			"nidalee",
			"jayce",
			"gnar",
			"azir",
			"neeko"
		};

		// Token: 0x0400017F RID: 383
		private readonly string[] ignoreMinions = new string[]
		{
			"jarvanivstandard"
		};

		// Token: 0x04000180 RID: 384
		private int LastLocalAttackTick;

		// Token: 0x04000181 RID: 385
		private int AutoAttackCounter;

		// Token: 0x04000182 RID: 386
		private int AttackPauseTick;

		// Token: 0x04000183 RID: 387
		private int MovePauseTick;

		// Token: 0x04000184 RID: 388
		private int AllPauseTick;

		// Token: 0x04000185 RID: 389
		private int LastFakeClickTick;

		// Token: 0x04000186 RID: 390
		private bool _initialize;

		// Token: 0x04000187 RID: 391
		private bool isAphelios;

		// Token: 0x04000188 RID: 392
		private bool isGraves;

		// Token: 0x04000189 RID: 393
		private bool isJhin;

		// Token: 0x0400018A RID: 394
		private bool isKalista;

		// Token: 0x0400018B RID: 395
		private bool isRengar;

		// Token: 0x0400018C RID: 396
		private bool isSett;

		// Token: 0x0400018D RID: 397
		private bool MissileLaunched;

		// Token: 0x0400018E RID: 398
		private bool nextAttackIsPassive;

		// Token: 0x0400018F RID: 399
		private bool JaxInGame;

		// Token: 0x04000190 RID: 400
		private bool GangplankInGame;

		// Token: 0x04000191 RID: 401
		private bool TahmKenchInGame;

		// Token: 0x04000192 RID: 402
		private bool CalcItemDamage;

		// Token: 0x04000193 RID: 403
		private Menu Menu;

		// Token: 0x04000194 RID: 404
		private Menu AttackMenu;

		// Token: 0x04000195 RID: 405
		private Menu PrioritizeMenu;

		// Token: 0x04000196 RID: 406
		private Menu OrbwalkerMenu;

		// Token: 0x04000197 RID: 407
		private Menu FarmMenu;

		// Token: 0x04000198 RID: 408
		private Menu AdvancedMenu;

		// Token: 0x04000199 RID: 409
		private Menu DrawMenu;

		// Token: 0x0400019A RID: 410
		private Vector3 _orbwalkerPosition = Vector3.Zero;

		// Token: 0x0400019B RID: 411
		private AIBaseClient LaneClearMinion;

		// Token: 0x0400019C RID: 412
		private OrbwalkerMode _activeMode = OrbwalkerMode.None;

		// Token: 0x0400019D RID: 413
		private OrbwalkerSDK.SettAttackInfo Info = new OrbwalkerSDK.SettAttackInfo(true, 0);

		// Token: 0x0400019E RID: 414
		private readonly Random random = new Random(Variables.GameTimeTickCount);

		// Token: 0x02000491 RID: 1169
		internal class SettAttackInfo
		{
			// Token: 0x0600158E RID: 5518 RVA: 0x0004D0AA File Offset: 0x0004B2AA
			public SettAttackInfo(bool isLeft, int time)
			{
				this.IsLeftPunch = isLeft;
				this.AttackTime = time;
			}

			// Token: 0x04000BDD RID: 3037
			public int AttackTime;

			// Token: 0x04000BDE RID: 3038
			public bool IsLeftPunch;
		}
	}
}
