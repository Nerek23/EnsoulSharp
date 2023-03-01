using System;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000213 RID: 531
	public static class PropertyTypeHelper
	{
		// Token: 0x06000BA1 RID: 2977 RVA: 0x00020E78 File Offset: 0x0001F078
		public static string ConvertToString(PropertyType propertyType)
		{
			switch (propertyType)
			{
			case PropertyType.Unknown:
				return "unknown";
			case PropertyType.String:
				return "string";
			case PropertyType.Bool:
				return "bool";
			case PropertyType.UInt32:
				return "uint32";
			case PropertyType.Int32:
				return "int32";
			case PropertyType.Float:
				return "float";
			case PropertyType.Vector2:
				return "vector2";
			case PropertyType.Vector3:
				return "vector3";
			case PropertyType.Vector4:
				return "vector4";
			case PropertyType.IUnknown:
				return "iunknown";
			case PropertyType.Enum:
				return "enum";
			case PropertyType.Clsid:
				return "clsid";
			case PropertyType.Matrix3x2:
				return "matrix3x2";
			case PropertyType.Matrix4x3:
				return "matrix4x3";
			case PropertyType.Matrix4x4:
				return "matrix4x4";
			case PropertyType.Matrix5x4:
				return "matrix5x4";
			case PropertyType.ColorContext:
				return "colorcontext";
			}
			return "unknown";
		}
	}
}
