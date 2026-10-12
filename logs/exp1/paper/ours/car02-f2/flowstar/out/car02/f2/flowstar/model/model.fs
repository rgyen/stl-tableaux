hybrid reachability {
 state var rx, ry, ff, clk0, gClk, clk1, theta1
 setting {
 adaptive steps {min 0.001, max 0.5}
time 2
remainder estimation 1e-8
identity precondition 
gnuplot octagon rx,rx fixed orders 12
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
rx' = -1
theta1' = 0.05
ry' = (2 * (sin (theta1)))
ff' = 0.0
}
inv {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(gClk - 0.0) >= 0.0
(rx - -20) >= 0.0
(theta1 - 1.4) <= 0.0
(theta1 - (2 + 0.5)) <= 0.0
(-40 - ry) <= 0.0
(gClk - 5.0) <= 0.0
(-40 - rx) <= 0.0
(ry - 20) <= 0.0
}
}
mode_1{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
rx' = -1
ry' = (-2 * (sin (theta1)))
theta1' = 0.05
ff' = 0.0
}
inv {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(gClk - 0.0) >= 0.0
(rx - -20) >= 0.0
(theta1 - 1.4) <= 0.0
(theta1 - (2 + 0.5)) <= 0.0
(-40 - ry) <= 0.0
(gClk - 5.0) <= 0.0
(ry - -20) >= 0.0
(-40 - rx) <= 0.0
}
}
mode_2{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
theta1' = 0.05
ry' = (2 * (sin (theta1)))
rx' = 1
ff' = 0.0
}
inv {
(rx - 20) <= 0.0
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(gClk - 0.0) >= 0.0
(theta1 - 1.4) <= 0.0
(theta1 - (2 + 0.5)) <= 0.0
(-40 - ry) <= 0.0
(gClk - 5.0) <= 0.0
(-40 - rx) <= 0.0
(ry - 20) <= 0.0
}
}
mode_3{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
rx' = -1
theta1' = 0.05
ry' = (2 * (sin (theta1)))
ff' = 0.0
}
inv {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(gClk - 0.0) >= 0.0
(rx - -20) >= 0.0
(theta1 - 1.4) <= 0.0
(theta1 - (2 + 0.5)) <= 0.0
(-40 - ry) <= 0.0
(gClk - 5.0) <= 0.0
(-40 - rx) <= 0.0
(ry - 20) <= 0.0
}
}
mode_4{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
ry' = (-2 * (sin (theta1)))
theta1' = 0.05
rx' = 1
ff' = 0.0
}
inv {
(rx - 20) <= 0.0
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(gClk - 0.0) >= 0.0
(theta1 - 1.4) <= 0.0
(theta1 - (2 + 0.5)) <= 0.0
(-40 - ry) <= 0.0
(gClk - 5.0) <= 0.0
(ry - -20) >= 0.0
(-40 - rx) <= 0.0
}
}
mode_5{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
rx' = -1
ry' = (-2 * (sin (theta1)))
theta1' = 0.05
ff' = 0.0
}
inv {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(gClk - 0.0) >= 0.0
(rx - -20) >= 0.0
(theta1 - 1.4) <= 0.0
(-40 - ry) <= 0.0
(gClk - 5.0) <= 0.0
(ry - -20) >= 0.0
(-40 - rx) <= 0.0
}
}
mode_6{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
rx' = -1
theta1' = 0.05
ry' = (2 * (sin (theta1)))
ff' = 0.0
}
inv {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(gClk - 0.0) >= 0.0
(rx - -20) >= 0.0
(theta1 - 1.4) <= 0.0
(-40 - ry) <= 0.0
(gClk - 5.0) <= 0.0
(-40 - rx) <= 0.0
(ry - 20) <= 0.0
}
}
mode_7{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
ry' = (-2 * (sin (theta1)))
theta1' = 0.05
rx' = 1
ff' = 0.0
}
inv {
(rx - 20) <= 0.0
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(gClk - 0.0) >= 0.0
(theta1 - 1.4) <= 0.0
(-40 - ry) <= 0.0
(gClk - 5.0) <= 0.0
(ry - -20) >= 0.0
(-40 - rx) <= 0.0
}
}
mode_8{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
theta1' = 0.05
ry' = (2 * (sin (theta1)))
rx' = 1
ff' = 0.0
}
inv {
(rx - 20) <= 0.0
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(gClk - 0.0) >= 0.0
(theta1 - 1.4) <= 0.0
(-40 - ry) <= 0.0
(gClk - 5.0) <= 0.0
(-40 - rx) <= 0.0
(ry - 20) <= 0.0
}
}
mode_9{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
rx' = -1
ry' = (-2 * (sin (theta1)))
theta1' = 0.05
ff' = 0.0
}
inv {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(gClk - 0.0) >= 0.0
(rx - -20) >= 0.0
(theta1 - 1.4) <= 0.0
(theta1 - (2 + 0.5)) <= 0.0
(-40 - ry) <= 0.0
(gClk - 5.0) <= 0.0
(ry - -20) >= 0.0
(-40 - rx) <= 0.0
}
}
mode_10{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
theta1' = 0.05
ry' = (2 * (sin (theta1)))
rx' = 1
ff' = 0.0
}
inv {
(rx - 20) <= 0.0
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(gClk - 0.0) >= 0.0
(theta1 - 1.4) <= 0.0
(theta1 - (2 + 0.5)) <= 0.0
(-40 - ry) <= 0.0
(gClk - 5.0) <= 0.0
(-40 - rx) <= 0.0
(ry - 20) <= 0.0
}
}
mode_11{
nonpoly ode
{rx' = 0.0
theta1' = 0.0
ry' = 0.0
clk0' = 0.0
gClk' = 1.0
clk1' = 0.0
ff' = 0.0
}
inv {
(gClk - 0.0) >= 0.0
(gClk - 5.0) <= 0.0
}
}
mode_12{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
theta1' = 0.05
ry' = (2 * (sin (theta1)))
rx' = 1
ff' = 0.0
}
inv {
(rx - 20) <= 0.0
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(gClk - 0.0) >= 0.0
(theta1 - 1.4) <= 0.0
(-40 - ry) <= 0.0
(gClk - 5.0) <= 0.0
(-40 - rx) <= 0.0
(ry - 20) <= 0.0
}
}
mode_13{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
ry' = (-2 * (sin (theta1)))
theta1' = 0.05
rx' = 1
ff' = 0.0
}
inv {
(rx - 20) <= 0.0
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(gClk - 0.0) >= 0.0
(theta1 - 1.4) <= 0.0
(theta1 - (2 + 0.5)) <= 0.0
(-40 - ry) <= 0.0
(gClk - 5.0) <= 0.0
(ry - -20) >= 0.0
(-40 - rx) <= 0.0
}
}
mode_14{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
rx' = -1
ry' = (-2 * (sin (theta1)))
theta1' = 0.05
ff' = 0.0
}
inv {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(gClk - 0.0) >= 0.0
(rx - -20) >= 0.0
(theta1 - 1.4) <= 0.0
(-40 - ry) <= 0.0
(gClk - 5.0) <= 0.0
(ry - -20) >= 0.0
(-40 - rx) <= 0.0
}
}
mode_15{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
rx' = -1
theta1' = 0.05
ry' = (2 * (sin (theta1)))
ff' = 0.0
}
inv {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(gClk - 0.0) >= 0.0
(rx - -20) >= 0.0
(theta1 - 1.4) <= 0.0
(-40 - ry) <= 0.0
(gClk - 5.0) <= 0.0
(-40 - rx) <= 0.0
(ry - 20) <= 0.0
}
}
mode_16{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
ry' = (-2 * (sin (theta1)))
theta1' = 0.05
rx' = 1
ff' = 0.0
}
inv {
(rx - 20) <= 0.0
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(gClk - 0.0) >= 0.0
(theta1 - 1.4) <= 0.0
(-40 - ry) <= 0.0
(gClk - 5.0) <= 0.0
(ry - -20) >= 0.0
(-40 - rx) <= 0.0
}
}
}

 jumps {
 mode_11 -> mode_1
guard {
}
reset {
rx' := rx
ry' := ry
clk0' := 0.0
theta1' := theta1
gClk' := 0.0
clk1' := clk1
}
parallelotope aggregation { }

mode_16 -> mode_12
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_16 -> mode_16
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_0 -> mode_7
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_16 -> mode_15
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_16 -> mode_5
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_0 -> mode_14
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_1 -> mode_0
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_14 -> mode_7
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_14 -> mode_14
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_1 -> mode_9
guard {
(clk0 - 0.0) >= 0.0
}
reset {
rx' := rx
ry' := ry
clk1' := 0.0
clk0' := 0.0
theta1' := theta1
gClk' := gClk
}
parallelotope aggregation { }

mode_14 -> mode_8
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_1 -> mode_9
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(ry - 2.4) >= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
ry' := ry
clk1' := 0.0
clk0' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_14 -> mode_6
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_13 -> mode_6
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_6 -> mode_7
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_6 -> mode_14
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_0 -> mode_1
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_6 -> mode_6
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_0 -> mode_4
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_0 -> mode_2
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_6 -> mode_8
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_1 -> mode_10
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
ry' := ry
clk1' := 0.0
clk0' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_8 -> mode_7
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_16 -> mode_9
guard {
(ry - 40) <= 0.0
(clk0 - 2.0) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
clk1' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_1 -> mode_3
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
ry' := ry
clk1' := 0.0
clk0' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_8 -> mode_6
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_1 -> mode_13
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(ry - 2.4) >= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
ry' := ry
clk1' := 0.0
clk0' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_8 -> mode_14
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_0 -> mode_0
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_8 -> mode_8
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_1 -> mode_6
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_7 -> mode_8
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_16 -> mode_13
guard {
(clk0 - 2.0) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
clk1' := 0.0
theta1' := theta1
gClk' := gClk
}
parallelotope aggregation { }

mode_1 -> mode_14
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_7 -> mode_7
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_1 -> mode_14
guard {
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
theta1' := theta1
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_7 -> mode_6
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_13 -> mode_7
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(ry - 2.4) >= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_0 -> mode_8
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_1 -> mode_4
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_7 -> mode_14
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_13 -> mode_3
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_13 -> mode_14
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(ry - 2.4) >= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_13 -> mode_7
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
theta1' := theta1
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_13 -> mode_13
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_0 -> mode_6
guard {
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
theta1' := theta1
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_1 -> mode_2
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_1 -> mode_1
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_1 -> mode_7
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_13 -> mode_10
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_0 -> mode_6
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_1 -> mode_8
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_13 -> mode_8
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_13 -> mode_9
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_0 -> mode_13
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(ry - 2.4) >= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
ry' := ry
clk1' := 0.0
clk0' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_4 -> mode_14
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_4 -> mode_7
guard {
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
theta1' := theta1
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_10 -> mode_9
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_4 -> mode_10
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
ry' := ry
clk1' := 0.0
clk0' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_4 -> mode_13
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(ry - 2.4) >= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
ry' := ry
clk1' := 0.0
clk0' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_4 -> mode_3
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
ry' := ry
clk1' := 0.0
clk0' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_10 -> mode_10
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_0 -> mode_3
guard {
(clk0 - 0.0) >= 0.0
}
reset {
rx' := rx
ry' := ry
clk1' := 0.0
clk0' := 0.0
theta1' := theta1
gClk' := gClk
}
parallelotope aggregation { }

mode_4 -> mode_9
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(ry - 2.4) >= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
ry' := ry
clk1' := 0.0
clk0' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_3 -> mode_10
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_4 -> mode_13
guard {
(clk0 - 0.0) >= 0.0
}
reset {
rx' := rx
ry' := ry
clk1' := 0.0
clk0' := 0.0
theta1' := theta1
gClk' := gClk
}
parallelotope aggregation { }

mode_9 -> mode_10
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_5 -> mode_13
guard {
(ry - 40) <= 0.0
(clk0 - 2.0) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
clk1' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_5 -> mode_9
guard {
(ry - 40) <= 0.0
(clk0 - 2.0) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
clk1' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_10 -> mode_3
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_10 -> mode_8
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
theta1' := theta1
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_5 -> mode_10
guard {
(ry - 40) <= 0.0
(clk0 - 2.0) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
clk1' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_5 -> mode_9
guard {
(clk0 - 2.0) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
clk1' := 0.0
theta1' := theta1
gClk' := gClk
}
parallelotope aggregation { }

mode_2 -> mode_0
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_3 -> mode_6
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_5 -> mode_3
guard {
(ry - 40) <= 0.0
(clk0 - 2.0) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
clk1' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_2 -> mode_4
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_3 -> mode_7
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(ry - 2.4) >= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_5 -> mode_16
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_3 -> mode_14
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(ry - 2.4) >= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_5 -> mode_5
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_0 -> mode_10
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
ry' := ry
clk1' := 0.0
clk0' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_5 -> mode_12
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_10 -> mode_13
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_2 -> mode_1
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_2 -> mode_2
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_3 -> mode_3
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_2 -> mode_6
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_3 -> mode_9
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_5 -> mode_15
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_2 -> mode_8
guard {
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
theta1' := theta1
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_15 -> mode_13
guard {
(ry - 40) <= 0.0
(clk0 - 2.0) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
clk1' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_2 -> mode_7
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_10 -> mode_8
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_15 -> mode_9
guard {
(ry - 40) <= 0.0
(clk0 - 2.0) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
clk1' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_0 -> mode_9
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(ry - 2.4) >= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
ry' := ry
clk1' := 0.0
clk0' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_15 -> mode_3
guard {
(ry - 40) <= 0.0
(clk0 - 2.0) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
clk1' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_3 -> mode_6
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
theta1' := theta1
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_15 -> mode_10
guard {
(ry - 40) <= 0.0
(clk0 - 2.0) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
clk1' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_3 -> mode_8
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_2 -> mode_13
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(ry - 2.4) >= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
ry' := ry
clk1' := 0.0
clk0' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_15 -> mode_3
guard {
(clk0 - 2.0) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
clk1' := 0.0
theta1' := theta1
gClk' := gClk
}
parallelotope aggregation { }

mode_15 -> mode_16
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_2 -> mode_14
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_10 -> mode_7
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(ry - 2.4) >= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_15 -> mode_5
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_2 -> mode_8
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_0 -> mode_3
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
ry' := ry
clk1' := 0.0
clk0' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_9 -> mode_3
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_15 -> mode_15
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_15 -> mode_12
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_3 -> mode_13
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_12 -> mode_13
guard {
(ry - 40) <= 0.0
(clk0 - 2.0) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
clk1' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_10 -> mode_14
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(ry - 2.4) >= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_10 -> mode_6
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_12 -> mode_10
guard {
(clk0 - 2.0) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
clk1' := 0.0
theta1' := theta1
gClk' := gClk
}
parallelotope aggregation { }

mode_9 -> mode_7
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(ry - 2.4) >= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_12 -> mode_3
guard {
(ry - 40) <= 0.0
(clk0 - 2.0) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
clk1' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_2 -> mode_3
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
ry' := ry
clk1' := 0.0
clk0' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_12 -> mode_9
guard {
(ry - 40) <= 0.0
(clk0 - 2.0) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
clk1' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_2 -> mode_10
guard {
(clk0 - 0.0) >= 0.0
}
reset {
rx' := rx
ry' := ry
clk1' := 0.0
clk0' := 0.0
theta1' := theta1
gClk' := gClk
}
parallelotope aggregation { }

mode_9 -> mode_9
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_12 -> mode_10
guard {
(ry - 40) <= 0.0
(clk0 - 2.0) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
clk1' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_2 -> mode_9
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(ry - 2.4) >= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
ry' := ry
clk1' := 0.0
clk0' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_9 -> mode_14
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(ry - 2.4) >= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_12 -> mode_16
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_2 -> mode_10
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
ry' := ry
clk1' := 0.0
clk0' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_11 -> mode_5
guard {
}
reset {
rx' := rx
ry' := ry
clk0' := 0.0
theta1' := theta1
gClk' := 0.0
clk1' := clk1
}
parallelotope aggregation { }

mode_9 -> mode_13
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_4 -> mode_2
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_12 -> mode_15
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_4 -> mode_4
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_12 -> mode_5
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_9 -> mode_6
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_4 -> mode_0
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_12 -> mode_12
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_4 -> mode_1
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_16 -> mode_10
guard {
(ry - 40) <= 0.0
(clk0 - 2.0) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
clk1' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_9 -> mode_8
guard {
(ry - 40) <= 0.0
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_16 -> mode_13
guard {
(ry - 40) <= 0.0
(clk0 - 2.0) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
clk1' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_4 -> mode_8
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_9 -> mode_14
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
theta1' := theta1
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_16 -> mode_3
guard {
(ry - 40) <= 0.0
(clk0 - 2.0) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
clk1' := 0.0
gClk' := gClk
theta1' := 0
}
parallelotope aggregation { }

mode_4 -> mode_7
guard {
(ry - 40) <= 0.0
(ry - 2.4) >= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(rx - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }

mode_4 -> mode_6
guard {
(ry - 40) <= 0.0
(0 - theta1) <= 0.0
(rx - 40) <= 0.0
(rx - 2.4) >= 0.0
(theta1 - 1.5) <= 0.0
(-40 - ry) <= 0.0
(ry - 2) <= 0.0
(-40 - rx) <= 0.0
}
reset {
rx' := rx
clk0' := clk0
ry' := ry
gClk' := gClk
clk1' := clk1
theta1' := 0
}
parallelotope aggregation { }
 
 }

 init {
 mode_11 {rx in [0, 1]
ry in [0, 1]
ff in [1.0, 1.0]
clk0 in [0.0, 0.0]
gClk in [0.0, 0.0]
clk1 in [0.0, 0.0]
theta1 in [0, 1]
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
mode_6{}
mode_7{}
mode_8{}
mode_9{ ff >= 10 }
mode_10{ ff >= 10 }
mode_11{ ff >= 10 }
mode_12{ ff >= 10 }
mode_13{ ff >= 10 }
mode_14{}
mode_15{ ff >= 10 }
mode_16{ ff >= 10 }
 
 }
