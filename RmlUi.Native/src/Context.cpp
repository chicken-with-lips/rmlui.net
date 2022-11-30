#include "RmlUi/Core.h"
#include "EventListener.h"

extern "C" void *rml_Context_New(const char *name, Rml::Vector2i dimensions, Rml::RenderInterface *renderInterface) {
    return Rml::CreateContext(name, dimensions, renderInterface);
}

extern "C" void rml_Context_Update(Rml::Context *context) {
    context->Update();
}

extern "C" void rml_Context_Render(Rml::Context *context) {
    context->Render();
}

extern "C" void *rml_Context_LoadDocument(Rml::Context *context, const char *documentPath) {
    return context->LoadDocument(documentPath);
}

extern "C" void *
rml_Context_LoadDocumentFromMemory(Rml::Context *context, const char *documentRml, const char *sourceUrl) {
    return context->LoadDocumentFromMemory(documentRml, sourceUrl);
}

extern "C" bool rml_Context_IsMouseInteracting(Rml::Context *context) {
    return context->IsMouseInteracting();
}

extern "C" bool rml_Context_ProcessMouseLeave(Rml::Context *context) {
    return context->ProcessMouseLeave();
}

extern "C" bool rml_Context_ProcessMouseMove(Rml::Context *context, int x, int y, int keyModifierState) {
    return context->ProcessMouseMove(x, y, keyModifierState);
}

extern "C" bool rml_Context_ProcessMouseButtonDown(Rml::Context *context, int button_index, int keyModifierState) {
    return context->ProcessMouseButtonDown(button_index, keyModifierState);
}

extern "C" bool rml_Context_ProcessMouseButtonUp(Rml::Context *context, int button_index, int keyModifierState) {
    return context->ProcessMouseButtonUp(button_index, keyModifierState);
}

extern "C" void
rml_Context_AddEventListener(Rml::Context *context, const char *event, Rml::EventListener *eventListener,
                             bool inCapturePhase) {
    context->AddEventListener(event, eventListener, inCapturePhase);
}

extern "C" void
rml_Context_RemoveEventListener(Rml::Context *context, const char *event, Rml::EventListener *eventListener,
                                bool inCapturePhase) {
    context->RemoveEventListener(event, eventListener, inCapturePhase);
}

extern "C" const char*
rml_Context_GetName(Rml::Context *context) {
    return context->GetName().c_str();
}