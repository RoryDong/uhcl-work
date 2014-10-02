% Mike Moore
% CENG 5131
% HW 4
% Problem # 2
% Description:
%   This script plots the solutions to problem # 2. 
%   The first part is a plot of the solution obtained 
%   by hand to part a. It is a 2nd order system with 
%   no forcing function. The second part plots the same
%   system's response to the unit step forcing function.
%   Both solutions to the differential equation were obtained
%   by hand, and this script simply plots them.

clear all; close all; clc;

% Create time array
t = linspace(0,5,100);
homogeneous_soln = 2*exp(-t) - exp(-2*t);
particular_soln = exp(-t) - 0.5*exp(-2*t) + 0.5;

figure(1)
plot(t, homogeneous_soln, t, particular_soln)
title('Graph of Problem 2 Homogenous and Particular Solutions')
xlabel('0 < t < 5') % x-axis label
ylabel('solutions') % y-axis label
legend('yh = homogeneous soln','yp = particular soln', 'Location', 'northeast')
