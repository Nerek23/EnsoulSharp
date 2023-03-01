using System;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000016 RID: 22
	public interface IOrbwalker : IDisposable
	{
		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060000C1 RID: 193
		// (set) Token: 0x060000C2 RID: 194
		AttackableUnit ForceTarget { get; set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060000C3 RID: 195
		// (set) Token: 0x060000C4 RID: 196
		AttackableUnit LastTarget { get; set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060000C5 RID: 197
		// (set) Token: 0x060000C6 RID: 198
		OrbwalkerMode ActiveMode { get; set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000C7 RID: 199
		// (set) Token: 0x060000C8 RID: 200
		int LastAutoAttackTick { get; set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000C9 RID: 201
		// (set) Token: 0x060000CA RID: 202
		int LastMovementTick { get; set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000CB RID: 203
		// (set) Token: 0x060000CC RID: 204
		bool AttackEnabled { get; set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000CD RID: 205
		// (set) Token: 0x060000CE RID: 206
		bool MoveEnabled { get; set; }

		// Token: 0x060000CF RID: 207
		bool IsAutoAttack(string name);

		// Token: 0x060000D0 RID: 208
		bool IsAutoAttackReset(string name);

		// Token: 0x060000D1 RID: 209
		void ResetAutoAttackTimer();

		// Token: 0x060000D2 RID: 210
		void SetOrbwalkerPosition(Vector3 position);

		// Token: 0x060000D3 RID: 211
		void SetPauseTime(int time);

		// Token: 0x060000D4 RID: 212
		void SetServerPauseTime();

		// Token: 0x060000D5 RID: 213
		void SetAttackPauseTime(int time);

		// Token: 0x060000D6 RID: 214
		void SetAttackServerPauseTime();

		// Token: 0x060000D7 RID: 215
		void SetMovePauseTime(int time);

		// Token: 0x060000D8 RID: 216
		void SetMoveServerPauseTime();

		// Token: 0x060000D9 RID: 217
		AttackableUnit GetTarget();

		// Token: 0x060000DA RID: 218
		bool CanAttack();

		// Token: 0x060000DB RID: 219
		bool CanAttack(float extraWindup);

		// Token: 0x060000DC RID: 220
		bool CanMove();

		// Token: 0x060000DD RID: 221
		bool CanMove(float extraWindup, bool disableMissileCheck);

		// Token: 0x060000DE RID: 222
		bool Attack(AttackableUnit target);

		// Token: 0x060000DF RID: 223
		void Move(Vector3 position);

		// Token: 0x060000E0 RID: 224
		void Orbwalk(AttackableUnit target, Vector3 position);
	}
}
