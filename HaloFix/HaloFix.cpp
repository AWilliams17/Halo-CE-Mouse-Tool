// HaloFix.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include <iostream>

/*
		-Halo Mouse Fix DLL-
	yay :)
	Sensitivity X Axis offset: 0x2ABB50
	Sensitivity Y Axis offset: 0x2ABB54
	Acceleration Function offset: 0x8F830
	Acceleration function offset 2: 0x8F836
	BYTE mouseaccelnop[] = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };

	NOTE: preprocessor settings edited
	Remember: 0.25F == 1 ingame sensitivity.

*/

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
