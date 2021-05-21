# TranzactChallenge

This app was develop to resolve the challenge for a new position in Tranzact.

For use the app, you need to execute the TZ.AtNinjas.App.SearchFight.exe from cmd or for testproject (method 4) sending any words as parameters. You can compile the exe from the solution or use the exe inside release.zip.

(example: .net, java, etc; you can use "java script" (¿?) as a word too ... . )

PD: This app use some "scrapping" techniche, with HttpClient, use (or better not use) in Production enviroments with care. The search engines have their own api's to access results, but... i think that this is enough
to resolve the challenge (or at least i think so... :'))

PD2: If you clean or recompile test project, ensure to create a file with name "UnitTestProject1.dll.config" that will be a copy of TZ.AtNinjas.App.SearchFight.exe.config, in other way you cant run the last test method 4.

PD3: In test cases and in release, ensure to change the last parameter "useProxy" to false (in normal execute variable is on json config file)

![alt text](https://github.com/tkMageztik/TranzactChallenge/blob/main/code%20coverage.png?raw=true)

2)
![alt text](https://github.com/tkMageztik/TranzactChallenge/blob/main/code%20coverage2.png?raw=true)

