hybrid reachability {
 state var ff, gClk, x, y, z
 setting {
 adaptive steps {min 0.00001, max 0.5}
time 20
remainder estimation 1e-8
identity precondition 
gnuplot octagon ff,ff fixed orders 15
cutoff 1e-13
precision 53
no output 
max jumps 1000
print on  
}

 modes {
 mode_0{
poly ode 2
{gClk' = 1.0
y' = (((0.4 * x) - ((100 * y) * z)) - ((100000 * y) * y))
z' = ((100000 * y) * y)
x' = (((100 * y) * z) - (0.4 * x))
ff' = 0.0
}
inv {
(-5 - y) <= 0.0
(gClk - 40.0) <= 0.0
(x - 10) <= 0.0
(-5 - z) <= 0.0
(-5 - x) <= 0.0
(z - 10) <= 0.0
(gClk - 0.0) >= 0.0
(y - 10) <= 0.0
}
}
mode_1{
poly ode 2
{x' = 0.0
y' = 0.0
z' = 0.0
gClk' = 1.0
ff' = 0.0
}
inv {
(gClk - 0.0) >= 0.0
(gClk - 40.0) <= 0.0
}
}
mode_2{
poly ode 2
{gClk' = 1.0
y' = (((0.4 * x) - ((100 * y) * z)) - ((100000 * y) * y))
z' = ((100000 * y) * y)
x' = (((100 * y) * z) - (0.4 * x))
ff' = 0.0
}
inv {
(-5 - y) <= 0.0
(gClk - 40.0) <= 0.0
(x - 10) <= 0.0
(-5 - z) <= 0.0
(-5 - x) <= 0.0
(x - (3.0 + 0.0005)) <= 0.0
(z - 10) <= 0.0
(gClk - 0.0) >= 0.0
(y - 10) <= 0.0
}
}
}

 jumps {
 mode_1 -> mode_2
guard {
}
reset {
gClk' := 0.0
y' := y
x' := x
z' := z
}
parallelotope aggregation { }

mode_2 -> mode_0
guard {
(gClk - 40.0) >= 0.0
}
reset {
y' := y
gClk' := gClk
x' := x
z' := z
}
parallelotope aggregation { }
 
 }

 init {
 mode_1 {ff in [1.0, 1.0]
gClk in [0.0, 0.0]
x in [1, 1]
y in [0, 0]
z in [0, 0]
}

}

}
 unsafe {
 mode_0{}
mode_1{ ff >= 10 }
mode_2{ ff >= 10 }
 
 }
