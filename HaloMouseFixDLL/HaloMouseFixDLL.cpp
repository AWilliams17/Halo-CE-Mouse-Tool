// HaloMouseFixDLL.cpp : Defines the exported functions for the DLL application.
//


//Remember: 0.25F == 1 ingame sensitivity.
#include "HaloMouseFixDLL.h"

#define BASE_ADDR (DWORD)GetModuleHandle(NULL)
#define MOUSE_X *(float*)(BASE_ADDR + 0x2ABB50)
#define MOUSE_Y *(float*)(BASE_ADDR + 0x2ABB54)
#define MOUSEACCELFUNC (PVOID)(BASE_ADDR + 0x8F830)
#define MOUSEACCELFUNC2 (PVOID)(BASE_ADDR + 0x8F836)
#define NOP 0x90

void write_memory () {
	MOUSE_X = 2.25F;
	MOUSE_Y = 2.25F;
	memset (MOUSEACCELFUNC, NOP, 6);
	memset (MOUSEACCELFUNC2, NOP, 6);
}