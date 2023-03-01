using System;

namespace SharpDX.DXGI
{
	// Token: 0x02000055 RID: 85
	public class ResultCode
	{
		// Token: 0x0400018E RID: 398
		public static readonly ResultDescriptor InvalidCall = new ResultDescriptor(-2005270527, "SharpDX.DXGI", "DXGI_ERROR_INVALID_CALL", "InvalidCall", null);

		// Token: 0x0400018F RID: 399
		public static readonly ResultDescriptor NotFound = new ResultDescriptor(-2005270526, "SharpDX.DXGI", "DXGI_ERROR_NOT_FOUND", "NotFound", null);

		// Token: 0x04000190 RID: 400
		public static readonly ResultDescriptor MoreData = new ResultDescriptor(-2005270525, "SharpDX.DXGI", "DXGI_ERROR_MORE_DATA", "MoreData", null);

		// Token: 0x04000191 RID: 401
		public static readonly ResultDescriptor Unsupported = new ResultDescriptor(-2005270524, "SharpDX.DXGI", "DXGI_ERROR_UNSUPPORTED", "Unsupported", null);

		// Token: 0x04000192 RID: 402
		public static readonly ResultDescriptor DeviceRemoved = new ResultDescriptor(-2005270523, "SharpDX.DXGI", "DXGI_ERROR_DEVICE_REMOVED", "DeviceRemoved", null);

		// Token: 0x04000193 RID: 403
		public static readonly ResultDescriptor DeviceHung = new ResultDescriptor(-2005270522, "SharpDX.DXGI", "DXGI_ERROR_DEVICE_HUNG", "DeviceHung", null);

		// Token: 0x04000194 RID: 404
		public static readonly ResultDescriptor DeviceReset = new ResultDescriptor(-2005270521, "SharpDX.DXGI", "DXGI_ERROR_DEVICE_RESET", "DeviceReset", null);

		// Token: 0x04000195 RID: 405
		public static readonly ResultDescriptor WasStillDrawing = new ResultDescriptor(-2005270518, "SharpDX.DXGI", "DXGI_ERROR_WAS_STILL_DRAWING", "WasStillDrawing", null);

		// Token: 0x04000196 RID: 406
		public static readonly ResultDescriptor FrameStatisticsDisjoint = new ResultDescriptor(-2005270517, "SharpDX.DXGI", "DXGI_ERROR_FRAME_STATISTICS_DISJOINT", "FrameStatisticsDisjoint", null);

		// Token: 0x04000197 RID: 407
		public static readonly ResultDescriptor GraphicsVidpnSourceInUse = new ResultDescriptor(-2005270516, "SharpDX.DXGI", "DXGI_ERROR_GRAPHICS_VIDPN_SOURCE_IN_USE", "GraphicsVidpnSourceInUse", null);

		// Token: 0x04000198 RID: 408
		public static readonly ResultDescriptor DriverInternalError = new ResultDescriptor(-2005270496, "SharpDX.DXGI", "DXGI_ERROR_DRIVER_INTERNAL_ERROR", "DriverInternalError", null);

		// Token: 0x04000199 RID: 409
		public static readonly ResultDescriptor Nonexclusive = new ResultDescriptor(-2005270495, "SharpDX.DXGI", "DXGI_ERROR_NONEXCLUSIVE", "Nonexclusive", null);

		// Token: 0x0400019A RID: 410
		public static readonly ResultDescriptor NotCurrentlyAvailable = new ResultDescriptor(-2005270494, "SharpDX.DXGI", "DXGI_ERROR_NOT_CURRENTLY_AVAILABLE", "NotCurrentlyAvailable", null);

		// Token: 0x0400019B RID: 411
		public static readonly ResultDescriptor RemoteClientDisconnected = new ResultDescriptor(-2005270493, "SharpDX.DXGI", "DXGI_ERROR_REMOTE_CLIENT_DISCONNECTED", "RemoteClientDisconnected", null);

		// Token: 0x0400019C RID: 412
		public static readonly ResultDescriptor RemoteOufOfMemory = new ResultDescriptor(-2005270492, "SharpDX.DXGI", "DXGI_ERROR_REMOTE_OUTOFMEMORY", "RemoteOufOfMemory", null);

		// Token: 0x0400019D RID: 413
		public static readonly ResultDescriptor AccessLost = new ResultDescriptor(-2005270490, "SharpDX.DXGI", "DXGI_ERROR_ACCESS_LOST", "AccessLost", null);

		// Token: 0x0400019E RID: 414
		public static readonly ResultDescriptor WaitTimeout = new ResultDescriptor(-2005270489, "SharpDX.DXGI", "DXGI_ERROR_WAIT_TIMEOUT", "WaitTimeout", null);

		// Token: 0x0400019F RID: 415
		public static readonly ResultDescriptor SessionDisconnected = new ResultDescriptor(-2005270488, "SharpDX.DXGI", "DXGI_ERROR_SESSION_DISCONNECTED", "SessionDisconnected", null);

		// Token: 0x040001A0 RID: 416
		public static readonly ResultDescriptor RestrictToOutputStale = new ResultDescriptor(-2005270487, "SharpDX.DXGI", "DXGI_ERROR_RESTRICT_TO_OUTPUT_STALE", "RestrictToOutputStale", null);

		// Token: 0x040001A1 RID: 417
		public static readonly ResultDescriptor CannotProtectContent = new ResultDescriptor(-2005270486, "SharpDX.DXGI", "DXGI_ERROR_CANNOT_PROTECT_CONTENT", "CannotProtectContent", null);

		// Token: 0x040001A2 RID: 418
		public static readonly ResultDescriptor AccessDenied = new ResultDescriptor(-2005270485, "SharpDX.DXGI", "DXGI_ERROR_ACCESS_DENIED", "AccessDenied", null);

		// Token: 0x040001A3 RID: 419
		public static readonly ResultDescriptor NameAlreadyExists = new ResultDescriptor(-2005270484, "SharpDX.DXGI", "DXGI_ERROR_NAME_ALREADY_EXISTS", "NameAlreadyExists", null);

		// Token: 0x040001A4 RID: 420
		public static readonly ResultDescriptor SdkComponentMissing = new ResultDescriptor(-2005270483, "SharpDX.DXGI", "DXGI_ERROR_SDK_COMPONENT_MISSING", "SdkComponentMissing", null);

		// Token: 0x040001A5 RID: 421
		public static readonly ResultDescriptor NotCurrent = new ResultDescriptor(-2005270482, "SharpDX.DXGI", "DXGI_ERROR_NOT_CURRENT", "NotCurrent", null);

		// Token: 0x040001A6 RID: 422
		public static readonly ResultDescriptor HwProtectionOufOfMemory = new ResultDescriptor(-2005270480, "SharpDX.DXGI", "DXGI_ERROR_HW_PROTECTION_OUTOFMEMORY", "HwProtectionOufOfMemory", null);

		// Token: 0x040001A7 RID: 423
		public static readonly ResultDescriptor DynamicCodePolicyViolation = new ResultDescriptor(-2005270479, "SharpDX.DXGI", "DXGI_ERROR_DYNAMIC_CODE_POLICY_VIOLATION", "DynamicCodePolicyViolation", null);

		// Token: 0x040001A8 RID: 424
		public static readonly ResultDescriptor NonCompositedUi = new ResultDescriptor(-2005270478, "SharpDX.DXGI", "DXGI_ERROR_NON_COMPOSITED_UI", "NonCompositedUi", null);

		// Token: 0x040001A9 RID: 425
		public static readonly ResultDescriptor ModeChangeInProgress = new ResultDescriptor(-2005270491, "SharpDX.DXGI", "DXGI_ERROR_MODE_CHANGE_IN_PROGRESS", "ModeChangeInProgress", null);

		// Token: 0x040001AA RID: 426
		public static readonly ResultDescriptor CacheCorrupt = new ResultDescriptor(-2005270477, "SharpDX.DXGI", "DXGI_ERROR_CACHE_CORRUPT", "CacheCorrupt", null);

		// Token: 0x040001AB RID: 427
		public static readonly ResultDescriptor CacheFull = new ResultDescriptor(-2005270476, "SharpDX.DXGI", "DXGI_ERROR_CACHE_FULL", "CacheFull", null);

		// Token: 0x040001AC RID: 428
		public static readonly ResultDescriptor CacheHashCollision = new ResultDescriptor(-2005270475, "SharpDX.DXGI", "DXGI_ERROR_CACHE_HASH_COLLISION", "CacheHashCollision", null);

		// Token: 0x040001AD RID: 429
		public static readonly ResultDescriptor AlreadyExists = new ResultDescriptor(-2005270474, "SharpDX.DXGI", "DXGI_ERROR_ALREADY_EXISTS", "AlreadyExists", null);
	}
}
