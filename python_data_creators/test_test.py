import unittest
import test

class TestTest(unittest.TestCase):

    def test_add(self):
       result = test.add(10,5)
       self.assertEqual(result,15)
    
    def test_divide(self):
        self.assertEqual(test.divide(10,2),5)

        with self.assertRaises(ValueError):
            test.divide(10,1)
        


if __name__ == '__main__':
    unittest.main()