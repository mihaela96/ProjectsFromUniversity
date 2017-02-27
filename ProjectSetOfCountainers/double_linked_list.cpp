#include <iostream>
#include <queue>
using namespace std;

#ifndef _DOUBLE_LINKED_LIST_CPP
#define _DOUBLE_LINKED_LIST_CPP

#include "list.h"
#include "lstack.cpp"

template <typename T>
struct DoubleLinkedListElement {
	T data;
	DoubleLinkedListElement *next, *prev;

	DoubleLinkedListElement(T _data = T(),
			DoubleLinkedListElement* _next = NULL,
			DoubleLinkedListElement* _prev = NULL)
		: data(_data), next(_next), prev(_prev) {}
};

template <typename T>
using Condition3 = bool (*)(T const&);

template <typename T>
class DoubleLinkedList;

template <typename T>
class DoubleLinkedListIterator :
		public Iterator<T, DoubleLinkedListIterator<T> > {
	DoubleLinkedListElement<T>* p;
public:

	DoubleLinkedListIterator(DoubleLinkedListElement<T>* _p = NULL)
			: p(_p) {}

	typedef Iterator<T, DoubleLinkedListIterator<T> > I;

	// оправя проблемите с използването на наследените префиксни оператори
	using I::operator++;
	using I::operator--;

	// придвижва итератора напред и връща новата позиция
	// O(1)
	I& operator++() {
		if (p != NULL)
			p = p->next;
		return *this;
	}


	// придвижва итератора назад и връща новата позиция
	I& operator--() {
		if (p != NULL)
			p = p->prev;
		return *this;
	}

	// достъп до елемент
	// O(1)
	T& operator*() const {
		// ВНИМАНИЕ: итераторът трябва да е валиден!
		return p->data;
	}

	// проверка за валидност
	// O(1)
	operator bool() const {
		return p != NULL;
	}

	bool operator==(I const& it) const {
		return p == ((DoubleLinkedListIterator<T> const&)it).p;
	}

	friend class DoubleLinkedList<T>;

};

template <typename T>
class DoubleLinkedList : public List<T, DoubleLinkedListIterator<T> > {
public:

	typedef DoubleLinkedListIterator<T> I;
	typedef DoubleLinkedListElement<T> E;

private:
	DoubleLinkedListElement<T> *front, *back;

public:
	DoubleLinkedList() : front(NULL), back(NULL) {}

	DoubleLinkedList(DoubleLinkedList const& l) : front(NULL), back(NULL) {
		this->copy(l);
	}

	DoubleLinkedList& operator=(DoubleLinkedList& l) {
		if (this != &l) {
			this->clean();
			this->copy(l);
		}
		return l;
	}

	~DoubleLinkedList() {
		this->clean();
	}

	// проверка за празнота
	// O(1)
	bool empty() const {
		return front == NULL;
	}

	// достъп до елемент на позиция
	// O(1)
	T& elementAt(I const& it) {
		return *it;
	}

	// връща позицията "начало на списъка"
	I begin() const {
		return I(front);
	}

	// връща позицията "край на списъка"
	I end() const {
		return I(back);
	}

	// включване преди позиция
	// O(1)
	bool insertBefore(T const& x, I const& it) {
		if (empty()) {
			back = front = new E(x);
			return true;
		}
		// back != NULL =! front
		if (!it)
			return false;
		// !empty() && it

		E* p = new E(x, it.p, it.p->prev);
		p->next->prev = p;
		if (front == it.p)
			// добавяме преди първия елемент
			front = p;
		else
			// не сме преди първия, значи предният трябва да сочи към p
			p->prev->next = p;

		return true;
	}

	// включване след позиция
	// O(1)
	bool insertAfter(T const& x, I const& it) {
		if (empty()) {
			front = back = new E(x);
			return true;
		}
		// front != NULL =! back
		if (!it)
			return false;
		// !empty() && it

		E* p = new E(x, it.p->next, it.p);
		p->prev->next = p;
		if (back == it.p)
			// добавяме след последния елемент
			back = p;
		else
			// не сме след последния, значи следващият трябва да сочи към p
			p->next->prev = p;

		return true;
	}

	// изключване преди позиция
	bool deleteBefore(T& x, I const& it) {
		I pit = it;
		--pit;
		return deleteAt(x, pit);
	}

	// изключване на позиция
	bool deleteAt(T& x, I const& it) {
		if (empty() || !it)
			return false;
		// !empty() && it

		if (front == it.p)
			// изтриваме първия
			front = it.p->next;
		else
			// не изтриваме първия, значи имаме предишен
			it.p->prev->next = it.p->next;

		if (back == it.p)
			// изтриваме последния
			back = it.p->prev;
		else
			// не изтриваме последния, значи имаме следващ
			it.p->next->prev = it.p->prev;

		x = *it;
		delete it.p;
		return true;
	}

	// изключване след позиция
	bool deleteAfter(T& x, I const& it) {
		I nit = it;
		++nit;
		return deleteAt(x, nit);
	}

	// O(1)
	void append(DoubleLinkedList<T>& l2) {
		if (empty())
			front = l2.front;
		else {
			back->next = l2.front;
			l2.front->prev = back;
		}
		back = l2.back;
		l2.front = l2.back = NULL;
	}


   bool member(T const& x){
     DoubleLinkedList<T> tmp;
     tmp = *this;
     int i = 0;
        while(!tmp.empty()){
           if (tmp.elementAt(tmp.end()) == x)
             return true;
           else
             tmp.deleteAt(i,tmp.end());
         }
      return false;
   }

};

template<typename T>
int my_size_dl(DoubleLinkedList<T> tmp){
  int i = 0;
  int j = 0;
    while(!tmp.empty())
      {
        j++;
        tmp.deleteAt(i,tmp.end());
      }
  return j;
}

template<typename T, typename Condition3>
bool my_filter(Condition3 func,DoubleLinkedList<T>& dl){
        DoubleLinkedList<T> tmp;
        tmp = dl;
        int x = 1;
       if((tmp).empty())
          return false;
       while(!tmp.empty()){
           if (func(*tmp.end()))
              return true;
            else
                tmp.deleteEnd(x);
       }
       return false;
}
template<typename T, typename Condition3>
void filter(Condition3 func,DoubleLinkedList<T>& l){
       LinkedStack<T> tmp;
       int x = 0;
       if(l.empty())
          return;
       while(!l.empty()){
           if (func(*(l.end())))
              l.deleteEnd(x);
            else {
              tmp.push(*(l.end()));
              l.deleteEnd(x); }
       }

       while(!tmp.empty()){
        l.insertEnd(tmp.peek());
        tmp.pop();
       }
}

template<typename T>
void dl_sort(DoubleLinkedList<T>& q){
  priority_queue<T> tmp;
  LinkedStack<T> tm ;
  int m;
  int i = 0;
  while(!q.empty()){
    m = q.elementAt(q.begin());
    tmp.push(m);
    q.deleteAt(i,q.begin());
  }

  int n;
  while(!tmp.empty()){
    n = tmp.top();
    tm.push(n);
    tmp.pop();
   }

  int y;
  while(!tm.empty()){
    y = tm.peek();
    q.insertEnd(y);
    tm.pop();
  }
}


#endif
