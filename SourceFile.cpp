#include<iostream>
#include<cstring>
#include<vector>
#include <windows.h>
#include <conio.h>
using namespace std;

#include"official.h"

//������������� �� ����� Book

Book::Book(){
 author="";
 name="";
 description="";
 year=0;
 word="";
 janr="";
 reiting=0;
 number=0;
}

void Book::SetAuthor(string a){
     author=a;
}
void Book::SetDescription(string b){
     description=b;
}
void Book::SetJanr(string j){
     janr=j;
}
void Book::SetName(string n){
     name=n;
}
void Book::SetWord(string w){
      word=w;
}
void Book::SetYear(int _year){
   year=_year;
}
void Book::SetReiting(int _reiting){
   reiting=_reiting;
}
void Book::SetNumber(int _number) {
  number=_number;
}
bool Book::before(Book const& a1,Book const& a2){
 return a1.year<a2.year;
}
bool Book::beforee(Book const& b1,Book const& b2){
 return b1.reiting<b2.reiting;
}
Book::Book(string author1,string name1,string janr1,string description1,int year1,string word1,int reiting1,int number1){
    SetAuthor(author1);
    SetName(name1);
    SetJanr(janr1);
    SetDescription(description1);
    SetYear(year1);
    SetWord(word1);
    SetReiting(reiting1);
    SetNumber(number1);
}
void test4();

int Book::GetNumber() const {
   return number;
}
void Book::booksprint(){

     cout<<"���: "<<name<<endl;
     cout<<"A����: "<<author<<endl;
     cout<<"�������: "<<reiting<<endl;
     cout<<"���������� �����: "<<number<<endl;
     cout<<endl;
}
void Book::printall(){
     cout<<"���: "<<name<<endl;
     cout<<"A����: "<<author<<endl;
     cout<<"�������: "<<reiting<<endl;
     cout<<"������: "<<year<<endl;
     cout<<"��������: "<<description<<endl;
     cout<<"���������� �����: "<<number<<endl;
     cout<<endl;

}
bool Book::find(string option,string value){
string a ="name";
string b ="author";
string c ="word";
if(option==a && name==value) {
    return true;
  }
else if(option==b && author==value){
      return true;
}
else if(option==c && value==word){
      return true;
}
 else
 {
return false;
}
}
void Book::booksfind(string option,string value){
string a ="name";
string b ="author";
string c ="word";
if(option==a && name==value) {
    cout<<"�����: "<<name<<" �������� �� "<<author;
  }

else if(option==b && author==value){
      cout<<"�����: "<<author<<" �����: "<<name<<endl;
  }

else if(option==c && value==word){
      cout<<"������� ����: "<<word<<" �����: "<<name<<endl;
}
 else
 {
  cout<<"���� �����������!"<<endl;
}
}

//������������� �� ����� USER

User::User(){
   username="";
   password="";
   acess=false;
}
User::User(string _username,string _password,bool _acess){

username=_username;
password=_password;

 acess=_acess;
}
void User::setNewPass(){
  string b;
  cin>>b;
  password=b;
}
bool User::login(string n,string p){
   if (username==n && password==p){
    acess=true;
    return true;
   }
return false;
}
void User::logout(){
 acess=false;
}

void User::deletepass(string namenew1){
if(username==namenew1){
   cout<<"�������� ����� ������:";
   string passnew;
   getline(cin,passnew);
   if(password==passnew){
    string passnew1;
    string namenew1;
    cout<<"�������� ���� ���: ";
    getline(cin,namenew1);
    username=namenew1;
    cout<<"�������� ���� ������: ";
    getline(cin,passnew1);
    password==passnew1;
   }
 else {
   cout<<"������ ������!"<<endl;
 }
}
}
void User::chanepass(string namenew){
    if(username==namenew){
   cout<<"�������� ����� ������:";
   string passnew;
   getline(cin,passnew);
   if(password==passnew){
    string passnew1;
    cout<<"�������� ���� ������: ";
    getline(cin,passnew1);
    password==passnew1;
   }
else {
  cout<<"������ ������!"<<endl;
   }
}
}
void myswap(Book& w1,Book& w2){
    Book c;
    c=w1;
    w1=w2;
    w2=c;
}
void knigi(int,vector<Book>);
void test3(){
cout<<"****************************************************"<<endl;
cout<<"*******************����������***********************"<<endl;
cout<<"***  1.������� �� �������                        ***"<<endl;
cout<<"***  2.���������� �� ����� � ���������� �����    ***"<<endl;
cout<<"***  3.������ ����� �� �����e��� ��������        ***"<<endl;
cout<<"***  4.��������� �� ����� �� �������e� ��������  ***"<<endl;
cout<<"***  5.�������� �� �����                         ***"<<endl;
cout<<"***  6.���������� �� �����                       ***"<<endl;
cout<<"***  7.����� �� ������ �� ������                 ***"<<endl;
cout<<"***  8.���������� �� ������ � �������� �� ���    ***"<<endl;
cout<<"***  9.�������� �� ���������                     ***"<<endl;
cout<<"***                                              ***"<<endl;
cout<<"****************************************************"<<endl;
}
void knigistara(int t, vector<Book> &a6){
int num;
cout<<"�������� �������� ����� ��  �������, ����� ������ �� ����������: ";
cin>>num;
for(int k=0;k<t;k++){
     if(a6[k].GetNumber()==num){
        if(k!=(t-1)){
         cout<<"�� �������: "<<endl;
         a6[k].booksprint();
         myswap(a6[k],a6[t-1]);
         a6.pop_back();
         break;
     }
     else {
       a6.pop_back();
       break;}
}
}}
void kniginova(int t,vector<Book> &a5){
string author1;
cout<<"�������� �����: ";
cin.ignore();
getline(cin,author1);
cout<<endl;
cout<<"�������� ��� �� �����:";
string name1;
cin.ignore();
getline(cin,name1);
cout<<endl;
cout<<"�������� ����: ";
string janr1;
cin.ignore();
getline(cin,janr1);
cout<<endl;
cout<<"�������� ��������: ";
string description1;
cin.ignore();
getline(cin,description1);
cout<<endl;
cout<<"�������� ������: ";
int year1;
cin>>year1;
cout<<"�������� ������� ����: ";
string word1;
cin.ignore();
getline(cin,word1);
cout<<endl;
cout<<"�������� �������: ";
int reiting1;
cin>>reiting1;
int number1;
number1=100+t+1;
Book nova(author1,name1,janr1,description1,year1,word1,reiting1,number1);
a5.push_back(nova);
}
void knigisort(int t,vector<Book> &a4){
   string a="year";
   string b="reiting";
   string nowo;
   cout<<"�������� ��������(year , reiting): ";
   cin>>nowo;
 if(nowo==a) {
    for(int i=0;i<t;i++){
      sort(a4.begin(),a4.end(),Book::before);
    }
 }
 if(nowo==b){
   for(int i=0;i<t;i++){
      sort(a4.begin(),a4.end(),Book::beforee);
    }
 }
 for(int j=0;j<t;j++){
   a4[j].printall();
 }
}
void knigi(int t,vector<Book> a1){
  for(int i=0;i<t;i++){
     a1[i].printall();
  }

}
void knigiinfo(int t,vector<Book> a2){
int p;
cout<<"�������� ����� �� �����: ";
cin>>p;
bool flag=false;
for(int i=0;i<t;i++){
  if(a2[i].GetNumber()==p){
     flag=true;
     a2[i].printall();
     break;
  }
  else
     flag=false;
}
if(flag==false){
  cout<<"���� ������ ����� � ����� �����!"<<endl;
}
}
void knigisearch(int t,vector<Book> a3){
 string option1;
 string value1;
 cout<<"�������� ��������(name , author , word): ";
 cin>>option1;
 cout<<"�������� ��������: ";
 cin.ignore();
 getline(cin,value1);
 int br=0;
 for(int k=0;k<t;k++){
    if(a3[k].find(option1,value1)){
    a3[k].booksfind(option1,value1);
 }
 else { br++; }
}
if(br==t) { cout<<"���� ������������!"<<endl;}
}
void changepass(User* a1){
cout<<"��� ������ ������ �� ���������: ";
string namenew;
cin.ignore();
getline(cin,namenew);
 for(int i=0;i<5;i++){
    a1[i].chanepass(namenew);
 }
}
void changeuser(User* a2){
cout<<"��� ������ ������ �� ���������: ";
string namenew1;
cin.ignore();
getline(cin,namenew1);
 for(int i=0;i<5;i++){
  a2[i].deletepass(namenew1);
 }
}
void test2();

void test4(User *employee1){
vector<Book>lib;
Book first("������ �����������","������� ����������������","�������",
"���� � ������� ������������ �� ��������� �������������.���� �����  ������� ����������� ������������ � �������� �� �������, ������ ������ ��������  ��������� �� �� �������.",
1760,"�����������",10,100);
Book second("���� ������ ���","�� ���������","����������",
"� ���� ����� ��� ������� �� ���������� �� ��������, ����� � ��     �������������� �� ��������������. ��� ���������� ���������� �� ��� �������      ������� ����� ������������ ��������� � ������������ ����.",
1859,"����",8,101);
Book third("��� �����","��������� �� ��� �����","�����",
"������� ������ ��������� �� ������� ��� �����, ����� � ����������� �� 2 ������ �� ���� �� ���������� �������� ������ ��� ����������� �� � ��������. ���� 1944 �� �� �������� � �������� � ��������������� �����, ������ ��� ������ �������� �� ��� � �����.",
1947,"�����",9,102);
Book fourth("������ ������","���� ������","������-����������",
"����� ������ ����������� �������� ����������� �� �����������      ����� �������� ����� � ��������� ������. �������, ���� ����, �������� ����������� ��������� � �������� �� ����������.",
1962,"�������",6,103);
lib.push_back(first);
lib.push_back(second);
lib.push_back(third);
lib.push_back(fourth);
int n=0;
   while(n!=9){
   cout<<"������ ����� �: ";
   cin>>n;
   int t=lib.size();
   switch(n){
 case 1: knigi(t,lib); break;
 case 2: knigiinfo(t,lib); break;
 case 3: knigisearch(t,lib); break;
 case 4: knigisort(t,lib); break;
 case 5: kniginova(t,lib); break;
 case 6: knigistara(t,lib); break;
 case 7: changepass(employee1); break;
 case 8: changeuser(employee1); break;
  }
}
}

void test2(){
 SetConsoleCP(1251);
 SetConsoleOutputCP(1251);
 cout<<"~~~~~~~~~~~~~����� �����!~~~~~~~~~~~~~~"<<endl;
 cout<<"~~~~~                            ~~~~~~"<<endl;
 cout<<"~~~~~�������� ���������� � ������~~~~~~"<<endl;
  string nam="";
  string pass="";
  cout<<"����������: "; cin>>nam;
  char ch;
  cout<<"������: ";
   ch = _getch();
   while(ch != 13){
      pass.push_back(ch);
      cout <<'*';
      ch = _getch();
   }
cout<<endl;
User employee[5];
employee[0]=User("mihaela","12345",false);
employee[1]=User("ivan_bg","feelgood",false);
employee[2]=User("irena_pld","1996",false);
employee[3]=User("teodoraDD","1988",false);
employee[4]=User("admin","i<3c++",false);

 for(int i=0;i<5;i++){
     if(employee[i].login(nam,pass))
     {
         cout<<"������� "<<nam<<"! "<<endl;
         test3();
         break;
     }
     else {
       cout<<"���� ����� �����������!"<<endl;
       break;
     }
 }
 test4(employee);
}

int main(){
test2();
return 0;
}
