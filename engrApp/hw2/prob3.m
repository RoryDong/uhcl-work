% CENG 5131 HW 2 Problem 3 - 
%                            
%
% Author: Mike Moore
% Date : Sept 8 2014

%------------- BEGIN CODE --------------

% Part 1
% Convert the decimal integer 11 to binary
a = dec2bin(11)
b = bin2dec(a)
% Part 2
intVal = int16(325.499)
% Verify the size of intVal is 2 bytes... 16 bits
s=whos('intVal');
[s.bytes]

%------------- END OF CODE --------------
