% Mike Moore
% CENG 5131
% HW 9
% Problem # 5
% Description:
%   This script plots the solutions to problem # 5. 
%    It relies on symbolic Matlab to compute the
%    Laplace Transform for four functions.
clear all; close all; clc;

syms a t y
f1 = 2*t;
f2 = t-3;
f3 = 2*sin(t);
f4 = 3*t*exp(3*t);

laplace(f1, y)
laplace(f2, y)
laplace(f3, y)
laplace(f4, y)
