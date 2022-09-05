import { Injectable } from '@angular/core';
import { BehaviorSubject, Subject } from 'rxjs';

import { Question } from '../model/question.model';


@Injectable({
  providedIn: 'root'
})
export class QuestionService {

  private _dummyQuestion: Question = {
    text: '',
    options: [
      { text: '', isCorrect: true },
      { text: '', isCorrect: false },
      { text: '', isCorrect: false },
      { text: '', isCorrect: false },
    ]
  }

  private _questions: Question[] = [];

  private _questionsSubject = new BehaviorSubject(this._questions);
  questionsSubject$ = this._questionsSubject.asObservable();

  private _newQuestion = new BehaviorSubject<Question>(JSON.parse(JSON.stringify(this._dummyQuestion)));
  newQuestionSubject$ = this._newQuestion.asObservable();

  constructor() { }

  editQuestion = (question: Question) => this._newQuestion.next(question);

  addQuestion = () => this._newQuestion.next(JSON.parse(JSON.stringify(this._dummyQuestion)));

  pushQuestion(question: Question): void {
    this._questions.push(question);
    this._questionsSubject.next(this._questions);
  }

  deleteQuestion(question: Question): void {
    let index = this._questions.indexOf(question);
    if (index >= 0)
      this._questions.splice(index, 1);
    this._questionsSubject.next(this._questions);
  }
}
