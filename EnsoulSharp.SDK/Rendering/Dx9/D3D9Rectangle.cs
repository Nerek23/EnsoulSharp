﻿using System;
using System.Collections.Generic;
using EnsoulSharp.SDK.Rendering.Interfaces;
using SharpDX;
using SharpDX.Direct3D9;
using SharpDX.Mathematics.Interop;

namespace EnsoulSharp.SDK.Rendering.Dx9
{
	// Token: 0x0200009C RID: 156
	internal class D3D9Rectangle : ID3DRectangle
	{
		// Token: 0x0600056B RID: 1387 RVA: 0x00025D28 File Offset: 0x00023F28
		public void Draw(Vector2 position, float width, float height, float borderWidth, Color color, Color borderColor)
		{
			if (Drawing.Direct3DDevice9 == null || Drawing.Direct3DDevice9.IsDisposed)
			{
				return;
			}
			if (D3D9Rectangle.vertexBuffer == null)
			{
				D3D9Rectangle.CreateVertexes();
			}
			if (D3D9Rectangle.vertexBuffer == null)
			{
				return;
			}
			try
			{
				if (!D3D9Rectangle.vertexBuffer.IsDisposed)
				{
					if (!D3D9Rectangle.vertexDeclaration.IsDisposed)
					{
						if (!D3D9Rectangle.effect.IsDisposed)
						{
							RawVector4 value;
							if (!D3D9Rectangle.ColorCache.TryGetValue(color.ToRgba(), out value))
							{
								value = new RawVector4((float)color.R / 255f, (float)color.G / 255f, (float)color.B / 255f, (float)color.A / 255f);
								D3D9Rectangle.ColorCache.Add(color.ToRgba(), value);
							}
							RawVector4 value2;
							if (!D3D9Rectangle.ColorCache.TryGetValue(borderColor.ToRgba(), out value2))
							{
								value2 = new RawVector4((float)borderColor.R / 255f, (float)borderColor.G / 255f, (float)borderColor.B / 255f, (float)borderColor.A / 255f);
								D3D9Rectangle.ColorCache.Add(borderColor.ToRgba(), value2);
							}
							VertexDeclaration vertexDeclaration = Drawing.Direct3DDevice9.VertexDeclaration;
							Surface renderTarget = Drawing.Direct3DDevice9.GetRenderTarget(0);
							D3D9Rectangle.effect.SetValue<Matrix>("Transform", Matrix.OrthoOffCenterLH(0f, (float)renderTarget.Description.Width, (float)renderTarget.Description.Height, 0f, -1f, 1f));
							D3D9Rectangle.effect.SetValue("Color", value);
							D3D9Rectangle.effect.SetValue("BorderColor", value2);
							D3D9Rectangle.effect.SetValue("Width", width);
							D3D9Rectangle.effect.SetValue("Height", height);
							D3D9Rectangle.effect.SetValue<Vector2>("Position", position);
							D3D9Rectangle.effect.SetValue("BorderWidth", borderWidth);
							D3D9Rectangle.effect.Begin();
							D3D9Rectangle.effect.BeginPass(0);
							Drawing.Direct3DDevice9.SetStreamSource(0, D3D9Rectangle.vertexBuffer, 0, Utilities.SizeOf<Vector4>());
							Drawing.Direct3DDevice9.VertexDeclaration = D3D9Rectangle.vertexDeclaration;
							Drawing.Direct3DDevice9.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2);
							D3D9Rectangle.effect.EndPass();
							D3D9Rectangle.effect.End();
							Drawing.Direct3DDevice9.VertexDeclaration = vertexDeclaration;
						}
					}
				}
			}
			catch
			{
				D3D9Rectangle.OnDispose(null, EventArgs.Empty);
			}
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x00025FCC File Offset: 0x000241CC
		private static void CreateVertexes()
		{
			D3D9Rectangle.vertexBuffer = new VertexBuffer(Drawing.Direct3DDevice9, Utilities.SizeOf<Vector4>() * 4, Usage.WriteOnly, VertexFormat.Texture0, Pool.Managed);
			D3D9Rectangle.vertexBuffer.Lock(0, 0, LockFlags.None).WriteRange<Vector4>(new Vector4[]
			{
				new Vector4(0f, (float)Library.GameCache.WindowsValue.WindowsHeight, 1f, 1f),
				new Vector4(0f, 0f, 1f, 1f),
				new Vector4((float)Library.GameCache.WindowsValue.WindowsWidth, (float)Library.GameCache.WindowsValue.WindowsHeight, 1f, 1f),
				new Vector4((float)Library.GameCache.WindowsValue.WindowsWidth, 0f, 1f, 1f)
			});
			D3D9Rectangle.vertexBuffer.Unlock();
			D3D9Rectangle.vertexDeclaration = new VertexDeclaration(Drawing.Direct3DDevice9, new VertexElement[]
			{
				new VertexElement(0, 0, DeclarationType.Float4, DeclarationMethod.Default, DeclarationUsage.Position, 0),
				VertexElement.VertexDeclarationEnd
			});
			byte[] memory = new byte[]
			{
				1,
				9,
				byte.MaxValue,
				254,
				104,
				2,
				0,
				0,
				0,
				0,
				0,
				0,
				3,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				48,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				4,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				6,
				0,
				0,
				0,
				67,
				111,
				108,
				111,
				114,
				0,
				0,
				0,
				3,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				104,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				4,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				12,
				0,
				0,
				0,
				66,
				111,
				114,
				100,
				101,
				114,
				67,
				111,
				108,
				111,
				114,
				0,
				3,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				212,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				4,
				0,
				0,
				0,
				4,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				10,
				0,
				0,
				0,
				84,
				114,
				97,
				110,
				115,
				102,
				111,
				114,
				109,
				0,
				0,
				0,
				3,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				4,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				6,
				0,
				0,
				0,
				87,
				105,
				100,
				116,
				104,
				0,
				0,
				0,
				3,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				48,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				7,
				0,
				0,
				0,
				72,
				101,
				105,
				103,
				104,
				116,
				0,
				0,
				3,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				92,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				12,
				0,
				0,
				0,
				66,
				111,
				114,
				100,
				101,
				114,
				87,
				105,
				100,
				116,
				104,
				0,
				3,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				144,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				9,
				0,
				0,
				0,
				80,
				111,
				115,
				105,
				116,
				105,
				111,
				110,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				6,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				5,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				16,
				0,
				0,
				0,
				4,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				15,
				0,
				0,
				0,
				4,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				3,
				0,
				0,
				0,
				80,
				48,
				0,
				0,
				9,
				0,
				0,
				0,
				77,
				111,
				118,
				101,
				109,
				101,
				110,
				116,
				0,
				0,
				0,
				0,
				7,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				3,
				0,
				0,
				0,
				3,
				0,
				0,
				0,
				4,
				0,
				0,
				0,
				32,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				60,
				0,
				0,
				0,
				88,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				120,
				0,
				0,
				0,
				148,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				228,
				0,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				16,
				1,
				0,
				0,
				44,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				60,
				1,
				0,
				0,
				88,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				108,
				1,
				0,
				0,
				136,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				88,
				2,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				80,
				2,
				0,
				0,
				0,
				0,
				0,
				0,
				6,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				164,
				1,
				0,
				0,
				160,
				1,
				0,
				0,
				13,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				196,
				1,
				0,
				0,
				192,
				1,
				0,
				0,
				7,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				228,
				1,
				0,
				0,
				224,
				1,
				0,
				0,
				6,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				4,
				2,
				0,
				0,
				0,
				2,
				0,
				0,
				146,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				36,
				2,
				0,
				0,
				32,
				2,
				0,
				0,
				147,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				60,
				2,
				0,
				0,
				56,
				2,
				0,
				0,
				0,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				5,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				92,
				5,
				0,
				0,
				0,
				2,
				byte.MaxValue,
				byte.MaxValue,
				254,
				byte.MaxValue,
				56,
				0,
				67,
				84,
				65,
				66,
				28,
				0,
				0,
				0,
				171,
				0,
				0,
				0,
				0,
				2,
				byte.MaxValue,
				byte.MaxValue,
				3,
				0,
				0,
				0,
				28,
				0,
				0,
				0,
				0,
				0,
				0,
				32,
				164,
				0,
				0,
				0,
				88,
				0,
				0,
				0,
				2,
				0,
				7,
				0,
				1,
				0,
				0,
				0,
				100,
				0,
				0,
				0,
				116,
				0,
				0,
				0,
				132,
				0,
				0,
				0,
				2,
				0,
				6,
				0,
				1,
				0,
				0,
				0,
				100,
				0,
				0,
				0,
				116,
				0,
				0,
				0,
				138,
				0,
				0,
				0,
				2,
				0,
				8,
				0,
				1,
				0,
				0,
				0,
				148,
				0,
				0,
				0,
				116,
				0,
				0,
				0,
				66,
				111,
				114,
				100,
				101,
				114,
				67,
				111,
				108,
				111,
				114,
				0,
				1,
				0,
				3,
				0,
				1,
				0,
				4,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				67,
				111,
				108,
				111,
				114,
				0,
				80,
				111,
				115,
				105,
				116,
				105,
				111,
				110,
				0,
				171,
				1,
				0,
				3,
				0,
				1,
				0,
				2,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				112,
				115,
				95,
				50,
				95,
				48,
				0,
				77,
				105,
				99,
				114,
				111,
				115,
				111,
				102,
				116,
				32,
				40,
				82,
				41,
				32,
				72,
				76,
				83,
				76,
				32,
				83,
				104,
				97,
				100,
				101,
				114,
				32,
				67,
				111,
				109,
				112,
				105,
				108,
				101,
				114,
				32,
				57,
				46,
				50,
				57,
				46,
				57,
				53,
				50,
				46,
				51,
				49,
				49,
				49,
				0,
				254,
				byte.MaxValue,
				186,
				0,
				80,
				82,
				69,
				83,
				1,
				2,
				88,
				70,
				254,
				byte.MaxValue,
				71,
				0,
				67,
				84,
				65,
				66,
				28,
				0,
				0,
				0,
				231,
				0,
				0,
				0,
				1,
				2,
				88,
				70,
				4,
				0,
				0,
				0,
				28,
				0,
				0,
				0,
				0,
				1,
				0,
				32,
				228,
				0,
				0,
				0,
				108,
				0,
				0,
				0,
				2,
				0,
				2,
				0,
				1,
				0,
				0,
				0,
				120,
				0,
				0,
				0,
				136,
				0,
				0,
				0,
				152,
				0,
				0,
				0,
				2,
				0,
				1,
				0,
				1,
				0,
				0,
				0,
				160,
				0,
				0,
				0,
				136,
				0,
				0,
				0,
				176,
				0,
				0,
				0,
				2,
				0,
				3,
				0,
				1,
				0,
				0,
				0,
				188,
				0,
				0,
				0,
				136,
				0,
				0,
				0,
				204,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				212,
				0,
				0,
				0,
				136,
				0,
				0,
				0,
				66,
				111,
				114,
				100,
				101,
				114,
				87,
				105,
				100,
				116,
				104,
				0,
				0,
				0,
				3,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				72,
				101,
				105,
				103,
				104,
				116,
				0,
				171,
				0,
				0,
				3,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				80,
				111,
				115,
				105,
				116,
				105,
				111,
				110,
				0,
				171,
				171,
				171,
				1,
				0,
				3,
				0,
				1,
				0,
				2,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				87,
				105,
				100,
				116,
				104,
				0,
				171,
				171,
				0,
				0,
				3,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				116,
				120,
				0,
				77,
				105,
				99,
				114,
				111,
				115,
				111,
				102,
				116,
				32,
				40,
				82,
				41,
				32,
				72,
				76,
				83,
				76,
				32,
				83,
				104,
				97,
				100,
				101,
				114,
				32,
				67,
				111,
				109,
				112,
				105,
				108,
				101,
				114,
				32,
				57,
				46,
				50,
				57,
				46,
				57,
				53,
				50,
				46,
				51,
				49,
				49,
				49,
				0,
				254,
				byte.MaxValue,
				12,
				0,
				80,
				82,
				83,
				73,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				6,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				6,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				254,
				byte.MaxValue,
				2,
				0,
				67,
				76,
				73,
				84,
				0,
				0,
				0,
				0,
				254,
				byte.MaxValue,
				94,
				0,
				70,
				88,
				76,
				67,
				9,
				0,
				0,
				0,
				1,
				0,
				64,
				160,
				2,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				12,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				7,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				0,
				64,
				160,
				2,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				7,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				8,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				4,
				0,
				0,
				0,
				8,
				0,
				0,
				0,
				1,
				0,
				0,
				16,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				7,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				4,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				0,
				16,
				16,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				8,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				7,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				0,
				64,
				160,
				2,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				7,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				12,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				4,
				0,
				0,
				0,
				12,
				0,
				0,
				0,
				1,
				0,
				64,
				160,
				2,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				7,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				13,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				4,
				0,
				0,
				0,
				20,
				0,
				0,
				0,
				1,
				0,
				64,
				160,
				2,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				4,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				13,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				7,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				0,
				64,
				160,
				2,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				7,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				8,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				4,
				0,
				0,
				0,
				16,
				0,
				0,
				0,
				1,
				0,
				0,
				16,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				7,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				4,
				0,
				0,
				0,
				4,
				0,
				0,
				0,
				240,
				240,
				240,
				240,
				15,
				15,
				15,
				15,
				byte.MaxValue,
				byte.MaxValue,
				0,
				0,
				81,
				0,
				0,
				5,
				9,
				0,
				15,
				160,
				0,
				0,
				0,
				128,
				0,
				0,
				128,
				191,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				31,
				0,
				0,
				2,
				0,
				0,
				0,
				128,
				0,
				0,
				3,
				176,
				2,
				0,
				0,
				3,
				0,
				0,
				8,
				128,
				0,
				0,
				85,
				177,
				5,
				0,
				0,
				160,
				88,
				0,
				0,
				4,
				0,
				0,
				1,
				128,
				0,
				0,
				byte.MaxValue,
				128,
				9,
				0,
				0,
				160,
				9,
				0,
				85,
				160,
				2,
				0,
				0,
				3,
				0,
				0,
				2,
				128,
				0,
				0,
				85,
				176,
				4,
				0,
				0,
				161,
				88,
				0,
				0,
				4,
				0,
				0,
				1,
				128,
				0,
				0,
				85,
				128,
				9,
				0,
				0,
				160,
				0,
				0,
				0,
				128,
				2,
				0,
				0,
				3,
				0,
				0,
				2,
				128,
				0,
				0,
				0,
				177,
				3,
				0,
				0,
				160,
				88,
				0,
				0,
				4,
				0,
				0,
				1,
				128,
				0,
				0,
				85,
				128,
				9,
				0,
				0,
				160,
				0,
				0,
				0,
				128,
				2,
				0,
				0,
				3,
				0,
				0,
				2,
				128,
				0,
				0,
				0,
				176,
				2,
				0,
				0,
				161,
				88,
				0,
				0,
				4,
				0,
				0,
				1,
				128,
				0,
				0,
				85,
				128,
				9,
				0,
				0,
				160,
				0,
				0,
				0,
				128,
				1,
				0,
				0,
				2,
				0,
				0,
				4,
				128,
				9,
				0,
				170,
				160,
				88,
				0,
				0,
				4,
				0,
				0,
				15,
				128,
				0,
				0,
				0,
				128,
				0,
				0,
				170,
				128,
				7,
				0,
				228,
				160,
				2,
				0,
				0,
				3,
				1,
				0,
				8,
				128,
				0,
				0,
				85,
				177,
				8,
				0,
				85,
				160,
				88,
				0,
				0,
				4,
				1,
				0,
				1,
				128,
				1,
				0,
				byte.MaxValue,
				128,
				9,
				0,
				0,
				160,
				9,
				0,
				85,
				160,
				2,
				0,
				0,
				3,
				1,
				0,
				2,
				128,
				0,
				0,
				85,
				176,
				1,
				0,
				0,
				161,
				88,
				0,
				0,
				4,
				1,
				0,
				1,
				128,
				1,
				0,
				85,
				128,
				9,
				0,
				0,
				160,
				1,
				0,
				0,
				128,
				2,
				0,
				0,
				3,
				1,
				0,
				2,
				128,
				0,
				0,
				0,
				177,
				8,
				0,
				0,
				160,
				88,
				0,
				0,
				4,
				1,
				0,
				1,
				128,
				1,
				0,
				85,
				128,
				9,
				0,
				0,
				160,
				1,
				0,
				0,
				128,
				2,
				0,
				0,
				3,
				1,
				0,
				2,
				128,
				0,
				0,
				0,
				176,
				0,
				0,
				0,
				161,
				88,
				0,
				0,
				4,
				1,
				0,
				1,
				128,
				1,
				0,
				85,
				128,
				9,
				0,
				0,
				160,
				1,
				0,
				0,
				128,
				88,
				0,
				0,
				4,
				0,
				0,
				15,
				128,
				1,
				0,
				0,
				128,
				0,
				0,
				228,
				128,
				6,
				0,
				228,
				160,
				1,
				0,
				0,
				2,
				0,
				8,
				15,
				128,
				0,
				0,
				228,
				128,
				byte.MaxValue,
				byte.MaxValue,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				4,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				68,
				1,
				0,
				0,
				0,
				2,
				254,
				byte.MaxValue,
				254,
				byte.MaxValue,
				50,
				0,
				67,
				84,
				65,
				66,
				28,
				0,
				0,
				0,
				147,
				0,
				0,
				0,
				0,
				2,
				254,
				byte.MaxValue,
				1,
				0,
				0,
				0,
				28,
				0,
				0,
				0,
				0,
				0,
				0,
				32,
				140,
				0,
				0,
				0,
				48,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				4,
				0,
				0,
				0,
				60,
				0,
				0,
				0,
				76,
				0,
				0,
				0,
				84,
				114,
				97,
				110,
				115,
				102,
				111,
				114,
				109,
				0,
				171,
				171,
				3,
				0,
				3,
				0,
				4,
				0,
				4,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				118,
				115,
				95,
				50,
				95,
				48,
				0,
				77,
				105,
				99,
				114,
				111,
				115,
				111,
				102,
				116,
				32,
				40,
				82,
				41,
				32,
				72,
				76,
				83,
				76,
				32,
				83,
				104,
				97,
				100,
				101,
				114,
				32,
				67,
				111,
				109,
				112,
				105,
				108,
				101,
				114,
				32,
				57,
				46,
				50,
				57,
				46,
				57,
				53,
				50,
				46,
				51,
				49,
				49,
				49,
				0,
				31,
				0,
				0,
				2,
				0,
				0,
				0,
				128,
				0,
				0,
				15,
				144,
				31,
				0,
				0,
				2,
				10,
				0,
				0,
				128,
				1,
				0,
				15,
				144,
				9,
				0,
				0,
				3,
				0,
				0,
				1,
				192,
				0,
				0,
				228,
				144,
				0,
				0,
				228,
				160,
				9,
				0,
				0,
				3,
				0,
				0,
				2,
				192,
				0,
				0,
				228,
				144,
				1,
				0,
				228,
				160,
				9,
				0,
				0,
				3,
				0,
				0,
				4,
				192,
				0,
				0,
				228,
				144,
				2,
				0,
				228,
				160,
				9,
				0,
				0,
				3,
				0,
				0,
				8,
				192,
				0,
				0,
				228,
				144,
				3,
				0,
				228,
				160,
				1,
				0,
				0,
				2,
				0,
				0,
				15,
				208,
				1,
				0,
				228,
				144,
				1,
				0,
				0,
				2,
				0,
				0,
				15,
				224,
				0,
				0,
				228,
				144,
				byte.MaxValue,
				byte.MaxValue,
				0,
				0
			};
			D3D9Rectangle.effect = Effect.FromMemory(Drawing.Direct3DDevice9, memory, ShaderFlags.OptimizationLevel1);
			Render.OnPreReset += D3D9Rectangle.OnPreReset;
			Render.OnPostReset += D3D9Rectangle.OnPostReset;
			AppDomain.CurrentDomain.DomainUnload += D3D9Rectangle.OnDispose;
			AppDomain.CurrentDomain.ProcessExit += D3D9Rectangle.OnDispose;
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x00026168 File Offset: 0x00024368
		private static void OnPreReset(EventArgs args)
		{
			if (D3D9Rectangle.effect != null && !D3D9Rectangle.effect.IsDisposed)
			{
				D3D9Rectangle.effect.OnLostDevice();
			}
		}

		// Token: 0x0600056E RID: 1390 RVA: 0x00026187 File Offset: 0x00024387
		private static void OnPostReset(EventArgs args)
		{
			if (D3D9Rectangle.effect != null && !D3D9Rectangle.effect.IsDisposed)
			{
				D3D9Rectangle.effect.OnResetDevice();
			}
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x000261A8 File Offset: 0x000243A8
		private static void OnDispose(object sender, EventArgs args)
		{
			D3D9Rectangle.OnPreReset(EventArgs.Empty);
			if (D3D9Rectangle.effect != null && !D3D9Rectangle.effect.IsDisposed)
			{
				D3D9Rectangle.effect.Dispose();
				D3D9Rectangle.effect = null;
			}
			if (D3D9Rectangle.vertexBuffer != null && !D3D9Rectangle.vertexBuffer.IsDisposed)
			{
				D3D9Rectangle.vertexBuffer.Dispose();
				D3D9Rectangle.vertexBuffer = null;
			}
			if (D3D9Rectangle.vertexDeclaration != null && !D3D9Rectangle.vertexDeclaration.IsDisposed)
			{
				D3D9Rectangle.vertexDeclaration.Dispose();
				D3D9Rectangle.vertexDeclaration = null;
			}
		}

		// Token: 0x040002F7 RID: 759
		private static Effect effect;

		// Token: 0x040002F8 RID: 760
		private static VertexBuffer vertexBuffer;

		// Token: 0x040002F9 RID: 761
		private static VertexDeclaration vertexDeclaration;

		// Token: 0x040002FA RID: 762
		private static readonly Dictionary<int, RawVector4> ColorCache = new Dictionary<int, RawVector4>();
	}
}
