#define MAX 7

#include <iostream>
#include <string>
#include<fstream>
#include<queue>

#include "Btree.cpp"

using namespace std;

class Mydatabase{

private:
  void makedatabase();

public:
  Mydatabase();
  void from_file_to_tree(Btree&);
  void getGradebyName(Btree, string);
  void getPhonebyName(Btree, string);
  void updateGrade(Btree&, string,double);
  void updatePhone(Btree&, string,int);
  void sorted_database();
  void deleting(Btree&,string);
};

Student* readStudent(int n){
   Student* s = new Student[n];
   for(int i=0;i<n;i++){
         cin >> s[i];
   }
   return s;
}

void writeStudent(Student* s, int n){
   ofstream fo("my_database.txt");
   for(int i=0;i<n;i++){
         fo << s[i];
   }
}

void Mydatabase::makedatabase(){
Student students[10];
students[0] = Student("Ivan P",4.25,87954521);
students[1] = Student("Marina P",5.75,97254521);
students[2] = Student("Petar I",3.15,88845723);
students[3] = Student("Stilqn P",2.65,95745812);
students[4] = Student("Ivelina V",3.20,78745861);
students[5] = Student("Margarita I",4.50,85421457);
students[6] = Student("Boqn P",6.00,98632541);
students[7] = Student("Iliqn K",3.00,78389699);
students[8] = Student("Ivan D",4.18,86574287);
students[9] = Student("Georgi L",5.61,85749354);
writeStudent(students,10);
}

Mydatabase::Mydatabase(){
  makedatabase();
}

void Mydatabase::from_file_to_tree(Btree& l){
 ifstream sf("my_database.txt");
	Student s;
	while( sf >> s){
        l.insert(s);
	}
}

void Mydatabase::getGradebyName(Btree tree, string name){
  if(tree.search(name)!= NULL){
    TreeNode *temp = tree.search(name) ;
    double tmpmark;
    for(int i=0;i<temp->numofkeys;i++){

      if(name.compare(temp->data[i].key.getName()) == 0){
        tmpmark = temp->data[i].key.getMark();
        cout<<endl<<"The grade of "<<name<<" is "<<tmpmark<<endl;
        return;
     }
    }

  }
  else {
    cout<<"There isn't student named "<<name<<endl;
  }
}
void Mydatabase::getPhonebyName(Btree tree, string name){
  if(tree.search(name)!= NULL){
    TreeNode *temp = tree.search(name) ;
    int tmpmark;
    for(int i=0;i<temp->numofkeys;i++){

      if(name.compare(temp->data[i].key.getName()) == 0){
        tmpmark = temp->data[i].key.getPhone();
        cout<<"The phone of "<<name<<" is "<<tmpmark<<endl;
        return;
     }
    }

  }
  else {
    cout<<"There isn't student named "<<name<<endl;
  }
}

void Mydatabase::updateGrade(Btree& tree, string name,double newGrade){
  if(tree.search(name)!=NULL){
    TreeNode *temp = (tree.search(name)) ;
    for(int i=0;i<temp->numofkeys;i++){
      if(name.compare(temp->data[i].key.getName()) == 0)
         temp->data[i].key.setMark(newGrade);
    }
  }
  else
    cout<<"There isn't student named "<<name<<endl;
}

void Mydatabase::deleting(Btree& tree,string name){
if(tree.search(name)!=NULL){
    TreeNode *temp = (tree.search(name)) ;
    for(int i=0;i<temp->numofkeys;i++){
      if(name.compare(temp->data[i].key.getName()) == 0)
         tree.Delete(temp->data[i].key);
    }
  }
  else
    cout<<"There isn't student named "<<name<<endl;

}

void Mydatabase::updatePhone(Btree& tree, string name,int newPhone){
  if(tree.search(name)!=NULL){
        TreeNode *temp = (tree.search(name)) ;
    for(int i=0;i<temp->numofkeys;i++){
      if(name.compare(temp->data[i].key.getName()) == 0)
         temp->data[i].key.setPhone(newPhone);
    }
  }
  else
    cout<<"There isn't student named "<<name<<endl;
}

void Mydatabase::sorted_database(){
priority_queue<Student> myq;
 ifstream sf("tree_database.txt");
	Student s;
	while( sf >> s){
        myq.push(s);
	}
while(!myq.empty()){
    cout<<myq.top();
    myq.pop();
}
}

int main() {
      Mydatabase base;
      Student x;
      Btree b(4);
        cout<<"\n\n1)Insert\n2)Search\n3)Delete\n4)Print\n5)Quit"<<endl;

		cout<<endl<<"Insert: "<<endl;
				base.from_file_to_tree(b);
				b.displaytree();
       cout<<endl<<"New insertation: "<<endl;
         Student x1("Mihaela R",3.47,7898745);
         Student x2("Elena T",4.87,7895478);
         b.insert(x1);
         b.insert(x2);
         b.displaytree();
       cout<<endl<<"Deleting: "<<endl;
          base.deleting(b,"Veliqn T");
          base.deleting(b,"Mihaela R");
          b.displaytree();
       cout<<endl<<"Searching: "<<endl;
			base.getGradebyName(b,"Stilqn P");
			base.getGradebyName(b,"Monika I");
			base.getPhonebyName(b,"Ivan D");
      cout<<endl<<"Changing: "<<endl;
         base.updateGrade(b,"Petar I",5.28);
         base.updatePhone(b,"Ivelina I",254781);
         base.updateGrade(b,"Teo D",3.14);
         b.displaytree();
         base.getGradebyName(b,"Petar I");

      cout<<endl<<"From tree to txt"<<endl;
      b.to_txt_tree();

     base.sorted_database();

   return 0;
}
