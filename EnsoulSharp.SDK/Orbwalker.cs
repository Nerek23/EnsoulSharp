using System;
using System.Collections.Generic;
using System.Linq;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000017 RID: 23
	public class Orbwalker
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x060000E1 RID: 225 RVA: 0x00007270 File Offset: 0x00005470
		// (remove) Token: 0x060000E2 RID: 226 RVA: 0x000072A4 File Offset: 0x000054A4
		public static event EventHandler<AfterAttackEventArgs> OnAfterAttack;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x060000E3 RID: 227 RVA: 0x000072D8 File Offset: 0x000054D8
		// (remove) Token: 0x060000E4 RID: 228 RVA: 0x0000730C File Offset: 0x0000550C
		public static event EventHandler<BeforeAttackEventArgs> OnBeforeAttack;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x060000E5 RID: 229 RVA: 0x00007340 File Offset: 0x00005540
		// (remove) Token: 0x060000E6 RID: 230 RVA: 0x00007374 File Offset: 0x00005574
		public static event EventHandler<AttackingEventArgs> OnAttack;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x060000E7 RID: 231 RVA: 0x000073A8 File Offset: 0x000055A8
		// (remove) Token: 0x060000E8 RID: 232 RVA: 0x000073DC File Offset: 0x000055DC
		public static event EventHandler<NonKillableMinionEventArgs> OnNonKillableMinion;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x060000E9 RID: 233 RVA: 0x00007410 File Offset: 0x00005610
		// (remove) Token: 0x060000EA RID: 234 RVA: 0x00007444 File Offset: 0x00005644
		public static event EventHandler<BeforeMoveEventArgs> OnBeforeMove;

		// Token: 0x060000EB RID: 235 RVA: 0x00007477 File Offset: 0x00005677
		internal static void Initialize()
		{
			if (Orbwalker._initialize)
			{
				return;
			}
			Orbwalker._initialize = true;
			Orbwalker.Implementations.Add("SDK", new OrbwalkerSDK());
			Orbwalker.Implementation = Orbwalker.Implementations["SDK"];
		}

		// Token: 0x060000EC RID: 236 RVA: 0x000074AF File Offset: 0x000056AF
		internal static void RemoveSDK()
		{
			if (Orbwalker.Implementations.ContainsKey("SDK"))
			{
				Orbwalker.Implementations.Remove("SDK");
			}
		}

		// Token: 0x060000ED RID: 237 RVA: 0x000074D2 File Offset: 0x000056D2
		public static void AddOrbwalker(string name, IOrbwalker orb)
		{
			if (Orbwalker.Implementations.ContainsKey(name))
			{
				Console.WriteLine("Cant not Add {0} Orbwalker bcz already have it!", name);
				return;
			}
			Orbwalker.Implementations.Add(name, orb);
		}

		// Token: 0x060000EE RID: 238 RVA: 0x000074F9 File Offset: 0x000056F9
		public static void SetOrbwalker(string name)
		{
			if (Orbwalker.Implementations.ContainsKey(name))
			{
				Orbwalker.Implementation = Orbwalker.Implementations[name];
				return;
			}
			Console.WriteLine("Cant not Set {0} to Default Orbwalker", name);
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00007524 File Offset: 0x00005724
		public static IOrbwalker GetOrbwalker(string name)
		{
			if (!Orbwalker.Implementations.ContainsKey(name))
			{
				return null;
			}
			return Orbwalker.Implementations[name];
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000F0 RID: 240 RVA: 0x00007540 File Offset: 0x00005740
		// (set) Token: 0x060000F1 RID: 241 RVA: 0x00007568 File Offset: 0x00005768
		public static AttackableUnit ForceTarget
		{
			get
			{
				if (Orbwalker.Implementation == null)
				{
					return Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().ForceTarget;
				}
				return Orbwalker.Implementation.ForceTarget;
			}
			set
			{
				if (Orbwalker.Implementation == null)
				{
					Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().ForceTarget = value;
					return;
				}
				Orbwalker.Implementation.ForceTarget = value;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000F2 RID: 242 RVA: 0x00007592 File Offset: 0x00005792
		// (set) Token: 0x060000F3 RID: 243 RVA: 0x000075BA File Offset: 0x000057BA
		public static AttackableUnit LastTarget
		{
			get
			{
				if (Orbwalker.Implementation == null)
				{
					return Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().LastTarget;
				}
				return Orbwalker.Implementation.LastTarget;
			}
			set
			{
				if (Orbwalker.Implementation == null)
				{
					Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().LastTarget = value;
					return;
				}
				Orbwalker.Implementation.LastTarget = value;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000F4 RID: 244 RVA: 0x000075E4 File Offset: 0x000057E4
		// (set) Token: 0x060000F5 RID: 245 RVA: 0x0000760C File Offset: 0x0000580C
		public static int LastAutoAttackTick
		{
			get
			{
				if (Orbwalker.Implementation == null)
				{
					return Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().LastAutoAttackTick;
				}
				return Orbwalker.Implementation.LastAutoAttackTick;
			}
			set
			{
				if (Orbwalker.Implementation == null)
				{
					Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().LastAutoAttackTick = value;
					return;
				}
				Orbwalker.Implementation.LastAutoAttackTick = value;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000F6 RID: 246 RVA: 0x00007636 File Offset: 0x00005836
		// (set) Token: 0x060000F7 RID: 247 RVA: 0x0000765E File Offset: 0x0000585E
		public static int LastMovementTick
		{
			get
			{
				if (Orbwalker.Implementation == null)
				{
					return Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().LastMovementTick;
				}
				return Orbwalker.Implementation.LastMovementTick;
			}
			set
			{
				if (Orbwalker.Implementation == null)
				{
					Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().LastMovementTick = value;
					return;
				}
				Orbwalker.Implementation.LastMovementTick = value;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000F8 RID: 248 RVA: 0x00007688 File Offset: 0x00005888
		// (set) Token: 0x060000F9 RID: 249 RVA: 0x000076B0 File Offset: 0x000058B0
		public static OrbwalkerMode ActiveMode
		{
			get
			{
				if (Orbwalker.Implementation == null)
				{
					return Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().ActiveMode;
				}
				return Orbwalker.Implementation.ActiveMode;
			}
			set
			{
				if (Orbwalker.Implementation == null)
				{
					Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().ActiveMode = value;
					return;
				}
				Orbwalker.Implementation.ActiveMode = value;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000FA RID: 250 RVA: 0x000076DA File Offset: 0x000058DA
		// (set) Token: 0x060000FB RID: 251 RVA: 0x00007702 File Offset: 0x00005902
		public static bool AttackEnabled
		{
			get
			{
				if (Orbwalker.Implementation == null)
				{
					return Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().AttackEnabled;
				}
				return Orbwalker.Implementation.AttackEnabled;
			}
			set
			{
				if (Orbwalker.Implementation == null)
				{
					Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().AttackEnabled = value;
					return;
				}
				Orbwalker.Implementation.AttackEnabled = value;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000FC RID: 252 RVA: 0x0000772C File Offset: 0x0000592C
		// (set) Token: 0x060000FD RID: 253 RVA: 0x00007754 File Offset: 0x00005954
		public static bool MoveEnabled
		{
			get
			{
				if (Orbwalker.Implementation == null)
				{
					return Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().MoveEnabled;
				}
				return Orbwalker.Implementation.MoveEnabled;
			}
			set
			{
				if (Orbwalker.Implementation == null)
				{
					Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().MoveEnabled = value;
					return;
				}
				Orbwalker.Implementation.MoveEnabled = value;
			}
		}

		// Token: 0x060000FE RID: 254 RVA: 0x0000777E File Offset: 0x0000597E
		public static bool CanAttack()
		{
			if (Orbwalker.Implementation == null)
			{
				return Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().CanAttack();
			}
			return Orbwalker.Implementation.CanAttack();
		}

		// Token: 0x060000FF RID: 255 RVA: 0x000077A6 File Offset: 0x000059A6
		public static bool CanAttack(float extraWindup)
		{
			if (Orbwalker.Implementation == null)
			{
				return Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().CanAttack(extraWindup);
			}
			return Orbwalker.Implementation.CanAttack(extraWindup);
		}

		// Token: 0x06000100 RID: 256 RVA: 0x000077D0 File Offset: 0x000059D0
		public static bool CanMove()
		{
			if (Orbwalker.Implementation == null)
			{
				return Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().CanMove();
			}
			return Orbwalker.Implementation.CanMove();
		}

		// Token: 0x06000101 RID: 257 RVA: 0x000077F8 File Offset: 0x000059F8
		public static bool CanMove(float extraWindup, bool disableMissileCheck)
		{
			if (Orbwalker.Implementation == null)
			{
				return Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().CanMove(extraWindup, disableMissileCheck);
			}
			return Orbwalker.Implementation.CanMove(extraWindup, disableMissileCheck);
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00007824 File Offset: 0x00005A24
		public static AttackableUnit GetTarget()
		{
			if (Orbwalker.Implementation == null)
			{
				return Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().GetTarget();
			}
			return Orbwalker.Implementation.GetTarget();
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000784C File Offset: 0x00005A4C
		public static bool IsAutoAttack(string name)
		{
			if (Orbwalker.Implementation == null)
			{
				return Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().IsAutoAttack(name);
			}
			return Orbwalker.Implementation.IsAutoAttack(name);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00007876 File Offset: 0x00005A76
		public static bool IsAutoAttackReset(string name)
		{
			if (Orbwalker.Implementation == null)
			{
				return Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().IsAutoAttackReset(name);
			}
			return Orbwalker.Implementation.IsAutoAttackReset(name);
		}

		// Token: 0x06000105 RID: 261 RVA: 0x000078A0 File Offset: 0x00005AA0
		public static void Attack(AttackableUnit target)
		{
			if (Orbwalker.Implementation == null)
			{
				Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().Attack(target);
				return;
			}
			Orbwalker.Implementation.Attack(target);
		}

		// Token: 0x06000106 RID: 262 RVA: 0x000078CC File Offset: 0x00005ACC
		public static void Move(Vector3 position)
		{
			if (Orbwalker.Implementation == null)
			{
				Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().Move(position);
				return;
			}
			Orbwalker.Implementation.Move(position);
		}

		// Token: 0x06000107 RID: 263 RVA: 0x000078F6 File Offset: 0x00005AF6
		public static void Orbwalk(AttackableUnit target, Vector3 position)
		{
			if (Orbwalker.Implementation == null)
			{
				Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().Orbwalk(target, position);
				return;
			}
			Orbwalker.Implementation.Orbwalk(target, position);
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00007922 File Offset: 0x00005B22
		public static void ResetAutoAttackTimer()
		{
			if (Orbwalker.Implementation == null)
			{
				Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().ResetAutoAttackTimer();
				return;
			}
			Orbwalker.Implementation.ResetAutoAttackTimer();
		}

		// Token: 0x06000109 RID: 265 RVA: 0x0000794A File Offset: 0x00005B4A
		public static void SetOrbwalkerPosition(Vector3 position)
		{
			if (Orbwalker.Implementation == null)
			{
				Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().SetOrbwalkerPosition(position);
				return;
			}
			Orbwalker.Implementation.SetOrbwalkerPosition(position);
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00007974 File Offset: 0x00005B74
		public static void SetPauseTime(int time)
		{
			if (Orbwalker.Implementation == null)
			{
				Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().SetPauseTime(time);
				return;
			}
			Orbwalker.Implementation.SetPauseTime(time);
		}

		// Token: 0x0600010B RID: 267 RVA: 0x0000799E File Offset: 0x00005B9E
		public static void SetServerPauseTime()
		{
			if (Orbwalker.Implementation == null)
			{
				Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().SetServerPauseTime();
				return;
			}
			Orbwalker.Implementation.SetServerPauseTime();
		}

		// Token: 0x0600010C RID: 268 RVA: 0x000079C6 File Offset: 0x00005BC6
		public static void SetAttackPauseTime(int time)
		{
			if (Orbwalker.Implementation == null)
			{
				Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().SetAttackPauseTime(time);
				return;
			}
			Orbwalker.Implementation.SetAttackPauseTime(time);
		}

		// Token: 0x0600010D RID: 269 RVA: 0x000079F0 File Offset: 0x00005BF0
		public static void SetAttackServerPauseTime()
		{
			if (Orbwalker.Implementation == null)
			{
				Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().SetAttackServerPauseTime();
				return;
			}
			Orbwalker.Implementation.SetAttackServerPauseTime();
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00007A18 File Offset: 0x00005C18
		public static void SetMovePauseTime(int time)
		{
			if (Orbwalker.Implementation == null)
			{
				Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().SetMovePauseTime(time);
				return;
			}
			Orbwalker.Implementation.SetMovePauseTime(time);
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00007A42 File Offset: 0x00005C42
		public static void SetMoveServerPauseTime()
		{
			if (Orbwalker.Implementation == null)
			{
				Orbwalker.Implementations.Values.FirstOrDefault<IOrbwalker>().SetMoveServerPauseTime();
				return;
			}
			Orbwalker.Implementation.SetMoveServerPauseTime();
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00007A6C File Offset: 0x00005C6C
		public static void FireNonKillableMinion(AttackableUnit target, string orbwalkerName)
		{
			NonKillableMinionEventArgs e = new NonKillableMinionEventArgs
			{
				Target = target,
				OrbwalkerName = orbwalkerName
			};
			EventHandler<NonKillableMinionEventArgs> onNonKillableMinion = Orbwalker.OnNonKillableMinion;
			if (onNonKillableMinion == null)
			{
				return;
			}
			onNonKillableMinion(null, e);
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00007AA0 File Offset: 0x00005CA0
		public static BeforeAttackEventArgs FireBeforeAttack(AttackableUnit target, string orbwalkerName)
		{
			BeforeAttackEventArgs beforeAttackEventArgs = new BeforeAttackEventArgs
			{
				Target = target,
				OrbwalkerName = orbwalkerName
			};
			EventHandler<BeforeAttackEventArgs> onBeforeAttack = Orbwalker.OnBeforeAttack;
			if (onBeforeAttack != null)
			{
				onBeforeAttack(null, beforeAttackEventArgs);
			}
			return beforeAttackEventArgs;
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00007AD4 File Offset: 0x00005CD4
		public static void FireAfterAttack(AttackableUnit target, string orbwalkerName)
		{
			AfterAttackEventArgs e = new AfterAttackEventArgs
			{
				Target = target,
				OrbwalkerName = orbwalkerName
			};
			EventHandler<AfterAttackEventArgs> onAfterAttack = Orbwalker.OnAfterAttack;
			if (onAfterAttack == null)
			{
				return;
			}
			onAfterAttack(null, e);
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00007B08 File Offset: 0x00005D08
		public static void FireOnAttack(AttackableUnit target, string orbwalkerName)
		{
			AttackingEventArgs e = new AttackingEventArgs
			{
				Target = target,
				OrbwalkerName = orbwalkerName
			};
			EventHandler<AttackingEventArgs> onAttack = Orbwalker.OnAttack;
			if (onAttack == null)
			{
				return;
			}
			onAttack(null, e);
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00007B3C File Offset: 0x00005D3C
		public static BeforeMoveEventArgs FirePreMove(Vector3 position, string orbwalkerName)
		{
			BeforeMoveEventArgs beforeMoveEventArgs = new BeforeMoveEventArgs
			{
				MovePosition = position,
				OrbwalkerName = orbwalkerName
			};
			EventHandler<BeforeMoveEventArgs> onBeforeMove = Orbwalker.OnBeforeMove;
			if (onBeforeMove != null)
			{
				onBeforeMove(null, beforeMoveEventArgs);
			}
			return beforeMoveEventArgs;
		}

		// Token: 0x04000085 RID: 133
		private static bool _initialize;

		// Token: 0x04000086 RID: 134
		private static IOrbwalker Implementation;

		// Token: 0x04000087 RID: 135
		private static readonly Dictionary<string, IOrbwalker> Implementations = new Dictionary<string, IOrbwalker>();
	}
}
