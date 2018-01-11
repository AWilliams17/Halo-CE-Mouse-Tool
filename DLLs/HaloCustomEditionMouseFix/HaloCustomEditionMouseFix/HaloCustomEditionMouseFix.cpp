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

bool PatchAcceleration = true;
bool SoundsEnabled = true;
float SensX;
float SensY;

int readRegistry() {
	int result1;
	int result2;
	int result3;
	int result4;

	char sensXSZ[255];
	char sensYSZ[255];
	DWORD soundsEnabledDword;
	DWORD patchAccelerationDword;
	DWORD buffersize = 255;

	result1 = RegGetValue(HKEY_CURRENT_USER, ("SOFTWARE\\HaloMouseTool"), ("SensX"), REG_SZ, NULL, sensXSZ, &buffersize);
	result2 = RegGetValue(HKEY_CURRENT_USER, ("SOFTWARE\\HaloMouseTool"), ("SensY"), REG_SZ, NULL, sensYSZ, &buffersize);
	result3 = RegGetValue(HKEY_CURRENT_USER, ("SOFTWARE\\HaloMouseTool"), ("SoundsEnabledDll"), REG_DWORD, NULL, (PVOID)&soundsEnabledDword, &buffersize);
	result4 = RegGetValue(HKEY_CURRENT_USER, ("SOFTWARE\\HaloMouseTool"), ("PatchMouseAcceleration"), REG_DWORD, NULL, (PVOID)&patchAccelerationDword, &buffersize);

	if (resultValid(result1) && resultValid(result2) && resultValid(result3) && resultValid(result4)) {
		SensX = atof(&sensXSZ[0]);
		SensY = atof(&sensYSZ[0]);
		if (soundsEnabledDword == 0) {
			SoundsEnabled = false;
		}
		if (patchAccelerationDword == 0) {
			PatchAcceleration = false;
		}

		return 0;
	}
	return 1;
}

void writeMemory() {
	if (readRegistry() == 0) {
		MOUSE_X = SensX * 0.25f;
		MOUSE_Y = SensY * 0.25f;
		if (PatchAcceleration == 1) {
			nop_memory(MOUSEACCELFUNC, 6);
			nop_memory(MOUSEACCELFUNC2, 6);
		}
		if (SoundsEnabled) {
			Beep(500, 150);
			Beep(700, 250);
		}
	}
	else {
		Beep(250, 250);
		MessageBox(NULL, "", "", MB_OK); //Failure message
	}
}

void nop_memory(PVOID address, int bytes) {
	DWORD old_protection;
	VirtualProtect(address, bytes, PAGE_EXECUTE_READWRITE, &old_protection);
	memset(address, NOP, bytes);
	VirtualProtect(address, bytes, old_protection, NULL);
}

bool resultValid(int result) {
	if (result == ERROR_FILE_NOT_FOUND) {
		return false;
	}
	else {
		return true;
	}
}