#include <iostream>
#include<cstring>
#include<map>
#include<set>
#include <windows.h>
#include<utility>

using namespace std;

#include "dfa.h"

 int const startERROR = -3;
 int const ERRORSTATEN = -2;
 char const e_prehod = '*';

DFA::DFA(){
  number_states = 0;
  startstate = startERROR;
  finalstates.clear();
  transition.clear();
  alphabet=NULL;
}

DFA::DFA(DFA const& copydfa):number_states(copydfa.number_states),
                         startstate(copydfa.startstate),
                         finalstates(copydfa.finalstates),
                         transition(copydfa.transition)
{
  int n = strlen(copydfa.alphabet) + 1;
          if(alphabet!=NULL)
	delete[] alphabet;
	alphabet = new char[n];
	strncpy(alphabet,copydfa.alphabet, n);
	alphabet[n - 1] = '\0';
}

DFA::~DFA(){
 delete [] alphabet;
}

DFA& DFA::operator=(DFA const& df){
     if(&df!=this){
     number_states=df.number_states;
     startstate=df.startstate;
     finalstates=df.finalstates;
     transition=df.transition;
     delete []alphabet;
    int n = strlen(df.alphabet) + 1;
	alphabet = new char[n];
	strncpy(alphabet,df.alphabet, n);
	alphabet[n - 1] = '\0';
     }
}

DFA::DFA(int a,int b){
 number_states = a;
 startstate=b;
  setfinal(a);
  setalphabet();
  setmaps();
}

void DFA::setfinal(int a){
 int p=0;
 cout<<"Enter final states, eventually indicate a negative number:";
 int t[a];
 do{
   cin>>t[p];
   p++;
 } while(t[p-1]>=0);       //int g = -1
for(int i=0;i<p;i++){
  if(t[i]>=0)
  finalstates.insert(t[i]);
}

}

void DFA::setalphabet(){
char alpha[66];
cout<<"Enter alphabet: ";
cin>>alpha;

int m =strlen(alpha) + 1;
for(int i=0;i<m-1;i++){
    if((alpha[i]<'0' || alpha[i]>'9') && (alpha[i]<'a' || alpha[i]>'z') && (alpha[i]<'A' || alpha[i]<'Z')){
    cout<<"You have entered the wrong character alphabet should only consist of letters and numbers!"<<endl;
    cout<<"Entered the alphabet: ";
    cin>>alpha;
    break;
}}
	//delete[] alphabet;
	alphabet = new char[m];
	strncpy(alphabet,alpha, m);
	alphabet[m - 1] = '\0';
}

void DFA::setmaps(){
char ip;
int num=0;
int begin, end;
cout<<"Enter the machine throught the following criteria: state - point(character) - state (such as for the machine type state - mark = - state):"<<endl;
  do {
    cin>>begin>>ip>>end;
    if(!isinalpha(ip) && ip!='='){
        cout<<"The letter you entered is not in the language !:"<<endl;}

    if(ip!='='){
    pair<int, char> trans1 = make_pair(begin,ip);
    transition[trans1] = end;
    }
} while (ip!='=');
}

int DFA::getNumberState() const {
     return number_states;
}

int DFA::getStartstate() const {
     return startstate;
}

int DFA::returmap(const pair<int,char> sth){
     return transition[sth];
}

int DFA::finalstatesize() const {
     return finalstates.size();
}

int DFA::countalpha() const {
     return strlen(alphabet);
}

char* DFA::alpha() const {
     return this->alphabet;
}

bool DFA::tranfind(int state,char alpha) const {
    if(transition.count(pair<int,char>(state,alpha))==1)
           return true;
    else
    return false;

}

bool DFA::iffinalstate(int x) const {
  if(finalstates.count(x)==1)
       return true;
return false;
}

void DFA::print() const{
        cout<<"DFA start state: "<<startstate<<endl;
	    cout<<"DFA end states: ";
	    for(set<int>::const_iterator i=finalstates.begin();i!=finalstates.end();i++)
		cout<<*i<<" ";
	    cout<<endl;

	    for(map<pair<int,char>,int>::const_iterator i=transition.begin();
		    i!=transition.end();i++)
	    {
		cout<<"Function of transition["<<(i->first).first<<","<<(i->first).second<<"]="<<i->second<<endl;
	    }

}
bool DFA::isinalpha(char sth) const{
  for(int i=0;i<strlen(alphabet);i++){
     if(sth==alphabet[i])
             return true;
  }
return false;
}

void DFA::clearfinal() {
     finalstates.clear();
}

void DFA::newfinal(int x) {
     finalstates.insert(x);
}

void DFA::infolanguage(){
if(finalstates.count(0)!=0){
  cout<<"LANGUAGE recognize the empty word!"<<endl;
}
if(number_states==1 && transition.empty()==true){
  cout<<"Language is empty!"<<endl;
}
int k=0;
for(int i=0;i<number_states;i++){
  for(int j=0;j<strlen(alphabet);j++){
     pair<int,char> first = make_pair(i,alphabet[j]);
     if(transition.count(first) && transition[first]==i){
       cout<<"The language is NOT final!"<<endl;
       k=1;
       break;
     }
  }
  if(k==1)
     break;
}
int numb=0;
for(int i=0;i<number_states;i++){
  for(int j=0;j<strlen(alphabet);j++){
     pair<int,char> first = make_pair(i,alphabet[j]);
     if(transition.count(first) && transition[first]!=i){
       numb++;
     }
  }
}
if(numb==transition.size())
    cout<<"Language is final!"<<endl;

if(finalstates.size()==(number_states-1) && finalstates.count(0)==false && transition.size()== (number_states*strlen(alphabet)))
  cout<<"Language is full!"<<endl;
}


bool DFA::isAccepted(char* word){
  int current_state = startstate;
  int p=strlen(word);
 for(int i=0;i<p;i++){
    pair<int,char> tran1=make_pair(current_state,word[i]);
    if(transition.find(tran1) == transition.end()){
         return false;
    }
    current_state=transition[tran1];
}
   if(finalstates.find(current_state)!=finalstates.end()){
        return true;
   }
 else
       return false;
}

void DFA::errorstate(){
    int al=0;
    while(alphabet[al]!='\0'){
      al++;
     }
    int errorstate1 = number_states;
   for(int i=startstate;i<number_states;i++){
       for(int j=0;j<al;j++){
           pair<int,char> tried = make_pair(i,alphabet[j]);
           if(transition.count(tried)==0)
           {
               pair<int,char> novo = make_pair(i,alphabet[j]);
               transition[novo] = errorstate1;
           }
           pair<int,char> vazel = make_pair(errorstate1,alphabet[j]);
               transition[vazel] = errorstate1;
       }
   }number_states++;
   cout<<"Where "<<number_states-1<<" is error - state!"<<endl;
}


DFA& DFA::dopalnenie(){
    if(transition.size()==number_states*strlen(alphabet)){
    int sizef1 = finalstates.size();
    int st1[sizef1];
    int p1=0;
for (set<int>::iterator it1=finalstates.begin(); it1!=finalstates.end(); it1++){
    st1[p1]=*it1;
    p1++;
   }
finalstates.clear();
for(int i1=startstate;i1<number_states;i1++){
   for(int j1=0;j1<sizef1;j1++){
      if(i1!=st1[j1]){
         finalstates.insert(i1);
      }
   }
  }
}
  else {
    errorstate();
    int sizef = finalstates.size();
    int st[sizef];
    int p=0;
for (set<int>::iterator it=finalstates.begin(); it!=finalstates.end(); it++){
    st[p]=*it;
    p++;
   }
finalstates.clear();
for(int i=startstate;i<number_states;i++){
   for(int j=0;j<sizef;j++){
      if(i!=st[j]){
         finalstates.insert(i);
      }
   }
 }
}
 return *this;
}

DFA& DFA::obedinenie(DFA& d1){
 for(int i=0;i<strlen(alphabet);i++){
     const pair<int,char> tr=make_pair(startstate,e_prehod);
       transition.insert(pair<const pair<int,char>,int>(tr,d1.getStartstate() + number_states));
 }
 char * newalphabet = d1.alpha();
 for(int j=d1.getStartstate();j<d1.getNumberState();j++){
     for(int k=0;k<d1.countalpha();k++){
        if(d1.tranfind(j,newalphabet[k])){
        int novprehod = d1.returmap(pair<int,char>(j,newalphabet[k])) + number_states;
       const pair<int,char> trd1=make_pair(j+number_states,newalphabet[k]);
       transition.insert(pair<const pair<int,char>,int>(trd1,novprehod));
        }
        if(d1.iffinalstate(j))
              finalstates.insert(j+number_states);
 }
 }
 number_states = number_states + d1.getNumberState();
 return *this;
}

ostream& operator<<(ostream& os,DFA const & a){
      a.print();
}

void onthescreen() {
//SetConsoleCP(1251);
//SetConsoleOutputCP(1251);
cout<<"***********************************************************"<<endl;
cout<<"**********Deterministic finite automatonò******************"<<endl;
cout<<"***                                                     ***"<<endl;
cout<<"***  1.Display machine                                  ***"<<endl;
cout<<"***  2.Check whether a word is in the language of the mashine ***"<<endl;
cout<<"***  3.Add error-state                                  ***"<<endl;
cout<<"***  4.Addition to introducing machine                  ***"<<endl;
cout<<"***  5.Unification entered machine with another machine ***"<<endl;
cout<<"***  6.Information for language, recognizable by the machine  ***"<<endl;
cout<<"***  7.Exit                                             ***"<<endl;
cout<<"***                                                     ***"<<endl;
cout<<"***********************************************************"<<endl;
}

void just_to_start(){
    startt:
SetConsoleCP(1251);
SetConsoleOutputCP(1251);
int k,t;
     cout<<"Enter the number of state of the mashine: ";
     cin>>k;
     cout<<"Enter the start state:";
     cin>>t;
DFA myauto(k,t);
int n = 1;
while(n>0 && n<=8){
   cout<<"Your choice is: ";
   cin>>n;
   switch(n){
 case 1: myauto.print(); break;
 case 2: {
   char word[100];
   cout<<"Enter the word you want to check: ";
   cin>>word;
   if(myauto.isAccepted(word))
        cout<<"ACCEPTED"<<endl;
    else
        cout<<"CANCELLED"<<endl;
 } break;
 case 3:{
    myauto.errorstate();
    myauto.print();
 } break;
 case 4:{
    myauto.dopalnenie();
    myauto.print();
 } break;
 case 5: {
  int k,t;
     cout<<"Enter the number of state of the OTHER mashine: ";
     cin>>k;
     cout<<"Enter the start state:";
     cin>>t;
DFA newauto(k,t);
myauto.obedinenie(newauto);
myauto.print();
 } break;
 case 6: {
   myauto.infolanguage();
 } break;
 case 7: {
  cout<<"BYE!"<<endl;

 } break;
  }
}
}

int main(){
  onthescreen();
  just_to_start();
return 0;
}

