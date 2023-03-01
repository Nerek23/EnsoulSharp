using System;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1.Effects
{
	// Token: 0x02000345 RID: 837
	public class ConvolveMatrix : Effect
	{
		// Token: 0x06000E4E RID: 3662 RVA: 0x00026F42 File Offset: 0x00025142
		public ConvolveMatrix(DeviceContext context) : base(context, Effect.ConvolveMatrix)
		{
		}

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x06000E4F RID: 3663 RVA: 0x00026F50 File Offset: 0x00025150
		// (set) Token: 0x06000E50 RID: 3664 RVA: 0x00026F59 File Offset: 0x00025159
		public float KernelUnitLength
		{
			get
			{
				return base.GetFloatValue(0);
			}
			set
			{
				base.SetValue(0, value);
			}
		}

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x06000E51 RID: 3665 RVA: 0x00026F63 File Offset: 0x00025163
		// (set) Token: 0x06000E52 RID: 3666 RVA: 0x00026F6C File Offset: 0x0002516C
		public ConvoleMatrixScaleMode ScaleMode
		{
			get
			{
				return base.GetEnumValue<ConvoleMatrixScaleMode>(1);
			}
			set
			{
				base.SetEnumValue<ConvoleMatrixScaleMode>(1, value);
			}
		}

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x06000E53 RID: 3667 RVA: 0x00026F76 File Offset: 0x00025176
		// (set) Token: 0x06000E54 RID: 3668 RVA: 0x00026F7F File Offset: 0x0002517F
		public int KernelSizeX
		{
			get
			{
				return (int)base.GetUIntValue(2);
			}
			set
			{
				base.SetValue(2, (uint)value);
			}
		}

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x06000E55 RID: 3669 RVA: 0x00026F89 File Offset: 0x00025189
		// (set) Token: 0x06000E56 RID: 3670 RVA: 0x00026F92 File Offset: 0x00025192
		public int KernelSizeY
		{
			get
			{
				return (int)base.GetUIntValue(3);
			}
			set
			{
				base.SetValue(3, (uint)value);
			}
		}

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x06000E57 RID: 3671 RVA: 0x00026F9C File Offset: 0x0002519C
		// (set) Token: 0x06000E58 RID: 3672 RVA: 0x00027010 File Offset: 0x00025210
		public unsafe float[] KernelMatrix
		{
			get
			{
				if (this.kernelMatrix == null)
				{
					this.kernelMatrix = new float[this.KernelSizeX * this.KernelSizeY];
				}
				if (this.kernelMatrix.Length != 0)
				{
					float[] array;
					void* value;
					if ((array = this.kernelMatrix) == null || array.Length == 0)
					{
						value = null;
					}
					else
					{
						value = (void*)(&array[0]);
					}
					base.GetValue(4, PropertyType.Blob, (IntPtr)value, 4 * this.kernelMatrix.Length);
					array = null;
				}
				return this.kernelMatrix;
			}
			set
			{
				if (value.Length != this.KernelSizeX * this.KernelSizeY)
				{
					throw new ArgumentException("Size of the array doesn't match KernelSizeX * KernelSizeY");
				}
				this.kernelMatrix = value;
				float[] array;
				void* value2;
				if ((array = this.kernelMatrix) == null || array.Length == 0)
				{
					value2 = null;
				}
				else
				{
					value2 = (void*)(&array[0]);
				}
				base.SetValue(4, PropertyType.Blob, (IntPtr)value2, 4 * this.kernelMatrix.Length);
				array = null;
			}
		}

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x06000E59 RID: 3673 RVA: 0x00027079 File Offset: 0x00025279
		// (set) Token: 0x06000E5A RID: 3674 RVA: 0x00027082 File Offset: 0x00025282
		public float Divisor
		{
			get
			{
				return base.GetFloatValue(5);
			}
			set
			{
				base.SetValue(5, value);
			}
		}

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06000E5B RID: 3675 RVA: 0x0002708C File Offset: 0x0002528C
		// (set) Token: 0x06000E5C RID: 3676 RVA: 0x00027095 File Offset: 0x00025295
		public float Bias
		{
			get
			{
				return base.GetFloatValue(6);
			}
			set
			{
				base.SetValue(6, value);
			}
		}

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x06000E5D RID: 3677 RVA: 0x0002709F File Offset: 0x0002529F
		// (set) Token: 0x06000E5E RID: 3678 RVA: 0x000270A8 File Offset: 0x000252A8
		public RawVector2 KernelOffset
		{
			get
			{
				return base.GetVector2Value(7);
			}
			set
			{
				base.SetValue(7, value);
			}
		}

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x06000E5F RID: 3679 RVA: 0x000270B2 File Offset: 0x000252B2
		// (set) Token: 0x06000E60 RID: 3680 RVA: 0x000270BB File Offset: 0x000252BB
		public bool PreserveAlpha
		{
			get
			{
				return base.GetBoolValue(8);
			}
			set
			{
				base.SetValue(8, value);
			}
		}

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x06000E61 RID: 3681 RVA: 0x000270C5 File Offset: 0x000252C5
		// (set) Token: 0x06000E62 RID: 3682 RVA: 0x000270CF File Offset: 0x000252CF
		public BorderMode BorderMode
		{
			get
			{
				return base.GetEnumValue<BorderMode>(9);
			}
			set
			{
				base.SetEnumValue<BorderMode>(9, value);
			}
		}

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x06000E63 RID: 3683 RVA: 0x00026F0E File Offset: 0x0002510E
		// (set) Token: 0x06000E64 RID: 3684 RVA: 0x00026F17 File Offset: 0x00025117
		public bool ClampOutput
		{
			get
			{
				return base.GetBoolValue(2);
			}
			set
			{
				base.SetValue(2, value);
			}
		}

		// Token: 0x04000B37 RID: 2871
		private float[] kernelMatrix;
	}
}
