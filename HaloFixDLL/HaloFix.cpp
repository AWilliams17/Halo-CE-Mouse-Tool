// HaloFix.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include <iostream>
#include "HaloFix.h"

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

float SensXF;
float SensYF;
int MouseAccelerationi;

int Read_Registry() {
	char SensX[255];
	char SensY[255];
	char MouseAcceleration[255];
	int BufferSize = 255;
	int result1;
	int result2;
	int result3;

	result1 = RegGetValue(HKEY_CURRENT_USER, ("SOFTWARE\\HaloFixDLL"), ("SensX"), REG_SZ, NULL, (PVOID)&SensX, (LPDWORD)&BufferSize);
	result2 = RegGetValue(HKEY_CURRENT_USER, ("SOFTWARE\\HaloFixDLL"), ("SensY"), REG_SZ, NULL, (PVOID)&SensY, (LPDWORD)&BufferSize);
	result3 = RegGetValue(HKEY_CURRENT_USER, ("SOFTWARE\\HaloFixDLL"), ("MouseAcceleration"), REG_SZ, NULL, (PVOID)&MouseAcceleration, (LPDWORD)&BufferSize);

	if (result1 == ERROR_FILE_NOT_FOUND || result2 == ERROR_FILE_NOT_FOUND || result3 == ERROR_FILE_NOT_FOUND) {
		return 0;
	}
	else {
		SensXF = atof(SensX);
		SensYF = atof(SensY);
		MouseAccelerationi = atoi(MouseAcceleration);
		return 1;
	}
}

int write_memory () {
	int RegistryValid = Read_Registry();

	if (RegistryValid == 1) {
		MOUSE_X = SensXF;
		MOUSE_Y = SensYF;
		if (MouseAccelerationi != 1) {
			nop_memory(MOUSEACCELFUNC, 6);
			nop_memory(MOUSEACCELFUNC2, 6);
		}
		return 1;
	}
	else {
		return 0;
	}
}

void nop_memory (PVOID address, int bytes) {
	DWORD old_protection;
	VirtualProtect (address, bytes, PAGE_EXECUTE_READWRITE, &old_protection);
	memset (address, NOP, bytes);
	VirtualProtect (address, bytes, old_protection, NULL);
}

