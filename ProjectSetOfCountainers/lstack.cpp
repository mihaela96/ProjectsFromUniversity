#ifndef LSTACK_CPP_
#define LSTACK_CPP_

#include <iostream>
using namespace std;

template <typename T>
struct StackElement {
	T data;
	StackElement* next;
};


template <typename T>
using Condition1 = bool (*)(T const&);


template <typename T>
class LinkedStack {
private:
	StackElement<T>* top;

public:
	LinkedStack();
    LinkedStack(LinkedStack const&);
	LinkedStack& operator=(LinkedStack const&);
	bool empty() const;
	bool member(T const& x);
	T peek() const;
	void push(T const&);
	T pop();
	~LinkedStack();
};

template<typename T>
ostream& operator<<(ostream& os, LinkedStack<T> s){
  while(!s.empty()){
     os << s.peek() <<" ";
     s.pop();
    }
  return os;
}

template <typename T>
LinkedStack<T>::LinkedStack() {
	top = NULL;
}

template<typename T,typename Condition1>
bool q_filter(Condition1 func,LinkedStack<T>& s){
        LinkedStack<T> tmp;
        tmp = s;
       if((tmp).empty())
          return false;
       while(!tmp.empty()){
           if (func(tmp.peek()))
              return true;
            else
                tmp.pop();
       }
       return false;
}

template<typename T, typename Condition2>
void filter(Condition2 func,LinkedStack<T>& q){
       LinkedStack<T> tmp;
       if(q.empty())
          return;

       while(!q.empty()){
           if (func(q.peek()))
              q.pop();
            else {
              tmp.push(q.peek());
              q.pop();}
       }

       while(!tmp.empty()){
        q.push(tmp.peek());
        tmp.pop();
       }
}

template<typename T>
int my_size(LinkedStack<T> tmp){
  int i = 0;
    while(!tmp.empty()){
      i++;
      tmp.pop();
    }
  return i;
}

template<typename T>
void s_sort(LinkedStack<T>& s){
  int tmp1,tmp_min;
  LinkedStack<T> first_stack, second_stack;

  tmp1 = s.pop();
  if(s.empty()){
    s.push(tmp1);
    return;
   }
   s.push(tmp1);

   while(!s.empty()){
      tmp1 = s.peek();
      first_stack.push(tmp1);
      s.pop();
   }

   while(!first_stack.empty()){
      tmp_min = first_stack.peek();
      first_stack.pop();
      second_stack.push(tmp_min);

       while(!first_stack.empty()){
          tmp1 = first_stack.peek();
          first_stack.pop();
          if(tmp_min < tmp1)
            tmp_min = tmp1;
          second_stack.push(tmp1);
        }

        while(!second_stack.empty()){
          tmp1 = second_stack.peek();
          second_stack.pop();
          if (tmp_min == tmp1)
             s.push(tmp1);
          else
             first_stack.push(tmp1);
         }
    }
}

template<typename T>
bool LinkedStack<T>::member(T const& x){
  LinkedStack<T> tmp;
  tmp = *this;
  while(!tmp.empty()){
    if (tmp.peek() == x)
        return true;
    else
       tmp.pop();
  }
  return false;
}

template <typename T>
bool LinkedStack<T>::empty() const {
	return top == NULL;
}

template <typename T>
T LinkedStack<T>::peek() const {
	if (empty()) {
		cout << "Error!The stack is empty!\n";
		return 0;
	}

	return top->data;
}

template <typename T>
void LinkedStack<T>::push(T const& x) {
	StackElement<T>* p = new StackElement<T>;
	p->data = x;
	p->next = top;
	top = p;
}

template <typename T>
T LinkedStack<T>::pop() {
	if (empty()) {
		cout << "Error!The stack is empty!\n";
		return 0;
	}
	StackElement<T>* p = top;
	top = top->next;
	T x = p->data;
	delete p;
	return x;
}

template <typename T>
LinkedStack<T>::~LinkedStack() {

	StackElement<T>* toDelete;
	while (top != NULL) {
		toDelete = top;
		top = top->next;
		delete toDelete;
	}
}

template <typename T>
LinkedStack<T>::LinkedStack(LinkedStack<T> const& ls)
	: top(NULL) {

	*this = ls;
}

template <typename T>
LinkedStack<T>& LinkedStack<T>::operator=(LinkedStack<T> const& ls) {
	if (this != &ls) {
		while (!empty()) pop();

		StackElement<T>* toCopy = ls.top;
		StackElement<T> *copy, *lastCopied = NULL;
		while (toCopy != NULL) {
			copy = new StackElement<T>;

			if (top == NULL)
				top = copy;

			copy->data = toCopy->data;

			if (lastCopied != NULL)
				lastCopied->next = copy;

			// преместване на указателите
			lastCopied = copy;
			toCopy = toCopy->next;

		}
		if(lastCopied!=NULL)
		    lastCopied->next = NULL;
	}
	return *this;
}

#endif
