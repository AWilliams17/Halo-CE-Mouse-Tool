#pragma once
#include <Windows.h>

void writeMemory();
int readRegistry();
inline void nop_memory(PVOID address, int bytes);
extern float SensX;
extern float SensY;
extern DWORD Hotkey;