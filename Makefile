all: w1e1 w1e2 w1e3 w1e4 w1e5 w1e6 w1e7 w1e8 w1e9

w1e1: build/w1e1.exe
build/w1e1.exe: w1e1/w1e1.cs
	mcs w1e1/w1e1.cs -out:build/w1e1.exe

w1e2: build/w1e2.exe
build/w1e2.exe: w1e2/w1e2.cs
	mcs w1e2/w1e2.cs -out:build/w1e2.exe

w1e3: build/w1e3.exe
build/w1e3.exe: w1e3/w1e3.cs
	mcs w1e3/w1e3.cs -out:build/w1e3.exe

w1e4: build/w1e4.exe
build/w1e4.exe: w1e4/w1e4.cs
	mcs w1e4/w1e4.cs -out:build/w1e4.exe

w1e5: build/w1e5.exe
build/w1e5.exe: w1e5/w1e5.cs
	mcs w1e5/w1e5.cs -out:build/w1e5.exe

w1e6: build/w1e6.exe
build/w1e6.exe: w1e6/w1e6.cs
	mcs w1e6/w1e6.cs -out:build/w1e6.exe

w1e7: build/w1e7.exe
build/w1e7.exe: w1e7/w1e7.cs
	mcs w1e7/w1e7.cs -out:build/w1e7.exe

w1e8: build/w1e8.exe
build/w1e8.exe: w1e8/w1e8.cs
	mcs w1e8/w1e8.cs -out:build/w1e8.exe

w1e9: build/w1e9.exe
build/w1e9.exe: w1e9/w1e9.cs
	mcs w1e9/w1e9.cs -out:build/w1e9.exe
