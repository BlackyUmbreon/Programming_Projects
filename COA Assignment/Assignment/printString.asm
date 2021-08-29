Include irvine32.inc

.code
printString PROC C , strPrint:DWORD
	mov edx , strPrint	;Get Offset/Address of String
	call WriteString	;Print String
	ret
printString ENDP

END