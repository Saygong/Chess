cmake_minimum_required(VERSION 3.21)
project(Chess)

set(CMAKE_CXX_STANDARD 14)

set(Headers Table/Table.h Cell/Cell.h)
set(Sources main.cpp Table/Table.cpp Cell/Cell.cpp)

add_executable(Chess ${Sources} ${Headers})
