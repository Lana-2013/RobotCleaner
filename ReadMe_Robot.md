This is Robot Cleaner App. This can be run through both console and React UI.
By default the robot is positioned at 0,0,NORTH position on start up.
Below you will find more details on each of the projects in Robot Cleaner solution.

## Robot Cleaner React App

You can run the Robot Cleaner Web app directly from Visual Studio by setting it as start up proj.
The web interface lets you select multiple robot commands like PLACE/MOVE/LEFT/RIGHT/REPORT
For Place command you will need to enter the x/y/direction first.
After you click place you will be prompted with a message confirmation that robot is placed successfully.

You can also on click MOVE/LEFT/RIGHT or REPORT.
REPORT command will also prompt with the current Robot position.

## Robot Cleaner Console App

Robot Cleaner console App references- RobotCleaner.WebAPI to perform the robot tracker commands.
When you open the console, you will be promped to enter the Robot commands - PLACE/MOVE/LEFT/RIGHT/REPORT
You can enter any of the commands to proceed or press 'x/X' to exit.

When you enter command - PLACE, there will be a prompt to enter the coordinate in order - x,y,direction
For example - 0,0,North

Rest of the commands can be entered in any order and in lower/upper case.
MOVE
LEFT
RIGHT
REPORT

REPORT command will print the current robot position.

You can Press x/X to exit the console.

## Robot Cleaner Web API

Robot Cleaner Web API contains all the model classes and also logic for all the Robot Tracker commands

## Robot Cleaner Tests

This project includes all the test cases mentioned in the test and a few more.
Example Input and Output:
a)
PLACE 0,0,NORTH
MOVE
REPORT
Output: 0,1,NORTH

b)
PLACE 0,0,NORTH
LEFT
REPORT
Output: 0,0,WEST

c)
PLACE 1,2,EAST
MOVE
MOVE
LEFT
MOVE
REPORT
Output: 3,3,NORTH


