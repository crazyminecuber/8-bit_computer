#include "8-bit_programmer.h"


// Initializes arduino and starts writing
void setup() {
  setPins();

  // 33 + 9 = 42
  // 42 - 21 = 21
  sendByte(LDA, 33);
  sendByte(ADD, 9);
  sendByte(SUB, 21);
}

// Does nothing
void loop() {
  // put your main code here, to run repeatedly:
 delay(20000);
}
