hybrid reachability {
 state var x, ff, clk0, gClk, y, clk1
 setting {
 adaptive steps {min 0.001, max 0.5}
time 30
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
{y' = 0.0
x' = 0.0
clk0' = 0.0
gClk' = 1.0
clk1' = 0.0
ff' = 0.0
}
inv {
(gClk - 0.0) >= 0.0
(gClk - 50.0) <= 0.0
}
}
mode_1{
poly ode 2
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
x' = (0.1 * y)
y' = ((((0.2 * x) - (((0.1 * x) * x) * x)) - (0.02 * y)) + 0.01)
ff' = 0.0
}
inv {
(x - 1000) <= 0.0
(gClk - 50.0) <= 0.0
(-1000 - y) <= 0.0
(-1000 - x) <= 0.0
(gClk - 0.0) >= 0.0
(y - 1000) <= 0.0
}
}
mode_2{
poly ode 2
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
x' = (0.1 * y)
y' = ((((0.2 * x) - (((0.1 * x) * x) * x)) - (0.02 * y)) + 0.01)
ff' = 0.0
}
inv {
(x - 1000) <= 0.0
(gClk - 50.0) <= 0.0
(-1000 - y) <= 0.0
(-1000 - x) <= 0.0
(gClk - 0.0) >= 0.0
(y - 1000) <= 0.0
(x - (4.0 + 0.5)) <= 0.0
}
}
mode_3{
poly ode 2
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
x' = (0.1 * y)
y' = ((((0.2 * x) - (((0.1 * x) * x) * x)) - (0.02 * y)) + 0.01)
ff' = 0.0
}
inv {
(x - 1000) <= 0.0
(gClk - 50.0) <= 0.0
(-1000 - y) <= 0.0
(y - (6.0 + 0.5)) <= 0.0
(-1000 - x) <= 0.0
(gClk - 0.0) >= 0.0
(y - 1000) <= 0.0
}
}
mode_4{
poly ode 2
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
x' = (0.1 * y)
y' = ((((0.2 * x) - (((0.1 * x) * x) * x)) - (0.02 * y)) + 0.01)
ff' = 0.0
}
inv {
(x - 1000) <= 0.0
(gClk - 50.0) <= 0.0
(-1000 - y) <= 0.0
(-1000 - x) <= 0.0
(gClk - 0.0) >= 0.0
(y - 1000) <= 0.0
(x - (4.0 + 0.5)) <= 0.0
}
}
mode_5{
poly ode 2
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
x' = (0.1 * y)
y' = ((((0.2 * x) - (((0.1 * x) * x) * x)) - (0.02 * y)) + 0.01)
ff' = 0.0
}
inv {
(x - 1000) <= 0.0
(gClk - 50.0) <= 0.0
(-1000 - y) <= 0.0
(-1000 - x) <= 0.0
(gClk - 0.0) >= 0.0
(y - 1000) <= 0.0
}
}
mode_6{
poly ode 2
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
x' = (0.1 * y)
y' = ((((0.2 * x) - (((0.1 * x) * x) * x)) - (0.02 * y)) + 0.01)
ff' = 0.0
}
inv {
(x - 1000) <= 0.0
(gClk - 50.0) <= 0.0
(-1000 - y) <= 0.0
(-1000 - x) <= 0.0
(gClk - 0.0) >= 0.0
(y - 1000) <= 0.0
}
}
}

 jumps {
 mode_0 -> mode_5
guard {
}
reset {
y' := y
clk0' := 0.0
x' := x
gClk' := 0.0
clk1' := clk1
}
parallelotope aggregation { }

mode_4 -> mode_6
guard {
(clk1 - 10.0) <= 0.0
(clk0 - 10.0) >= 0.0
}
reset {
clk0' := 10.0
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_0 -> mode_3
guard {
}
reset {
clk0' := clk0
y' := y
x' := x
gClk' := 0.0
clk1' := clk1
}
parallelotope aggregation { }

mode_5 -> mode_4
guard {
(clk0 - 20.0) <= 0.0
}
reset {
clk0' := clk0
y' := y
clk1' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_6 -> mode_4
guard {
(clk0 - 20.0) <= 0.0
}
reset {
clk0' := clk0
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_2 -> mode_4
guard {
(clk0 - 10.0) >= 0.0
}
reset {
clk0' := 10.0
y' := y
clk1' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_3 -> mode_1
guard {
(gClk - 50.0) >= 0.0
}
reset {
clk0' := clk0
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_3 -> mode_5
guard {
}
reset {
y' := y
clk0' := 0.0
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_3 -> mode_2
guard {
}
reset {
y' := y
clk0' := 0.0
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_4 -> mode_1
guard {
(clk0 - 10.0) >= 0.0
(clk1 - 10.0) >= 0.0
}
reset {
clk0' := clk0
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_5 -> mode_6
guard {
(clk0 - 20.0) <= 0.0
}
reset {
clk0' := clk0
y' := y
clk1' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_2 -> mode_6
guard {
(clk0 - 10.0) >= 0.0
}
reset {
clk0' := 10.0
y' := y
clk1' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_0 -> mode_2
guard {
}
reset {
y' := y
clk0' := 0.0
x' := x
gClk' := 0.0
clk1' := clk1
}
parallelotope aggregation { }
 
 }

 init {
 mode_0 {x in [-0.5, -0.4]
ff in [1.0, 1.0]
clk0 in [0.0, 0.0]
gClk in [0.0, 0.0]
y in [-0.5, -0.4]
clk1 in [0.0, 0.0]
}

}

}
 unsafe {
 mode_0{ ff >= 10 }
mode_1{}
mode_2{ ff >= 10 }
mode_3{ ff >= 10 }
mode_4{ ff >= 10 }
mode_5{ ff >= 10 }
mode_6{ ff >= 10 }
 
 }
