// dllmain.cpp : Defines the entry point for the DLL application.
#include "stdafx.h"
#include "HaloFix.h"
#include <cstdlib>
#include <windowsx.h>

bool IsForegroundProcess(DWORD pid)
{
	HWND hwnd = GetForegroundWindow();
	DWORD foregroundPid;

	GetWindowThreadProcessId(hwnd, &foregroundPid);

	return (foregroundPid == pid);
}

DWORD CALLBACK HookFunctions(LPVOID) {
	while (IsForegroundProcess(GetCurrentProcessId())) {
		if (GetAsyncKeyState(Hotkey)) {
			writeMemory();
		}
		Sleep(100);
	}
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
		readRegistry(); //to set hotkey
		CreateThread(0, 0, (LPTHREAD_START_ROUTINE)HookFunctions, 0, 0, 0);
	case DLL_THREAD_ATTACH:
	case DLL_THREAD_DETACH:
	case DLL_PROCESS_DETACH:
		break;
	}
	return TRUE;
}

