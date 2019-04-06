#define LED 13
void setup() {
  // put your setup code here, to run once
  pinMode(LED,OUTPUT);

}

void loop() {
  // put your main code here, to run repeatedly:
  digitalWrite(LED, 1);
  delay(500);
  digitalWrite(LED,0);
  delay(500);
}
