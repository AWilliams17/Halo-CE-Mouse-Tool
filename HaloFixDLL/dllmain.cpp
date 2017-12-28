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
			write_memory();
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