#pragma once
#include <Windows.h>

void writeMemory();
int readRegistry();
void nop_memory(PVOID address, int bytes);
bool resultValid(int result);
extern DWORD Hotkey;