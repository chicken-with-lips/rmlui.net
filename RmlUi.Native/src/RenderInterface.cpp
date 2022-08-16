#include <iostream>
#include "RmlUi/Core/RenderInterface.h"


typedef void(*onRenderGeometry)(Rml::Vertex *vertices,
                                int num_vertices,
                                int *indices,
                                int num_indices,
                                Rml::TextureHandle texture,
                                const Rml::Vector2f translation);

typedef bool(*onGenerateTexture)(
        Rml::TextureHandle &texture_handle,
        const Rml::byte *source,
        const int source_size,
        const Rml::Vector2i source_dimensions);

typedef bool(*onLoadTexture)(Rml::TextureHandle &texture_handle,
                             Rml::Vector2i texture_dimensions,
                             const char *source);

typedef void(*onReleaseTexture)(Rml::TextureHandle texture_handle);

class RenderInterface : Rml::RenderInterface {
private:
    ::onRenderGeometry m_onRenderGeometry;
    ::onGenerateTexture m_onGenerateTexture;
    ::onLoadTexture m_onLoadTexture;
    ::onReleaseTexture m_onReleaseTexture;

public:
    explicit RenderInterface(::onRenderGeometry onRenderGeometry, ::onGenerateTexture onGenerateTexture,
                             ::onLoadTexture onLoadTexture,
                             ::onReleaseTexture onReleaseTexture) {
        m_onRenderGeometry = onRenderGeometry;
        m_onGenerateTexture = onGenerateTexture;
        m_onLoadTexture = onLoadTexture;
        m_onReleaseTexture = onReleaseTexture;
    }

    void RenderGeometry(Rml::Vertex *vertices,
                        int num_vertices,
                        int *indices,
                        int num_indices,
                        Rml::TextureHandle texture,
                        const Rml::Vector2f &translation) override {
        (*m_onRenderGeometry)(vertices, num_vertices, indices, num_indices, texture, translation);
    }

    Rml::CompiledGeometryHandle CompileGeometry(Rml::Vertex *vertices, int num_vertices, int *indices, int num_indices,
                                                Rml::TextureHandle texture) override {
//        std::cout << "RmlUi::RenderInterface::CompileGeometry" << "\n";

        return 0;
    }

    void RenderCompiledGeometry(Rml::CompiledGeometryHandle geometry, const Rml::Vector2f &translation) override {
//        std::cout << "RmlUi::RenderInterface::RenderCompiledGeometry" << "\n";
    }

    void ReleaseCompiledGeometry(Rml::CompiledGeometryHandle geometry) override {
//        std::cout << "RmlUi::RenderInterface::ReleaseCompiledGeometry" << "\n";
    }

    void EnableScissorRegion(bool enable) override {
//        std::cout << "RmlUi::RenderInterface::EnableScissorRegion" << "\n";
    }

    void SetScissorRegion(int x, int y, int width, int height) override {
//        std::cout << "RmlUi::RenderInterface::SetScissorRegion" << "\n";
    }

    bool LoadTexture(Rml::TextureHandle &texture_handle,
                     Rml::Vector2i &texture_dimensions,
                     const Rml::String &source) override {
        return (*m_onLoadTexture)(texture_handle, texture_dimensions, source.c_str());
    }

    bool GenerateTexture(Rml::TextureHandle &texture_handle,
                         const Rml::byte *source,
                         const Rml::Vector2i &source_dimensions) override {
        return (*m_onGenerateTexture)(texture_handle, source, source_dimensions.x * source_dimensions.y * 4,
                                      source_dimensions);
    }

    void ReleaseTexture(Rml::TextureHandle texture_handle) override {
        (*m_onReleaseTexture)(texture_handle);
    }

    void SetTransform(const Rml::Matrix4f *transform) override {
        std::cout << "RmlUi::RenderInterface::SetTransform" << "\n";
    }
};

extern "C" void *rml_RenderInterface_New(::onRenderGeometry onRenderGeometry, ::onGenerateTexture onGenerateTexture,
                                         ::onLoadTexture onLoadTexture,
                                         ::onReleaseTexture onReleaseTexture) {
    return new RenderInterface(onRenderGeometry, onGenerateTexture, onLoadTexture, onReleaseTexture);
}