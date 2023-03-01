using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security;
using EnsoulSharp.Native;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains ecerything we can offer related to each AIHeroClient object.
	/// </summary>
	// Token: 0x020000B8 RID: 184
	public class AIHeroClient : AIBaseClient
	{
		// Token: 0x060004BB RID: 1211 RVA: 0x000055E4 File Offset: 0x000049E4
		internal AIHeroClient()
		{
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x000055CC File Offset: 0x000049CC
		internal AIHeroClient(uint networkId, uint index) : base(networkId, index)
		{
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x000016D8 File Offset: 0x00000AD8
		internal new unsafe AIHeroClient* GetPtr()
		{
			return (AIHeroClient*)base.GetPtr();
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x00005B00 File Offset: 0x00004F00
		static AIHeroClient()
		{
			AppDomain.CurrentDomain.DomainUnload += AIHeroClient.DomainUnloadEventHandler;
			AIHeroClient.m_LevelUpNativeDelegate = new AIHeroClient.OnLevelUpNativeDelegate(AIHeroClient.OnLevelUpNative);
			AIHeroClient.m_LevelUpNative = Marshal.GetFunctionPointerForDelegate<AIHeroClient.OnLevelUpNativeDelegate>(AIHeroClient.m_LevelUpNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIHeroClient\u0020*,int)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetAIHeroClientLevelUpHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), AIHeroClient.m_LevelUpNative.ToPointer());
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x000055F8 File Offset: 0x000049F8
		internal new static void DomainUnloadEventHandler(object sender, EventArgs e)
		{
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIHeroClient\u0020*,int)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetAIHeroClientLevelUpHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), AIHeroClient.m_LevelUpNative.ToPointer());
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x00005620 File Offset: 0x00004A20
		[HandleProcessCorruptedStateExceptions]
		[SecurityCritical]
		internal unsafe static void OnLevelUpNative(AIHeroClient* aiHeroClient, int level)
		{
			AIHeroClientLevelUp[] array = null;
			try
			{
				AIHeroClient aiheroClient = ObjectManager.CreateObjectFromPointer((GameObject*)aiHeroClient) as AIHeroClient;
				if (aiheroClient != null)
				{
					AIHeroClientLevelUpEventArgs args = new AIHeroClientLevelUpEventArgs(level);
					foreach (AIHeroClientLevelUp aiheroClientLevelUp in AIHeroClient.LevelUpHandlers.ToArray())
					{
						try
						{
							aiheroClientLevelUp(aiheroClient, args);
						}
						catch (Exception ex)
						{
							Console.WriteLine();
							Console.WriteLine("========================================");
							Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
							Console.WriteLine();
							Console.WriteLine("Type: {0}", ex.GetType().FullName);
							Console.WriteLine("Message: {0}", ex.Message);
							Console.WriteLine();
							Console.WriteLine("Stracktrace:");
							Console.WriteLine(ex.StackTrace);
							Exception innerException = ex.InnerException;
							if (innerException != null)
							{
								Console.WriteLine();
								Console.WriteLine("InnerException(s):");
								do
								{
									Console.WriteLine("----------------------------------------");
									Console.WriteLine("Type: {0}", innerException.GetType().FullName);
									Console.WriteLine("Message: {0}", innerException.Message);
									Console.WriteLine();
									Console.WriteLine("Stracktrace:");
									Console.WriteLine(innerException.StackTrace);
									innerException = innerException.InnerException;
								}
								while (innerException != null);
								Console.WriteLine("----------------------------------------");
							}
							Console.WriteLine("========================================");
							Console.WriteLine();
							string newValue = "";
							Log.Error(ex.ToString().Replace("\r", newValue).Replace("\n", newValue));
						}
					}
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue = "";
				Log.Error(ex2.ToString().Replace("\r", newValue).Replace("\n", newValue));
			}
		}

		/// <summary>
		/// 	This event is fired before level up.
		/// </summary>
		// Token: 0x14000013 RID: 19
		// (add) Token: 0x060004C1 RID: 1217 RVA: 0x000058F0 File Offset: 0x00004CF0
		// (remove) Token: 0x060004C2 RID: 1218 RVA: 0x00005908 File Offset: 0x00004D08
		public static event AIHeroClientLevelUp OnLevelUp
		{
			add
			{
				AIHeroClient.LevelUpHandlers.Add(value);
			}
			remove
			{
				AIHeroClient.LevelUpHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	Gets the perks of the object.
		/// </summary>
		// Token: 0x17000116 RID: 278
		// (get) Token: 0x060004C3 RID: 1219 RVA: 0x00005B70 File Offset: 0x00004F70
		public unsafe Perk[] Perks
		{
			get
			{
				List<Perk> list = new List<Perk>();
				StlVector<EnsoulSharp::Native::BasePerkInfo>* ptr = <Module>.EnsoulSharp.Native.AvatarCommon.GetPerkInfos(<Module>.EnsoulSharp.Native.AvatarClient.GetAvatarCommon(<Module>.EnsoulSharp.Native.AIHero.GetAvatar(this.GetPtr())));
				BasePerkInfo* ptr2 = *(int*)ptr;
				if (ptr2 != *(int*)(ptr + 4 / sizeof(StlVector<EnsoulSharp::Native::BasePerkInfo>)))
				{
					do
					{
						Perk* ptr3 = *<Module>.EnsoulSharp.Native.BasePerkInfo.GetPerk(ptr2);
						if (ptr3 != null)
						{
							int value = *<Module>.EnsoulSharp.Native.BasePerk.GetPerkName(ptr3);
							uint* ptr4 = <Module>.EnsoulSharp.Native.BasePerk.GetPerkId(ptr3);
							list.Add(new Perk((int)(*ptr4), new string(value)));
						}
						ptr2 += 136 / sizeof(BasePerkInfo);
					}
					while (ptr2 != *(int*)(ptr + 4 / sizeof(StlVector<EnsoulSharp::Native::BasePerkInfo>)));
				}
				return list.ToArray();
			}
		}

		/// <summary>
		/// 	Gets the evolve points of the object.
		/// </summary>
		// Token: 0x17000115 RID: 277
		// (get) Token: 0x060004C4 RID: 1220 RVA: 0x00005924 File Offset: 0x00004D24
		public unsafe int EvolvePoints
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.EvolutionState.GetEvolvePoints(<Module>.EnsoulSharp.Native.AIHero.GetEvolution(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the spell training points of the object.
		/// </summary>
		// Token: 0x17000114 RID: 276
		// (get) Token: 0x060004C5 RID: 1221 RVA: 0x00005944 File Offset: 0x00004D44
		public unsafe int SpellTrainingPoints
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.Experience.GetSpellTrainingPoints(<Module>.EnsoulSharp.Native.AIHero.GetExperience(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the level of the object.
		/// </summary>
		// Token: 0x17000113 RID: 275
		// (get) Token: 0x060004C6 RID: 1222 RVA: 0x00005964 File Offset: 0x00004D64
		public unsafe int Level
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.Experience.GetLevel(<Module>.EnsoulSharp.Native.AIHero.GetExperience(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the experience of the object.
		/// </summary>
		// Token: 0x17000112 RID: 274
		// (get) Token: 0x060004C7 RID: 1223 RVA: 0x00005984 File Offset: 0x00004D84
		public unsafe float Experience
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.Experience.GetExp(<Module>.EnsoulSharp.Native.AIHero.GetExperience(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the experience to current level of the object.
		/// </summary>
		// Token: 0x17000111 RID: 273
		// (get) Token: 0x060004C8 RID: 1224 RVA: 0x000059A4 File Offset: 0x00004DA4
		public float ExpToCurrentLevel
		{
			get
			{
				return <Module>.EnsoulSharp.Native.Experience.ExpToCurrentLevel(<Module>.EnsoulSharp.Native.AIHero.GetExperience(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the experience to next level of the object.
		/// </summary>
		// Token: 0x17000110 RID: 272
		// (get) Token: 0x060004C9 RID: 1225 RVA: 0x000059C4 File Offset: 0x00004DC4
		public float ExpToNextLevel
		{
			get
			{
				return <Module>.EnsoulSharp.Native.Experience.ExpToNextLevel(<Module>.EnsoulSharp.Native.AIHero.GetExperience(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the minions killed of the object.
		/// </summary>
		// Token: 0x1700010F RID: 271
		// (get) Token: 0x060004CA RID: 1226 RVA: 0x000059E4 File Offset: 0x00004DE4
		public unsafe int MinionsKilled
		{
			get
			{
				HeroStatsCollection* ptr = <Module>.EnsoulSharp.Native.AIHeroClient.GetStats(this.GetPtr());
				if (ptr != null)
				{
					return (int)((double)(*<Module>.EnsoulSharp.Native.HeroStatIntRounded.GetValue(<Module>.EnsoulSharp.Native.HeroStatsCollection.GetMinionsKilled(ptr))));
				}
				return 0;
			}
		}

		/// <summary>
		/// 	Gets the neutral minions killed of the object.
		/// </summary>
		// Token: 0x1700010E RID: 270
		// (get) Token: 0x060004CB RID: 1227 RVA: 0x00005A10 File Offset: 0x00004E10
		public unsafe int NeutralMinionsKilled
		{
			get
			{
				HeroStatsCollection* ptr = <Module>.EnsoulSharp.Native.AIHeroClient.GetStats(this.GetPtr());
				if (ptr != null)
				{
					return (int)((double)(*<Module>.EnsoulSharp.Native.HeroStatIntRounded.GetValue(<Module>.EnsoulSharp.Native.HeroStatsCollection.GetNeutralMinionsKilled(ptr))));
				}
				return 0;
			}
		}

		/// <summary>
		/// 	Gets the champions killed of the object.
		/// </summary>
		// Token: 0x1700010D RID: 269
		// (get) Token: 0x060004CC RID: 1228 RVA: 0x00005A3C File Offset: 0x00004E3C
		public unsafe int ChampionsKilled
		{
			get
			{
				HeroStatsCollection* ptr = <Module>.EnsoulSharp.Native.AIHeroClient.GetStats(this.GetPtr());
				if (ptr != null)
				{
					return *<Module>.EnsoulSharp.Native.HeroStatInt.GetValue(<Module>.EnsoulSharp.Native.HeroStatsCollection.GetNumChampionKills(ptr));
				}
				return 0;
			}
		}

		/// <summary>
		/// 	Gets the deaths of the object.
		/// </summary>
		// Token: 0x1700010C RID: 268
		// (get) Token: 0x060004CD RID: 1229 RVA: 0x00005A68 File Offset: 0x00004E68
		public unsafe int Deaths
		{
			get
			{
				HeroStatsCollection* ptr = <Module>.EnsoulSharp.Native.AIHeroClient.GetStats(this.GetPtr());
				if (ptr != null)
				{
					return *<Module>.EnsoulSharp.Native.HeroStatInt.GetValue(<Module>.EnsoulSharp.Native.HeroStatsCollection.GetNumDeaths(ptr));
				}
				return 0;
			}
		}

		/// <summary>
		/// 	Gets the assists of the object.
		/// </summary>
		// Token: 0x1700010B RID: 267
		// (get) Token: 0x060004CE RID: 1230 RVA: 0x00005A94 File Offset: 0x00004E94
		public unsafe int Assists
		{
			get
			{
				HeroStatsCollection* ptr = <Module>.EnsoulSharp.Native.AIHeroClient.GetStats(this.GetPtr());
				if (ptr != null)
				{
					return *<Module>.EnsoulSharp.Native.HeroStatInt.GetValue(<Module>.EnsoulSharp.Native.HeroStatsCollection.GetNumAssists(ptr));
				}
				return 0;
			}
		}

		/// <summary>
		/// 	Buys an item.
		/// </summary>
		/// <param name="itemId">The item id.</param>
		/// <returns>The <see cref="T:EnsoulSharp.BuyItemResult" /> of the given item id.</returns>
		// Token: 0x060004CF RID: 1231 RVA: 0x00005AC0 File Offset: 0x00004EC0
		public BuyItemResult BuyItem(ItemId itemId)
		{
			return (BuyItemResult)<Module>.EnsoulSharp.Native.HeroInventoryCommon.BuyItem(<Module>.EnsoulSharp.Native.AIHero.GetHeroInventory(this.GetPtr()), (int)itemId);
		}

		/// <summary>
		/// 	Sells an item.
		/// </summary>
		/// <param name="slot">The inventory slot.</param>
		// Token: 0x060004D0 RID: 1232 RVA: 0x00005AE0 File Offset: 0x00004EE0
		public void SellItem(int slot)
		{
			<Module>.EnsoulSharp.Native.HeroInventoryClient.RemoveItemClient(<Module>.EnsoulSharp.Native.AIHero.GetHeroInventory(this.GetPtr()), slot);
		}

		// Token: 0x040003B8 RID: 952
		internal static AIHeroClient.OnLevelUpNativeDelegate m_LevelUpNativeDelegate;

		// Token: 0x040003B9 RID: 953
		internal static IntPtr m_LevelUpNative = IntPtr.Zero;

		// Token: 0x040003BA RID: 954
		internal static List<AIHeroClientLevelUp> LevelUpHandlers = new List<AIHeroClientLevelUp>();

		// Token: 0x020000B9 RID: 185
		// (Invoke) Token: 0x060004D2 RID: 1234
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void OnLevelUpNativeDelegate(AIHeroClient* aiHeroClient, int level);
	}
}
