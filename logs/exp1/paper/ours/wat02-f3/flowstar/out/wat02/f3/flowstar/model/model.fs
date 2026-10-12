hybrid reachability {
 state var ff, clk0, gClk, x, clk1
 setting {
 adaptive steps {min 0.001, max 0.5}
time 4
remainder estimation 1e-8
identity precondition 
gnuplot octagon ff,ff fixed orders 6
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
mode_1{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
x' = (0.8 - ((0.01 * 4.43) * (sqrt (x))))
ff' = 0.0
}
inv {
(x - (5 + 2.0)) <= 0.0
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(x - 8) <= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_2{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
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
mode_3{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
x' = ((-0.01 * 4.43) * (sqrt (x)))
ff' = 0.0
}
inv {
(x - 1) >= 0.0
(x - (5 + 2.0)) <= 0.0
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_4{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
x' = ((-0.01 * 4.43) * (sqrt (x)))
ff' = 0.0
}
inv {
(x - 1) >= 0.0
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(x - (6 - 2.0)) >= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_5{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
x' = (0.8 - ((0.01 * 4.43) * (sqrt (x))))
ff' = 0.0
}
inv {
(x - (5 + 2.0)) <= 0.0
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(x - 8) <= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_6{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
x' = ((-0.01 * 4.43) * (sqrt (x)))
ff' = 0.0
}
inv {
(x - 1) >= 0.0
(x - (5 + 2.0)) <= 0.0
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_7{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
x' = ((-0.01 * 4.43) * (sqrt (x)))
ff' = 0.0
}
inv {
(x - 1) >= 0.0
(0 - x) <= 0.0
(x - (5 + 2.0)) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(x - (6 - 2.0)) >= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_8{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
x' = ((-0.01 * 4.43) * (sqrt (x)))
ff' = 0.0
}
inv {
(x - 1) >= 0.0
(0 - x) <= 0.0
(x - (5 + 2.0)) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(x - (6 - 2.0)) >= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_9{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
x' = (0.8 - ((0.01 * 4.43) * (sqrt (x))))
ff' = 0.0
}
inv {
(x - (5 + 2.0)) <= 0.0
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(x - 8) <= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_10{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
x' = (0.8 - ((0.01 * 4.43) * (sqrt (x))))
ff' = 0.0
}
inv {
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(x - (6 - 2.0)) >= 0.0
(x - 8) <= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_11{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
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
x' = ((-0.01 * 4.43) * (sqrt (x)))
ff' = 0.0
}
inv {
(x - 1) >= 0.0
(x - (5 + 2.0)) <= 0.0
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
mode_14{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
x' = (0.8 - ((0.01 * 4.43) * (sqrt (x))))
ff' = 0.0
}
inv {
(x - (5 + 2.0)) <= 0.0
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(x - 8) <= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_15{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
x' = ((-0.01 * 4.43) * (sqrt (x)))
ff' = 0.0
}
inv {
(x - 1) >= 0.0
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(x - (6 - 2.0)) >= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_16{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
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
mode_17{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
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
mode_18{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
x' = ((-0.01 * 4.43) * (sqrt (x)))
ff' = 0.0
}
inv {
(x - 1) >= 0.0
(x - (5 + 2.0)) <= 0.0
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_19{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
x' = ((-0.01 * 4.43) * (sqrt (x)))
ff' = 0.0
}
inv {
(x - 1) >= 0.0
(x - (5 + 2.0)) <= 0.0
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_20{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
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
mode_21{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
x' = (0.8 - ((0.01 * 4.43) * (sqrt (x))))
ff' = 0.0
}
inv {
(x - (5 + 2.0)) <= 0.0
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(x - 8) <= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_22{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
x' = (0.8 - ((0.01 * 4.43) * (sqrt (x))))
ff' = 0.0
}
inv {
(0 - x) <= 0.0
(x - (5 + 2.0)) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(x - (6 - 2.0)) >= 0.0
(x - 8) <= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_23{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
x' = (0.8 - ((0.01 * 4.43) * (sqrt (x))))
ff' = 0.0
}
inv {
(x - (5 + 2.0)) <= 0.0
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(x - 8) <= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_24{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
x' = (0.8 - ((0.01 * 4.43) * (sqrt (x))))
ff' = 0.0
}
inv {
(x - (5 + 2.0)) <= 0.0
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(x - 8) <= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_25{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
x' = ((-0.01 * 4.43) * (sqrt (x)))
ff' = 0.0
}
inv {
(x - 1) >= 0.0
(x - (5 + 2.0)) <= 0.0
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_26{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
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
mode_27{
nonpoly ode
{x' = 0.0
clk0' = 0.0
gClk' = 1.0
clk1' = 0.0
ff' = 0.0
}
inv {
(gClk - 0.0) >= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_28{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
x' = (0.8 - ((0.01 * 4.43) * (sqrt (x))))
ff' = 0.0
}
inv {
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(x - (6 - 2.0)) >= 0.0
(x - 8) <= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_29{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
x' = ((-0.01 * 4.43) * (sqrt (x)))
ff' = 0.0
}
inv {
(x - 1) >= 0.0
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(x - (6 - 2.0)) >= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_30{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
x' = ((-0.01 * 4.43) * (sqrt (x)))
ff' = 0.0
}
inv {
(x - 1) >= 0.0
(x - (5 + 2.0)) <= 0.0
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_31{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
x' = (0.8 - ((0.01 * 4.43) * (sqrt (x))))
ff' = 0.0
}
inv {
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(x - (6 - 2.0)) >= 0.0
(x - 8) <= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_32{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
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
mode_33{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
x' = (0.8 - ((0.01 * 4.43) * (sqrt (x))))
ff' = 0.0
}
inv {
(0 - x) <= 0.0
(x - (5 + 2.0)) <= 0.0
(x - 10) <= 0.0
(gClk - 0.0) >= 0.0
(x - (6 - 2.0)) >= 0.0
(x - 8) <= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_34{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
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
mode_35{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
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
mode_36{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
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
}

 jumps {
 mode_14 -> mode_16
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_19 -> mode_17
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_19 -> mode_23
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_14 -> mode_32
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_14 -> mode_17
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_14 -> mode_34
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_1 -> mode_31
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_14 -> mode_23
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_19 -> mode_31
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_14 -> mode_19
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_11 -> mode_16
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_14 -> mode_36
guard {
(gClk - 8.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_1 -> mode_7
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_14 -> mode_35
guard {
(gClk - 8.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_30 -> mode_7
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_14 -> mode_31
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_19 -> mode_36
guard {
(gClk - 8.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_14 -> mode_15
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_19 -> mode_35
guard {
(gClk - 8.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_11 -> mode_4
guard {
(clk0 - 1.2) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_19 -> mode_34
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_11 -> mode_16
guard {
(clk0 - 1.2) <= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_23 -> mode_31
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_11 -> mode_32
guard {
(clk0 - 1.2) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_17 -> mode_31
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_30 -> mode_17
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_1 -> mode_34
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_1 -> mode_17
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_15 -> mode_35
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_17 -> mode_15
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_23 -> mode_15
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_16 -> mode_32
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_1 -> mode_15
guard {
(gClk - 8.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_34 -> mode_15
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_34 -> mode_17
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_34 -> mode_31
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_1 -> mode_15
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_1 -> mode_34
guard {
(gClk - 8.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_11 -> mode_10
guard {
(clk0 - 1.2) <= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_17 -> mode_34
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_1 -> mode_30
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_1 -> mode_17
guard {
(gClk - 8.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_31 -> mode_15
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_15 -> mode_36
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_30 -> mode_1
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_31 -> mode_35
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_19 -> mode_15
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_1 -> mode_31
guard {
(gClk - 8.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_15 -> mode_31
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_11 -> mode_32
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_1 -> mode_33
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_30 -> mode_33
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_31 -> mode_36
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_30 -> mode_34
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_5 -> mode_34
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_21 -> mode_17
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_21 -> mode_15
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(gClk - 8.0) >= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_25 -> mode_34
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_0 -> mode_35
guard {
(clk0 - 1.2) <= 0.0
(gClk - 8.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_30 -> mode_17
guard {
(gClk - 8.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_30 -> mode_34
guard {
(gClk - 8.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_0 -> mode_36
guard {
(clk0 - 1.2) <= 0.0
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 8.0) >= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_21 -> mode_34
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(gClk - 8.0) >= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_25 -> mode_36
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(gClk - 8.0) >= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_16 -> mode_31
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_30 -> mode_31
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_21 -> mode_17
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(gClk - 8.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_24 -> mode_35
guard {
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 8.0) >= 0.0
(clk0 - 1.2) >= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_26 -> mode_9
guard {
(clk0 - 1.2) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_16 -> mode_34
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_26 -> mode_12
guard {
(clk0 - 1.2) <= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_6 -> mode_9
guard {
(x - 10) <= 0.0
(x - 5) <= 0.0
(0 - x) <= 0.0
(clk0 - 1.2) >= 0.0
}
reset {
gClk' := gClk
clk0' := 1.2
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_24 -> mode_6
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_25 -> mode_17
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_21 -> mode_31
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(gClk - 8.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_26 -> mode_0
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_32 -> mode_16
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_26 -> mode_36
guard {
(clk0 - 1.2) <= 0.0
(gClk - 8.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_5 -> mode_17
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_26 -> mode_35
guard {
(clk0 - 1.2) <= 0.0
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 8.0) >= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_6 -> mode_36
guard {
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 8.0) >= 0.0
(clk0 - 1.2) >= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_29 -> mode_32
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_6 -> mode_12
guard {
(clk0 - 1.2) >= 0.0
}
reset {
x' := x
clk0' := 1.2
clk1' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_29 -> mode_16
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_30 -> mode_31
guard {
(gClk - 8.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_29 -> mode_35
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_6 -> mode_35
guard {
(gClk - 8.0) >= 0.0
(clk0 - 1.2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_16 -> mode_15
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_29 -> mode_36
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_30 -> mode_15
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_29 -> mode_4
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_29 -> mode_10
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_29 -> mode_28
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_21 -> mode_31
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_10 -> mode_4
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_29 -> mode_25
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_24 -> mode_36
guard {
(gClk - 8.0) >= 0.0
(clk0 - 1.2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_21 -> mode_23
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(gClk - 8.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_24 -> mode_9
guard {
(clk0 - 1.2) >= 0.0
}
reset {
x' := x
clk0' := 1.2
clk1' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_29 -> mode_5
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_28 -> mode_16
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_21 -> mode_18
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_24 -> mode_12
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(clk0 - 1.2) >= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := 1.2
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_28 -> mode_32
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_10 -> mode_35
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_28 -> mode_36
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_28 -> mode_35
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_30 -> mode_15
guard {
(gClk - 8.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_32 -> mode_31
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_6 -> mode_24
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_21 -> mode_7
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_28 -> mode_10
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_5 -> mode_25
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_28 -> mode_4
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_32 -> mode_17
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_25 -> mode_35
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(gClk - 8.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_32 -> mode_15
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_18 -> mode_33
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_25 -> mode_31
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_28 -> mode_29
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_21 -> mode_19
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(gClk - 8.0) >= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_28 -> mode_5
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_32 -> mode_34
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_10 -> mode_36
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_21 -> mode_30
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_28 -> mode_25
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_21 -> mode_34
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_5 -> mode_23
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_25 -> mode_15
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_35 -> mode_36
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_5 -> mode_31
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_16 -> mode_17
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_36 -> mode_35
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_7 -> mode_35
guard {
(gClk - 8.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_7 -> mode_36
guard {
(gClk - 8.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_25 -> mode_5
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_5 -> mode_19
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_25 -> mode_19
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_7 -> mode_15
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_7 -> mode_31
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_21 -> mode_15
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_7 -> mode_34
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_5 -> mode_35
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(gClk - 8.0) >= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_25 -> mode_23
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_5 -> mode_36
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(gClk - 8.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_7 -> mode_17
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_21 -> mode_1
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_21 -> mode_33
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_7 -> mode_33
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_5 -> mode_15
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_18 -> mode_7
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_8 -> mode_31
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_18 -> mode_21
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_22 -> mode_8
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_4 -> mode_35
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_22 -> mode_15
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_18 -> mode_34
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_18 -> mode_19
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(gClk - 8.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_20 -> mode_18
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_4 -> mode_10
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_22 -> mode_34
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_18 -> mode_30
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_27 -> mode_3
guard {
}
reset {
clk0' := 0.0
gClk' := 0.0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_22 -> mode_23
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_18 -> mode_34
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(gClk - 8.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_20 -> mode_25
guard {
(clk0 - 1.2) <= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_8 -> mode_23
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_12 -> mode_35
guard {
(clk1 - 3.0) >= 0.0
(clk0 - 1.2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_18 -> mode_31
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_20 -> mode_5
guard {
(clk0 - 1.2) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_22 -> mode_31
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_18 -> mode_17
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_4 -> mode_36
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_9 -> mode_12
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_20 -> mode_34
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_18 -> mode_15
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_8 -> mode_35
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(gClk - 8.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_18 -> mode_23
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(gClk - 8.0) >= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_9 -> mode_36
guard {
(clk1 - 3.0) >= 0.0
(clk0 - 1.2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_8 -> mode_17
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_9 -> mode_36
guard {
(gClk - 8.0) >= 0.0
(clk0 - 1.2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_18 -> mode_15
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(gClk - 8.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_20 -> mode_22
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_12 -> mode_36
guard {
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 8.0) >= 0.0
(clk0 - 1.2) >= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_22 -> mode_19
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_9 -> mode_35
guard {
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 8.0) >= 0.0
(clk0 - 1.2) >= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_18 -> mode_31
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(gClk - 8.0) >= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_8 -> mode_19
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_20 -> mode_8
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_22 -> mode_36
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(gClk - 8.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_22 -> mode_17
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_8 -> mode_22
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_12 -> mode_9
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_22 -> mode_35
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(gClk - 8.0) >= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_8 -> mode_36
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(gClk - 8.0) >= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_8 -> mode_15
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_9 -> mode_35
guard {
(0 - x) <= 0.0
(x - 10) <= 0.0
(clk0 - 1.2) >= 0.0
(x - 2) >= 0.0
(clk1 - 3.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_18 -> mode_17
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(gClk - 8.0) >= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_0 -> mode_26
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_18 -> mode_1
guard {
(0 - x) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(x - 10) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_0 -> mode_9
guard {
(clk0 - 1.2) <= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_20 -> mode_17
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_20 -> mode_11
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_12 -> mode_36
guard {
(0 - x) <= 0.0
(x - 10) <= 0.0
(clk0 - 1.2) >= 0.0
(clk1 - 3.0) >= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_8 -> mode_34
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_12 -> mode_35
guard {
(gClk - 8.0) >= 0.0
(clk0 - 1.2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_27 -> mode_11
guard {
}
reset {
clk0' := 0.0
gClk' := 0.0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_13 -> mode_9
guard {
(clk0 - 1.2) <= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_14 -> mode_5
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_3 -> mode_35
guard {
(gClk - 8.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_11 -> mode_10
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_33 -> mode_36
guard {
(gClk - 8.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_11 -> mode_18
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_14 -> mode_25
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_3 -> mode_15
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_23 -> mode_19
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_14 -> mode_22
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_7 -> mode_23
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_20 -> mode_10
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_3 -> mode_31
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_3 -> mode_23
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_27 -> mode_13
guard {
}
reset {
clk0' := 0.0
gClk' := 0.0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_3 -> mode_22
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_13 -> mode_0
guard {
(clk0 - 1.2) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_20 -> mode_4
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_23 -> mode_34
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_11 -> mode_4
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_13 -> mode_35
guard {
(clk0 - 1.2) <= 0.0
(gClk - 8.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_3 -> mode_19
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_2 -> mode_26
guard {
(clk0 - 1.2) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_3 -> mode_21
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_20 -> mode_21
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_2 -> mode_36
guard {
(clk0 - 1.2) <= 0.0
(gClk - 8.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_11 -> mode_20
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_13 -> mode_2
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_2 -> mode_12
guard {
(clk0 - 1.2) <= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_14 -> mode_10
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_3 -> mode_8
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_11 -> mode_22
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_27 -> mode_6
guard {
}
reset {
clk0' := 0.0
gClk' := 0.0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_33 -> mode_7
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_3 -> mode_4
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_2 -> mode_0
guard {
(clk0 - 1.2) <= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_3 -> mode_32
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_11 -> mode_31
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_3 -> mode_34
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_3 -> mode_18
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_20 -> mode_10
guard {
(clk0 - 1.2) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_11 -> mode_34
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_11 -> mode_17
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_3 -> mode_16
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_27 -> mode_29
guard {
}
reset {
clk0' := 0.0
gClk' := 0.0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_2 -> mode_13
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_3 -> mode_17
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_2 -> mode_35
guard {
(clk0 - 1.2) <= 0.0
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 8.0) >= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_3 -> mode_5
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_11 -> mode_8
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_3 -> mode_10
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_2 -> mode_9
guard {
(clk0 - 1.2) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_33 -> mode_23
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_20 -> mode_16
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_23 -> mode_35
guard {
(gClk - 8.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_3 -> mode_36
guard {
(gClk - 8.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_11 -> mode_5
guard {
(clk0 - 1.2) <= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_20 -> mode_16
guard {
(clk0 - 1.2) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_13 -> mode_36
guard {
(clk0 - 1.2) <= 0.0
(0 - x) <= 0.0
(x - 10) <= 0.0
(gClk - 8.0) >= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_3 -> mode_14
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_20 -> mode_32
guard {
(clk0 - 1.2) <= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_23 -> mode_17
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_14 -> mode_8
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_0 -> mode_12
guard {
(clk0 - 1.2) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_7 -> mode_19
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_20 -> mode_4
guard {
(clk0 - 1.2) <= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_20 -> mode_31
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_3 -> mode_25
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_11 -> mode_25
guard {
(clk0 - 1.2) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_13 -> mode_26
guard {
(clk0 - 1.2) <= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_14 -> mode_4
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_33 -> mode_31
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_20 -> mode_32
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_23 -> mode_36
guard {
(gClk - 8.0) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_33 -> mode_19
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_11 -> mode_21
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_14 -> mode_21
guard {
(clk0 - 0.0) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_33 -> mode_35
guard {
(gClk - 8.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_14 -> mode_18
guard {
(clk0 - 0.0) >= 0.0
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
clk0' := 0.0
gClk' := gClk
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_14 -> mode_3
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_20 -> mode_15
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_11 -> mode_15
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_33 -> mode_15
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_13 -> mode_12
guard {
(clk0 - 1.2) <= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := 0.0
x' := x
}
parallelotope aggregation { }

mode_33 -> mode_34
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }

mode_33 -> mode_17
guard {
}
reset {
gClk' := gClk
clk0' := clk0
clk1' := clk1
x' := x
}
parallelotope aggregation { }
 
 }

 init {
 mode_27 {ff in [1.0, 1.0]
clk0 in [0.0, 0.0]
gClk in [0.0, 0.0]
x in [4, 4.5]
clk1 in [0.0, 0.0]
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
mode_11{ ff >= 10 }
mode_12{ ff >= 10 }
mode_13{ ff >= 10 }
mode_14{ ff >= 10 }
mode_15{ ff >= 10 }
mode_16{ ff >= 10 }
mode_17{ ff >= 10 }
mode_18{ ff >= 10 }
mode_19{ ff >= 10 }
mode_20{ ff >= 10 }
mode_21{ ff >= 10 }
mode_22{ ff >= 10 }
mode_23{ ff >= 10 }
mode_24{ ff >= 10 }
mode_25{ ff >= 10 }
mode_26{ ff >= 10 }
mode_27{ ff >= 10 }
mode_28{ ff >= 10 }
mode_29{ ff >= 10 }
mode_30{ ff >= 10 }
mode_31{ ff >= 10 }
mode_32{ ff >= 10 }
mode_33{ ff >= 10 }
mode_34{ ff >= 10 }
mode_35{}
mode_36{}
 
 }
