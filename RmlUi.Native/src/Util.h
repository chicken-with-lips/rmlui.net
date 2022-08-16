#pragma once

#include "RmlUi/Core.h"
#include "RmlUi/Debugger/Debugger.h"

class Util {
public:
    static const char *GetElementMarshalId(Rml::Element *element) {
        if (dynamic_cast<Rml::ElementDataGrid *>(element)) {
            return "ElementDataGrid";
        } else if (dynamic_cast<Rml::ElementDataGridCell *>(element)) {
            return "ElementDataGridCell";
        } else if (dynamic_cast<Rml::ElementDataGridExpandButton *>(element)) {
            return "ElementDataGridExpandButton";
        } else if (dynamic_cast<Rml::ElementDataGridRow *>(element)) {
            return "ElementDataGridRow";
        } else if (dynamic_cast<Rml::ElementDocument *>(element)) {
            return "ElementDocument";
        } else if (dynamic_cast<Rml::ElementForm *>(element)) {
            return "ElementForm";
        } else if (dynamic_cast<Rml::ElementFormControl *>(element)) {
            return "ElementFormControl";
        } else if (dynamic_cast<Rml::ElementFormControlDataSelect *>(element)) {
            return "ElementFormControlDataSelect";
        } else if (dynamic_cast<Rml::ElementFormControlInput *>(element)) {
            return "ElementFormControlInput";
        } else if (dynamic_cast<Rml::ElementFormControlSelect *>(element)) {
            return "ElementFormControlSelect";
        } else if (dynamic_cast<Rml::ElementFormControlTextArea *>(element)) {
            return "ElementFormControlTextArea";
        } else if (dynamic_cast<Rml::ElementProgress *>(element)) {
            return "ElementProgress";
        } else if (dynamic_cast<Rml::ElementTabSet *>(element)) {
            return "ElementTabSet";
        } else if (dynamic_cast<Rml::ElementText *>(element)) {
            return "ElementText";
        }

        return "Element";
    }
};