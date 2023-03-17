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
		// Token: 0x060004C6 RID: 1222 RVA: 0x00005664 File Offset: 0x00004A64
		internal AIHeroClient()
		{
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x0000564C File Offset: 0x00004A4C
		internal AIHeroClient(uint networkId, uint index) : base(networkId, index)
		{
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x000016D8 File Offset: 0x00000AD8
		internal new unsafe AIHeroClient* GetPtr()
		{
			return (AIHeroClient*)base.GetPtr();
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x00005B80 File Offset: 0x00004F80
		static AIHeroClient()
		{
			AppDomain.CurrentDomain.DomainUnload += AIHeroClient.DomainUnloadEventHandler;
			AIHeroClient.m_LevelUpNativeDelegate = new AIHeroClient.OnLevelUpNativeDelegate(AIHeroClient.OnLevelUpNative);
			AIHeroClient.m_LevelUpNative = Marshal.GetFunctionPointerForDelegate<AIHeroClient.OnLevelUpNativeDelegate>(AIHeroClient.m_LevelUpNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIHeroClient\u0020*,int)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetAIHeroClientLevelUpHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), AIHeroClient.m_LevelUpNative.ToPointer());
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x00005678 File Offset: 0x00004A78
		internal new static void DomainUnloadEventHandler(object sender, EventArgs e)
		{
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AIHeroClient\u0020*,int)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetAIHeroClientLevelUpHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), AIHeroClient.m_LevelUpNative.ToPointer());
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x000056A0 File Offset: 0x00004AA0
		[SecurityCritical]
		[HandleProcessCorruptedStateExceptions]
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
		// (add) Token: 0x060004CC RID: 1228 RVA: 0x00005970 File Offset: 0x00004D70
		// (remove) Token: 0x060004CD RID: 1229 RVA: 0x00005988 File Offset: 0x00004D88
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
		// Token: 0x1700011A RID: 282
		// (get) Token: 0x060004CE RID: 1230 RVA: 0x00005BF0 File Offset: 0x00004FF0
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
		// Token: 0x17000119 RID: 281
		// (get) Token: 0x060004CF RID: 1231 RVA: 0x000059A4 File Offset: 0x00004DA4
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
		// Token: 0x17000118 RID: 280
		// (get) Token: 0x060004D0 RID: 1232 RVA: 0x000059C4 File Offset: 0x00004DC4
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
		// Token: 0x17000117 RID: 279
		// (get) Token: 0x060004D1 RID: 1233 RVA: 0x000059E4 File Offset: 0x00004DE4
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
		// Token: 0x17000116 RID: 278
		// (get) Token: 0x060004D2 RID: 1234 RVA: 0x00005A04 File Offset: 0x00004E04
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
		// Token: 0x17000115 RID: 277
		// (get) Token: 0x060004D3 RID: 1235 RVA: 0x00005A24 File Offset: 0x00004E24
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
		// Token: 0x17000114 RID: 276
		// (get) Token: 0x060004D4 RID: 1236 RVA: 0x00005A44 File Offset: 0x00004E44
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
		// Token: 0x17000113 RID: 275
		// (get) Token: 0x060004D5 RID: 1237 RVA: 0x00005A64 File Offset: 0x00004E64
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
		// Token: 0x17000112 RID: 274
		// (get) Token: 0x060004D6 RID: 1238 RVA: 0x00005A90 File Offset: 0x00004E90
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
		// Token: 0x17000111 RID: 273
		// (get) Token: 0x060004D7 RID: 1239 RVA: 0x00005ABC File Offset: 0x00004EBC
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
		// Token: 0x17000110 RID: 272
		// (get) Token: 0x060004D8 RID: 1240 RVA: 0x00005AE8 File Offset: 0x00004EE8
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
		// Token: 0x1700010F RID: 271
		// (get) Token: 0x060004D9 RID: 1241 RVA: 0x00005B14 File Offset: 0x00004F14
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
		// Token: 0x060004DA RID: 1242 RVA: 0x00005B40 File Offset: 0x00004F40
		public BuyItemResult BuyItem(ItemId itemId)
		{
			return (BuyItemResult)<Module>.EnsoulSharp.Native.HeroInventoryCommon.BuyItem(<Module>.EnsoulSharp.Native.AIHero.GetHeroInventory(this.GetPtr()), (int)itemId);
		}

		/// <summary>
		/// 	Sells an item.
		/// </summary>
		/// <param name="slot">The inventory slot.</param>
		// Token: 0x060004DB RID: 1243 RVA: 0x00005B60 File Offset: 0x00004F60
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
		// (Invoke) Token: 0x060004DD RID: 1245
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void OnLevelUpNativeDelegate(AIHeroClient* aiHeroClient, int level);
	}
}
