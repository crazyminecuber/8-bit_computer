#include "8-bit_programmer.h"

uint8_t nr = 0;

// Writes next instruction and data. Keeps track of how many instructions has been added and writes to the correct address.
void sendByte(uint8_t instruction, uint8_t data, uint8_t address){

    // Puts pins in non writing, instruction, ready - mode
    digitalWrite(WE, HIGH);
    digitalWrite(addrSwitch, HIGH);
    digitalWrite(datatoggle, LOW);

    // Writes address to proper address pins
    digitalWrite(addr1, bitRead(address,0));
    digitalWrite(addr2, bitRead(address,1));
    digitalWrite(addr3, bitRead(address,2));
    digitalWrite(addr4, bitRead(address,3));
    digitalWrite(addr5, bitRead(address,4));
    digitalWrite(addr6, bitRead(address,5));
    digitalWrite(addr7, bitRead(address,6));
    digitalWrite(addr8, bitRead(address,7));

    // Shifts out instruction
    shiftOut(shiftPin, clock, LSBFIRST, instruction);

    // Writes instruction
    delay(10);
    digitalWrite(WE, LOW);
    delay(10);
    digitalWrite(WE, HIGH);
    delay(10);

    // Sets data mode.
    digitalWrite(datatoggle, HIGH);

    // Shift out data
    shiftOut(shiftPin, clock, LSBFIRST, data);

    // Writes data
    delay(10);
    digitalWrite(WE, LOW);
    delay(10);
    digitalWrite(WE, HIGH);
    delay(10);

    // Totaly disables arduino.
    digitalWrite(WE, HIGH);
    digitalWrite(addrSwitch, LOW);
    digitalWrite(datatoggle, LOW);
    delay(10);

    // Add to tutal number of added instructions
    nr ++;
}

// Executes first and primes arduino to program
void setPins(){

  pinMode(addr1, OUTPUT);
  pinMode(addr2, OUTPUT);
  pinMode(addr3, OUTPUT);
  pinMode(addr4, OUTPUT);
  pinMode(addr5, OUTPUT);
  pinMode(addr6, OUTPUT);
  pinMode(addr7, OUTPUT);
  pinMode(addr8, OUTPUT);
  pinMode(WE, OUTPUT);
  pinMode(clock, OUTPUT);
  pinMode(shiftPin, OUTPUT);
  pinMode(addrSwitch, OUTPUT);
  pinMode(datatoggle, OUTPUT);

  digitalWrite(addrSwitch, LOW);
  digitalWrite(WE, HIGH);
  digitalWrite(datatoggle, LOW);
} 