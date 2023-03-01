using System;
using System.Runtime.InteropServices;
using EnsoulSharp.Native;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each spell data.
	/// </summary>
	// Token: 0x02000075 RID: 117
	public class SpellData
	{
		// Token: 0x06000489 RID: 1161 RVA: 0x0000F308 File Offset: 0x0000E708
		internal unsafe SpellData(SpellData* sdata)
		{
			this.m_sdata = sdata;
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x0000F324 File Offset: 0x0000E724
		internal unsafe SpellData* GetPtr()
		{
			return this.m_sdata;
		}

		/// <summary>
		/// 	Gets the name of the spell.
		/// </summary>
		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x0600048B RID: 1163 RVA: 0x0000F338 File Offset: 0x0000E738
		public unsafe string Name
		{
			get
			{
				StlString* ptr = <Module>.EnsoulSharp.Native.SpellData.GetName(this.GetPtr());
				return new string((*(ptr + 16) + 1 <= 16) ? ptr : (*ptr));
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether can move while the spell is channeling.
		/// </summary>
		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x0600048C RID: 1164 RVA: 0x0000F368 File Offset: 0x0000E768
		public unsafe bool CanMoveWhileChanneling
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				SpellDataResource* ptr = *<Module>.EnsoulSharp.Native.SpellData.GetDataResource(this.GetPtr());
				return ptr != null && *<Module>.EnsoulSharp.Native.SpellDataResource.GetCanMoveWhileChanneling(ptr) != 0;
			}
		}

		/// <summary>
		/// 	Gets a value indiacating whether the spell is toggle type.
		/// </summary>
		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x0600048D RID: 1165 RVA: 0x0000F390 File Offset: 0x0000E790
		public unsafe bool IsToggleSpell
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				SpellDataResource* ptr = *<Module>.EnsoulSharp.Native.SpellData.GetDataResource(this.GetPtr());
				return ptr != null && *<Module>.EnsoulSharp.Native.SpellDataResource.GetIsToggleSpell(ptr) != 0;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the spell use charge channeling.
		/// </summary>
		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x0600048E RID: 1166 RVA: 0x0000F3B8 File Offset: 0x0000E7B8
		public unsafe bool UseChargeChanneling
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				SpellDataResource* ptr = *<Module>.EnsoulSharp.Native.SpellData.GetDataResource(this.GetPtr());
				return ptr != null && *<Module>.EnsoulSharp.Native.SpellDataResource.GetUseChargeChanneling(ptr) != 0;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the spell can use minimap targeting.
		/// </summary>
		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x0600048F RID: 1167 RVA: 0x0000F3E0 File Offset: 0x0000E7E0
		public unsafe bool UseMinimapTargeting
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				SpellDataResource* ptr = *<Module>.EnsoulSharp.Native.SpellData.GetDataResource(this.GetPtr());
				return ptr != null && *<Module>.EnsoulSharp.Native.SpellDataResource.GetUseMinimapTargeting(ptr) != 0;
			}
		}

		/// <summary>
		/// 	Gets the cooldown time of the spell.
		/// </summary>
		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06000490 RID: 1168 RVA: 0x0000F408 File Offset: 0x0000E808
		public unsafe float CooldownTime
		{
			get
			{
				SpellDataResource* ptr = *<Module>.EnsoulSharp.Native.SpellData.GetDataResource(this.GetPtr());
				if (ptr != null)
				{
					return *<Module>.EnsoulSharp.Native.SpellDataResource.GetCooldownTime(ptr);
				}
				return 0f;
			}
		}

		/// <summary>
		/// 	Gets the cast range of the spell.
		/// </summary>
		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06000491 RID: 1169 RVA: 0x0000F434 File Offset: 0x0000E834
		public unsafe float CastRange
		{
			get
			{
				SpellDataResource* ptr = *<Module>.EnsoulSharp.Native.SpellData.GetDataResource(this.GetPtr());
				if (ptr != null)
				{
					return *<Module>.EnsoulSharp.Native.SpellDataResource.GetCastRange(ptr);
				}
				return 0f;
			}
		}

		/// <summary>
		/// 	Gets the dislay override cast range of the spell.
		/// </summary>
		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x06000492 RID: 1170 RVA: 0x0000F460 File Offset: 0x0000E860
		public unsafe float CastRangeDisplayOverride
		{
			get
			{
				SpellDataResource* ptr = *<Module>.EnsoulSharp.Native.SpellData.GetDataResource(this.GetPtr());
				if (ptr != null)
				{
					return *<Module>.EnsoulSharp.Native.SpellDataResource.GetCastRangeDisplayOverride(ptr);
				}
				return 0f;
			}
		}

		/// <summary>
		/// 	Gets the cast radius of the spell.
		/// </summary>
		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x06000493 RID: 1171 RVA: 0x0000F48C File Offset: 0x0000E88C
		public unsafe float CastRadius
		{
			get
			{
				SpellDataResource* ptr = *<Module>.EnsoulSharp.Native.SpellData.GetDataResource(this.GetPtr());
				if (ptr != null)
				{
					return *<Module>.EnsoulSharp.Native.SpellDataResource.GetCastRadius(ptr);
				}
				return 0f;
			}
		}

		/// <summary>
		/// 	Gets the secondary cast radius of the spell.
		/// </summary>
		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x06000494 RID: 1172 RVA: 0x0000F4B8 File Offset: 0x0000E8B8
		public unsafe float CastRadiusSecondary
		{
			get
			{
				SpellDataResource* ptr = *<Module>.EnsoulSharp.Native.SpellData.GetDataResource(this.GetPtr());
				if (ptr != null)
				{
					return *<Module>.EnsoulSharp.Native.SpellDataResource.GetCastRadiusSecondary(ptr);
				}
				return 0f;
			}
		}

		/// <summary>
		/// 	Gets the cast cone angle of the spell.
		/// </summary>
		// Token: 0x170000EF RID: 239
		// (get) Token: 0x06000495 RID: 1173 RVA: 0x0000F4E4 File Offset: 0x0000E8E4
		public unsafe float CastConeAngle
		{
			get
			{
				SpellDataResource* ptr = *<Module>.EnsoulSharp.Native.SpellData.GetDataResource(this.GetPtr());
				if (ptr != null)
				{
					return *<Module>.EnsoulSharp.Native.SpellDataResource.GetCastConeAngle(ptr);
				}
				return 0f;
			}
		}

		/// <summary>
		/// 	Gets the cast cone distance of the spell.
		/// </summary>
		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06000496 RID: 1174 RVA: 0x0000F510 File Offset: 0x0000E910
		public unsafe float CastConeDistance
		{
			get
			{
				SpellDataResource* ptr = *<Module>.EnsoulSharp.Native.SpellData.GetDataResource(this.GetPtr());
				if (ptr != null)
				{
					return *<Module>.EnsoulSharp.Native.SpellDataResource.GetCastConeDistance(ptr);
				}
				return 0f;
			}
		}

		/// <summary>
		/// 	Gets the cast frame of the spell.
		/// </summary>
		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06000497 RID: 1175 RVA: 0x0000F53C File Offset: 0x0000E93C
		public unsafe float CastFrame
		{
			get
			{
				SpellDataResource* ptr = *<Module>.EnsoulSharp.Native.SpellData.GetDataResource(this.GetPtr());
				if (ptr != null)
				{
					return *<Module>.EnsoulSharp.Native.SpellDataResource.GetCastFrame(ptr);
				}
				return 0f;
			}
		}

		/// <summary>
		/// 	Gets the cast type of the spell.
		/// </summary>
		// Token: 0x170000EC RID: 236
		// (get) Token: 0x06000498 RID: 1176 RVA: 0x0000F568 File Offset: 0x0000E968
		public unsafe SpellDataCastType CastType
		{
			get
			{
				SpellDataResource* ptr = *<Module>.EnsoulSharp.Native.SpellData.GetDataResource(this.GetPtr());
				if (ptr != null)
				{
					return (SpellDataCastType)(*<Module>.EnsoulSharp.Native.SpellDataResource.GetCastType(ptr));
				}
				return SpellDataCastType.Unknown;
			}
		}

		/// <summary>
		/// 	Gets the missile speed of the spell.
		/// </summary>
		// Token: 0x170000EB RID: 235
		// (get) Token: 0x06000499 RID: 1177 RVA: 0x0000F590 File Offset: 0x0000E990
		public unsafe float MissileSpeed
		{
			get
			{
				SpellDataResource* ptr = *<Module>.EnsoulSharp.Native.SpellData.GetDataResource(this.GetPtr());
				if (ptr != null)
				{
					return *<Module>.EnsoulSharp.Native.SpellDataResource.GetMissileSpeed(ptr);
				}
				return 0f;
			}
		}

		/// <summary>
		/// 	Gets the line width of the spell.
		/// </summary>
		// Token: 0x170000EA RID: 234
		// (get) Token: 0x0600049A RID: 1178 RVA: 0x0000F5BC File Offset: 0x0000E9BC
		public unsafe float LineWidth
		{
			get
			{
				SpellDataResource* ptr = *<Module>.EnsoulSharp.Native.SpellData.GetDataResource(this.GetPtr());
				if (ptr != null)
				{
					return *<Module>.EnsoulSharp.Native.SpellDataResource.GetLineWidth(ptr);
				}
				return 0f;
			}
		}

		/// <summary>
		/// 	Gets the line drag length of the spell.
		/// </summary>
		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x0600049B RID: 1179 RVA: 0x0000F5E8 File Offset: 0x0000E9E8
		public unsafe float LineDragLength
		{
			get
			{
				SpellDataResource* ptr = *<Module>.EnsoulSharp.Native.SpellData.GetDataResource(this.GetPtr());
				if (ptr != null)
				{
					return *<Module>.EnsoulSharp.Native.SpellDataResource.GetLineDragLength(ptr);
				}
				return 0f;
			}
		}

		/// <summary>
		/// 	Gets the targeting type of the spell.
		/// </summary>
		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x0600049C RID: 1180 RVA: 0x0000F614 File Offset: 0x0000EA14
		public unsafe SpellDataTargetType TargetingType
		{
			get
			{
				SpellDataResource* ptr = *<Module>.EnsoulSharp.Native.SpellData.GetDataResource(this.GetPtr());
				if (ptr != null)
				{
					return (SpellDataTargetType)<Module>.EnsoulSharp.Native.SpellDataResource.GetTargetingType(ptr);
				}
				return SpellDataTargetType.Unknown;
			}
		}

		/// <summary>
		/// 	Gets the cooldown time array of the spell.
		/// </summary>
		/// <remarks>The max count is 6.</remarks>
		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x0600049D RID: 1181 RVA: 0x0000F63C File Offset: 0x0000EA3C
		public unsafe float[] CooldownTimeArray
		{
			get
			{
				float[] array = new float[6];
				SpellDataResource* ptr = *<Module>.EnsoulSharp.Native.SpellData.GetDataResource(this.GetPtr());
				if (ptr != null)
				{
					int num = 0;
					do
					{
						float num2 = *(num * 4 + <Module>.EnsoulSharp.Native.SpellDataResource.GetCooldownTime(ptr) + 4);
						array[num] = num2;
						num++;
					}
					while (num < 6);
				}
				return array;
			}
		}

		/// <summary>
		/// 	Gets the cast range array of the spell.
		/// </summary>
		/// <remarks>The max count is 6.</remarks>
		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x0600049E RID: 1182 RVA: 0x0000F680 File Offset: 0x0000EA80
		public unsafe float[] CastRangeArray
		{
			get
			{
				float[] array = new float[6];
				SpellDataResource* ptr = *<Module>.EnsoulSharp.Native.SpellData.GetDataResource(this.GetPtr());
				if (ptr != null)
				{
					int num = 0;
					do
					{
						float num2 = *(num * 4 + <Module>.EnsoulSharp.Native.SpellDataResource.GetCastRange(ptr) + 4);
						array[num] = num2;
						num++;
					}
					while (num < 6);
				}
				return array;
			}
		}

		/// <summary>
		/// 	Gets the display override cast range array of the spell.
		/// </summary>
		/// <remarks>The max count is 6.</remarks>
		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x0600049F RID: 1183 RVA: 0x0000F6C4 File Offset: 0x0000EAC4
		public unsafe float[] CastRangeDisplayOverrideArray
		{
			get
			{
				float[] array = new float[6];
				SpellDataResource* ptr = *<Module>.EnsoulSharp.Native.SpellData.GetDataResource(this.GetPtr());
				if (ptr != null)
				{
					int num = 0;
					do
					{
						float num2 = *(num * 4 + <Module>.EnsoulSharp.Native.SpellDataResource.GetCastRangeDisplayOverride(ptr) + 4);
						array[num] = num2;
						num++;
					}
					while (num < 6);
				}
				return array;
			}
		}

		/// <summary>
		/// 	Gets the cast radius array of the spell.
		/// </summary>
		/// <remarks>The max count is 6.</remarks>
		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x060004A0 RID: 1184 RVA: 0x0000F708 File Offset: 0x0000EB08
		public unsafe float[] CastRadiusArray
		{
			get
			{
				float[] array = new float[6];
				SpellDataResource* ptr = *<Module>.EnsoulSharp.Native.SpellData.GetDataResource(this.GetPtr());
				if (ptr != null)
				{
					int num = 0;
					do
					{
						float num2 = *(num * 4 + <Module>.EnsoulSharp.Native.SpellDataResource.GetCastRadius(ptr) + 4);
						array[num] = num2;
						num++;
					}
					while (num < 6);
				}
				return array;
			}
		}

		/// <summary>
		/// 	Gets the secondary cast radius array of the spell.
		/// </summary>
		/// <remarks>The max count is 6.</remarks>
		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x060004A1 RID: 1185 RVA: 0x0000F74C File Offset: 0x0000EB4C
		public unsafe float[] CastRadiusSecondaryArray
		{
			get
			{
				float[] array = new float[6];
				SpellDataResource* ptr = *<Module>.EnsoulSharp.Native.SpellData.GetDataResource(this.GetPtr());
				if (ptr != null)
				{
					int num = 0;
					do
					{
						float num2 = *(num * 4 + <Module>.EnsoulSharp.Native.SpellDataResource.GetCastRadiusSecondary(ptr) + 4);
						array[num] = num2;
						num++;
					}
					while (num < 6);
				}
				return array;
			}
		}

		/// <summary>
		/// 	Gets the mana array of the spell.
		/// </summary>
		/// <remarks>The max count is 6.</remarks>
		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x060004A2 RID: 1186 RVA: 0x0000F790 File Offset: 0x0000EB90
		public unsafe float[] ManaArray
		{
			get
			{
				float[] array = new float[6];
				SpellDataResource* ptr = *<Module>.EnsoulSharp.Native.SpellData.GetDataResource(this.GetPtr());
				if (ptr != null)
				{
					int num = 0;
					do
					{
						float num2 = *(num * 4 + <Module>.EnsoulSharp.Native.SpellDataResource.GetMana(ptr));
						array[num] = num2;
						num++;
					}
					while (num < 6);
				}
				return array;
			}
		}

		// Token: 0x040003B4 RID: 948
		private unsafe SpellData* m_sdata;
	}
}
