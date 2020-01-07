#define addr1 2
#define addr2 3
#define addr3 4
#define addr4 5
#define addr5 6
#define addr6 7
#define addr7 8
#define addr8 9

#define datatoggle 10
#define WE 11
#define addrSwitch 12

#define  clock A1
#define shiftPin A0

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


void setup() {
  // put your setup code here, to run once:
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

byte test = 1;
for(byte i = 0; i <8 ; i++){
 sendByte(i, LDA, test);
 test = test << 1;
}

test = 1;
for(byte i = 8; i <16 ; i++){
 sendByte(i, LDB, test);
 test = test << 1;
}

}

void loop() {
  // put your main code here, to run repeatedly:
  delay(2000);
}

void sendByte(byte address, byte instruction, byte data){
digitalWrite(WE, HIGH);
digitalWrite(addrSwitch, HIGH);
digitalWrite(datatoggle, LOW);

digitalWrite(addr1, bitRead(address,0));
digitalWrite(addr2, bitRead(address,1));
digitalWrite(addr3, bitRead(address,2));
digitalWrite(addr4, bitRead(address,3));
digitalWrite(addr5, bitRead(address,4));
digitalWrite(addr6, bitRead(address,5));
digitalWrite(addr7, bitRead(address,6));
digitalWrite(addr8, bitRead(address,7));

shiftOut(shiftPin, clock, LSBFIRST, instruction);

delay(100);
digitalWrite(WE, LOW);
delay(100);
digitalWrite(WE, HIGH);

delay(100);

digitalWrite(datatoggle, HIGH);

shiftOut(shiftPin, clock, LSBFIRST, data);

delay(100);
digitalWrite(WE, LOW);
delay(100);
digitalWrite(WE, HIGH);

delay(100);

digitalWrite(WE, HIGH);
digitalWrite(addrSwitch, LOW);
digitalWrite(datatoggle, LOW);
delay(100);
}