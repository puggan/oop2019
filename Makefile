all: w1e1 w1e2 w1e3

w1e1: build/w1e1.exe
build/w1e1.exe: w1e1/w1e1.cs
	mcs w1e1/w1e1.cs -out:build/w1e1.exe

w1e2: build/w1e2.exe
build/w1e2.exe: w1e2/w1e2.cs
	mcs w1e2/w1e2.cs -out:build/w1e2.exe

w1e3: build/w1e3.exe
build/w1e3.exe: w1e3/w1e3.cs
	mcs w1e3/w1e3.cs -out:build/w1e3.exe
