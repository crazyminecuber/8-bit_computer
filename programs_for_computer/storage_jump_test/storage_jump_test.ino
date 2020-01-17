#include <8-bit_programmer.h>



// Initializes arduino and starts writing
void setup() {
  setPins();
  sendByte(NOP, 1);
  sendByte(LDA, 1);
  sendByte(ADD, 2);
  sendByte(STA, 4);
  sendByte(LDG, 1);
  sendByte(JMP, 0);
  

}

// Does nothing
void loop() {
  // put your main code here, to run repeatedly:
 delay(20000);
}