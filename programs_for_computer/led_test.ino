#include "8-bit_programmer.h"



// Initializes arduino and starts writing
void setup() {
  setPins();
  sendByte(LDB, 0);

  // Checks general register one LED at a time.
  uint8_t test = 1;
  for(uint8_t i = 8; i <16 ; i++){
    sendByte(LDG, test);
    test = test << 1;
  }
  
  // Checks A register one LED at a time.
  test = 1;
  for(uint8_t i = 0; i <8 ; i++){
    sendByte(LDA, test);
    test = test << 1;
  }


  // Checks B register one LED at a time.
  test = 1;
  for(uint8_t i = 8; i <16 ; i++){
    sendByte(LDB, test);
    test = test << 1;
  }

}

// Does nothing
void loop() {
  // put your main code here, to run repeatedly:
 delay(20000);
}
