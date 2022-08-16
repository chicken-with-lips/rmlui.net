#include "RmlUi/Core.h"
#include "EventListener.h"

extern "C" void rml_Initialise() {
    Rml::Initialise();
}

extern "C" void rml_Shutdown() {
    Rml::Shutdown();
}

extern "C" void rml_SetRenderInterface(Rml::RenderInterface *renderInterface) {
    Rml::SetRenderInterface(renderInterface);
}

extern "C" void rml_SetSystemInterface(Rml::SystemInterface *systemInterface) {
    Rml::SetSystemInterface(systemInterface);
}

extern "C" void rml_LoadFontFace(const char *fileName, bool fallbackFace, Rml::Style::FontWeight weight) {
    Rml::LoadFontFace(fileName, fallbackFace, weight);
}

extern "C" Rml::EventListener *rml_CreateEventListener(::onProcessEvent onProcessEvent, ::onAttachEvent onAttachEvent, ::onDetachEvent onDetachEvent) {
    return new EventListenerProxy(onProcessEvent, onAttachEvent, onDetachEvent);
}

extern "C" void rml_ReleaseEventListener(Rml::EventListener *eventListener) {
    delete eventListener;
}