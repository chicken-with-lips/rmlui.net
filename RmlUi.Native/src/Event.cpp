
#include "RmlUi/Core/ElementDocument.h"
#include "Util.h"

extern "C" Rml::EventId rml_Event_GetId(Rml::Event *ev) {
    return ev->GetId();
}

extern "C" Rml::EventPhase rml_Event_GetPhase(Rml::Event *ev) {
    return ev->GetPhase();
}

extern "C" const char *rml_Event_GetCurrentElement(Rml::Event *ev, Rml::Element **element) {
    *element = ev->GetCurrentElement();

    return Util::GetElementMarshalId(ev->GetCurrentElement());
}

extern "C" const char *rml_Event_GetTargetElement(Rml::Event *ev, Rml::Element **element) {
    *element = ev->GetTargetElement();

    return Util::GetElementMarshalId(ev->GetTargetElement());
}

extern "C" void rml_Event_StopPropagation(Rml::Event *ev) {
    ev->StopPropagation();
}

extern "C" void rml_Event_StopImmediatePropagation(Rml::Event *ev) {
    ev->StopImmediatePropagation();
}

extern "C" bool rml_Event_IsInterruptible(Rml::Event *ev) {
    return ev->IsInterruptible();
}

extern "C" bool rml_Event_IsPropagating(Rml::Event *ev) {
    return ev->IsPropagating();
}

extern "C" bool rml_Event_IsImmediatePropagating(Rml::Event *ev) {
    return ev->IsImmediatePropagating();
}
