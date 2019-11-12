all: w1e1
w1e1: build/w1e1.exe
build/w1e1.exe: w1e1/Program.cs
	mcs w1e1/Program.cs -out:build/w1e1.exe
