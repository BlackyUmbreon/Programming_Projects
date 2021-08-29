include irvine32.inc

.data
	foodType BYTE 'F'
	drinkType BYTE 'B'
	
.code
IDCompare PROC C , TID:DWORD , CID:DWORD , LengthString:DWORD
	mov esi , TID			;Get Address of Input ID
	mov edi , CID			;Get Address of Current ID
	mov ecx , LengthString	;Get length for looping
	mov eax , 0
	mov ebx , 0

	checking :
		mov al , [esi]
		mov bl , [edi]		
		cmp al , 0			;if \0 will skip compare, read not null only
		jz skip
		cmp al , bl
		jne Different		; Input ID != Existing ID
		skip :
			inc esi
			inc edi
			loop checking

	; Input ID == Existing ID
	Same :
		mov eax , 1D		; Set EAX to 1 and return
		ret			

	Different:
		mov eax , 0D		; Set EAX to 0 and return
		ret

IDCompare ENDP

TYPECompare PROC C, PTYPE:BYTE
	mov eax , 0
	mov al, PTYPE		;Get Product Type Character
	cmp al, foodType	; Product Type == 'F'
	je Food
	cmp al, drinkType	; Product Type == 'B'
	je Drink
	jmp Fail			; Otherwise

	Food :
		mov eax , 1D	; Set EAX to 1 and return
		ret
	Drink :
		mov eax , 2D	; Set EAX to 2 and return
		ret
	Fail :
		mov eax , -1D	; Set EAX to -1 and return
		ret
TYPECompare ENDP

PriceCompare PROC C, TPrice:DWORD, CPrice:DWORD
	mov eax , TPrice
	mov ebx , CPrice
	cmp eax, ebx
	je Same
	jne Different

	Same :
		mov eax , 1D		; Set EAX to 1 and return
		ret			

	Different:
		mov eax , 0D		; Set EAX to 0 and return
		ret
PriceCompare ENDP

CharCompare PROC C, TChar:BYTE, CChar:BYTE
	mov al , TChar
	mov bl , CChar
	cmp al, bl
	je Same
	jne Different

	Same :
		mov eax , 1D		; Set EAX to 1 and return
		ret			

	Different:
		mov eax , 0D		; Set EAX to 0 and return
		ret
CharCompare ENDP

END