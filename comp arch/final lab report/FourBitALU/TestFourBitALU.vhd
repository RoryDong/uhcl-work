----------------------------------------------------
-- Engineer: Mike Moore
--
-- Create Date:   13:43:31 10/31/2013
-- Design Name:   
-- Module Name:   FourBitALU/TestFourBitALU.vhd
-- Project Name:  UHCL CENG 3511 Four Bit ALU
--
----------------------------------------------------
LIBRARY ieee;
USE ieee.std_logic_1164.ALL;
use IEEE.NUMERIC_STD.ALL;
ENTITY TestFourBitALU IS
END TestFourBitALU;
 
ARCHITECTURE behavior OF TestFourBitALU IS 
    -- Component Declaration for the Unit Under Test (UUT)
    COMPONENT FourBitALU
    PORT(
         registerA : IN  std_logic_vector(3 downto 0);
         registerB : IN  std_logic_vector(3 downto 0);
         opCode : IN  std_logic_vector(3 downto 0);
         carryIn : IN  std_logic;
         dataOut : OUT  std_logic_vector(3 downto 0);
         carryOut : OUT  std_logic
        );
    END COMPONENT;

   --Inputs
   signal registerA : std_logic_vector(3 downto 0) := (others => '0');
   signal registerB : std_logic_vector(3 downto 0) := (others => '0');
   signal opCode : std_logic_vector(3 downto 0) := (others => '0');
   signal carryIn : std_logic := '0';
 	--Outputs
   signal dataOut : std_logic_vector(3 downto 0);
   signal carryOut : std_logic;
BEGIN
	-- Instantiate the Unit Under Test (UUT)
   uut: FourBitALU PORT MAP (
          registerA => registerA,
          registerB => registerB,
          opCode => opCode,
          carryIn => carryIn,
          dataOut => dataOut,
          carryOut => carryOut
        );
 
   -- Stimulus process
   stim_proc: process
   begin	
      wait for 100 ns; --Expected Output: 0101
			registerA <= "0101";
			registerB <= "0000"; 
			carryIn <= '0';
			opCode <=  "0000"; --G=A 
      wait for 100 ns; --Expected Output: 0010
			registerA <= "0001";
			registerB <= "0000"; 
			carryIn <= '1';
			opCode <= "0001"; --G=A+1 
		wait for 100 ns; --Expected Output: 1111
			registerA <= "1010";
			registerB <= "0101";
			carryIn <= '0';			
			opCode <= "0010"; --G=A+B
		wait for 100 ns; --Expected Output: 1111
			registerA <= "1010";
			registerB <= "0100";
			carryIn <= '1'; 
			opCode <= "0011"; --G=A+B+1
		wait for 100 ns; --Expected Output: 0000
			registerA <= "0001";
			registerB <= "0000"; 
			carryIn <= '0'; 
			opCode <= "0110"; --G=A-1 
		wait for 100 ns; --Expected Output: 1111
			registerA <= "1111"; 
			registerB <= "0000"; 
			carryIn <= '1'; 
			opCode <= "0111"; --G=A 
		wait for 100 ns; --Expected Output: 1001
			registerA <= "1001"; 
			registerB <= "1111"; 
			carryIn <= '0';
			opCode <= "1001"; --G=A and B 
		wait for 100 ns; --Expected Output: 1100
			registerA <= "1000";
			registerB <= "1100"; 
			carryIn <= '0';
			opCode <= "1010"; --G=A or B
		wait for 100 ns; --Expected Output: 0100
			registerA <= "1001";
			registerB <= "1101"; 
			carryIn <= '0';
			opCode <= "1011"; --G=A xor B
		wait for 100 ns; --Expected Output: 0111 
			registerA <= "1111"; 
			registerB <= "0000"; 
			carryIn <= '0';
			opCode <= "1100"; --shift right logical one bit 
		wait for 100 ns; --Expected Output: 1110 
			registerA <= "1111";
			registerB <= "0000"; 
			carryIn <= '0';
			opCode <= "1111"; --shift left logical one bit 	
		wait for 100 ns; 
      wait;
   end process;
END;