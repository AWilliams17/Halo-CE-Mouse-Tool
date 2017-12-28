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
int DLLSoundsi;

int Read_Registry() {
	char SensX[255];
	char SensY[255];
	char MouseAcceleration[255];
	char DLLSounds[255];
	int BufferSize = 255;
	int result1;
	int result2;
	int result3;
	int result4;

	result1 = RegGetValue(HKEY_CURRENT_USER, ("SOFTWARE\\HaloFixDLL"), ("SensX"), REG_SZ, NULL, (PVOID)&SensX, (LPDWORD)&BufferSize);
	result2 = RegGetValue(HKEY_CURRENT_USER, ("SOFTWARE\\HaloFixDLL"), ("SensY"), REG_SZ, NULL, (PVOID)&SensY, (LPDWORD)&BufferSize);
	result3 = RegGetValue(HKEY_CURRENT_USER, ("SOFTWARE\\HaloFixDLL"), ("MouseAcceleration"), REG_SZ, NULL, (PVOID)&MouseAcceleration, (LPDWORD)&BufferSize);
	result4 = RegGetValue(HKEY_CURRENT_USER, ("SOFTWARE\\HaloFixDLL"), ("DLLSounds"), REG_SZ, NULL, (PVOID)&DLLSounds, (LPDWORD)&BufferSize);
	/*
		For some reason, even when the registry values are valid REG_SZs, I get error code 1160 causing it to fail, even when 
		the values retrieved are perfectly usable. I guess I only care if the key exists or not, so I'll just specifically
		check for that.

		The only way something else would be returned is if the user went into the registry themselves and messed with all the
		values the tool used. Soooo whatever?
	*/
	if (result1 == ERROR_FILE_NOT_FOUND || result2 == ERROR_FILE_NOT_FOUND || result3 == ERROR_FILE_NOT_FOUND || result4 == ERROR_FILE_NOT_FOUND) {
		return 0;
	}
	else {
		SensXF = atof(SensX);
		SensYF = atof(SensY);
		MouseAccelerationi = atoi(MouseAcceleration);
		DLLSoundsi = atoi(DLLSounds);
		return 1;
	}
}

void write_memory () {
	int RegistryValid = Read_Registry();

	if (RegistryValid == 1) {
		MOUSE_X = SensXF;
		MOUSE_Y = SensYF;
		if (MouseAccelerationi != 1) {
			nop_memory(MOUSEACCELFUNC, 6);
			nop_memory(MOUSEACCELFUNC2, 6);
		}
		
		if (DLLSoundsi == 1) {
			Beep(600, 150);
			Beep(900, 250);
		}
	}
	else {
		Beep(900, 150);
		Beep(600, 250);
		MessageBox(NULL, "Failed to read settings from registry. Did you run the DLL settings tool in the controls folder where the DLL is?", "HaloMouseDLL: Error", MB_OK);
	}
}

void nop_memory (PVOID address, int bytes) {
	DWORD old_protection;
	VirtualProtect (address, bytes, PAGE_EXECUTE_READWRITE, &old_protection);
	memset (address, NOP, bytes);
	VirtualProtect (address, bytes, old_protection, NULL);
}

