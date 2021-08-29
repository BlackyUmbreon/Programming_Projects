include irvine32.inc

.data
priceTotal DWORD 0

.code

calculateTotalPrice PROC C , unitPrice:DWORD , Quantity:DWORD , NumberofItem:DWORD
	mov priceTotal, 0			;Initial priceTotal to 0
	mov esi, Quantity			;Move Offset/Address of Quantity Array into ESI
	mov edi, unitPrice			;Move Offset/Address of UnitPrice Array into EDI
	mov eax , 0
	mov ebx , 0
	mov ecx , NumberofItem	    ;Get Number of Array for looping
	mov edx , 0
	addPrice : 
		mov eax , [esi]			;get Quantity value from addressing
		mov ebx , [edi]			;get unitPrice value from addressing
		mul ebx
		mov edx, priceTotal
		add edx, eax
		mov priceTotal, edx
		add esi, TYPE unitPrice	;Plus 4H (DWORD Type) into ESI
		add edi, TYPE Quantity  ;Plus 4H (DWORD Type) into EDI
		loop addPrice
	mov eax, priceTotal			;Move priceTotal for Return
	ret
calculateTotalPrice ENDP

calculateByPercentage PROC C, total:DWORD, Percentage:DWORD
	mov eax, total
	mov ebx, Percentage
	mul ebx						; Result = total * ( Percentage / 100 )
	mov ebx , 100D
	div ebx
	ret
calculateByPercentage ENDP

amountPaidCompare PROC C, amountPaid:DWORD , GrandTotal:DWORD
	mov eax , amountPaid
	mov ebx , GrandTotal
	cmp eax, ebx
	jae validPaid				; AmountPaid(EAX) >= GrandTotal(EBX)
	jb invalidPaid				; AmountPaid(EAX) < GrandTotal(EBX)

	validPaid :
		sub eax,ebx
		ret
	invalidPaid :
		mov eax, -1D
		ret
amountPaidCompare ENDP

addAmount PROC C, InputValue:DWORD, CurrentValue: DWORD
	mov eax , CurrentValue
	add eax , InputValue		; Update Value = Current Value + Add Value
	ret
addAmount ENDP

END