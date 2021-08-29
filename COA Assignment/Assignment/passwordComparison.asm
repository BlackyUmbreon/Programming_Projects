include irvine32.inc

.code
passwordCompare PROC C , TPassword:DWORD , CPassword:DWORD, LengthString:DWORD
	mov esi , TPassword		;Get Address of Input Password String
	mov edi , CPassword     ;Get Address of Current Password String
	mov ecx , LengthString	;Get length for looping
	mov eax , 0
	mov ebx , 0

	checking :
		mov al , [esi]      ;Get Character from Input Password String
		mov bl , [edi]      ;Get Character from Current Password String		
		cmp al , 0			;if \0 will skip compare, read not null only
		jz skip
		add al , 10H		;Encrypt Password by adding 10H
		cmp al , bl
		jne Different		; Input Password != Existing Password
		skip :
			inc esi
			inc edi
			loop checking

	; Input Password == Existing Password
	Same :
		mov eax , 1D		; Set EAX to 1 and return
		ret			

	Different:
		mov eax , 0D		; Set EAX to 0 and return
		ret
passwordCompare ENDP
END