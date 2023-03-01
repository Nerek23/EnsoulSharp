using System;
using System.Runtime.InteropServices;
using SharpDX.DirectWrite;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000190 RID: 400
	internal class CommandSinkShadow : ComObjectShadow
	{
		// Token: 0x060007B2 RID: 1970 RVA: 0x00017244 File Offset: 0x00015444
		public static IntPtr ToIntPtr(CommandSink callback)
		{
			return CppObject.ToCallbackPtr<CommandSink>(callback);
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x060007B3 RID: 1971 RVA: 0x0001724C File Offset: 0x0001544C
		protected override CppObjectVtbl GetVtbl
		{
			get
			{
				return CommandSinkShadow.Vtbl;
			}
		}

		// Token: 0x040005FA RID: 1530
		private static readonly CommandSinkShadow.CommandSinkVtbl Vtbl = new CommandSinkShadow.CommandSinkVtbl();

		// Token: 0x02000191 RID: 401
		public class CommandSinkVtbl : ComObjectShadow.ComObjectVtbl
		{
			// Token: 0x060007B6 RID: 1974 RVA: 0x0001725F File Offset: 0x0001545F
			public CommandSinkVtbl() : this(0)
			{
			}

			// Token: 0x060007B7 RID: 1975 RVA: 0x00017268 File Offset: 0x00015468
			public CommandSinkVtbl(int numMethods) : base(numMethods + 28)
			{
				base.AddMethod(new CommandSinkShadow.CommandSinkVtbl.CallNoParams(CommandSinkShadow.CommandSinkVtbl.BeginDrawImpl));
				base.AddMethod(new CommandSinkShadow.CommandSinkVtbl.CallNoParams(CommandSinkShadow.CommandSinkVtbl.EndDrawImpl));
				base.AddMethod(new CommandSinkShadow.CommandSinkVtbl.SetAntialiasModeDelegate(CommandSinkShadow.CommandSinkVtbl.SetAntialiasModeImpl));
				base.AddMethod(new CommandSinkShadow.CommandSinkVtbl.SetTagsDelegate(CommandSinkShadow.CommandSinkVtbl.SetTagsImpl));
				base.AddMethod(new CommandSinkShadow.CommandSinkVtbl.SetTextAntialiasModeDelegate(CommandSinkShadow.CommandSinkVtbl.SetTextAntialiasModeImpl));
				base.AddMethod(new CommandSinkShadow.CommandSinkVtbl.SetTextRenderingParamsDelegate(CommandSinkShadow.CommandSinkVtbl.SetTextRenderingParamsImpl));
				base.AddMethod(new CommandSinkShadow.CommandSinkVtbl.SetTransformDelegate(CommandSinkShadow.CommandSinkVtbl.SetTransformImpl));
				base.AddMethod(new CommandSinkShadow.CommandSinkVtbl.SetPrimitiveBlendDelegate(CommandSinkShadow.CommandSinkVtbl.SetPrimitiveBlendImpl));
				base.AddMethod(new CommandSinkShadow.CommandSinkVtbl.SetUnitModeDelegate(CommandSinkShadow.CommandSinkVtbl.SetUnitModeImpl));
				base.AddMethod(new CommandSinkShadow.CommandSinkVtbl.ClearDelegate(CommandSinkShadow.CommandSinkVtbl.ClearImpl));
				base.AddMethod(new CommandSinkShadow.CommandSinkVtbl.DrawGlyphRunDelegate(CommandSinkShadow.CommandSinkVtbl.DrawGlyphRunImpl));
				base.AddMethod(new CommandSinkShadow.CommandSinkVtbl.DrawLineDelegate(CommandSinkShadow.CommandSinkVtbl.DrawLineImpl));
				base.AddMethod(new CommandSinkShadow.CommandSinkVtbl.DrawGeometryDelegate(CommandSinkShadow.CommandSinkVtbl.DrawGeometryImpl));
				base.AddMethod(new CommandSinkShadow.CommandSinkVtbl.DrawRectangleDelegate(CommandSinkShadow.CommandSinkVtbl.DrawRectangleImpl));
				base.AddMethod(new CommandSinkShadow.CommandSinkVtbl.DrawBitmapDelegate(CommandSinkShadow.CommandSinkVtbl.DrawBitmapImpl));
				base.AddMethod(new CommandSinkShadow.CommandSinkVtbl.DrawImageDelegate(CommandSinkShadow.CommandSinkVtbl.DrawImageImpl));
				base.AddMethod(new CommandSinkShadow.CommandSinkVtbl.DrawGdiMetafileDelegate(CommandSinkShadow.CommandSinkVtbl.DrawGdiMetafileImpl));
				base.AddMethod(new CommandSinkShadow.CommandSinkVtbl.FillMeshDelegate(CommandSinkShadow.CommandSinkVtbl.FillMeshImpl));
				base.AddMethod(new CommandSinkShadow.CommandSinkVtbl.FillOpacityMaskDelegate(CommandSinkShadow.CommandSinkVtbl.FillOpacityMaskImpl));
				base.AddMethod(new CommandSinkShadow.CommandSinkVtbl.FillGeometryDelegate(CommandSinkShadow.CommandSinkVtbl.FillGeometryImpl));
				base.AddMethod(new CommandSinkShadow.CommandSinkVtbl.FillRectangleDelegate(CommandSinkShadow.CommandSinkVtbl.FillRectangleImpl));
				base.AddMethod(new CommandSinkShadow.CommandSinkVtbl.PushAxisAlignedClipDelegate(CommandSinkShadow.CommandSinkVtbl.PushAxisAlignedClipImpl));
				base.AddMethod(new CommandSinkShadow.CommandSinkVtbl.PushLayerDelegate(CommandSinkShadow.CommandSinkVtbl.PushLayerImpl));
				base.AddMethod(new CommandSinkShadow.CommandSinkVtbl.CallNoParams(CommandSinkShadow.CommandSinkVtbl.PopAxisAlignedClipImpl));
				base.AddMethod(new CommandSinkShadow.CommandSinkVtbl.CallNoParams(CommandSinkShadow.CommandSinkVtbl.PopLayerImpl));
			}

			// Token: 0x060007B8 RID: 1976 RVA: 0x00017444 File Offset: 0x00015644
			private static int BeginDrawImpl(IntPtr thisPtr)
			{
				try
				{
					((CommandSink)CppObjectShadow.ToShadow<CommandSinkShadow>(thisPtr).Callback).BeginDraw();
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x060007B9 RID: 1977 RVA: 0x00017494 File Offset: 0x00015694
			private static int EndDrawImpl(IntPtr thisPtr)
			{
				try
				{
					((CommandSink)CppObjectShadow.ToShadow<CommandSinkShadow>(thisPtr).Callback).EndDraw();
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x060007BA RID: 1978 RVA: 0x000174E4 File Offset: 0x000156E4
			private static int SetAntialiasModeImpl(IntPtr thisPtr, AntialiasMode antialiasMode)
			{
				try
				{
					((CommandSink)CppObjectShadow.ToShadow<CommandSinkShadow>(thisPtr).Callback).AntialiasMode = antialiasMode;
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x060007BB RID: 1979 RVA: 0x00017538 File Offset: 0x00015738
			private static int SetTagsImpl(IntPtr thisPtr, long tag1, long tag2)
			{
				try
				{
					((CommandSink)CppObjectShadow.ToShadow<CommandSinkShadow>(thisPtr).Callback).SetTags(tag1, tag2);
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x060007BC RID: 1980 RVA: 0x0001758C File Offset: 0x0001578C
			private static int SetTextAntialiasModeImpl(IntPtr thisPtr, TextAntialiasMode textAntialiasMode)
			{
				try
				{
					((CommandSink)CppObjectShadow.ToShadow<CommandSinkShadow>(thisPtr).Callback).TextAntialiasMode = textAntialiasMode;
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x060007BD RID: 1981 RVA: 0x000175E0 File Offset: 0x000157E0
			private static int SetTextRenderingParamsImpl(IntPtr thisPtr, IntPtr textRenderingParams)
			{
				try
				{
					((CommandSink)CppObjectShadow.ToShadow<CommandSinkShadow>(thisPtr).Callback).TextRenderingParams = new RenderingParams(textRenderingParams);
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x060007BE RID: 1982 RVA: 0x00017638 File Offset: 0x00015838
			private unsafe static int SetTransformImpl(IntPtr thisPtr, IntPtr transform)
			{
				try
				{
					((CommandSink)CppObjectShadow.ToShadow<CommandSinkShadow>(thisPtr).Callback).Transform = *(RawMatrix3x2*)((void*)transform);
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x060007BF RID: 1983 RVA: 0x00017694 File Offset: 0x00015894
			private static int SetPrimitiveBlendImpl(IntPtr thisPtr, PrimitiveBlend primitiveBlend)
			{
				try
				{
					((CommandSink)CppObjectShadow.ToShadow<CommandSinkShadow>(thisPtr).Callback).PrimitiveBlend = primitiveBlend;
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x060007C0 RID: 1984 RVA: 0x000176E8 File Offset: 0x000158E8
			private static int SetUnitModeImpl(IntPtr thisPtr, UnitMode unitMode)
			{
				try
				{
					((CommandSink)CppObjectShadow.ToShadow<CommandSinkShadow>(thisPtr).Callback).UnitMode = unitMode;
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x060007C1 RID: 1985 RVA: 0x0001773C File Offset: 0x0001593C
			private unsafe static int ClearImpl(IntPtr thisPtr, IntPtr color)
			{
				try
				{
					((CommandSink)CppObjectShadow.ToShadow<CommandSinkShadow>(thisPtr).Callback).Clear((color == IntPtr.Zero) ? null : new RawColor4?(*(RawColor4*)((void*)color)));
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x060007C2 RID: 1986 RVA: 0x000177B4 File Offset: 0x000159B4
			private unsafe static int DrawGlyphRunImpl(IntPtr thisPtr, RawVector2 baselineOrigin, IntPtr glyphRunNative, IntPtr glyphRunDescriptionPtr, IntPtr foregroundBrush, MeasuringMode measuringMode)
			{
				GlyphRun glyphRun = new GlyphRun();
				try
				{
					GlyphRunDescription glyphRunDescription = new GlyphRunDescription();
					glyphRunDescription.__MarshalFrom(ref *(GlyphRunDescription.__Native*)((void*)glyphRunDescriptionPtr));
					glyphRun.__MarshalFrom(ref *(GlyphRun.__Native*)((void*)glyphRunNative));
					((CommandSink)CppObjectShadow.ToShadow<CommandSinkShadow>(thisPtr).Callback).DrawGlyphRun(baselineOrigin, glyphRun, glyphRunDescription, new Brush(foregroundBrush), measuringMode);
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				finally
				{
					glyphRun.__MarshalFree(ref *(GlyphRun.__Native*)((void*)glyphRunNative));
				}
				return Result.Ok.Code;
			}

			// Token: 0x060007C3 RID: 1987 RVA: 0x00017850 File Offset: 0x00015A50
			private static int DrawLineImpl(IntPtr thisPtr, RawVector2 point0, RawVector2 point1, IntPtr brush, float strokeWidth, IntPtr strokeStyle)
			{
				try
				{
					((CommandSink)CppObjectShadow.ToShadow<CommandSinkShadow>(thisPtr).Callback).DrawLine(point0, point1, new Brush(brush), strokeWidth, new StrokeStyle(strokeStyle));
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x060007C4 RID: 1988 RVA: 0x000178B4 File Offset: 0x00015AB4
			private static int DrawGeometryImpl(IntPtr thisPtr, IntPtr geometry, IntPtr brush, float strokeWidth, IntPtr strokeStyle)
			{
				try
				{
					((CommandSink)CppObjectShadow.ToShadow<CommandSinkShadow>(thisPtr).Callback).DrawGeometry(new Geometry(geometry), new Brush(brush), strokeWidth, new StrokeStyle(strokeStyle));
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x060007C5 RID: 1989 RVA: 0x00017918 File Offset: 0x00015B18
			private unsafe static int DrawRectangleImpl(IntPtr thisPtr, IntPtr rect, IntPtr brush, float strokeWidth, IntPtr strokeStyle)
			{
				try
				{
					((CommandSink)CppObjectShadow.ToShadow<CommandSinkShadow>(thisPtr).Callback).DrawRectangle(*(RawRectangleF*)((void*)rect), new Brush(brush), strokeWidth, new StrokeStyle(strokeStyle));
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x060007C6 RID: 1990 RVA: 0x00017984 File Offset: 0x00015B84
			private unsafe static int DrawBitmapImpl(IntPtr thisPtr, IntPtr bitmap, IntPtr destinationRectangle, float opacity, InterpolationMode interpolationMode, IntPtr sourceRectangle, IntPtr erspectiveTransformRef)
			{
				try
				{
					((CommandSink)CppObjectShadow.ToShadow<CommandSinkShadow>(thisPtr).Callback).DrawBitmap(new Bitmap(bitmap), (destinationRectangle == IntPtr.Zero) ? null : new RawRectangleF?(*(RawRectangleF*)((void*)destinationRectangle)), opacity, interpolationMode, (sourceRectangle == IntPtr.Zero) ? null : new RawRectangleF?(*(RawRectangleF*)((void*)sourceRectangle)), (erspectiveTransformRef == IntPtr.Zero) ? null : new RawMatrix?(*(RawMatrix*)((void*)erspectiveTransformRef)));
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x060007C7 RID: 1991 RVA: 0x00017A5C File Offset: 0x00015C5C
			private unsafe static int DrawImageImpl(IntPtr thisPtr, IntPtr image, IntPtr targetOffset, IntPtr imageRectangle, InterpolationMode interpolationMode, CompositeMode compositeMode)
			{
				try
				{
					((CommandSink)CppObjectShadow.ToShadow<CommandSinkShadow>(thisPtr).Callback).DrawImage(new Image(image), (targetOffset == IntPtr.Zero) ? null : new RawVector2?(*(RawVector2*)((void*)targetOffset)), (imageRectangle == IntPtr.Zero) ? null : new RawRectangleF?(*(RawRectangleF*)((void*)imageRectangle)), interpolationMode, compositeMode);
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x060007C8 RID: 1992 RVA: 0x00017B08 File Offset: 0x00015D08
			private unsafe static int DrawGdiMetafileImpl(IntPtr thisPtr, IntPtr gdiMetafile, IntPtr targetOffset)
			{
				try
				{
					((CommandSink)CppObjectShadow.ToShadow<CommandSinkShadow>(thisPtr).Callback).DrawGdiMetafile(new GdiMetafile(gdiMetafile), (targetOffset == IntPtr.Zero) ? null : new RawVector2?(*(RawVector2*)((void*)targetOffset)));
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x060007C9 RID: 1993 RVA: 0x00017B88 File Offset: 0x00015D88
			private static int FillMeshImpl(IntPtr thisPtr, IntPtr mesh, IntPtr brush)
			{
				try
				{
					((CommandSink)CppObjectShadow.ToShadow<CommandSinkShadow>(thisPtr).Callback).FillMesh(new Mesh(mesh), new Brush(brush));
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x060007CA RID: 1994 RVA: 0x00017BE4 File Offset: 0x00015DE4
			private unsafe static int FillOpacityMaskImpl(IntPtr thisPtr, IntPtr opacityMask, IntPtr brush, IntPtr destinationRectangle, IntPtr sourceRectangle)
			{
				try
				{
					((CommandSink)CppObjectShadow.ToShadow<CommandSinkShadow>(thisPtr).Callback).FillOpacityMask(new Bitmap(opacityMask), new Brush(brush), (destinationRectangle == IntPtr.Zero) ? null : new RawRectangleF?(*(RawRectangleF*)((void*)destinationRectangle)), (sourceRectangle == IntPtr.Zero) ? null : new RawRectangleF?(*(RawRectangleF*)((void*)sourceRectangle)));
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x060007CB RID: 1995 RVA: 0x00017C94 File Offset: 0x00015E94
			private static int FillGeometryImpl(IntPtr thisPtr, IntPtr geometry, IntPtr brush, IntPtr opacityBrush)
			{
				try
				{
					((CommandSink)CppObjectShadow.ToShadow<CommandSinkShadow>(thisPtr).Callback).FillGeometry(new Geometry(geometry), new Brush(brush), new Brush(opacityBrush));
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x060007CC RID: 1996 RVA: 0x00017CF8 File Offset: 0x00015EF8
			private unsafe static int FillRectangleImpl(IntPtr thisPtr, IntPtr rect, IntPtr brush)
			{
				try
				{
					((CommandSink)CppObjectShadow.ToShadow<CommandSinkShadow>(thisPtr).Callback).FillRectangle(*(RawRectangleF*)((void*)rect), new Brush(brush));
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x060007CD RID: 1997 RVA: 0x00017D5C File Offset: 0x00015F5C
			private unsafe static int PushAxisAlignedClipImpl(IntPtr thisPtr, IntPtr clipRect, AntialiasMode antialiasMode)
			{
				try
				{
					((CommandSink)CppObjectShadow.ToShadow<CommandSinkShadow>(thisPtr).Callback).PushAxisAlignedClip(*(RawRectangleF*)((void*)clipRect), antialiasMode);
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x060007CE RID: 1998 RVA: 0x00017DB8 File Offset: 0x00015FB8
			private unsafe static int PushLayerImpl(IntPtr thisPtr, IntPtr layerParameters1, IntPtr layer)
			{
				try
				{
					CommandSink commandSink = (CommandSink)CppObjectShadow.ToShadow<CommandSinkShadow>(thisPtr).Callback;
					LayerParameters1 layerParameters2 = default(LayerParameters1);
					layerParameters2.__MarshalFrom(ref *(LayerParameters1.__Native*)((void*)layerParameters1));
					commandSink.PushLayer(ref layerParameters2, (layer == IntPtr.Zero) ? null : new Layer(layer));
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x060007CF RID: 1999 RVA: 0x00017E38 File Offset: 0x00016038
			private static int PopAxisAlignedClipImpl(IntPtr thisPtr)
			{
				try
				{
					((CommandSink)CppObjectShadow.ToShadow<CommandSinkShadow>(thisPtr).Callback).PopAxisAlignedClip();
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x060007D0 RID: 2000 RVA: 0x00017E88 File Offset: 0x00016088
			private static int PopLayerImpl(IntPtr thisPtr)
			{
				try
				{
					((CommandSink)CppObjectShadow.ToShadow<CommandSinkShadow>(thisPtr).Callback).PopLayer();
				}
				catch (Exception ex)
				{
					return (int)Result.GetResultFromException(ex);
				}
				return Result.Ok.Code;
			}

			// Token: 0x02000192 RID: 402
			// (Invoke) Token: 0x060007D2 RID: 2002
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int CallNoParams(IntPtr thisPtr);

			// Token: 0x02000193 RID: 403
			// (Invoke) Token: 0x060007D6 RID: 2006
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int SetAntialiasModeDelegate(IntPtr thisPtr, AntialiasMode antialiasMode);

			// Token: 0x02000194 RID: 404
			// (Invoke) Token: 0x060007DA RID: 2010
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int SetTagsDelegate(IntPtr thisPtr, long tag1, long tag2);

			// Token: 0x02000195 RID: 405
			// (Invoke) Token: 0x060007DE RID: 2014
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int SetTextAntialiasModeDelegate(IntPtr thisPtr, TextAntialiasMode textAntialiasMode);

			// Token: 0x02000196 RID: 406
			// (Invoke) Token: 0x060007E2 RID: 2018
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int SetTextRenderingParamsDelegate(IntPtr thisPtr, IntPtr textRenderingParams);

			// Token: 0x02000197 RID: 407
			// (Invoke) Token: 0x060007E6 RID: 2022
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int SetTransformDelegate(IntPtr thisPtr, IntPtr transform);

			// Token: 0x02000198 RID: 408
			// (Invoke) Token: 0x060007EA RID: 2026
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int SetPrimitiveBlendDelegate(IntPtr thisPtr, PrimitiveBlend primitiveBlend);

			// Token: 0x02000199 RID: 409
			// (Invoke) Token: 0x060007EE RID: 2030
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int SetUnitModeDelegate(IntPtr thisPtr, UnitMode unitMode);

			// Token: 0x0200019A RID: 410
			// (Invoke) Token: 0x060007F2 RID: 2034
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int ClearDelegate(IntPtr thisPtr, IntPtr color);

			// Token: 0x0200019B RID: 411
			// (Invoke) Token: 0x060007F6 RID: 2038
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int DrawGlyphRunDelegate(IntPtr thisPtr, RawVector2 baselineOrigin, IntPtr glyphRun, IntPtr glyphRunDescriptionPtr, IntPtr foregroundBrush, MeasuringMode measuringMode);

			// Token: 0x0200019C RID: 412
			// (Invoke) Token: 0x060007FA RID: 2042
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int DrawLineDelegate(IntPtr thisPtr, RawVector2 point0, RawVector2 point1, IntPtr brush, float strokeWidth, IntPtr strokeStyle);

			// Token: 0x0200019D RID: 413
			// (Invoke) Token: 0x060007FE RID: 2046
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int DrawGeometryDelegate(IntPtr thisPtr, IntPtr geometry, IntPtr brush, float strokeWidth, IntPtr strokeStyle);

			// Token: 0x0200019E RID: 414
			// (Invoke) Token: 0x06000802 RID: 2050
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int DrawRectangleDelegate(IntPtr thisPtr, IntPtr rect, IntPtr brush, float strokeWidth, IntPtr strokeStyle);

			// Token: 0x0200019F RID: 415
			// (Invoke) Token: 0x06000806 RID: 2054
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int DrawBitmapDelegate(IntPtr thisPtr, IntPtr bitmap, IntPtr destinationRectangle, float opacity, InterpolationMode interpolationMode, IntPtr sourceRectangle, IntPtr erspectiveTransformRef);

			// Token: 0x020001A0 RID: 416
			// (Invoke) Token: 0x0600080A RID: 2058
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int DrawImageDelegate(IntPtr thisPtr, IntPtr image, IntPtr targetOffset, IntPtr imageRectangle, InterpolationMode interpolationMode, CompositeMode compositeMode);

			// Token: 0x020001A1 RID: 417
			// (Invoke) Token: 0x0600080E RID: 2062
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int DrawGdiMetafileDelegate(IntPtr thisPtr, IntPtr gdiMetafile, IntPtr targetOffset);

			// Token: 0x020001A2 RID: 418
			// (Invoke) Token: 0x06000812 RID: 2066
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int FillMeshDelegate(IntPtr thisPtr, IntPtr mesh, IntPtr brush);

			// Token: 0x020001A3 RID: 419
			// (Invoke) Token: 0x06000816 RID: 2070
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int FillOpacityMaskDelegate(IntPtr thisPtr, IntPtr opacityMask, IntPtr brush, IntPtr destinationRectangle, IntPtr sourceRectangle);

			// Token: 0x020001A4 RID: 420
			// (Invoke) Token: 0x0600081A RID: 2074
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int FillGeometryDelegate(IntPtr thisPtr, IntPtr geometry, IntPtr brush, IntPtr opacityBrush);

			// Token: 0x020001A5 RID: 421
			// (Invoke) Token: 0x0600081E RID: 2078
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int FillRectangleDelegate(IntPtr thisPtr, IntPtr rect, IntPtr brush);

			// Token: 0x020001A6 RID: 422
			// (Invoke) Token: 0x06000822 RID: 2082
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int PushAxisAlignedClipDelegate(IntPtr thisPtr, IntPtr clipRect, AntialiasMode antialiasMode);

			// Token: 0x020001A7 RID: 423
			// (Invoke) Token: 0x06000826 RID: 2086
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int PushLayerDelegate(IntPtr thisPtr, IntPtr layerParameters1, IntPtr layer);
		}
	}
}
