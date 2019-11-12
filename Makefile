all: w1e01 w1e02 w1e03 w1e04 w1e05 w1e06 w1e07 w1e08 w1e09 w1e10 w1e11 w1e12

w1e01: build/w1e01.exe
build/w1e01.exe: w1e01/w1e01.cs
	mcs w1e01/w1e01.cs -out:build/w1e01.exe

w1e02: build/w1e02.exe
build/w1e02.exe: w1e02/w1e02.cs
	mcs w1e02/w1e02.cs -out:build/w1e02.exe

w1e03: build/w1e03.exe
build/w1e03.exe: w1e03/w1e03.cs
	mcs w1e03/w1e03.cs -out:build/w1e03.exe

w1e04: build/w1e04.exe
build/w1e04.exe: w1e04/w1e04.cs
	mcs w1e04/w1e04.cs -out:build/w1e04.exe

w1e05: build/w1e05.exe
build/w1e05.exe: w1e05/w1e05.cs
	mcs w1e05/w1e05.cs -out:build/w1e05.exe

w1e06: build/w1e06.exe
build/w1e06.exe: w1e06/w1e06.cs
	mcs w1e06/w1e06.cs -out:build/w1e06.exe

w1e07: build/w1e07.exe
build/w1e07.exe: w1e07/w1e07.cs
	mcs w1e07/w1e07.cs -out:build/w1e07.exe

w1e08: build/w1e08.exe
build/w1e08.exe: w1e08/w1e08.cs
	mcs w1e08/w1e08.cs -out:build/w1e08.exe

w1e09: build/w1e09.exe
build/w1e09.exe: w1e09/w1e09.cs
	mcs w1e09/w1e09.cs -out:build/w1e09.exe

w1e10: build/w1e10.exe
build/w1e10.exe: w1e10/w1e10.cs w1e10/invader.cs
	mcs w1e10/w1e10.cs w1e10/invader.cs -out:build/w1e10.exe

w1e11: build/w1e11.exe
build/w1e11.exe: w1e11/w1e11.cs
	mcs w1e11/w1e11.cs -out:build/w1e11.exe

w1e12: build/w1e12.exe
build/w1e12.exe: w1e12/w1e12.cs
	mcs w1e12/w1e12.cs -out:build/w1e12.exe
