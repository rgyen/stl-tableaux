hybrid reachability {
 state var ff, gClk, x, y
 setting {
 adaptive steps {min 0.001, max 0.5}
time 70
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
{y' = 0.0
x' = 0.0
gClk' = 1.0
ff' = 0.0
}
inv {
(gClk - 0.0) >= 0.0
(gClk - 100.0) <= 0.0
}
}
mode_1{
nonpoly ode
{gClk' = 1.0
y' = (-0.15 * ((((x * x) * y) + x) + y))
x' = (0.1 * y)
ff' = 0.0
}
inv {
(0 - x) <= 0.0
(0 - y) <= 0.0
(y - 100) <= 0.0
(x - (40 + 1.0)) <= 0.0
(gClk - 0.0) >= 0.0
(x - 100) <= 0.0
(gClk - 100.0) <= 0.0
}
}
mode_2{
nonpoly ode
{gClk' = 1.0
y' = (-0.15 * ((((x * x) * y) + x) + y))
x' = (0.1 * y)
ff' = 0.0
}
inv {
(0 - x) <= 0.0
(0 - y) <= 0.0
(y - 100) <= 0.0
(gClk - 0.0) >= 0.0
(x - 100) <= 0.0
(gClk - 100.0) <= 0.0
}
}
mode_3{
nonpoly ode
{gClk' = 1.0
y' = (-0.15 * ((((x * x) * y) + x) + y))
x' = (0.1 * y)
ff' = 0.0
}
inv {
(0 - x) <= 0.0
(0 - y) <= 0.0
(y - 100) <= 0.0
(y - (15 + 1.0)) <= 0.0
(gClk - 0.0) >= 0.0
(x - 100) <= 0.0
(gClk - 100.0) <= 0.0
}
}
}

 jumps {
 mode_0 -> mode_3
guard {
}
reset {
gClk' := 0.0
y' := y
x' := x
}
parallelotope aggregation { }

mode_1 -> mode_2
guard {
(gClk - 100.0) >= 0.0
}
reset {
y' := y
gClk' := gClk
x' := x
}
parallelotope aggregation { }

mode_0 -> mode_1
guard {
}
reset {
gClk' := 0.0
y' := y
x' := x
}
parallelotope aggregation { }

mode_3 -> mode_2
guard {
}
reset {
y' := y
gClk' := gClk
x' := x
}
parallelotope aggregation { }

mode_1 -> mode_3
guard {
}
reset {
y' := y
gClk' := gClk
x' := x
}
parallelotope aggregation { }
 
 }

 init {
 mode_0 {ff in [1.0, 1.0]
gClk in [0.0, 0.0]
x in [1, 1.2]
y in [1, 1.2]
}

}

}
 unsafe {
 mode_0{ ff >= 10 }
mode_1{ ff >= 10 }
mode_2{}
mode_3{ ff >= 10 }
 
 }
