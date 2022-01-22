# 8-bitars dator

# Manual

## Ladda över programm

I mappen `programs_for_computer` finns exempel och ett bibliotek för att skriva assembly liknande till datorn via arduino nanon som sitter på datorn. Biblioteket installeras genom att lägga det i library mappen till arduino klienten. 

Då datorn har en tendens att vara opålitlig finns det vissa testprogram skrivna. Jag rekomenderar dig stark att köra dessa program då du då kan vara säker på att viss funktionallitet fungerar.

## Ändring av microkod

Instruktionerna består av microinstruktioner som är inprogrammerade i EEPROM. Dessa har texten A,B,C på sig och skall programmeras med hex filer som spottas ut av instruction_data.py. Dessa får namnet 2,1,0 och skall programera EEPROM A,B,C i den ordningen!
Jag använde admittansen EEPROM-programerare när jag gjorde detta sist. Den fungerar bara på windows och man måste modifiera drivrutinerna för att det skall fungera på 64-bit. Se Admittansens github!


## Arkitektur

De styrsignaler som finns för tillfället är:
* HLT, ska stanna klockan men eftersom klockan nu mera är en arduino är denna funktion inte inkopplad.
* RA, gör att addressregistret till RAM-minnet läser in från bussen.
* RO, skriver ut data / instruktion på bussen från minnet:
* RI, skriver till minnet från bussen på addressen i addrssregistret.
* F1,F2,F3, väljer register att skriva från, se nedan
* T1,T2,T3, väljer register att skriva till, se nedan.
* Sub, sätter ALU till subtraktion.
* UO, mata ut resultatet från ALU till buss.
* CE, counter enable, räkna upp counter-registret.
* CI, skriv från buss till counter-registret.
* CO, skriv från counter-registret från bussen.
* MA, Sätter att minnet skall visa data istället för instruktion, (Varje address i minnet har både en byte instruktion och en byte data).
* FI, uppdaterar flagg-registret.

För att välja respektive register gäller följande(A,B,G,I är register, I är instructionsregistret)

AI = T1
BI = T2
AO = F1
BO = F2 
GI = T3
GO = F3
II = T1 + T2
IO = F1 + F2


Instruktionerna består av upp till 8 microinstructioner och tar 8 clockcyckler att utföra. De instruktioner som finns för tillfället är:

* NOP, gör ingenting
* LDA, ladda värde från minnet som hör till instruktionen till register A.
* LDB, ladda värde från minnet som hör till instruktionen till register B.
* LDG, ladda värde från minnet som hör till instruktionen till register G.
* STA, lagra värde från register A, till den minnesaddress som minnet som hör till denna instructionen pekar på.
* STB, lagra värde från register B, till den minnesaddress som minnet som hör till denna instructionen pekar på.
* STG, lagra värde från register G, till den minnesaddress som minnet som hör till denna instructionen pekar på.
* ADD, ladda värdet från minnet till register B och spara A + B i A.
* SUB, ladda värder från minnet till register B och spara A - B i A. 
* JMP, sätt counter-registret till värdet som minnet har.
* JPZ, om Z-flaggan är satt, hoppa till addressen som står i minnet, annars gör ingenting.
* JPC, om C-flaggan är satt, hoppa till addressen som står i minnet, annars gör ingenting.

De flaggor som för tillfället finns är 
*Z om resultatet av en ALU-operation är 0 sätts den.
*C om carry blir satt av en ALU-operation sätts den


