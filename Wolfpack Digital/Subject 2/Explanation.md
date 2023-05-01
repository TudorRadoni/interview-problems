# Choices

This file explains the class hierarchy I have created.

## Abstract Class

I have chosen to use an abstract class Student rather than an interface because abstract classes should be used primarily for objects that are closely related, whereas interfaces are best suited for providing a common functionality to unrelated classes.

## Student Class

Since all students must have an ID and a name, they are fields in this base class. It also contains a constructor to initialise them, making it easier for the rest of the classes to initialise their specific fields.
The method which calculates tuition has a common signature across the implementing classes, therefore it is also declared here.

## InStateStudent Class

This implements the above class, but, in addition, it contains the semester fee for each student (I was thinking that students could belong to different faculties of the university they study at, hence the field). This class uses the base class's constructor to initialise the Name and ID properties, and also initialises its own SemesterFee property through its constructor.

## OutOfStateStudent Class

Same as before, a SemesterFee field is used, but here we also store the per-credit fee. We still use the base class's constructor and we initialise the class specific properties in its constructor. To calculate the tuition, we just add the product of the per-credit fee and number of credits and then add it to the flat rate.
