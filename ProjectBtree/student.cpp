#ifndef _STUDENT_CPP
#define  _STUDENT_CPP

#include <iostream>
#include <string>
#include<fstream>

#include "student.h"

using namespace std;

Student::Student(string _name, double _mark, int _phone_number)
  :mark(_mark), phone_number(_phone_number){
     name = _name;
}

istream& operator>>(istream& is, Student& s){
   string firstName;
   string lastName;
   string tmpStr;
   is >> tmpStr; // "Name: "
   is >> firstName;
   is >> lastName;
   s.name = firstName + " " + lastName;
   is >> tmpStr; // "Grade: "
   is >> s.mark;
   is >> tmpStr; // "Phone: "
   is >> s.phone_number;
   return is;
}

ostream& operator<<(ostream& os, Student const& s){
  return os << "Name: "<<s.name<<" Grade: "<<s.mark<<" Phone: "<<s.phone_number<<endl;
}

bool Student::operator>(Student const& s) const{
  return name < s.getName();
}

bool Student::operator==(Student const& s) const{
  return name == s.getName();
}

bool Student::operator!=(Student const& s) const{
  return name != s.getName();
}

bool Student::operator<(Student const& s) const{
  return name > s.getName();
}


#endif // _STUDENT_CPP
