hybrid reachability {
 state var x, ff, clk0, gClk, y, clk2, clk1
 setting {
 adaptive steps {min 0.001, max 0.5}
time 70
remainder estimation 1e-8
identity precondition 
gnuplot octagon x,x fixed orders 8
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
gClk' = 1.0
clk0' = 1.0
clk2' = 1.0
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
(x - (8.0 + 1.0)) <= 0.0
}
}
mode_1{
poly ode 2
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
clk2' = 1.0
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
(x - (8.0 + 1.0)) <= 0.0
}
}
mode_2{
poly ode 2
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
clk2' = 1.0
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
(y - (12.0 + 1.0)) <= 0.0
(x - (8.0 + 1.0)) <= 0.0
}
}
mode_3{
poly ode 2
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
clk2' = 1.0
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
mode_4{
poly ode 2
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
clk2' = 1.0
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
(y - (12.0 + 1.0)) <= 0.0
(x - (8.0 + 1.0)) <= 0.0
}
}
mode_5{
poly ode 2
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
clk2' = 1.0
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
(x - (8.0 + 1.0)) <= 0.0
}
}
mode_6{
poly ode 2
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
clk2' = 1.0
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
mode_7{
poly ode 2
{y' = 0.0
x' = 0.0
clk0' = 0.0
gClk' = 1.0
clk2' = 0.0
clk1' = 0.0
ff' = 0.0
}
inv {
(gClk - 0.0) >= 0.0
(gClk - 100.0) <= 0.0
}
}
}

 jumps {
 mode_1 -> mode_2
guard {
(clk0 - 0.0) >= 0.0
}
reset {
y' := y
clk1' := 0.0
clk0' := 0.0
clk2' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_2 -> mode_3
guard {
(clk0 - 0.0) >= 0.0
(gClk - 100.0) >= 0.0
(clk2 - 0.0) <= 0.0
(clk1 - 40.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
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
clk2' := clk2
y' := y
clk1' := 0.0
clk0' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_1 -> mode_5
guard {
(clk0 - 0.0) >= 0.0
}
reset {
y' := y
clk1' := 0.0
clk0' := 0.0
clk2' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_2 -> mode_3
guard {
(clk0 - 0.0) >= 0.0
(gClk - 100.0) >= 0.0
(clk2 - 0.0) >= 0.0
(clk1 - 40.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_2 -> mode_3
guard {
(gClk - 100.0) >= 0.0
(clk0 - 0.0) <= 0.0
(clk2 - 0.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_2 -> mode_3
guard {
(clk0 - 0.0) >= 0.0
(gClk - 100.0) >= 0.0
(clk2 - 0.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_4 -> mode_3
guard {
(clk0 - 0.0) >= 0.0
(gClk - 100.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_1 -> mode_6
guard {
(clk0 - 0.0) >= 0.0
}
reset {
y' := y
clk1' := 0.0
clk0' := 0.0
clk2' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_0 -> mode_3
guard {
(clk0 - 0.0) >= 0.0
(gClk - 100.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_0 -> mode_3
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 40.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_7 -> mode_1
guard {
}
reset {
clk2' := clk2
y' := y
clk0' := 0.0
x' := x
gClk' := 0.0
clk1' := clk1
}
parallelotope aggregation { }

mode_7 -> mode_4
guard {
}
reset {
clk2' := clk2
y' := y
clk0' := 0.0
x' := x
gClk' := 0.0
clk1' := clk1
}
parallelotope aggregation { }

mode_2 -> mode_3
guard {
(clk0 - 0.0) >= 0.0
(gClk - 100.0) >= 0.0
(clk2 - 0.0) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }
 
 }

 init {
 mode_7 {x in [1, 1.2]
ff in [1.0, 1.0]
clk0 in [0.0, 0.0]
gClk in [0.0, 0.0]
y in [1, 1.2]
clk2 in [0.0, 0.0]
clk1 in [0.0, 0.0]
}

}

}
 unsafe {
 mode_0{ ff >= 10 }
mode_1{ ff >= 10 }
mode_2{ ff >= 10 }
mode_3{}
mode_4{ ff >= 10 }
mode_5{}
mode_6{}
mode_7{ ff >= 10 }
 
 }
