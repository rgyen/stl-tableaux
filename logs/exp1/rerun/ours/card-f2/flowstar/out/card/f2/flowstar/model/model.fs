hybrid reachability {
 state var clk4, v, ff, clk0, gClk, duration, u, clk2, clk1, clk3
 setting {
 adaptive steps {min 0.001, max 0.5}
time 60
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
u' = (((((((-0.9) * u) * u) - ((u * u) * u)) - (0.9 * u)) - v) + 1)
duration' = 1
v' = (u - (2 * v))
ff' = 0.0
}
inv {
(gClk - 90.0) <= 0.0
(u - 10) <= 0.0
(-10 - u) <= 0.0
(gClk - 0.0) >= 0.0
(duration - 5) <= 0.0
(u - (4.0 - 0.1)) >= 0.0
(-10 - v) <= 0.0
(duration - 10) <= 0.0
(0 - duration) <= 0.0
(v - 10) <= 0.0
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
u' = (((((((-0.9) * u) * u) - ((u * u) * u)) - (0.9 * u)) - v) + 1)
duration' = 1
v' = (u - (2 * v))
ff' = 0.0
}
inv {
(gClk - 90.0) <= 0.0
(u - 10) <= 0.0
(-10 - u) <= 0.0
(gClk - 0.0) >= 0.0
(duration - 5) <= 0.0
(u - (4.0 - 0.1)) >= 0.0
(-10 - v) <= 0.0
(duration - 10) <= 0.0
(u - (2.0 - 0.1)) >= 0.0
(0 - duration) <= 0.0
(v - 10) <= 0.0
}
}
mode_2{
poly ode 2
{duration' = 0.0
v' = 0.0
u' = 0.0
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
(gClk - 90.0) <= 0.0
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
u' = (((((((-0.9) * u) * u) - ((u * u) * u)) - (0.9 * u)) - v) + 1)
duration' = 1
v' = (u - (2 * v))
ff' = 0.0
}
inv {
(gClk - 90.0) <= 0.0
(u - 10) <= 0.0
(-10 - u) <= 0.0
(gClk - 0.0) >= 0.0
(duration - 5) <= 0.0
(u - (4.0 - 0.1)) >= 0.0
(-10 - v) <= 0.0
(duration - 10) <= 0.0
(u - (2.0 - 0.1)) >= 0.0
(0 - duration) <= 0.0
(v - 10) <= 0.0
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
u' = (((((((-0.9) * u) * u) - ((u * u) * u)) - (0.9 * u)) - v) + 1)
duration' = 1
v' = (u - (2 * v))
ff' = 0.0
}
inv {
(gClk - 90.0) <= 0.0
(u - 10) <= 0.0
(-10 - u) <= 0.0
(gClk - 0.0) >= 0.0
(duration - 5) <= 0.0
(u - (4.0 - 0.1)) >= 0.0
(-10 - v) <= 0.0
(duration - 10) <= 0.0
(0 - duration) <= 0.0
(v - 10) <= 0.0
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
u' = (((((((-0.9) * u) * u) - ((u * u) * u)) - (0.9 * u)) - v) + 1)
duration' = 1
v' = (u - (2 * v))
ff' = 0.0
}
inv {
(gClk - 90.0) <= 0.0
(u - 10) <= 0.0
(-10 - u) <= 0.0
(gClk - 0.0) >= 0.0
(duration - 5) <= 0.0
(u - (4.0 - 0.1)) >= 0.0
(-10 - v) <= 0.0
(duration - 10) <= 0.0
(u - (2.0 - 0.1)) >= 0.0
(0 - duration) <= 0.0
(v - 10) <= 0.0
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
u' = (((((((-0.9) * u) * u) - ((u * u) * u)) - (0.9 * u)) - v) + 1)
duration' = 1
v' = (u - (2 * v))
ff' = 0.0
}
inv {
(gClk - 90.0) <= 0.0
(u - 10) <= 0.0
(-10 - u) <= 0.0
(gClk - 0.0) >= 0.0
(duration - 5) <= 0.0
(-10 - v) <= 0.0
(duration - 10) <= 0.0
(0 - duration) <= 0.0
(v - 10) <= 0.0
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
u' = (((((((-0.9) * u) * u) - ((u * u) * u)) - (0.9 * u)) - v) + 1)
duration' = 1
v' = (u - (2 * v))
ff' = 0.0
}
inv {
(gClk - 90.0) <= 0.0
(u - 10) <= 0.0
(-10 - u) <= 0.0
(gClk - 0.0) >= 0.0
(duration - 5) <= 0.0
(u - (4.0 - 0.1)) >= 0.0
(-10 - v) <= 0.0
(duration - 10) <= 0.0
(0 - duration) <= 0.0
(v - 10) <= 0.0
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
u' = (((((((-0.9) * u) * u) - ((u * u) * u)) - (0.9 * u)) - v) + 1)
duration' = 1
v' = (u - (2 * v))
ff' = 0.0
}
inv {
(gClk - 90.0) <= 0.0
(u - 10) <= 0.0
(-10 - u) <= 0.0
(gClk - 0.0) >= 0.0
(duration - 5) <= 0.0
(-10 - v) <= 0.0
(duration - 10) <= 0.0
(0 - duration) <= 0.0
(v - 10) <= 0.0
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
u' = (((((((-0.9) * u) * u) - ((u * u) * u)) - (0.9 * u)) - v) + 1)
duration' = 1
v' = (u - (2 * v))
ff' = 0.0
}
inv {
(gClk - 90.0) <= 0.0
(u - 10) <= 0.0
(-10 - u) <= 0.0
(gClk - 0.0) >= 0.0
(duration - 5) <= 0.0
(-10 - v) <= 0.0
(duration - 10) <= 0.0
(0 - duration) <= 0.0
(v - 10) <= 0.0
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
u' = (((((((-0.9) * u) * u) - ((u * u) * u)) - (0.9 * u)) - v) + 1)
duration' = 1
v' = (u - (2 * v))
ff' = 0.0
}
inv {
(gClk - 90.0) <= 0.0
(u - 10) <= 0.0
(-10 - u) <= 0.0
(gClk - 0.0) >= 0.0
(duration - 5) <= 0.0
(-10 - v) <= 0.0
(duration - 10) <= 0.0
(u - (2.0 - 0.1)) >= 0.0
(0 - duration) <= 0.0
(v - 10) <= 0.0
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
u' = (((((((-0.9) * u) * u) - ((u * u) * u)) - (0.9 * u)) - v) + 1)
duration' = 1
v' = (u - (2 * v))
ff' = 0.0
}
inv {
(gClk - 90.0) <= 0.0
(u - 10) <= 0.0
(-10 - u) <= 0.0
(gClk - 0.0) >= 0.0
(duration - 5) <= 0.0
(-10 - v) <= 0.0
(duration - 10) <= 0.0
(u - (2.0 - 0.1)) >= 0.0
(0 - duration) <= 0.0
(v - 10) <= 0.0
}
}
mode_12{
poly ode 2
{clk1' = 1.0
clk0' = 1.0
clk3' = 1.0
clk2' = 1.0
clk4' = 1.0
gClk' = 1.0
u' = (((((((-0.9) * u) * u) - ((u * u) * u)) - (0.9 * u)) - v) + 1)
duration' = 1
v' = (u - (2 * v))
ff' = 0.0
}
inv {
(gClk - 90.0) <= 0.0
(u - 10) <= 0.0
(-10 - u) <= 0.0
(gClk - 0.0) >= 0.0
(duration - 5) <= 0.0
(-10 - v) <= 0.0
(duration - 10) <= 0.0
(0 - duration) <= 0.0
(v - 10) <= 0.0
}
}
mode_13{
poly ode 2
{clk1' = 1.0
clk0' = 1.0
clk3' = 1.0
clk2' = 1.0
clk4' = 1.0
gClk' = 1.0
u' = (((((((-0.9) * u) * u) - ((u * u) * u)) - (0.9 * u)) - v) + 1)
duration' = 1
v' = (u - (2 * v))
ff' = 0.0
}
inv {
(gClk - 90.0) <= 0.0
(u - 10) <= 0.0
(-10 - u) <= 0.0
(gClk - 0.0) >= 0.0
(duration - 5) <= 0.0
(u - (4.0 - 0.1)) >= 0.0
(-10 - v) <= 0.0
(duration - 10) <= 0.0
(0 - duration) <= 0.0
(v - 10) <= 0.0
}
}
mode_14{
poly ode 2
{clk1' = 1.0
clk0' = 1.0
clk3' = 1.0
clk2' = 1.0
clk4' = 1.0
gClk' = 1.0
u' = (((((((-0.9) * u) * u) - ((u * u) * u)) - (0.9 * u)) - v) + 1)
duration' = 1
v' = (u - (2 * v))
ff' = 0.0
}
inv {
(gClk - 90.0) <= 0.0
(u - 10) <= 0.0
(-10 - u) <= 0.0
(gClk - 0.0) >= 0.0
(duration - 5) <= 0.0
(u - (4.0 - 0.1)) >= 0.0
(-10 - v) <= 0.0
(duration - 10) <= 0.0
(u - (2.0 - 0.1)) >= 0.0
(0 - duration) <= 0.0
(v - 10) <= 0.0
}
}
mode_15{
poly ode 2
{clk1' = 1.0
clk0' = 1.0
clk3' = 1.0
clk2' = 1.0
clk4' = 1.0
gClk' = 1.0
u' = (((((((-0.9) * u) * u) - ((u * u) * u)) - (0.9 * u)) - v) + 1)
duration' = 1
v' = (u - (2 * v))
ff' = 0.0
}
inv {
(gClk - 90.0) <= 0.0
(u - 10) <= 0.0
(-10 - u) <= 0.0
(gClk - 0.0) >= 0.0
(duration - 5) <= 0.0
(-10 - v) <= 0.0
(duration - 10) <= 0.0
(0 - duration) <= 0.0
(v - 10) <= 0.0
}
}
}

 jumps {
 mode_4 -> mode_9
guard {
(clk0 - 1.0) >= 0.0
(clk1 - 1.0) >= 0.0
(clk2 - 6.0) <= 0.0
(gClk - 90.0) >= 0.0
(clk4 - 6.0) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
v' := v
clk3' := clk3
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_13 -> mode_14
guard {
(clk2 - 6.0) <= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := clk2
clk3' := 0.0
v' := v
clk0' := 1.0
clk1' := 0.0
u' := u
duration' := duration
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_13 -> mode_5
guard {
(clk2 - 6.0) <= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := clk2
clk3' := 0.0
v' := v
clk0' := 1.0
clk1' := 0.0
u' := u
duration' := duration
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_15 -> mode_1
guard {
(clk0 - 5.0) <= 0.0
}
reset {
clk0' := clk0
v' := v
clk1' := 0.0
clk3' := clk3
clk2' := 0.0
u' := u
duration' := duration
gClk' := gClk
clk4' := clk4
}
parallelotope aggregation { }

mode_7 -> mode_11
guard {
(clk2 - 6.0) <= 0.0
(clk0 - 1.0) >= 0.0
(clk1 - 1.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
clk3' := 0.0
v' := v
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_14 -> mode_5
guard {
(clk1 - 1.0) <= 0.0
(clk2 - 6.0) <= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := clk2
v' := v
clk0' := 1.0
clk1' := clk1
clk3' := clk3
u' := u
duration' := duration
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_2 -> mode_15
guard {
}
reset {
clk2' := clk2
u' := u
v' := v
clk3' := clk3
clk0' := 0.0
gClk' := 0.0
duration' := duration
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_0 -> mode_8
guard {
(clk1 - 1.0) <= 0.0
(clk2 - 6.0) <= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := clk2
v' := v
clk0' := 1.0
clk3' := clk3
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_3 -> mode_14
guard {
(clk2 - 6.0) >= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := 6.0
clk3' := 0.0
v' := v
clk0' := 1.0
clk1' := 0.0
u' := u
duration' := duration
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_14 -> mode_5
guard {
(clk1 - 1.0) <= 0.0
(clk2 - 6.0) >= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := 6.0
clk3' := 0.0
v' := v
clk0' := 1.0
clk1' := clk1
u' := u
duration' := duration
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_1 -> mode_11
guard {
(clk2 - 6.0) >= 0.0
(clk0 - 1.0) >= 0.0
(clk1 - 1.0) >= 0.0
}
reset {
clk2' := 6.0
clk0' := clk0
clk3' := 0.0
v' := v
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_13 -> mode_10
guard {
(clk2 - 6.0) <= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := clk2
clk3' := 0.0
v' := v
clk0' := 1.0
clk1' := 0.0
u' := u
duration' := duration
gClk' := gClk
clk4' := clk4
}
parallelotope aggregation { }

mode_0 -> mode_6
guard {
(clk2 - 6.0) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
v' := v
clk3' := clk3
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_8 -> mode_10
guard {
(clk2 - 6.0) <= 0.0
(clk0 - 5.0) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
v' := v
clk3' := clk3
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_6 -> mode_9
guard {
(clk2 - 6.0) <= 0.0
(gClk - 90.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
v' := v
clk3' := clk3
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_0 -> mode_5
guard {
(clk1 - 1.0) <= 0.0
(clk2 - 6.0) <= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := clk2
v' := v
clk0' := 1.0
clk1' := clk1
clk3' := clk3
u' := u
duration' := duration
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_14 -> mode_11
guard {
(clk2 - 6.0) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
v' := v
clk3' := clk3
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_15 -> mode_12
guard {
(clk0 - 5.0) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
v' := v
clk1' := 0.0
clk3' := clk3
u' := u
duration' := duration
gClk' := gClk
clk4' := clk4
}
parallelotope aggregation { }

mode_7 -> mode_9
guard {
(clk2 - 6.0) <= 0.0
(clk0 - 1.0) >= 0.0
(clk1 - 1.0) >= 0.0
(gClk - 90.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
v' := v
clk3' := clk3
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_7 -> mode_10
guard {
(clk1 - 1.0) <= 0.0
(clk2 - 6.0) <= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := clk2
clk3' := 0.0
v' := v
clk0' := 1.0
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_3 -> mode_10
guard {
(clk2 - 6.0) >= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := 6.0
clk3' := 0.0
v' := v
clk0' := 1.0
clk1' := 0.0
u' := u
duration' := duration
gClk' := gClk
clk4' := clk4
}
parallelotope aggregation { }

mode_10 -> mode_5
guard {
(clk3 - 10.0) <= 0.0
(clk2 - 6.0) >= 0.0
(clk0 - 5.0) <= 0.0
}
reset {
clk2' := 6.0
clk0' := clk0
v' := v
clk1' := clk1
clk3' := clk3
u' := u
duration' := duration
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_13 -> mode_4
guard {
(clk2 - 6.0) <= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := clk2
clk3' := 0.0
v' := v
clk0' := 1.0
clk1' := 0.0
u' := u
duration' := duration
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_0 -> mode_4
guard {
(clk1 - 1.0) <= 0.0
(clk2 - 6.0) <= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := clk2
v' := v
clk0' := 1.0
clk1' := clk1
clk3' := clk3
u' := u
duration' := duration
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_7 -> mode_4
guard {
(clk1 - 1.0) <= 0.0
(clk2 - 6.0) <= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := clk2
clk3' := 0.0
v' := v
clk0' := 1.0
clk1' := clk1
u' := u
duration' := duration
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_14 -> mode_5
guard {
(clk3 - 10.0) <= 0.0
(clk2 - 6.0) >= 0.0
(clk0 - 1.0) >= 0.0
(clk1 - 1.0) <= 0.0
}
reset {
clk2' := 6.0
v' := v
clk0' := 1.0
clk1' := clk1
clk3' := clk3
u' := u
duration' := duration
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_8 -> mode_0
guard {
(clk2 - 6.0) <= 0.0
(clk0 - 5.0) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
v' := v
clk1' := clk1
clk3' := clk3
u' := u
duration' := duration
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_14 -> mode_6
guard {
(clk2 - 6.0) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
v' := v
clk3' := clk3
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_5 -> mode_9
guard {
(clk0 - 1.0) >= 0.0
(clk1 - 1.0) >= 0.0
(clk4 - 6.0) >= 0.0
(clk2 - 6.0) <= 0.0
(gClk - 90.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
v' := v
clk3' := clk3
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_5 -> mode_14
guard {
(clk1 - 1.0) <= 0.0
(clk2 - 6.0) >= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := 6.0
clk3' := 0.0
v' := v
clk0' := 1.0
clk1' := clk1
u' := u
duration' := duration
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_12 -> mode_7
guard {
(clk0 - 5.0) <= 0.0
}
reset {
clk0' := clk0
v' := v
clk3' := clk3
clk2' := 0.0
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_7 -> mode_14
guard {
(clk1 - 1.0) <= 0.0
(clk2 - 6.0) <= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := clk2
clk3' := 0.0
v' := v
clk0' := 1.0
clk1' := clk1
u' := u
duration' := duration
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_6 -> mode_11
guard {
(clk2 - 6.0) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
v' := v
clk3' := clk3
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_0 -> mode_14
guard {
(clk1 - 1.0) <= 0.0
(clk2 - 6.0) <= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := clk2
v' := v
clk0' := 1.0
clk1' := clk1
clk3' := clk3
u' := u
duration' := duration
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_2 -> mode_13
guard {
}
reset {
u' := u
v' := v
clk3' := clk3
clk0' := 0.0
clk2' := 0.0
gClk' := 0.0
duration' := duration
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_5 -> mode_11
guard {
(clk3 - 10.0) >= 0.0
(clk2 - 6.0) >= 0.0
(clk0 - 1.0) >= 0.0
(clk1 - 1.0) >= 0.0
}
reset {
clk2' := 6.0
clk0' := clk0
clk3' := 0.0
v' := v
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_0 -> mode_11
guard {
(clk2 - 6.0) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
v' := v
clk3' := clk3
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_3 -> mode_5
guard {
(clk2 - 6.0) >= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := 6.0
clk3' := 0.0
v' := v
clk0' := 1.0
clk1' := 0.0
u' := u
duration' := duration
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_11 -> mode_9
guard {
(clk2 - 6.0) >= 0.0
(gClk - 90.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
v' := v
clk3' := clk3
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_14 -> mode_10
guard {
(clk3 - 10.0) <= 0.0
(clk2 - 6.0) >= 0.0
(clk0 - 1.0) >= 0.0
(clk1 - 1.0) <= 0.0
}
reset {
clk2' := 6.0
v' := v
clk0' := 1.0
clk3' := clk3
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_5 -> mode_11
guard {
(clk0 - 1.0) >= 0.0
(clk1 - 1.0) >= 0.0
(clk3 - 10.0) >= 0.0
(clk2 - 6.0) <= 0.0
(clk2 - 6.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
clk3' := 0.0
v' := v
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_14 -> mode_11
guard {
(clk2 - 6.0) >= 0.0
}
reset {
clk2' := 6.0
clk0' := clk0
clk3' := 0.0
v' := v
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_7 -> mode_0
guard {
(clk1 - 1.0) <= 0.0
(clk2 - 6.0) <= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := clk2
clk3' := 0.0
v' := v
clk0' := 1.0
clk1' := clk1
u' := u
duration' := duration
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_0 -> mode_10
guard {
(clk1 - 1.0) <= 0.0
(clk2 - 6.0) <= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := clk2
v' := v
clk0' := 1.0
clk3' := clk3
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_14 -> mode_4
guard {
(clk1 - 1.0) <= 0.0
(clk2 - 6.0) <= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := clk2
v' := v
clk0' := 1.0
clk1' := clk1
clk3' := clk3
u' := u
duration' := duration
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_5 -> mode_9
guard {
(clk0 - 1.0) >= 0.0
(clk1 - 1.0) >= 0.0
(clk4 - 6.0) >= 0.0
(gClk - 90.0) >= 0.0
(clk2 - 6.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
v' := v
clk3' := clk3
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_14 -> mode_10
guard {
(clk1 - 1.0) <= 0.0
(clk2 - 6.0) >= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := 6.0
clk3' := 0.0
v' := v
clk0' := 1.0
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_14 -> mode_8
guard {
(clk1 - 1.0) <= 0.0
(clk2 - 6.0) <= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := clk2
v' := v
clk0' := 1.0
clk3' := clk3
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_5 -> mode_0
guard {
(clk1 - 1.0) <= 0.0
(clk2 - 6.0) <= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := clk2
clk3' := 0.0
v' := v
clk0' := 1.0
clk1' := clk1
u' := u
duration' := duration
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_10 -> mode_14
guard {
(clk3 - 10.0) <= 0.0
(clk2 - 6.0) >= 0.0
(clk0 - 5.0) <= 0.0
}
reset {
clk2' := 6.0
clk0' := clk0
v' := v
clk1' := clk1
clk3' := clk3
u' := u
duration' := duration
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_14 -> mode_0
guard {
(clk1 - 1.0) <= 0.0
(clk2 - 6.0) <= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := clk2
v' := v
clk0' := 1.0
clk1' := clk1
clk3' := clk3
u' := u
duration' := duration
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_15 -> mode_7
guard {
(clk0 - 5.0) <= 0.0
}
reset {
clk0' := clk0
v' := v
clk1' := 0.0
clk3' := clk3
clk2' := 0.0
u' := u
duration' := duration
gClk' := gClk
clk4' := clk4
}
parallelotope aggregation { }

mode_7 -> mode_5
guard {
(clk1 - 1.0) <= 0.0
(clk2 - 6.0) <= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := clk2
clk3' := 0.0
v' := v
clk0' := 1.0
clk1' := clk1
u' := u
duration' := duration
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_13 -> mode_8
guard {
(clk2 - 6.0) <= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := clk2
clk3' := 0.0
v' := v
clk0' := 1.0
clk1' := 0.0
u' := u
duration' := duration
gClk' := gClk
clk4' := clk4
}
parallelotope aggregation { }

mode_14 -> mode_10
guard {
(clk1 - 1.0) <= 0.0
(clk2 - 6.0) <= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := clk2
v' := v
clk0' := 1.0
clk3' := clk3
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_1 -> mode_9
guard {
(clk2 - 6.0) >= 0.0
(clk0 - 1.0) >= 0.0
(clk1 - 1.0) >= 0.0
(gClk - 90.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
v' := v
clk3' := clk3
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_14 -> mode_11
guard {
(clk3 - 10.0) <= 0.0
(clk2 - 6.0) >= 0.0
}
reset {
clk2' := 6.0
clk0' := clk0
v' := v
clk3' := clk3
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_1 -> mode_5
guard {
(clk1 - 1.0) <= 0.0
(clk2 - 6.0) >= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := 6.0
clk3' := 0.0
v' := v
clk0' := 1.0
clk1' := clk1
u' := u
duration' := duration
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_8 -> mode_4
guard {
(clk2 - 6.0) <= 0.0
(clk0 - 5.0) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
v' := v
clk1' := clk1
clk3' := clk3
u' := u
duration' := duration
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_10 -> mode_12
guard {
(clk3 - 10.0) >= 0.0
(clk2 - 6.0) >= 0.0
(clk0 - 5.0) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
v' := v
clk3' := clk3
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_12 -> mode_1
guard {
(clk0 - 5.0) <= 0.0
}
reset {
clk0' := clk0
v' := v
clk3' := clk3
clk2' := 0.0
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_7 -> mode_6
guard {
(clk2 - 6.0) <= 0.0
(clk0 - 1.0) >= 0.0
(clk1 - 1.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
clk3' := 0.0
v' := v
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_10 -> mode_1
guard {
(clk3 - 10.0) >= 0.0
(clk2 - 6.0) >= 0.0
(clk0 - 5.0) <= 0.0
}
reset {
clk0' := clk0
v' := v
clk3' := clk3
clk2' := 0.0
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_1 -> mode_14
guard {
(clk1 - 1.0) <= 0.0
(clk2 - 6.0) >= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := 6.0
clk3' := 0.0
v' := v
clk0' := 1.0
clk1' := clk1
u' := u
duration' := duration
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_2 -> mode_3
guard {
}
reset {
u' := u
v' := v
clk3' := clk3
clk0' := 0.0
clk2' := 0.0
gClk' := 0.0
duration' := duration
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_5 -> mode_9
guard {
(clk0 - 1.0) >= 0.0
(clk1 - 1.0) >= 0.0
(gClk - 90.0) >= 0.0
(clk2 - 6.0) >= 0.0
(clk4 - 6.0) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
v' := v
clk3' := clk3
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_5 -> mode_9
guard {
(clk0 - 1.0) >= 0.0
(clk1 - 1.0) >= 0.0
(clk4 - 6.0) >= 0.0
(clk3 - 10.0) >= 0.0
(gClk - 90.0) >= 0.0
(clk2 - 6.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
v' := v
clk3' := clk3
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_5 -> mode_14
guard {
(clk1 - 1.0) <= 0.0
(clk2 - 6.0) <= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := clk2
clk3' := 0.0
v' := v
clk0' := 1.0
clk1' := clk1
u' := u
duration' := duration
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_8 -> mode_5
guard {
(clk2 - 6.0) <= 0.0
(clk0 - 5.0) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
v' := v
clk1' := clk1
clk3' := clk3
u' := u
duration' := duration
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_11 -> mode_9
guard {
(clk3 - 10.0) >= 0.0
(clk2 - 6.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
v' := v
clk3' := clk3
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_1 -> mode_10
guard {
(clk1 - 1.0) <= 0.0
(clk2 - 6.0) >= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := 6.0
clk3' := 0.0
v' := v
clk0' := 1.0
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_13 -> mode_0
guard {
(clk2 - 6.0) <= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := clk2
clk3' := 0.0
v' := v
clk0' := 1.0
clk1' := 0.0
u' := u
duration' := duration
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_5 -> mode_9
guard {
(clk0 - 1.0) >= 0.0
(clk1 - 1.0) >= 0.0
(clk3 - 10.0) >= 0.0
(gClk - 90.0) >= 0.0
(clk2 - 6.0) >= 0.0
(clk4 - 6.0) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
v' := v
clk3' := clk3
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }

mode_8 -> mode_14
guard {
(clk2 - 6.0) <= 0.0
(clk0 - 5.0) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
v' := v
clk1' := clk1
clk3' := clk3
u' := u
duration' := duration
clk4' := 0.0
gClk' := gClk
}
parallelotope aggregation { }

mode_7 -> mode_8
guard {
(clk1 - 1.0) <= 0.0
(clk2 - 6.0) <= 0.0
(clk0 - 1.0) >= 0.0
}
reset {
clk2' := clk2
clk3' := 0.0
v' := v
clk0' := 1.0
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
clk4' := clk4
}
parallelotope aggregation { }
 
 }

 init {
 mode_2 {clk4 in [0.0, 0.0]
v in [0, 0.01]
ff in [1.0, 1.0]
clk0 in [0.0, 0.0]
gClk in [0.0, 0.0]
duration in [0, 0.01]
u in [0, 0.01]
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
mode_9{}
mode_10{ ff >= 10 }
mode_11{ ff >= 10 }
mode_12{ ff >= 10 }
mode_13{ ff >= 10 }
mode_14{ ff >= 10 }
mode_15{ ff >= 10 }
 
 }
