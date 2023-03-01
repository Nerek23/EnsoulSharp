using System;
using System.Runtime.InteropServices;
using SharpDX.Direct2D1;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000DF RID: 223
	internal class TextRendererShadow : PixelSnappingShadow
	{
		// Token: 0x060004CF RID: 1231 RVA: 0x0000FD71 File Offset: 0x0000DF71
		public static IntPtr ToIntPtr(TextRenderer callback)
		{
			return CppObject.ToCallbackPtr<TextRenderer>(callback);
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060004D0 RID: 1232 RVA: 0x0000FD79 File Offset: 0x0000DF79
		protected override CppObjectVtbl GetVtbl
		{
			get
			{
				return TextRendererShadow.Vtbl;
			}
		}

		// Token: 0x0400026C RID: 620
		private static readonly TextRendererShadow.TextRendererVtbl Vtbl = new TextRendererShadow.TextRendererVtbl();

		// Token: 0x020000E0 RID: 224
		private class TextRendererVtbl : PixelSnappingShadow.PixelSnappingVtbl
		{
			// Token: 0x060004D3 RID: 1235 RVA: 0x0000FD94 File Offset: 0x0000DF94
			public TextRendererVtbl() : base(4)
			{
				base.AddMethod(new TextRendererShadow.TextRendererVtbl.DrawGlyphRunDelegate(TextRendererShadow.TextRendererVtbl.DrawGlyphRunImpl));
				base.AddMethod(new TextRendererShadow.TextRendererVtbl.DrawUnderlineDelegate(TextRendererShadow.TextRendererVtbl.DrawUnderlineImpl));
				base.AddMethod(new TextRendererShadow.TextRendererVtbl.DrawStrikethroughDelegate(TextRendererShadow.TextRendererVtbl.DrawStrikethroughImpl));
				base.AddMethod(new TextRendererShadow.TextRendererVtbl.DrawInlineObjectDelegate(TextRendererShadow.TextRendererVtbl.DrawInlineObjectImpl));
			}

			// Token: 0x060004D4 RID: 1236 RVA: 0x0000FDF0 File Offset: 0x0000DFF0
			private static int DrawGlyphRunImpl(IntPtr thisObject, IntPtr clientDrawingContextPtr, float baselineOriginX, float baselineOriginY, MeasuringMode measuringMode, IntPtr glyphRunPtr, IntPtr glyphRunDescriptionPtr, IntPtr clientDrawingEffectPtr)
			{
				TextRenderer textRenderer = (TextRenderer)CppObjectShadow.ToShadow<TextRendererShadow>(thisObject).Callback;
				GlyphRun.__Native _Native = default(GlyphRun.__Native);
				Utilities.Read<GlyphRun.__Native>(glyphRunPtr, ref _Native);
				int code;
				using (GlyphRun glyphRun = new GlyphRun())
				{
					glyphRun.__MarshalFrom(ref _Native);
					GlyphRunDescription.__Native _Native2 = default(GlyphRunDescription.__Native);
					Utilities.Read<GlyphRunDescription.__Native>(glyphRunDescriptionPtr, ref _Native2);
					GlyphRunDescription glyphRunDescription = new GlyphRunDescription();
					glyphRunDescription.__MarshalFrom(ref _Native2);
					code = textRenderer.DrawGlyphRun(GCHandle.FromIntPtr(clientDrawingContextPtr).Target, baselineOriginX, baselineOriginY, measuringMode, glyphRun, glyphRunDescription, (ComObject)Utilities.GetObjectForIUnknown(clientDrawingEffectPtr)).Code;
				}
				return code;
			}

			// Token: 0x060004D5 RID: 1237 RVA: 0x0000FEA0 File Offset: 0x0000E0A0
			private unsafe static int DrawUnderlineImpl(IntPtr thisObject, IntPtr clientDrawingContextPtr, float baselineOriginX, float baselineOriginY, Underline.__Native* underline, IntPtr clientDrawingEffectPtr)
			{
				TextRenderer textRenderer = (TextRenderer)CppObjectShadow.ToShadow<TextRendererShadow>(thisObject).Callback;
				Underline underline2 = default(Underline);
				underline2.__MarshalFrom(ref *underline);
				return textRenderer.DrawUnderline(GCHandle.FromIntPtr(clientDrawingContextPtr).Target, baselineOriginX, baselineOriginY, ref underline2, (ComObject)Utilities.GetObjectForIUnknown(clientDrawingEffectPtr)).Code;
			}

			// Token: 0x060004D6 RID: 1238 RVA: 0x0000FEFC File Offset: 0x0000E0FC
			private unsafe static int DrawStrikethroughImpl(IntPtr thisObject, IntPtr clientDrawingContextPtr, float baselineOriginX, float baselineOriginY, Strikethrough.__Native* strikethrough, IntPtr clientDrawingEffectPtr)
			{
				TextRenderer textRenderer = (TextRenderer)CppObjectShadow.ToShadow<TextRendererShadow>(thisObject).Callback;
				Strikethrough strikethrough2 = default(Strikethrough);
				strikethrough2.__MarshalFrom(ref *strikethrough);
				return textRenderer.DrawStrikethrough(GCHandle.FromIntPtr(clientDrawingContextPtr).Target, baselineOriginX, baselineOriginY, ref strikethrough2, (ComObject)Utilities.GetObjectForIUnknown(clientDrawingEffectPtr)).Code;
			}

			// Token: 0x060004D7 RID: 1239 RVA: 0x0000FF58 File Offset: 0x0000E158
			private static int DrawInlineObjectImpl(IntPtr thisObject, IntPtr clientDrawingContextPtr, float originX, float originY, IntPtr inlineObject, int isSideways, int isRightToLeft, IntPtr clientDrawingEffectPtr)
			{
				return ((TextRenderer)CppObjectShadow.ToShadow<TextRendererShadow>(thisObject).Callback).DrawInlineObject(GCHandle.FromIntPtr(clientDrawingContextPtr).Target, originX, originY, new InlineObjectNative(inlineObject), isSideways != 0, isRightToLeft != 0, (ComObject)Utilities.GetObjectForIUnknown(clientDrawingEffectPtr)).Code;
			}

			// Token: 0x020000E1 RID: 225
			// (Invoke) Token: 0x060004D9 RID: 1241
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int DrawGlyphRunDelegate(IntPtr thisObject, IntPtr clientDrawingContext, float baselineOriginX, float baselineOriginY, MeasuringMode measuringMode, IntPtr glyphRunPtr, IntPtr glyphRunDescription, IntPtr clientDrawingEffect);

			// Token: 0x020000E2 RID: 226
			// (Invoke) Token: 0x060004DD RID: 1245
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private unsafe delegate int DrawUnderlineDelegate(IntPtr thisObject, IntPtr clientDrawingContext, float baselineOriginX, float baselineOriginY, Underline.__Native* underline, IntPtr clientDrawingEffect);

			// Token: 0x020000E3 RID: 227
			// (Invoke) Token: 0x060004E1 RID: 1249
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private unsafe delegate int DrawStrikethroughDelegate(IntPtr thisObject, IntPtr clientDrawingContext, float baselineOriginX, float baselineOriginY, Strikethrough.__Native* strikethrough, IntPtr clientDrawingEffect);

			// Token: 0x020000E4 RID: 228
			// (Invoke) Token: 0x060004E5 RID: 1253
			[UnmanagedFunctionPointer(CallingConvention.StdCall)]
			private delegate int DrawInlineObjectDelegate(IntPtr thisObject, IntPtr clientDrawingContext, float originX, float originY, IntPtr inlineObject, int isSideways, int isRightToLeft, IntPtr clientDrawingEffect);
		}
	}
}
