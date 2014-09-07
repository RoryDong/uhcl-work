x = input('Estimate e^x. Insert value for x: ')
exp_series = zeros(1, 20);
exp_series(1) = 1.0;
for i = 1:length(exp_series-1)
exp_series(i+1) = exp_series(i) + x^i / factorial(i);
end
fprintf('n      Series      Error    \n');
fprintf('%d   %.15f          %.7g   \n', 10, exp_series(10), exp(1) - exp_series(10)) ;
fprintf('%d   %.15f          %.7g   \n', 20, exp_series(20), exp(1) - exp_series(20)) ;