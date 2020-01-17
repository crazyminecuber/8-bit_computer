#include <stdint.h>
#include "Arduino.h"

// Address pins
#define addr1 2
#define addr2 3
#define addr3 4
#define addr4 5
#define addr5 6
#define addr6 7
#define addr7 8
#define addr8 9

// Programming control pinns
#define datatoggle 10 // On: writes the data byte
#define WE 11 // Only writes when this pulses low
#define addrSwitch 12 // On: Switch from computers own to arduinos address pins

// clock and shiftpin for data and instruction.
#define  clock A1
#define shiftPin A0

// Existing instructions
#define NOP  0
#define LDA  1
#define LDB  2
#define LDG  3

#define STA  4
#define STB  5
#define STG  6

#define ADD  7
#define SUB  8

#define JMP  9
#define JPZ  10
#define JPC  11
#define PRG  12

extern uint8_t nr;

void sendByte(uint8_t instruction, uint8_t data, uint8_t address=nr);
void setPins();