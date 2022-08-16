
#include "RmlUi/Core/Element.h"

extern "C" const char *rml_Element_GetTagName(Rml::Element *element) {
    return element->GetTagName().c_str();
}