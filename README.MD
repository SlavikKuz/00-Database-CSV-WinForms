OBS! Machine translation. Please, see images algorithm1-3.png for clarification. 

It is necessary to develop a software complex for the creation and processing of files used to store information. For effective work, the program should perform the following functions:
1.	To database the following information:
the author's name;
Name of the work;
Year of publication;
Publishing house
form of publication: paper or electronic
2.	Delete information from the database:
at: First letter of the name;
3.	Records the contents of the database into a file;
4.	Reading and viewing saved and information the file;
5.	Adding new data to the generated file;
6.	Convenient and understandable program.

Data structure
The following data types were used to perform the task:
1.	Database. CSV-The main file of the data record. It uses:
Created public static class Globals; C# does not support global variables, and the program should always refer to the file:
Globals.Dir – public static String Dir;
Globals.File - public static String File.
int lineCount – counting lines in a file;
string [] Split – An array for book fields, which is readable by one line from the file and is divided into fields;
2.	private void addButton_Click for the Add records function:
String fullLine – line of all fields of the book for the record;
string [] arrayShow – an array of all fields of the book to be displayed;
String[] readarray – array find duplicates.
3.	private void buttonRec_Click to delete records function:
Char deleteChar – a letter from which the name to delete is started;
string [] arrayDel – A new array for the remaining period;
List < int > order – List of position strings In arrayDel Containing deleteChar;
int orderString – The positions are In arrayDel Containing deleteChar.
4.	authorTextBox.Text, bookTextBox.Text, yearTextBox.Text, publisherTextBox.Text, editionComboBox.Text – All field values are converted to a type string.All field values are converted to a type string.


Program Description

Data. csv is a default file format *.CSV in which you can easily convert files, such as tables MS Excel. The file has a simple structure where each record of one book is a separate tape, and the fields are separated by a symbol ";". This means that the data. csv can be imported by a lot of programs. Another advantage of the CSV file is the fact that you are breaking the Ribbon into words, ";" serves as a reliable marker, so it is almost never found in Names Books.
A form initialization occurs after launching the program. Execution starts with a search for the file. If the file is missing, the program creates a folder and a file. If a file has already been created and it contains data, the program is reads data and forms an array of lines consisting of 5 words. This array is passed to the Listview element that displays the content on the screen. This runs to the end of the file. Then program goes into standby mode for user input.
To add a new record, the user enters the full author name in the Authorfield. This field allows you to type only letters. If the author field is not filled in, you try to add the program will give the warning "Please Enter Author! ".
Book field allows you to enter all characters and can also be blank.
In the Year field It is not possible to enter anything other than numbers, can also be empty. No limit on length there.
Publisher assumes input only letters.
In field Edition, the user selects between two Paper and E-book values.
When input all the data, user Click on the button "Add". The program records data contatinating all the fields and placing ";" between them. Then program checks if similar record is already in the database. If there is no matches, the data string is appended to the end of the file. Also with is displayed on the screen at the end of the list.
For filtering, the user enters the letter into "Please enter filter letter" and Click the "Del" button. The box allows to enter only the letters. If you entered more than one letters that you enter are cropped to the first letter. If the field was empty, an alert is displayed to enter the letter.
After that, the program generates an array term from the recorded file and looks for the terms that begin with the typed letter. The program lists the positions in the array. If there is no such term, the program notifies you and prompts you to enter a new letter.
The term position list will be rolled out in descending order, and using the cycle is deleted from the end. The database file rewrite and is displayed on the screen. The program enters further user actions.





 
 
 
