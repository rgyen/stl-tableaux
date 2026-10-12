hybrid reachability {
 state var ff, gClk, x
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
{gClk' = 1.0
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
{x' = 0.0
gClk' = 1.0
ff' = 0.0
}
inv {
(gClk - 0.0) >= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_2{
nonpoly ode
{gClk' = 1.0
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
mode_3{
nonpoly ode
{gClk' = 1.0
x' = (0.8 - ((0.01 * 4.43) * (sqrt (x))))
ff' = 0.0
}
inv {
(0 - x) <= 0.0
(x - 10) <= 0.0
(x - (0 + 0.001)) <= 0.0
(gClk - 0.0) >= 0.0
(x - 8) <= 0.0
(gClk - 8.0) <= 0.0
}
}
mode_4{
nonpoly ode
{gClk' = 1.0
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
mode_5{
nonpoly ode
{gClk' = 1.0
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
 mode_4 -> mode_3
guard {
}
reset {
gClk' := gClk
x' := x
}
parallelotope aggregation { }

mode_0 -> mode_3
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
x' := x
}
parallelotope aggregation { }

mode_2 -> mode_5
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
x' := x
}
parallelotope aggregation { }

mode_3 -> mode_5
guard {
}
reset {
gClk' := gClk
x' := x
}
parallelotope aggregation { }

mode_5 -> mode_2
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
x' := x
}
parallelotope aggregation { }

mode_4 -> mode_0
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 2) >= 0.0
}
reset {
gClk' := gClk
x' := x
}
parallelotope aggregation { }

mode_0 -> mode_4
guard {
(x - 10) <= 0.0
(0 - x) <= 0.0
(x - 5) <= 0.0
}
reset {
gClk' := gClk
x' := x
}
parallelotope aggregation { }

mode_1 -> mode_0
guard {
}
reset {
gClk' := 0.0
x' := x
}
parallelotope aggregation { }
 
 }

 init {
 mode_1 {ff in [1.0, 1.0]
gClk in [0.0, 0.0]
x in [4, 4.5]
}

}

}
 unsafe {
 mode_0{ ff >= 10 }
mode_1{ ff >= 10 }
mode_2{}
mode_3{ ff >= 10 }
mode_4{ ff >= 10 }
mode_5{}
 
 }
