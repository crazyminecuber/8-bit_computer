import binascii

HLT = 2**0
RA  = 2**1
RO  = 2**2
RI  = 2**3
F1  = 2**4
F2  = 2**5
T1  = 2**6
T2  = 2**7
Sub = 2**8
UO  = 2**9
CE  = 2**10
CI  = 2**11
CO  = 2**12
MA  = 2**13
#IO  = 2**14
#GO  = 2**15
#GI  = 2**16
#II  = 2**17
FI  = 2**18
F3  = 2**19
T3  = 2**20

AI = T1
BI = T2
AO = F1
BO = F2 
GI = T3
GO = F3
II = T1 + T2
IO = F1 + F2

START = [CO + RA, RO + II]
END = [CE]


Fzero = 1
Fcarry = 2

max_instructions = 16
max_steps = 8
max_signals = 24
max_flag = 4
nr_step_pins = 3
nr_instr_pins = 4
nr_flag_pins = 2
inst_nr = 0
NAMEBASE = "EEPROM"




def write_to_file(the_list, number):
    with open(NAMEBASE + str(number) + ".hex","wb") as file:
        for item in the_list:
            file.write(item[0])

def get_eeprom(number):
    return [instr.get_bytes_and_adress(number) for instr in Instruction_Flag.List_flaged_instructions]

class Instruction_Flag:

    List_flaged_instructions = []

    def __init__(self, name, number, microinstructions, flag):
        self.name = name
        self.number = number
        self.set_micro(microinstructions)
        self.flag = flag
        self.adress = number * 2**(nr_step_pins) + flag * 2**(nr_step_pins+nr_instr_pins)

        Instruction_Flag.List_flaged_instructions.append(self)

    def get_total_micro(microinstructions):
        micro = START.copy()
        micro.extend(microinstructions)
        micro.extend(END)
        while len(micro) < 8:
            micro.append(0)
        return micro

    def set_micro(self, micro):
        self.micro = Instruction_Flag.get_total_micro(micro)

    def get_bytes_and_adress(self,EEPROM_number):
        ints = []
        for nano in self.micro:
            binary_string = "{0:b}".format(nano).zfill(24)
            sub_binary = binary_string[(16 - EEPROM_number*8):(24 - EEPROM_number*8)]
            ints.append(int(sub_binary,2))
        the_bytes = bytes(ints)
        return [the_bytes,self.adress]

    def fill_missing():
        #assumes sorted
        new_list = []
        for j in range(2**(nr_flag_pins)):
            for i in range(2**(nr_instr_pins)):
                new_list.append(Instruction_Flag("DUM",i,[0],j))
        for instr in Instruction_Flag.List_flaged_instructions:
            new_list[instr.adress // 8] = instr
        Instruction_Flag.List_flaged_instruction = new_list

# All will have length 8
class Instruction:
    List_general_instructions = []

    def __init__(self,name, number, microinstructions):
        self.flagged_instructions = []
        for i in range(max_flag):
            self.flagged_instructions.append(Instruction_Flag(name,number,microinstructions,i))
        Instruction.List_general_instructions.append(self)

    def flag(self, flag, micro):
        self.flagged_instructions[flag].set_micro(micro)

            
if __name__ == "__main__":

    NOP = Instruction("NOP", 0, [0])
    LDA = Instruction("LDA", 1, [MA + RO + AI])
    LDB = Instruction("LDB", 2, [MA + RO + BI])
    LDG = Instruction("LDG", 3, [MA + RO + GI])

    STA = Instruction("STA", 4, [RO + MA + RA, AO + RI])
    STB = Instruction("STB", 5, [RO + MA + RA, BO + RI])
    STG = Instruction("STG", 6, [RO + MA + RA, GO + RI])

    ADD = Instruction("ADD", 7, [MA + RO + BI, UO + AI + FI])
    SUB = Instruction("SUB", 8, [MA + RO + BI, UO + AI + Sub + FI])

    JMP = Instruction("JMP", 9, [MA + RO + CI])
    JPZ = Instruction("JPZ", 10, [0] )
    JPZ .flag(1, [ MA + RO + CI] )
    JPC = Instruction("JPC", 11, [0])
    JPC .flag(2, [MA + RO + CI] )
    PRG = Instruction("PRG", 12, [MA + RO + GI])

    Instruction_Flag.List_flaged_instructions.sort(key=lambda x: x.adress)
    Instruction_Flag.fill_missing()

    EEPROM0 = get_eeprom(0)
    EEPROM1 = get_eeprom(1)
    EEPROM2 = get_eeprom(2)
    write_to_file(EEPROM0,0)
    write_to_file(EEPROM1,1)
    write_to_file(EEPROM2,2)


