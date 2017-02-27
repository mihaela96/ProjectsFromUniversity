using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateXmlFile
{
    class FirstXmlFile
    {
        public static void create30Question(XmlFile file)
        {
            //make list of questions
            
            string[] textOfQuestions = new string[30];
            List<string>[] answersOfEachQuestion = new List<string>[30];
            int[] answer = new int[30];

            #region Define30Question

            //1.
            textOfQuestions[0] = "C# class can inherit multiple ________?";
            answersOfEachQuestion[0] = new List<string>() { "Class", "Interface", "Abstract class", "Static class" };
            answer[0] = 2;

            //2.
            textOfQuestions[1] = "Which of the followings are value types in C#?";
            answersOfEachQuestion[1] = new List<string>() { "Int32", "Double", "Decimal", "All of the above" };
            answer[1] = 4;

            //3.
            textOfQuestions[2] = "What is Nullable type?";
            answersOfEachQuestion[2] = new List<string>()
                     {
                       "It allows assignment of null to reference type.",
                       "It allows assignment of null to value type.",
                       "It allows assignment of null to static class.",
                       "None of the above." };
            answer[2] = 1;

            //4.
            textOfQuestions[3] = "Struct is a _____?";
            answersOfEachQuestion[3] = new List<string>() { "Reference type", "Value type", "Class type", "String type" };
            answer[3] = 2;

            //5.
            textOfQuestions[4] = "10 > 9 ? “10 is greater than 9” : “9 is greater than 10” is an example of _______?";
            answersOfEachQuestion[4] = new List<string>() {
                "Ternary operator",
                "Conditional operator",
                "Greater than operator",
                "Inverse operator" };
            answer[4] = 2;

            //6.
            textOfQuestions[5] = "Which of the following datatype can be used with enum?";
            answersOfEachQuestion[5] = new List<string>() { "Int", "String", "Boolean", "All of the above" };
            answer[5] = 4;

            //7.
            textOfQuestions[6] = "If s1 and s2 are references to two strings, then which of the following is the correct way to compare the two references ?";
            answersOfEachQuestion[6] = new List<string>() {
                "s1 = s2",
                "s1 == s2",
                "strcmp(s1, s2)",
                "s1.Equals(s2)" };
            answer[6] = 4;
            
            //8.
            textOfQuestions[7] = "String data type is ______?";
            answersOfEachQuestion[7] = new List<string>() { "Mutable", "Immutable", "Static", "Value type" };
            answer[7] = 1;

            //9.
            textOfQuestions[8] = "An array in C# starts with _____ index?";
            answersOfEachQuestion[8] = new List<string>() { "One", "Zero", "-1", "None of the above" };
            answer[8] = 2;

            //10.
            textOfQuestions[9] = "Which of the following is right way of declaring an array?";
            answersOfEachQuestion[9] = new List<string>()
            {  "Int[] intArray = new int[];",
               "Int intArray[] = new int[5];",
               "Int[] intArray = new int[5];",
               "Int[] intArray = new int[]{1, 2, 3, 4, 5};" };
            answer[9] = 3;

            //11.
            textOfQuestions[10] = "Which of the following is true for ReadOnly variables?";
            answersOfEachQuestion[10] = new List<string>() {
                "Value will be assigned at runtime.",
                "Value will be assigned at compile time.",
                "Value will be assigned when it accessed first time",
                "None of the above" };
            answer[10] = 1;

            //12.
            textOfQuestions[11] = "Which of the following statement is true?";
            answersOfEachQuestion[11] = new List<string>() {
                "An argument passed to a ref parameter need not be initialized first.",
                "Variables passed as out arguments need to be initialized prior to being passed.",
                "Argument that uses params keyword must be the last argument of variable argument list of a method.",
                "To use a ref parameter only the calling method must explicitly use the ref keyword." };
            answer[11] = 3;

            //13.
            textOfQuestions[12] = "Which of the following is the necessary condition for implementing delegates?";
            answersOfEachQuestion[12] = new List<string>() {
                "Class declaration",
                "Inheritance",
                "Run-time Polymorphism",
                "Exceptions" };
            answer[12] = 1;

            //14.
            textOfQuestions[13] = "Assume class B is inherited from class A. Which of the following statements is correct about construction of an object of class B ?";
            answersOfEachQuestion[13] = new List<string>() {
                "While creating the object firstly the constructor of class A will be called followed by constructor of class B.",
                "The constructor of only class B will be called.",
                "While creating the object firstly the constructor of class B will be called followed by constructor of class A.",
                "The order of calling constructors depends upon whether constructors in class A and class B are private or public." };
            answer[13] = 1;

            //15.
            textOfQuestions[14] = "Which of the following statements is incorrect about delegate?";
            answersOfEachQuestion[14] = new List<string>() {
                "Delegates are object oriented.",
                "Delegates are type-safe.",
                "Delegates serve the same purpose as function pointers in C and pointers to member function operators in C++",
                "Only one method can be called using a delegate." };
            answer[14] = 4;

            //16.
            textOfQuestions[15] = "Which of the following statements are correct about Inheritance in C#.NET?";
            answersOfEachQuestion[15] = new List<string>() {
                "Inheritance cannot suppress the base class functionality.",
                "A derived class may not be able to access all the base class data.",
                "Inheritance cannot extend the base class functionality.",
                "None of the above" };
            answer[15] = 2;

            //17.
            textOfQuestions[16] = "Which of the following CANNOT be used as an underlying datatype for an enum in C#.NET?";
            answersOfEachQuestion[16] = new List<string>() { "byte", "short", "float", "int" };
            answer[16] = 3;

            //18.
            textOfQuestions[17] = "Which of the following statements is correct about an enum used inC#.NET?";
            answersOfEachQuestion[17] = new List<string>()
                     {
                       "By default the first enumerator has the value equal to the number of elements present in the list?",
                       "The value of each successive enumerator is decreased by 1.",
                       "An enumerator contains white space in its name.",
                       "A variable cannot be assigned to an enum element." };
            answer[17] = 4;

            //19.
            textOfQuestions[18] = "Which of the following statements is valid about advantages of generics?";
            answersOfEachQuestion[18] = new List<string>() {
                "Generics shift the burden of type safety to the programmer rather than compiler.",
                "Generics provide type safety without the overhead of multiple implementations.",
                "Generics eliminate the possibility of run-time errors.",
                "None of the above." };
            answer[18] = 2;

            //20.
            textOfQuestions[19] = "Which of the following statements is valid about generics in .NET Framework?";
            answersOfEachQuestion[19] = new List<string>() {
                "We can create a generic class, however, we cannot create a generic interface in C#.NET.",
                "Generics delegates are not allowed in C#.NET.",
                "Generics are useful in collection classes in .NET framework.",
                "None of the above." };
            answer[19] = 3;

            //21.
            textOfQuestions[20] = "Which of the following statements is correct?";
            answersOfEachQuestion[20] = new List<string>() {
                "Only one object can be created from an abstract class.",
                "By default methods are virtual.",
                "If a derived class does not provide its own version of virtual method then the one in the base class is used.",
                "If the method in the derived class is not preceded by override keywords, the compiler will issue a warning and the method will behave as if the override keyword were present." };
            answer[20] = 3;

            //22.
            textOfQuestions[21] = "Which of the following modifier is used when a virtual method is redefined by a derived class?";
            answersOfEachQuestion[21] = new List<string>() {
                "override",
                "overridable",
                "virtual",
                "base" };
            answer[21] = 1;

            //23.
            textOfQuestions[22] = "Which of the following statement is correct about the Stack collection?";
            answersOfEachQuestion[22] = new List<string>() {
                "All elements in the Stack collection can be accessed using an enumerator.",
                "It is used to maintain a FIFO list.",
                "All elements stored in a Stack collection must be of similar type.",
                "None of the above." };
            answer[22] = 1;

            //24.
            textOfQuestions[23] = "The [Serializable()] attribute gets inspected at?";
            answersOfEachQuestion[23] = new List<string>() { "Compile-time", "Run-time", "Design-time", "None of the above" };
            answer[23] = 2;

            //25.
            textOfQuestions[24] = "Which of the following statement is correct about the this reference?";
            answersOfEachQuestion[24] = new List<string>()
            {  "this reference can be modified in the instance member function of a class.",
               "Static functions of a class never receive the this reference.",
               "this reference continues to exist even after control returns from an instance member function.",
               "All of the above." };
            answer[24] = 2;

            //26.
            textOfQuestions[25] = "Which of the following is true for ReadOnly variables?";
            answersOfEachQuestion[25] = new List<string>() {
                "Value will be assigned at runtime.",
                "Value will be assigned at compile time.",
                "Value will be assigned when it accessed first time",
                "None of the above" };
            answer[25] = 1;

            //27.
            textOfQuestions[26] = "Which of the following preprocessor directive defines a sequence of characters as symbol in C#?";
            answersOfEachQuestion[26] = new List<string>() {
                "define",
                "undef",
                "region",
                "endregion" };
            answer[26] = 1;

            //28.
            textOfQuestions[27] = "Which of the following is the correct about class destructor?";
            answersOfEachQuestion[27] = new List<string>() {
                "A destructor is a special member function of a class that is executed whenever an object of its class goes out of scope.",
                "A destructor has exactly the same name as that of the class with a prefixed tilde (~) and it can neither return a value nor can it take any parameters.",
                "Both of the above.",
                "None of the above." };
            answer[27] = 3;

            //29.
            textOfQuestions[28] = "Which of the following access specifier in C# allows a class to hide its member variables and member functions from other class objects and functions, except a child class within the same application?";
            answersOfEachQuestion[28] = new List<string>() { "Protected Internal", "Private", "Protected", "Internal" };
            answer[28] = 1;

            //30.
            textOfQuestions[29] = "Which of the following is correct about C#?";
            answersOfEachQuestion[29] = new List<string>() {
                "C# is a modern, general-purpose, object-oriented programming language developed by Microsoft.",
                "C# was developed by Anders Hejlsberg and his team during the development of .Net Framework.",
                "C# is designed for Common Language Infrastructure (CLI).",
                "All of the above." };
            answer[29] = 4;

            #endregion

            //initialize this list of questions

            List<Question> quiz = new List<Question>();
            for(int i = 0; i < 30; i++)
            {
                quiz.Add(new Question(textOfQuestions[i], answersOfEachQuestion[i], answer[i]));
            }
            
            file.FillXml(quiz);
        }
        static void Main(string[] args)
        {
            XmlFile testFile = new XmlFile("testC#.xml");

            create30Question(testFile);

        }
    }
  }