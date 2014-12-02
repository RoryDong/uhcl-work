% Mike Moore
% CENG 5131
% HW 6
% Problem 5
% Description:
% Using Matlab to calculate the frequency response of a transfer function
% H(z) = (1/10)*[z/ (z-0.9)]
clear; close all; clc

num = [1/10 0]; den = [1 -0.9];
[h,w] = freqz(num,den);
freqz(num,den, [-pi:pi/150:pi])
% Print out values for when input frequency is 0.01 rad/sec
h(3)
% Print out values for when input frequency is 3 rad/sec
h(490)

% Output 

% ans =
% 
%    0.9873 - 0.1090i
% 
% 
% ans =
% 
%    0.0526 - 0.0035i