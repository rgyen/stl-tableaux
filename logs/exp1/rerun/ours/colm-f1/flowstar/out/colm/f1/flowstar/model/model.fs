hybrid reachability {
 state var clk4, x, ff, clk0, gClk, y, clk2, clk1, clk3
 setting {
 adaptive steps {min 0.001, max 0.5}
time 30
remainder estimation 1e-8
identity precondition 
gnuplot octagon clk4,clk4 fixed orders 8
cutoff 1e-13
precision 53
no output 
max jumps 1000
print on  
}

 modes {
 mode_0{
poly ode 2
{clk1' = 1.0
clk0' = 1.0
clk3' = 1.0
clk2' = 1.0
clk4' = 1.0
gClk' = 1.0
x' = (0.1 * y)
y' = ((((0.2 * x) - (((0.1 * x) * x) * x)) - (0.02 * y)) + 0.01)
ff' = 0.0
}
inv {
(x - 1000) <= 0.0
(gClk - 50.0) <= 0.0
(-1000 - y) <= 0.0
(-1000 - x) <= 0.0
(gClk - 0.0) >= 0.0
(y - 1000) <= 0.0
(y - (3.0 + 0.5)) <= 0.0
}
}
mode_1{
poly ode 2
{clk1' = 1.0
clk0' = 1.0
clk3' = 1.0
clk2' = 1.0
clk4' = 1.0
gClk' = 1.0
x' = (0.1 * y)
y' = ((((0.2 * x) - (((0.1 * x) * x) * x)) - (0.02 * y)) + 0.01)
ff' = 0.0
}
inv {
(x - 1000) <= 0.0
(gClk - 50.0) <= 0.0
(-1000 - y) <= 0.0
(-1000 - x) <= 0.0
(gClk - 0.0) >= 0.0
(y - 1000) <= 0.0
}
}
mode_2{
poly ode 2
{clk1' = 1.0
clk0' = 1.0
clk3' = 1.0
clk2' = 1.0
clk4' = 1.0
gClk' = 1.0
x' = (0.1 * y)
y' = ((((0.2 * x) - (((0.1 * x) * x) * x)) - (0.02 * y)) + 0.01)
ff' = 0.0
}
inv {
(x - 1000) <= 0.0
(gClk - 50.0) <= 0.0
(-1000 - y) <= 0.0
(-1000 - x) <= 0.0
(gClk - 0.0) >= 0.0
(y - 1000) <= 0.0
(y - (3.0 + 0.5)) <= 0.0
}
}
mode_3{
poly ode 2
{clk1' = 1.0
clk0' = 1.0
clk3' = 1.0
clk2' = 1.0
clk4' = 1.0
gClk' = 1.0
x' = (0.1 * y)
y' = ((((0.2 * x) - (((0.1 * x) * x) * x)) - (0.02 * y)) + 0.01)
ff' = 0.0
}
inv {
(x - 1000) <= 0.0
(gClk - 50.0) <= 0.0
(-1000 - y) <= 0.0
(-1000 - x) <= 0.0
(gClk - 0.0) >= 0.0
(y - 1000) <= 0.0
}
}
mode_4{
poly ode 2
{clk1' = 1.0
clk0' = 1.0
clk3' = 1.0
clk2' = 1.0
clk4' = 1.0
gClk' = 1.0
x' = (0.1 * y)
y' = ((((0.2 * x) - (((0.1 * x) * x) * x)) - (0.02 * y)) + 0.01)
ff' = 0.0
}
inv {
(x - 1000) <= 0.0
(gClk - 50.0) <= 0.0
(-1000 - y) <= 0.0
(-1000 - x) <= 0.0
(gClk - 0.0) >= 0.0
(y - 1000) <= 0.0
(y - (3.0 + 0.5)) <= 0.0
}
}
mode_5{
poly ode 2
{clk1' = 1.0
clk0' = 1.0
clk3' = 1.0
clk2' = 1.0
clk4' = 1.0
gClk' = 1.0
x' = (0.1 * y)
y' = ((((0.2 * x) - (((0.1 * x) * x) * x)) - (0.02 * y)) + 0.01)
ff' = 0.0
}
inv {
(x - 1000) <= 0.0
(gClk - 50.0) <= 0.0
(-1000 - y) <= 0.0
(-1000 - x) <= 0.0
(gClk - 0.0) >= 0.0
(y - 1000) <= 0.0
(y - (3.0 + 0.5)) <= 0.0
}
}
mode_6{
poly ode 2
{clk1' = 1.0
clk0' = 1.0
clk3' = 1.0
clk2' = 1.0
clk4' = 1.0
gClk' = 1.0
x' = (0.1 * y)
y' = ((((0.2 * x) - (((0.1 * x) * x) * x)) - (0.02 * y)) + 0.01)
ff' = 0.0
}
inv {
(x - 1000) <= 0.0
(gClk - 50.0) <= 0.0
(-1000 - y) <= 0.0
(-1000 - x) <= 0.0
(gClk - 0.0) >= 0.0
(y - 1000) <= 0.0
(y - (3.0 + 0.5)) <= 0.0
}
}
mode_7{
poly ode 2
{clk1' = 1.0
clk0' = 1.0
clk3' = 1.0
clk2' = 1.0
clk4' = 1.0
gClk' = 1.0
x' = (0.1 * y)
y' = ((((0.2 * x) - (((0.1 * x) * x) * x)) - (0.02 * y)) + 0.01)
ff' = 0.0
}
inv {
(x - 1000) <= 0.0
(gClk - 50.0) <= 0.0
(-1000 - y) <= 0.0
(-1000 - x) <= 0.0
(gClk - 0.0) >= 0.0
(y - 1000) <= 0.0
}
}
mode_8{
poly ode 2
{clk1' = 1.0
clk0' = 1.0
clk3' = 1.0
clk2' = 1.0
clk4' = 1.0
gClk' = 1.0
x' = (0.1 * y)
y' = ((((0.2 * x) - (((0.1 * x) * x) * x)) - (0.02 * y)) + 0.01)
ff' = 0.0
}
inv {
(x - 1000) <= 0.0
(gClk - 50.0) <= 0.0
(-1000 - y) <= 0.0
(-1000 - x) <= 0.0
(gClk - 0.0) >= 0.0
(y - 1000) <= 0.0
}
}
mode_9{
poly ode 2
{clk1' = 1.0
clk0' = 1.0
clk3' = 1.0
clk2' = 1.0
clk4' = 1.0
gClk' = 1.0
x' = (0.1 * y)
y' = ((((0.2 * x) - (((0.1 * x) * x) * x)) - (0.02 * y)) + 0.01)
ff' = 0.0
}
inv {
(x - 1000) <= 0.0
(gClk - 50.0) <= 0.0
(-1000 - y) <= 0.0
(-1000 - x) <= 0.0
(gClk - 0.0) >= 0.0
(y - 1000) <= 0.0
}
}
mode_10{
poly ode 2
{clk1' = 1.0
clk0' = 1.0
clk3' = 1.0
clk2' = 1.0
clk4' = 1.0
gClk' = 1.0
x' = (0.1 * y)
y' = ((((0.2 * x) - (((0.1 * x) * x) * x)) - (0.02 * y)) + 0.01)
ff' = 0.0
}
inv {
(x - 1000) <= 0.0
(gClk - 50.0) <= 0.0
(-1000 - y) <= 0.0
(-1000 - x) <= 0.0
(gClk - 0.0) >= 0.0
(y - 1000) <= 0.0
}
}
mode_11{
poly ode 2
{clk1' = 1.0
clk0' = 1.0
clk3' = 1.0
clk2' = 1.0
clk4' = 1.0
gClk' = 1.0
x' = (0.1 * y)
y' = ((((0.2 * x) - (((0.1 * x) * x) * x)) - (0.02 * y)) + 0.01)
ff' = 0.0
}
inv {
(x - 1000) <= 0.0
(gClk - 50.0) <= 0.0
(-1000 - y) <= 0.0
(-1000 - x) <= 0.0
(gClk - 0.0) >= 0.0
(y - 1000) <= 0.0
}
}
mode_12{
poly ode 2
{y' = 0.0
x' = 0.0
clk4' = 0.0
clk0' = 0.0
gClk' = 1.0
clk2' = 0.0
clk1' = 0.0
clk3' = 0.0
ff' = 0.0
}
inv {
(gClk - 0.0) >= 0.0
(gClk - 50.0) <= 0.0
}
}
}

 jumps {
 mode_4 -> mode_5
guard {
(clk0 - 10.0) >= 0.0
(clk2 - 20.0) >= 0.0
(clk1 - 20.0) <= 0.0
}
reset {
clk0' := 10.0
clk3' := 0.0
y' := y
clk1' := clk1
clk2' := 20.0
x' := x
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_0 -> mode_5
guard {
(clk0 - 10.0) >= 0.0
(clk2 - 20.0) >= 0.0
}
reset {
clk0' := 10.0
clk3' := 0.0
y' := y
clk1' := 0.0
clk2' := 20.0
x' := x
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_2 -> mode_11
guard {
(clk2 - 20.0) >= 0.0
(clk3 - 20.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_5 -> mode_2
guard {
(clk0 - 10.0) >= 0.0
(clk2 - 20.0) >= 0.0
(clk3 - 20.0) >= 0.0
(clk1 - 20.0) >= 0.0
}
reset {
clk0' := clk0
clk3' := 0.0
y' := y
clk2' := 20.0
x' := x
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_6 -> mode_2
guard {
(clk2 - 20.0) >= 0.0
(clk3 - 20.0) <= 0.0
}
reset {
clk0' := clk0
y' := y
clk3' := clk3
clk2' := 20.0
x' := x
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_10 -> mode_4
guard {
(clk0 - 10.0) <= 0.0
}
reset {
clk0' := clk0
y' := y
clk3' := clk3
clk2' := 0.0
x' := x
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_1 -> mode_3
guard {
(clk0 - 10.0) >= 0.0
(clk2 - 28.0) <= 0.0
(clk1 - 20.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
clk3' := 0.0
y' := y
x' := x
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_4 -> mode_7
guard {
(clk0 - 10.0) >= 0.0
(clk2 - 20.0) >= 0.0
(clk1 - 20.0) <= 0.0
}
reset {
clk0' := 10.0
clk3' := 0.0
y' := y
clk1' := clk1
clk2' := 20.0
x' := x
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_6 -> mode_3
guard {
(clk2 - 28.0) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_10 -> mode_1
guard {
(clk0 - 10.0) <= 0.0
}
reset {
clk0' := clk0
y' := y
clk3' := clk3
clk2' := 0.0
x' := x
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_6 -> mode_5
guard {
(clk0 - 10.0) >= 0.0
(clk2 - 20.0) >= 0.0
(clk1 - 20.0) <= 0.0
}
reset {
clk0' := 10.0
clk3' := 0.0
y' := y
clk1' := clk1
clk2' := 20.0
x' := x
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_7 -> mode_5
guard {
(clk0 - 10.0) >= 0.0
(clk2 - 28.0) <= 0.0
(clk1 - 20.0) <= 0.0
}
reset {
clk0' := 10.0
clk2' := clk2
y' := y
clk1' := clk1
clk3' := clk3
x' := x
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_6 -> mode_5
guard {
(clk0 - 10.0) >= 0.0
(clk2 - 20.0) >= 0.0
(clk1 - 20.0) <= 0.0
(clk3 - 20.0) <= 0.0
}
reset {
clk0' := 10.0
y' := y
clk1' := clk1
clk3' := clk3
clk2' := 20.0
x' := x
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_9 -> mode_10
guard {
(clk0 - 10.0) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk1' := 0.0
clk3' := clk3
x' := x
gClk' := gClk
clk4' := clk4
}
parallelotope aggregation { }

mode_12 -> mode_9
guard {
}
reset {
clk2' := clk2
y' := y
clk3' := clk3
clk0' := 0.0
x' := x
gClk' := 0.0
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_5 -> mode_7
guard {
(clk0 - 10.0) >= 0.0
(clk2 - 28.0) <= 0.0
(clk1 - 20.0) <= 0.0
}
reset {
clk0' := 10.0
clk2' := clk2
clk3' := 0.0
y' := y
clk1' := clk1
x' := x
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_0 -> mode_7
guard {
(clk0 - 10.0) >= 0.0
(clk2 - 20.0) >= 0.0
}
reset {
clk0' := 10.0
clk3' := 0.0
y' := y
clk1' := 0.0
clk2' := 20.0
x' := x
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_4 -> mode_6
guard {
(clk0 - 10.0) >= 0.0
(clk2 - 20.0) >= 0.0
(clk1 - 20.0) <= 0.0
}
reset {
clk0' := 10.0
clk3' := 0.0
y' := y
clk1' := clk1
clk2' := 20.0
x' := x
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_6 -> mode_7
guard {
(clk0 - 10.0) >= 0.0
(clk2 - 28.0) <= 0.0
(clk1 - 20.0) <= 0.0
}
reset {
clk0' := 10.0
clk2' := clk2
y' := y
clk1' := clk1
clk3' := clk3
x' := x
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_9 -> mode_4
guard {
(clk0 - 10.0) <= 0.0
}
reset {
clk0' := clk0
y' := y
clk1' := 0.0
clk3' := clk3
clk2' := 0.0
x' := x
gClk' := gClk
clk4' := clk4
}
parallelotope aggregation { }

mode_1 -> mode_6
guard {
(clk0 - 10.0) >= 0.0
(clk2 - 28.0) <= 0.0
(clk1 - 20.0) <= 0.0
}
reset {
clk0' := 10.0
clk2' := clk2
clk3' := 0.0
y' := y
clk1' := clk1
x' := x
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_2 -> mode_3
guard {
(clk2 - 20.0) >= 0.0
(clk3 - 20.0) <= 0.0
}
reset {
clk0' := clk0
y' := y
clk3' := clk3
clk2' := 20.0
x' := x
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_6 -> mode_3
guard {
(clk2 - 20.0) >= 0.0
(clk3 - 20.0) <= 0.0
}
reset {
clk0' := clk0
y' := y
clk3' := clk3
clk2' := 20.0
x' := x
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_0 -> mode_6
guard {
(clk0 - 10.0) >= 0.0
(clk2 - 20.0) >= 0.0
}
reset {
clk0' := 10.0
clk3' := 0.0
y' := y
clk1' := 0.0
clk2' := 20.0
x' := x
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_5 -> mode_2
guard {
(clk3 - 20.0) >= 0.0
(clk2 - 28.0) <= 0.0
(clk2 - 20.0) >= 0.0
(clk0 - 10.0) >= 0.0
(clk1 - 20.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
clk3' := 0.0
y' := y
x' := x
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_1 -> mode_5
guard {
(clk0 - 10.0) >= 0.0
(clk2 - 28.0) <= 0.0
(clk1 - 20.0) <= 0.0
}
reset {
clk0' := 10.0
clk2' := clk2
clk3' := 0.0
y' := y
clk1' := clk1
x' := x
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_8 -> mode_5
guard {
(clk0 - 10.0) >= 0.0
(clk2 - 28.0) <= 0.0
}
reset {
clk0' := 10.0
clk2' := clk2
y' := y
clk3' := 0.0
clk1' := 0.0
x' := x
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_5 -> mode_3
guard {
(clk3 - 20.0) >= 0.0
(clk2 - 28.0) <= 0.0
(clk2 - 20.0) >= 0.0
(clk0 - 10.0) >= 0.0
(clk1 - 20.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
clk3' := 0.0
y' := y
x' := x
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_4 -> mode_3
guard {
(clk0 - 10.0) >= 0.0
(clk2 - 20.0) >= 0.0
(clk1 - 20.0) >= 0.0
}
reset {
clk0' := clk0
clk3' := 0.0
y' := y
clk2' := 20.0
x' := x
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_3 -> mode_2
guard {
(clk2 - 28.0) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_6 -> mode_7
guard {
(clk0 - 10.0) >= 0.0
(clk2 - 20.0) >= 0.0
(clk1 - 20.0) <= 0.0
(clk3 - 20.0) <= 0.0
}
reset {
clk0' := 10.0
y' := y
clk1' := clk1
clk3' := clk3
clk2' := 20.0
x' := x
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_5 -> mode_6
guard {
(clk0 - 10.0) >= 0.0
(clk2 - 28.0) <= 0.0
(clk1 - 20.0) <= 0.0
}
reset {
clk0' := 10.0
clk2' := clk2
clk3' := 0.0
y' := y
clk1' := clk1
x' := x
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_6 -> mode_3
guard {
(clk2 - 20.0) >= 0.0
}
reset {
clk0' := clk0
clk3' := 0.0
y' := y
clk2' := 20.0
x' := x
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_1 -> mode_2
guard {
(clk0 - 10.0) >= 0.0
(clk2 - 28.0) <= 0.0
(clk1 - 20.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
clk3' := 0.0
y' := y
x' := x
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_7 -> mode_6
guard {
(clk0 - 10.0) >= 0.0
(clk2 - 28.0) <= 0.0
(clk1 - 20.0) <= 0.0
}
reset {
clk0' := 10.0
clk2' := clk2
y' := y
clk1' := clk1
clk3' := clk3
x' := x
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_5 -> mode_3
guard {
(clk0 - 10.0) >= 0.0
(clk2 - 20.0) >= 0.0
(clk3 - 20.0) >= 0.0
(clk1 - 20.0) >= 0.0
}
reset {
clk0' := clk0
clk3' := 0.0
y' := y
clk2' := 20.0
x' := x
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_6 -> mode_5
guard {
(clk0 - 10.0) >= 0.0
(clk2 - 28.0) <= 0.0
(clk1 - 20.0) <= 0.0
}
reset {
clk0' := 10.0
clk2' := clk2
y' := y
clk1' := clk1
clk3' := clk3
x' := x
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_8 -> mode_7
guard {
(clk0 - 10.0) >= 0.0
(clk2 - 28.0) <= 0.0
}
reset {
clk0' := 10.0
clk2' := clk2
y' := y
clk3' := 0.0
clk1' := 0.0
x' := x
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_9 -> mode_11
guard {
(gClk - 50.0) >= 0.0
(clk0 - 10.0) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_6 -> mode_2
guard {
(clk2 - 20.0) >= 0.0
}
reset {
clk0' := clk0
clk3' := 0.0
y' := y
clk2' := 20.0
x' := x
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_1 -> mode_7
guard {
(clk0 - 10.0) >= 0.0
(clk2 - 28.0) <= 0.0
(clk1 - 20.0) <= 0.0
}
reset {
clk0' := 10.0
clk2' := clk2
clk3' := 0.0
y' := y
clk1' := clk1
x' := x
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_5 -> mode_7
guard {
(clk0 - 10.0) >= 0.0
(clk2 - 20.0) >= 0.0
(clk1 - 20.0) <= 0.0
}
reset {
clk0' := 10.0
clk3' := 0.0
y' := y
clk1' := clk1
clk2' := 20.0
x' := x
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_7 -> mode_2
guard {
(clk2 - 28.0) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_10 -> mode_11
guard {
(gClk - 50.0) >= 0.0
(clk0 - 10.0) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_5 -> mode_6
guard {
(clk0 - 10.0) >= 0.0
(clk2 - 20.0) >= 0.0
(clk1 - 20.0) <= 0.0
}
reset {
clk0' := 10.0
clk3' := 0.0
y' := y
clk1' := clk1
clk2' := 20.0
x' := x
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_6 -> mode_7
guard {
(clk0 - 10.0) >= 0.0
(clk2 - 20.0) >= 0.0
(clk1 - 20.0) <= 0.0
}
reset {
clk0' := 10.0
clk3' := 0.0
y' := y
clk1' := clk1
clk2' := 20.0
x' := x
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_12 -> mode_8
guard {
}
reset {
y' := y
clk3' := clk3
clk0' := 0.0
clk2' := 0.0
x' := x
gClk' := 0.0
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_8 -> mode_6
guard {
(clk0 - 10.0) >= 0.0
(clk2 - 28.0) <= 0.0
}
reset {
clk0' := 10.0
clk2' := clk2
y' := y
clk3' := 0.0
clk1' := 0.0
x' := x
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_12 -> mode_0
guard {
}
reset {
y' := y
clk3' := clk3
clk0' := 0.0
clk2' := 0.0
x' := x
gClk' := 0.0
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_7 -> mode_3
guard {
(clk2 - 28.0) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_6 -> mode_2
guard {
(clk2 - 28.0) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_9 -> mode_1
guard {
(clk0 - 10.0) <= 0.0
}
reset {
clk0' := clk0
y' := y
clk1' := 0.0
clk3' := clk3
clk2' := 0.0
x' := x
gClk' := gClk
clk4' := clk4
}
parallelotope aggregation { }

mode_4 -> mode_2
guard {
(clk0 - 10.0) >= 0.0
(clk2 - 20.0) >= 0.0
(clk1 - 20.0) >= 0.0
}
reset {
clk0' := clk0
clk3' := 0.0
y' := y
clk2' := 20.0
x' := x
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }
 
 }

 init {
 mode_12 {clk4 in [0.0, 0.0]
x in [-0.5, -0.4]
ff in [1.0, 1.0]
clk0 in [0.0, 0.0]
gClk in [0.0, 0.0]
y in [-0.5, -0.4]
clk2 in [0.0, 0.0]
clk1 in [0.0, 0.0]
clk3 in [0.0, 0.0]
}

}

}
 unsafe {
 mode_0{ ff >= 10 }
mode_1{ ff >= 10 }
mode_2{ ff >= 10 }
mode_3{ ff >= 10 }
mode_4{ ff >= 10 }
mode_5{ ff >= 10 }
mode_6{ ff >= 10 }
mode_7{ ff >= 10 }
mode_8{ ff >= 10 }
mode_9{ ff >= 10 }
mode_10{ ff >= 10 }
mode_11{}
mode_12{ ff >= 10 }
 
 }
