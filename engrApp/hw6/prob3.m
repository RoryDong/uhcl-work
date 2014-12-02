% Mike Moore
% CENG 5131
% HW 6
% Problem 3
% Description:
% Using Matlab to do an inverse z transform for problem 3
clear
syms k z
F =  (z)/(z^2-3*z+2)
iztrans(F, z, k)

num=[1 0 0];
den=[1 -3 2];
[K,Z,p]=residue(num,den)
x=filter(num,den,[1, zeros(1,5)])

% Output 
% prob3
%  
% F =
%  
% z/(z^2 - 3*z + 2)
%  
%  
% ans =
%  
% 2^k - 1
%  
% 
% K =
% 
%      4
%     -1
% 
% 
% Z =
% 
%      2
%      1
% 
% 
% p =
% 
%      1
% 
% 
% x =
% 
%      1     3     7    15    31    63
