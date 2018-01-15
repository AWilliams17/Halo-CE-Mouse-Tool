// HaloCustomEditionMouseFix.cpp : Defines the exported functions for the DLL application.
//

//NOTE: WIP. code sucks. will be fixed lol.
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
float IncAmt;
DWORD Hotkey;

int readRegistry() {
	int result1;
	int result2;
	int result3;
	int result4;
	int result5;

	char sensXSZ[255];
	char sensYSZ[255];
	char incAmtSZ[255];
	DWORD hotkeyDword;
	DWORD soundsEnabledDword;
	DWORD patchAccelerationDword;
	DWORD buffersize = 255;
	/*
	Is there any real point in doing a loop for these? It seems like it's already easy to understand and follow. -shrug-
	*/
	result3 = RegGetValue(HKEY_CURRENT_USER, ("SOFTWARE\\HaloMouseTool"), ("HotkeyDll"), REG_DWORD, NULL, &hotkeyDword, &buffersize);
	buffersize = 255;

	result1 = RegGetValue(HKEY_CURRENT_USER, ("SOFTWARE\\HaloMouseTool"), ("SensX"), REG_SZ, NULL, sensXSZ, &buffersize);
	buffersize = 255;

	result2 = RegGetValue(HKEY_CURRENT_USER, ("SOFTWARE\\HaloMouseTool"), ("SensY"), REG_SZ, NULL, sensYSZ, &buffersize);
	buffersize = 255;

	result3 = RegGetValue(HKEY_CURRENT_USER, ("SOFTWARE\\HaloMouseTool"), ("HotkeyDll"), REG_DWORD, NULL, &hotkeyDword, &buffersize);
	buffersize = 255;

	result4 = RegGetValue(HKEY_CURRENT_USER, ("SOFTWARE\\HaloMouseTool"), ("SoundsEnabledDll"), REG_DWORD, NULL, &soundsEnabledDword, &buffersize);
	buffersize = 255;

	result5 = RegGetValue(HKEY_CURRENT_USER, ("SOFTWARE\\HaloMouseTool"), ("PatchMouseAcceleration"), REG_DWORD, NULL, &patchAccelerationDword, &buffersize);
	buffersize = 255;
	
	if (resultValid(result1) && resultValid(result2) && resultValid(result3) && resultValid(result4) && resultValid(result5)) {
		SensX = atof(&sensXSZ[0]);
		SensY = atof(&sensYSZ[0]);
		IncAmt = atof(&incAmtSZ[0]);
		Hotkey = hotkeyDword;
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
			nop_memory(MOUSEACCELFUNC, 12);
		}
		if (SoundsEnabled) {
			Beep(500, 150);
		}
	}
	else {
		Beep(250, 250);
		MessageBox(NULL, "Failed to read registry. Did you run the mouse tool first/delete the registry settings?", "Failure to read registry.", MB_OK);
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