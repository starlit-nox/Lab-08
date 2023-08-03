# Lab-08-PhilsLendingLibrary
 
## Overview
Phil's Lending Library is a C# console app that allows users to add and borrow books from a pseudo Library. Users can view the books, add them, borrow them, and store them in their pack. 

## Getting Started
To build and run this app on your machine, follow the instructions below:

1.Clone this repository to your local machine.
2. Navigate to the Lab08 folder.
3. Open the solution file Lab08 in Visual Studio or your preferred C# development environment.
4. Build the solution to resolve any dependencies and compile the code.
5. Run the application by executing the Program.cs file.

## Demo

### Introduction

**"Howdy! Welcome to Phil's Lending Library. What can I do ya' for?"**
**Pick an option:**
1. View Books
2. Add Book
3. Borrow Book
4. Return Book
5. View Backpack
6. Exit

### Option 1: View Books

**Library Books:**
"Title" by Jane Doe, 50 pages
"Title2" by John Doe, 60 pages

Then it'll return you to the main menu.

### Option 2: Add Books

**Enter the title of the book:**
userInputHere

**Enter the author's first name:**
authorFirstNameHere

**Enter the author's last name:**
authorLastNameHere

**Enter the number of pages:**
numberValueHere

Then it'll return you to the main menu.

### Option 3: Borrow Book

**Enter the title of the book to borrow here:**
TItle

Then it'll return you to the main menu.

### Option 4: Return Book

**Enter the number of the book to return:**
You have to press the number which your book is located in your backpack inventory. 

Then it'll return you to the main menu. 

### Option 5: View Backpack

"Title" by Jane Doe, 50 pages

Then it'll return you to main menu. 

### Option 6: Exit

**Goodbye**

Closes out the console.

## Architecture

The application is built using C# and consists of the following classes:

**Book:** Represents a book with properties like title, author, and number of pages.

**Library:** Implements the ILibrary interface to manage the collection of books. It uses a private dictionary to store books.

**Backpack:** Implements the IBag<Book> interface to hold borrowed books. It uses a private list to store books.

**Program:** Contains the main method and serves as the user interface to interact with the library and backpack.

The application uses the .NET framework and C# language. It includes interfaces (ILibrary and IBag) to define the required functionality for the library and backpack. The code follows object-oriented design principles, and collections are used for data storage and management.
