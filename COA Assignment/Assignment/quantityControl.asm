Include irvine32.inc

.data
stockError BYTE "Out of Stock Exception.",0

.code
stockIn PROC C , Input:DWORD , Stock:DWORD
	mov eax , Stock
	add eax , Input		; Updated Quantity = Current Quantity + Add Quantity
	ret
stockIn ENDP

stockOut PROC C , Input:DWORD , Stock:DWORD
	mov eax , Stock
	cmp eax , Input			; Current Quantity < Subtract Quantity
	jb outofStock
	sub eax , Input			; Updated Quantity = Current Quantity - Subtract Quantity
	ret

	outofStock:
		mov edx , OFFSET stockError
		call writeString	;Print Out of Stock
		call crlf
		call crlf
		mov eax , -1D		; Set EAX to -1 and return
		ret
stockOut ENDP

zeroStock PROC C , Stock:DWORD
	mov eax,Stock			; Get Stock Quantity
	cmp eax, 0
	ja validQuantity		; Stock Quantity > 0
	jbe invalidQuantity		; Stock Quantity <= 0
	validQuantity :
		mov eax , 1D		; Set EAX to 1 and return
		ret
	invalidQuantity :
		mov eax , -1D		; Set EAX to -1 and return
		ret
zeroStock ENDP

END