
% Mike Moore
% CENG 5131
% HW 10
% Problem # 3
% Description:
%   This script plots the solutions to problem # 3.
%   It relies on MATLAB's tf function to plot the 
%   system impulse response.
clear all; close all; clc;

num = [0 0 0 1];
denom = [1 1 0 0];
sys = tf(num,denom)
impulse(sys)