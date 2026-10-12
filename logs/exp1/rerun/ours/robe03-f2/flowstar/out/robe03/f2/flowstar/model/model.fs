hybrid reachability {
 state var x, ff, clk0, gClk, y, z, clk1
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
z' = ((10000000 * y) * y)
y' = (((0.4 * x) - ((100 * y) * z)) - ((10000000 * y) * y))
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
mode_1{
poly ode 2
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
z' = ((10000000 * y) * y)
y' = (((0.4 * x) - ((100 * y) * z)) - ((10000000 * y) * y))
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
z' = ((10000000 * y) * y)
y' = (((0.4 * x) - ((100 * y) * z)) - ((10000000 * y) * y))
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
mode_3{
poly ode 2
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
z' = ((10000000 * y) * y)
y' = (((0.4 * x) - ((100 * y) * z)) - ((10000000 * y) * y))
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
mode_4{
poly ode 2
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
z' = ((10000000 * y) * y)
y' = (((0.4 * x) - ((100 * y) * z)) - ((10000000 * y) * y))
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
mode_5{
poly ode 2
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
z' = ((10000000 * y) * y)
y' = (((0.4 * x) - ((100 * y) * z)) - ((10000000 * y) * y))
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
mode_6{
poly ode 2
{x' = 0.0
y' = 0.0
z' = 0.0
clk0' = 0.0
gClk' = 1.0
clk1' = 0.0
ff' = 0.0
}
inv {
(gClk - 0.0) >= 0.0
(gClk - 40.0) <= 0.0
}
}
mode_7{
poly ode 2
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
z' = ((10000000 * y) * y)
y' = (((0.4 * x) - ((100 * y) * z)) - ((10000000 * y) * y))
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
mode_8{
poly ode 2
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
z' = ((10000000 * y) * y)
y' = (((0.4 * x) - ((100 * y) * z)) - ((10000000 * y) * y))
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
mode_9{
poly ode 2
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
z' = ((10000000 * y) * y)
y' = (((0.4 * x) - ((100 * y) * z)) - ((10000000 * y) * y))
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
z' = ((10000000 * y) * y)
y' = (((0.4 * x) - ((100 * y) * z)) - ((10000000 * y) * y))
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
mode_11{
poly ode 2
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
z' = ((10000000 * y) * y)
y' = (((0.4 * x) - ((100 * y) * z)) - ((10000000 * y) * y))
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
mode_12{
poly ode 2
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
z' = ((10000000 * y) * y)
y' = (((0.4 * x) - ((100 * y) * z)) - ((10000000 * y) * y))
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
mode_13{
poly ode 2
{clk1' = 1.0
gClk' = 1.0
clk0' = 1.0
z' = ((10000000 * y) * y)
y' = (((0.4 * x) - ((100 * y) * z)) - ((10000000 * y) * y))
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
}

 jumps {
 mode_12 -> mode_3
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(gClk - 40.0) >= 0.0
}
reset {
clk0' := clk0
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_7 -> mode_3
guard {
(clk0 - 1.0) <= 0.0
(gClk - 40.0) >= 0.0
}
reset {
clk0' := clk0
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_11 -> mode_12
guard {
(clk0 - 0.0) >= 0.0
}
reset {
z' := z
y' := y
clk1' := 0.0
clk0' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_5 -> mode_4
guard {
(clk0 - 1.0) <= 0.0
}
reset {
clk0' := clk0
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_10 -> mode_3
guard {
(gClk - 40.0) >= 0.0
}
reset {
clk0' := clk0
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_10 -> mode_8
guard {
}
reset {
clk0' := clk0
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_11 -> mode_13
guard {
(clk0 - 0.0) >= 0.0
}
reset {
z' := z
y' := y
clk1' := 0.0
clk0' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_5 -> mode_3
guard {
(clk0 - 1.0) <= 0.0
(gClk - 40.0) >= 0.0
}
reset {
clk0' := clk0
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_6 -> mode_2
guard {
}
reset {
z' := z
y' := y
clk0' := 0.0
x' := x
gClk' := 0.0
clk1' := clk1
}
parallelotope aggregation { }

mode_9 -> mode_3
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(gClk - 40.0) >= 0.0
}
reset {
clk0' := clk0
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_11 -> mode_3
guard {
(gClk - 40.0) >= 0.0
}
reset {
clk0' := clk0
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_11 -> mode_9
guard {
(clk0 - 0.0) >= 0.0
}
reset {
z' := z
y' := y
clk1' := 0.0
clk0' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_7 -> mode_4
guard {
(clk0 - 1.0) <= 0.0
}
reset {
clk0' := clk0
z' := z
y' := y
clk1' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_12 -> mode_8
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
clk0' := clk0
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_1 -> mode_13
guard {
(clk0 - 1.0) <= 0.0
}
reset {
clk0' := clk0
z' := z
y' := y
clk1' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_6 -> mode_11
guard {
}
reset {
z' := z
y' := y
clk0' := 0.0
x' := x
gClk' := 0.0
clk1' := clk1
}
parallelotope aggregation { }

mode_4 -> mode_3
guard {
(clk0 - 1.0) >= 0.0
(clk1 - 5.0) >= 0.0
}
reset {
clk0' := clk0
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_9 -> mode_10
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(gClk - 40.0) >= 0.0
}
reset {
clk0' := clk0
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_9 -> mode_8
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
(gClk - 40.0) >= 0.0
}
reset {
clk0' := clk0
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_6 -> mode_0
guard {
}
reset {
z' := z
y' := y
clk0' := 0.0
x' := x
gClk' := 0.0
clk1' := clk1
}
parallelotope aggregation { }

mode_9 -> mode_8
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
clk0' := clk0
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_6 -> mode_1
guard {
}
reset {
z' := z
y' := y
clk0' := 0.0
x' := x
gClk' := 0.0
clk1' := clk1
}
parallelotope aggregation { }

mode_8 -> mode_3
guard {
}
reset {
clk0' := clk0
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_0 -> mode_3
guard {
(clk0 - 1.0) >= 0.0
(gClk - 40.0) >= 0.0
}
reset {
clk0' := clk0
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_6 -> mode_7
guard {
}
reset {
z' := z
y' := y
clk0' := 0.0
x' := x
gClk' := 0.0
clk1' := clk1
}
parallelotope aggregation { }

mode_0 -> mode_4
guard {
(clk0 - 1.0) >= 0.0
}
reset {
z' := z
y' := y
clk0' := 1.0
clk1' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_13 -> mode_3
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
clk0' := clk0
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_2 -> mode_3
guard {
}
reset {
clk0' := clk0
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_11 -> mode_10
guard {
}
reset {
clk0' := clk0
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_12 -> mode_10
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
clk0' := clk0
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_2 -> mode_13
guard {
(clk0 - 0.0) >= 0.0
}
reset {
z' := z
y' := y
clk1' := 0.0
clk0' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_4 -> mode_3
guard {
(clk0 - 1.0) >= 0.0
(gClk - 40.0) >= 0.0
}
reset {
clk0' := clk0
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_7 -> mode_5
guard {
(clk0 - 1.0) <= 0.0
}
reset {
clk0' := clk0
z' := z
y' := y
clk1' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_11 -> mode_8
guard {
}
reset {
clk0' := clk0
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_1 -> mode_9
guard {
(clk0 - 1.0) <= 0.0
}
reset {
clk0' := clk0
z' := z
y' := y
clk1' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }

mode_9 -> mode_10
guard {
(clk0 - 0.0) >= 0.0
(clk1 - 0.0) >= 0.0
}
reset {
clk0' := clk0
z' := z
y' := y
x' := x
gClk' := gClk
clk1' := clk1
}
parallelotope aggregation { }

mode_2 -> mode_9
guard {
(clk0 - 0.0) >= 0.0
}
reset {
z' := z
y' := y
clk1' := 0.0
clk0' := 0.0
x' := x
gClk' := gClk
}
parallelotope aggregation { }
 
 }

 init {
 mode_6 {x in [1, 1]
ff in [1.0, 1.0]
clk0 in [0.0, 0.0]
gClk in [0.0, 0.0]
y in [0, 0]
z in [0, 0]
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
mode_5{ ff >= 10 }
mode_6{ ff >= 10 }
mode_7{ ff >= 10 }
mode_8{ ff >= 10 }
mode_9{ ff >= 10 }
mode_10{ ff >= 10 }
mode_11{ ff >= 10 }
mode_12{ ff >= 10 }
mode_13{ ff >= 10 }
 
 }
