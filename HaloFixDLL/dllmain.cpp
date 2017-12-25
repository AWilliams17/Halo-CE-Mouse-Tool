// dllmain.cpp : Defines the entry point for the DLL application.
#include "stdafx.h"
#include "HaloFix.h"
#include <cstdlib>


DWORD CALLBACK HookFunctions (LPVOID) {
	while (1) {
		if (GetAsyncKeyState (VK_F1)) {
			write_memory ();

			Beep (100, 200);
		}
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
		CreateThread (0, 0, HookFunctions, 0, 0, 0);
	case DLL_THREAD_ATTACH:
	case DLL_THREAD_DETACH:
	case DLL_PROCESS_DETACH:
		break;
	}
	return TRUE;
}