include irvine32.inc

.code
StringInput PROC C, id:DWORD , buffer_size:DWORD
	mov  edx, id			;Get OFFSET of String
    mov  ecx,buffer_size	;Get Size of String
	call ReadString			;scanf("%[^\n]",&String) , exit Method when newLine is entered
	ret
StringInput ENDP

IntInput PROC C
	read:	
		call ReadInt		;Get Int Value and return into EAX , OF = 1 if bad input and OF = 0 if good input
	    jno  goodInput		;If Not Overflow Flag , OF == 0
		mov eax, -1D		;If Overflow Flag , set to -1D
		ret					;Return EAX (-1D)		
	goodInput:
		ret					;Direct Return EAX (Read as Int Value)
IntInput ENDP

CharInput PROC C
	mov eax, 0
	call ReadChar			;Get Char Value (BYTE) , exit Method when any button on keyboard is enter
	ret						;Return ASCII Value
CharInput ENDP

END