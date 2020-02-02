#include <8-bit_programmer.h>



// Initializes arduino and starts writing
void setup() {
  setPins();
  sendByte(LDA, 255);
  sendByte(ADD, 3);
  sendByte(STA, 4);
  sendByte(LDG, 1);
  sendByte(JMP, 0);
  

}

// Does nothing
void loop() {
  // put your main code here, to run repeatedly:
 delay(20000);
}