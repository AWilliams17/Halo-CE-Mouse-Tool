#include "stdafx.h"
#include <iostream>
#include "HaloFix.h"

#define BASE_ADDR (DWORD)GetModuleHandle(NULL)
#define MOUSE_X *(float*)(BASE_ADDR + 0x2ABB50)
#define MOUSE_Y *(float*)(BASE_ADDR + 0x2ABB54)
#define MOUSEACCELFUNC (PVOID)(BASE_ADDR + 0x8F830)
#define NOP 0x90

bool PatchAcceleration = true;
bool SoundsEnabled = true;
float SensX;
float SensY;
float IncAmt;
DWORD Hotkey;

int readRegistry() {
	char sensXSZ[255];
	char sensYSZ[255];
	char incAmtSZ[255];
	DWORD hotkeyDword;
	DWORD soundsEnabledDword;
	DWORD patchAccelerationDword;

	int result;
	DWORD buffersize = 255;
	for (int i = 0; i != 4; i++) {
		if (i == 0) {
			result = RegGetValue(HKEY_CURRENT_USER, ("SOFTWARE\\HaloMouseTool"), ("SensX"), REG_SZ, NULL, sensXSZ, &buffersize);
			SensX = atof(&sensXSZ[0]);
		}
		if (i == 1) {
			result = RegGetValue(HKEY_CURRENT_USER, ("SOFTWARE\\HaloMouseTool"), ("SensY"), REG_SZ, NULL, sensYSZ, &buffersize);
			SensY = atof(&sensYSZ[0]);
		}
		if (i == 2) {
			result = RegGetValue(HKEY_CURRENT_USER, ("SOFTWARE\\HaloMouseTool"), ("HotkeyDll"), REG_DWORD, NULL, &hotkeyDword, &buffersize);
			Hotkey = hotkeyDword;
		}
		if (i == 3) {
			result = RegGetValue(HKEY_CURRENT_USER, ("SOFTWARE\\HaloMouseTool"), ("SoundsEnabledDll"), REG_DWORD, NULL, &soundsEnabledDword, &buffersize);
			if (soundsEnabledDword == 0) {
				SoundsEnabled = false;
			}
		}
		if (i == 4) {
			result = RegGetValue(HKEY_CURRENT_USER, ("SOFTWARE\\HaloMouseTool"), ("PatchMouseAcceleration"), REG_DWORD, NULL, &patchAccelerationDword, &buffersize);
			if (patchAccelerationDword == 0) {
				PatchAcceleration = false;
			}
		}
		buffersize = 255; //Every successful call of RegGetValue sets the buffersize to something else, so reset it.

		if (result == ERROR_FILE_NOT_FOUND) {
			return 1;
		}
	}
	return 0;
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
	} else {
		Beep(250, 250);
		MessageBox(NULL, "Failed to read registry. Did you run the mouse tool first/delete the registry settings?", "Failure to read registry.", MB_OK);
	}
}

inline void nop_memory(PVOID address, int bytes) {
	DWORD old_protection;
	VirtualProtect(address, bytes, PAGE_EXECUTE_READWRITE, &old_protection);
	memset(address, NOP, bytes);
	VirtualProtect(address, bytes, old_protection, NULL);
}