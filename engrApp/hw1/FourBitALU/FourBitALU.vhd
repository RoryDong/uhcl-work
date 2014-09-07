----------------------------------------------------
-- Engineer: Mike Moore 
-- 
-- Create Date:    13:24:51 10/31/2013 
-- Module Name:    FourBitALU - Behavioral 
-- Project Name:   UHCL CENG 3511 Final Lab Project
-- Description:    VHDL Code for a four bit ALU.
--
----------------------------------------------------
library IEEE;
use IEEE.STD_LOGIC_1164.ALL;
use IEEE.NUMERIC_STD.ALL;

entity FourBitALU is
    Port ( registerA : in std_logic_vector(3 downto 0);
           registerB : in std_logic_vector(3 downto 0);
           opCode : in std_logic_vector(3 downto 0);
           carryIn : in  STD_LOGIC;
           dataOut : out std_logic_vector(3 downto 0);
           carryOut : out  STD_LOGIC);
end FourBitALU;

architecture Behavioral of FourBitALU is
   signal Temp: std_logic_vector(4 downto 0);
begin
   process(registerA, registerB, opCode, Temp, carryIn) is
   begin
      carryOut <= '0';
      case opCode is
        when "0000" => --dataOut = A (Cin = 0)
          dataOut <= registerA;
        when "0001" => --dataOut = A + 1 
          dataOut <= std_logic_vector(unsigned(registerA) + 1);
        when "0010" => --dataOut = A + B 
			   	Temp   <= std_logic_vector((unsigned("0" & registerA) + unsigned(registerB)));
          dataOut <= Temp(3 downto 0);
          carryOut   <= Temp(4);	 
        when "0011" => --dataOut = A + B + 1 
          Temp   <= std_logic_vector((unsigned("0" & registerA) + unsigned(registerB)) + 1);
          dataOut <= Temp(3 downto 0);
          carryOut   <= Temp(4);					
        when "0110" => --dataOut = A - 1 
          dataOut <= std_logic_vector(unsigned(registerA) - 1); 
        when "0111" => --dataOut = A (Cin = 1) 
          dataOut <= registerA;
        when "1001" => --dataOut = A and B 
          dataOut <= registerA and registerB;		
			  when "1010" => --dataOut = A or B 
			  	dataOut <= registerA or registerB; 
			  when "1011" => --dataOut = A xor B 
			  	dataOut <= registerA xor registerB;
			  when "1100" => --dataOut = A shift logical right one bit 
				  dataOut <= std_logic_vector(unsigned(registerA) srl 1);
			  when "1101" => --dataOut = A shift logical right one bit 
				  dataOut <= std_logic_vector(unsigned(registerA) srl 1);
			  when "1110" => --dataOut = A shift logical left one bit 
				  dataOut <= std_logic_vector(unsigned(registerA) sll 1);
			  when "1111" => --dataOut = A shift logical left one bit 
				  dataOut <= std_logic_vector(unsigned(registerA) sll 1); 
        when others => 
          dataOut <= "0000"; 
      end case;
   end process;
end Behavioral;