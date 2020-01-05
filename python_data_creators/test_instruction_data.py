import unittest                                          
from instruction_data import *

class Test_instruction_data(unittest.TestCase):

    def setUp(self):
        #Instruction("NOP", 0,[0])
        #Instruction("LDA", 1,[RO + AI + MA])
        pass


    def tearDown(self):

        Instruction.Instructions = []
        Instruction_Flag.instructions_flags = []


    def test_class(self):
        # Testing adding one instruction
        NOP = Instruction("NOP",0,[0])
        self.assertEqual(len(Instruction.Instructions), 1)
        self.assertEqual(len(Instruction_Flag.instructions_flags), 4)

        self.assertEqual(Instruction_Flag.instructions_flags[0].micro[2], 0)
        self.assertEqual(Instruction_Flag.instructions_flags[1].micro[2], 0)
        self.assertEqual(Instruction_Flag.instructions_flags[2].micro[2], 0)
        self.assertEqual(Instruction_Flag.instructions_flags[3].micro[2], 0)

        NOP.flag(1,[1])
        NOP.flag(2,[2])
        NOP.flag(3,[AI,BI])

        debug = Instruction_Flag.instructions_flags

        self.assertEqual(len(Instruction_Flag.instructions_flags), 4)

        self.assertEqual(Instruction_Flag.instructions_flags[0].micro[2], 0)
        self.assertEqual(Instruction_Flag.instructions_flags[1].micro[2], 1)
        self.assertEqual(Instruction_Flag.instructions_flags[2].micro[2], 2)
        self.assertEqual(Instruction_Flag.instructions_flags[3].micro[2:4], [AI,BI])

        LDA = Instruction("LDA",1,[RO + AI + MA])
        self.assertEqual(len(Instruction.Instructions), 2)
        self.assertEqual(len(Instruction_Flag.instructions_flags), 8)
        LDA.flag(3, [7,2])
        self.assertEqual(Instruction_Flag.instructions_flags[0].micro[2], 0)
        self.assertEqual(Instruction_Flag.instructions_flags[1].micro[2], 1)
        self.assertEqual(Instruction_Flag.instructions_flags[2].micro[2], 2)
        self.assertEqual(Instruction_Flag.instructions_flags[3].micro[2], AI)

        self.assertEqual(Instruction_Flag.instructions_flags[4].micro[2], RO + AI + MA)
        self.assertEqual(Instruction_Flag.instructions_flags[5].micro[2], RO + AI + MA)
        self.assertEqual(Instruction_Flag.instructions_flags[6].micro[2], RO + AI + MA)
        self.assertEqual(Instruction_Flag.instructions_flags[7].micro[2], 7)

        self.assertEqual(Instruction_Flag.instructions_flags[0].adress, 0)
        self.assertEqual(Instruction_Flag.instructions_flags[1].adress, 2**(nr_step_pins + nr_instr_pins ))
        self.assertEqual(Instruction_Flag.instructions_flags[2].adress, 2 * 2**(nr_step_pins + nr_instr_pins))
        self.assertEqual(Instruction_Flag.instructions_flags[3].adress, 3 * 2**(nr_step_pins + nr_instr_pins))

        self.assertEqual(Instruction_Flag.instructions_flags[4].adress, 2**(nr_step_pins))
        self.assertEqual(Instruction_Flag.instructions_flags[5].adress, 2**(nr_step_pins)+2**(nr_step_pins + nr_instr_pins))
        self.assertEqual(Instruction_Flag.instructions_flags[6].adress, 2**(nr_step_pins)+2 * 2**(nr_step_pins + nr_instr_pins))
        self.assertEqual(Instruction_Flag.instructions_flags[7].adress, 2**(nr_step_pins)+3 * 2**(nr_step_pins + nr_instr_pins))

        Instruction_Flag.instructions_flags.sort(key=lambda x: x.adress)

        self.assertEqual(Instruction_Flag.instructions_flags[0].adress, 0)
        self.assertEqual(Instruction_Flag.instructions_flags[1].adress, 8)
        self.assertEqual(Instruction_Flag.instructions_flags[2].adress, 128)
        self.assertEqual(Instruction_Flag.instructions_flags[3].adress, 136)
        self.assertEqual(Instruction_Flag.instructions_flags[4].adress, 256)
        self.assertEqual(Instruction_Flag.instructions_flags[5].adress, 264)
        self.assertEqual(Instruction_Flag.instructions_flags[6].adress, 384)
        self.assertEqual(Instruction_Flag.instructions_flags[7].adress, 392)

    def test_EEPROM(self):
        NOP = Instruction("NOP",0,[0])
        self.assertEqual(len(Instruction_Flag.instructions_flags[0].get_bytes_and_adress(0)[0]), 8)
        self.assertEqual(Instruction_Flag.instructions_flags[0].get_bytes_and_adress(0)[0][0], int('00000010',2))
        self.assertEqual(Instruction_Flag.instructions_flags[0].get_bytes_and_adress(1)[0][0], int('00010000',2))
        self.assertEqual(Instruction_Flag.instructions_flags[0].get_bytes_and_adress(0)[0][1], int('00000100',2))

if __name__ == "__main__":
    unittest.main()