using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security;
using EnsoulSharp.Native;
using SharpDX;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to each MissileClient object.
	/// </summary>
	// Token: 0x02000151 RID: 337
	public class MissileClient : GameObject
	{
		// Token: 0x06000659 RID: 1625 RVA: 0x00005C8C File Offset: 0x0000508C
		internal MissileClient()
		{
		}

		// Token: 0x0600065A RID: 1626 RVA: 0x00005C74 File Offset: 0x00005074
		internal MissileClient(uint networkId, uint index) : base(networkId, index)
		{
		}

		// Token: 0x0600065B RID: 1627 RVA: 0x000016D8 File Offset: 0x00000AD8
		internal new unsafe MissileClient* GetPtr()
		{
			return (MissileClient*)base.GetPtr();
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x0000D3CC File Offset: 0x0000C7CC
		static MissileClient()
		{
			AppDomain.CurrentDomain.DomainUnload += MissileClient.DomainUnloadEventHandler;
			MissileClient.m_CommitMovementNativeDelegate = new MissileClient.OnCommitMovementNativeDelegate(MissileClient.OnCommitMovementNative);
			MissileClient.m_CommitMovementNative = Marshal.GetFunctionPointerForDelegate<MissileClient.OnCommitMovementNativeDelegate>(MissileClient.m_CommitMovementNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::MissileClient\u0020*,int\u0020*,int\u0020*)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetMissileClientCommitMovementHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), MissileClient.m_CommitMovementNative.ToPointer());
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x0000CD70 File Offset: 0x0000C170
		internal new static void DomainUnloadEventHandler(object sender, EventArgs args)
		{
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(EnsoulSharp::Native::MissileClient\u0020*,int\u0020*,int\u0020*)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetMissileClientCommitMovementHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), MissileClient.m_CommitMovementNative.ToPointer());
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x0000CD98 File Offset: 0x0000C198
		[SecurityCritical]
		[HandleProcessCorruptedStateExceptions]
		internal unsafe static void OnCommitMovementNative(MissileClient* missileClient, int* x, int* y)
		{
			MissileClientCommitMovement[] array = null;
			try
			{
				MissileClient missileClient2 = ObjectManager.CreateObjectFromPointer((GameObject*)missileClient) as MissileClient;
				if (missileClient2 != null)
				{
					Vector2 position = new Vector2((float)(*x), (float)(*y));
					MissileClientCommitMovementEventArgs missileClientCommitMovementEventArgs = new MissileClientCommitMovementEventArgs(position);
					foreach (MissileClientCommitMovement missileClientCommitMovement in MissileClient.CommitMovementHandlers.ToArray())
					{
						try
						{
							missileClientCommitMovement(missileClient2, missileClientCommitMovementEventArgs);
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
					*x = (int)((double)missileClientCommitMovementEventArgs.Position.X);
					*y = (int)((double)missileClientCommitMovementEventArgs.Position.Y);
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
		/// 	This event is fired before committing movement.
		/// </summary>
		// Token: 0x14000026 RID: 38
		// (add) Token: 0x0600065F RID: 1631 RVA: 0x0000D09C File Offset: 0x0000C49C
		// (remove) Token: 0x06000660 RID: 1632 RVA: 0x0000D0B4 File Offset: 0x0000C4B4
		public static event MissileClientCommitMovement OnCommitMovement
		{
			add
			{
				MissileClient.CommitMovementHandlers.Add(value);
			}
			remove
			{
				MissileClient.CommitMovementHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	Gets the spell cast info of the object.
		/// </summary>
		// Token: 0x17000166 RID: 358
		// (get) Token: 0x06000661 RID: 1633 RVA: 0x0000D0D0 File Offset: 0x0000C4D0
		public unsafe AIBaseClientProcessSpellCastEventArgs CastInfo
		{
			get
			{
				SpellCastInfo* ptr = <Module>.EnsoulSharp.Native.Missile.GetCastInfo(this.GetPtr());
				uint targetLocalId;
				if (*<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetObjID(ptr) != 0)
				{
					targetLocalId = (uint)(*(*<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetObjID(ptr)));
				}
				else
				{
					targetLocalId = 0U;
				}
				Vector3 end = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetEndPosition(ptr)), <Module>.EnsoulSharp.Native.Vector3f.GetZ(<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetEndPosition(ptr)), <Module>.EnsoulSharp.Native.Vector3f.GetY(<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetEndPosition(ptr)));
				Vector3 to = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetPosition(ptr)), <Module>.EnsoulSharp.Native.Vector3f.GetZ(<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetPosition(ptr)), <Module>.EnsoulSharp.Native.Vector3f.GetY(<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetPosition(ptr)));
				Vector3 start = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(<Module>.EnsoulSharp.Native.SpellCastInfo.GetSpellCastLaunchPos(ptr)), <Module>.EnsoulSharp.Native.Vector3f.GetZ(<Module>.EnsoulSharp.Native.SpellCastInfo.GetSpellCastLaunchPos(ptr)), <Module>.EnsoulSharp.Native.Vector3f.GetY(<Module>.EnsoulSharp.Native.SpellCastInfo.GetSpellCastLaunchPos(ptr)));
				SpellData sdata = (*<Module>.EnsoulSharp.Native.SpellCastInfo.GetSData(ptr) == 0) ? null : new SpellData(*<Module>.EnsoulSharp.Native.SpellCastInfo.GetSData(ptr));
				int slot = *<Module>.EnsoulSharp.Native.SpellCastInfo.GetSlot(ptr);
				float totalTime = *<Module>.EnsoulSharp.Native.SpellCastInfo.GetDesignerTotalTime(ptr);
				float num = *<Module>.EnsoulSharp.Native.SpellCastInfo.GetDesignerCastTime(ptr);
				float num2 = *<Module>.EnsoulSharp.Native.SpellCastInfo.GetExtraTimeForCast(ptr);
				int missileNetworkId = *<Module>.EnsoulSharp.Native.SpellCastInfo.GetMissileNetworkID(ptr);
				int* ptr2 = <Module>.EnsoulSharp.Native.SpellCastInfo.GetSpellLevel(ptr);
				return new AIBaseClientProcessSpellCastEventArgs(sdata, *ptr2 + 1, start, to, end, (int)targetLocalId, missileNetworkId, (float)((double)num2 + (double)num), totalTime, (SpellSlot)slot);
			}
		}

		/// <summary>
		/// 	Gets the spell data of the object.
		/// </summary>
		// Token: 0x17000165 RID: 357
		// (get) Token: 0x06000662 RID: 1634 RVA: 0x0000D1E0 File Offset: 0x0000C5E0
		public unsafe SpellData SData
		{
			get
			{
				SpellData* ptr = *<Module>.EnsoulSharp.Native.SpellCastInfo.GetSData(<Module>.EnsoulSharp.Native.Missile.GetCastInfo(this.GetPtr()));
				if (ptr != null)
				{
					return new SpellData(ptr);
				}
				return null;
			}
		}

		/// <summary>
		/// 	Gets the spell caster of the object.
		/// </summary>
		// Token: 0x17000164 RID: 356
		// (get) Token: 0x06000663 RID: 1635 RVA: 0x0000D20C File Offset: 0x0000C60C
		public unsafe AIBaseClient SpellCaster
		{
			get
			{
				return ObjectManager.CreateObjectFromPointer(<Module>.EnsoulSharp.Native.ObjectManager.GetUnitByIndex((uint)(*<Module>.EnsoulSharp.Native.SpellCastInfo.GetCasterObjID(<Module>.EnsoulSharp.Native.Missile.GetCastInfo(this.GetPtr())))));
			}
		}

		/// <summary>
		/// 	Gets the start position of the object.
		/// </summary>
		// Token: 0x17000163 RID: 355
		// (get) Token: 0x06000664 RID: 1636 RVA: 0x0000D234 File Offset: 0x0000C634
		public unsafe Vector3 StartPosition
		{
			get
			{
				MissileMovement* ptr = *<Module>.EnsoulSharp.Native.Missile.GetMovement(this.GetPtr());
				if (ptr != null)
				{
					Vector3f* ptr2 = <Module>.EnsoulSharp.Native.MissileMovement.GetMovementStartPosition(ptr);
					Vector3 result = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(ptr2), <Module>.EnsoulSharp.Native.Vector3f.GetZ(ptr2), <Module>.EnsoulSharp.Native.Vector3f.GetY(ptr2));
					return result;
				}
				return Vector3.Zero;
			}
		}

		/// <summary>
		/// 	Gets the end position of the object.
		/// </summary>
		// Token: 0x17000162 RID: 354
		// (get) Token: 0x06000665 RID: 1637 RVA: 0x0000D278 File Offset: 0x0000C678
		public unsafe Vector3 EndPosition
		{
			get
			{
				MissileMovement* ptr = *<Module>.EnsoulSharp.Native.Missile.GetMovement(this.GetPtr());
				if (ptr != null)
				{
					Vector3f* ptr2 = <Module>.EnsoulSharp.Native.MissileMovement.GetTargetPosition(ptr);
					Vector3 result = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(ptr2), <Module>.EnsoulSharp.Native.Vector3f.GetZ(ptr2), <Module>.EnsoulSharp.Native.Vector3f.GetY(ptr2));
					return result;
				}
				return Vector3.Zero;
			}
		}

		/// <summary>
		/// 	Gets the spell target of the object.
		/// </summary>
		// Token: 0x17000161 RID: 353
		// (get) Token: 0x06000666 RID: 1638 RVA: 0x0000D2BC File Offset: 0x0000C6BC
		public unsafe GameObject Target
		{
			get
			{
				uint* ptr = *<Module>.EnsoulSharp.Native.SpellCastInfo.GetTargetObjID(<Module>.EnsoulSharp.Native.Missile.GetCastInfo(this.GetPtr()));
				if (ptr != null)
				{
					return ObjectManager.CreateObjectFromPointer(<Module>.EnsoulSharp.Native.ObjectManager.GetUnitByIndex(*ptr));
				}
				return null;
			}
		}

		/// <summary>
		/// 	Gets the spell slot of the object.
		/// </summary>
		// Token: 0x17000160 RID: 352
		// (get) Token: 0x06000667 RID: 1639 RVA: 0x0000D2EC File Offset: 0x0000C6EC
		public unsafe SpellSlot Slot
		{
			get
			{
				return (SpellSlot)(*<Module>.EnsoulSharp.Native.SpellCastInfo.GetSlot(<Module>.EnsoulSharp.Native.Missile.GetCastInfo(this.GetPtr())));
			}
		}

		/// <summary>
		/// 	Gets the start time of the object.
		/// </summary>
		// Token: 0x1700015F RID: 351
		// (get) Token: 0x06000668 RID: 1640 RVA: 0x0000D30C File Offset: 0x0000C70C
		public unsafe float StartTime
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.Missile.GetStartTime(this.GetPtr());
			}
		}

		/// <summary>
		/// 	Gets the speed of the object.
		/// </summary>
		// Token: 0x1700015E RID: 350
		// (get) Token: 0x06000669 RID: 1641 RVA: 0x0000D328 File Offset: 0x0000C728
		public unsafe float Speed
		{
			get
			{
				MissileMovement* ptr = *<Module>.EnsoulSharp.Native.Missile.GetMovement(this.GetPtr());
				if (ptr != null)
				{
					return *<Module>.EnsoulSharp.Native.MissileMovement.GetSpeed(ptr);
				}
				return 0f;
			}
		}

		/// <summary>
		/// 	Gets the width of the object.
		/// </summary>
		// Token: 0x1700015D RID: 349
		// (get) Token: 0x0600066A RID: 1642 RVA: 0x0000D354 File Offset: 0x0000C754
		public unsafe float Width
		{
			get
			{
				return *<Module>.EnsoulSharp.Native.Missile.GetWidth(this.GetPtr());
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is complete.
		/// </summary>
		// Token: 0x1700015C RID: 348
		// (get) Token: 0x0600066B RID: 1643 RVA: 0x0000D370 File Offset: 0x0000C770
		public unsafe bool IsComplete
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				MissileMovement* ptr = *<Module>.EnsoulSharp.Native.Missile.GetMovement(this.GetPtr());
				return ptr != null && *<Module>.EnsoulSharp.Native.MissileMovement.GetIsComplete(ptr) != 0;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is destroyed.
		/// </summary>
		// Token: 0x1700015B RID: 347
		// (get) Token: 0x0600066C RID: 1644 RVA: 0x0000D398 File Offset: 0x0000C798
		public unsafe bool IsDestroyed
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return *<Module>.EnsoulSharp.Native.Missile.GetDestroyed(this.GetPtr()) != 0;
			}
		}

		/// <summary>
		/// 	Gets a value indicating whether the object is visible.
		/// </summary>
		// Token: 0x1700015A RID: 346
		// (get) Token: 0x0600066D RID: 1645 RVA: 0x0000D3B4 File Offset: 0x0000C7B4
		public bool IsVisible
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return <Module>.EnsoulSharp.Native.Missile.IsVisible(this.GetPtr()) != null;
			}
		}

		// Token: 0x0400040A RID: 1034
		internal static MissileClient.OnCommitMovementNativeDelegate m_CommitMovementNativeDelegate;

		// Token: 0x0400040B RID: 1035
		internal static IntPtr m_CommitMovementNative = IntPtr.Zero;

		// Token: 0x0400040C RID: 1036
		internal static List<MissileClientCommitMovement> CommitMovementHandlers = new List<MissileClientCommitMovement>();

		// Token: 0x02000152 RID: 338
		// (Invoke) Token: 0x0600066F RID: 1647
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void OnCommitMovementNativeDelegate(MissileClient* missileClient, int* x, int* y);
	}
}
