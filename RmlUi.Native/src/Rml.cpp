#include "RmlNative.h"
#include "RmlUi/Core.h"
#include "EventListener.h"

RMLUI_CAPI void rml_Initialise() {
    Rml::Initialise();
}

RMLUI_CAPI void rml_Shutdown() {
    Rml::Shutdown();
}

RMLUI_CAPI void rml_SetRenderInterface(Rml::RenderInterface *renderInterface) {
    Rml::SetRenderInterface(renderInterface);
}

RMLUI_CAPI void rml_SetSystemInterface(Rml::SystemInterface *systemInterface) {
    Rml::SetSystemInterface(systemInterface);
}

RMLUI_CAPI void rml_LoadFontFace(const char *fileName, bool fallbackFace, Rml::Style::FontWeight weight) {
    Rml::LoadFontFace(fileName, fallbackFace, weight);
}

RMLUI_CAPI Rml::EventListener *rml_CreateEventListener(::onProcessEvent onProcessEvent, ::onAttachEvent onAttachEvent, ::onDetachEvent onDetachEvent) {
    return new EventListenerProxy(onProcessEvent, onAttachEvent, onDetachEvent);
}

RMLUI_CAPI void rml_ReleaseEventListener(Rml::EventListener *eventListener) {
    delete eventListener;
}

RMLUI_CAPI void rml_RemoveContext(const char *name) {
    Rml::RemoveContext(name);
}
