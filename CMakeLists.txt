cmake_minimum_required(VERSION 3.21)
project(Chess)

set(CMAKE_CXX_STANDARD 14)

set(Headers src/main/Board/Board.h src/main/Board/ChessBoard/ChessBoard.h)
set(Sources src/main.cpp src/main/Board/Board.cpp src/main/Board/ChessBoard/ChessBoard.cpp)

add_executable(Chess ${Sources} ${Headers})
