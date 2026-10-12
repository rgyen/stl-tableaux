hybrid reachability {
 state var x, ff, clk0, gClk, clk2, clk1
 setting {
 adaptive steps {min 0.001, max 0.5}
time 4
remainder estimation 1e-8
identity precondition 
gnuplot octagon x,x fixed orders 6
cutoff 1e-13
precision 53
no output 
max jumps 1000
print on  
}

 modes {
 mode_0{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
clk2' = 1.0
x' = ((-0.01 * 4.43) * (sqrt (x)))
ff' = 0.0
}
inv {
(x - 1) >= 0.0
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(x - (5.0 + 0.5)) <= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_1{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
clk2' = 1.0
x' = ((-0.01 * 4.43) * (sqrt (x)))
ff' = 0.0
}
inv {
(x - 1) >= 0.0
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(x - (5.0 + 0.5)) <= 0.0
(x - (2.0 + 0.5)) <= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_2{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
clk2' = 1.0
x' = (0.8 - ((0.01 * 4.43) * (sqrt (x))))
ff' = 0.0
}
inv {
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(x - (5.0 + 0.5)) <= 0.0
(x - (2.0 + 0.5)) <= 0.0
(x - 8) <= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_3{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
clk2' = 1.0
x' = (0.8 - ((0.01 * 4.43) * (sqrt (x))))
ff' = 0.0
}
inv {
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(x - (5.0 + 0.5)) <= 0.0
(x - 8) <= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_4{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
clk2' = 1.0
x' = ((-0.01 * 4.43) * (sqrt (x)))
ff' = 0.0
}
inv {
(x - 1) >= 0.0
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(x - (5.0 + 0.5)) <= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_5{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
clk2' = 1.0
x' = ((-0.01 * 4.43) * (sqrt (x)))
ff' = 0.0
}
inv {
(x - 1) >= 0.0
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(x - (5.0 + 0.5)) <= 0.0
(x - (2.0 + 0.5)) <= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_6{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
clk2' = 1.0
x' = ((-0.01 * 4.43) * (sqrt (x)))
ff' = 0.0
}
inv {
(x - 1) >= 0.0
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(x - (5.0 + 0.5)) <= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_7{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
clk2' = 1.0
x' = (0.8 - ((0.01 * 4.43) * (sqrt (x))))
ff' = 0.0
}
inv {
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(x - 8) <= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_8{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
clk2' = 1.0
x' = (0.8 - ((0.01 * 4.43) * (sqrt (x))))
ff' = 0.0
}
inv {
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(x - (5.0 + 0.5)) <= 0.0
(x - 8) <= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_9{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
clk2' = 1.0
x' = (0.8 - ((0.01 * 4.43) * (sqrt (x))))
ff' = 0.0
}
inv {
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(x - (5.0 + 0.5)) <= 0.0
(x - 8) <= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_10{
nonpoly ode
{x' = 0.0
clk0' = 0.0
gClk' = 1.0
clk2' = 0.0
clk1' = 0.0
ff' = 0.0
}
inv {
(gClk - 0.0) >= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_11{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
clk2' = 1.0
x' = ((-0.01 * 4.43) * (sqrt (x)))
ff' = 0.0
}
inv {
(x - 1) >= 0.0
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_12{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
clk2' = 1.0
x' = ((-0.01 * 4.43) * (sqrt (x)))
ff' = 0.0
}
inv {
(x - 1) >= 0.0
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_13{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
clk2' = 1.0
x' = (0.8 - ((0.01 * 4.43) * (sqrt (x))))
ff' = 0.0
}
inv {
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(x - 8) <= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_14{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
clk2' = 1.0
x' = (0.8 - ((0.01 * 4.43) * (sqrt (x))))
ff' = 0.0
}
inv {
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(x - (5.0 + 0.5)) <= 0.0
(x - (2.0 + 0.5)) <= 0.0
(x - 8) <= 0.0
(gClk - 8.0) <= 0.0
}
}
}

 jumps {
 mode_3 -> mode_13
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 4.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_6 -> mode_12
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 4.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_14 -> mode_13
guard {
(clk0 - 0.0) >= 0.0
(gClk - 8.0) >= 0.0
(clk2 - 0.0) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_5 -> mode_6
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk2' := clk2
clk1' := 0.0
clk0' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_4 -> mode_9
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
clk1' := 0.0
clk0' := 0.0
clk2' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_6 -> mode_12
guard {
(clk0 - 0.0) >= 0.0
(gClk - 8.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_0 -> mode_9
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_8 -> mode_7
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk1' := 0.0
clk0' := 0.0
clk2' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_2 -> mode_5
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_14 -> mode_13
guard {
(clk0 - 0.0) >= 0.0
(gClk - 8.0) >= 0.0
(clk2 - 0.0) <= 0.0
(clk1 - 4.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_4 -> mode_0
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk1' := 0.0
clk0' := 0.0
clk2' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_2 -> mode_6
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
clk2' := clk2
clk1' := 0.0
clk0' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_4 -> mode_11
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk1' := 0.0
clk0' := 0.0
clk2' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_1 -> mode_14
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_14 -> mode_13
guard {
(clk0 - 0.0) >= 0.0
(gClk - 8.0) >= 0.0
(clk2 - 0.0) >= 0.0
(clk1 - 4.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_1 -> mode_12
guard {
(clk0 - 0.0) >= 0.0
(gClk - 8.0) >= 0.0
(clk2 - 0.0) >= 0.0
(clk1 - 4.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_14 -> mode_12
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(gClk - 8.0) >= 0.0
(clk2 - 0.0) <= 0.0
(x - 2) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_5 -> mode_12
guard {
(clk0 - 0.0) >= 0.0
(gClk - 8.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_1 -> mode_13
guard {
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 8.0) >= 0.0
(clk0 - 0.0) <= 0.0
(clk2 - 0.0) >= 0.0
(x - 5) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_14 -> mode_12
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(gClk - 8.0) >= 0.0
(x - 2) >= 0.0
(clk2 - 0.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_8 -> mode_11
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
clk1' := 0.0
clk0' := 0.0
clk2' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_1 -> mode_13
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(gClk - 8.0) >= 0.0
(clk2 - 0.0) <= 0.0
(x - 5) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_13 -> mode_12
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_1 -> mode_13
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(clk1 - 4.0) >= 0.0
(gClk - 8.0) >= 0.0
(clk2 - 0.0) <= 0.0
(x - 5) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_14 -> mode_12
guard {
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 8.0) >= 0.0
(x - 2) >= 0.0
(clk0 - 0.0) <= 0.0
(clk2 - 0.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_5 -> mode_13
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(gClk - 8.0) >= 0.0
(x - 5) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_1 -> mode_12
guard {
(clk0 - 0.0) >= 0.0
(gClk - 8.0) >= 0.0
(clk2 - 0.0) <= 0.0
(clk1 - 4.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_1 -> mode_13
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(clk1 - 4.0) >= 0.0
(gClk - 8.0) >= 0.0
(clk2 - 0.0) >= 0.0
(x - 5) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_8 -> mode_0
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
clk1' := 0.0
clk0' := 0.0
clk2' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_7 -> mode_11
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_8 -> mode_1
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
clk1' := 0.0
clk0' := 0.0
clk2' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_14 -> mode_12
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(clk1 - 4.0) >= 0.0
(gClk - 8.0) >= 0.0
(x - 2) >= 0.0
(clk2 - 0.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_1 -> mode_13
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(gClk - 8.0) >= 0.0
(clk2 - 0.0) >= 0.0
(x - 5) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_10 -> mode_5
guard {
}
reset {
clk2' := clk2
clk0' := 0.0
x' := x
gClk' := 0.0
clk1' := clk1
}
parallelotope aggregation { }

mode_6 -> mode_13
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(clk1 - 4.0) >= 0.0
(x - 5) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_1 -> mode_12
guard {
(clk0 - 0.0) <= 0.0
(clk2 - 0.0) >= 0.0
(gClk - 8.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_2 -> mode_3
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk2' := clk2
clk1' := 0.0
clk0' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_3 -> mode_12
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(gClk - 8.0) >= 0.0
(x - 2) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_6 -> mode_3
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_6 -> mode_13
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(gClk - 8.0) >= 0.0
(x - 5) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_5 -> mode_2
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_4 -> mode_1
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk1' := 0.0
clk0' := 0.0
clk2' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_4 -> mode_7
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
clk1' := 0.0
clk0' := 0.0
clk2' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_3 -> mode_6
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_1 -> mode_12
guard {
(clk0 - 0.0) >= 0.0
(gClk - 8.0) >= 0.0
(clk2 - 0.0) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_8 -> mode_14
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk1' := 0.0
clk0' := 0.0
clk2' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_4 -> mode_8
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_14 -> mode_12
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(clk1 - 4.0) >= 0.0
(gClk - 8.0) >= 0.0
(clk2 - 0.0) <= 0.0
(x - 2) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_3 -> mode_12
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(clk1 - 4.0) >= 0.0
(x - 2) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_8 -> mode_9
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk1' := 0.0
clk0' := 0.0
clk2' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_10 -> mode_4
guard {
}
reset {
clk2' := clk2
clk0' := 0.0
x' := x
gClk' := 0.0
clk1' := clk1
}
parallelotope aggregation { }

mode_9 -> mode_0
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_8 -> mode_4
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_1 -> mode_12
guard {
(clk0 - 0.0) >= 0.0
(gClk - 8.0) >= 0.0
(clk2 - 0.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_2 -> mode_12
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(gClk - 8.0) >= 0.0
(x - 2) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_4 -> mode_14
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
clk1' := 0.0
clk0' := 0.0
clk2' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_3 -> mode_13
guard {
(clk0 - 0.0) >= 0.0
(gClk - 8.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_14 -> mode_1
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_11 -> mode_7
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_2 -> mode_13
guard {
(clk0 - 0.0) >= 0.0
(gClk - 8.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_5 -> mode_3
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
clk2' := clk2
clk1' := 0.0
clk0' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_12 -> mode_13
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_14 -> mode_13
guard {
(clk0 - 0.0) >= 0.0
(gClk - 8.0) >= 0.0
(clk2 - 0.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_14 -> mode_13
guard {
(clk0 - 0.0) <= 0.0
(clk2 - 0.0) >= 0.0
(gClk - 8.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }
 
 }

 init {
 mode_10 {x in [4, 4.5]
ff in [1.0, 1.0]
clk0 in [0.0, 0.0]
gClk in [0.0, 0.0]
clk2 in [0.0, 0.0]
clk1 in [0.0, 0.0]
}

}

}
 unsafe {
 mode_0{}
mode_1{ ff >= 10 }
mode_2{ ff >= 10 }
mode_3{ ff >= 10 }
mode_4{ ff >= 10 }
mode_5{ ff >= 10 }
mode_6{ ff >= 10 }
mode_7{}
mode_8{ ff >= 10 }
mode_9{}
mode_10{ ff >= 10 }
mode_11{}
mode_12{}
mode_13{}
mode_14{ ff >= 10 }
 
 }
