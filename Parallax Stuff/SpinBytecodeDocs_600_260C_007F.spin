'  ┌──────────────────────────────────────────────────────────────────────────┐
'  │    Spin Bytecode Document                                                │
'  └──────────────────────────────────────────────────────────────────────────┘
'  RR20080721   The following has been put together by "Cluso99" from information
'               supplied by Chip from his Spin Interpreter, Hippy and his AiChip
'               Disassembler, and others including the Propeller Forums and the
'               Wiki. I have added/updated/reformatted information as well,
'               including what I have found in writing a faster version of the
'               Spin Interpreter.
'  RR20080812   updated
'  RR20080901   updated  (for use with ClusoInterpreter v0.600)
'  RR20090401   added $3F from hippy (from ClusoInterpreter_260_007F)
'               (need to check nothing else updated in v_260_007F)
'
'  There are no warranties as to the accuracy of this document.
'
'  ┌──────────────────────────────────────────────────────────────────────────┐
'  │    Spin Bytecodes                                                        │
'  └──────────────────────────────────────────────────────────────────────────┘
'
' set     byte          description                                     extra bytes
' ----------------------------------------------------------------------------------------------
'$00-3F   00xxxxxx      special purpose ops
'$40-7F   01bxxxoo      variable op (Fast access VAR and LOC)                           +1 if assign
'$80-DF   1ssibboo      memory op   (Access MEM, OBJ, VAR and LOC)      +1..2 if base,  +1 if assign
'$E0-FF   111xxxxx      math op     (Unary and Binary operators)
'
'
'
'                               .---.---.---.---.---.---.---.---.
'$00-3F Special purpose opcodes | 0 | 0 | o   o   o   o   o   o |
'                               `---^---^---^---^---^---^---^---'

'          op set byte      description              pops push  extra bytes                  
'------------------------------------------------------------------------------------     
'        ' 00  0  000000tp  drop anchor                         (t=try, !p=push)                   
'        ' 01     000000tp  drop anchor                         (t=try, !p=push)               
'        ' 02     000000tp  drop anchor                         (t=try, !p=push)               
'        ' 03     000000tp  drop anchor                         (t=try, !p=push)               
'        ' 04  1  00000100  jmp                                 +1..2 address                  
'        ' 05     00000101  call sub                            +1 sub                         
'        ' 06     00000110  call obj.sub                        +2 obj+sub                     
' popx   ' 07     00000111  call obj[].sub              1       +2 obj+sub                     
' popx   ' 08  2  00001000  tjz                         1  0/1  +1..2 address                  
' popx   ' 09     00001001  djnz                        1  0/1  +1..2 address                  
' popx   ' 0A     00001010  jz                          1       +1..2 address                  
' popx   ' 0B     00001011  jnz                         1       +1..2 address                  
' popyx  ' 0C  3  00001100  casedone                    2       +1..2 address                  
' popx   ' 0D     00001101  value case                  1       +1..2 address                  
' popyx  ' 0E     00001110  range case                  2       +1..2 address                  
' popayx ' 0F     00001111  lookdone                    3  1                                   
' popx   ' 10  4  00010000  value lookup                1                                      
' popx   ' 11     00010001  value lookdown              1                                      
' popyx  ' 12     00010010  range lookup                2                                      
' popyx  ' 13     00010011  range lookdown              2                                      
' popx   ' 14  5  00010100  pop                         1+          ???1+                      
'        ' 15     00010101  run                                                                
' popx   ' 16     00010110  STRSIZE(string)             1  1                                   
' popyx  ' 17     00010111  STRCOMP(stringa,stringb)    2  1                                   
' popayx ' 18  6  00011000  BYTEFILL(start,value,count) 3                                      
' popayx ' 19     00011001  WORDFILL(start,value,count) 3                                      
' popayx ' 1A     00011010  LONGFILL(start,value,count) 3                                      
' popayx ' 1B     00011011  WAITPEQ(data,mask,port)     3                                      
' popayx ' 1C  7  00011100  BYTEMOVE(to,from,count)     3                                      
' popayx ' 1D     00011101  WORDMOVE(to,from,count)     3                                      
' popayx ' 1E     00011110  LONGMOVE(to,from,count)     3                                      
' popayx ' 1F     00011111  WAITPNE(data,mask,port)     3                                      
' popyx  ' 20  8  00100000  CLKSET(mode,freq)           2                                      
' popx   ' 21     00100001  COGSTOP(id)                 1                                      
' popx   ' 22     00100010  LOCKRET(id)                 1                                      
' popx   ' 23     00100011  WAITCNT(count)              1                                      
' popx   ' 24  9  001001oo  SPR[nibble] op   push       1                  +1 if assign        
' popx   ' 25     001001oo  SPR[nibble] op   pop        1                  +1 if assign        
' popx   ' 26     001001oo  SPR[nibble] op   using      1                  +1 if assign        
' popyx  ' 27     00100111  WAITVID(colors,pixels)      2                                      
' popayx ' 28  A  00101p00  COGINIT(id,adr,ptr)         3  1    (!p=push)                      
'        ' 29     00101p01  LOCKNEW                        1    (!p=push)                      
' popx   ' 2A     00101p10  LOCKSET(id)                 1  1    (!p=push)                      
' popx   ' 2B     00101p11  LOCKCLR(id)                 1  1    (!p=push)                      
' popayx ' 2C  B  00101p00  COGINIT(id,adr,ptr)         3  0    (no push)                      
'        ' 2D     00101p01  LOCKNEW                        0    (no push)                      
' popx   ' 2E     00101p10  LOCKSET(id)                 1  0    (no push)                      
' popx   ' 2F     00101p11  LOCKCLR(id)                 1  0    (no push)                      
'        ' 30  C  00110000  ABORT                                                              
' popx   ' 31     00110001  ABORT value                 1                                      
'        ' 32     00110010  RETURN                                                             
' popx   ' 33     00110011  RETURN value                1                                      
'        ' 34  D  001101cc  PUSH #-1                       1                                   
'        ' 35     001101cc  PUSH #0                        1                                   
'        ' 36     001101cc  PUSH #1                        1                                   
'        ' 37     00110111  PUSH #kp                       1    +1 maskdata  (** see below)    
'        ' 38  E  001110bb  PUSH #k1 (1 byte)              1    +1 constant                    
'        ' 39     001110bb  PUSH #k2 (2 bytes)             1    +2 constant  (#k1<<8 + #k2)                  
'        ' 3A     001110bb  PUSH #k3 (3 bytes)             1    +3 constant  (#k1<<16 + #k2<<8 + #k3)                  
'        ' 3B     001110bb  PUSH #k4 (4 bytes)             1    +4 constant  (#k1<<24 + #k2<<16 + #k3<<8 + #k4)                  
'        ' 3C  F  00111100  <unused>                                                           
' popx   ' 3D     00111101  register[bit]      op       1       +1 reg+op, +1 if assign        
' popyx  ' 3E     00111110  register[bit..bit] op       2       +1 reg+op, +1 if assign        
'        ' 3F     00111111  register           op               +1 reg+op, +1 if assign        
'
'
' ** $37  additional byte        .---.---.---.---.---.---.---.---.
'         used as a constant     | - | n | d | r   r   r   r   r |
'                                `---^---^---^---^---^---^---^---'
'                                      |   |           |
'                                      |   |           X := 2 << rrrrr ( #2 rotate left "rrrrr" bits)
'                                      |   |             then...
'                                      |   `-----------0:  nothing
'                                      |               1:  X := X - 1  (decrement)
'                                      |                 then...
'                                      `---------------0:  nothing
'                                                      1:  X := !X     (invert/not)
'from Hippy 
'3F 80+n     PUSH    spr
'3F A0+n     POP     spr
'3F C0+n     USING   spr

'
'                                .---.---.---.---.---.---.---.---.  These opcodes allow fast access by making long access
'$40-7F Fast access VAR, LOC     | 0   1 | b | v   v   v | o   o |  to the first few long entries in the variable space
'                                `---^---^---^---^---^---^---^---'  or stack a single byte opcode. The single byte opcodes
'                                          |       |         |      are effectively expanded within the interpreter...
'                                      0= VAR    Address    00= PUSH   Read  - push result in stack                                    
'                                      1= LOC  (adr = v*4)  01= POP    Write - pop value from stack                                    
'                                          |       |        10= USING  2nd opcode (assignment) executed, result in target              
'                                          |       |        11= PUSH # Push address of destination onto stack             
'                                          |       `---------|------------------------.
'                                          `-----------.     |                        |
'                                                     \|/   \|/                      \|/
'                                .---.---.---.---.---.---.---.---.  .---.---.---.---.---.---.---.---.
'               10= long? ===>   | 1 |?1?  0 | 0 | 1   b | o   o |  | 0   0   0 | v   v   v | 0   0 |
'                                `---^---^---^---^---^---^---^---'  `---^---^---^---^---^---^---^---'
'              op  description
'-----------------------------------------------------------------------------------------------------------
' varop      ' 40  VAR  PUSH    addr=0*4= 00  
' varop      ' 41  VAR  POP     addr=0*4= 00
' varop      ' 42  VAR  USING   addr=0*4= 00
' varop      ' 43  VAR  PUSH #  addr=0*4= 00
' varop      ' 44  VAR  PUSH    addr=1*4= 04
' varop      ' 45  VAR  POP     addr=1*4= 04
' varop      ' 46  VAR  USING   addr=1*4= 04
' varop      ' 47  VAR  PUSH #  addr=1*4= 04
' varop      ' 48  VAR  PUSH    addr=2*4= 08
' varop      ' 49  VAR  POP     addr=2*4= 08
' varop      ' 4A  VAR  USING   addr=2*4= 08
' varop      ' 4B  VAR  PUSH #  addr=2*4= 08
' varop      ' 4C  VAR  PUSH    addr=3*4= 0C
' varop      ' 4D  VAR  POP     addr=3*4= 0C
' varop      ' 4E  VAR  USING   addr=3*4= 0C
' varop      ' 4F  VAR  PUSH #  addr=3*4= 0C
' varop      ' 50  VAR  PUSH    addr=4*4= 10
' varop      ' 51  VAR  POP     addr=4*4= 10
' varop      ' 52  VAR  USING   addr=4*4= 10
' varop      ' 53  VAR  PUSH #  addr=4*4= 10
' varop      ' 54  VAR  PUSH    addr=5*4= 14
' varop      ' 55  VAR  POP     addr=5*4= 14
' varop      ' 56  VAR  USING   addr=5*4= 14
' varop      ' 57  VAR  PUSH #  addr=5*4= 14
' varop      ' 58  VAR  PUSH    addr=6*4= 18
' varop      ' 59  VAR  POP     addr=6*4= 18
' varop      ' 5A  VAR  USING   addr=6*4= 18
' varop      ' 5B  VAR  PUSH #  addr=6*4= 18
' varop      ' 5C  VAR  PUSH    addr=7*4= 1C
' varop      ' 5D  VAR  POP     addr=7*4= 1C
' varop      ' 5E  VAR  USING   addr=7*4= 1C
' varop      ' 5F  VAR  PUSH #  addr=7*4= 1C
       
' varop      ' 60  LOC  PUSH    addr=0*4= 00
' varop      ' 61  LOC  POP     addr=0*4= 00
' varop      ' 62  LOC  USING   addr=0*4= 00
' varop      ' 63  LOC  PUSH #  addr=0*4= 00
' varop      ' 64  LOC  PUSH    addr=1*4= 04
' varop      ' 65  LOC  POP     addr=1*4= 04
' varop      ' 66  LOC  USING   addr=1*4= 04
' varop      ' 67  LOC  PUSH #  addr=1*4= 04
' varop      ' 68  LOC  PUSH    addr=2*4= 08
' varop      ' 69  LOC  POP     addr=2*4= 08
' varop      ' 6A  LOC  USING   addr=2*4= 08
' varop      ' 6B  LOC  PUSH #  addr=2*4= 08
' varop      ' 6C  LOC  PUSH    addr=3*4= 0C
' varop      ' 6D  LOC  POP     addr=3*4= 0C
' varop      ' 6E  LOC  USING   addr=3*4= 0C
' varop      ' 6F  LOC  PUSH #  addr=3*4= 0C
' varop      ' 70  LOC  PUSH    addr=4*4= 10
' varop      ' 71  LOC  POP     addr=4*4= 10
' varop      ' 72  LOC  USING   addr=4*4= 10
' varop      ' 73  LOC  PUSH #  addr=4*4= 10
' varop      ' 74  LOC  PUSH    addr=5*4= 14
' varop      ' 75  LOC  POP     addr=5*4= 14
' varop      ' 76  LOC  USING   addr=5*4= 14
' varop      ' 77  LOC  PUSH #  addr=5*4= 14
' varop      ' 78  LOC  PUSH    addr=6*4= 18
' varop      ' 79  LOC  POP     addr=6*4= 18
' varop      ' 7A  LOC  USING   addr=6*4= 18
' varop      ' 7B  LOC  PUSH #  addr=6*4= 18
' varop      ' 7C  LOC  PUSH    addr=7*4= 1C
' varop      ' 7D  LOC  POP     addr=7*4= 1C
' varop      ' 7E  LOC  USING   addr=7*4= 1C
' varop      ' 7F  LOC  PUSH #  addr=7*4= 1C
 
'
'                                .---.---.---.---.---.---.---.---.    
'$80-DF Access MEM, OBJ,         | 1 | s   s | i | b   b | o   o |  (96 stack load / save opcodes)  
'           VAR and LOC          `---^---^---^---^---^---^---^---'
'                                        |     |     |       |
'                                    00= Byte  |     |      00= PUSH   Read  - push result in stack
'                                    01= Word  |     |      01= POP    Write - pop value from stack
'                                    10= Long  |     |      10= USING  2nd opcode (assignment) executed, result in target
'                                 (11= mathop) |     |      11= PUSH # Push address of destination onto stack
'                                              |  00= MEM  base popped from stack, if i=1 add offset
'                                              |  01= OBJ  base is object base   , if i=1 add offset
'                                              |  10= VAR  base is variable base , if i=1 add offset
'                                              |  11= LOC  base is stack base    , if i=1 add offset
'                                             0= no offset
'                                             1=[]= add offset (indexed)
'              op  size  ndx description
'-----------------------------------------------------------------------------------------------------------
' memop      ' 80  Byte      MEM  PUSH  
' memop      ' 81  Byte      MEM  POP   
' memop      ' 82  Byte      MEM  USING 
' memop      ' 83  Byte      MEM  PUSH #
' memop      ' 84  Byte      OBJ  PUSH  
' memop      ' 85  Byte      OBJ  POP   
' memop      ' 86  Byte      OBJ  USING 
' memop      ' 87  Byte      OBJ  PUSH #
' memop      ' 88  Byte      VAR  PUSH  
' memop      ' 89  Byte      VAR  POP   
' memop      ' 8A  Byte      VAR  USING 
' memop      ' 8B  Byte      VAR  PUSH #
' memop      ' 8C  Byte      LOC  PUSH  
' memop      ' 8D  Byte      LOC  POP   
' memop      ' 8E  Byte      LOC  USING 
' memop      ' 8F  Byte      LOC  PUSH #
' memop      ' 90  Byte  []  MEM  PUSH  
' memop      ' 91  Byte  []  MEM  POP   
' memop      ' 92  Byte  []  MEM  USING 
' memop      ' 93  Byte  []  MEM  PUSH #
' memop      ' 94  Byte  []  OBJ  PUSH  
' memop      ' 95  Byte  []  OBJ  POP   
' memop      ' 96  Byte  []  OBJ  USING 
' memop      ' 97  Byte  []  OBJ  PUSH #
' memop      ' 98  Byte  []  VAR  PUSH  
' memop      ' 99  Byte  []  VAR  POP   
' memop      ' 9A  Byte  []  VAR  USING 
' memop      ' 9B  Byte  []  VAR  PUSH #
' memop      ' 9C  Byte  []  LOC  PUSH  
' memop      ' 9D  Byte  []  LOC  POP   
' memop      ' 9E  Byte  []  LOC  USING 
' memop      ' 9F  Byte  []  LOC  PUSH #

' memop      ' A0  Word      MEM  PUSH   
' memop      ' A1  Word      MEM  POP    
' memop      ' A2  Word      MEM  USING  
' memop      ' A3  Word      MEM  PUSH # 
' memop      ' A4  Word      OBJ  PUSH   
' memop      ' A5  Word      OBJ  POP    
' memop      ' A6  Word      OBJ  USING  
' memop      ' A7  Word      OBJ  PUSH # 
' memop      ' A8  Word      VAR  PUSH   
' memop      ' A9  Word      VAR  POP    
' memop      ' AA  Word      VAR  USING  
' memop      ' AB  Word      VAR  PUSH # 
' memop      ' AC  Word      LOC  PUSH   
' memop      ' AD  Word      LOC  POP    
' memop      ' AE  Word      LOC  USING  
' memop      ' AF  Word      LOC  PUSH # 
' memop      ' B0  Word  []  MEM  PUSH   
' memop      ' B1  Word  []  MEM  POP    
' memop      ' B2  Word  []  MEM  USING  
' memop      ' B3  Word  []  MEM  PUSH # 
' memop      ' B4  Word  []  OBJ  PUSH   
' memop      ' B5  Word  []  OBJ  POP    
' memop      ' B6  Word  []  OBJ  USING  
' memop      ' B7  Word  []  OBJ  PUSH # 
' memop      ' B8  Word  []  VAR  PUSH   
' memop      ' B9  Word  []  VAR  POP    
' memop      ' BA  Word  []  VAR  USING  
' memop      ' BB  Word  []  VAR  PUSH # 
' memop      ' BC  Word  []  LOC  PUSH   
' memop      ' BD  Word  []  LOC  POP    
' memop      ' BE  Word  []  LOC  USING  
' memop      ' BF  Word  []  LOC  PUSH # 

' memop      ' C0  Long      MEM  PUSH   
' memop      ' C1  Long      MEM  POP    
' memop      ' C2  Long      MEM  USING  
' memop      ' C3  Long      MEM  PUSH # 
' memop      ' C4  Long      OBJ  PUSH    
' memop      ' C5  Long      OBJ  POP     
' memop      ' C6  Long      OBJ  USING   
' memop      ' C7  Long      OBJ  PUSH #  
' memop      ' C8  Long      VAR  PUSH    \ see also $40-7F bytecodes 
' memop      ' C9  Long      VAR  POP     |
' memop      ' CA  Long      VAR  USING   |
' memop      ' CB  Long      VAR  PUSH #  |
' memop      ' CC  Long      LOC  PUSH    |
' memop      ' CD  Long      LOC  POP     |
' memop      ' CE  Long      LOC  USING   |
' memop      ' CF  Long      LOC  PUSH #  /
' memop      ' D0  Long  []  MEM  PUSH    
' memop      ' D1  Long  []  MEM  POP    
' memop      ' D2  Long  []  MEM  USING  
' memop      ' D3  Long  []  MEM  PUSH # 
' memop      ' D4  Long  []  OBJ  PUSH   
' memop      ' D5  Long  []  OBJ  POP    
' memop      ' D6  Long  []  OBJ  USING  
' memop      ' D7  Long  []  OBJ  PUSH # 
' memop      ' D8  Long  []  VAR  PUSH   
' memop      ' D9  Long  []  VAR  POP    
' memop      ' DA  Long  []  VAR  USING  
' memop      ' DB  Long  []  VAR  PUSH # 
' memop      ' DC  Long  []  LOC  PUSH   
' memop      ' DD  Long  []  LOC  POP    
' memop      ' DE  Long  []  LOC  USING  
' memop      ' DF  Long  []  LOC  PUSH # 

'
'                               .---.---.---.---.---.---.---.---.
'$E0-FF Math operation          | 1   1   1 | o   o   o   o   o |   (32 maths opcodes)
'                               `---^---^---^---^---^---^---^---'
'
'                               .---.---.---.---.---.---.---.---.
' Math Assignment (USING)       | p   1   s | o   o   o   o   o |   (32 maths opcodes) "op2"
'  operation                    `---^---^---^---^---^---^---^---'
'                                 |       |
'                                 |  (!s) 0 = swap binary args 
'                                 |       1 = no swap 
'                            (!p) 0 = push 
'                                 1 = no push
'     unary/                                              unary/                                                                  
'     binary  instr  instr  code                          binary normal assign description                                        
'-------------------------------------------------------------------------------------------------                                  
'     bin     ROR   '$041  E0 00000  ROR      1st -> 2nd  b       ->     ->=  rotate right                           
'     bin     ROL   '$049  E1 00001  ROL      1st <- 2nd  b       <-     <-=  rotate left                            
'     bin     SHR   '$051  E2 00010  SHR      1st >> 2nd  b       >>     >>=  shift right                            
'     bin     SHL   '$059  E3 00011  SHL      1st << 2nd  b       <<     <<=  shift left                             
'     bin     MINS  '$081  E4 00100  MINs     1st #> 2nd  b       #>     #>=  limit minimum (signed)                 
'     bin     MAXS  '$089  E5 00101  MAXs     1st <# 2nd  b       <#     <#=  limit maximum (signed)                 
'     un      NEG   '$149  E6 00110  NEG      - 1st       unary   -      -    negate                                 
'     un            '      E7 00111  BIT_NOT  ! 1st       unary   !      !    bitwise not                            
'     bin     AND   '$0C1  E8 01000  BIT_AND  1st & 2nd   b       &      &=   bitwise and                            
'     un      ABS   '$151  E9 01001  ABS      ABS( 1st )  unary   ||     ||   absolute                               
'     bin     OR    '$0D1  EA 01010  BIT_OR   1st | 2nd   b       |      |=   bitwise or                             
'     bin     XOR   '$0D9  EB 01011  BIT_XOR  1st ^ 2nd   b       ^      ^=   bitwise xor                            
'     bin     ADD   '$101  EC 01100  ADD      1st + 2nd   b       +      +=   add                                    
'     bin     SUB   '$109  ED 01101  SUB      1st - 2nd   b       -      -=   subtract                               
'     bin     SAR   '$071  EE 01110  SAR      1st ~> 2nd  b       ~>     ~>=  shift arithmetic right                 
'     bin           '      EF 01111  BIT_REV  1st >< 2nd  b       ><     ><=  reverse bits (neg y first)             
'     bin     AND   '$0C1  F0 10000  LOG_AND  1st AND 2nd b       AND         boolean and                            
'     un            '      F1 10001  ENCODE   >| 1st      unary   >|     >|   encode (0-32)                          
'     bin     OR    '$0D1  F2 10010  LOG_OR   1st OR 2nd  b       OR          boolean or                             
'     un            '      F3 10011  DECODE   |< 1st      unary   |<     |<   decode                                 
'     bin           '      F4 10100  MPY      1st * 2nd   b       *      *=   multiply, return lower half (signed)   
'     bin           '      F5 10101  MPY_MSW  1st ** 2nd  b       **     **=  multiply, return upper half (signed)   
'     bin           '      F6 10110  DIV      1st / 2nd   b       /      /=   divide, return quotient (signed)       
'     bin           '      F7 10111  MOD      1st // 2nd  b       //     //=  divide, return remainder (signed)      
'     un            '      F8 11000  SQRT     ^^ 1st      unary   ^^     ^^   square root                            
'     bin           '      F9 11001  LT       1st < 2nd   b       <           test below (signed)                    
'     bin           '      FA 11010  GT       1st > 2nd   b       >           test above (signed)                    
'     bin           '      FB 11011  NE       1st <> 2nd  b       <>          test not equal                         
'     bin           '      FC 11100  EQ       1st == 2nd  b       ==          test equal                             
'     bin           '      FD 11101  LE       1st =< 2nd  b       =<          test below or equal (signed)           
'     bin           '      FE 11110  GE       1st => 2nd  b       =>          test above or equal (signed)           
'     un            '      FF 11111  LOG_NOT  NOT 1st     unary   NOT    NOT  boolean not                            

'
' Assignment Operators (p=push, ss=size: 00=bit, 01=byte, 10=word, 11=long)
'
' This is an additional bytecode and follows a USING bytecode.
'
'       p000000-                write
'       -0000s1-                repeat-var loop (s = pop step) +1..2 address
'       p00010--        ?var    random forward (long)
'       p00011--        var?    random reverse (long)
'       p00100--        ~var    sign-extend byte
'       p00101--        ~~var   sign-extend word
'       p00110--        var~    post-clear
'       p00111--        var~~   post-set
'       p0100ss-        ++var   pre-inc (mask by size)
'       p0101ss-        var++   post-inc (mask by size)
'       p0110ss-        --var   pre-dec (mask by size)
'       p0111ss-        var--   post-dec (mask by size)
'       p1sxxxxx                math operator (!s = swap binary args)
'
'
' Address bytecodes (sign or zero extended to a long address)
'
' These (1 or 2) bytecodes are used to form a long address for the CASE, CASER and memory operations.
'
'                                  0 = 1 byte only
'                                  1 = 2 bytes -------------------> if the optional second byte is used then
'                                  |                                  the first byte will be shifted left by 8 bits.
'                                .---.---.---.---.---.---.---.---.  .---.---.---.---.---.---.---.---.
'                                | x | s | a   a   a   a   a   a |  | a   a   a   a   a   a   a   a |
'                                `---^---^---^---^---^---^---^---'  `---^---^---^---^---^---^---^---'
'                                 /|\  |
'                                  |   0 = higher order bits will be zero
'                                  |   1 = if sign-extend then 1's will be propagated to the left,
'                                  |         otherwise 0's will be propagated to the left
'                                  |                   |
'                                  `-------------------'
'
'
' reg   oo      xxxxx   (extra byte)
'       -------------
'   00| read    reg
'   01| write
'   10| assign
'
' op    tt              oo
'       -----------------------
'   00| memory          read
'   01| register        write
'   10| (register)      assign
'   11| register[]      address
'
'
' initial parameters
'
'       par     word
'       -----------------
'       +2      pbase
'       +4      vbase
'       +6      dbase
'       +8      pcurr
'       +A      dcurr
'
'
        �