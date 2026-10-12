hybrid reachability {
 state var x, ff, clk0, gClk, y, clk2, clk1, clk3
 setting {
 adaptive steps {min 0.001, max 0.5}
time 30
remainder estimation 1e-8
identity precondition 
gnuplot octagon x,x fixed orders 8
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
gClk' = 1.0
x' = (0.1 * y)
y' = ((((0.2 * x) - (((0.1 * x) * x) * x)) - (0.02 * y)) + 0.01)
ff' = 0.0
}
inv {
(x - 1000) <= 0.0
(gClk - 50.0) <= 0.0
(-1000 - y) <= 0.0
(y - (100.0 + 0.5)) <= 0.0
(-1000 - x) <= 0.0
(gClk - 0.0) >= 0.0
(y - 1000) <= 0.0
(x - (40.0 - 0.5)) >= 0.0
}
}
mode_1{
poly ode 2
{clk1' = 1.0
clk0' = 1.0
clk3' = 1.0
clk2' = 1.0
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
(x - (40.0 - 0.5)) >= 0.0
}
}
mode_2{
poly ode 2
{clk1' = 1.0
clk0' = 1.0
clk3' = 1.0
clk2' = 1.0
gClk' = 1.0
x' = (0.1 * y)
y' = ((((0.2 * x) - (((0.1 * x) * x) * x)) - (0.02 * y)) + 0.01)
ff' = 0.0
}
inv {
(x - 1000) <= 0.0
(gClk - 50.0) <= 0.0
(-1000 - y) <= 0.0
(y - (100.0 + 0.5)) <= 0.0
(-1000 - x) <= 0.0
(gClk - 0.0) >= 0.0
(y - 1000) <= 0.0
(x - (40.0 - 0.5)) >= 0.0
}
}
mode_3{
poly ode 2
{y' = 0.0
x' = 0.0
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
mode_4{
poly ode 2
{clk1' = 1.0
clk0' = 1.0
clk3' = 1.0
clk2' = 1.0
gClk' = 1.0
x' = (0.1 * y)
y' = ((((0.2 * x) - (((0.1 * x) * x) * x)) - (0.02 * y)) + 0.01)
ff' = 0.0
}
inv {
(x - 1000) <= 0.0
(gClk - 50.0) <= 0.0
(-1000 - y) <= 0.0
(y - (100.0 + 0.5)) <= 0.0
(-1000 - x) <= 0.0
(gClk - 0.0) >= 0.0
(y - 1000) <= 0.0
}
}
mode_5{
poly ode 2
{clk1' = 1.0
clk0' = 1.0
clk3' = 1.0
clk2' = 1.0
gClk' = 1.0
x' = (0.1 * y)
y' = ((((0.2 * x) - (((0.1 * x) * x) * x)) - (0.02 * y)) + 0.01)
ff' = 0.0
}
inv {
(x - 1000) <= 0.0
(gClk - 50.0) <= 0.0
(-1000 - y) <= 0.0
(y - (100.0 + 0.5)) <= 0.0
(-1000 - x) <= 0.0
(gClk - 0.0) >= 0.0
(y - 1000) <= 0.0
}
}
mode_6{
poly ode 2
{clk1' = 1.0
clk0' = 1.0
clk3' = 1.0
clk2' = 1.0
gClk' = 1.0
x' = (0.1 * y)
y' = ((((0.2 * x) - (((0.1 * x) * x) * x)) - (0.02 * y)) + 0.01)
ff' = 0.0
}
inv {
(x - 1000) <= 0.0
(gClk - 50.0) <= 0.0
(-1000 - y) <= 0.0
(y - (100.0 + 0.5)) <= 0.0
(-1000 - x) <= 0.0
(gClk - 0.0) >= 0.0
(y - 1000) <= 0.0
(x - (40.0 - 0.5)) >= 0.0
}
}
mode_7{
poly ode 2
{clk1' = 1.0
clk0' = 1.0
clk3' = 1.0
clk2' = 1.0
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
gClk' = 1.0
x' = (0.1 * y)
y' = ((((0.2 * x) - (((0.1 * x) * x) * x)) - (0.02 * y)) + 0.01)
ff' = 0.0
}
inv {
(x - 1000) <= 0.0
(gClk - 50.0) <= 0.0
(-1000 - y) <= 0.0
(y - (100.0 + 0.5)) <= 0.0
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
gClk' = 1.0
x' = (0.1 * y)
y' = ((((0.2 * x) - (((0.1 * x) * x) * x)) - (0.02 * y)) + 0.01)
ff' = 0.0
}
inv {
(x - 1000) <= 0.0
(gClk - 50.0) <= 0.0
(-1000 - y) <= 0.0
(y - (100.0 + 0.5)) <= 0.0
(-1000 - x) <= 0.0
(gClk - 0.0) >= 0.0
(y - 1000) <= 0.0
(x - (40.0 - 0.5)) >= 0.0
}
}
mode_10{
poly ode 2
{clk1' = 1.0
clk0' = 1.0
clk3' = 1.0
clk2' = 1.0
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
gClk' = 1.0
x' = (0.1 * y)
y' = ((((0.2 * x) - (((0.1 * x) * x) * x)) - (0.02 * y)) + 0.01)
ff' = 0.0
}
inv {
(x - 1000) <= 0.0
(gClk - 50.0) <= 0.0
(-1000 - y) <= 0.0
(y - (100.0 + 0.5)) <= 0.0
(-1000 - x) <= 0.0
(gClk - 0.0) >= 0.0
(y - 1000) <= 0.0
}
}
}

 jumps {
 mode_0 -> mode_7
guard {
(clk3 - 6.0) >= 0.0
(clk1 - 6.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_9 -> mode_8
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 6.0) >= 0.0
}
reset {
clk3' := 0.0
y' := y
clk0' := 0.0
clk2' := 0.0
x' := x
clk1' := 6.0
gClk' := gClk
}
parallelotope aggregation { }

mode_2 -> mode_0
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 30.0) <= 0.0
(clk2 - 6.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_0 -> mode_10
guard {
(clk3 - 6.0) <= 0.0
(clk1 - 6.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
clk1' := 6.0
gClk' := gClk
}
parallelotope aggregation { }

mode_1 -> mode_10
guard {
(clk3 - 6.0) <= 0.0
(clk1 - 6.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
clk1' := 6.0
gClk' := gClk
}
parallelotope aggregation { }

mode_2 -> mode_6
guard {
(clk0 - 0.0) >= 0.0
(gClk - 50.0) >= 0.0
(clk3 - 6.0) >= 0.0
(clk1 - 6.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_2 -> mode_1
guard {
(clk0 - 0.0) >= 0.0
(clk2 - 6.0) >= 0.0
(clk3 - 6.0) <= 0.0
(clk1 - 6.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
clk1' := 6.0
gClk' := gClk
}
parallelotope aggregation { }

mode_0 -> mode_1
guard {
(clk1 - 30.0) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_2 -> mode_7
guard {
(clk0 - 0.0) <= 0.0
(gClk - 50.0) >= 0.0
(clk3 - 6.0) >= 0.0
(clk1 - 6.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_2 -> mode_10
guard {
(clk0 - 0.0) >= 0.0
(clk2 - 6.0) >= 0.0
(clk3 - 6.0) <= 0.0
(clk1 - 6.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
clk1' := 6.0
gClk' := gClk
}
parallelotope aggregation { }

mode_3 -> mode_9
guard {
}
reset {
clk2' := clk2
y' := y
clk1' := 0.0
clk3' := clk3
clk0' := 0.0
x' := x
gClk' := 0.0
}
parallelotope aggregation { }

mode_2 -> mode_7
guard {
(clk0 - 0.0) >= 0.0
(gClk - 50.0) >= 0.0
(clk3 - 6.0) >= 0.0
(clk1 - 6.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_2 -> mode_6
guard {
(clk0 - 0.0) >= 0.0
(clk2 - 6.0) >= 0.0
(clk3 - 6.0) >= 0.0
(clk1 - 6.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_9 -> mode_2
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 6.0) >= 0.0
}
reset {
clk3' := 0.0
y' := y
clk0' := 0.0
clk2' := 0.0
x' := x
clk1' := 6.0
gClk' := gClk
}
parallelotope aggregation { }

mode_4 -> mode_8
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 30.0) <= 0.0
}
reset {
clk3' := 0.0
y' := y
clk0' := 0.0
clk2' := 0.0
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_0 -> mode_10
guard {
(clk1 - 30.0) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_8 -> mode_11
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 30.0) <= 0.0
(clk2 - 6.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_2 -> mode_5
guard {
(clk0 - 0.0) >= 0.0
(gClk - 50.0) >= 0.0
(clk3 - 6.0) >= 0.0
(clk1 - 6.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_4 -> mode_2
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 30.0) <= 0.0
}
reset {
clk3' := 0.0
y' := y
clk0' := 0.0
clk2' := 0.0
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_1 -> mode_7
guard {
(clk3 - 6.0) >= 0.0
(clk1 - 6.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_2 -> mode_11
guard {
(clk0 - 0.0) >= 0.0
(clk2 - 6.0) >= 0.0
(clk3 - 6.0) <= 0.0
(clk1 - 6.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
clk1' := 6.0
gClk' := gClk
}
parallelotope aggregation { }

mode_0 -> mode_1
guard {
(clk3 - 6.0) <= 0.0
(clk1 - 6.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
clk1' := 6.0
gClk' := gClk
}
parallelotope aggregation { }

mode_8 -> mode_0
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 30.0) <= 0.0
(clk2 - 6.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_2 -> mode_6
guard {
(clk0 - 0.0) <= 0.0
(gClk - 50.0) >= 0.0
(clk3 - 6.0) >= 0.0
(clk1 - 6.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_9 -> mode_8
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 30.0) <= 0.0
}
reset {
clk3' := 0.0
y' := y
clk0' := 0.0
clk2' := 0.0
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_0 -> mode_5
guard {
(clk3 - 6.0) >= 0.0
(clk1 - 6.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_0 -> mode_6
guard {
(clk3 - 6.0) >= 0.0
(clk1 - 6.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_3 -> mode_4
guard {
}
reset {
clk2' := clk2
y' := y
clk1' := 0.0
clk3' := clk3
clk0' := 0.0
x' := x
gClk' := 0.0
}
parallelotope aggregation { }

mode_2 -> mode_1
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 30.0) <= 0.0
(clk2 - 6.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_10 -> mode_1
guard {
(clk1 - 30.0) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_2 -> mode_5
guard {
(clk0 - 0.0) >= 0.0
(clk2 - 6.0) >= 0.0
(clk3 - 6.0) >= 0.0
(clk1 - 6.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_2 -> mode_0
guard {
(clk0 - 0.0) >= 0.0
(clk2 - 6.0) >= 0.0
(clk3 - 6.0) <= 0.0
(clk1 - 6.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
clk1' := 6.0
gClk' := gClk
}
parallelotope aggregation { }

mode_2 -> mode_7
guard {
(clk0 - 0.0) >= 0.0
(clk2 - 6.0) >= 0.0
(clk3 - 6.0) >= 0.0
(clk1 - 6.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_2 -> mode_5
guard {
(clk0 - 0.0) <= 0.0
(gClk - 50.0) >= 0.0
(clk3 - 6.0) >= 0.0
(clk1 - 6.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_11 -> mode_0
guard {
(clk1 - 30.0) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_9 -> mode_2
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 30.0) <= 0.0
}
reset {
clk3' := 0.0
y' := y
clk0' := 0.0
clk2' := 0.0
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_0 -> mode_11
guard {
(clk3 - 6.0) <= 0.0
(clk1 - 6.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
clk1' := 6.0
gClk' := gClk
}
parallelotope aggregation { }

mode_2 -> mode_10
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 30.0) <= 0.0
(clk2 - 6.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_2 -> mode_11
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 30.0) <= 0.0
(clk2 - 6.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_5 -> mode_6
guard {
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_6 -> mode_7
guard {
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
clk3' := clk3
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }
 
 }

 init {
 mode_3 {x in [-0.5, -0.4]
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
mode_7{}
mode_8{ ff >= 10 }
mode_9{ ff >= 10 }
mode_10{ ff >= 10 }
mode_11{ ff >= 10 }
 
 }
