#ifndef LQUEUE_CPP_
#define LQUEUE_CPP_

#include<iostream>
#include<queue>
#include "lstack.cpp"
using namespace std;

template <typename T>
struct QueueElement {
	T data;
	QueueElement* next;

	QueueElement(T const& _data = T(), QueueElement* _next = NULL) :
		data(_data), next(_next) {}
};

template <typename T>
using Condition2 = bool (*)(T const&);

template <typename T>
class LinkedQueue {
	QueueElement<T> *front, *back;

	void copy(LinkedQueue<T> const& q) {
		for(QueueElement<T>* p = q.front;p != NULL;p = p->next)
			enqueue(p->data);
	}

	void clean() {
		while (!empty())
			dequeue();
	}

public:

	LinkedQueue() : front(NULL), back(NULL) {}

	LinkedQueue(LinkedQueue const& q) : front(NULL), back(NULL) {
		copy(q);
	}

	LinkedQueue& operator=(LinkedQueue const& q) {
		if (this != &q) {
			clean();
			copy(q);
		}
		return *this;
	}

	~LinkedQueue() {
		clean();
	}

	bool empty() const {
		return back == NULL;
	}

	bool member(T const& x){
        LinkedQueue<T> tmp;
        tmp = *this;
        while(!tmp.empty()){
           if (tmp.head() == x)
             return true;
           else
             tmp.dequeue();
         }
      return false;
   }

		void enqueue(T const& x) {
		QueueElement<T>* p = new QueueElement<T>(x);
		if (!empty()) {
			back->next = p;
		} else
			front = p;
		back = p;
	}

	T dequeue() {
		if (empty()) {
			cerr << "The queue is empty!\n";
			return T();
		}
		QueueElement<T>* p = front;
		front = front->next;
		if (front == NULL)
			back = NULL;
		T x = p->data;
		delete p;
		return x;
	}

	T head() const {
		if (empty()) {
			cerr << "The queue is empty!\n";
			return T();
		}
		return front->data;
	}

};

template<typename T>
ostream& operator<<(ostream& os, LinkedQueue<T> q){
  while(!q.empty()){
    os << q.head() << " ";
    q.dequeue();
  }
  return os;
}

template<typename T>
int my_size_q(LinkedQueue<T> tmp){
  int i = 0;
    while(!tmp.empty())
      {
        i++;
        tmp.dequeue();
      }
  return i;
}

template<typename T, typename Condition2>
bool q_filter(Condition2 func,LinkedQueue<T>& q){
        LinkedQueue<T> tmp;
        tmp = q;
       if((tmp).empty())
          return false;
       while(!tmp.empty()){
           if (func(tmp.head()))
              return true;
            else
                tmp.dequeue();
       }
       return false;
}

template<typename T, typename Condition2>
void filter(Condition2 func,LinkedQueue<T>& q){
       LinkedQueue<T> tmp;
       if(q.empty())
          return;
       while(!q.empty()){
           if (func(q.head()))
              q.dequeue();
            else{
              tmp.enqueue(q.head());
              q.dequeue(); }
       }

       while(!tmp.empty()){
        q.enqueue(tmp.head());
        tmp.dequeue();
       }
}

template<typename T>
void q_sort(LinkedQueue<T>& q){
  priority_queue<T> tmp;
  LinkedStack<T> tm ;
  int m;
  while(!q.empty()){
    m = q.head();
    tmp.push(m);
    q.dequeue();
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
    q.enqueue(y);
    tm.pop();
  }
}

#endif
