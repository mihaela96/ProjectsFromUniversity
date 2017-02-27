#ifndef DFA_H_INCLUDED
#define DFA_H_INCLUDED

#include<map>
#include<set>
#include <windows.h>
#include<utility>

class DFA {

private:
 int number_states;
 int startstate;
 set<int>finalstates;
 char* alphabet;
 typedef pair<int,char> trans;
 map<trans,int> transition;
public:
 DFA();
 DFA(DFA const&);
 ~DFA();
 DFA& operator=(DFA const&);
 DFA(int,int);

 void setfinal(int);
 void setmaps();
 void setalphabet();

 int getNumberState() const;
 int getStartstate() const;
 int returmap(const pair<int,char> sth);
 int finalstatesize() const;
 int countalpha() const;
 char* alpha() const;
 bool tranfind(int,char) const;
 bool iffinalstate(int) const;
 void print() const;
 bool isinalpha(char) const;

 void clearfinal();
 void newfinal(int x);
 void infolanguage();

 bool isAccepted(char* word);
 void errorstate();
 DFA& dopalnenie();
 DFA& obedinenie(DFA&);
 friend ostream& operator<<(ostream&,DFA const&);

};

DFA& se4enie (DFA& , DFA&);
#endif // DFA_H_INCLUDED

