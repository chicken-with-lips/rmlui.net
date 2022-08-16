#include <iostream>
#include "RmlUi/Core/SystemInterface.h"

typedef double(*onGetElapsedTime)();

typedef const char *(*onTranslateString)(int *changeCount, const char *input);

typedef bool(*onLogMessage)(Rml::Log::Type type, const char *message);

class SystemInterface : Rml::SystemInterface {
private:
    ::onGetElapsedTime m_onGetElapsedTime;
    ::onTranslateString m_onTranslateString;
    ::onLogMessage m_onLogMessage;

public:
    explicit SystemInterface(::onGetElapsedTime onGetElapsedTime, ::onTranslateString onTranslateString,
                             ::onLogMessage onLogMessage) {
        m_onGetElapsedTime = onGetElapsedTime;
        m_onTranslateString = onTranslateString;
        m_onLogMessage = onLogMessage;
    }

    double GetElapsedTime() override {
        return (*m_onGetElapsedTime)();
    }

    int TranslateString(Rml::String &translated, const Rml::String &input) override {
        int changeCount;
        translated = (*m_onTranslateString)(&changeCount, input.c_str());

        return changeCount;
    }

    bool LogMessage(Rml::Log::Type type, const Rml::String &message) override {
        return (*m_onLogMessage)(type, message.c_str());
    }

    void SetMouseCursor(const Rml::String &cursor_name) override {
        std::cout << "RmlUi::SystemInterface::SetMouseCursor" << "\n";
    }

    void SetClipboardText(const Rml::String &text) override {
        std::cout << "RmlUi::SystemInterface::SetClipboardText" << "\n";
    }

    void GetClipboardText(Rml::String &text) override {
        std::cout << "RmlUi::SystemInterface::GetClipboardText" << "\n";
    }

    void ActivateKeyboard(Rml::Vector2f caret_position, float line_height) override {
        std::cout << "RmlUi::SystemInterface::ActivateKeyboard" << "\n";
    }

    void DeactivateKeyboard() override {
        std::cout << "RmlUi::SystemInterface::DeactivateKeyboard" << "\n";
    }
};

extern "C" void *rml_SystemInterface_New(::onGetElapsedTime onGetElapsedTime, ::onTranslateString onTranslateString,
                                         ::onLogMessage onLogMessage) {
    return new SystemInterface(onGetElapsedTime, onTranslateString, onLogMessage);
}