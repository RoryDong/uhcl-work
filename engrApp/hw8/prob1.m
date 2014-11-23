% Mike Moore
% CENG 5131
% HW 8
% Problem # 1
% Description:
%   Computes and plot the DFT of f(t)=2exp(-3t).
%   Relies on function defined in clfftf.m 
%   This function was taken from class textbook:
%   Advanced Engineering Mathematics with MATLAB
clear all; close all; clc;

N = 128
T = 3 
% Sampling interval
Ts = T/N;
t0 = 0;
% vector of time points and f(n*Ts)
ts = (t0:Ts:Ts*(N-1));
ft = 2*exp(-3*ts);
% Determines the spectrum by calling clfftf
[Fft,Ffmag,Ffang] = clfftf(ft,N,Ts);
% Compute the frequency values in hertz fs=1/(N*Ts); fmax=1/(2*Ts)
fs = 1/(N*Ts);
f = fs*linspace(-N/2,N/2-1,N);
% Plot Fexact and DFT result
w = 2*pi*f;
Fexact = 2./(sqrt((9+w.^2))); % Magnitude
Thetaex = -(180/pi)*atan(w/3); % Angle in degrees
clf
subplot(2,1,1)
plot(f,Fexact(1:N),'--',f,Ffmag(1:N));
title(['FT and DFT of exp(-t), N=',num2str(N), ' T= ',num2str(T),' sec'])
xlabel('Frequency in hertz')
ylabel('FT and DFT')
legend('FT','DFT')
subplot(2,1,2),plot(f,Thetaex(1:N),'--',f,Ffang(1:N));
xlabel('Frequency in hertz')
ylabel('Phase FT and DFT')
legend('FT','DFT')
