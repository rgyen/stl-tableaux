hybrid reachability {
 state var x, ff, clk0, gClk, y, z, clk2, clk1
 setting {
 adaptive steps {min 0.00001, max 0.5}
time 20
remainder estimation 1e-8
identity precondition 
gnuplot octagon x,x fixed orders 15
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
(y - (2.0 + 0.5)) <= 0.0
(y - 10) <= 0.0
}
}
mode_1{
poly ode 2
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
clk2' = 1.0
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
mode_2{
poly ode 2
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
clk2' = 1.0
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
mode_3{
poly ode 2
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
clk2' = 1.0
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
(z - (1.0 + 0.5)) <= 0.0
(z - 10) <= 0.0
(gClk - 0.0) >= 0.0
(y - 10) <= 0.0
}
}
mode_4{
poly ode 2
{x' = 0.0
y' = 0.0
z' = 0.0
clk0' = 0.0
gClk' = 1.0
clk2' = 0.0
clk1' = 0.0
ff' = 0.0
}
inv {
(gClk - 0.0) >= 0.0
(gClk - 40.0) <= 0.0
}
}
mode_5{
poly ode 2
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
clk2' = 1.0
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
(z - (1.0 + 0.5)) <= 0.0
(z - 10) <= 0.0
(gClk - 0.0) >= 0.0
(y - 10) <= 0.0
}
}
mode_6{
poly ode 2
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
clk2' = 1.0
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
mode_7{
poly ode 2
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
clk2' = 1.0
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
(y - (2.0 + 0.5)) <= 0.0
(y - 10) <= 0.0
}
}
mode_8{
poly ode 2
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
clk2' = 1.0
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
(z - (1.0 + 0.5)) <= 0.0
(-5 - x) <= 0.0
(z - 10) <= 0.0
(gClk - 0.0) >= 0.0
(y - (2.0 + 0.5)) <= 0.0
(y - 10) <= 0.0
}
}
mode_9{
poly ode 2
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
clk2' = 1.0
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
(z - (1.0 + 0.5)) <= 0.0
(z - 10) <= 0.0
(gClk - 0.0) >= 0.0
(y - 10) <= 0.0
}
}
mode_10{
poly ode 2
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
clk2' = 1.0
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
}

 jumps {
 mode_7 -> mode_5
guard {
(clk0 - 1.1) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_3 -> mode_1
guard {
(clk0 - 1.1) >= 0.0
(gClk - 40.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_7 -> mode_10
guard {
(clk0 - 1.1) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_3 -> mode_0
guard {
(clk0 - 1.1) >= 0.0
(gClk - 40.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_10 -> mode_5
guard {
(clk0 - 1.1) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_6 -> mode_0
guard {
(clk2 - 1.1) <= 0.0
(gClk - 40.0) >= 0.0
(clk0 - 1.1) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_9 -> mode_1
guard {
(clk0 - 1.1) >= 0.0
(gClk - 40.0) >= 0.0
(clk2 - 1.1) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_9 -> mode_1
guard {
(clk1 - 2.2) >= 0.0
(clk0 - 1.1) >= 0.0
(gClk - 40.0) >= 0.0
(clk2 - 1.1) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_9 -> mode_0
guard {
(clk2 - 1.1) <= 0.0
(clk0 - 1.1) >= 0.0
(gClk - 40.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_9 -> mode_0
guard {
(clk0 - 1.1) <= 0.0
(gClk - 40.0) >= 0.0
(clk2 - 1.1) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_9 -> mode_1
guard {
(clk0 - 1.1) <= 0.0
(gClk - 40.0) >= 0.0
(clk2 - 1.1) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_6 -> mode_1
guard {
(clk2 - 1.1) <= 0.0
(gClk - 40.0) >= 0.0
(clk0 - 1.1) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_3 -> mode_9
guard {
(clk0 - 1.1) >= 0.0
}
reset {
z' := z
y' := y
clk1' := 0.0
clk2' := 0.0
x' := x
clk0' := 1.1
gClk' := gClk
}
parallelotope aggregation { }

mode_9 -> mode_0
guard {
(clk1 - 2.2) >= 0.0
(clk0 - 1.1) >= 0.0
(gClk - 40.0) >= 0.0
(clk2 - 1.1) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_2 -> mode_7
guard {
(clk0 - 1.1) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
z' := z
y' := y
clk1' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_4 -> mode_0
guard {
}
reset {
clk0' := clk0
clk2' := clk2
z' := z
y' := y
x' := x
gClk' := 0.0
clk1' := clk1
}
parallelotope aggregation { }

mode_10 -> mode_1
guard {
(clk0 - 1.1) <= 0.0
(gClk - 40.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_5 -> mode_1
guard {
(clk1 - 2.2) >= 0.0
(clk0 - 1.1) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_9 -> mode_1
guard {
(clk2 - 1.1) <= 0.0
(clk0 - 1.1) >= 0.0
(gClk - 40.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_2 -> mode_9
guard {
(clk0 - 1.1) <= 0.0
}
reset {
clk0' := clk0
z' := z
y' := y
clk1' := 0.0
clk2' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_7 -> mode_1
guard {
(clk0 - 1.1) <= 0.0
(gClk - 40.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_2 -> mode_8
guard {
(clk0 - 1.1) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
z' := z
y' := y
clk1' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_8 -> mode_1
guard {
(clk0 - 1.1) >= 0.0
(gClk - 40.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_8 -> mode_1
guard {
(clk1 - 2.2) >= 0.0
(clk0 - 1.1) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_4 -> mode_3
guard {
}
reset {
clk2' := clk2
z' := z
y' := y
clk0' := 0.0
x' := x
gClk' := 0.0
clk1' := clk1
}
parallelotope aggregation { }

mode_2 -> mode_1
guard {
(clk0 - 1.1) <= 0.0
(gClk - 40.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_9 -> mode_8
guard {
(clk1 - 2.2) >= 0.0
(clk0 - 1.1) >= 0.0
}
reset {
clk2' := clk2
z' := z
y' := y
clk1' := 0.0
x' := x
clk0' := 1.1
gClk' := gClk
}
parallelotope aggregation { }

mode_9 -> mode_8
guard {
(clk1 - 2.2) >= 0.0
(clk0 - 1.1) >= 0.0
(clk0 - 1.1) <= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
z' := z
y' := y
clk1' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_9 -> mode_0
guard {
(clk0 - 1.1) >= 0.0
(gClk - 40.0) >= 0.0
(clk2 - 1.1) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_9 -> mode_1
guard {
(clk2 - 1.1) <= 0.0
(clk1 - 2.2) >= 0.0
(clk0 - 1.1) >= 0.0
(gClk - 40.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_5 -> mode_1
guard {
(clk0 - 1.1) >= 0.0
(gClk - 40.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_0 -> mode_1
guard {
}
reset {
clk0' := clk0
clk2' := clk2
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_3 -> mode_8
guard {
(clk0 - 1.1) >= 0.0
}
reset {
clk2' := clk2
z' := z
y' := y
clk1' := 0.0
x' := x
clk0' := 1.1
gClk' := gClk
}
parallelotope aggregation { }

mode_4 -> mode_2
guard {
}
reset {
clk2' := clk2
z' := z
y' := y
clk0' := 0.0
x' := x
gClk' := 0.0
clk1' := clk1
}
parallelotope aggregation { }

mode_9 -> mode_0
guard {
(clk2 - 1.1) <= 0.0
(clk1 - 2.2) >= 0.0
(clk0 - 1.1) >= 0.0
(gClk - 40.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_2 -> mode_0
guard {
(clk0 - 1.1) <= 0.0
(gClk - 40.0) >= 0.0
}
reset {
clk0' := clk0
clk2' := clk2
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_2 -> mode_6
guard {
(clk0 - 1.1) <= 0.0
}
reset {
clk0' := clk0
z' := z
y' := y
clk1' := 0.0
clk2' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_8 -> mode_5
guard {
(clk1 - 2.2) <= 0.0
(clk0 - 1.1) >= 0.0
}
reset {
clk2' := clk2
z' := z
y' := y
clk1' := clk1
x' := x
clk0' := 1.1
gClk' := gClk
}
parallelotope aggregation { }
 
 }

 init {
 mode_4 {x in [1, 1]
ff in [1.0, 1.0]
clk0 in [0.0, 0.0]
gClk in [0.0, 0.0]
y in [0, 0]
z in [0, 0]
clk2 in [0.0, 0.0]
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
mode_7{ ff >= 10 }
mode_8{ ff >= 10 }
mode_9{ ff >= 10 }
mode_10{ ff >= 10 }
 
 }
