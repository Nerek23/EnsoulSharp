using System;
using EnsoulSharp.SDK.MenuUI;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000012 RID: 18
	public static class StringExtensions
	{
		// Token: 0x06000089 RID: 137 RVA: 0x00006028 File Offset: 0x00004228
		public static int GetRecallTime(this string recallName)
		{
			string a = recallName.ToLower();
			if (a == "recall")
			{
				return 8000;
			}
			if (a == "recallimproved")
			{
				return 7000;
			}
			if (a == "odinrecall")
			{
				return 4500;
			}
			if (a == "odinrecallimproved" || a == "superrecall" || a == "superrecallimproved")
			{
				return 4000;
			}
			return 0;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000060A4 File Offset: 0x000042A4
		public static string KeyToText(this Keys Key)
		{
			uint num = (uint)Key;
			if (num >= 65U && num <= 90U)
			{
				return ((char)num).ToString();
			}
			if (num >= 112U && num <= 123U)
			{
				return "F" + (num - 111U);
			}
			if (num <= 20U)
			{
				if (num == 0U)
				{
					return "None";
				}
				if (num == 9U)
				{
					return "Tab";
				}
				switch (num)
				{
				case 16U:
					return "Shift";
				case 17U:
					return "Ctrl";
				case 20U:
					return "CAPS";
				}
			}
			else
			{
				if (num == 27U)
				{
					return "ESC";
				}
				if (num == 32U)
				{
					return "Space";
				}
				if (num == 45U)
				{
					return "Insert";
				}
			}
			return num.ToString();
		}

		// Token: 0x0600008B RID: 139 RVA: 0x0000615C File Offset: 0x0000435C
		public static string KeyToText(this uint vKey)
		{
			if (vKey >= 65U && vKey <= 90U)
			{
				return ((char)vKey).ToString();
			}
			if (vKey >= 112U && vKey <= 123U)
			{
				return "F" + (vKey - 111U);
			}
			if (vKey <= 20U)
			{
				if (vKey == 0U)
				{
					return "None";
				}
				if (vKey == 9U)
				{
					return "Tab";
				}
				switch (vKey)
				{
				case 16U:
					return "Shift";
				case 17U:
					return "Ctrl";
				case 20U:
					return "CAPS";
				}
			}
			else
			{
				if (vKey == 27U)
				{
					return "ESC";
				}
				if (vKey == 32U)
				{
					return "Space";
				}
				if (vKey == 45U)
				{
					return "Insert";
				}
			}
			return vKey.ToString();
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00006210 File Offset: 0x00004410
		public static bool IsAutoAttack(this string name)
		{
			return Orbwalker.IsAutoAttack(name);
		}
	}
}
