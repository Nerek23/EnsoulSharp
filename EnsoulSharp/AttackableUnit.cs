﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security;
using EnsoulSharp.Native;
using EnsoulSharp.Native.Enums;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each AttackableUnit object.
	/// </summary>
	// Token: 0x0200004A RID: 74
	public class AttackableUnit : GameObject
	{
		// Token: 0x060002E4 RID: 740 RVA: 0x00005C8C File Offset: 0x0000508C
		internal AttackableUnit()
		{
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x00005C74 File Offset: 0x00005074
		internal AttackableUnit(uint networkId, uint index) : base(networkId, index)
		{
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x000016D8 File Offset: 0x00000AD8
		internal new unsafe AttackableUnit* GetPtr()
		{
			return (AttackableUnit*)base.GetPtr();
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x000063C8 File Offset: 0x000057C8
		static AttackableUnit()
		{
			AppDomain.CurrentDomain.DomainUnload += AttackableUnit.DomainUnloadEventHandler;
			AttackableUnit.m_TeleportNativeDelegate = new AttackableUnit.OnTeleportNativeDelegate(AttackableUnit.OnTeleportNative);
			AttackableUnit.m_TeleportNative = Marshal.GetFunctionPointerForDelegate<AttackableUnit.OnTeleportNativeDelegate>(AttackableUnit.m_TeleportNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AttackableUnit\u0020*,EnsoulSharp::Native::StlString\u0020*,EnsoulSharp::Native::StlString\u0020*)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetAttackableUnitTeleportHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), AttackableUnit.m_TeleportNative.ToPointer());
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x00005CA0 File Offset: 0x000050A0
		internal new static void DomainUnloadEventHandler(object sender, EventArgs e)
		{
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::AttackableUnit\u0020*,EnsoulSharp::Native::StlString\u0020*,EnsoulSharp::Native::StlString\u0020*)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetAttackableUnitTeleportHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), AttackableUnit.m_TeleportNative.ToPointer());
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x00005CC8 File Offset: 0x000050C8
		[SecurityCritical]
		[HandleProcessCorruptedStateExceptions]
		internal unsafe static void OnTeleportNative(AttackableUnit* attackableUnit, StlString* recallType, StlString* recallName)
		{
			AttackableUnitTeleport[] array = null;
			try
			{
				AttackableUnit attackableUnit2 = ObjectManager.CreateObjectFromPointer((GameObject*)attackableUnit) as AttackableUnit;
				if (attackableUnit2 != null)
				{
					AttackableUnitTeleportEventArgs args = new AttackableUnitTeleportEventArgs(new string(<Module>.EnsoulSharp.Native.StlString.get(recallType)), new string(<Module>.EnsoulSharp.Native.StlString.get(recallName)));
					foreach (AttackableUnitTeleport attackableUnitTeleport in AttackableUnit.TeleportHandlers.ToArray())
					{
						try
						{
							attackableUnitTeleport(attackableUnit2, args);
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
		/// 	This event is fired before a object teleport.
		/// </summary>
		// Token: 0x14000005 RID: 5
		// (add) Token: 0x060002EA RID: 746 RVA: 0x00005FAC File Offset: 0x000053AC
		// (remove) Token: 0x060002EB RID: 747 RVA: 0x00005FC4 File Offset: 0x000053C4
		public static event AttackableUnitTeleport OnTeleport
		{
			add
			{
				AttackableUnit.TeleportHandlers.Add(value);
			}
			remove
			{
				AttackableUnit.TeleportHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is physical immune.
		/// </summary>
		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060002EC RID: 748 RVA: 0x00005FE0 File Offset: 0x000053E0
		public bool IsPhysicalImmune
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.TScrambleWrapper<int,int,unsigned\u0020int,0>.Get(<Module>.EnsoulSharp.Native.AttackableUnit.GetIsPhysicalImmune(this.GetPtr()), 0) != 0;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is magical immune.
		/// </summary>
		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060002ED RID: 749 RVA: 0x00006008 File Offset: 0x00005408
		public bool IsMagicalImmune
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.TScrambleWrapper<int,int,unsigned\u0020int,0>.Get(<Module>.EnsoulSharp.Native.AttackableUnit.GetIsMagicImmune(this.GetPtr()), 0) != 0;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is lifesteal immune.
		/// </summary>
		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060002EE RID: 750 RVA: 0x00006030 File Offset: 0x00005430
		public bool IsLifestealImmune
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.TScrambleWrapper<int,int,unsigned\u0020int,0>.Get(<Module>.EnsoulSharp.Native.AttackableUnit.GetIsLifestealImmune(this.GetPtr()), 0) != 0;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is invulnerable.
		/// </summary>
		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060002EF RID: 751 RVA: 0x00006058 File Offset: 0x00005458
		public bool IsInvulnerable
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.AttackableUnit.IsInvulnerable(this.GetPtr()) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is targetable.
		/// </summary>
		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060002F0 RID: 752 RVA: 0x00006070 File Offset: 0x00005470
		public bool IsTargetable
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.AttackableUnit.IsTargetable(this.GetPtr()) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is visible.
		/// </summary>
		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060002F1 RID: 753 RVA: 0x00006088 File Offset: 0x00005488
		public unsafe bool IsVisible
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return *<Module>.EnsoulSharp.Native.NetVisibilityObjectClient.GetVisible(<Module>.EnsoulSharp.Native.AttackableUnit.GetNetVisibility(this.GetPtr())) != 0;
			}
		}

		/// <summary>
		/// 	Gets the time of death of the object.
		/// </summary>
		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060002F2 RID: 754 RVA: 0x000060A8 File Offset: 0x000054A8
		public float DeathTime
		{
			get
			{
				return <Module>.EnsoulSharp.Native.TScrambleWrapper<float,float,unsigned\u0020int,0>.Get(<Module>.EnsoulSharp.Native.AttackableUnit.GetTimeOfDeath(this.GetPtr()), 0f);
			}
		}

		/// <summary>
		/// 	Gets the override collision height of the object.
		/// </summary>
		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060002F3 RID: 755 RVA: 0x000060CC File Offset: 0x000054CC
		public unsafe float OverrideCollisionHeight
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.AttackableUnit.GetOverrideCollisionHeight(this.GetPtr());
			}
		}

		/// <summary>
		/// 	Gets the override collision radius of the object.
		/// </summary>
		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060002F4 RID: 756 RVA: 0x000060E8 File Offset: 0x000054E8
		public unsafe float OverrideCollisionRadius
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.AttackableUnit.GetOverrideCollisionRadius(this.GetPtr());
			}
		}

		/// <summary>
		/// 	Gets the pathfinding collision radius of the object.
		/// </summary>
		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060002F5 RID: 757 RVA: 0x00006104 File Offset: 0x00005504
		public unsafe float PathfindingCollisionRadius
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.AttackableUnit.GetPathfindingCollisionRadius(this.GetPtr());
			}
		}

		/// <summary>
		/// 	Gets the health of the object.
		/// </summary>
		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060002F6 RID: 758 RVA: 0x00006120 File Offset: 0x00005520
		public unsafe float Health
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.Health.GetCurrent(<Module>.EnsoulSharp.Native.AttackableUnit.GetHealth(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the max health of the object.
		/// </summary>
		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060002F7 RID: 759 RVA: 0x00006140 File Offset: 0x00005540
		public unsafe float MaxHealth
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.Health.GetMax(<Module>.EnsoulSharp.Native.AttackableUnit.GetHealth(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the mana of the object.
		/// </summary>
		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060002F8 RID: 760 RVA: 0x00006160 File Offset: 0x00005560
		public unsafe float Mana
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.AbilityResource.GetCurrent(<Module>.EnsoulSharp.Native.AttackableUnit.GetAbilityResources(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the max mana of the object.
		/// </summary>
		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060002F9 RID: 761 RVA: 0x00006180 File Offset: 0x00005580
		public unsafe float MaxMana
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.AbilityResource.GetMax(<Module>.EnsoulSharp.Native.AttackableUnit.GetAbilityResources(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the ability resource of the object.
		/// </summary>
		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060002FA RID: 762 RVA: 0x000061A0 File Offset: 0x000055A0
		public unsafe float AbilityResource
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.AbilityResource.GetCurrent(<Module>.EnsoulSharp.Native.AttackableUnit.GetAbilityResources(this.GetPtr()) + 96);
			}
		}

		/// <summary>
		/// 	Gets the max ability resource of the object.
		/// </summary>
		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060002FB RID: 763 RVA: 0x000061C4 File Offset: 0x000055C4
		public unsafe float MaxAbilityResource
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.AbilityResource.GetMax(<Module>.EnsoulSharp.Native.AttackableUnit.GetAbilityResources(this.GetPtr()) + 96);
			}
		}

		/// <summary>
		/// 	Gets the all shield of the object.
		/// </summary>
		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060002FC RID: 764 RVA: 0x000061E8 File Offset: 0x000055E8
		public unsafe float AllShield
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.Health.GetAllShield(<Module>.EnsoulSharp.Native.AttackableUnit.GetHealth(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the physical shield of the object.
		/// </summary>
		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060002FD RID: 765 RVA: 0x00006208 File Offset: 0x00005608
		public unsafe float PhysicalShield
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.Health.GetPhysicalShield(<Module>.EnsoulSharp.Native.AttackableUnit.GetHealth(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the magical shield of the object.
		/// </summary>
		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060002FE RID: 766 RVA: 0x00006228 File Offset: 0x00005628
		public unsafe float MagicalShield
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.Health.GetMagicalShield(<Module>.EnsoulSharp.Native.AttackableUnit.GetHealth(this.GetPtr()));
			}
		}

		/// <summary>
		/// 	Gets the health percent of the object.
		/// </summary>
		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060002FF RID: 767 RVA: 0x00006248 File Offset: 0x00005648
		public unsafe float HealthPercent
		{
			get
			{
				Health* ptr = <Module>.EnsoulSharp.Native.AttackableUnit.GetHealth(this.GetPtr());
				float num = *<Module>.EnsoulSharp.Native.Health.GetCurrent(ptr);
				float* ptr2 = <Module>.EnsoulSharp.Native.Health.GetMax(ptr);
				return (float)((double)num * 100.0 / (double)(*ptr2));
			}
		}

		/// <summary>
		/// 	Gets the mana percent of the object.
		/// </summary>
		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000300 RID: 768 RVA: 0x00006284 File Offset: 0x00005684
		public unsafe float ManaPercent
		{
			get
			{
				AbilityResource* ptr = <Module>.EnsoulSharp.Native.AttackableUnit.GetAbilityResources(this.GetPtr());
				float num = *<Module>.EnsoulSharp.Native.AbilityResource.GetCurrent(ptr);
				float* ptr2 = <Module>.EnsoulSharp.Native.AbilityResource.GetMax(ptr);
				return (float)((double)num * 100.0 / (double)(*ptr2));
			}
		}

		/// <summary>
		/// 	Gets the ability resource percent of the object.
		/// </summary>
		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000301 RID: 769 RVA: 0x000062C0 File Offset: 0x000056C0
		public unsafe float AbilityResourcePercent
		{
			get
			{
				AbilityResource* ptr = <Module>.EnsoulSharp.Native.AttackableUnit.GetAbilityResources(this.GetPtr()) + 96;
				float num = *<Module>.EnsoulSharp.Native.AbilityResource.GetCurrent(ptr);
				float* ptr2 = <Module>.EnsoulSharp.Native.AbilityResource.GetMax(ptr);
				return (float)((double)num * 100.0 / (double)(*ptr2));
			}
		}

		/// <summary>
		/// 	Gets the armor material of the object.
		/// </summary>
		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000302 RID: 770 RVA: 0x000062FC File Offset: 0x000056FC
		public unsafe string ArmorMaterial
		{
			get
			{
				StlString* ptr = <Module>.EnsoulSharp.Native.AttackableUnit.GetArmorMaterial(this.GetPtr());
				return new string((*(ptr + 16) + 1 <= 16) ? ptr : (*ptr));
			}
		}

		/// <summary>
		/// 	Gets the weapon material of the object.
		/// </summary>
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000303 RID: 771 RVA: 0x0000632C File Offset: 0x0000572C
		public unsafe string WeaponMaterial
		{
			get
			{
				StlString* ptr = <Module>.EnsoulSharp.Native.AttackableUnit.GetWeaponMaterial(this.GetPtr());
				return new string((*(ptr + 16) + 1 <= 16) ? ptr : (*ptr));
			}
		}

		/// <summary>
		/// 	Gets the owner of the object.
		/// </summary>
		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000304 RID: 772 RVA: 0x0000635C File Offset: 0x0000575C
		public unsafe GameObject Owner
		{
			get
			{
				GameObject** ptr = *<Module>.EnsoulSharp.Native.AttackableUnit.GetGoldRedirectTarget(this.GetPtr());
				if (ptr != null)
				{
					GameObject* ptr2 = *(int*)ptr;
					if (ptr2 != null)
					{
						return ObjectManager.CreateObjectFromPointer(ptr2);
					}
				}
				return null;
			}
		}

		/// <summary>
		/// 	This method can only be used in Drawing.OnRenderMouseOvers for glowing the object frame at current position.
		/// </summary>
		/// <param name="color">The color.</param>
		/// <param name="size">The size.</param>
		/// <param name="blurFactor">The blur factor.</param>
		// Token: 0x06000305 RID: 773 RVA: 0x00006388 File Offset: 0x00005788
		public void Glow(Color color, int size, int blurFactor)
		{
			<Module>.EnsoulSharp.Native.AttackableUnit.Glow(this.GetPtr(), color.ToArgb(), size, blurFactor);
		}

		/// <summary>
		/// 	Gets whether the object is targetable to specified team.
		/// </summary>
		/// <param name="attackingTeam">The attacking team.</param>
		/// <returns>A value indicating whether the object is targetable to specified team.</returns>
		// Token: 0x06000306 RID: 774 RVA: 0x000063AC File Offset: 0x000057AC
		[return: MarshalAs(UnmanagedType.U1)]
		public bool IsTargetableToTeam(GameObjectTeam attackingTeam)
		{
			return <Module>.EnsoulSharp.Native.AttackableUnit.IsTargetableToTeam(this.GetPtr(), (TeamId)attackingTeam) != null;
		}

		// Token: 0x0400035E RID: 862
		internal static AttackableUnit.OnTeleportNativeDelegate m_TeleportNativeDelegate;

		// Token: 0x0400035F RID: 863
		internal static IntPtr m_TeleportNative = IntPtr.Zero;

		// Token: 0x04000360 RID: 864
		internal static List<AttackableUnitTeleport> TeleportHandlers = new List<AttackableUnitTeleport>();

		// Token: 0x0200004B RID: 75
		// (Invoke) Token: 0x06000308 RID: 776
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void OnTeleportNativeDelegate(AttackableUnit* attackableUnit, StlString* recallType, StlString* recallName);
	}
}
