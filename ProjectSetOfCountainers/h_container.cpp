#include<iostream>
#include<fstream>
#include<string>
#include<sstream>
#include<queue>

#include "lstack.cpp"
#include "lqueue.cpp"
#include "linked_list.cpp"
#include "double_linked_list.cpp"

using namespace std;

template <typename T>
class Object {
public:
    using Condition = bool (*)(T const&);
    virtual bool insert(T const&) = 0;
    virtual bool remove(T&) = 0;
    virtual bool member(T const&) = 0;
    virtual int l_size() = 0;
    virtual void sort() = 0;
    virtual void obj_filter(Condition) = 0;
    virtual bool special_condition(Condition) = 0;
    virtual void print(ostream& os) const = 0;
    virtual ~Object() {}

};

template <typename T>
class StackObject : public Object<T>, private LinkedStack<T> {
public:
    using Condition = bool (*)(T const&);

	// включване
	bool insert(T const& x) {
		LinkedStack<T>::push(x);
		return true;
	}

	// изключване
	bool remove(T& x) {
		if (LinkedStack<T>::empty())
			return false;
		x = LinkedStack<T>::pop();
		return true;
	}

	//проверка
	 bool member(T const& x){
         return LinkedStack<T>::member(x);
	 }

    int l_size() {
       return my_size(*this);
    }

	// извеждане
	void print(ostream& os) const {
		os << *this;
	}

	void sort(){
	   s_sort(*this);
	}

    void obj_filter(Condition c){
      filter(c,*this);
    }

    bool special_condition(Condition c){
	      return q_filter(c,*this);
}
};

template <typename T>
class QueueObject : public Object<T>, private LinkedQueue<T> {
public:
    using Condition = bool (*)(T const&);

	// включване
	bool insert(T const& x) {
		LinkedQueue<T>::enqueue(x);
		return true;
	}

	/// изключване
	bool remove(T& x) {
		if (LinkedQueue<T>::empty())
			return false;
		x = LinkedQueue<T>::dequeue();
		return true;
	}

	///Търсене
    bool member(T const& x){
      return LinkedQueue<T>::member(x);
    }

    int l_size() {
       return my_size_q(*this);
    }

    void sort(){
       q_sort(*this);
    }
	/// извеждане
	void print(ostream& os) const {
		os << *this;
	}

	 void obj_filter(Condition c){
      filter(c,*this);
    }


    bool special_condition(Condition c){
       return q_filter(c,*this);
 }
};

template <typename T>
class DoubleListObject : public Object<T>, private DoubleLinkedList<T> {
public:
    using Condition = bool (*)(T const&);

	// включване
	bool insert(T const& x) {
		DoubleLinkedList<T>::insertEnd(x);
		return true;
	}

	/// изключване
	bool remove(T& x) {
		if (DoubleLinkedList<T>::empty())
			return false;
		 DoubleLinkedList<T>::deleteEnd(x);
		return true;
	}

	///Търсене
    bool member(T const& x){
      return DoubleLinkedList<T>::member(x);
    }

    int l_size() {
       return my_size_dl(*this);
    }

    void sort(){
       dl_sort(*this);
    }

     void obj_filter(Condition c){
       filter(c,*this);
    }

	/// извеждане
	void print(ostream& os) const {
		os << *this;
	}

    bool special_condition(Condition c){
       return my_filter(c,*this);
}
};
/*
template <typename T,typename Condition>
bool special_condition(DoubleListObject<T>& dl,Condition c){
       return my_filter(dl,c);
}
*/
template <typename T>
ostream& operator<<(ostream& os, Object<T>* o) {
	o->print(os);
	return os;
}

class QueueStackList : public LinkedList<Object<int>*> {
using Condition = bool (*)(int const&);
public:
	~QueueStackList() {
		for(LinkedListIterator<Object<int>*> it = this->begin(); it; ++it)
			delete *it;
	}

	void read_from_file();
	bool if_in_conteiner(int);
	void all_filter(Condition);
	void l_insert(int);
	void l_sort();
    void from_l_to_txt();
    void print();
};

void QueueStackList::read_from_file(){
ifstream inf("list_of_containers.txt");

    string line;
    while(getline(inf,line)){
    if(line.compare("stack") == 0) {
         insertEnd(new StackObject<int>);
        }
    else if(line.compare("queue") == 0) {
         insertEnd(new QueueObject<int>);
        }
    else if(line.compare("list") == 0) {
         insertEnd(new DoubleListObject<int>);
        }
    else{
    if (line.empty()) break;
    istringstream iss(line);
    int next = 0;
    while (iss >> next)
       {

           (*((*this).end()))->insert(next);

       }
    }
  }
  inf.close();
}

bool QueueStackList::if_in_conteiner(int x){
  for(LinkedListIterator<Object<int>*> it = (*this).begin(); it; ++it)
  if ((*it)->member(x)){
           return true;
  }
  return false;
}
void QueueStackList::all_filter(Condition c){
for(LinkedListIterator<Object<int>*> it = (*this).begin(); it; ++it){
        (*it)->obj_filter(c);
  }
}

void QueueStackList::l_insert(int k){
  int s = (*(*this).begin())->l_size();
  for(LinkedListIterator<Object<int>*> it = (*this).begin(); it; ++it){
     if(s > (*it)->l_size())
        s = (*it)->l_size();
  }
  for(LinkedListIterator<Object<int>*> jt = (*this).begin();jt;++jt){
    if ((*jt)->l_size() == s){
        (*jt)->insert(k);
        return;
    }
  }
}

void QueueStackList::l_sort(){
  for(LinkedListIterator<Object<int>*> it = (*this).begin(); it; ++it){
        (*it)->sort();
  }
}

void make_file(){
cout<<"Hello, type how many containers do you want to have in the H. list: ";
int n;
cin>>n;
string type;
cout<<"Write first type of container then numbers in it, and put 0 to show the end of inserting number in container!"<<endl;
ofstream out_file("list_of_containers.txt");
for(int i=0;i<n;i++){
      string type;
      cin >> type;
      out_file << type;
      out_file << endl;
        int tmp = 1;
        while(tmp!=0){
          cin >> tmp;
          if (tmp!=0){
            out_file << tmp << " "; }
          else
            out_file << endl;
      }
   }
}


void QueueStackList::from_l_to_txt(){
ofstream fo("change_containers.txt");
ifstream foo("list_of_containers.txt");

string line;
LinkedListIterator<Object<int>*> jt = (*this).begin();
while(getline(foo,line)){
    if(line.compare("stack") == 0 || line.compare("queue") == 0 || line.compare("list") == 0) {
         fo << line;
         fo << endl;
        }
    else{
         fo << (*jt);
         jt++;
         fo << endl;
      }
 }
 foo.close();
}

void QueueStackList::print(){
for(LinkedListIterator<Object<int>*> it = (*this).begin(); it; ++it)
  cout << (*it) << "  ";
  cout << endl;
}

int main(){
//make_file();
QueueStackList qsl;
qsl.read_from_file();
cout<<qsl.if_in_conteiner(1)<<endl;
cout<<qsl.if_in_conteiner(59)<<endl;
qsl.print();
qsl.l_insert(111);
qsl.l_insert(37);
qsl.print();
qsl.l_sort();
qsl.print();
qsl.from_l_to_txt();
///Пример за lambda-функция
cout << (*(qsl.begin()))->special_condition([](int const& x) -> bool { return x%2 == 0; });
///Пример за филтриране
qsl.all_filter([](int const& x) -> bool { return x%2 == 0; });
qsl.print();
return 0;
}
