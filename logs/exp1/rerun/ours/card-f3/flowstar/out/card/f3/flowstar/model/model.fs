hybrid reachability {
 state var ff, clk0, gClk, duration, v, clk1, u
 setting {
 adaptive steps {min 0.0001, max 0.0005}
time 60
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
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
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
mode_1{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
u' = (((((((-0.9) * u) * u) - ((u * u) * u)) - (0.9 * u)) - v) + 1)
duration' = 1
v' = (u - (2 * v))
ff' = 0.0
}
inv {
(gClk - 90.0) <= 0.0
(u - 10) <= 0.0
(v - 10) <= 0.0
(-10 - u) <= 0.0
(gClk - 0.0) >= 0.0
(duration - 5) <= 0.0
(-10 - v) <= 0.0
(duration - 10) <= 0.0
(0 - duration) <= 0.0
(duration - (10.0 + 0.1)) <= 0.0
}
}
mode_2{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
u' = (((((((-0.9) * u) * u) - ((u * u) * u)) - (0.9 * u)) - v) + 1)
duration' = 1
v' = (u - (2 * v))
ff' = 0.0
}
inv {
(u - (10.0 - 0.1)) >= 0.0
(gClk - 90.0) <= 0.0
(u - 10) <= 0.0
(v - 10) <= 0.0
(-10 - u) <= 0.0
(gClk - 0.0) >= 0.0
(duration - 5) <= 0.0
(-10 - v) <= 0.0
(duration - 10) <= 0.0
(0 - duration) <= 0.0
(duration - (10.0 + 0.1)) <= 0.0
}
}
mode_3{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
u' = (((((((-0.9) * u) * u) - ((u * u) * u)) - (0.9 * u)) - v) + 1)
duration' = 1
v' = (u - (2 * v))
ff' = 0.0
}
inv {
(gClk - 90.0) <= 0.0
(u - 10) <= 0.0
(v - 10) <= 0.0
(-10 - u) <= 0.0
(gClk - 0.0) >= 0.0
(duration - 5) <= 0.0
(-10 - v) <= 0.0
(duration - 10) <= 0.0
(0 - duration) <= 0.0
(duration - (10.0 + 0.1)) <= 0.0
}
}
mode_4{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
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
mode_5{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
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
mode_6{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
u' = (((((((-0.9) * u) * u) - ((u * u) * u)) - (0.9 * u)) - v) + 1)
duration' = 1
v' = (u - (2 * v))
ff' = 0.0
}
inv {
(gClk - 90.0) <= 0.0
(u - 10) <= 0.0
(v - 10) <= 0.0
(-10 - u) <= 0.0
(gClk - 0.0) >= 0.0
(duration - 5) <= 0.0
(-10 - v) <= 0.0
(duration - 10) <= 0.0
(0 - duration) <= 0.0
(duration - (10.0 + 0.1)) <= 0.0
}
}
mode_7{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
u' = (((((((-0.9) * u) * u) - ((u * u) * u)) - (0.9 * u)) - v) + 1)
duration' = 1
v' = (u - (2 * v))
ff' = 0.0
}
inv {
(gClk - 90.0) <= 0.0
(u - 10) <= 0.0
(v - 10) <= 0.0
(-10 - u) <= 0.0
(gClk - 0.0) >= 0.0
(duration - 5) <= 0.0
(-10 - v) <= 0.0
(duration - 10) <= 0.0
(0 - duration) <= 0.0
(duration - (10.0 + 0.1)) <= 0.0
}
}
mode_8{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
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
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
u' = (((((((-0.9) * u) * u) - ((u * u) * u)) - (0.9 * u)) - v) + 1)
duration' = 1
v' = (u - (2 * v))
ff' = 0.0
}
inv {
(u - (10.0 - 0.1)) >= 0.0
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
nonpoly ode
{duration' = 0.0
v' = 0.0
u' = 0.0
clk0' = 0.0
gClk' = 1.0
clk1' = 0.0
ff' = 0.0
}
inv {
(gClk - 0.0) >= 0.0
(gClk - 90.0) <= 0.0
}
}
mode_11{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
u' = (((((((-0.9) * u) * u) - ((u * u) * u)) - (0.9 * u)) - v) + 1)
duration' = 1
v' = (u - (2 * v))
ff' = 0.0
}
inv {
(gClk - 90.0) <= 0.0
(u - 10) <= 0.0
(v - 10) <= 0.0
(-10 - u) <= 0.0
(gClk - 0.0) >= 0.0
(duration - 5) <= 0.0
(-10 - v) <= 0.0
(duration - 10) <= 0.0
(0 - duration) <= 0.0
(duration - (10.0 + 0.1)) <= 0.0
}
}
mode_12{
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
u' = (((((((-0.9) * u) * u) - ((u * u) * u)) - (0.9 * u)) - v) + 1)
duration' = 1
v' = (u - (2 * v))
ff' = 0.0
}
inv {
(u - (10.0 - 0.1)) >= 0.0
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
nonpoly ode
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
u' = (((((((-0.9) * u) * u) - ((u * u) * u)) - (0.9 * u)) - v) + 1)
duration' = 1
v' = (u - (2 * v))
ff' = 0.0
}
inv {
(u - (10.0 - 0.1)) >= 0.0
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
 mode_1 -> mode_5
guard {
(clk1 - 15.0) >= 0.0
(clk0 - 5.0) >= 0.0
}
reset {
clk0' := clk0
v' := v
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_2 -> mode_7
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
clk0' := clk0
v' := v
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_2 -> mode_5
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(gClk - 90.0) >= 0.0
}
reset {
clk0' := clk0
v' := v
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_6 -> mode_7
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
clk0' := clk0
v' := v
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_8 -> mode_5
guard {
(gClk - 90.0) >= 0.0
(clk0 - 5.0) <= 0.0
}
reset {
clk0' := clk0
v' := v
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_10 -> mode_4
guard {
}
reset {
u' := u
v' := v
clk0' := 0.0
gClk' := 0.0
duration' := duration
clk1' := clk1
}
parallelotope aggregation { }

mode_7 -> mode_5
guard {
(gClk - 90.0) >= 0.0
}
reset {
clk0' := clk0
v' := v
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_10 -> mode_3
guard {
}
reset {
u' := u
v' := v
clk0' := 0.0
gClk' := 0.0
duration' := duration
clk1' := clk1
}
parallelotope aggregation { }

mode_11 -> mode_12
guard {
}
reset {
clk0' := clk0
v' := v
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_6 -> mode_12
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
clk0' := clk0
v' := v
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_8 -> mode_1
guard {
(clk0 - 5.0) <= 0.0
}
reset {
clk0' := clk0
v' := v
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_7 -> mode_12
guard {
}
reset {
clk0' := clk0
v' := v
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_4 -> mode_5
guard {
(gClk - 90.0) >= 0.0
(clk0 - 5.0) <= 0.0
}
reset {
clk0' := clk0
v' := v
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_11 -> mode_7
guard {
}
reset {
clk0' := clk0
v' := v
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_3 -> mode_1
guard {
(clk0 - 5.0) >= 0.0
}
reset {
v' := v
clk1' := 0.0
clk0' := 5.0
u' := u
duration' := duration
gClk' := gClk
}
parallelotope aggregation { }

mode_6 -> mode_12
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(gClk - 90.0) >= 0.0
}
reset {
clk0' := clk0
v' := v
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_9 -> mode_6
guard {
(clk0 - 0.0) >= 0.0
}
reset {
v' := v
clk1' := 0.0
clk0' := 0.0
u' := u
duration' := duration
gClk' := gClk
}
parallelotope aggregation { }

mode_0 -> mode_13
guard {
(clk0 - 5.0) <= 0.0
}
reset {
clk0' := clk0
v' := v
clk1' := 0.0
u' := u
duration' := duration
gClk' := gClk
}
parallelotope aggregation { }

mode_2 -> mode_12
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
clk0' := clk0
v' := v
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_4 -> mode_8
guard {
(clk0 - 5.0) <= 0.0
}
reset {
clk0' := clk0
v' := v
clk1' := 0.0
u' := u
duration' := duration
gClk' := gClk
}
parallelotope aggregation { }

mode_10 -> mode_0
guard {
}
reset {
u' := u
v' := v
clk0' := 0.0
gClk' := 0.0
duration' := duration
clk1' := clk1
}
parallelotope aggregation { }

mode_12 -> mode_5
guard {
}
reset {
clk0' := clk0
v' := v
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_9 -> mode_5
guard {
}
reset {
clk0' := clk0
v' := v
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_10 -> mode_11
guard {
}
reset {
u' := u
v' := v
clk0' := 0.0
gClk' := 0.0
duration' := duration
clk1' := clk1
}
parallelotope aggregation { }

mode_11 -> mode_2
guard {
(clk0 - 0.0) >= 0.0
}
reset {
v' := v
clk1' := 0.0
clk0' := 0.0
u' := u
duration' := duration
gClk' := gClk
}
parallelotope aggregation { }

mode_13 -> mode_5
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
clk0' := clk0
v' := v
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_1 -> mode_5
guard {
(gClk - 90.0) >= 0.0
(clk0 - 5.0) >= 0.0
}
reset {
clk0' := clk0
v' := v
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_11 -> mode_6
guard {
(clk0 - 0.0) >= 0.0
}
reset {
v' := v
clk1' := 0.0
clk0' := 0.0
u' := u
duration' := duration
gClk' := gClk
}
parallelotope aggregation { }

mode_4 -> mode_1
guard {
(clk0 - 5.0) <= 0.0
}
reset {
clk0' := clk0
v' := v
clk1' := 0.0
u' := u
duration' := duration
gClk' := gClk
}
parallelotope aggregation { }

mode_11 -> mode_13
guard {
(clk0 - 0.0) >= 0.0
}
reset {
v' := v
clk1' := 0.0
clk0' := 0.0
u' := u
duration' := duration
gClk' := gClk
}
parallelotope aggregation { }

mode_6 -> mode_7
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(gClk - 90.0) >= 0.0
}
reset {
clk0' := clk0
v' := v
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_3 -> mode_5
guard {
(gClk - 90.0) >= 0.0
(clk0 - 5.0) >= 0.0
}
reset {
clk0' := clk0
v' := v
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_9 -> mode_13
guard {
(clk0 - 0.0) >= 0.0
}
reset {
v' := v
clk1' := 0.0
clk0' := 0.0
u' := u
duration' := duration
gClk' := gClk
}
parallelotope aggregation { }

mode_6 -> mode_5
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(gClk - 90.0) >= 0.0
}
reset {
clk0' := clk0
v' := v
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_0 -> mode_6
guard {
(clk0 - 5.0) <= 0.0
}
reset {
clk0' := clk0
v' := v
clk1' := 0.0
u' := u
duration' := duration
gClk' := gClk
}
parallelotope aggregation { }

mode_10 -> mode_9
guard {
}
reset {
u' := u
v' := v
clk0' := 0.0
gClk' := 0.0
duration' := duration
clk1' := clk1
}
parallelotope aggregation { }

mode_11 -> mode_5
guard {
(gClk - 90.0) >= 0.0
}
reset {
clk0' := clk0
v' := v
u' := u
duration' := duration
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }
 
 }

 init {
 mode_10 {ff in [1.0, 1.0]
clk0 in [0.0, 0.0]
gClk in [0.0, 0.0]
duration in [0, 0.01]
v in [0, 0.01]
clk1 in [0.0, 0.0]
u in [0, 0.01]
}

}

}
 unsafe {
 mode_0{ ff >= 10 }
mode_1{ ff >= 10 }
mode_2{ ff >= 10 }
mode_3{ ff >= 10 }
mode_4{ ff >= 10 }
mode_5{}
mode_6{ ff >= 10 }
mode_7{ ff >= 10 }
mode_8{ ff >= 10 }
mode_9{ ff >= 10 }
mode_10{ ff >= 10 }
mode_11{ ff >= 10 }
mode_12{ ff >= 10 }
mode_13{ ff >= 10 }
 
 }
