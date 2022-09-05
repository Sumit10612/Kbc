import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Game } from 'src/app/model/game.model';
import { Question } from 'src/app/model/question.model';
import { GameService } from 'src/app/service/game.service';
import { QuestionService } from 'src/app/service/question.service';

@Component({
  selector: 'app-create-game',
  templateUrl: './create-game.component.html',
  styleUrls: ['./create-game.component.scss']
})
export class CreateGameComponent {

  height = (screen.height - screen.height * .35) + 'px';
  questions$ = this._questionService.questionsSubject$;
  game: Game = {
    name: '',
    questions: []
  };

  constructor(private _gameService: GameService,
    private _questionService: QuestionService,
    private _router: Router) { }

  editQuestion = (question: Question) => this._questionService.editQuestion(question);

  deleteQuestion = (question: Question) => this._questionService.deleteQuestion(question);

  onSubmit(questions: Question[]): void {
    this.game.questions = questions;
    this._gameService.addGame(this.game)
      .subscribe(() => this._router.navigate(['/dashboard']));
  }
}
