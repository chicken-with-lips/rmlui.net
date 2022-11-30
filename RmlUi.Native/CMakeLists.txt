cmake_minimum_required(VERSION 3.14...3.23)

project(RmlUi.Native VERSION 1.0 LANGUAGES CXX)

set(CMAKE_CXX_STANDARD 14)
set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++1y -march=native")

if (CMAKE_CONFIGURATION_TYPES)
    set(CMAKE_CONFIGURATION_TYPES Debug Release)
    set(CMAKE_CONFIGURATION_TYPES "${CMAKE_CONFIGURATION_TYPES}" CACHE STRING "Reset the configurations to what we need" FORCE)
endif ()

include(FetchContent)
find_package(freetype CONFIG REQUIRED)

FetchContent_Declare (
    rmlui
    GIT_REPOSITORY http://github.com/mikke89/RmlUi.git
    GIT_TAG master
    GIT_SHALLOW TRUE
    GIT_PROGRESS TRUE
)

FetchContent_MakeAvailable(rmlui)

add_library(${PROJECT_NAME} SHARED
    src/Context.cpp
    src/Element.cpp
    src/ElementDocument.cpp
    src/Event.cpp
    src/EventListener.h
    src/RenderInterface.cpp
    src/Rml.cpp
    src/SystemInterface.cpp
    src/Util.h
)

target_link_libraries(${PROJECT_NAME}
    freetype
    RmlCore
)

add_custom_command(TARGET ${PROJECT_NAME} POST_BUILD COMMAND ${CMAKE_COMMAND} -E copy $<TARGET_FILE:${PROJECT_NAME}> /media/jolly_samurai/Data/Projects/chicken-with-lips/duck/Build/Debug/net6.0/${PROJECT_NAME}.so)
