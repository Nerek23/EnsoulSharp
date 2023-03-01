using System;
using System.Collections.Generic;
using System.Linq;
using EnsoulSharp.SDK.Utility;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000021 RID: 33
	public class TargetSelector
	{
		// Token: 0x0600017B RID: 379 RVA: 0x00009C0B File Offset: 0x00007E0B
		internal static void Initialize()
		{
			if (TargetSelector._initialize)
			{
				return;
			}
			TargetSelector._initialize = true;
			TargetSelector.Implementations.Add("SDK", new TargetSelectorSDK());
			TargetSelector.Implementation = TargetSelector.Implementations["SDK"];
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00009C43 File Offset: 0x00007E43
		internal static void RemoveSDK()
		{
			if (TargetSelector.Implementations.ContainsKey("SDK"))
			{
				TargetSelector.Implementations.Remove("SDK");
			}
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00009C68 File Offset: 0x00007E68
		public static void AddTargetSelector(string name, ITargetSelector ts)
		{
			if (TargetSelector.Implementations.ContainsKey(name))
			{
				Logging.Write(false, true, "AddTargetSelector")(LogLevel.Error, "Cant not Add " + name + " TargetSelector bcz already have it!", Array.Empty<object>());
				return;
			}
			Logging.Write(false, true, "AddTargetSelector")(LogLevel.Info, "Add " + name + " TargetSelector", Array.Empty<object>());
			TargetSelector.Implementations.Add(name, ts);
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00009CE0 File Offset: 0x00007EE0
		public static void SetTargetSelector(string name)
		{
			if (TargetSelector.Implementations.ContainsKey(name))
			{
				Logging.Write(false, true, "SetTargetSelector")(LogLevel.Info, "Set " + name + " to Default TargetSelector", Array.Empty<object>());
				TargetSelector.Implementation = TargetSelector.Implementations[name];
				return;
			}
			Logging.Write(false, true, "SetTargetSelector")(LogLevel.Error, "Cant not Set " + name + " to Default TargetSelector", Array.Empty<object>());
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00009D59 File Offset: 0x00007F59
		public static ITargetSelector GetTargetSelector(string name)
		{
			if (!TargetSelector.Implementations.ContainsKey(name))
			{
				return null;
			}
			return TargetSelector.Implementations[name];
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000180 RID: 384 RVA: 0x00009D75 File Offset: 0x00007F75
		// (set) Token: 0x06000181 RID: 385 RVA: 0x00009D9D File Offset: 0x00007F9D
		public static AIHeroClient SelectedTarget
		{
			get
			{
				if (TargetSelector.Implementation != null)
				{
					return TargetSelector.Implementation.SelectedTarget;
				}
				return TargetSelector.Implementations.Values.FirstOrDefault<ITargetSelector>().SelectedTarget;
			}
			set
			{
				if (TargetSelector.Implementation == null)
				{
					TargetSelector.Implementations.Values.FirstOrDefault<ITargetSelector>().SelectedTarget = value;
					return;
				}
				TargetSelector.Implementation.SelectedTarget = value;
			}
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00009DC7 File Offset: 0x00007FC7
		public static int GetDefaultPriority(AIHeroClient target)
		{
			ITargetSelector implementation = TargetSelector.Implementation;
			if (implementation == null)
			{
				return TargetSelector.Implementations.Values.FirstOrDefault<ITargetSelector>().GetDefaultPriority(target);
			}
			return implementation.GetDefaultPriority(target);
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00009DEE File Offset: 0x00007FEE
		public static int GetPriority(AIHeroClient target)
		{
			ITargetSelector implementation = TargetSelector.Implementation;
			if (implementation == null)
			{
				return TargetSelector.Implementations.Values.FirstOrDefault<ITargetSelector>().GetPriority(target);
			}
			return implementation.GetPriority(target);
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00009E15 File Offset: 0x00008015
		public static AIHeroClient GetTarget(IEnumerable<AIHeroClient> possibleTargets, DamageType damageType, bool ignoreShields = true, Vector3? checkFrom = null)
		{
			if (TargetSelector.Implementation != null)
			{
				return TargetSelector.Implementation.GetTarget(possibleTargets, damageType, ignoreShields, checkFrom);
			}
			return TargetSelector.Implementations.Values.FirstOrDefault<ITargetSelector>().GetTarget(possibleTargets, damageType, ignoreShields, checkFrom);
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00009E45 File Offset: 0x00008045
		public static AIHeroClient GetTarget(float range, DamageType damageType, bool ignoreShields = true, Vector3? checkFrom = null, IEnumerable<AIHeroClient> ignoreChampions = null)
		{
			if (TargetSelector.Implementation != null)
			{
				return TargetSelector.Implementation.GetTarget(range, damageType, ignoreShields, checkFrom, ignoreChampions);
			}
			return TargetSelector.Implementations.Values.FirstOrDefault<ITargetSelector>().GetTarget(range, damageType, ignoreShields, checkFrom, ignoreChampions);
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00009E79 File Offset: 0x00008079
		public static List<AIHeroClient> GetTargets(float range, DamageType damageType, bool ignoreShields = true, Vector3? checkFrom = null, IEnumerable<AIHeroClient> ignoreChampions = null)
		{
			if (TargetSelector.Implementation != null)
			{
				return TargetSelector.Implementation.GetTargets(range, damageType, ignoreShields, checkFrom, ignoreChampions);
			}
			return TargetSelector.Implementations.Values.FirstOrDefault<ITargetSelector>().GetTargets(range, damageType, ignoreShields, checkFrom, ignoreChampions);
		}

		// Token: 0x040000AE RID: 174
		private static bool _initialize;

		// Token: 0x040000AF RID: 175
		private static ITargetSelector Implementation;

		// Token: 0x040000B0 RID: 176
		private static readonly Dictionary<string, ITargetSelector> Implementations = new Dictionary<string, ITargetSelector>();
	}
}
