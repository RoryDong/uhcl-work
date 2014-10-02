% Mike Moore
% CENG 5131
% HW 4
% Problem # 5
% Description:
%   This script plots the solutions to problem # 5. 
%   The first part is a plot of the solution obtained 
%   by hand to part a and satisfying initial conditions
%   x(0) = 1/3 and x'(0) = 0 . It is a 2nd order system with 
%   no forcing function. The second part plots the same
%   system's response with a different set of initial conditions.
%   The initial conditions for part b are x(0) = 0 and x'(0) = 5

clear all; close all; clc;

% Create time array
t = linspace(0,5,1000);
part_a_soln = (8/3)*t.*exp(-8*t) + (1/3)*exp(-8*t);
part_b_soln = 5*t.*exp(-8*t);

figure(1)
plot(t, part_a_soln, t, part_b_soln)
title('Graph of Problem 5 Part A and Part B Solutions')
xlabel('0 < t < 5') % x-axis label
ylabel('solutions') % y-axis label
legend('Part A Soln','Part B Soln', 'Location', 'northeast')
