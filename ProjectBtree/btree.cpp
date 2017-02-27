#define MAX 7

#include <iostream>
#include <string>
#include<fstream>
#include<queue>
#include "student.h"

using namespace std;


class TreeNode;
 struct mypair
    {
	TreeNode *next;
	Student key;
    };

class TreeNode
 {
	public:
	int numofkeys;
	mypair data[MAX];
	TreeNode *father;
	TreeNode *first;
	TreeNode();
	bool leafnode();
	void insert_in_node(mypair x);
	mypair split_node(mypair x);
    TreeNode *next_index(string x);
    void display_node();

  };

  void TreeNode::display_node() {
	int i;
	cout<<"(";
	for(i=0;i<numofkeys;i++)
		cout<<"**"<< data[i].key.getName()<<"** ";
	 cout<<")";
}

  TreeNode *TreeNode::next_index(string x) {
    int i;
	if( x.compare(data[0].key.getName()) < 0)
	   return first;
	for(i=1;i<numofkeys ;i++){
	  if((x.compare(data[i].key.getName()) < 0)
      || (x.compare(data[i].key.getName()) == 0))
	    return data[i-1].next;
    }
	return data[i-1].next;
}

 bool TreeNode::leafnode()  {
	if(data[0].next==NULL)
		return true;
	return false;
}

 void TreeNode::insert_in_node(mypair x) {
	int i = -1;
	for(i=numofkeys-1;i>=0 && data[i].key.getName().compare(x.key.getName())> 0;i--)
		data[i+1]=data[i];
	data[i+1]=x;
	numofkeys++;
}

 mypair TreeNode::split_node(mypair x) {
	TreeNode *T = new TreeNode;
	mypair my_pair1;
	int i,j,centre;
	centre=(numofkeys-1)/2;
	if( x.key.getName().compare(data[centre].key.getName())> 0)
	    {
		for(i=centre+1,j=0;i<=numofkeys;i++,j++)
			T->data[j]=data[i];
		 T->numofkeys=numofkeys-centre-1;
		 numofkeys=numofkeys-T->numofkeys;
		 T->insert_in_node(x);
		 T->first=T->data[0].next;
		 T->father=father;
		 my_pair1.key=T->data[0].key;
		 my_pair1.next=T;
		 for(i=1;i<T->numofkeys;i++)
			T->data[i-1]=T->data[i];
		 T->numofkeys--;
	    }
	 else
	    {
		 for(i=centre,j=0;i<numofkeys;i++,j++)
			T->data[j]=data[i];
		 T->numofkeys=numofkeys-centre;
		 numofkeys=numofkeys-T->numofkeys;
		 insert_in_node(x);
		 T->father=father;
		 my_pair1.key=T->data[0].key;
		 my_pair1.next=T;
		 for(i=1;i<T->numofkeys;i++)
			T->data[i-1]=T->data[i];
		 T->numofkeys--;
	    }
   return(my_pair1);
 }

 TreeNode::TreeNode() {
	      for(int i=0;i<=MAX;i++)
		   data[i].next=NULL;
	      numofkeys=0;
	      father=NULL;
	      first=NULL;
}

class Q ///За да обхождам дарвото
  {
	TreeNode *data[60];
	int R,F;
	public:
		Q()
		  {
			R=F=0;
		  }
		int empty()
		  {
			if(R==F)
				return 1;
			else
				return 0;
		  }
		TreeNode *deque()
		  {
			return data[F++];
		  }
		void  enque(TreeNode *x)
		    {
			data[R++]=x;
		    }
		void makeempty()
		   {
			R=F=0;
		   }
   };

class Btree
 {
	int max_num_keys;
	TreeNode *root;
	public:
		Btree(int n)
		   {
			max_num_keys=n;
			root=NULL;
		   }
		TreeNode *search(string x);
		void insert(Student x);
		void Delete(Student x);
		void displaytree();
		void to_txt_tree();
  };

void Btree::to_txt_tree(){
ofstream foo("tree_database.txt");
int i;
Q q1,q2;
	TreeNode *p;
	q1.enque(root);
	while(!q1.empty())
	  {
		q2.makeempty();
		while(!q1.empty())
		  {
			p=q1.deque();
                for(i=0;i<p->numofkeys;i++)
		            foo<<p->data[i].key;
			if(!p->leafnode())
			   {
				q2.enque(p->first);
				for(int i=0;i<p->numofkeys;i++)
					q2.enque(p->data[i].next);

			   }
		   }
		q1=q2;
	   }
}


TreeNode *  Btree::search(string x)
 {
	TreeNode *p = root;
	while(p)
	   {
		for(int i=0;i<p->numofkeys;i++)
			if(x.compare(p->data[i].key.getName()) == 0)
				return(p);
		p=p->next_index(x);
	   }
	return NULL;
 }

void Btree::displaytree()
   {
	Q q1,q2;
	TreeNode *p;
	q1.enque(root);
	while(!q1.empty())
	  {
		q2.makeempty();
		cout<<"\n";
		while(!q1.empty())
		  {
			p=q1.deque();
			p->display_node();cout<<"  ";
			if(!p->leafnode())
			   {
				q2.enque(p->first);
				for(int i=0;i<p->numofkeys;i++)
					q2.enque(p->data[i].next);

			   }
		   }
		q1=q2;
	   }
}

void Btree::insert(Student x)
  {
    mypair my_pair2;
    TreeNode *p,*q;
    my_pair2.key = x;
    my_pair2.next = NULL;
    if(root==NULL)
	{
	     root = new TreeNode;
	     root->insert_in_node(my_pair2);
	}
    else
	{
	    p=root;
	    while(!(p->leafnode()))
		  p=p->next_index(x.getName());
      if(p->numofkeys < max_num_keys)
		     p->insert_in_node(my_pair2);

	  else
		{
		     my_pair2=p->split_node(my_pair2);
		     while(1)
		       {
            if(p==root)
			    {
			       q=new TreeNode;
			       q->data[0]=my_pair2;
			       q->first=root;
			       q->father=NULL;
			       q->numofkeys=1;
			       root=q;
			       q->first->father=q;
			       q->data[0].next->father=q;
			       return;

			     }
            else
			     {
				p=p->father;
				 if(p->numofkeys < max_num_keys)
				   {
					p->insert_in_node(my_pair2);
					return;
				    }
				 else
					my_pair2=p->split_node(my_pair2);
			      }

			 }
		  }

	}
  }

 void Btree::Delete(Student x)
   {
      TreeNode *left,*right;
      mypair *centre;
      TreeNode *p,*q;
      int i,j,centreindex;
      p=search(x.getName());
      for(i=0;p->data[i].key != x; i++);
      /// if p is not a leaf TreeNode then locate its succеssor  in a leaf TreeNode,
      /// replace x with its successor/predecessor and delete it.
      if(!p->leafnode())
	{
	  q=p->data[i].next;
	  while(!q->leafnode())
	       q=q->first;
	  p->data[i].key=q->data[0].key;
	  p=q;
	  x=q->data[0].key;
	  i=0;
	}

		for(i=i+1;i<p->numofkeys;i++)
			p->data[i-1]=p->data[i];
		p->numofkeys--;

	   while(1)
	    {
		if(p->numofkeys >= max_num_keys/2 )
			return;
		if(p == root)
		   if(p->numofkeys>0)
		      return;
		   else
		      {
			 root = p->first;
			 return;
		      }

///В противен случай
		    q = p->father;
		    if(q->first == p || q->data[0].next == p)
		       {
			  left=q->first;
			  right=q->data[0].next;
			  centre=&(q->data[0]);
			  centreindex=0;
		       }
            else
		       {
			  for(i=1;i<q->numofkeys;i++)
				if(q->data[i].next == p)
				     break;
			  left=q->data[i-1].next;
			  right=q->data[i].next;
			  centre=&(q->data[i]);
			  centreindex=i;
		       }

	 ///Слaчай 1 :Ако лeвия връх има 1 в повече ключ, преместваме го от там

		   if(left->numofkeys > max_num_keys/2)
			 {
			      for(i=right->numofkeys-1;i>=0;i--)
				     right->data[i+1]=right->data[i];
			      right->numofkeys ++;
			      right->data[0].key = centre->key;
			      centre->key = left->data[left->numofkeys - 1].key;
			      left->numofkeys--;
			      return;
			  }
	 ///Случай 2 :Ако десния връх има 1 в повече ключ, преместваме го от там
		    else
			  if(right->numofkeys > max_num_keys/2)
			     {
			       left->data[left->numofkeys].key=centre->key;
			       left->numofkeys++;
			       centre->key=right->data[0].key;
			       for(i=1;i<right->numofkeys;i++)
				    right->data[i-1]=right->data[i];
			       right->numofkeys--;
			       return;
			     }
			   else
			    {  ///Съединяваме ляв и десен
				left->data[left->numofkeys].key=centre->key;
				left->numofkeys++;
				for(j=0;j<right->numofkeys;j++)
				    left->data[left->numofkeys+j]=right->data[j];
				left->numofkeys+=right->numofkeys;
				///Изтриваме pair-a от върха
				for(i=centreindex+1;i<q->numofkeys ;i++)
				    q->data[i-1]=q->data[i];
				q->numofkeys--;
				p=q;/// за следващи итерации
			     }
	      }
}

