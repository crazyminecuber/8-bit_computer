#include <8-bit_programmer.h>



// Initializes arduino and starts writing
void setup() {
  setPins();
  sendByte(NOP, 0);
  sendByte(LDA, 8);
  sendByte(SUB, 8);
  sendByte(JPZ, 5);
  sendByte(JMP, 0);
  sendByte(LDG, 255);

}

// Does nothing
void loop() {
  // put your main code here, to run repeatedly:
 delay(20000);
}