% Plot a sine wave for different spacing
% Test time spacing
dt=[0.1 0.5 0.9 1.5]; % Seconds between samples
% Plot x(t)=sin(pi*t) Here w=pi and T=2 sec so dt << 1 sec
for i = 1:length(dt)
	t1=0:dt(i):20 % We expect 10 cycles of the sine wave
	x1=sin(pi*t1);
	figure(1)
	subplot(2,2,i), plot(t1,x1) % Make a 2x2 matrix of plots to save space
	title(['\Delta t1 = ', num2str(dt(i)), ' sec ']);
end	
