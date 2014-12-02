% Mike Moore
% CENG 5131
% HW 6
% Problem 4
% Description:
% Using Matlab to verify the solution to the difference
% equation described in problem 4 (see handout)
clear; close all; clc
% declare filter input vector
x_in = 4*ones(1,11);
% initialize the filter output by applying intial conditions
y = [4, zeros(1,10)];

for n = 2:11
    % apply the filter programmatically
    y(n) = x_in(n) + 0.5*y(n-1);
end


syms k z
F =  (4*z^2)/((z-1)*(z-0.5));
iztrans(F, z, k);

num=[1];
den=[1 -1/2];
[K,Z,p]=residue(num,den);
x=filter(num,den,[4*ones(1,11)]);


% plot comparison
filter_output = [x' y']
figure(1)
stem(filter_output)
title('Stem plot of both filter outputs')
xlabel('time step')
ylabel('filter output')
legend('matlab filter', 'programmed filter')
legend
