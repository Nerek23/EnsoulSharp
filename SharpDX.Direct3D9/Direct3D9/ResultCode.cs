using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000A9 RID: 169
	public class ResultCode
	{
		// Token: 0x040009AC RID: 2476
		public static readonly ResultDescriptor ConflictingRenderState = new ResultDescriptor(-2005530591, "SharpDX.Direct3D9", "D3DERR_CONFLICTINGRENDERSTATE", "ConflictingRenderState", null);

		// Token: 0x040009AD RID: 2477
		public static readonly ResultDescriptor ConflictingTextureFilter = new ResultDescriptor(-2005530594, "SharpDX.Direct3D9", "D3DERR_CONFLICTINGTEXTUREFILTER", "ConflictingTextureFilter", null);

		// Token: 0x040009AE RID: 2478
		public static readonly ResultDescriptor ConflictingTexturePalette = new ResultDescriptor(-2005530586, "SharpDX.Direct3D9", "D3DERR_CONFLICTINGTEXTUREPALETTE", "ConflictingTexturePalette", null);

		// Token: 0x040009AF RID: 2479
		public static readonly ResultDescriptor DeviceHung = new ResultDescriptor(-2005530508, "SharpDX.Direct3D9", "D3DERR_DEVICEHUNG", "DeviceHung", null);

		// Token: 0x040009B0 RID: 2480
		public static readonly ResultDescriptor DeviceLost = new ResultDescriptor(-2005530520, "SharpDX.Direct3D9", "D3DERR_DEVICELOST", "DeviceLost", null);

		// Token: 0x040009B1 RID: 2481
		public static readonly ResultDescriptor DeviceNotReset = new ResultDescriptor(-2005530519, "SharpDX.Direct3D9", "D3DERR_DEVICENOTRESET", "DeviceNotReset", null);

		// Token: 0x040009B2 RID: 2482
		public static readonly ResultDescriptor DeviceRemoved = new ResultDescriptor(-2005530512, "SharpDX.Direct3D9", "D3DERR_DEVICEREMOVED", "DeviceRemoved", null);

		// Token: 0x040009B3 RID: 2483
		public static readonly ResultDescriptor DriverInternalError = new ResultDescriptor(-2005530585, "SharpDX.Direct3D9", "D3DERR_DRIVERINTERNALERROR", "DriverInternalError", null);

		// Token: 0x040009B4 RID: 2484
		public static readonly ResultDescriptor InvalidCall = new ResultDescriptor(-2005530516, "SharpDX.Direct3D9", "D3DERR_INVALIDCALL", "InvalidCall", null);

		// Token: 0x040009B5 RID: 2485
		public static readonly ResultDescriptor InvalidDevice = new ResultDescriptor(-2005530517, "SharpDX.Direct3D9", "D3DERR_INVALIDDEVICE", "InvalidDevice", null);

		// Token: 0x040009B6 RID: 2486
		public static readonly ResultDescriptor MoreData = new ResultDescriptor(-2005530521, "SharpDX.Direct3D9", "D3DERR_MOREDATA", "MoreData", null);

		// Token: 0x040009B7 RID: 2487
		public static readonly ResultDescriptor NoAutomaticGeneration = new ResultDescriptor(141953135, "SharpDX.Direct3D9", "D3DOK_NOAUTOGEN", "NoAutomaticGeneration", null);

		// Token: 0x040009B8 RID: 2488
		public static readonly ResultDescriptor NotAvailable = new ResultDescriptor(-2005530518, "SharpDX.Direct3D9", "D3DERR_NOTAVAILABLE", "NotAvailable", null);

		// Token: 0x040009B9 RID: 2489
		public static readonly ResultDescriptor NotFound = new ResultDescriptor(-2005530522, "SharpDX.Direct3D9", "D3DERR_NOTFOUND", "NotFound", null);

		// Token: 0x040009BA RID: 2490
		public static readonly ResultDescriptor OutOfVideoMemory = new ResultDescriptor(-2005532292, "SharpDX.Direct3D9", "D3DERR_OUTOFVIDEOMEMORY", "OutOfVideoMemory", null);

		// Token: 0x040009BB RID: 2491
		public static readonly ResultDescriptor PresentModeChanged = new ResultDescriptor(141953143, "SharpDX.Direct3D9", "S_PRESENT_MODE_CHANGED", "PresentModeChanged", null);

		// Token: 0x040009BC RID: 2492
		public static readonly ResultDescriptor PresentOccluded = new ResultDescriptor(141953144, "SharpDX.Direct3D9", "S_PRESENT_OCCLUDED", "PresentOccluded", null);

		// Token: 0x040009BD RID: 2493
		public static readonly ResultDescriptor ResidentInSharedMemory = new ResultDescriptor(141953142, "SharpDX.Direct3D9", "S_RESIDENT_IN_SHARED_MEMORY", "ResidentInSharedMemory", null);

		// Token: 0x040009BE RID: 2494
		public static readonly ResultDescriptor Success = new ResultDescriptor(0, "SharpDX.Direct3D9", "D3D_OK", "Success", null);

		// Token: 0x040009BF RID: 2495
		public static readonly ResultDescriptor TooManyOperations = new ResultDescriptor(-2005530595, "SharpDX.Direct3D9", "D3DERR_TOOMANYOPERATIONS", "TooManyOperations", null);

		// Token: 0x040009C0 RID: 2496
		public static readonly ResultDescriptor UnsupportedAlphaArgument = new ResultDescriptor(-2005530596, "SharpDX.Direct3D9", "D3DERR_UNSUPPORTEDALPHAARG", "UnsupportedAlphaArgument", null);

		// Token: 0x040009C1 RID: 2497
		public static readonly ResultDescriptor UnsupportedAlphaOperation = new ResultDescriptor(-2005530597, "SharpDX.Direct3D9", "D3DERR_UNSUPPORTEDALPHAOPERATION", "UnsupportedAlphaOperation", null);

		// Token: 0x040009C2 RID: 2498
		public static readonly ResultDescriptor UnsupportedColorArgument = new ResultDescriptor(-2005530598, "SharpDX.Direct3D9", "D3DERR_UNSUPPORTEDCOLORARG", "UnsupportedColorArgument", null);

		// Token: 0x040009C3 RID: 2499
		public static readonly ResultDescriptor UnsupportedColorOperation = new ResultDescriptor(-2005530599, "SharpDX.Direct3D9", "D3DERR_UNSUPPORTEDCOLOROPERATION", "UnsupportedColorOperation", null);

		// Token: 0x040009C4 RID: 2500
		public static readonly ResultDescriptor UnsupportedFactorValue = new ResultDescriptor(-2005530593, "SharpDX.Direct3D9", "D3DERR_UNSUPPORTEDFACTORVALUE", "UnsupportedFactorValue", null);

		// Token: 0x040009C5 RID: 2501
		public static readonly ResultDescriptor UnsupportedTextureFilter = new ResultDescriptor(-2005530590, "SharpDX.Direct3D9", "D3DERR_UNSUPPORTEDTEXTUREFILTER", "UnsupportedTextureFilter", null);

		// Token: 0x040009C6 RID: 2502
		public static readonly ResultDescriptor WasStillDrawing = new ResultDescriptor(-2005532132, "SharpDX.Direct3D9", "D3DERR_WASSTILLDRAWING", "WasStillDrawing", null);

		// Token: 0x040009C7 RID: 2503
		public static readonly ResultDescriptor WrongTextureFormat = new ResultDescriptor(-2005530600, "SharpDX.Direct3D9", "D3DERR_WRONGTEXTUREFORMAT", "WrongTextureFormat", null);
	}
}
