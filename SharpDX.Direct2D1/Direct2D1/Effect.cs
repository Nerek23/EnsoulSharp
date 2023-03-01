using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x020001DA RID: 474
	[Guid("28211a43-7d89-476f-8181-2d6159b220ad")]
	public class Effect : Properties
	{
		// Token: 0x06000997 RID: 2455 RVA: 0x0001B948 File Offset: 0x00019B48
		public Effect(DeviceContext deviceContext, Guid effectId) : base(IntPtr.Zero)
		{
			deviceContext.CreateEffect(effectId, this);
		}

		// Token: 0x06000998 RID: 2456 RVA: 0x0001B95D File Offset: 0x00019B5D
		public Effect(EffectContext effectContext, Guid effectId) : base(IntPtr.Zero)
		{
			effectContext.CreateEffect(effectId, this);
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x0001B974 File Offset: 0x00019B74
		public void SetInputEffect(int index, Effect effect, bool invalidate = true)
		{
			using (Image output = effect.Output)
			{
				this.SetInput(index, output, invalidate);
			}
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x0001B9B4 File Offset: 0x00019BB4
		public Effect(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x0001B9BD File Offset: 0x00019BBD
		public new static explicit operator Effect(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Effect(nativePtr);
			}
			return null;
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x0600099C RID: 2460 RVA: 0x0001B9D4 File Offset: 0x00019BD4
		// (set) Token: 0x0600099D RID: 2461 RVA: 0x0001B9DC File Offset: 0x00019BDC
		public int InputCount
		{
			get
			{
				return this.GetInputCount();
			}
			set
			{
				this.SetInputCount(value);
			}
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x0600099E RID: 2462 RVA: 0x0001B9E8 File Offset: 0x00019BE8
		public Image Output
		{
			get
			{
				Image result;
				this.GetOutput(out result);
				return result;
			}
		}

		// Token: 0x0600099F RID: 2463 RVA: 0x0001BA00 File Offset: 0x00019C00
		public unsafe void SetInput(int index, Image input, RawBool invalidate)
		{
			IntPtr value = IntPtr.Zero;
			value = CppObject.ToCallbackPtr<Image>(input);
			calli(System.Void(System.Void*,System.Int32,System.Void*,SharpDX.Mathematics.Interop.RawBool), this._nativePointer, index, (void*)value, invalidate, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060009A0 RID: 2464 RVA: 0x0001BA40 File Offset: 0x00019C40
		internal unsafe void SetInputCount(int inputCount)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, inputCount, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x060009A1 RID: 2465 RVA: 0x0001BA7C File Offset: 0x00019C7C
		public unsafe Image GetInput(int index)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Void(System.Void*,System.Int32,System.Void*), this._nativePointer, index, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*)));
			Image result;
			if (zero != IntPtr.Zero)
			{
				result = new Image(zero);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060009A2 RID: 2466 RVA: 0x0001BACA File Offset: 0x00019CCA
		internal unsafe int GetInputCount()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060009A3 RID: 2467 RVA: 0x0001BAEC File Offset: 0x00019CEC
		internal unsafe void GetOutput(out Image outputImage)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				outputImage = new Image(zero);
				return;
			}
			outputImage = null;
		}

		// Token: 0x04000621 RID: 1569
		public static readonly Guid ArithmeticComposite = new Guid("fc151437-049a-4784-a24a-f1c4daf20987");

		// Token: 0x04000622 RID: 1570
		public static readonly Guid Atlas = new Guid("913e2be4-fdcf-4fe2-a5f0-2454f14ff408");

		// Token: 0x04000623 RID: 1571
		public static readonly Guid BitmapSource = new Guid("5fb6c24d-c6dd-4231-9404-50f4d5c3252d");

		// Token: 0x04000624 RID: 1572
		public static readonly Guid Blend = new Guid("81c5b77b-13f8-4cdd-ad20-c890547ac65d");

		// Token: 0x04000625 RID: 1573
		public static readonly Guid Border = new Guid("2a2d49c0-4acf-43c7-8c6a-7c4a27874d27");

		// Token: 0x04000626 RID: 1574
		public static readonly Guid Brightness = new Guid("8cea8d1e-77b0-4986-b3b9-2f0c0eae7887");

		// Token: 0x04000627 RID: 1575
		public static readonly Guid ColorManagement = new Guid("1a28524c-fdd6-4aa4-ae8f-837eb8267b37");

		// Token: 0x04000628 RID: 1576
		public static readonly Guid ColorMatrix = new Guid("921f03d6-641c-47df-852d-b4bb6153ae11");

		// Token: 0x04000629 RID: 1577
		public static readonly Guid Composite = new Guid("48fc9f51-f6ac-48f1-8b58-3b28ac46f76d");

		// Token: 0x0400062A RID: 1578
		public static readonly Guid ConvolveMatrix = new Guid("407f8c08-5533-4331-a341-23cc3877843e");

		// Token: 0x0400062B RID: 1579
		public static readonly Guid Crop = new Guid("e23f7110-0e9a-4324-af47-6a2c0c46f35b");

		// Token: 0x0400062C RID: 1580
		public static readonly Guid DirectionalBlur = new Guid("174319a6-58e9-49b2-bb63-caf2c811a3db");

		// Token: 0x0400062D RID: 1581
		public static readonly Guid DiscreteTransfer = new Guid("90866fcd-488e-454b-af06-e5041b66c36c");

		// Token: 0x0400062E RID: 1582
		public static readonly Guid DisplacementMap = new Guid("edc48364-0417-4111-9450-43845fa9f890");

		// Token: 0x0400062F RID: 1583
		public static readonly Guid DistantDiffuse = new Guid("3e7efd62-a32d-46d4-a83c-5278889ac954");

		// Token: 0x04000630 RID: 1584
		public static readonly Guid DistantSpecular = new Guid("428c1ee5-77b8-4450-8ab5-72219c21abda");

		// Token: 0x04000631 RID: 1585
		public static readonly Guid DpiCompensation = new Guid("6c26c5c7-34e0-46fc-9cfd-e5823706e228");

		// Token: 0x04000632 RID: 1586
		public static readonly Guid Flood = new Guid("61c23c20-ae69-4d8e-94cf-50078df638f2");

		// Token: 0x04000633 RID: 1587
		public static readonly Guid GammaTransfer = new Guid("409444c4-c419-41a0-b0c1-8cd0c0a18e42");

		// Token: 0x04000634 RID: 1588
		public static readonly Guid GaussianBlur = new Guid("1feb6d69-2fe6-4ac9-8c58-1d7f93e7a6a5");

		// Token: 0x04000635 RID: 1589
		public static readonly Guid Scale = new Guid("9daf9369-3846-4d0e-a44e-0c607934a5d7");

		// Token: 0x04000636 RID: 1590
		public static readonly Guid Histogram = new Guid("881db7d0-f7ee-4d4d-a6d2-4697acc66ee8");

		// Token: 0x04000637 RID: 1591
		public static readonly Guid HueRotation = new Guid("0f4458ec-4b32-491b-9e85-bd73f44d3eb6");

		// Token: 0x04000638 RID: 1592
		public static readonly Guid LinearTransfer = new Guid("ad47c8fd-63ef-4acc-9b51-67979c036c06");

		// Token: 0x04000639 RID: 1593
		public static readonly Guid LuminanceToAlpha = new Guid("41251ab7-0beb-46f8-9da7-59e93fcce5de");

		// Token: 0x0400063A RID: 1594
		public static readonly Guid Morphology = new Guid("eae6c40d-626a-4c2d-bfcb-391001abe202");

		// Token: 0x0400063B RID: 1595
		public static readonly Guid OpacityMetadata = new Guid("6c53006a-4450-4199-aa5b-ad1656fece5e");

		// Token: 0x0400063C RID: 1596
		public static readonly Guid PointDiffuse = new Guid("b9e303c3-c08c-4f91-8b7b-38656bc48c20");

		// Token: 0x0400063D RID: 1597
		public static readonly Guid PointSpecular = new Guid("09c3ca26-3ae2-4f09-9ebc-ed3865d53f22");

		// Token: 0x0400063E RID: 1598
		public static readonly Guid Premultiply = new Guid("06eab419-deed-4018-80d2-3e1d471adeb2");

		// Token: 0x0400063F RID: 1599
		public static readonly Guid Saturation = new Guid("5cb2d9cf-327d-459f-a0ce-40c0b2086bf7");

		// Token: 0x04000640 RID: 1600
		public static readonly Guid Shadow = new Guid("c67ea361-1863-4e69-89db-695d3e9a5b6b");

		// Token: 0x04000641 RID: 1601
		public static readonly Guid SpotDiffuse = new Guid("818a1105-7932-44f4-aa86-08ae7b2f2c93");

		// Token: 0x04000642 RID: 1602
		public static readonly Guid SpotSpecular = new Guid("edae421e-7654-4a37-9db8-71acc1beb3c1");

		// Token: 0x04000643 RID: 1603
		public static readonly Guid TableTransfer = new Guid("5bf818c3-5e43-48cb-b631-868396d6a1d4");

		// Token: 0x04000644 RID: 1604
		public static readonly Guid Tile = new Guid("b0784138-3b76-4bc5-b13b-0fa2ad02659f");

		// Token: 0x04000645 RID: 1605
		public static readonly Guid Turbulence = new Guid("cf2bb6ae-889a-4ad7-ba29-a2fd732c9fc9");

		// Token: 0x04000646 RID: 1606
		public static readonly Guid UnPremultiply = new Guid("fb9ac489-ad8d-41ed-9999-bb6347d110f7");

		// Token: 0x04000647 RID: 1607
		public static readonly Guid YCbCr = new Guid("99503cc1-66c7-45c9-a875-8ad8a7914401");

		// Token: 0x04000648 RID: 1608
		public static readonly Guid Contrast = new Guid("b648a78a-0ed5-4f80-a94a-8e825aca6b77");

		// Token: 0x04000649 RID: 1609
		public static readonly Guid RgbToHue = new Guid("23f3e5ec-91e8-4d3d-ad0a-afadc1004aa1");

		// Token: 0x0400064A RID: 1610
		public static readonly Guid HueToRgb = new Guid("7b78a6bd-0141-4def-8a52-6356ee0cbdd5");

		// Token: 0x0400064B RID: 1611
		public static readonly Guid ChromaKey = new Guid("74c01f5b-2a0d-408c-88e2-c7a3c7197742");

		// Token: 0x0400064C RID: 1612
		public static readonly Guid Emboss = new Guid("b1c5eb2b-0348-43f0-8107-4957cacba2ae");

		// Token: 0x0400064D RID: 1613
		public static readonly Guid Exposure = new Guid("b56c8cfa-f634-41ee-bee0-ffa617106004");

		// Token: 0x0400064E RID: 1614
		public static readonly Guid Grayscale = new Guid("36dde0eb-3725-42e0-836d-52fb20aee644");

		// Token: 0x0400064F RID: 1615
		public static readonly Guid Invert = new Guid("e0c3784d-cb39-4e84-b6fd-6b72f0810263");

		// Token: 0x04000650 RID: 1616
		public static readonly Guid Posterize = new Guid("2188945e-33a3-4366-b7bc-086bd02d0884");

		// Token: 0x04000651 RID: 1617
		public static readonly Guid Sepia = new Guid("3a1af410-5f1d-4dbe-84df-915da79b7153");

		// Token: 0x04000652 RID: 1618
		public static readonly Guid Sharpen = new Guid("c9b887cb-c5ff-4dc5-9779-273dcf417c7d");

		// Token: 0x04000653 RID: 1619
		public static readonly Guid Straighten = new Guid("4da47b12-79a3-4fb0-8237-bbc3b2a4de08");

		// Token: 0x04000654 RID: 1620
		public static readonly Guid TemperatureTint = new Guid("89176087-8af9-4a08-aeb1-895f38db1766");

		// Token: 0x04000655 RID: 1621
		public static readonly Guid Vignette = new Guid("c00c40be-5e67-4ca3-95b4-f4b02c115135");

		// Token: 0x04000656 RID: 1622
		public static readonly Guid EdgeDetection = new Guid("eff583ca-cb07-4aa9-ac5d-2cc44c76460f");

		// Token: 0x04000657 RID: 1623
		public static readonly Guid HighlightsShadows = new Guid("cadc8384-323f-4c7e-a361-2e2b24df6ee4");

		// Token: 0x04000658 RID: 1624
		public static readonly Guid LookupTable3D = new Guid("349e0eda-0088-4a79-9ca3-c7e300202020");

		// Token: 0x04000659 RID: 1625
		public static readonly Guid Opacity = new Guid("811d79a4-de28-4454-8094-c64685f8bd4c");

		// Token: 0x0400065A RID: 1626
		public static readonly Guid AlphaMask = new Guid("c80ecff0-3fd5-4f05-8328-c5d1724b4f0a");

		// Token: 0x0400065B RID: 1627
		public static readonly Guid CrossFade = new Guid("12f575e8-4db1-485f-9a84-03a07dd3829f");

		// Token: 0x0400065C RID: 1628
		public static readonly Guid Tint = new Guid("36312b17-f7dd-4014-915d-ffca768cf211");

		// Token: 0x0400065D RID: 1629
		public static readonly Guid AffineTransform2D = new Guid("6aa97485-6354-4cfc-908c-e4a74f62c96c");

		// Token: 0x0400065E RID: 1630
		public static readonly Guid PerspectiveTransform3D = new Guid("c2844d0b-3d86-46e7-85ba-526c9240f3fb");

		// Token: 0x0400065F RID: 1631
		public static readonly Guid Transform3D = new Guid("e8467b04-ec61-4b8a-b5de-d4d73debea5a");
	}
}
