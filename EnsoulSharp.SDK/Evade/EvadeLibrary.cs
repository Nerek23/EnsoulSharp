using System;
using System.Collections.Generic;
using EnsoulSharp.SDK.Utility;

namespace EnsoulSharp.SDK.Evade
{
	// Token: 0x020000E0 RID: 224
	public static class EvadeLibrary
	{
		// Token: 0x060008A0 RID: 2208 RVA: 0x00037868 File Offset: 0x00035A68
		public static void AddEvade(string evadeName)
		{
			if (!EvadeLibrary.AllSpells.ContainsKey(evadeName))
			{
				EvadeLibrary.AllSpells.Add(evadeName, new Dictionary<int, ISkillshot>());
			}
			if (!EvadeLibrary.ExistSpells.ContainsKey(evadeName))
			{
				EvadeLibrary.ExistSpells.Add(evadeName, new List<ExistSkillshot>());
			}
			if (!EvadeLibrary.EvadeFunction.ContainsKey(evadeName))
			{
				EvadeLibrary.EvadeFunction.Add(evadeName, null);
			}
		}

		// Token: 0x060008A1 RID: 2209 RVA: 0x000378C8 File Offset: 0x00035AC8
		public static bool IsExist(string evadeName)
		{
			return EvadeLibrary.AllSpells.ContainsKey(evadeName);
		}

		// Token: 0x060008A2 RID: 2210 RVA: 0x000378D8 File Offset: 0x00035AD8
		public static void AddExistSkillshot(string evadeName, ExistSkillshot skillshot)
		{
			if (!EvadeLibrary.ExistSpells.ContainsKey(evadeName))
			{
				EvadeLibrary.ExistSpells.Add(evadeName, new List<ExistSkillshot>());
			}
			if (!EvadeLibrary.ExistSpells[evadeName].Contains(skillshot))
			{
				EvadeLibrary.ExistSpells[evadeName].Add(skillshot);
				return;
			}
			Logging.Write(false, true, "AddExistSkillshot")(LogLevel.Error, string.Concat(new string[]
			{
				"Already Exist Skillshot Cache in [",
				evadeName,
				"]. From: ",
				skillshot.ChampionName,
				" - Spell Name: ",
				skillshot.SpellName
			}), Array.Empty<object>());
		}

		// Token: 0x040005B0 RID: 1456
		public static Dictionary<string, Dictionary<int, ISkillshot>> AllSpells = new Dictionary<string, Dictionary<int, ISkillshot>>();

		// Token: 0x040005B1 RID: 1457
		public static Dictionary<string, List<ExistSkillshot>> ExistSpells = new Dictionary<string, List<ExistSkillshot>>();

		// Token: 0x040005B2 RID: 1458
		public static Dictionary<string, IEvadeManager> EvadeFunction = new Dictionary<string, IEvadeManager>();
	}
}
