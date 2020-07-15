# parking-structure
How to run the project:
1. Unzip all files.
2. Use IntelliJ to open folder “ParkingPalJavaServices” (you should see a black symbol near the folder symbol in IntelliJ). If IntelliJ reports some errors in files about missing some classes, you should add “javax.json-api-1.0.jar” into the libraries through “Project Structure”. We have put “javax.json-api-1.0.jar” file in the folder “....../ParkingPalJavaServices\lib”. Note: we use glassfish 5.0.0, so you need to add glassfish server in editing configuration. 
3. Run this Java Server, then you should see your default web browser launches a new tab or window with the homepage of the Java server. If you get the message “Welcome to Parking Pals” you have successfully launched the server. 
4. Use Visual Studio to open four projects in four distinct windows: 
   1. “ParkingPalDBWS.sln” in “....../ParkingPalDBWS”
   2. “UpdateService.sln” in “....../UpdateService”
   3. “DeleteAccount.sln” in “....../DeleteAccount”
   4. “ParkingPalsClientSide.sln” in “....../ParkingPalsClientSide”
5. For any database connection, please change the database connection string according to the local path of the “ParkingPalConnection.mdf” file in the folder “....../ParkingPalDBWS\ParkingPalDBWS\App_Data”. In the original codes, the connection string contains the following part: “C:\\Users\\Gavin\\Downloads\\559A_Final_Submission\\ParkingPalDBWS\\ParkingPalDBWS\\App_Data\\ParkingPalConnection.mdf”. You should change this part to your actual local path of the file ““ParkingPalConnection.mdf”. Note: you do not need to change connection string in ParkingPalDBWS project, but for the other C# projects, you have to change them one by one.
6. Run ParkingPalDBWS Server then you should see your default web browser launches a new tab or window with the homepage of this server.
7. Run UpdateService Server then you should see your default web browser launches a new tab or window with the homepage of this server.
8. Run DeleteAccount Server then you should see your default web browser launches a new tab or window with the homepage of this server.s
9. Run ParkingPalsClientSide Server. Note: Must run the server from ParkingPalsPage.aspx.cs, because other pages may check the request QueryString, but at the beginning, you do not provide it.
10. Congraducations! You can start to explore this project!
