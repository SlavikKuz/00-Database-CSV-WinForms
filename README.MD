### Program

<img src="/Skjermbilde.png?raw=true" width="320"/>

It is a small library database that serializes data to a file. 
The task for the program included the following functions:
- add information to the database:
  - author's name;
  - name of the book/artickle;
  - year of publication;
  - publishing house
  - form of publication (paper/electronic)
-	delete information from the database (after the first letter of the name);
- record and store the data;
- read and view saved information from the file;
- add new data to the stored file;
- convenient and user friendly interface.

### Algorithm

Algorithm *Main*

<img src="/algorithm01.png?raw=true" width="320"/>

Algorithm *Delete*

<img src="/algorithm02.png?raw=true" width="320"/>

Algorithm *Add*

<img src="/algorithm03.png?raw=true" width="320"/>


### Data structure
The following data types were used in the project:
- Database:
  - *CSV* - output file extention;
  - public static class Globals; *C# does not support global variables, class stores refernces to the file*;
    - public static string Dir;
    - public static String File;
    - int lineCount *//count lines in the file*;
    - string [] split *//an array of fields for a book*;

-	private void addButton_Click *//Add records function*:
    - string fullLine *// contatinated line of all fields of the book for the record*;
    - string [] arrayShow *//an array of all fields of the book to be displayed*;
    - string[] readArray *//array for finding duplicates*;

- private void buttonRec_Click *//delete records function//:
  - char deleteChar *// a first letter of the name*;
  - string [] arrayDel *//a new array of book records for the deleting data*;
  - List < int > order *//list of positions of strings in arrayDel that contain deleteChar*;
  - int orderString *// the positions in arrayDel Containing deleteChar*.

- authorTextBox.Text, bookTextBox.Text, yearTextBox.Text, publisherTextBox.Text, editionComboBox.Text *//all values are converted to a type string*

### Description

Data.csv is a default file format *.CSV that can be imported by many programs. The file has a simple structure where each record of a single book is a separated with ";". 

A form initialization oppens after launching the program. Execution starts with a search for the file. If the file is missing, the program creates a folder and a file. If a file has already been created and it contains data, the program reads it and creates an array of lines. This array is passed to the *Listview* element that displays the content on the screen. Then program goes into standby mode for user input.

To add a new record, the user enters the full author name in the *Author* field. This field allows you to type only letters. If the author field is not filled in, the program will give the warning *"Please Enter Author!"*

*Book* field allows you to enter all characters and can also be blank.

In the *Year* field it is not possible to enter anything but numbers, and can also be empty. No limit on length here.

*Publisher* assumes input only letters.

In field *Edition*, the user selects between *Paper* and *E-book* values.

When user clicks on the button *Add*, the program records all the fields placing *";"* between them. Then program checks if a similar record is already in the database. If there is no matches, the data string is appended to the end of the file. It will be also displayed on the screen at the end of the list.

For filtering, the user enters the letter into *"Please enter filter letter"* and clicks the *"Del"* button. The box allows to enter only the letters. If you entered more than one letters, it is cropped to the first letter. If the field was empty, an alert is displayed to *enter the letter*.

Then the program makes a list of the positions in the array that containe that *letter*. If there is no such *letter*, the program gives a warning and asks to enter a new letter.

Thanks for attention!
