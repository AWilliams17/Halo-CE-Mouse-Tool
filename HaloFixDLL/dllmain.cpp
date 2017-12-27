// dllmain.cpp : Defines the entry point for the DLL application.
#include "stdafx.h"
#include "HaloFix.h"
#include <cstdlib>
#include <windowsx.h>

bool IsForegroundProcess(DWORD pid)
{
	HWND hwnd = GetForegroundWindow();
	if (hwnd == NULL) {
		return false;
	}

	DWORD foregroundPid;
	if (GetWindowThreadProcessId(hwnd, &foregroundPid) == 0) {
		return false;
	}

	return (foregroundPid == pid);
}

DWORD CALLBACK HookFunctions (LPVOID) {
	do{
		if (GetAsyncKeyState(VK_F1)) {
			if (write_memory() == 1) {
				Beep(600, 150);
				Beep(900, 250);
			}
			else {
				Beep(900, 150);
				Beep(600, 250);
				MessageBox(NULL, "Failed to read settings from registry. Did you run the DLL settings tool in the controls folder where the DLL is?", "HaloMouseDLL: Error", MB_OK);
			}
		}
		Sleep(10);
	} while (IsForegroundProcess(GetCurrentProcessId()));
	return 0;
}

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
					 )
{
	switch (ul_reason_for_call)
	{
	case DLL_PROCESS_ATTACH:
		CreateThread(0, 0, (LPTHREAD_START_ROUTINE)HookFunctions, 0, 0, 0);
		break;
	case DLL_THREAD_ATTACH:
	case DLL_THREAD_DETACH:
	case DLL_PROCESS_DETACH:
		break;
	}
	return TRUE;
}