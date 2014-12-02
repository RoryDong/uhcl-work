% Mike Moore
% CENG 5131
% HW 6
% Problem 3
% Description:
% Using Matlab to do an inverse z transform for problem 2
syms k z
F =  (8*z^3+2*z^2-5*z)/(z^3-1.75*z+0.75)
 
iztrans(F, z, k)

num = [8 2 -5 0]
den = [1 0 -1.75 0.75]
x=filter(num,den,[1 zeros(1,9)])

% output
% prob2
%  
% F =
%  
% (8*z^3 + 2*z^2 - 5*z)/(z^3 - (7*z)/4 + 3/4)
%  
%  
% ans =
%  
% 2*(1/2)^k + 2*(-3/2)^k + 4
%  
% 
% num =
% 
%      8     2    -5     0
% 
% 
% den =
% 
%     1.0000         0   -1.7500    0.7500
% 
% 
% x =
% 
%   Columns 1 through 5
% 
%     8.0000    2.0000    9.0000   -2.5000   14.2500
% 
%   Columns 6 through 10
% 
%   -11.1250   26.8125  -30.1562   55.2656  -72.8828