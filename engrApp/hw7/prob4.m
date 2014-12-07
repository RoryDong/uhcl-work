% Mike Moore
% CENG 5131
% HW 7
% Problem 4
% Description:
% Using Matlab to plot the Fourier amplitude spectrum
% of a pulse train. This script also plots the
% fourier series representaton of the pulse train.

% Fourier series representation for the pulse train
A = 4;
w0 = (8e6)*2*pi;
tau = 0.05e-6;
n=1:100; % Number of components
Wn=zeros(size(n));
Wn=(A/pi)*(sin(n*w0*(tau/2))./n); % Frequency spectrum n=1,2,...
Wn=[A*tau*w0/(2*pi),Wn]; % Add dc term
n=[0,n];
%
t=[-10*(1/w0):(1/(1000*w0)):10*(1/w0)]; % Range of t
f=zeros(size(t));
for k=1:1:100; % f(t) with 100 terms
f=f+(2*A/(k*pi))*sin(k*w0*(tau/2))*cos(k*w0*t); % in series
end
f=(A*tau*w0/(2*pi))+f; % Add dc value A*tau/T
% Put in a zero line and plot frequency
fzero=zeros(size(n));
clf % Clear any figures
subplot(2,1,1),plot(n,Wn,'*',n,fzero,'-');
xlabel('w radians per second')
ylabel('(A/pi)*sin(n*w0*tau/2)/n')
title('Fourier Series of Pulse Train')
% Plot f(t)
subplot(2,1,2),plot(t,f)
xlabel('t time in seconds')
ylabel('f(t)')
