cmake_minimum_required(VERSION 3.14...3.23)

project(RmlUi.Native VERSION 1.0 LANGUAGES CXX)

set(CMAKE_RUNTIME_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/bin)
set(CMAKE_LIBRARY_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/lib)
set(CMAKE_ARCHIVE_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/lib)

if(WIN32)    
    set(CMAKE_EXE_LINKER_FLAGS "/SUBSYSTEM:WINDOWS /DEBUG:FASTLINK")
    set(CMAKE_VS_PLATFORM_TOOLSET_HOST_ARCHITECTURE "x64")

    if ("${CMAKE_CXX_COMPILER_ID}" STREQUAL "MSVC")
        set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} /std:c++17")

        if (USE_STATIC_MSVC_RUNTIME_LIBRARY)
		    set(CMAKE_MSVC_RUNTIME_LIBRARY "MultiThreaded$<$<CONFIG:Debug>:Debug>")
	    else()
		    set(CMAKE_MSVC_RUNTIME_LIBRARY "MultiThreaded")
	    endif()
    endif()
elseif(LINUX)
    set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++17 -I. -Wall -Werror")
endif()

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

include_directories(${PROJECT_NAME}
    PRIVATE include
)

target_link_libraries(${PROJECT_NAME}
    freetype
    RmlCore
)
