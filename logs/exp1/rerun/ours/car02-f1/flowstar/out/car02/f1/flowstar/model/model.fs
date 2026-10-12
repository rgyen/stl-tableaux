hybrid reachability {
 state var ff, gClk, rx, theta1, ry
 setting {
 adaptive steps {min 0.001, max 0.5}
time 2
remainder estimation 1e-8
identity precondition 
gnuplot octagon ff,ff fixed orders 12
cutoff 1e-13
precision 53
no output 
max jumps 1000
print on  
}

 modes {
 mode_0{
nonpoly ode
{gClk' = 1.0
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
mode_1{
nonpoly ode
{rx' = 0.0
theta1' = 0.0
ry' = 0.0
gClk' = 1.0
ff' = 0.0
}
inv {
(gClk - 0.0) >= 0.0
(gClk - 5.0) <= 0.0
}
}
mode_2{
nonpoly ode
{gClk' = 1.0
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
mode_3{
nonpoly ode
{gClk' = 1.0
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
mode_4{
nonpoly ode
{gClk' = 1.0
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
mode_5{
nonpoly ode
{gClk' = 1.0
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
{gClk' = 1.0
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
mode_7{
nonpoly ode
{gClk' = 1.0
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
(theta1 - (1.0 + 0.001)) <= 0.0
(theta1 - 1.4) <= 0.0
(-40 - ry) <= 0.0
(gClk - 5.0) <= 0.0
(ry - -20) >= 0.0
(-40 - rx) <= 0.0
}
}
mode_8{
nonpoly ode
{gClk' = 1.0
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
(theta1 - (1.0 + 0.001)) <= 0.0
(theta1 - 1.4) <= 0.0
(-40 - ry) <= 0.0
(gClk - 5.0) <= 0.0
(ry - -20) >= 0.0
(-40 - rx) <= 0.0
}
}
mode_9{
nonpoly ode
{gClk' = 1.0
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
(theta1 - (1.0 + 0.001)) <= 0.0
(theta1 - 1.4) <= 0.0
(-40 - ry) <= 0.0
(gClk - 5.0) <= 0.0
(-40 - rx) <= 0.0
(ry - 20) <= 0.0
}
}
mode_10{
nonpoly ode
{gClk' = 1.0
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
mode_11{
nonpoly ode
{gClk' = 1.0
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
mode_12{
nonpoly ode
{gClk' = 1.0
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
(theta1 - (1.0 + 0.001)) <= 0.0
(theta1 - 1.4) <= 0.0
(-40 - ry) <= 0.0
(gClk - 5.0) <= 0.0
(-40 - rx) <= 0.0
(ry - 20) <= 0.0
}
}
}

 jumps {
 mode_9 -> mode_3
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_12 -> mode_3
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_6 -> mode_9
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_12 -> mode_7
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
gClk' := gClk
ry' := ry
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_8 -> mode_9
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_3 -> mode_5
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_5 -> mode_2
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_7 -> mode_5
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
gClk' := gClk
ry' := ry
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_7 -> mode_2
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_12 -> mode_0
guard {
}
reset {
rx' := rx
gClk' := gClk
theta1' := theta1
ry' := ry
}
parallelotope aggregation { }

mode_7 -> mode_12
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_8 -> mode_12
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_6 -> mode_7
guard {
}
reset {
rx' := rx
gClk' := gClk
theta1' := theta1
ry' := ry
}
parallelotope aggregation { }

mode_7 -> mode_5
guard {
}
reset {
rx' := rx
gClk' := gClk
theta1' := theta1
ry' := ry
}
parallelotope aggregation { }

mode_8 -> mode_3
guard {
}
reset {
rx' := rx
gClk' := gClk
theta1' := theta1
ry' := ry
}
parallelotope aggregation { }

mode_9 -> mode_0
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_10 -> mode_11
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_11 -> mode_9
guard {
}
reset {
rx' := rx
gClk' := gClk
theta1' := theta1
ry' := ry
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_4 -> mode_10
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_11 -> mode_6
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_7 -> mode_8
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_10 -> mode_12
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_12 -> mode_8
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_4 -> mode_12
guard {
}
reset {
rx' := rx
gClk' := gClk
theta1' := theta1
ry' := ry
}
parallelotope aggregation { }

mode_7 -> mode_3
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_12 -> mode_0
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_6 -> mode_10
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_9 -> mode_2
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_11 -> mode_12
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_10 -> mode_6
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_11 -> mode_7
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_7 -> mode_7
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_11 -> mode_8
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_5 -> mode_0
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_8 -> mode_3
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_4 -> mode_4
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_5 -> mode_3
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_8 -> mode_5
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_4 -> mode_12
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_10 -> mode_9
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_4 -> mode_8
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_6 -> mode_12
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_10 -> mode_4
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_1 -> mode_7
guard {
}
reset {
gClk' := 0.0
rx' := rx
theta1' := theta1
ry' := ry
}
parallelotope aggregation { }

mode_6 -> mode_4
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_3 -> mode_0
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_11 -> mode_9
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_6 -> mode_11
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_9 -> mode_9
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_7 -> mode_0
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_8 -> mode_7
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_1 -> mode_6
guard {
}
reset {
gClk' := 0.0
rx' := rx
theta1' := theta1
ry' := ry
}
parallelotope aggregation { }

mode_10 -> mode_8
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_12 -> mode_9
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_9 -> mode_5
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_10 -> mode_10
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_4 -> mode_11
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
gClk' := gClk
ry' := ry
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_6 -> mode_7
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_3 -> mode_3
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_4 -> mode_9
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_4 -> mode_7
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_11 -> mode_4
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_10 -> mode_7
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_12 -> mode_12
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_9 -> mode_8
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_9 -> mode_7
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_7 -> mode_9
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_10 -> mode_8
guard {
}
reset {
rx' := rx
gClk' := gClk
theta1' := theta1
ry' := ry
}
parallelotope aggregation { }

mode_12 -> mode_2
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_2 -> mode_5
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_11 -> mode_11
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
gClk' := gClk
ry' := ry
theta1' := 0
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_6 -> mode_6
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_11 -> mode_10
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_0 -> mode_5
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_8 -> mode_0
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_9 -> mode_12
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_8 -> mode_2
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_6 -> mode_8
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_8 -> mode_8
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
gClk' := gClk
ry' := ry
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_9 -> mode_2
guard {
}
reset {
rx' := rx
gClk' := gClk
theta1' := theta1
ry' := ry
}
parallelotope aggregation { }

mode_3 -> mode_2
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_2 -> mode_3
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_0 -> mode_3
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }

mode_4 -> mode_6
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
gClk' := gClk
ry' := ry
theta1' := 0
}
parallelotope aggregation { }
 
 }

 init {
 mode_1 {ff in [1.0, 1.0]
gClk in [0.0, 0.0]
rx in [0, 1]
theta1 in [0, 1]
ry in [0, 1]
}

}

}
 unsafe {
 mode_0{}
mode_1{ ff >= 10 }
mode_2{}
mode_3{}
mode_4{ ff >= 10 }
mode_5{}
mode_6{ ff >= 10 }
mode_7{ ff >= 10 }
mode_8{ ff >= 10 }
mode_9{ ff >= 10 }
mode_10{ ff >= 10 }
mode_11{ ff >= 10 }
mode_12{ ff >= 10 }
 
 }
