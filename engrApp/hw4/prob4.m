% Mike Moore
% CENG 5131
% HW 4
% Problem # 4
% Description:
%    Symbolic MATLAB is used to solve the differential
%    equation described in problem 4.

clear all; close all; clc;

syms y(t)
dsolve(diff(y, 2) + 4 * diff(y) + 40*y == 9.81)
