% Mike Moore
% CENG 5131
% HW 9
% Problem # 7
% Description:
%   This script plots the solutions to problem # 7.
%    It relies on symbolic Matlab to compute the
%    solution of a second order linear diffeq.
clear all; close all; clc;

syms y(t)
Dy = diff(y);
D2y = diff(y, 2);
dsolve(D2y + y == 2, y(0) == 0, Dy(0) == 2)