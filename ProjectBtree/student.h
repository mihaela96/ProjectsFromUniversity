#ifndef STUDENT_H_INCLUDED
#define STUDENT_H_INCLUDED

#include <string>
#include<iostream>

class Student {

  std::string name;
  double mark;
  int phone_number;
public:

  Student(std::string _name = "anonimous", double = 2, int = 0);
  std::string getName() const { return name; }
  double getMark() const { return mark; }
  int getPhone() const { return phone_number;}
  void setMark(double newmark) { mark = newmark; }
  void setPhone(int newphone) { phone_number = newphone; }
  friend std::istream& operator>>(std::istream& is, Student& s);
  friend std::ostream& operator<<(std::ostream& os, Student const& s);
  bool operator>(Student const& s) const;
  bool operator<(Student const& s) const;
  bool operator==(Student const& s) const;
  bool operator!=(Student const& s) const;

};


#endif // STUDENT_H_INCLUDED
