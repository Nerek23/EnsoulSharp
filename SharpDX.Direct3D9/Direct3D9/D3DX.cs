using System;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000016 RID: 22
	public static class D3DX
	{
		// Token: 0x060000EC RID: 236 RVA: 0x0000524B File Offset: 0x0000344B
		public static bool CheckVersion()
		{
			return D3DX9.CheckVersion(32, 43);
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000525B File Offset: 0x0000345B
		public static bool DebugMute(bool mute)
		{
			return D3DX9.DebugMute(mute);
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00005270 File Offset: 0x00003470
		public static VertexElement[] DeclaratorFromFVF(VertexFormat fvf)
		{
			VertexElement[] array = new VertexElement[65];
			if (D3DX9.DeclaratorFromFVF(fvf, array).Failure)
			{
				return null;
			}
			VertexElement[] array2 = new VertexElement[D3DX9.GetDeclLength(array) + 1];
			Array.Copy(array, array2, array2.Length);
			array2[array2.Length - 1] = VertexElement.VertexDeclarationEnd;
			return array2;
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000052C1 File Offset: 0x000034C1
		public static VertexFormat FVFFromDeclarator(VertexElement[] declarator)
		{
			return D3DX9.FVFFromDeclarator(declarator);
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x000052CC File Offset: 0x000034CC
		public static VertexElement[] GenerateOutputDeclaration(VertexElement[] declaration)
		{
			VertexElement[] array = new VertexElement[65];
			if (D3DX9.GenerateOutputDecl(array, declaration).Failure)
			{
				return null;
			}
			VertexElement[] array2 = new VertexElement[D3DX9.GetDeclLength(array) + 1];
			Array.Copy(array, array2, array2.Length);
			array2[array2.Length - 1] = VertexElement.VertexDeclarationEnd;
			return array2;
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000531D File Offset: 0x0000351D
		public static int GetDeclarationLength(VertexElement[] declaration)
		{
			return D3DX9.GetDeclLength(declaration);
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00005325 File Offset: 0x00003525
		public static int GetDeclarationVertexSize(VertexElement[] elements, int stream)
		{
			return D3DX9.GetDeclVertexSize(elements, stream);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0000532E File Offset: 0x0000352E
		public static int GetFVFVertexSize(VertexFormat fvf)
		{
			return D3DX9.GetFVFVertexSize(fvf);
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00005336 File Offset: 0x00003536
		public static Result GetRectanglePatchSize(float segmentCount, out int triangleCount, out int vertexCount)
		{
			return D3DX9.RectPatchSize(segmentCount, out triangleCount, out vertexCount);
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00005340 File Offset: 0x00003540
		public static Result GetTrianglePatchSize(float segmentCount, out int triangleCount, out int vertexCount)
		{
			return D3DX9.TriPatchSize(segmentCount, out triangleCount, out vertexCount);
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x0000534C File Offset: 0x0000354C
		public static RawVector3[] GetVectors(DataStream stream, int vertexCount, VertexFormat format)
		{
			int fvfvertexSize = D3DX.GetFVFVertexSize(format);
			return D3DX.GetVectors(stream, vertexCount, fvfvertexSize);
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00005368 File Offset: 0x00003568
		public static RawVector3[] GetVectors(DataStream stream, int vertexCount, int stride)
		{
			RawVector3[] array = new RawVector3[vertexCount];
			for (int i = 0; i < vertexCount; i++)
			{
				array[i] = stream.Read<RawVector3>();
				stream.Position += (long)(stride - sizeof(RawVector3));
			}
			return array;
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x000053AC File Offset: 0x000035AC
		public static Format MakeFourCC(byte c1, byte c2, byte c3, byte c4)
		{
			return (Format)((((int)c4 << 8 | (int)c3) << 8 | (int)c2) << 8 | (int)c1);
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x000053BC File Offset: 0x000035BC
		public unsafe static int[] OptimizeFaces(short[] indices, int faceCount, int vertexCount)
		{
			int[] array = new int[faceCount];
			Result result;
			fixed (short[] array2 = indices)
			{
				void* value;
				if (indices == null || array2.Length == 0)
				{
					value = null;
				}
				else
				{
					value = (void*)(&array2[0]);
				}
				result = D3DX9.OptimizeFaces((IntPtr)value, faceCount, indices.Length, false, array);
			}
			if (result.Failure)
			{
				return null;
			}
			return array;
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00005410 File Offset: 0x00003610
		public unsafe static int[] OptimizeFaces(int[] indices, int faceCount, int vertexCount)
		{
			int[] array = new int[faceCount];
			Result result;
			fixed (int[] array2 = indices)
			{
				void* value;
				if (indices == null || array2.Length == 0)
				{
					value = null;
				}
				else
				{
					value = (void*)(&array2[0]);
				}
				result = D3DX9.OptimizeFaces((IntPtr)value, faceCount, indices.Length, true, array);
			}
			if (result.Failure)
			{
				return null;
			}
			return array;
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00005464 File Offset: 0x00003664
		public unsafe static int[] OptimizeVertices(short[] indices, int faceCount, int vertexCount)
		{
			int[] array = new int[vertexCount];
			Result result;
			fixed (short[] array2 = indices)
			{
				void* value;
				if (indices == null || array2.Length == 0)
				{
					value = null;
				}
				else
				{
					value = (void*)(&array2[0]);
				}
				result = D3DX9.OptimizeVertices((IntPtr)value, faceCount, indices.Length, false, array);
			}
			if (result.Failure)
			{
				return null;
			}
			return array;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x000054B8 File Offset: 0x000036B8
		public unsafe static int[] OptimizeVertices(int[] indices, int faceCount, int vertexCount)
		{
			int[] array = new int[vertexCount];
			Result result;
			fixed (int[] array2 = indices)
			{
				void* value;
				if (indices == null || array2.Length == 0)
				{
					value = null;
				}
				else
				{
					value = (void*)(&array2[0]);
				}
				result = D3DX9.OptimizeVertices((IntPtr)value, faceCount, indices.Length, true, array);
			}
			if (result.Failure)
			{
				return null;
			}
			return array;
		}

		// Token: 0x040004A9 RID: 1193
		public const int Default = -1;

		// Token: 0x040004AA RID: 1194
		public const int DefaultNonPowerOf2 = -2;

		// Token: 0x040004AB RID: 1195
		public const int FormatFromFile = -3;

		// Token: 0x040004AC RID: 1196
		public const int FromFile = -3;
	}
}
