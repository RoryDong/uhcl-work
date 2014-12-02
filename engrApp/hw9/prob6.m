
% Mike Moore
% CENG 5131
% HW 9
% Problem # 6
% Description:
%   This script plots the solutions to problem # 6.
%    It relies on symbolic Matlab to compute the
%    inverse Laplace Transform.
clear all; close all; clc;

syms x s
F = (120*s)/((s-1)*(s+2)*(s^2-2*s+3));

ilaplace(F, s, x)