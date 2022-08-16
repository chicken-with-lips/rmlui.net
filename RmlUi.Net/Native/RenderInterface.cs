using System.Numerics;
using System.Runtime.InteropServices;

namespace ChickenWithLips.RmlUi.Native;

internal static class RenderInterface
{
    [DllImport("RmlUi.Native", EntryPoint = "rml_RenderInterface_New")]
    public static extern IntPtr Create(OnRenderGeometry onRenderGeometry, OnGenerateTexture onGenerateTexture, OnLoadTexture onLoadTexture, OnReleaseTexture onReleaseTexture);

    internal delegate void OnRenderGeometry(
        [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]
        Vertex[] vertices,
        int vertexCount,
        [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]
        int[] indices,
        int indexCount,
        ulong texture,
        Vector2 translation);

    internal delegate bool OnGenerateTexture(
        out ulong textureHandle,
        [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
        byte[] source,
        int sourceSize,
        Vector2i sourceDimensions);

    internal delegate bool OnLoadTexture(
        out ulong textureHandle,
        Vector2i textureDimensions,
        string source);

    internal delegate void OnReleaseTexture(IntPtr textureHandle);
}
