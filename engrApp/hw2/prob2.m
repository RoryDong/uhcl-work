% CENG 5131 HW 2 Problem 2 - Solves the complex equation z^3 = -1 using
%                            the roots command
%
% Author: Mike Moore
% Date : Sept 8 2014

%------------- BEGIN CODE --------------

% Using root commands to solve complex equation z^3 + 1 = 0
a = roots([1 0 0 1])
% Verify the solution by multiplying each of the roots by itself three times
check1 = a(1)*a(1)*a(1)
check2 = a(2)*a(2)*a(2)
check3 = a(3)*a(3)*a(3)

%------------- END OF CODE --------------
