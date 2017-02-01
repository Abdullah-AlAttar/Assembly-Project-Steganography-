include irvine32.inc
INCLUDE macros.inc
MAXIMUM_IMAGE_SIZE = 10000000      ;Maximum size of image 
MAXIMUM_MESSAGE_SIZE =10000 ;Maximum size of the Secret Message
.data
        imagePixels BYTE MAXIMUM_IMAGE_SIZE DUP(?)
		image_file_name byte"text_of_image.txt",0                 ;;;
 
		secretMessage BYTE MAXIMUM_MESSAGE_SIZE DUP(?)
		message_file_name byte "text_of_message.txt",0            ;;;
		textSize DWORD ?
		imageSize      DWORD ?
		fileHandle1  HANDLE ?
		fileHandle   HANDLE ?
		HiddenMessage byte MAXIMUM_MESSAGE_SIZE dup(?)
		decryptedMessage BYTE 0
		checkZero BYTE  0
		encryptvalue byte 26
.code
;---------------------------------------------------------
 Encrypt_funs proc
 
call ReadMessage                      
 
		CALL ReadPixels
 
		CALL ENCRYPT 
		CALL SaveChanges
ret
 
Encrypt_funs endp
;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
Decrypt_funs proc  byteArray:PTR BYTE
call ReadPixels
call Decrypt
 
ret
Decrypt_funs endp
ReadMessage PROC
 
		MOV EDX,offset message_file_name
	    MOV ecx,SIZEOF message_file_name
		CALL OpenInputFile
		MOV fileHandle1,EAX
		; Check for errors.
		 ;cmp EAX,INVALID_HANDLE_VALUE ; error opening file?
		 ;JNE file_ok1 ; no: skip
		 ;mWrite <"Cannot open file",0dh,0ah>
		 ;JMP quit1 ; and quit
		 ;file_ok1:
		MOV EDX,offset secretMessage
		MOV ecx,MAXIMUM_MESSAGE_SIZE
		CALL ReadFromFile
		 ;JNC check_MAXIMUM_IMAGE_SIZE ; error reading?
		 ;mWrite "Error reading file. " ; yes: show error message
		  ;CALL WriteWindowsMsg
		  ;JMP close_file1
		  ;check_MAXIMUM_IMAGE_SIZE:
		  ;MOV imageSize , EAX
		  ;cmp EAX,EDI ; imagePixels large enough?
		  ;JB buf_size_ok ; yes
		  ;mWrite <"Error: imagePixels too smALl for the file",0dh,0ah>
		  ;JMP quit1 ; and quit
		  ;buf_size_ok:
		MOV secretMessage[EAX],0 ; insert null terminator
		mov ecx , eax
 
	    mov textSize,eax    ; mov size of the message
 
		close_file1:
		MOV EAX,fileHandle1
		CALL CloseFile
		quit1:
 
	RET 
	ReadMessage ENDP
 
 
 
	ReadPixels PROC
	;recieve ebx  : offset of file name 
	;and esi : offset imagePixels name
	;and edi: size of file
	;return ecx imagePixels size
	;read the text and the matrix from file 
	;------------------------------------------------------------
		; Let user input a filename.
		;mWrite "Enter the Image path: "
		;MOV EDI , MAXIMUM_IMAGE_SIZE
 
		MOV EDX,offset image_file_name
		MOV ecx,SIZEOF image_file_name
 
		CALL OpenInputFile
		MOV fileHandle1,EAX
		; Check for errors.
	;	cmp EAX,INVALID_HANDLE_VALUE ; error opening file?
	;	JNE file_ok1 ; no: skip
	;	mWrite <"Cannot open file",0dh,0ah>
	;	JMP quit1 ; and quit
	;	file_ok1:
		; Read the file into a imagePixels.
		MOV EDX,OFFSET imagePixels
		MOV ecx,MAXIMUM_IMAGE_SIZE
		CALL ReadFromFile
	;	JNC check_MAXIMUM_IMAGE_SIZE ; error reading?
	;	mWrite "Error reading file. " ; yes: show error message
	;	CALL WriteWindowsMsg
	;	JMP close_file1
	;	check_MAXIMUM_IMAGE_SIZE:
		MOV imageSize , EAX
	;	cmp EAX,MAXIMUM_IMAGE_SIZE ; imagePixels large enough?
	;	JB buf_size_ok ; yes
	;	mWrite <"Error: imagePixels too smALl for the file",0dh,0ah>
	;	JMP quit1 ; and quit
	;	buf_size_ok:
		MOV imagePixels[EAX],0 ; insert null terminator
		mov ecx , eax
 
		close_file1:
		MOV EAX,fileHandle1
		CALL CloseFile
		quit1:
 
	RET 
	ReadPixels ENDP
 
		ENCRYPT PROC
		; 
		; encrypts the message given by the user using LSB method 
		;-----------------------------------------------
 
		MOV ECX , textSize
		MOV EDX , OFFSET secretMessage    ; text 
		MOV ESI , OFFSET imagePixels			; image
 
					L1:             ; the first loop gets the width of the image 
 
						cmp byte ptr [ESI], ','
						JE L1_break
						INC ESI
						jmp L1
					L1_break:
					INC ESI
 
 
					L2:   ; the second loop gets the height of the image 
 
						CMP byte ptr [ESI], ','
						JE L2_break
						INC ESI
						JMP L2
					L2_break:
					INC ESI
 
			; now we need three loops to get every pixel and change it's LSB 
			LOOP1:    ; loop with the size of text
				push ecx
				MOV AL , [EDX]
				xor al , encryptvalue
				mov ecx,8
				LOOP2:       ; loop to encrypt 1 character
 
					LOOP3:	 ; loop to find the termination character ,
					cmp byte ptr [ESI], ','
					JE LOOP3_break
					;MOV bl , [ESI]
					INC ESI
					jmp LOOP3
					LOOP3_break:
 
				dec esi
				SHL AL , 1
				JNC NOTCARRY
				or byte ptr[esi],00000001b
				jmp skip
				NOTCARRY:
 
				and byte ptr[esi],11111114 0b
				skip:
				ADD ESI,2
				loop LOOP2
 
					LOOP4: ; skip the 9th number in the 3th pixel
					cmp byte ptr [ESI], ','
					JE LOOP4_break
					INC ESI
 
					jmp LOOP4
					LOOP4_break:
					INC ESI
					INC EDX
					POP ECX
			LOOP LOOP1
 
 
					mov ecx , 8
					L3:      ; make the last 8 pixels 0
					cmp byte ptr [ESI], ','
					JE L3_break
					INC ESI
					jmp L3
					L3_break:
					dec esi
					and byte ptr[esi],11111110b
					ADD ESI,2
 
					loop L3
		RET
		ENCRYPT ENDP
	;---------------------------------------------------------
SaveChanges PROC
 
	;; Create a new text file.
		MOV EDX,offset image_file_name
;
		INVOKE CreateFile,
        edx, GENERIC_WRITE, FILE_SHARE_READ , NULL,              ;;; try the write
        CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, 0
		MOV fileHandle,EAX
		; Check for errors.
		;cmp EAX, INVALID_HANDLE_VALUE ; error found?
		;JNE file_ok ; no: skip
		;MOV EDX,OFFSET str1 ; display error
		;CALL WriteString
		;mWrite "Cannot create file"
		;call crlf
		;JMP quit
		;file_ok:
		; Ask the user to input a string.
		;MOV EDX,OFFSET str3 ; "Enter up to ...."
		;CALL WriteString
		;MOV ecx,MAXIMUM_IMAGE_SIZE ; Input a string
		;MOV EDX,OFFSET imagePixels
 
		;	CALL ReadString                                
	;	MOV stringLength,EAX ; counts chars entered
		; Write the imagePixels to the output file.
		MOV EAX,fileHandle
		MOV EDX,OFFSET imagePixels
		MOV ecx,imageSize
		CALL WriteToFile
		;MOV BYTEsWritten,EAX ; save RETurn vALue
	  invoke CloseHandle , fileHandle
 
		CALL CloseFile
		; Display the RETurn vALue.
		;MOV EDX,OFFSET str2 ; "BYTEs written"
		;CALL WriteString
		;MOV EAX,BYTEsWritten
		;CALL WriteDec
		;CALL Crlf
		quit:
 
 
 
	RET
	SaveChanges ENDP
 
		Decrypt PROC  out_str : ptr byte
		;
		;-----------------------------------------------
		;MOV EDX , OFFSET secretMessage         ; message
		MOV ESI , OFFSET imagePixels			; image
	    mov edi, out_str
 
					L1:             ; the first loop gets the width of the image 
 
						cmp byte ptr [ESI], ','
						JE L1_break
						INC ESI
						jmp L1
					L1_break:
					INC ESI
 
 
					L2:   ; the second loop gets the height of the image 
 
						CMP byte ptr [ESI], ','
						JE L2_break
						INC ESI
						JMP L2
					L2_break:
					INC ESI
 
					LOOP1:    ; loop with the size of text
				push ecx
				mov ecx,8
				LOOP2:       ; loop to encrypt 1 character
 
						LOOP3:	 ; loop to find the termination character ,
						cmp byte ptr [ESI], ','
						JE LOOP3_break
						;MOV bl , [ESI]
						INC ESI
						jmp LOOP3
						LOOP3_break:
 
					dec esi
					push eax
					 SHl decryptedMessage,1
						mov al , [esi]
						and al,00000001b
						shr al ,1
						Jnc NOTCARRY
						or decryptedMessage,00000001b
						jmp skip_NOTCARRY
						NOTCARRY:
						inc checkZero
						skip_NOTCARRY:
 
 
					pop eax
					ADD ESI,2
				loop LOOP2
				CMP checkZero ,8
				JE endOfMessage
				mov checkZero ,0
				push eax
				mov eax ,0
				mov al , decryptedMessage
				xor al , encryptvalue
				mov byte ptr[edi],al
				inc edi
			  ;	call writechar
				;CALL WRITEBINB
				;CALL CRLF
				pop eax
				mov decryptedMessage,0
					LOOP4:					 ; skip the 9th number in the 3th pixel
					cmp byte ptr [ESI], ','
					JE LOOP4_break
					INC ESI
 
					jmp LOOP4
					LOOP4_break:
					INC ESI
					INC EDX
					POP ECX
			JMP LOOP1
 
			endOfMessage:
			pop ecx
			inc edi
			mov byte ptr[edi],0
		;	mov edx,offset HiddenMessage
		;	call writestring
 
        ; call crlf
 
		RET
		Decrypt ENDP
 
 
DllMain PROC hInstance:DWORD, fdwReason:DWORD, lpReserved:DWORD 
 
mov eax, 1		; Return true to caller. 
ret 				
DllMain ENDP
 
END DllMain