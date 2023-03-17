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
		// Token: 0x06000494 RID: 1172 RVA: 0x0000F3F8 File Offset: 0x0000E7F8
		internal unsafe SpellData(SpellData* sdata)
		{
			this.m_sdata = sdata;
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x0000F414 File Offset: 0x0000E814
		internal unsafe SpellData* GetPtr()
		{
			return this.m_sdata;
		}

		/// <summary>
		/// 	Gets the name of the spell.
		/// </summary>
		// Token: 0x170000FD RID: 253
		// (get) Token: 0x06000496 RID: 1174 RVA: 0x0000F428 File Offset: 0x0000E828
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
		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000497 RID: 1175 RVA: 0x0000F458 File Offset: 0x0000E858
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
		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06000498 RID: 1176 RVA: 0x0000F480 File Offset: 0x0000E880
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
		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000499 RID: 1177 RVA: 0x0000F4A8 File Offset: 0x0000E8A8
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
		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x0600049A RID: 1178 RVA: 0x0000F4D0 File Offset: 0x0000E8D0
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
		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x0600049B RID: 1179 RVA: 0x0000F4F8 File Offset: 0x0000E8F8
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
		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x0600049C RID: 1180 RVA: 0x0000F524 File Offset: 0x0000E924
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
		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x0600049D RID: 1181 RVA: 0x0000F550 File Offset: 0x0000E950
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
		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x0600049E RID: 1182 RVA: 0x0000F57C File Offset: 0x0000E97C
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
		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x0600049F RID: 1183 RVA: 0x0000F5A8 File Offset: 0x0000E9A8
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
		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x060004A0 RID: 1184 RVA: 0x0000F5D4 File Offset: 0x0000E9D4
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
		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x060004A1 RID: 1185 RVA: 0x0000F600 File Offset: 0x0000EA00
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
		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x060004A2 RID: 1186 RVA: 0x0000F62C File Offset: 0x0000EA2C
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
		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x060004A3 RID: 1187 RVA: 0x0000F658 File Offset: 0x0000EA58
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
		// Token: 0x170000EF RID: 239
		// (get) Token: 0x060004A4 RID: 1188 RVA: 0x0000F680 File Offset: 0x0000EA80
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
		// Token: 0x170000EE RID: 238
		// (get) Token: 0x060004A5 RID: 1189 RVA: 0x0000F6AC File Offset: 0x0000EAAC
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
		// Token: 0x170000ED RID: 237
		// (get) Token: 0x060004A6 RID: 1190 RVA: 0x0000F6D8 File Offset: 0x0000EAD8
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
		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060004A7 RID: 1191 RVA: 0x0000F704 File Offset: 0x0000EB04
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
		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060004A8 RID: 1192 RVA: 0x0000F72C File Offset: 0x0000EB2C
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
		// Token: 0x170000EA RID: 234
		// (get) Token: 0x060004A9 RID: 1193 RVA: 0x0000F770 File Offset: 0x0000EB70
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
		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060004AA RID: 1194 RVA: 0x0000F7B4 File Offset: 0x0000EBB4
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
		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060004AB RID: 1195 RVA: 0x0000F7F8 File Offset: 0x0000EBF8
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
		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060004AC RID: 1196 RVA: 0x0000F83C File Offset: 0x0000EC3C
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
		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060004AD RID: 1197 RVA: 0x0000F880 File Offset: 0x0000EC80
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
