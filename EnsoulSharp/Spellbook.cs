using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security;
using EnsoulSharp.Native;
using EnsoulSharp.Native.Enums;
using SharpDX;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each object spell book.
	/// </summary>
	// Token: 0x02000071 RID: 113
	public class Spellbook
	{
		// Token: 0x06000461 RID: 1121 RVA: 0x0000E194 File Offset: 0x0000D594
		internal Spellbook(uint networkId)
		{
			this.m_networkId = networkId;
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x0000E1B0 File Offset: 0x0000D5B0
		internal unsafe SpellbookClient* GetPtr()
		{
			AIBaseClient* ptr = <Module>.EnsoulSharp.Native.ObjectManager.GetUnitByNetworkId(this.m_networkId);
			if (ptr != null)
			{
				return <Module>.EnsoulSharp.Native.AIBaseCommon.GetSpellbook(ptr);
			}
			throw new SpellbookNotFoundException();
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x0000F0E4 File Offset: 0x0000E4E4
		static Spellbook()
		{
			AppDomain.CurrentDomain.DomainUnload += Spellbook.DomainUnloadEventHandler;
			Spellbook.m_CastSpellNativeDelegate = new Spellbook.OnCastSpellNativeDelegate(Spellbook.OnCastSpellNative);
			Spellbook.m_CastSpellNative = Marshal.GetFunctionPointerForDelegate<Spellbook.OnCastSpellNativeDelegate>(Spellbook.m_CastSpellNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::SpellbookClient\u0020*,enum\u0020EnsoulSharp::Native::Enums::SpellSlot,EnsoulSharp::Native::Vector3f\u0020*,EnsoulSharp::Native::Vector3f\u0020*,unsigned\u0020int,bool\u0020*)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetSpellbookCastSpellHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Spellbook.m_CastSpellNative.ToPointer());
			Spellbook.m_StopCastNativeDelegate = new Spellbook.OnStopCastNativeDelegate(Spellbook.OnStopCastNative);
			Spellbook.m_StopCastNative = Marshal.GetFunctionPointerForDelegate<Spellbook.OnStopCastNativeDelegate>(Spellbook.m_StopCastNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::SpellbookClient\u0020*,bool,bool,bool\u0020*,bool,unsigned\u0020int,unsigned\u0020int)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetSpellbookStopCastHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Spellbook.m_StopCastNative.ToPointer());
			Spellbook.m_UpdateChargedSpellNativeDelegate = new Spellbook.OnUpdateChargedSpellNativeDelegate(Spellbook.OnUpdateChargedSpellNative);
			Spellbook.m_UpdateChargedSpellNative = Marshal.GetFunctionPointerForDelegate<Spellbook.OnUpdateChargedSpellNativeDelegate>(Spellbook.m_UpdateChargedSpellNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::SpellbookClient\u0020*,enum\u0020EnsoulSharp::Native::Enums::SpellSlot,EnsoulSharp::Native::Vector3f\u0020*,bool,bool\u0020*)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetSpellbookUpdateChargedSpellHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Spellbook.m_UpdateChargedSpellNative.ToPointer());
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x0000E1DC File Offset: 0x0000D5DC
		internal static void DomainUnloadEventHandler(object sender, EventArgs e)
		{
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::SpellbookClient\u0020*,enum\u0020EnsoulSharp::Native::Enums::SpellSlot,EnsoulSharp::Native::Vector3f\u0020*,EnsoulSharp::Native::Vector3f\u0020*,unsigned\u0020int,bool\u0020*)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetSpellbookCastSpellHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Spellbook.m_CastSpellNative.ToPointer());
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::SpellbookClient\u0020*,bool,bool,bool\u0020*,bool,unsigned\u0020int,unsigned\u0020int)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetSpellbookStopCastHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Spellbook.m_StopCastNative.ToPointer());
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::SpellbookClient\u0020*,enum\u0020EnsoulSharp::Native::Enums::SpellSlot,EnsoulSharp::Native::Vector3f\u0020*,bool,bool\u0020*)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetSpellbookUpdateChargedSpellHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Spellbook.m_UpdateChargedSpellNative.ToPointer());
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x0000E234 File Offset: 0x0000D634
		[HandleProcessCorruptedStateExceptions]
		[SecurityCritical]
		internal unsafe static void OnCastSpellNative(SpellbookClient* spellBook, SpellSlot slot, Vector3f* startPosition, Vector3f* endPosition, uint targetNetworkId, bool* process)
		{
			SpellbookCastSpell[] array = null;
			try
			{
				AIBaseClient* ptr = <Module>.EnsoulSharp.Native.Spellbook.GetOwner(spellBook);
				if (ptr != null)
				{
					Spellbook sender = new Spellbook((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(ptr)));
					GameObject target;
					if (targetNetworkId != 0U)
					{
						target = ObjectManager.GetUnitByNetworkId<GameObject>((int)targetNetworkId);
					}
					else
					{
						target = null;
					}
					Vector3 endPosition2 = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(endPosition), <Module>.EnsoulSharp.Native.Vector3f.GetZ(endPosition), <Module>.EnsoulSharp.Native.Vector3f.GetY(endPosition));
					Vector3 startPosition2 = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(startPosition), <Module>.EnsoulSharp.Native.Vector3f.GetZ(startPosition), <Module>.EnsoulSharp.Native.Vector3f.GetY(startPosition));
					SpellbookCastSpellEventArgs spellbookCastSpellEventArgs = new SpellbookCastSpellEventArgs(*process, startPosition2, endPosition2, target, (SpellSlot)slot);
					foreach (SpellbookCastSpell spellbookCastSpell in Spellbook.CastSpellHandlers.ToArray())
					{
						try
						{
							spellbookCastSpell(sender, spellbookCastSpellEventArgs);
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
					*process = spellbookCastSpellEventArgs.Process;
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

		// Token: 0x06000466 RID: 1126 RVA: 0x0000E55C File Offset: 0x0000D95C
		[SecurityCritical]
		[HandleProcessCorruptedStateExceptions]
		internal unsafe static void OnStopCastNative(SpellbookClient* spellBook, [MarshalAs(UnmanagedType.U1)] bool keepAnimationPlaying, [MarshalAs(UnmanagedType.U1)] bool hasBeenCast, bool* spellStopCancelled, [MarshalAs(UnmanagedType.U1)] bool destroyMissile, uint missileToDestroy, uint spellCastId)
		{
			SpellbookStopCast[] array = null;
			try
			{
				AIBaseClient* ptr = <Module>.EnsoulSharp.Native.Spellbook.GetOwner(spellBook);
				if (ptr != null)
				{
					Spellbook sender = new Spellbook((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(ptr)));
					SpellbookStopCastEventArgs args = new SpellbookStopCastEventArgs(keepAnimationPlaying, hasBeenCast, *spellStopCancelled, destroyMissile, (int)missileToDestroy, (int)spellCastId);
					foreach (SpellbookStopCast spellbookStopCast in Spellbook.StopCastHandlers.ToArray())
					{
						try
						{
							spellbookStopCast(sender, args);
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

		// Token: 0x06000467 RID: 1127 RVA: 0x0000E838 File Offset: 0x0000DC38
		[SecurityCritical]
		[HandleProcessCorruptedStateExceptions]
		internal unsafe static void OnUpdateChargedSpellNative(SpellbookClient* spellBook, SpellSlot slot, Vector3f* position, [MarshalAs(UnmanagedType.U1)] bool releaseCast, bool* process)
		{
			SpellbookUpdateChargedSpell[] array = null;
			try
			{
				AIBaseClient* ptr = <Module>.EnsoulSharp.Native.Spellbook.GetOwner(spellBook);
				if (ptr != null)
				{
					Spellbook sender = new Spellbook((uint)(*<Module>.EnsoulSharp.Native.GameObject.GetNetworkID(ptr)));
					Vector3 position2 = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(position), <Module>.EnsoulSharp.Native.Vector3f.GetZ(position), <Module>.EnsoulSharp.Native.Vector3f.GetY(position));
					SpellbookUpdateChargedSpellEventArgs spellbookUpdateChargedSpellEventArgs = new SpellbookUpdateChargedSpellEventArgs(*process, (SpellSlot)slot, position2, releaseCast);
					foreach (SpellbookUpdateChargedSpell spellbookUpdateChargedSpell in Spellbook.UpdateChargedSpellHandlers.ToArray())
					{
						try
						{
							spellbookUpdateChargedSpell(sender, spellbookUpdateChargedSpellEventArgs);
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
					*process = spellbookUpdateChargedSpellEventArgs.Process;
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
		/// 	This event is fired before cast a spell.
		/// </summary>
		// Token: 0x14000012 RID: 18
		// (add) Token: 0x06000468 RID: 1128 RVA: 0x0000EB34 File Offset: 0x0000DF34
		// (remove) Token: 0x06000469 RID: 1129 RVA: 0x0000EB4C File Offset: 0x0000DF4C
		public static event SpellbookCastSpell OnCastSpell
		{
			add
			{
				Spellbook.CastSpellHandlers.Add(value);
			}
			remove
			{
				Spellbook.CastSpellHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	This event is fired after stop cast a spell.
		/// </summary>
		// Token: 0x14000011 RID: 17
		// (add) Token: 0x0600046A RID: 1130 RVA: 0x0000EB68 File Offset: 0x0000DF68
		// (remove) Token: 0x0600046B RID: 1131 RVA: 0x0000EB80 File Offset: 0x0000DF80
		public static event SpellbookStopCast OnStopCast
		{
			add
			{
				Spellbook.StopCastHandlers.Add(value);
			}
			remove
			{
				Spellbook.StopCastHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	This event is fired before update a charged spell.
		/// </summary>
		// Token: 0x14000010 RID: 16
		// (add) Token: 0x0600046C RID: 1132 RVA: 0x0000EB9C File Offset: 0x0000DF9C
		// (remove) Token: 0x0600046D RID: 1133 RVA: 0x0000EBB4 File Offset: 0x0000DFB4
		public static event SpellbookUpdateChargedSpell OnUpdateChargedSpell
		{
			add
			{
				Spellbook.UpdateChargedSpellHandlers.Add(value);
			}
			remove
			{
				Spellbook.UpdateChargedSpellHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	Gets the all spells.
		/// </summary>
		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x0600046E RID: 1134 RVA: 0x0000EBD0 File Offset: 0x0000DFD0
		public unsafe SpellDataInst[] Spells
		{
			get
			{
				List<SpellDataInst> list = new List<SpellDataInst>();
				SpellbookClient* ptr = this.GetPtr();
				int num = 0;
				do
				{
					SpellDataInstClient* ptr2 = *(num * 4 + <Module>.EnsoulSharp.Native.SpellbookClient.GetSpellsDataClient(ptr));
					if (ptr2 != null && *<Module>.EnsoulSharp.Native.SpellDataInstClient.GetSpellDataClient(ptr2) != 0)
					{
						list.Add(new SpellDataInst(this.m_networkId, (uint)num));
					}
					num++;
				}
				while (num < 64);
				return list.ToArray();
			}
		}

		/// <summary>
		/// 	Gets the active spell if exist, otherwise null.
		/// </summary>
		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x0600046F RID: 1135 RVA: 0x0000EC28 File Offset: 0x0000E028
		public unsafe AIBaseClientProcessSpellCastEventArgs ActiveSpell
		{
			get
			{
				SpellInstance* ptr = *<Module>.EnsoulSharp.Native.Spellbook.GetSpellcastingObject(this.GetPtr());
				if (ptr != null)
				{
					SpellCastInfo* ptr2 = <Module>.EnsoulSharp.Native.SpellInstance.GetCastInfo(ptr);
					uint targetLocalId;
					if (*<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetObjID(ptr2) != 0)
					{
						targetLocalId = (uint)(*(*<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetObjID(ptr2)));
					}
					else
					{
						targetLocalId = 0U;
					}
					Vector3 end = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetEndPosition(ptr2)), <Module>.EnsoulSharp.Native.Vector3f.GetZ(<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetEndPosition(ptr2)), <Module>.EnsoulSharp.Native.Vector3f.GetY(<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetEndPosition(ptr2)));
					Vector3 to = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetPosition(ptr2)), <Module>.EnsoulSharp.Native.Vector3f.GetZ(<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetPosition(ptr2)), <Module>.EnsoulSharp.Native.Vector3f.GetY(<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetPosition(ptr2)));
					Vector3 start = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(<Module>.EnsoulSharp.Native.SpellCastInfo.GetSpellCastLaunchPos(ptr2)), <Module>.EnsoulSharp.Native.Vector3f.GetZ(<Module>.EnsoulSharp.Native.SpellCastInfo.GetSpellCastLaunchPos(ptr2)), <Module>.EnsoulSharp.Native.Vector3f.GetY(<Module>.EnsoulSharp.Native.SpellCastInfo.GetSpellCastLaunchPos(ptr2)));
					SpellData sdata = (*<Module>.EnsoulSharp.Native.SpellCastInfo.GetSData(ptr2) == 0) ? null : new SpellData(*<Module>.EnsoulSharp.Native.SpellCastInfo.GetSData(ptr2));
					int slot = *<Module>.EnsoulSharp.Native.SpellCastInfo.GetSlot(ptr2);
					float totalTime = *<Module>.EnsoulSharp.Native.SpellCastInfo.GetDesignerTotalTime(ptr2);
					float num = *<Module>.EnsoulSharp.Native.SpellCastInfo.GetDesignerCastTime(ptr2);
					float num2 = *<Module>.EnsoulSharp.Native.SpellCastInfo.GetExtraTimeForCast(ptr2);
					int missileNetworkId = *<Module>.EnsoulSharp.Native.SpellCastInfo.GetMissileNetworkID(ptr2);
					int* ptr3 = <Module>.EnsoulSharp.Native.SpellCastInfo.GetSpellLevel(ptr2);
					return new AIBaseClientProcessSpellCastEventArgs(sdata, *ptr3 + 1, start, to, end, (int)targetLocalId, missileNetworkId, (float)((double)num2 + (double)num), totalTime, (SpellSlot)slot);
				}
				return null;
			}
		}

		/// <summary>
		/// 	Gets the book owner.
		/// </summary>
		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x06000470 RID: 1136 RVA: 0x0000ED4C File Offset: 0x0000E14C
		public AIBaseClient Owner
		{
			get
			{
				return ObjectManager.GetUnitByNetworkId<AIBaseClient>((int)this.m_networkId);
			}
		}

		/// <summary>
		/// 	Gets the spell cast time.
		/// </summary>
		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x06000471 RID: 1137 RVA: 0x0000ED64 File Offset: 0x0000E164
		public unsafe float CastTime
		{
			get
			{
				SpellInstance* ptr = *<Module>.EnsoulSharp.Native.Spellbook.GetSpellcastingObject(this.GetPtr());
				if (ptr != null)
				{
					return <Module>.EnsoulSharp.Native.SpellInstance.GetSpellCastTime(ptr);
				}
				return 0f;
			}
		}

		/// <summary>
		/// 	Gets the spell end time.
		/// </summary>
		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x06000472 RID: 1138 RVA: 0x0000ED90 File Offset: 0x0000E190
		public unsafe float CastEndTime
		{
			get
			{
				SpellInstance* ptr = *<Module>.EnsoulSharp.Native.Spellbook.GetSpellcastingObject(this.GetPtr());
				if (ptr != null)
				{
					return <Module>.EnsoulSharp.Native.SpellInstance.GetSpellEndTime(ptr);
				}
				return 0f;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether is casting spell now.
		/// </summary>
		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x06000473 RID: 1139 RVA: 0x0000EDBC File Offset: 0x0000E1BC
		public unsafe bool IsCastingSpell
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return *<Module>.EnsoulSharp.Native.Spellbook.GetIsCastingSpell(this.GetPtr()) != 0;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether is winding up now.
		/// </summary>
		// Token: 0x170000DF RID: 223
		// (get) Token: 0x06000474 RID: 1140 RVA: 0x0000EDD8 File Offset: 0x0000E1D8
		public bool IsWindingUp
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.Spellbook.IsCastObjectWindingUp(this.GetPtr()) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether is auto attacking now.
		/// </summary>
		// Token: 0x170000DE RID: 222
		// (get) Token: 0x06000475 RID: 1141 RVA: 0x0000EDF0 File Offset: 0x0000E1F0
		public unsafe bool IsAutoAttack
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				SpellInstance* ptr = *<Module>.EnsoulSharp.Native.Spellbook.GetSpellcastingObject(this.GetPtr());
				return ptr != null && <Module>.EnsoulSharp.Native.SpellInstance.IsAutoAttack(ptr) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether is channeling now.
		/// </summary>
		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06000476 RID: 1142 RVA: 0x0000EE18 File Offset: 0x0000E218
		public unsafe bool IsChanneling
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				SpellInstance* ptr = *<Module>.EnsoulSharp.Native.Spellbook.GetSpellcastingObject(this.GetPtr());
				return ptr != null && <Module>.EnsoulSharp.Native.SpellInstance.IsChanneling(ptr) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether is charging now.
		/// </summary>
		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000477 RID: 1143 RVA: 0x0000EE40 File Offset: 0x0000E240
		public unsafe bool IsCharging
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				SpellInstance* ptr = *<Module>.EnsoulSharp.Native.Spellbook.GetSpellcastingObject(this.GetPtr());
				return ptr != null && <Module>.EnsoulSharp.Native.SpellInstance.IsCharging(ptr) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether is stopped now.
		/// </summary>
		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000478 RID: 1144 RVA: 0x0000EE68 File Offset: 0x0000E268
		public unsafe bool IsStopped
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				SpellInstance* ptr = *<Module>.EnsoulSharp.Native.Spellbook.GetSpellcastingObject(this.GetPtr());
				return ptr != null && <Module>.EnsoulSharp.Native.SpellInstance.IsStopped(ptr) != null;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the spell was cast.
		/// </summary>
		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06000479 RID: 1145 RVA: 0x0000EE90 File Offset: 0x0000E290
		public unsafe bool SpellWasCast
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				SpellInstance* ptr = *<Module>.EnsoulSharp.Native.Spellbook.GetSpellcastingObject(this.GetPtr());
				return ptr != null && <Module>.EnsoulSharp.Native.SpellInstance.SpellWasCast(ptr) != null;
			}
		}

		/// <summary>
		/// 	Casts a spell at the given position.
		/// </summary>
		/// <param name="slot">The spell slot.</param>
		/// <param name="position">The spell target position.</param>
		/// <returns>A value indicating whether the spell is successfully cast.</returns>
		// Token: 0x0600047A RID: 1146 RVA: 0x0000EFE0 File Offset: 0x0000E3E0
		[return: MarshalAs(UnmanagedType.U1)]
		public bool CastSpell(SpellSlot slot, Vector3 position)
		{
			return this.CastSpell(slot, position, true);
		}

		/// <summary>
		/// 	Casts a spell at the given position, and you can specify whether trigger event.
		/// </summary>
		/// <param name="slot">The spell slot.</param>
		/// <param name="position">The spell target position.</param>
		/// <param name="triggerEvent">A value indicating whether trigger event.</param>
		/// <returns>A value indicating whether the spell is successfully cast.</returns>
		// Token: 0x0600047B RID: 1147 RVA: 0x0000EFA4 File Offset: 0x0000E3A4
		[return: MarshalAs(UnmanagedType.U1)]
		public unsafe bool CastSpell(SpellSlot slot, Vector3 position, [MarshalAs(UnmanagedType.U1)] bool triggerEvent)
		{
			Vector3f vector3f;
			return <Module>.EnsoulSharp.Native.SpellbookClient.CastSpell(this.GetPtr(), (SpellSlot)slot, *<Module>.EnsoulSharp.Native.Vector3f.{ctor}(ref vector3f, position.X, position.Z, position.Y), triggerEvent) != null;
		}

		/// <summary>
		/// 	Casts a spell from given start position to end position.
		/// </summary>
		/// <param name="slot">The spell slot.</param>
		/// <param name="startPosition">The spell start position.</param>
		/// <param name="endPosition">The spell end position.</param>
		/// <returns>A value indicating whether the spell is successfully cast.</returns>
		// Token: 0x0600047C RID: 1148 RVA: 0x0000EF8C File Offset: 0x0000E38C
		[return: MarshalAs(UnmanagedType.U1)]
		public bool CastSpell(SpellSlot slot, Vector3 startPosition, Vector3 endPosition)
		{
			return this.CastSpell(slot, startPosition, endPosition, true);
		}

		/// <summary>
		/// 	Casts a spell from given start position to end position, and you can specify whether trigger event.
		/// </summary>
		/// <param name="slot">The spell slot.</param>
		/// <param name="startPosition">The spell start position.</param>
		/// <param name="endPosition">The spell end position.</param>
		/// <param name="triggerEvent">A value indicating whether trigger event.</param>
		/// <returns>A value indicating whether the spell is successfully cast.</returns>
		// Token: 0x0600047D RID: 1149 RVA: 0x0000EF2C File Offset: 0x0000E32C
		[return: MarshalAs(UnmanagedType.U1)]
		public unsafe bool CastSpell(SpellSlot slot, Vector3 startPosition, Vector3 endPosition, [MarshalAs(UnmanagedType.U1)] bool triggerEvent)
		{
			Vector3f vector3f;
			Vector3f vector3f2;
			return <Module>.EnsoulSharp.Native.SpellbookClient.CastSpell(this.GetPtr(), (SpellSlot)slot, *<Module>.EnsoulSharp.Native.Vector3f.{ctor}(ref vector3f, startPosition.X, startPosition.Z, startPosition.Y), *<Module>.EnsoulSharp.Native.Vector3f.{ctor}(ref vector3f2, endPosition.X, endPosition.Z, endPosition.Y), triggerEvent) != null;
		}

		/// <summary>
		/// 	Casts a spell on the given unit.
		/// </summary>
		/// <param name="slot">The spell slot.</param>
		/// <param name="target">The spell target unit.</param>
		/// <returns>A value indicating whether the spell is successfully cast.</returns>
		// Token: 0x0600047E RID: 1150 RVA: 0x0000EF14 File Offset: 0x0000E314
		[return: MarshalAs(UnmanagedType.U1)]
		public bool CastSpell(SpellSlot slot, GameObject target)
		{
			return this.CastSpell(slot, target, true);
		}

		/// <summary>
		/// 	Casts a spell on the given unit, and you can specify whether trigger event.
		/// </summary>
		/// <param name="slot">The spell slot.</param>
		/// <param name="target">The spell target unit.</param>
		/// <param name="triggerEvent">A value indicating whether trigger event.</param>
		/// <returns>A value indicating whether the spell is successfully cast.</returns>
		// Token: 0x0600047F RID: 1151 RVA: 0x0000EEEC File Offset: 0x0000E2EC
		[return: MarshalAs(UnmanagedType.U1)]
		public unsafe bool CastSpell(SpellSlot slot, GameObject target, [MarshalAs(UnmanagedType.U1)] bool triggerEvent)
		{
			GameObject* ptr = target.GetPtr();
			return ptr != null && <Module>.EnsoulSharp.Native.SpellbookClient.CastSpell(this.GetPtr(), (SpellSlot)slot, ptr, triggerEvent) != null;
		}

		/// <summary>
		/// 	Casts a spell.
		/// </summary>
		/// <param name="slot">The spell slot.</param>
		/// <returns>A value indicating whether the spell is successfully cast.</returns>
		// Token: 0x06000480 RID: 1152 RVA: 0x0000EED4 File Offset: 0x0000E2D4
		[return: MarshalAs(UnmanagedType.U1)]
		public bool CastSpell(SpellSlot slot)
		{
			return this.CastSpell(slot, true);
		}

		/// <summary>
		/// 	Casts a spell, and you can specify whether trigger event.
		/// </summary>
		/// <param name="slot">The spell slot.</param>
		/// <param name="triggerEvent">A value indicating whether trigger event.</param>
		/// <returns>A value indicating whether the spell is successfully cast.</returns>
		// Token: 0x06000481 RID: 1153 RVA: 0x0000EEB8 File Offset: 0x0000E2B8
		[return: MarshalAs(UnmanagedType.U1)]
		public bool CastSpell(SpellSlot slot, [MarshalAs(UnmanagedType.U1)] bool triggerEvent)
		{
			return <Module>.EnsoulSharp.Native.SpellbookClient.CastSpell(this.GetPtr(), (SpellSlot)slot, triggerEvent) != null;
		}

		/// <summary>
		/// 	Updates a charged spell at the given position.
		/// </summary>
		/// <param name="slot">The spell slot.</param>
		/// <param name="position">The spell target position.</param>
		/// <param name="releaseCast">A value indicating whether the cast is release.</param>
		/// <returns>A value indicating whether the spell is successfully cast.</returns>
		// Token: 0x06000482 RID: 1154 RVA: 0x0000F038 File Offset: 0x0000E438
		[return: MarshalAs(UnmanagedType.U1)]
		public bool UpdateChargedSpell(SpellSlot slot, Vector3 position, [MarshalAs(UnmanagedType.U1)] bool releaseCast)
		{
			return this.UpdateChargedSpell(slot, position, releaseCast, true);
		}

		/// <summary>
		/// 	Updates a charged spell at the given position, and you can specify whether trigger event.
		/// </summary>
		/// <param name="slot">The spell slot.</param>
		/// <param name="position">The spell target position.</param>
		/// <param name="releaseCast">A value indicating whether the cast is release.</param>
		/// <param name="triggerEvent">A value indicating whether trigger event.</param>
		/// <returns>A value indicating whether the spell is successfully cast.</returns>
		// Token: 0x06000483 RID: 1155 RVA: 0x0000EFF8 File Offset: 0x0000E3F8
		[return: MarshalAs(UnmanagedType.U1)]
		public unsafe bool UpdateChargedSpell(SpellSlot slot, Vector3 position, [MarshalAs(UnmanagedType.U1)] bool releaseCast, [MarshalAs(UnmanagedType.U1)] bool triggerEvent)
		{
			Vector3f vector3f;
			return <Module>.EnsoulSharp.Native.SpellbookClient.UpdateChargedSpell(this.GetPtr(), (SpellSlot)slot, *<Module>.EnsoulSharp.Native.Vector3f.{ctor}(ref vector3f, position.X, position.Z, position.Y), releaseCast, triggerEvent) != null;
		}

		/// <summary>
		/// 	Evolves a spell.
		/// </summary>
		/// <param name="slot">The spell slot.</param>
		// Token: 0x06000484 RID: 1156 RVA: 0x0000F050 File Offset: 0x0000E450
		public void EvolveSpell(SpellSlot slot)
		{
			<Module>.EnsoulSharp.Native.SpellbookClient.EvolveSpell(this.GetPtr(), (SpellSlot)slot);
		}

		/// <summary>
		/// 	Upgrades a spell.
		/// </summary>
		/// <param name="slot">The spell slot.</param>
		// Token: 0x06000485 RID: 1157 RVA: 0x0000F06C File Offset: 0x0000E46C
		public void LevelSpell(SpellSlot slot)
		{
			<Module>.EnsoulSharp.Native.SpellbookClient.UpgradeSpell(this.GetPtr(), (SpellSlot)slot);
		}

		/// <summary>
		/// 	Gets the <see cref="T:EnsoulSharp.SpellState" /> of the given spell slot.
		/// </summary>
		/// <param name="slot">The spell slot.</param>
		/// <returns>The <see cref="T:EnsoulSharp.SpellState" /> of the given spell slot.</returns>
		// Token: 0x06000486 RID: 1158 RVA: 0x0000F088 File Offset: 0x0000E488
		public SpellState CanUseSpell(SpellSlot slot)
		{
			return (SpellState)<Module>.EnsoulSharp.Native.SpellbookClient.CanUseSpell(this.GetPtr(), (SpellSlot)slot);
		}

		/// <summary>
		/// 	Gets the spell data instance of the given spell slot.
		/// </summary>
		/// <param name="slot">The spell slot.</param>
		/// <returns>The spell data instance.</returns>
		// Token: 0x06000487 RID: 1159 RVA: 0x0000F0A4 File Offset: 0x0000E4A4
		public unsafe SpellDataInst GetSpell(SpellSlot slot)
		{
			if (slot < (SpellSlot)64)
			{
				SpellDataInstClient* ptr = *(slot * SpellSlot.Summoner1 + <Module>.EnsoulSharp.Native.SpellbookClient.GetSpellsDataClient(this.GetPtr()));
				if (ptr != null && *<Module>.EnsoulSharp.Native.SpellDataInstClient.GetSpellDataClient(ptr) != 0)
				{
					return new SpellDataInst(this.m_networkId, (uint)slot);
				}
			}
			return null;
		}

		// Token: 0x040003AA RID: 938
		private uint m_networkId;

		// Token: 0x040003AB RID: 939
		internal static Spellbook.OnCastSpellNativeDelegate m_CastSpellNativeDelegate;

		// Token: 0x040003AC RID: 940
		internal static Spellbook.OnStopCastNativeDelegate m_StopCastNativeDelegate;

		// Token: 0x040003AD RID: 941
		internal static Spellbook.OnUpdateChargedSpellNativeDelegate m_UpdateChargedSpellNativeDelegate;

		// Token: 0x040003AE RID: 942
		internal static IntPtr m_CastSpellNative = IntPtr.Zero;

		// Token: 0x040003AF RID: 943
		internal static IntPtr m_StopCastNative = IntPtr.Zero;

		// Token: 0x040003B0 RID: 944
		internal static IntPtr m_UpdateChargedSpellNative = IntPtr.Zero;

		// Token: 0x040003B1 RID: 945
		internal static List<SpellbookCastSpell> CastSpellHandlers = new List<SpellbookCastSpell>();

		// Token: 0x040003B2 RID: 946
		internal static List<SpellbookStopCast> StopCastHandlers = new List<SpellbookStopCast>();

		// Token: 0x040003B3 RID: 947
		internal static List<SpellbookUpdateChargedSpell> UpdateChargedSpellHandlers = new List<SpellbookUpdateChargedSpell>();

		// Token: 0x02000072 RID: 114
		// (Invoke) Token: 0x06000489 RID: 1161
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void OnCastSpellNativeDelegate(SpellbookClient* spellBook, SpellSlot slot, Vector3f* startPosition, Vector3f* endPosition, uint targetNetworkId, bool* process);

		// Token: 0x02000073 RID: 115
		// (Invoke) Token: 0x0600048D RID: 1165
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void OnStopCastNativeDelegate(SpellbookClient* spellBook, [MarshalAs(UnmanagedType.U1)] bool keepAnimationPlaying, [MarshalAs(UnmanagedType.U1)] bool hasBeenCast, bool* spellStopCancelled, [MarshalAs(UnmanagedType.U1)] bool destroyMissile, uint missileToDestroy, uint spellCastId);

		// Token: 0x02000074 RID: 116
		// (Invoke) Token: 0x06000491 RID: 1169
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void OnUpdateChargedSpellNativeDelegate(SpellbookClient* spellBook, SpellSlot slot, Vector3f* position, [MarshalAs(UnmanagedType.U1)] bool releaseCast, bool* process);
	}
}
