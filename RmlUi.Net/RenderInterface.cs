using System.Numerics;

namespace ChickenWithLips.RmlUi;

public abstract class RenderInterface : RmlBase<RenderInterface>
{
    private Native.RenderInterface.OnRenderGeometry _onRenderGeometry;
    private Native.RenderInterface.OnGenerateTexture _onGenerateTexture;
    private Native.RenderInterface.OnLoadTexture _onLoadTexture;
    private Native.RenderInterface.OnReleaseTexture _onReleaseTexture;

    public RenderInterface() : base(IntPtr.Zero)
    {
        _onRenderGeometry = RenderGeometry;
        _onGenerateTexture = GenerateTexture;
        _onLoadTexture = LoadTexture;
        _onReleaseTexture = ReleaseTexture;

        NativePtr = Native.RenderInterface.Create(
            _onRenderGeometry,
            _onGenerateTexture,
            _onLoadTexture,
            _onReleaseTexture
        );

        ManuallyRegisterCache(NativePtr, this);
    }

    public virtual void RenderGeometry(Vertex[] vertices, int vertexCount, int[] indices, int indexCount,
        ulong texture,
        Vector2 translation)
    {
    }

    public virtual bool GenerateTexture(out ulong textureHandle, byte[] source, int sourceSize, Vector2i sourceDimensions)
    {
        textureHandle = 0;

        return false;
    }

    public virtual bool LoadTexture(out ulong textureHandle, Vector2i textureDimensions, string source)
    {
        textureHandle = 0;

        return false;
    }

    public virtual void ReleaseTexture(IntPtr textureHandle)
    {
    }
}
