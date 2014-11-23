% Mike Moore
% CENG 5131
% HW 10
% Problem # 1
% Description:
%   This script plots the solutions to problem # 1.
%    It relies on symbolic Matlab to compute the
%    Laplace Transform for the given impulse response:
%    h(t) = [2e^(-5t)cos(12t-pi/2)]*u(t) 
clear all; close all; clc;

syms a t s
f = 2*exp(-5*t)*cos(12*t-pi/2);

laplace(f, s)
