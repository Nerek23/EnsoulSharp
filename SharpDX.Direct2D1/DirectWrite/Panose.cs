using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000161 RID: 353
	public struct Panose
	{
		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06000670 RID: 1648 RVA: 0x00014B2C File Offset: 0x00012D2C
		// (set) Token: 0x06000671 RID: 1649 RVA: 0x00014B53 File Offset: 0x00012D53
		public byte[] Values
		{
			get
			{
				byte[] result;
				if ((result = this._Values) == null)
				{
					result = (this._Values = new byte[10]);
				}
				return result;
			}
			private set
			{
				this._Values = value;
			}
		}

		// Token: 0x06000672 RID: 1650 RVA: 0x00009E0F File Offset: 0x0000800F
		internal void __MarshalFree(ref Panose.__Native @ref)
		{
		}

		// Token: 0x06000673 RID: 1651 RVA: 0x00014B5C File Offset: 0x00012D5C
		internal unsafe void __MarshalFrom(ref Panose.__Native @ref)
		{
			fixed (byte* ptr = &this.Values[0])
			{
				void* value = (void*)ptr;
				fixed (byte* ptr2 = &@ref.Values)
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value, (IntPtr)value2, 10);
					ptr = null;
				}
				this.FamilyKind = @ref.FamilyKind;
				this.Text = @ref.Text;
				this.Script = @ref.Script;
				this.Decorative = @ref.Decorative;
				this.Symbol = @ref.Symbol;
			}
		}

		// Token: 0x06000674 RID: 1652 RVA: 0x00014BD8 File Offset: 0x00012DD8
		internal unsafe void __MarshalTo(ref Panose.__Native @ref)
		{
			fixed (byte* ptr = &this.Values[0])
			{
				void* value = (void*)ptr;
				fixed (byte* ptr2 = &@ref.Values)
				{
					void* value2 = (void*)ptr2;
					Utilities.CopyMemory((IntPtr)value2, (IntPtr)value, 10);
					ptr = null;
				}
				@ref.FamilyKind = this.FamilyKind;
				@ref.Text = this.Text;
				@ref.Script = this.Script;
				@ref.Decorative = this.Decorative;
				@ref.Symbol = this.Symbol;
			}
		}

		// Token: 0x04000566 RID: 1382
		internal byte[] _Values;

		// Token: 0x04000567 RID: 1383
		public byte FamilyKind;

		// Token: 0x04000568 RID: 1384
		public PanoseText Text;

		// Token: 0x04000569 RID: 1385
		public PanoseScript Script;

		// Token: 0x0400056A RID: 1386
		public PanoseDecorative Decorative;

		// Token: 0x0400056B RID: 1387
		public PanoseSymbol Symbol;

		// Token: 0x02000162 RID: 354
		[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x0400056C RID: 1388
			[FieldOffset(0)]
			public byte Values;

			// Token: 0x0400056D RID: 1389
			[FieldOffset(1)]
			public byte __Values1;

			// Token: 0x0400056E RID: 1390
			[FieldOffset(2)]
			public byte __Values2;

			// Token: 0x0400056F RID: 1391
			[FieldOffset(3)]
			public byte __Values3;

			// Token: 0x04000570 RID: 1392
			[FieldOffset(4)]
			public byte __Values4;

			// Token: 0x04000571 RID: 1393
			[FieldOffset(5)]
			public byte __Values5;

			// Token: 0x04000572 RID: 1394
			[FieldOffset(6)]
			public byte __Values6;

			// Token: 0x04000573 RID: 1395
			[FieldOffset(7)]
			public byte __Values7;

			// Token: 0x04000574 RID: 1396
			[FieldOffset(8)]
			public byte __Values8;

			// Token: 0x04000575 RID: 1397
			[FieldOffset(9)]
			public byte __Values9;

			// Token: 0x04000576 RID: 1398
			[FieldOffset(0)]
			public byte FamilyKind;

			// Token: 0x04000577 RID: 1399
			[FieldOffset(0)]
			public PanoseText Text;

			// Token: 0x04000578 RID: 1400
			[FieldOffset(0)]
			public PanoseScript Script;

			// Token: 0x04000579 RID: 1401
			[FieldOffset(0)]
			public PanoseDecorative Decorative;

			// Token: 0x0400057A RID: 1402
			[FieldOffset(0)]
			public PanoseSymbol Symbol;
		}
	}
}
