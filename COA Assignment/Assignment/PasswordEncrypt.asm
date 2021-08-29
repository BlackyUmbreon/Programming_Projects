include irvine32.inc

.code
passwordEncrypted PROC C , Password:DWORD , lengthString:DWORD
	mov esi , Password		;Get Address of Input Password Character
	mov ecx , lengthString	;Get Size for looping
	mov eax , 0

	encrypt :
		mov al , [esi]
		cmp al, 0
		jz skip
		add al , 10H		;Encrypt Password by adding 10H
		mov [esi], al
		skip :
			inc esi
			loop encrypt

	ret
passwordEncrypted ENDP
END