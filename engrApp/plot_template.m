clear all; close all; clc;

t = linspace(0,2*pi,100);
x = sin(t);
y = cos(t);

figure(1)
plot(t, x, t, y)
title('Graph of Sine and Cosine Between -2\pi and 2\pi')
xlabel('-2\pi < x < 2\pi') % x-axis label
ylabel('sine and cosine values') % y-axis label
legend('y = sin(x)','y = cos(x)', 'Location', 'southwest')
