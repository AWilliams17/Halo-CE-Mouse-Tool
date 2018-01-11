#pragma once
#include <Windows.h>

void writeMemory();
void nop_memory(PVOID address, int bytes);
bool resultValid(int result);