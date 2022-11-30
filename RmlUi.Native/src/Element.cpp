
#include "RmlUi/Core/Element.h"
#include "Util.h"

extern "C" const char *rml_Element_GetTagName(Rml::Element *element) {
    return element->GetTagName().c_str();
}

extern "C" void
rml_Element_AddEventListener(Rml::Element *element, const char *event, Rml::EventListener *eventListener,
                             bool inCapturePhase) {
    element->AddEventListener(event, eventListener, inCapturePhase);
}

extern "C" void
rml_Element_RemoveEventListener(Rml::Element *element, const char *event, Rml::EventListener *eventListener,
                                bool inCapturePhase) {
    element->RemoveEventListener(event, eventListener, inCapturePhase);
}

extern "C" const char *rml_Element_GetElementByID(Rml::Element *element, const char *id, Rml::Element **foundElement) {
    *foundElement = element->GetElementById(id);

    if (*foundElement) {
        return Util::GetElementMarshalId(*foundElement);
    }

    return nullptr;
}

extern "C" const char *rml_Element_GetOwnerDocument(Rml::Element *element, Rml::Element **foundElement) {
    *foundElement = element->GetOwnerDocument();

    return Util::GetElementMarshalId(*foundElement);
}

extern "C" void rml_Element_SetInnerRml(Rml::Element *element, const char* rml) {
    element->SetInnerRML(rml);
}

extern "C" void rml_Element_Focus(Rml::Element *element) {
    element->Focus();
}

extern "C" void rml_Element_Blur(Rml::Element *element) {
    element->Blur();
}

extern "C" void rml_Element_Click(Rml::Element *element) {
    element->Click();
}
