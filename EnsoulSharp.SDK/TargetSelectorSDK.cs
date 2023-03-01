using System;
using System.Collections.Generic;
using System.Linq;
using EnsoulSharp.SDK.MenuUI;
using EnsoulSharp.SDK.Rendering;
using EnsoulSharp.SDK.Utility;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x0200004D RID: 77
	internal class TargetSelectorSDK : ITargetSelector, IDisposable
	{
		// Token: 0x06000329 RID: 809 RVA: 0x00017248 File Offset: 0x00015448
		public TargetSelectorSDK()
		{
			if (TargetSelectorSDK._initialize)
			{
				return;
			}
			TargetSelectorSDK._initialize = true;
			TargetSelectorSDK.Menu = new Menu("TargetSelector", "Target Selector", true).Attach();
			TargetSelectorSDK.PriorityMenu = TargetSelectorSDK.Menu.Add<Menu>(new Menu("Priority", "Priority", false));
			foreach (AIHeroClient aiheroClient in from x in GameObjects.EnemyHeroes
			where x != null && x.IsValid
			select x)
			{
				if (TargetSelectorSDK.PriorityMenu["TS_" + aiheroClient.CharacterName] == null)
				{
					int defaultPriority = this.GetDefaultPriority(aiheroClient);
					MenuSlider component = new MenuSlider("TS_" + aiheroClient.CharacterName, aiheroClient.CharacterName, defaultPriority, 1, 5);
					TargetSelectorSDK.PriorityMenu.Add<MenuSlider>(component);
				}
			}
			TargetSelectorSDK.WeightsMenu = TargetSelectorSDK.Menu.Add<Menu>(new Menu("Weights", "Weights", false));
			TargetSelectorSDK.WeightsMenu.Add<MenuSliderButton>(new MenuSliderButton("Closest", "Closest to Player", 1, 0, 100, true));
			TargetSelectorSDK.WeightsMenu.Add<MenuSliderButton>(new MenuSliderButton("NearMouse", "Closest to Mouse", 1, 0, 100, true));
			TargetSelectorSDK.WeightsMenu.Add<MenuSliderButton>(new MenuSliderButton("LeastAttacks", "Least Auto Attacks", 100, 0, 100, true));
			TargetSelectorSDK.WeightsMenu.Add<MenuSliderButton>(new MenuSliderButton("LeastSpells", "Least Spells", 100, 0, 100, true));
			TargetSelectorSDK.WeightsMenu.Add<MenuSliderButton>(new MenuSliderButton("MostPriority", "Most Priority", 100, 0, 100, true));
			TargetSelectorSDK.WeightsMenu.Add<MenuSliderButton>(new MenuSliderButton("MostAD", "Most AD", 100, 0, 100, true));
			TargetSelectorSDK.WeightsMenu.Add<MenuSliderButton>(new MenuSliderButton("MostAP", "Most AP", 100, 0, 100, true));
			TargetSelectorSDK.WeightsMenu.Add<MenuSliderButton>(new MenuSliderButton("MinHealth", "Min Health", 100, 0, 100, true));
			TargetSelectorSDK.DrawingsMenu = TargetSelectorSDK.Menu.Add<Menu>(new Menu("Drawings", "Drawings", false));
			TargetSelectorSDK.DrawingsMenu.Add<MenuColor>(new MenuColor("SelectColor", "^ Draw Color", new ColorBGRA(byte.MaxValue, 0, 0, byte.MaxValue)));
			TargetSelectorSDK.DrawingsMenu.Add<MenuBool>(new MenuBool("DrawSelect", "Draw Selected Target", true));
			TargetSelectorSDK.Menu.Add<MenuBool>(new MenuBool("ForceSelectTarget", "Force on Select Target", true));
			TargetSelectorSDK.Menu.Add<MenuBool>(new MenuBool("OnlySelectTarget", "Only Attack Select Target", false));
			TargetSelectorSDK.Menu.Add<MenuList>(new MenuList("TSMode_" + GameObjects.Player.CharacterName, "TS Mode: ", new string[]
			{
				"Least Attacks",
				"Least Spells",
				"Closest",
				"Near Mouse",
				"Most AD",
				"Most AP",
				"Lowest Health",
				"Most Priority"
			}, 7));
			TargetSelectorSDK.Menu.Add<MenuList>(new MenuList("SearchMode_" + GameObjects.Player.CharacterName, "Search Mode: ", new string[]
			{
				"Simple",
				"Weight"
			}, 0));
			Render.OnDraw += this.OnDraw;
			GameEvent.OnGameWndProc += this.OnWndProc;
		}

		// Token: 0x0600032A RID: 810 RVA: 0x000175D8 File Offset: 0x000157D8
		private Dictionary<TargetSelectorWeight, float> GetEnabledWeights()
		{
			Dictionary<TargetSelectorWeight, float> dictionary = new Dictionary<TargetSelectorWeight, float>();
			foreach (TargetSelectorMode mode in new TargetSelectorMode[]
			{
				TargetSelectorMode.LeastAttacks,
				TargetSelectorMode.LeastSpells,
				TargetSelectorMode.Closest,
				TargetSelectorMode.NearMouse,
				TargetSelectorMode.MostAD,
				TargetSelectorMode.MostAP,
				TargetSelectorMode.LowestHealth,
				TargetSelectorMode.MostPriority
			})
			{
				if (TargetSelectorSDK.WeightsMenu[mode.ToString()] != null && TargetSelectorSDK.WeightsMenu[mode.ToString()].GetValue<MenuSliderButton>().Enabled)
				{
					dictionary.Add(new TargetSelectorWeight(mode, mode.ToString().Contains("Most") ? TargetSelectorWeightEffect.HigherIsBetter : TargetSelectorWeightEffect.LowerIsBetter), (float)TargetSelectorSDK.WeightsMenu[mode.ToString()].GetValue<MenuSliderButton>().Value);
				}
			}
			return dictionary;
		}

		// Token: 0x0600032B RID: 811 RVA: 0x000176A0 File Offset: 0x000158A0
		private Dictionary<AIHeroClient, float> GetTargetsAndWeights(float range, bool autoattack = false, Vector3? from = null, IEnumerable<AIHeroClient> ignoreChampions = null)
		{
			if (ignoreChampions == null)
			{
				ignoreChampions = new List<AIHeroClient>();
			}
			List<AIHeroClient> list = GameObjects.EnemyHeroes.ToList<AIHeroClient>().FindAll(delegate(AIHeroClient x)
			{
				if (!autoattack)
				{
					return this.IsValidTarget(x, range, from) && ignoreChampions.All((AIHeroClient ignored) => ignored != null && ignored.IsValid && !ignored.Compare(x));
				}
				return this.InCurrentAutoAttackRange(x, 0f);
			});
			Dictionary<TargetSelectorWeight, float> enabledWeights = this.GetEnabledWeights();
			Dictionary<AIHeroClient, float> dictionary = new Dictionary<AIHeroClient, float>();
			foreach (AIHeroClient key in list)
			{
				dictionary[key] = 0f;
			}
			foreach (KeyValuePair<TargetSelectorWeight, float> keyValuePair in enabledWeights)
			{
				keyValuePair.Key.ComputeWeight(list, keyValuePair.Value, ref dictionary);
			}
			return dictionary;
		}

		// Token: 0x0600032C RID: 812 RVA: 0x000177AC File Offset: 0x000159AC
		private Dictionary<AIHeroClient, float> GetTargetsAndWeights(List<AIHeroClient> targets)
		{
			Dictionary<TargetSelectorWeight, float> enabledWeights = this.GetEnabledWeights();
			Dictionary<AIHeroClient, float> dictionary = new Dictionary<AIHeroClient, float>();
			foreach (AIHeroClient key in targets)
			{
				dictionary[key] = 0f;
			}
			foreach (KeyValuePair<TargetSelectorWeight, float> keyValuePair in enabledWeights)
			{
				keyValuePair.Key.ComputeWeight(targets, keyValuePair.Value, ref dictionary);
			}
			return dictionary;
		}

		// Token: 0x0600032D RID: 813 RVA: 0x0001785C File Offset: 0x00015A5C
		private IEnumerable<AIHeroClient> GetOrderedTargetsByMode(float range, DamageType damageType, bool ignoreShield, Vector3? from = null, IEnumerable<AIHeroClient> ignoreChampions = null)
		{
			if (ignoreChampions == null)
			{
				ignoreChampions = new List<AIHeroClient>();
			}
			List<AIHeroClient> source = GameObjects.EnemyHeroes.ToList<AIHeroClient>().FindAll((AIHeroClient x) => this.IsValidTarget(x, range, from) && ignoreChampions.All((AIHeroClient ignored) => ignored.NetworkId != x.NetworkId));
			IEnumerable<AIHeroClient> result = null;
			switch (TargetSelectorSDK.Menu["TSMode_" + GameObjects.Player.CharacterName].GetValue<MenuList>().Index)
			{
			case 0:
				result = from hero in source
				orderby GameObjects.Player.CalculatePhysicalDamage(hero, 100.0) / (double)(1f + hero.Health) * (double)this.GetPriorityPercent(hero, damageType, ignoreShield) descending
				select hero;
				break;
			case 1:
				result = from hero in source
				orderby GameObjects.Player.CalculateMagicDamage(hero, 100.0) / (double)(1f + hero.Health) * (double)this.GetPriorityPercent(hero, damageType, ignoreShield) descending
				select hero;
				break;
			case 2:
				result = from x in source
				orderby x.Distance(GameObjects.Player) * this.GetInvulnerablePercent(x, damageType, ignoreShield, true)
				select x;
				break;
			case 3:
				result = from x in source
				orderby x.Distance(Game.CursorPos) * this.GetInvulnerablePercent(x, damageType, ignoreShield, true)
				select x;
				break;
			case 4:
				result = from x in source
				orderby x.TotalAttackDamage * this.GetInvulnerablePercent(x, damageType, ignoreShield, false) descending
				select x;
				break;
			case 5:
				result = from x in source
				orderby x.TotalMagicalDamage * this.GetInvulnerablePercent(x, damageType, ignoreShield, false) descending
				select x;
				break;
			case 6:
				result = from x in source
				orderby x.Health * this.GetInvulnerablePercent(x, damageType, ignoreShield, true)
				select x;
				break;
			case 7:
				result = from hero in source
				orderby GameObjects.Player.CalculateDamage(hero, damageType, 100.0) / (double)(1f + hero.Health) * (double)this.GetPriorityPercent(hero, damageType, ignoreShield) descending
				select hero;
				break;
			}
			return result;
		}

		// Token: 0x0600032E RID: 814 RVA: 0x000179CC File Offset: 0x00015BCC
		private bool IsValidTarget(AIHeroClient hero, float range, Vector3? from = null)
		{
			Vector3 position = (from != null && from.Value.IsValid()) ? from.Value : GameObjects.Player.ServerPosition;
			if (hero != null && hero.IsValidTarget(3.4028235E+38f, true, default(Vector3)))
			{
				if (hero.IsInvulnerableVisual)
				{
					return false;
				}
				if (range > 0f)
				{
					if ((double)hero.DistanceSquared(position) < Math.Pow((double)(range + hero.BoundingRadius), 2.0))
					{
						return true;
					}
				}
				else if (range < 0f && this.InCurrentAutoAttackRange(hero, 0f))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600032F RID: 815 RVA: 0x00017A74 File Offset: 0x00015C74
		private bool InCurrentAutoAttackRange(AIHeroClient target, float extraRange = 0f)
		{
			if (!this.IsValidTarget(target, 3.4028235E+38f, null))
			{
				return false;
			}
			if (GameObjects.Player.CharacterName == "Azir")
			{
				IEnumerable<GameObject> azirSoldiers = GameObjects.AzirSoldiers;
				if (azirSoldiers.Any<GameObject>() && azirSoldiers.Any((GameObject x) => x != null && x.IsValid && !x.IsDead && (double)x.DistanceSquared(GameObjects.Player.ServerPosition) <= Math.Pow(770.0, 2.0) && (double)target.DistanceSquared(x) <= Math.Pow(350.0, 2.0)))
				{
					return true;
				}
			}
			float num = target.GetCurrentAutoAttackRange() + extraRange;
			return (double)Vector2.DistanceSquared(target.ServerPosition.ToVector2(), GameObjects.Player.ServerPosition.ToVector2()) <= Math.Pow((double)num, 2.0);
		}

		// Token: 0x06000330 RID: 816 RVA: 0x00017B30 File Offset: 0x00015D30
		private float GetPriorityPercent(AIHeroClient hero, DamageType damageType, bool ignoreShields = true)
		{
			int num = 1;
			if (TargetSelectorSDK.PriorityMenu["TS_" + hero.CharacterName] != null)
			{
				num = TargetSelectorSDK.PriorityMenu["TS_" + hero.CharacterName].GetValue<MenuSlider>().Value;
			}
			float result = 1f;
			if (num == 2)
			{
				result = 1.5f;
			}
			else if (num == 3)
			{
				result = 1.75f;
			}
			else if (num == 4)
			{
				result = 2f;
			}
			else if (num == 5)
			{
				result = 2.5f;
			}
			if (Invulnerable.Check(hero, damageType, ignoreShields, -1f))
			{
				result = 0.1f;
			}
			return result;
		}

		// Token: 0x06000331 RID: 817 RVA: 0x00017BCC File Offset: 0x00015DCC
		private float GetInvulnerablePercent(AIHeroClient hero, DamageType damageType, bool ignoreShields = true, bool IsOrderBy = true)
		{
			float result = 1f;
			if (Invulnerable.Check(hero, damageType, ignoreShields, -1f))
			{
				result = (IsOrderBy ? 10f : 0.1f);
			}
			return result;
		}

		// Token: 0x06000332 RID: 818 RVA: 0x00017C00 File Offset: 0x00015E00
		private void OnWndProc(GameEvent.WindowndEventArgs args)
		{
			if ((ulong)args.Msg == 513UL)
			{
				Vector3 clickPosition = Game.CursorPos;
				AIHeroClient aiheroClient = (from x in GameObjects.EnemyHeroes
				where x.IsValidTarget(5000f, true, default(Vector3))
				orderby x.Distance(clickPosition)
				select x).FirstOrDefault((AIHeroClient x) => x.Type == GameObjectType.AIHeroClient);
				if (aiheroClient != null && Game.CursorPos.Distance(aiheroClient.ServerPosition) <= 300f)
				{
					this.SelectedTarget = aiheroClient;
					return;
				}
				this.SelectedTarget = null;
			}
		}

		// Token: 0x06000333 RID: 819 RVA: 0x00017CC0 File Offset: 0x00015EC0
		private void OnDraw(EventArgs args)
		{
			if (TargetSelectorSDK.DrawingsMenu == null)
			{
				return;
			}
			if (!TargetSelectorSDK.DrawingsMenu["DrawSelect"].GetValue<MenuBool>().Enabled)
			{
				return;
			}
			if (this.SelectedTarget == null || !this.SelectedTarget.IsValidTarget(3.4028235E+38f, true, default(Vector3)))
			{
				return;
			}
			ColorBGRA color = TargetSelectorSDK.DrawingsMenu["SelectColor"].GetValue<MenuColor>().Color;
			CircleRender.Draw(this.SelectedTarget.Position, this.SelectedTarget.BoundingRadius, color, 5, false);
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000334 RID: 820 RVA: 0x00017D59 File Offset: 0x00015F59
		// (set) Token: 0x06000335 RID: 821 RVA: 0x00017D61 File Offset: 0x00015F61
		public AIHeroClient SelectedTarget { get; set; }

		// Token: 0x06000336 RID: 822 RVA: 0x00017D6C File Offset: 0x00015F6C
		public int GetDefaultPriority(AIHeroClient target)
		{
			if (TargetSelectorSDK.MaxPriority.Any((string x) => string.Equals(target.CharacterName, x, StringComparison.CurrentCultureIgnoreCase)))
			{
				return 5;
			}
			if (TargetSelectorSDK.HighPriority.Any((string x) => string.Equals(target.CharacterName, x, StringComparison.CurrentCultureIgnoreCase)))
			{
				return 4;
			}
			if (TargetSelectorSDK.MediumPriority.Any((string x) => string.Equals(target.CharacterName, x, StringComparison.CurrentCultureIgnoreCase)))
			{
				return 3;
			}
			if (!TargetSelectorSDK.LowPriority.Any((string x) => string.Equals(target.CharacterName, x, StringComparison.CurrentCultureIgnoreCase)))
			{
				return 1;
			}
			return 2;
		}

		// Token: 0x06000337 RID: 823 RVA: 0x00017DF0 File Offset: 0x00015FF0
		public int GetPriority(AIHeroClient target)
		{
			if (!(target != null))
			{
				return 0;
			}
			if (TargetSelectorSDK.PriorityMenu["TS_" + target.CharacterName] == null)
			{
				return this.GetDefaultPriority(target);
			}
			return TargetSelectorSDK.PriorityMenu["TS_" + target.CharacterName].GetValue<MenuSlider>().Value;
		}

		// Token: 0x06000338 RID: 824 RVA: 0x00017E50 File Offset: 0x00016050
		public AIHeroClient GetTarget(IEnumerable<AIHeroClient> possibleTargets, DamageType damageType, bool ignoreShields = true, Vector3? checkFrom = null)
		{
			List<AIHeroClient> list = (from x in possibleTargets
			where this.IsValidTarget(x, float.MaxValue, checkFrom)
			select x).ToList<AIHeroClient>();
			if (this.SelectedTarget != null && this.SelectedTarget.IsValid && !this.SelectedTarget.IsDead)
			{
				if (TargetSelectorSDK.Menu["ForceSelectTarget"].GetValue<MenuBool>().Enabled && possibleTargets.Any((AIHeroClient x) => x.Compare(this.SelectedTarget)) && this.IsValidTarget(this.SelectedTarget, 3.4028235E+38f, checkFrom))
				{
					return this.SelectedTarget;
				}
				if (TargetSelectorSDK.Menu["OnlySelectTarget"].GetValue<MenuBool>().Enabled && this.IsValidTarget(this.SelectedTarget, 3.4028235E+38f, checkFrom))
				{
					return this.SelectedTarget;
				}
			}
			if (TargetSelectorSDK.Menu["SearchMode_" + GameObjects.Player.CharacterName].GetValue<MenuList>().Index == 1)
			{
				Dictionary<AIHeroClient, float> targetWeightDictionary = this.GetTargetsAndWeights(list);
				return (from k in targetWeightDictionary.Keys
				orderby targetWeightDictionary[k] descending
				select k).FirstOrDefault<AIHeroClient>();
			}
			switch (TargetSelectorSDK.Menu["TSMode_" + GameObjects.Player.CharacterName].GetValue<MenuList>().Index)
			{
			case 0:
				return (from x in list
				orderby GameObjects.Player.CalculatePhysicalDamage(x, 100.0) / (double)(1f + x.Health) * (double)this.GetPriorityPercent(x, damageType, ignoreShields) descending
				select x).FirstOrDefault<AIHeroClient>();
			case 1:
				return (from x in list
				orderby GameObjects.Player.CalculateMagicDamage(x, 100.0) / (double)(1f + x.Health) * (double)this.GetPriorityPercent(x, damageType, ignoreShields) descending
				select x).FirstOrDefault<AIHeroClient>();
			case 2:
				return (from x in list
				orderby GameObjects.Player.ServerPosition.DistanceSquared(x.ServerPosition) * this.GetInvulnerablePercent(x, damageType, ignoreShields, true)
				select x).FirstOrDefault<AIHeroClient>();
			case 3:
				return (from x in list
				orderby x.DistanceSquared(Game.CursorPos) * this.GetInvulnerablePercent(x, damageType, ignoreShields, true)
				select x).FirstOrDefault<AIHeroClient>();
			case 4:
				return (from x in list
				orderby x.TotalAttackDamage * this.GetInvulnerablePercent(x, damageType, ignoreShields, false) descending
				select x).FirstOrDefault<AIHeroClient>();
			case 5:
				return (from x in list
				orderby x.TotalMagicalDamage * this.GetInvulnerablePercent(x, damageType, ignoreShields, false) descending
				select x).FirstOrDefault<AIHeroClient>();
			case 6:
				return (from x in list
				orderby x.Health * this.GetInvulnerablePercent(x, damageType, ignoreShields, true)
				select x).FirstOrDefault<AIHeroClient>();
			case 7:
				return (from x in list
				orderby GameObjects.Player.CalculateDamage(x, damageType, 100.0) / (double)(1f + x.Health) * (double)this.GetPriorityPercent(x, damageType, ignoreShields) descending
				select x).FirstOrDefault<AIHeroClient>();
			default:
				return null;
			}
		}

		// Token: 0x06000339 RID: 825 RVA: 0x000180C8 File Offset: 0x000162C8
		public AIHeroClient GetTarget(float range, DamageType damageType, bool ignoreShields = true, Vector3? checkFrom = null, IEnumerable<AIHeroClient> ignoreChampions = null)
		{
			if (ignoreChampions == null)
			{
				ignoreChampions = new List<AIHeroClient>();
			}
			if (this.SelectedTarget != null && this.SelectedTarget.IsValid)
			{
				if (TargetSelectorSDK.Menu["ForceSelectTarget"].GetValue<MenuBool>().Enabled && this.IsValidTarget(this.SelectedTarget, range, checkFrom))
				{
					return this.SelectedTarget;
				}
				if (TargetSelectorSDK.Menu["OnlySelectTarget"].GetValue<MenuBool>().Enabled && this.IsValidTarget(this.SelectedTarget, 3.4028235E+38f, checkFrom))
				{
					return this.SelectedTarget;
				}
			}
			if (TargetSelectorSDK.Menu["SearchMode_" + GameObjects.Player.CharacterName].GetValue<MenuList>().Index == 1)
			{
				Dictionary<AIHeroClient, float> targetWeightDictionary = this.GetTargetsAndWeights(range, false, checkFrom, ignoreChampions);
				return (from k in targetWeightDictionary.Keys
				orderby targetWeightDictionary[k] descending
				select k).FirstOrDefault<AIHeroClient>();
			}
			List<AIHeroClient> source = GameObjects.EnemyHeroes.ToList<AIHeroClient>().FindAll((AIHeroClient x) => this.IsValidTarget(x, range, checkFrom) && ignoreChampions.All((AIHeroClient ignored) => ignored != null && ignored.IsValid && !ignored.Compare(x)));
			switch (TargetSelectorSDK.Menu["TSMode_" + GameObjects.Player.CharacterName].GetValue<MenuList>().Index)
			{
			case 0:
				return (from x in source
				orderby GameObjects.Player.CalculatePhysicalDamage(x, 100.0) / (double)(1f + x.Health) * (double)this.GetPriorityPercent(x, damageType, ignoreShields) descending
				select x).FirstOrDefault<AIHeroClient>();
			case 1:
				return (from x in source
				orderby GameObjects.Player.CalculateMagicDamage(x, 100.0) / (double)(1f + x.Health) * (double)this.GetPriorityPercent(x, damageType, ignoreShields) descending
				select x).FirstOrDefault<AIHeroClient>();
			case 2:
				return (from x in source
				orderby GameObjects.Player.ServerPosition.DistanceSquared(x.ServerPosition) * this.GetInvulnerablePercent(x, damageType, ignoreShields, true)
				select x).FirstOrDefault<AIHeroClient>();
			case 3:
				return (from x in source
				orderby x.DistanceSquared(Game.CursorPos) * this.GetInvulnerablePercent(x, damageType, ignoreShields, true)
				select x).FirstOrDefault<AIHeroClient>();
			case 4:
				return (from x in source
				orderby x.TotalAttackDamage * this.GetInvulnerablePercent(x, damageType, ignoreShields, false) descending
				select x).FirstOrDefault<AIHeroClient>();
			case 5:
				return (from x in source
				orderby x.TotalMagicalDamage * this.GetInvulnerablePercent(x, damageType, ignoreShields, false) descending
				select x).FirstOrDefault<AIHeroClient>();
			case 6:
				return (from x in source
				orderby x.Health * this.GetInvulnerablePercent(x, damageType, ignoreShields, true)
				select x).FirstOrDefault<AIHeroClient>();
			case 7:
				return (from x in source
				orderby GameObjects.Player.CalculateDamage(x, damageType, 100.0) / (double)(1f + x.Health) * (double)this.GetPriorityPercent(x, damageType, ignoreShields) descending
				select x).FirstOrDefault<AIHeroClient>();
			default:
				return null;
			}
		}

		// Token: 0x0600033A RID: 826 RVA: 0x00018354 File Offset: 0x00016554
		public List<AIHeroClient> GetTargets(float range, DamageType damageType, bool ignoreShields = true, Vector3? checkFrom = null, IEnumerable<AIHeroClient> ignoreChampions = null)
		{
			if (ignoreChampions == null)
			{
				ignoreChampions = new List<AIHeroClient>();
			}
			if (TargetSelectorSDK.Menu["OnlySelectTarget"].GetValue<MenuBool>().Enabled && this.SelectedTarget != null && this.SelectedTarget.IsValidTarget(3.4028235E+38f, true, default(Vector3)))
			{
				return new List<AIHeroClient>
				{
					this.SelectedTarget
				};
			}
			List<AIHeroClient> list;
			if (TargetSelectorSDK.Menu["SearchMode_" + GameObjects.Player.CharacterName].GetValue<MenuList>().Index == 1)
			{
				Dictionary<AIHeroClient, float> targetWeightDictionary = this.GetTargetsAndWeights(range, false, checkFrom, ignoreChampions);
				list = (from k in targetWeightDictionary.Keys
				orderby targetWeightDictionary[k] descending
				select k).ToList<AIHeroClient>();
			}
			else
			{
				list = this.GetOrderedTargetsByMode(range, damageType, ignoreShields, checkFrom, ignoreChampions).ToList<AIHeroClient>();
			}
			if (TargetSelectorSDK.Menu["ForceSelectTarget"].GetValue<MenuBool>().Enabled && this.SelectedTarget != null && this.SelectedTarget.IsValidTarget(range, true, default(Vector3)) && list.Any((AIHeroClient x) => x.Compare(this.SelectedTarget)))
			{
				list.RemoveAll((AIHeroClient x) => x.Compare(this.SelectedTarget));
				list.Insert(0, this.SelectedTarget);
			}
			return list;
		}

		// Token: 0x0600033B RID: 827 RVA: 0x000184B8 File Offset: 0x000166B8
		public void Dispose()
		{
			if (!TargetSelectorSDK._initialize)
			{
				return;
			}
			TargetSelectorSDK._initialize = false;
			Logging.Write(false, true, "Dispose")(LogLevel.Info, "SDK TargetSelector Dispose", Array.Empty<object>());
			TargetSelector.RemoveSDK();
			MenuManager.Instance.Remove(TargetSelectorSDK.Menu);
			Render.OnDraw -= this.OnDraw;
			GameEvent.OnGameWndProc -= this.OnWndProc;
		}

		// Token: 0x040001CA RID: 458
		private static readonly string[] MaxPriority = new string[]
		{
			"Ahri",
			"Aphelios",
			"Anivia",
			"Annie",
			"Ashe",
			"Azir",
			"Brand",
			"Caitlyn",
			"Cassiopeia",
			"Corki",
			"Draven",
			"Ezreal",
			"Graves",
			"Jinx",
			"Kalista",
			"Kaisa",
			"Karma",
			"Karthus",
			"Katarina",
			"Kennen",
			"KogMaw",
			"Kindred",
			"Leblanc",
			"Lucian",
			"Lux",
			"Malzahar",
			"MasterYi",
			"MissFortune",
			"Neeko",
			"Orianna",
			"Quinn",
			"Sivir",
			"Sylas",
			"Syndra",
			"Talon",
			"Teemo",
			"Tristana",
			"TwistedFate",
			"Twitch",
			"Varus",
			"Vayne",
			"Veigar",
			"Velkoz",
			"Viktor",
			"Xerath",
			"Zed",
			"Ziggs",
			"Jhin",
			"Soraka",
			"AurelionSol",
			"Taliayh",
			"Qayana",
			"Zoe",
			"Xayah",
			"Taliyah",
			"Samira"
		};

		// Token: 0x040001CB RID: 459
		private static readonly string[] HighPriority = new string[]
		{
			"Akali",
			"Diana",
			"Ekko",
			"FiddleSticks",
			"Fiora",
			"Fizz",
			"Heimerdinger",
			"Jayce",
			"Kassadin",
			"Kayle",
			"KhaZix",
			"Lissandra",
			"Mordekaiser",
			"Nidalee",
			"Riven",
			"Senna",
			"Shaco",
			"Vladimir",
			"Yasuo",
			"Zilean",
			"Camille",
			"Kayn",
			"Yone"
		};

		// Token: 0x040001CC RID: 460
		private static readonly string[] MediumPriority = new string[]
		{
			"Aatrox",
			"Darius",
			"Elise",
			"Evelynn",
			"Galio",
			"Gangplank",
			"Gragas",
			"Irelia",
			"Jax",
			"LeeSin",
			"Maokai",
			"Morgana",
			"Nocturne",
			"Pantheon",
			"Poppy",
			"Pyke",
			"Rengar",
			"Rumble",
			"Ryze",
			"Sett",
			"Swain",
			"Trundle",
			"Tryndamere",
			"Udyr",
			"Urgot",
			"Vi",
			"XinZhao",
			"RekSai",
			"Illaoi",
			"Kled",
			"Lillia"
		};

		// Token: 0x040001CD RID: 461
		private static readonly string[] LowPriority = new string[]
		{
			"Alistar",
			"Amumu",
			"Bard",
			"Blitzcrank",
			"Braum",
			"Chogath",
			"DrMundo",
			"Garen",
			"Gnar",
			"Hecarim",
			"Janna",
			"JarvanIV",
			"Leona",
			"Lulu",
			"Malphite",
			"Nami",
			"Nasus",
			"Nautilus",
			"Nunu",
			"Olaf",
			"Rammus",
			"Renekton",
			"Sejuani",
			"Shen",
			"Shyvana",
			"Singed",
			"Sion",
			"Skarner",
			"Sona",
			"Taric",
			"TahmKench",
			"Thresh",
			"Volibear",
			"Warwick",
			"MonkeyKing",
			"Yorick",
			"Yuumi",
			"Zac",
			"Zyra",
			"Ornn",
			"Rakan",
			"Ivern",
			"Rell"
		};

		// Token: 0x040001CE RID: 462
		private static bool _initialize;

		// Token: 0x040001CF RID: 463
		private static Menu Menu;

		// Token: 0x040001D0 RID: 464
		private static Menu PriorityMenu;

		// Token: 0x040001D1 RID: 465
		private static Menu WeightsMenu;

		// Token: 0x040001D2 RID: 466
		private static Menu DrawingsMenu;
	}
}
