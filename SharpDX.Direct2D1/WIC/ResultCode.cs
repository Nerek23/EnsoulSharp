using System;

namespace SharpDX.WIC
{
	// Token: 0x02000067 RID: 103
	public class ResultCode
	{
		// Token: 0x0400019C RID: 412
		public static readonly ResultDescriptor Base = new ResultDescriptor(8192, "SharpDX.WIC", "WINCODEC_ERR_BASE", "Base", null);

		// Token: 0x0400019D RID: 413
		public static readonly ResultDescriptor GenericError = new ResultDescriptor(-2147467259, "SharpDX.WIC", "WINCODEC_ERR_GENERIC_ERROR", "GenericError", null);

		// Token: 0x0400019E RID: 414
		public static readonly ResultDescriptor InvalidParameter = new ResultDescriptor(-2147024809, "SharpDX.WIC", "WINCODEC_ERR_INVALIDPARAMETER", "InvalidParameter", null);

		// Token: 0x0400019F RID: 415
		public static readonly ResultDescriptor OufOfMemory = new ResultDescriptor(-2147024882, "SharpDX.WIC", "WINCODEC_ERR_OUTOFMEMORY", "OufOfMemory", null);

		// Token: 0x040001A0 RID: 416
		public static readonly ResultDescriptor NotImplemented = new ResultDescriptor(-2147467263, "SharpDX.WIC", "WINCODEC_ERR_NOTIMPLEMENTED", "NotImplemented", null);

		// Token: 0x040001A1 RID: 417
		public static readonly ResultDescriptor Aborted = new ResultDescriptor(-2147467260, "SharpDX.WIC", "WINCODEC_ERR_ABORTED", "Aborted", null);

		// Token: 0x040001A2 RID: 418
		public static readonly ResultDescriptor AccessDenied = new ResultDescriptor(-2147024891, "SharpDX.WIC", "WINCODEC_ERR_ACCESSDENIED", "AccessDenied", null);

		// Token: 0x040001A3 RID: 419
		public static readonly ResultDescriptor Valueoverflow = new ResultDescriptor(-2147024362, "SharpDX.WIC", "WINCODEC_ERR_VALUEOVERFLOW", "Valueoverflow", null);

		// Token: 0x040001A4 RID: 420
		public static readonly ResultDescriptor WrongState = new ResultDescriptor(-2003292412, "SharpDX.WIC", "WINCODEC_ERR_WRONGSTATE", "WrongState", null);

		// Token: 0x040001A5 RID: 421
		public static readonly ResultDescriptor Valueoutofrange = new ResultDescriptor(-2003292411, "SharpDX.WIC", "WINCODEC_ERR_VALUEOUTOFRANGE", "Valueoutofrange", null);

		// Token: 0x040001A6 RID: 422
		public static readonly ResultDescriptor Unknownimageformat = new ResultDescriptor(-2003292409, "SharpDX.WIC", "WINCODEC_ERR_UNKNOWNIMAGEFORMAT", "Unknownimageformat", null);

		// Token: 0x040001A7 RID: 423
		public static readonly ResultDescriptor UnsupportedVersion = new ResultDescriptor(-2003292405, "SharpDX.WIC", "WINCODEC_ERR_UNSUPPORTEDVERSION", "UnsupportedVersion", null);

		// Token: 0x040001A8 RID: 424
		public static readonly ResultDescriptor NotInitializeD = new ResultDescriptor(-2003292404, "SharpDX.WIC", "WINCODEC_ERR_NOTINITIALIZED", "NotInitializeD", null);

		// Token: 0x040001A9 RID: 425
		public static readonly ResultDescriptor Alreadylocked = new ResultDescriptor(-2003292403, "SharpDX.WIC", "WINCODEC_ERR_ALREADYLOCKED", "Alreadylocked", null);

		// Token: 0x040001AA RID: 426
		public static readonly ResultDescriptor Propertynotfound = new ResultDescriptor(-2003292352, "SharpDX.WIC", "WINCODEC_ERR_PROPERTYNOTFOUND", "Propertynotfound", null);

		// Token: 0x040001AB RID: 427
		public static readonly ResultDescriptor Propertynotsupported = new ResultDescriptor(-2003292351, "SharpDX.WIC", "WINCODEC_ERR_PROPERTYNOTSUPPORTED", "Propertynotsupported", null);

		// Token: 0x040001AC RID: 428
		public static readonly ResultDescriptor Propertysize = new ResultDescriptor(-2003292350, "SharpDX.WIC", "WINCODEC_ERR_PROPERTYSIZE", "Propertysize", null);

		// Token: 0x040001AD RID: 429
		public static readonly ResultDescriptor Codecpresent = new ResultDescriptor(-2003292349, "SharpDX.WIC", "WINCODEC_ERR_CODECPRESENT", "Codecpresent", null);

		// Token: 0x040001AE RID: 430
		public static readonly ResultDescriptor Codecnothumbnail = new ResultDescriptor(-2003292348, "SharpDX.WIC", "WINCODEC_ERR_CODECNOTHUMBNAIL", "Codecnothumbnail", null);

		// Token: 0x040001AF RID: 431
		public static readonly ResultDescriptor Paletteunavailable = new ResultDescriptor(-2003292347, "SharpDX.WIC", "WINCODEC_ERR_PALETTEUNAVAILABLE", "Paletteunavailable", null);

		// Token: 0x040001B0 RID: 432
		public static readonly ResultDescriptor Codectoomanyscanlines = new ResultDescriptor(-2003292346, "SharpDX.WIC", "WINCODEC_ERR_CODECTOOMANYSCANLINES", "Codectoomanyscanlines", null);

		// Token: 0x040001B1 RID: 433
		public static readonly ResultDescriptor Internalerror = new ResultDescriptor(-2003292344, "SharpDX.WIC", "WINCODEC_ERR_INTERNALERROR", "Internalerror", null);

		// Token: 0x040001B2 RID: 434
		public static readonly ResultDescriptor SourceRectangleDoesnotmatchdimensions = new ResultDescriptor(-2003292343, "SharpDX.WIC", "WINCODEC_ERR_SOURCERECTDOESNOTMATCHDIMENSIONS", "SourceRectangleDoesnotmatchdimensions", null);

		// Token: 0x040001B3 RID: 435
		public static readonly ResultDescriptor Componentnotfound = new ResultDescriptor(-2003292336, "SharpDX.WIC", "WINCODEC_ERR_COMPONENTNOTFOUND", "Componentnotfound", null);

		// Token: 0x040001B4 RID: 436
		public static readonly ResultDescriptor Imagesizeoutofrange = new ResultDescriptor(-2003292335, "SharpDX.WIC", "WINCODEC_ERR_IMAGESIZEOUTOFRANGE", "Imagesizeoutofrange", null);

		// Token: 0x040001B5 RID: 437
		public static readonly ResultDescriptor TooMuchmetadata = new ResultDescriptor(-2003292334, "SharpDX.WIC", "WINCODEC_ERR_TOOMUCHMETADATA", "TooMuchmetadata", null);

		// Token: 0x040001B6 RID: 438
		public static readonly ResultDescriptor Badimage = new ResultDescriptor(-2003292320, "SharpDX.WIC", "WINCODEC_ERR_BADIMAGE", "Badimage", null);

		// Token: 0x040001B7 RID: 439
		public static readonly ResultDescriptor Badheader = new ResultDescriptor(-2003292319, "SharpDX.WIC", "WINCODEC_ERR_BADHEADER", "Badheader", null);

		// Token: 0x040001B8 RID: 440
		public static readonly ResultDescriptor FrameMissing = new ResultDescriptor(-2003292318, "SharpDX.WIC", "WINCODEC_ERR_FRAMEMISSING", "FrameMissing", null);

		// Token: 0x040001B9 RID: 441
		public static readonly ResultDescriptor Badmetadataheader = new ResultDescriptor(-2003292317, "SharpDX.WIC", "WINCODEC_ERR_BADMETADATAHEADER", "Badmetadataheader", null);

		// Token: 0x040001BA RID: 442
		public static readonly ResultDescriptor Badstreamdata = new ResultDescriptor(-2003292304, "SharpDX.WIC", "WINCODEC_ERR_BADSTREAMDATA", "Badstreamdata", null);

		// Token: 0x040001BB RID: 443
		public static readonly ResultDescriptor StreamWrite = new ResultDescriptor(-2003292303, "SharpDX.WIC", "WINCODEC_ERR_STREAMWRITE", "StreamWrite", null);

		// Token: 0x040001BC RID: 444
		public static readonly ResultDescriptor StreamRead = new ResultDescriptor(-2003292302, "SharpDX.WIC", "WINCODEC_ERR_STREAMREAD", "StreamRead", null);

		// Token: 0x040001BD RID: 445
		public static readonly ResultDescriptor StreamNotAvailable = new ResultDescriptor(-2003292301, "SharpDX.WIC", "WINCODEC_ERR_STREAMNOTAVAILABLE", "StreamNotAvailable", null);

		// Token: 0x040001BE RID: 446
		public static readonly ResultDescriptor UnsupportedPixelFormat = new ResultDescriptor(-2003292288, "SharpDX.WIC", "WINCODEC_ERR_UNSUPPORTEDPIXELFORMAT", "UnsupportedPixelFormat", null);

		// Token: 0x040001BF RID: 447
		public static readonly ResultDescriptor UnsupportedOperation = new ResultDescriptor(-2003292287, "SharpDX.WIC", "WINCODEC_ERR_UNSUPPORTEDOPERATION", "UnsupportedOperation", null);

		// Token: 0x040001C0 RID: 448
		public static readonly ResultDescriptor InvalidRegistration = new ResultDescriptor(-2003292278, "SharpDX.WIC", "WINCODEC_ERR_INVALIDREGISTRATION", "InvalidRegistration", null);

		// Token: 0x040001C1 RID: 449
		public static readonly ResultDescriptor Componentinitializefailure = new ResultDescriptor(-2003292277, "SharpDX.WIC", "WINCODEC_ERR_COMPONENTINITIALIZEFAILURE", "Componentinitializefailure", null);

		// Token: 0x040001C2 RID: 450
		public static readonly ResultDescriptor Insufficientbuffer = new ResultDescriptor(-2003292276, "SharpDX.WIC", "WINCODEC_ERR_INSUFFICIENTBUFFER", "Insufficientbuffer", null);

		// Token: 0x040001C3 RID: 451
		public static readonly ResultDescriptor Duplicatemetadatapresent = new ResultDescriptor(-2003292275, "SharpDX.WIC", "WINCODEC_ERR_DUPLICATEMETADATAPRESENT", "Duplicatemetadatapresent", null);

		// Token: 0x040001C4 RID: 452
		public static readonly ResultDescriptor Propertyunexpectedtype = new ResultDescriptor(-2003292274, "SharpDX.WIC", "WINCODEC_ERR_PROPERTYUNEXPECTEDTYPE", "Propertyunexpectedtype", null);

		// Token: 0x040001C5 RID: 453
		public static readonly ResultDescriptor UnexpectedSize = new ResultDescriptor(-2003292273, "SharpDX.WIC", "WINCODEC_ERR_UNEXPECTEDSIZE", "UnexpectedSize", null);

		// Token: 0x040001C6 RID: 454
		public static readonly ResultDescriptor InvalidQueryRequest = new ResultDescriptor(-2003292272, "SharpDX.WIC", "WINCODEC_ERR_INVALIDQUERYREQUEST", "InvalidQueryRequest", null);

		// Token: 0x040001C7 RID: 455
		public static readonly ResultDescriptor UnexpectedMetadataType = new ResultDescriptor(-2003292271, "SharpDX.WIC", "WINCODEC_ERR_UNEXPECTEDMETADATATYPE", "UnexpectedMetadataType", null);

		// Token: 0x040001C8 RID: 456
		public static readonly ResultDescriptor Requestonlyvalidatmetadataroot = new ResultDescriptor(-2003292270, "SharpDX.WIC", "WINCODEC_ERR_REQUESTONLYVALIDATMETADATAROOT", "Requestonlyvalidatmetadataroot", null);

		// Token: 0x040001C9 RID: 457
		public static readonly ResultDescriptor InvalidQueryCharacter = new ResultDescriptor(-2003292269, "SharpDX.WIC", "WINCODEC_ERR_INVALIDQUERYCHARACTER", "InvalidQueryCharacter", null);

		// Token: 0x040001CA RID: 458
		public static readonly ResultDescriptor Win32error = new ResultDescriptor(-2003292268, "SharpDX.WIC", "WINCODEC_ERR_WIN32ERROR", "Win32error", null);

		// Token: 0x040001CB RID: 459
		public static readonly ResultDescriptor InvalidProgressivelevel = new ResultDescriptor(-2003292267, "SharpDX.WIC", "WINCODEC_ERR_INVALIDPROGRESSIVELEVEL", "InvalidProgressivelevel", null);

		// Token: 0x040001CC RID: 460
		public static readonly ResultDescriptor InvalidJpegscanindex = new ResultDescriptor(-2003292266, "SharpDX.WIC", "WINCODEC_ERR_INVALIDJPEGSCANINDEX", "InvalidJpegscanindex", null);
	}
}
