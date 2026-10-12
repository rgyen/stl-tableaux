hybrid reachability {
 state var ff, gClk, x, y
 setting {
 adaptive steps {min 0.001, max 0.5}
time 2
remainder estimation 1e-8
identity precondition 
gnuplot octagon ff,ff fixed orders 8
cutoff 1e-13
precision 53
no output 
max jumps 1000
print on  
}

 modes {
 mode_0{
poly ode 2
{y' = 0.0
x' = 0.0
gClk' = 1.0
ff' = 0.0
}
inv {
(gClk - 0.0) >= 0.0
(gClk - 5.0) <= 0.0
}
}
mode_1{
poly ode 2
{gClk' = 1.0
y' = ((x * y) - y)
x' = ((3 * x) - ((3 * x) * y))
ff' = 0.0
}
inv {
(x - (0 + 1e-06)) <= 0.0
(y - 2) <= 0.0
(0 - x) <= 0.0
(0 - y) <= 0.0
((((x - 1) * (x - 1)) + ((y - 1) * (y - 1))) - (0.161 * 0.161)) >= 0.0
(x - 2) <= 0.0
(gClk - 0.0) >= 0.0
(gClk - 5.0) <= 0.0
}
}
mode_2{
poly ode 2
{gClk' = 1.0
y' = ((x * y) - y)
x' = ((3 * x) - ((3 * x) * y))
ff' = 0.0
}
inv {
(y - 2) <= 0.0
(0 - x) <= 0.0
(0 - y) <= 0.0
((((x - 1) * (x - 1)) + ((y - 1) * (y - 1))) - (0.161 * 0.161)) >= 0.0
(x - 2) <= 0.0
(gClk - 0.0) >= 0.0
(gClk - 5.0) <= 0.0
}
}
mode_3{
poly ode 2
{gClk' = 1.0
y' = ((x * y) - y)
x' = ((3 * x) - ((3 * x) * y))
ff' = 0.0
}
inv {
(y - 2) <= 0.0
(0 - x) <= 0.0
(0 - y) <= 0.0
((((x - 1) * (x - 1)) + ((y - 1) * (y - 1))) - (0.161 * 0.161)) <= 0.0
(x - 2) <= 0.0
(gClk - 0.0) >= 0.0
(y - (1 + 1e-06)) <= 0.0
(gClk - 5.0) <= 0.0
}
}
mode_4{
poly ode 2
{gClk' = 1.0
y' = ((x * y) - y)
x' = ((3 * x) - ((3 * x) * y))
ff' = 0.0
}
inv {
(y - 2) <= 0.0
(0 - x) <= 0.0
(0 - y) <= 0.0
((((x - 1) * (x - 1)) + ((y - 1) * (y - 1))) - (0.161 * 0.161)) <= 0.0
(x - 2) <= 0.0
(gClk - 0.0) >= 0.0
(gClk - 5.0) <= 0.0
}
}
mode_5{
poly ode 2
{gClk' = 1.0
y' = ((x * y) - y)
x' = ((3 * x) - ((3 * x) * y))
ff' = 0.0
}
inv {
(y - 2) <= 0.0
(0 - x) <= 0.0
(0 - y) <= 0.0
((((x - 1) * (x - 1)) + ((y - 1) * (y - 1))) - (0.161 * 0.161)) >= 0.0
(x - 2) <= 0.0
(gClk - 0.0) >= 0.0
(y - (1 + 1e-06)) <= 0.0
(gClk - 5.0) <= 0.0
}
}
}

 jumps {
 mode_3 -> mode_4
guard {
(gClk - 5.0) >= 0.0
}
reset {
y' := y
gClk' := gClk
x' := x
}
parallelotope aggregation { }

mode_5 -> mode_2
guard {
(gClk - 5.0) >= 0.0
}
reset {
y' := y
gClk' := gClk
x' := x
}
parallelotope aggregation { }

mode_5 -> mode_4
guard {
(y - 2) <= 0.0
(0 - x) <= 0.0
(0 - y) <= 0.0
(gClk - 5.0) >= 0.0
((((x - 1) * (x - 1)) + ((y - 1) * (y - 1))) - (0.161 * 0.161)) >= 0.0
(x - 2) <= 0.0
}
reset {
y' := y
gClk' := gClk
x' := x
}
parallelotope aggregation { }

mode_3 -> mode_5
guard {
(y - 2) <= 0.0
(0 - x) <= 0.0
(0 - y) <= 0.0
((((x - 1) * (x - 1)) + ((y - 1) * (y - 1))) - (0.161 * 0.161)) <= 0.0
(x - 2) <= 0.0
}
reset {
y' := y
gClk' := gClk
x' := x
}
parallelotope aggregation { }

mode_1 -> mode_4
guard {
(y - 2) <= 0.0
(0 - x) <= 0.0
(0 - y) <= 0.0
((((x - 1) * (x - 1)) + ((y - 1) * (y - 1))) - (0.161 * 0.161)) >= 0.0
(x - 2) <= 0.0
}
reset {
y' := y
gClk' := gClk
x' := x
}
parallelotope aggregation { }

mode_4 -> mode_2
guard {
(y - 2) <= 0.0
(0 - x) <= 0.0
(0 - y) <= 0.0
((((x - 1) * (x - 1)) + ((y - 1) * (y - 1))) - (0.161 * 0.161)) <= 0.0
(x - 2) <= 0.0
}
reset {
y' := y
gClk' := gClk
x' := x
}
parallelotope aggregation { }

mode_5 -> mode_3
guard {
(y - 2) <= 0.0
(0 - x) <= 0.0
(0 - y) <= 0.0
((((x - 1) * (x - 1)) + ((y - 1) * (y - 1))) - (0.161 * 0.161)) >= 0.0
(x - 2) <= 0.0
}
reset {
y' := y
gClk' := gClk
x' := x
}
parallelotope aggregation { }

mode_0 -> mode_5
guard {
}
reset {
gClk' := 0.0
y' := y
x' := x
}
parallelotope aggregation { }

mode_2 -> mode_4
guard {
(y - 2) <= 0.0
(0 - x) <= 0.0
(0 - y) <= 0.0
((((x - 1) * (x - 1)) + ((y - 1) * (y - 1))) - (0.161 * 0.161)) >= 0.0
(x - 2) <= 0.0
}
reset {
y' := y
gClk' := gClk
x' := x
}
parallelotope aggregation { }

mode_1 -> mode_2
guard {
}
reset {
y' := y
gClk' := gClk
x' := x
}
parallelotope aggregation { }

mode_5 -> mode_1
guard {
}
reset {
y' := y
gClk' := gClk
x' := x
}
parallelotope aggregation { }

mode_3 -> mode_2
guard {
(y - 2) <= 0.0
(0 - x) <= 0.0
(0 - y) <= 0.0
((((x - 1) * (x - 1)) + ((y - 1) * (y - 1))) - (0.161 * 0.161)) <= 0.0
(gClk - 5.0) >= 0.0
(x - 2) <= 0.0
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
 
 }

 init {
 mode_0 {ff in [1.0, 1.0]
gClk in [0.0, 0.0]
x in [1.288, 1.312]
y in [1, 1]
}

}

}
 unsafe {
 mode_0{ ff >= 10 }
mode_1{ ff >= 10 }
mode_2{}
mode_3{ ff >= 10 }
mode_4{}
mode_5{ ff >= 10 }
 
 }
