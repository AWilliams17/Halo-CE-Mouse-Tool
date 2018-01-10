// HaloCustomEditionMouseFix.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include <iostream>
#include "HaloFix.h"

#define BASE_ADDR (DWORD)GetModuleHandle(NULL)
#define MOUSE_X *(float*)(BASE_ADDR + 0x2ABB50)
#define MOUSE_Y *(float*)(BASE_ADDR + 0x2ABB54)
#define MOUSEACCELFUNC (PVOID)(BASE_ADDR + 0x8F830)
#define MOUSEACCELFUNC2 (PVOID)(BASE_ADDR + 0x8F836)
#define NOP 0x90

int readRegistry() {

}

void writeMemory() {

}

void nop_memory(PVOID address, int bytes) {
	DWORD old_protection;
	VirtualProtect(address, bytes, PAGE_EXECUTE_READWRITE, &old_protection);
	memset(address, NOP, bytes);
	VirtualProtect(address, bytes, old_protection, NULL);
}
